namespace ProPresenterRemote
{
    partial class TimerItem
    {
        /// <summary> 
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Komponenten-Designer generierter Code

        /// <summary> 
        /// Erforderliche Methode für die Designerunterstützung. 
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.txbType = new System.Windows.Forms.TextBox();
            this.chkOverrun = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.txbTime = new System.Windows.Forms.TextBox();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.txbEndTime = new ProPresenterRemote.TimeTextBox();
            this.txbDuration = new ProPresenterRemote.TimeTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Duration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "End Time";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(345, 12);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Overrun";
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(16, 28);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(100, 20);
            this.txbName.TabIndex = 0;
            this.txbName.TextChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txbType
            // 
            this.txbType.Enabled = false;
            this.txbType.Location = new System.Drawing.Point(122, 28);
            this.txbType.Name = "txbType";
            this.txbType.Size = new System.Drawing.Size(83, 20);
            this.txbType.TabIndex = 1;
            // 
            // chkOverrun
            // 
            this.chkOverrun.AutoSize = true;
            this.chkOverrun.Location = new System.Drawing.Point(348, 31);
            this.chkOverrun.Name = "chkOverrun";
            this.chkOverrun.Size = new System.Drawing.Size(15, 14);
            this.chkOverrun.TabIndex = 4;
            this.chkOverrun.UseVisualStyleBackColor = true;
            this.chkOverrun.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(529, 26);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(45, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.OnBtnResetClick);
            // 
            // txbTime
            // 
            this.txbTime.Location = new System.Drawing.Point(461, 28);
            this.txbTime.Name = "txbTime";
            this.txbTime.ReadOnly = true;
            this.txbTime.Size = new System.Drawing.Size(62, 20);
            this.txbTime.TabIndex = 1;
            this.txbTime.TabStop = false;
            this.txbTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnStartStop
            // 
            this.btnStartStop.ImageList = this.imageList;
            this.btnStartStop.Location = new System.Drawing.Point(410, 26);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(45, 23);
            this.btnStartStop.TabIndex = 5;
            this.btnStartStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.OnBtnStartStopClick);
            // 
            // imageList
            // 
            this.imageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // txbEndTime
            // 
            this.txbEndTime.Location = new System.Drawing.Point(279, 28);
            this.txbEndTime.Name = "txbEndTime";
            this.txbEndTime.Size = new System.Drawing.Size(62, 20);
            this.txbEndTime.TabIndex = 3;
            this.txbEndTime.TextChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txbDuration
            // 
            this.txbDuration.Location = new System.Drawing.Point(211, 28);
            this.txbDuration.Name = "txbDuration";
            this.txbDuration.Size = new System.Drawing.Size(62, 20);
            this.txbDuration.TabIndex = 2;
            this.txbDuration.TextChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // TimerItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnStartStop);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.chkOverrun);
            this.Controls.Add(this.txbTime);
            this.Controls.Add(this.txbEndTime);
            this.Controls.Add(this.txbDuration);
            this.Controls.Add(this.txbType);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TimerItem";
            this.Size = new System.Drawing.Size(589, 61);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.TextBox txbType;
        private TimeTextBox txbDuration;
        private TimeTextBox txbEndTime;
        private System.Windows.Forms.CheckBox chkOverrun;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TextBox txbTime;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.ImageList imageList;
    }
}
