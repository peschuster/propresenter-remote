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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txbName = new System.Windows.Forms.TextBox();
            this.txbType = new System.Windows.Forms.TextBox();
            this.txbDuration = new System.Windows.Forms.TextBox();
            this.txbEndTime = new System.Windows.Forms.TextBox();
            this.txbTime = new System.Windows.Forms.TextBox();
            this.chkRunning = new System.Windows.Forms.CheckBox();
            this.chkOverrun = new System.Windows.Forms.CheckBox();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(119, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Duration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(276, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "End Time";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(344, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Time";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(417, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Running";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(471, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Overrun";
            // 
            // txbName
            // 
            this.txbName.Location = new System.Drawing.Point(16, 32);
            this.txbName.Name = "txbName";
            this.txbName.Size = new System.Drawing.Size(100, 20);
            this.txbName.TabIndex = 1;
            this.txbName.TextChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txbType
            // 
            this.txbType.Enabled = false;
            this.txbType.Location = new System.Drawing.Point(122, 32);
            this.txbType.Name = "txbType";
            this.txbType.Size = new System.Drawing.Size(83, 20);
            this.txbType.TabIndex = 1;
            // 
            // txbDuration
            // 
            this.txbDuration.Location = new System.Drawing.Point(211, 31);
            this.txbDuration.Name = "txbDuration";
            this.txbDuration.Size = new System.Drawing.Size(62, 20);
            this.txbDuration.TabIndex = 1;
            this.txbDuration.TextChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txbEndTime
            // 
            this.txbEndTime.Location = new System.Drawing.Point(279, 31);
            this.txbEndTime.Name = "txbEndTime";
            this.txbEndTime.Size = new System.Drawing.Size(62, 20);
            this.txbEndTime.TabIndex = 1;
            this.txbEndTime.TextChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // txbTime
            // 
            this.txbTime.Enabled = false;
            this.txbTime.Location = new System.Drawing.Point(347, 31);
            this.txbTime.Name = "txbTime";
            this.txbTime.Size = new System.Drawing.Size(62, 20);
            this.txbTime.TabIndex = 1;
            // 
            // chkRunning
            // 
            this.chkRunning.AutoSize = true;
            this.chkRunning.Location = new System.Drawing.Point(420, 35);
            this.chkRunning.Name = "chkRunning";
            this.chkRunning.Size = new System.Drawing.Size(15, 14);
            this.chkRunning.TabIndex = 2;
            this.chkRunning.UseVisualStyleBackColor = true;
            this.chkRunning.CheckedChanged += new System.EventHandler(this.chkRunning_CheckedChanged);
            // 
            // chkOverrun
            // 
            this.chkOverrun.AutoSize = true;
            this.chkOverrun.Location = new System.Drawing.Point(474, 35);
            this.chkOverrun.Name = "chkOverrun";
            this.chkOverrun.Size = new System.Drawing.Size(15, 14);
            this.chkOverrun.TabIndex = 2;
            this.chkOverrun.UseVisualStyleBackColor = true;
            this.chkOverrun.CheckedChanged += new System.EventHandler(this.OnValueChanged);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(529, 28);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(45, 23);
            this.btnReset.TabIndex = 3;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // TimerItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.chkOverrun);
            this.Controls.Add(this.chkRunning);
            this.Controls.Add(this.txbTime);
            this.Controls.Add(this.txbEndTime);
            this.Controls.Add(this.txbDuration);
            this.Controls.Add(this.txbType);
            this.Controls.Add(this.txbName);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "TimerItem";
            this.Size = new System.Drawing.Size(589, 64);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbName;
        private System.Windows.Forms.TextBox txbType;
        private System.Windows.Forms.TextBox txbDuration;
        private System.Windows.Forms.TextBox txbEndTime;
        private System.Windows.Forms.TextBox txbTime;
        private System.Windows.Forms.CheckBox chkRunning;
        private System.Windows.Forms.CheckBox chkOverrun;
        private System.Windows.Forms.Button btnReset;
    }
}
