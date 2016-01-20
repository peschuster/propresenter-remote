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

        private readonly ServiceBrowser serviceBrowser = new ServiceBrowser();

        private WebSocket ws;

        private Timer refetchTimer;

        public event EventHandler StageDisplayLayoutsChanged;

        public event EventHandler Authenticated;

        public event EventHandler ClocksChanged;

        public Client(string password)
        {
            this.password = password;

            this.serviceBrowser.ServiceAdded += (_, args) => {
                args.Service.Resolved += (__, args2) => {
                    IResolvableService s = args2.Service;
                    this.Connect(s.HostEntry.AddressList[0], 50001);
                };

                args.Service.Resolve();
            };
        }

        public List<ProPresenterTimer> Timers { get; private set; }

        public string[] StageDisplaySet { get; private set; }

        public int StageDisplayIndex { get; private set; }

        private void Connect(IPAddress address, int port)
        {
            if (this.ws != null 
                && (this.ws.ReadyState == WebSocketState.Connecting || this.ws.ReadyState == WebSocketState.Open))
                return;

            if (this.ws != null)
            {
                this.ws.Close();
                this.ws = null;
            }

            this.ws = new WebSocket("ws://" + address + ":" + port + "/remote");
            this.ws.OnMessage += (sender, args) => { this.OnReceive(args.Data); };
            this.ws.OnError += (sender, args) =>
            {
                if (!this.ws.IsAlive)
                {
                    this.ws.Close();
                    this.ws.Connect();
                }
            };

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
            this.serviceBrowser.Browse("_pro6proremote._tcp", "local");
        }

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
            string json = JsonConvert.SerializeObject(data);

            this.ws.Send(json);
        }

        public void SendAction(string action)
        {
            this.Send(new { action });
        }

        private void OnReceive(string input)
        {
            try
            {
                JObject json = JObject.Parse(input);

                string stringValue = json.GetStringValue("action");

                if (string.IsNullOrEmpty(stringValue))
                    return;

                switch (stringValue)
                {
                    case "authenticate":
                        this.Trigger(this.Authenticated);
                        break;
                    case "stageDisplaySets":
                        string[] stageDisplaySet = json.GetValue("stageDisplaySets").ToObject<string[]>();
                        int stageDisplayIndex = json.GetIntValue("stageDisplayIndex");
                        if (this.StageDisplaySet == null || stageDisplaySet.Length != this.StageDisplaySet.Length || !stageDisplaySet.All(this.StageDisplaySet.Contains) || this.StageDisplayIndex != stageDisplayIndex)
                        {
                            this.StageDisplaySet = stageDisplaySet;
                            this.StageDisplayIndex = stageDisplayIndex;
                            this.Trigger(this.StageDisplayLayoutsChanged);
                        }
                        break;
                    case "clockRequest":
                        this.Timers = json.GetValue("clockInfo").ToObject<ProPresenterTimer[]>().ToList();

                        int i = 0;
                        foreach (var timer in this.Timers)
                        {
                            timer.Index = i++;
                        }

                        this.Trigger(this.ClocksChanged);

                        break;
                }
            }
            catch
            {
                //Debugger.Break();
            }
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            if (this.serviceBrowser != null)
            {
                this.serviceBrowser.Dispose();
            }

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

        private void Trigger(EventHandler eventHandler)
        {
            if (eventHandler != null)
            {
                eventHandler(this, EventArgs.Empty);
            }
        }
    }
}
