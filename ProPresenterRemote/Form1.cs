using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProPresenterRemote
{
    public partial class Form1 : Form
    {
        private Client client;

        private List<TimerItem> timerItems;

        public Form1()
        {
            this.InitializeComponent();
            this.grpStageDisplay.Enabled = false;
            this.grpClocks.Enabled = false;

            this.timerItems = new List<TimerItem>
            {
                this.timerItem1,
                this.timerItem2,
                this.timerItem3,
                this.timerItem4
            };

            foreach (var ctrl in this.timerItems)
            {
                ctrl.StartTriggered += this.OnTimerStart;
                ctrl.StopTriggered += this.OnTimerStop;
                ctrl.ResetTriggered += this.OnTimerReset;
                ctrl.UpdateTriggered += this.OnTimerUpdate;

                ctrl.Enabled = false;
            }
        }

        private void OnTimerStart(object sender, int index)
        {
            if (index >= 0)
            {
                this.client.Send(new { action = "clockStart", clockIndex = index });
            }
        }

        private void OnTimerStop(object sender, int index)
        {
            if (index >= 0)
            {
                this.client.Send(new { action = "clockStop", clockIndex = index });
            }
        }

        private void OnTimerReset(object sender, int index)
        {
            if (index >= 0)
            {
                this.client.Send(new { action = "clockReset", clockIndex = index });
            }
        }

        private void OnTimerUpdate(object sender, int index)
        {
            if (index >= 0)
            {
                try
                {
                    var timer = this.client.Timers[index];
                    this.timerItems[index].GetValues(timer);
                    
                    this.client.Send(new
                    {
                        action = "clockUpdate",
                        clockIndex = index,
                        clockName = timer.Name,
                        clockTime = timer.Duration,
                        clockElapsedTime = timer.EndTime == "No Limit" ? "" : timer.EndTime,
                        clockType = (int)timer.TimerType,
                        clockIsPM = timer.ClockIsPm,
                        clockOverrun = timer.Overrun
                    });
                }
                catch
                {
                    
                }
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.client.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void btn_Click(object sender, EventArgs e)
        {
            this.client = new Client(this.txbPassword.Text);

            this.client.StageDisplayLayoutsChanged += (_, args) => this.Invoke(
                () =>
                {
                    this.ddlStageDisplay.Items.Clear();

                    this.ddlStageDisplay.Items.AddRange(this.client.StageDisplaySet);
                    this.ddlStageDisplay.SelectedIndex = this.client.StageDisplayIndex;
                });

            this.client.Authenticated += (_, args) => this.Invoke(() => { this.grpStageDisplay.Enabled = true; this.grpClocks.Enabled = true; });

            this.client.ClocksChanged += (_, args) => this.Invoke(
                () =>
                {
                    int i = 0;
                    foreach (var ctrl in this.timerItems)
                    {
                        if (this.client.Timers.Count > i)
                        {
                            ctrl.Enabled = true;
                            ctrl.SetValues(this.client.Timers[i]);
                        }
                        else
                        {
                            ctrl.Enabled = false;
                            ctrl.SetValues(new ProPresenterTimer());
                        }

                        i++;
                    }
                });


            this.client.StartConnection();
            this.txbPassword.Enabled = false;
            this.btn.Enabled = false;
        }
    }
}
