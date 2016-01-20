using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using Mono.Zeroconf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocketSharp;

namespace ProPresenterRemote
{
    internal class Client : IDisposable
    {
        private readonly string password;

        private WebSocket ws;

        private Timer refetchTimer;

        public event EventHandler StageDisplayLayoutsChanged;

        public event EventHandler Authenticated;

        public event EventHandler ClocksChanged;

        public Client(string password)
        {
            this.password = password;
        }

        private void Connect(IPAddress address, int port)
        {
            if (this.ws != null && (this.ws.ReadyState == WebSocketState.Connecting || this.ws.ReadyState == WebSocketState.Open))
                return;

            if (this.ws != null)
            {
                this.ws.Close();
                this.ws = null;
            }

            this.ws = new WebSocket("ws://" + address + ":" + port + "/remote");
            this.ws.OnMessage += (sender, args) => { this.OnReceive(args.Data); };
            this.ws.Connect();

            if (this.ws.ReadyState == WebSocketState.Open)
            {
                this.Authenticate();

                this.refetchTimer = new Timer(this.Refetch, null, 0, 500);
            }
        }

        private void Refetch(object o)
        {
            this.QueryStageDisplay();
            this.QueryTimers();
        }

        public void StartConnection()
        {
            ServiceBrowser browser = new ServiceBrowser();
            
            browser.ServiceAdded += (_, args) => {
                args.Service.Resolved += (__, args2) => {
                    IResolvableService s = args2.Service;
                    this.Connect(s.HostEntry.AddressList[0], 50001);
                };

                args.Service.Resolve();
            };
            
            browser.Browse("_pro6proremote._tcp", "local");
        }

        public string[] StageDisplaySet { get; private set; }

        public int StageDisplayIndex { get; private set; }

        public void QueryStageDisplay()
        {
            this.SendAction("stageDisplaySets");
        }
        public void QueryTimers()
        {
            this.SendAction("clockRequest");
        }

        private void Authenticate()
        {
            this.Send(
                new
                {
                    action = "authenticate",
                    protocol = 610,
                    this.password
                });
        }

        public void Send(object data)
        {
            string sending = JsonConvert.SerializeObject(data);
            this.ws.Send(sending);
        }

        public void SendAction(string action)
        {
            string sending = JsonConvert.SerializeObject(new { action });
            this.ws.Send(sending);
        }

        public void OnReceive(string json)
        {
            try
            {
                JObject jobject = JObject.Parse(json);
                string stringValue = jobject.GetStringValue("action", (string)null);
                if (string.IsNullOrEmpty(stringValue))
                    return;

                switch (stringValue)
                {
                    case "authenticate":
                        if (this.Authenticated != null)
                        {
                            this.Authenticated(this, EventArgs.Empty);
                        }
                        break;
                    case "stageDisplaySets":
                        string[] stageDisplaySet = jobject.GetValue("stageDisplaySets").ToObject<string[]>();
                        int stageDisplayIndex = jobject.GetIntValue("stageDisplayIndex");
                        if (this.StageDisplaySet == null || stageDisplaySet.Length != this.StageDisplaySet.Length || !stageDisplaySet.All(this.StageDisplaySet.Contains) || this.StageDisplayIndex != stageDisplayIndex)
                        {
                            this.StageDisplaySet = stageDisplaySet;
                            this.StageDisplayIndex = stageDisplayIndex;
                            if (this.StageDisplayLayoutsChanged != null)
                            {
                                this.StageDisplayLayoutsChanged(this, EventArgs.Empty);
                            }
                        }
                        break;
                    case "clockRequest":
                        this.Timers = jobject.GetValue("clockInfo").ToObject<ProPresenterTimer[]>().ToList();

                        int i = 0;
                        foreach (var timer in this.Timers)
                        {
                            timer.Index = i++;
                        }
                        if (this.ClocksChanged != null)
                        {
                            this.ClocksChanged(this, EventArgs.Empty);
                        }

                        break;
                }
            }
            catch
            {
                //Debugger.Break();
            }
        }

        public List<ProPresenterTimer> Timers { get; private set; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this.refetchTimer != null)
            {
                this.refetchTimer.Dispose();
                this.refetchTimer = null;
            }

            if (this.ws != null)
            {
                this.ws.Close();
                this.ws = null;
            }
        }
    }
}
