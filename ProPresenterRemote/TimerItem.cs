using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProPresenterRemote
{
    public partial class TimerItem : UserControl
    {
        public event EventHandler<int> ResetTriggered;

        public event EventHandler<int> UpdateTriggered;

        public event EventHandler<int> StartTriggered;

        public event EventHandler<int> StopTriggered;

        private int index;

        private bool wasOverrunning;

        public TimerItem()
        {
            this.InitializeComponent();
        }

        public void SetValues(ProPresenterTimer timer)
        {
            this.index = -1;
            this.txbName.Text = timer.Name;

            switch (timer.TimerType)
            {
                case TimerType.CountDownTimer:
                    this.label3.Text = "Duration";
                    this.txbType.Text = "Countdown";
                    this.txbDuration.Enabled = true;
                    this.txbEndTime.Enabled = false;
                    break;
                case TimerType.CountDownToTimer:
                    this.label3.Text = "Time";
                    this.txbType.Text = "Count To Time";
                    this.txbDuration.Enabled = true;
                    this.txbEndTime.Enabled = false;
                    break;
                case TimerType.ElapsedTimer:
                    this.label3.Text = "Duration";
                    this.txbType.Text = "Elapsed";
                    this.txbDuration.Enabled = false;
                    this.txbEndTime.Enabled = true;
                    break;
                default:
                    this.txbType.Text = string.Empty;
                    break;
            }

            this.txbDuration.Text = timer.Duration;
            this.txbEndTime.Text = timer.EndTime;

            TimeSpan ts1, ts2;

            bool isOverrunning = timer.Running && timer.Overrun 
                && TimeSpan.TryParse(this.txbTime.Text, out ts1) && TimeSpan.TryParse(timer.Time, out ts2)
                && ((TimerType.ElapsedTimer != timer.TimerType && (ts2 > ts1 || (ts2 == ts1 && this.wasOverrunning)))
                || (TimerType.ElapsedTimer == timer.TimerType && TimeSpan.TryParse(timer.EndTime, out ts1) && (ts2 > ts1 || (ts2 == ts1 && this.wasOverrunning))));

            this.wasOverrunning = isOverrunning;

            this.txbTime.Text = timer.Time;

            this.chkRunning.Checked = timer.Running;
            this.chkOverrun.Checked = timer.Overrun;

            if (isOverrunning)
            {
                this.BackColor = Color.LightSalmon;
            }
            else
            {
                this.BackColor = timer.Running ? Color.LightGreen : DefaultBackColor;
            }

            this.index = timer.Index;
        }

        public void GetValues(ProPresenterTimer timer)
        {
            timer.Name = this.txbName.Text;
            timer.Duration = this.txbDuration.Text;
            timer.EndTime = this.txbEndTime.Text;
            timer.Time = this.txbTime.Text;
            timer.Overrun = this.chkOverrun.Checked;
        }

        private void chkRunning_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkRunning.Checked)
            {
                this.Trigger(this.StartTriggered);
            }
            else
            {
                this.Trigger(this.StopTriggered);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.Trigger(this.ResetTriggered);
        }

        private void Trigger(EventHandler<int> eventHandler)
        {
            if (eventHandler != null && this.index >= 0)
            {
                eventHandler(this, this.index);
            }
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            this.Trigger(this.UpdateTriggered);
        }
    }
}
