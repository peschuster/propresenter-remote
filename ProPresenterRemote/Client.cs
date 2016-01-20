using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Mono.Zeroconf;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebSocketSharp;

namespace ProPresenterRemote
{
    class Client : IDisposable
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

            this.ws = new WebSocket("ws://" + address.ToString() + ":" + port + "/remote");
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
                Console.WriteLine(@"Found Service: {0}", args.Service.Name);

                args.Service.Resolved += (__, args2) => {
                    IResolvableService s = args2.Service;
                    Console.WriteLine(@"Resolved Service: {0} - {1}:{2} ({3} TXT record entries)", s.FullName, s.HostEntry.AddressList[0], s.Port, s.TxtRecord.Count);

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
                    password = this.password
                });
        }

        public void Send(object data)
        {
            string sending = JsonConvert.SerializeObject(data);
            this.ws.Send(sending);
        }

        public void SendAction(string action)
        {
            string sending = JsonConvert.SerializeObject(new { action = action });
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
                    case "clearAll":
                        ////this.HandleClearAll();
                        break;
                    case "clearText":
                        ////this.HandleClearText();
                        break;
                    case "clearVideo":
                        ////this.HandleClearVideo();
                        break;
                    case "clearAudio":
                        ////this.HandleClearAudio();
                        break;
                    case "clearProps":
                        ////this.HandleClearProps();
                        break;
                    case "clearToLogo":
                        ////this.HandleClearToLogo();
                        break;
                    case "libraryRequest":
                        ////this.HandleLibraryRequest();
                        break;
                    case "playlistRequestAll":
                        ////this.HandlePlaylistRequestAll();
                        break;
                    case "playlistRequest":
                        ////this.HandlePlaylistRequest();
                        break;
                    case "presentationCurrent":
                        ////this.HandlePresentationCurrent((JToken)jobject);
                        break;
                    case "presentationCurrentIndex":
                        ////this.HandlePresentationCurrentIndex();
                        break;
                    case "presentationSlideIndex":
                        ////this.HandlePresentationSlideIndex();
                        break;
                    case "presentationRequest":
                        ////this.HandlePresentationRequest((JToken)jobject);
                        break;
                    case "presentationTriggerNext":
                        ////this.HandlePresentationTriggerNext((JToken)jobject);
                        break;
                    case "presentationTriggerPrevious":
                        ////this.HandlePresentationTriggerPrevious((JToken)jobject);
                        break;
                    case "presentationTriggerIndex":
                        ////this.HandlePresentationTriggerIndex((JToken)jobject);
                        break;
                    case "presentationTimelineRewind":
                        ////this.HandlePresentationTimelineRewind((JToken)jobject);
                        break;
                    case "presentationTimelinePlayPause":
                        ////this.HandlePresentationTimelinePlayPause((JToken)jobject);
                        break;
                    case "messageRequest":
                        ////this.HandleMessageRequest();
                        break;
                    case "messageSend":
                        ////this.HandleMessageSend((JToken)jobject);
                        break;
                    case "messageHide":
                        ////this.HandleMessageHide((JToken)jobject);
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
                    case "stageDisplaySendMessage":
                        ////this.HandleStageDisplayMessageSend((JToken)jobject);
                        break;
                    case "stageDisplayHideMessage":
                        ////this.HandleStageDisplayMessageHide();
                        break;
                    case "stageDisplaySetIndex":
                        ////this.HandleStageDisplaySetIndex((JToken)jobject);
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
                    case "clockStart":
                        ////this.HandleClockStart((JToken)jobject);
                        break;
                    case "clockStop":
                        ////this.HandleClockStop((JToken)jobject);
                        break;
                    case "clockReset":
                        ////this.HandleClockReset((JToken)jobject);
                        break;
                    case "clockResetAll":
                        ////this.HandleClockResetAll();
                        break;
                    case "clockStopAll":
                        ////this.HandleClockStopAll();
                        break;
                    case "clockStartAll":
                        ////this.HandleClockStartAll();
                        break;
                    case "clockUpdate":
                        ////this.HandleClockUpdate((JToken)jobject);
                        break;
                    case "clockStartSendingCurrentTime":
                        ////this.HandleClockStartSendingCurrentTime();
                        break;
                    case "clockStopSendingCurrentTime":
                        ////this.HandleClockStopSendingCurrentTime();
                        break;
                    case "socialSendTweet":
                        ////this.HandleSocialSendTweet((JToken)jobject);
                        break;
                    case "socialSendInstagram":
                        ////this.HandleSocialSendInstagram((JToken)jobject);
                        break;
                    case "audioRequest":
                        ////this.HandleAudioRequest();
                        break;
                    case "audioCurrentSong":
                        ////this.HandleAudioCurrentSong();
                        break;
                    case "audioStartCue":
                        ////this.HandleAudioStartCue((JToken)jobject);
                        break;
                    case "audioPlayPause":
                        ////this.HandleAudioPlayPause();
                        break;
                    case "audioIsPlaying":
                        ////this.HandleAudioIsPlaying();
                        break;
                    case "mediaRequest":
                        ////this.HandleMediaRequest();
                        break;
                    case "telestratorSettings":
                        ////this.HandleTelestratorSettings();
                        break;
                    case "telestratorEndEditing":
                        ////this.HandleTelestratorEndEditing();
                        break;
                    case "clearTelestrator":
                        ////this.HandleClearTelestrator();
                        break;
                    case "telestratorSet":
                        ////this.HandleTelestratorSet((JToken)jobject);
                        break;
                    case "telestratorUndo":
                        ////this.HandleTelestratorUndo();
                        break;
                    case "telestratorNew":
                        ////this.HandleTelestratorNew((JToken)jobject);
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
