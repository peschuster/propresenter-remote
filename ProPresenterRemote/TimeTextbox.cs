using System;
using System.Windows.Forms;

namespace ProPresenterRemote
{
    public class TimeTextBox : TextBox
    {
        private bool entered;

        private string stored;

        private string delayed;

        public TimeTextBox()
        {
            this.Enter += (_, e) => 
            {
                this.entered = true;
                this.stored = this.Text;
            };

            this.Leave += (_, e) =>
            {
                this.entered = false;

                if (this.delayed != null)
                {
                    if (!this.HasChanged())
                    {
                        this.Text = this.delayed;
                    }

                    this.delayed = null;
                }
            };
        }

        public bool Locked
        {
            get { return this.entered; }
        }

        public bool IsValid()
        {
            TimeSpan ts;
            return TimeSpan.TryParse(this.Text, out ts);
        }

        public bool HasChanged()
        {
            return this.stored != this.Text;
        }

        public void SetDelayed(string text)
        {
            if (this.Locked)
            {
                this.delayed = text;
            }
            else
            {
                this.Text = text;
            }
        }
    }
}
