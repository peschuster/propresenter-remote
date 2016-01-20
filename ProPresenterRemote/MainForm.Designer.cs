namespace ProPresenterRemote
{
    partial class MainForm
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

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.grpStageDisplay = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ddlStageDisplay = new System.Windows.Forms.ComboBox();
            this.grpClocks = new System.Windows.Forms.GroupBox();
            this.timerItem4 = new ProPresenterRemote.TimerItem();
            this.timerItem3 = new ProPresenterRemote.TimerItem();
            this.timerItem2 = new ProPresenterRemote.TimerItem();
            this.timerItem1 = new ProPresenterRemote.TimerItem();
            this.label2 = new System.Windows.Forms.Label();
            this.txbPassword = new System.Windows.Forms.TextBox();
            this.btn = new System.Windows.Forms.Button();
            this.grpStageDisplay.SuspendLayout();
            this.grpClocks.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpStageDisplay
            // 
            this.grpStageDisplay.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpStageDisplay.Controls.Add(this.label1);
            this.grpStageDisplay.Controls.Add(this.ddlStageDisplay);
            this.grpStageDisplay.Location = new System.Drawing.Point(12, 55);
            this.grpStageDisplay.Name = "grpStageDisplay";
            this.grpStageDisplay.Size = new System.Drawing.Size(595, 66);
            this.grpStageDisplay.TabIndex = 1;
            this.grpStageDisplay.TabStop = false;
            this.grpStageDisplay.Text = "Stage Display";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(39, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Layout";
            // 
            // ddlStageDisplay
            // 
            this.ddlStageDisplay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlStageDisplay.FormattingEnabled = true;
            this.ddlStageDisplay.Location = new System.Drawing.Point(81, 30);
            this.ddlStageDisplay.Name = "ddlStageDisplay";
            this.ddlStageDisplay.Size = new System.Drawing.Size(230, 21);
            this.ddlStageDisplay.TabIndex = 0;
            // 
            // grpClocks
            // 
            this.grpClocks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpClocks.Controls.Add(this.timerItem4);
            this.grpClocks.Controls.Add(this.timerItem3);
            this.grpClocks.Controls.Add(this.timerItem2);
            this.grpClocks.Controls.Add(this.timerItem1);
            this.grpClocks.Location = new System.Drawing.Point(12, 127);
            this.grpClocks.Name = "grpClocks";
            this.grpClocks.Size = new System.Drawing.Size(595, 307);
            this.grpClocks.TabIndex = 1;
            this.grpClocks.TabStop = false;
            this.grpClocks.Text = "Clocks";
            // 
            // timerItem4
            // 
            this.timerItem4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timerItem4.Location = new System.Drawing.Point(6, 229);
            this.timerItem4.Name = "timerItem4";
            this.timerItem4.Size = new System.Drawing.Size(583, 64);
            this.timerItem4.TabIndex = 0;
            // 
            // timerItem3
            // 
            this.timerItem3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timerItem3.Location = new System.Drawing.Point(6, 159);
            this.timerItem3.Name = "timerItem3";
            this.timerItem3.Size = new System.Drawing.Size(583, 64);
            this.timerItem3.TabIndex = 0;
            // 
            // timerItem2
            // 
            this.timerItem2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timerItem2.Location = new System.Drawing.Point(6, 89);
            this.timerItem2.Name = "timerItem2";
            this.timerItem2.Size = new System.Drawing.Size(583, 64);
            this.timerItem2.TabIndex = 0;
            // 
            // timerItem1
            // 
            this.timerItem1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.timerItem1.Location = new System.Drawing.Point(6, 19);
            this.timerItem1.Name = "timerItem1";
            this.timerItem1.Size = new System.Drawing.Size(583, 64);
            this.timerItem1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // txbPassword
            // 
            this.txbPassword.Location = new System.Drawing.Point(93, 19);
            this.txbPassword.Name = "txbPassword";
            this.txbPassword.Size = new System.Drawing.Size(100, 20);
            this.txbPassword.TabIndex = 3;
            this.txbPassword.Text = "123";
            // 
            // btn
            // 
            this.btn.Location = new System.Drawing.Point(199, 17);
            this.btn.Name = "btn";
            this.btn.Size = new System.Drawing.Size(46, 23);
            this.btn.TabIndex = 4;
            this.btn.Text = "Start";
            this.btn.UseVisualStyleBackColor = true;
            this.btn.Click += new System.EventHandler(this.OnBtnStartClick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(619, 446);
            this.Controls.Add(this.btn);
            this.Controls.Add(this.txbPassword);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grpClocks);
            this.Controls.Add(this.grpStageDisplay);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(635, 485);
            this.Name = "MainForm";
            this.Text = "ProPresenter Remote Clock Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.grpStageDisplay.ResumeLayout(false);
            this.grpStageDisplay.PerformLayout();
            this.grpClocks.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpStageDisplay;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlStageDisplay;
        private System.Windows.Forms.GroupBox grpClocks;
        private TimerItem timerItem1;
        private TimerItem timerItem4;
        private TimerItem timerItem3;
        private TimerItem timerItem2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbPassword;
        private System.Windows.Forms.Button btn;
    }
}

