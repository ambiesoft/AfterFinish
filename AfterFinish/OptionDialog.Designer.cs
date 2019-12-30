namespace Ambiesoft.AfterFinish
{
    partial class OptionDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.chkShowMessage = new System.Windows.Forms.CheckBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.chkPlaySound = new System.Windows.Forms.CheckBox();
            this.chkLaunchApp = new System.Windows.Forms.CheckBox();
            this.lblApplication = new System.Windows.Forms.Label();
            this.txtApp = new System.Windows.Forms.TextBox();
            this.lblArg = new System.Windows.Forms.Label();
            this.txtArg = new System.Windows.Forms.TextBox();
            this.btnBrowseApp = new System.Windows.Forms.Button();
            this.chkOpenFolder = new System.Windows.Forms.CheckBox();
            this.chkShutdown = new System.Windows.Forms.CheckBox();
            this.lblWave = new System.Windows.Forms.Label();
            this.txtWav = new System.Windows.Forms.TextBox();
            this.btnBrowseWav = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // chkShowMessage
            // 
            this.chkShowMessage.AutoSize = true;
            this.chkShowMessage.Location = new System.Drawing.Point(12, 12);
            this.chkShowMessage.Name = "chkShowMessage";
            this.chkShowMessage.Size = new System.Drawing.Size(117, 17);
            this.chkShowMessage.TabIndex = 100;
            this.chkShowMessage.Text = "Show &MessageBox";
            this.chkShowMessage.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(131, 259);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(107, 23);
            this.btnOK.TabIndex = 900;
            this.btnOK.Text = "&OK";
            this.btnOK.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(244, 259);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(107, 23);
            this.btnCancel.TabIndex = 1000;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // chkPlaySound
            // 
            this.chkPlaySound.AutoSize = true;
            this.chkPlaySound.Location = new System.Drawing.Point(12, 35);
            this.chkPlaySound.Name = "chkPlaySound";
            this.chkPlaySound.Size = new System.Drawing.Size(80, 17);
            this.chkPlaySound.TabIndex = 200;
            this.chkPlaySound.Text = "&Play Sound";
            this.chkPlaySound.UseVisualStyleBackColor = true;
            this.chkPlaySound.CheckedChanged += new System.EventHandler(this.chkPlaySound_CheckedChanged);
            // 
            // chkLaunchApp
            // 
            this.chkLaunchApp.AutoSize = true;
            this.chkLaunchApp.Location = new System.Drawing.Point(12, 144);
            this.chkLaunchApp.Name = "chkLaunchApp";
            this.chkLaunchApp.Size = new System.Drawing.Size(84, 17);
            this.chkLaunchApp.TabIndex = 300;
            this.chkLaunchApp.Text = "Launch &App";
            this.chkLaunchApp.UseVisualStyleBackColor = true;
            this.chkLaunchApp.CheckedChanged += new System.EventHandler(this.chkLaunchApp_CheckedChanged);
            // 
            // lblApplication
            // 
            this.lblApplication.AutoSize = true;
            this.lblApplication.Location = new System.Drawing.Point(12, 164);
            this.lblApplication.Name = "lblApplication";
            this.lblApplication.Size = new System.Drawing.Size(62, 13);
            this.lblApplication.TabIndex = 400;
            this.lblApplication.Text = "Appli&cation:";
            // 
            // txtApp
            // 
            this.txtApp.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApp.Location = new System.Drawing.Point(12, 180);
            this.txtApp.Name = "txtApp";
            this.txtApp.Size = new System.Drawing.Size(303, 20);
            this.txtApp.TabIndex = 500;
            // 
            // lblArg
            // 
            this.lblArg.AutoSize = true;
            this.lblArg.Location = new System.Drawing.Point(12, 203);
            this.lblArg.Name = "lblArg";
            this.lblArg.Size = new System.Drawing.Size(60, 13);
            this.lblArg.TabIndex = 700;
            this.lblArg.Text = "Ar&guments:";
            // 
            // txtArg
            // 
            this.txtArg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtArg.Location = new System.Drawing.Point(12, 219);
            this.txtArg.Name = "txtArg";
            this.txtArg.Size = new System.Drawing.Size(339, 20);
            this.txtArg.TabIndex = 800;
            // 
            // btnBrowseApp
            // 
            this.btnBrowseApp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseApp.Location = new System.Drawing.Point(321, 180);
            this.btnBrowseApp.Name = "btnBrowseApp";
            this.btnBrowseApp.Size = new System.Drawing.Size(30, 20);
            this.btnBrowseApp.TabIndex = 600;
            this.btnBrowseApp.Text = "&...";
            this.btnBrowseApp.UseVisualStyleBackColor = true;
            this.btnBrowseApp.Click += new System.EventHandler(this.btnBrowseApp_Click);
            // 
            // chkOpenFolder
            // 
            this.chkOpenFolder.AutoSize = true;
            this.chkOpenFolder.Location = new System.Drawing.Point(12, 98);
            this.chkOpenFolder.Name = "chkOpenFolder";
            this.chkOpenFolder.Size = new System.Drawing.Size(84, 17);
            this.chkOpenFolder.TabIndex = 250;
            this.chkOpenFolder.Text = "Open &Folder";
            this.chkOpenFolder.UseVisualStyleBackColor = true;
            // 
            // chkShutdown
            // 
            this.chkShutdown.AutoSize = true;
            this.chkShutdown.Location = new System.Drawing.Point(12, 121);
            this.chkShutdown.Name = "chkShutdown";
            this.chkShutdown.Size = new System.Drawing.Size(92, 17);
            this.chkShutdown.TabIndex = 275;
            this.chkShutdown.Text = "&Shutdown OS";
            this.chkShutdown.UseVisualStyleBackColor = true;
            // 
            // lblWave
            // 
            this.lblWave.AutoSize = true;
            this.lblWave.Location = new System.Drawing.Point(9, 55);
            this.lblWave.Name = "lblWave";
            this.lblWave.Size = new System.Drawing.Size(62, 13);
            this.lblWave.TabIndex = 225;
            this.lblWave.Text = "&wav sound:";
            // 
            // txtWav
            // 
            this.txtWav.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWav.Location = new System.Drawing.Point(12, 71);
            this.txtWav.Name = "txtWav";
            this.txtWav.Size = new System.Drawing.Size(303, 20);
            this.txtWav.TabIndex = 230;
            // 
            // btnBrowseWav
            // 
            this.btnBrowseWav.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowseWav.Location = new System.Drawing.Point(321, 71);
            this.btnBrowseWav.Name = "btnBrowseWav";
            this.btnBrowseWav.Size = new System.Drawing.Size(30, 20);
            this.btnBrowseWav.TabIndex = 240;
            this.btnBrowseWav.Text = "&...";
            this.btnBrowseWav.UseVisualStyleBackColor = true;
            this.btnBrowseWav.Click += new System.EventHandler(this.btnBrowseWav_Click);
            // 
            // OptionDialog
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(363, 294);
            this.Controls.Add(this.btnBrowseWav);
            this.Controls.Add(this.txtWav);
            this.Controls.Add(this.lblWave);
            this.Controls.Add(this.chkShutdown);
            this.Controls.Add(this.chkOpenFolder);
            this.Controls.Add(this.btnBrowseApp);
            this.Controls.Add(this.txtArg);
            this.Controls.Add(this.lblArg);
            this.Controls.Add(this.txtApp);
            this.Controls.Add(this.lblApplication);
            this.Controls.Add(this.chkLaunchApp);
            this.Controls.Add(this.chkPlaySound);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.chkShowMessage);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(379, 333);
            this.Name = "OptionDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Options";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.CheckBox chkShowMessage;
        public System.Windows.Forms.CheckBox chkPlaySound;
        public System.Windows.Forms.CheckBox chkLaunchApp;
        private System.Windows.Forms.Label lblApplication;
        private System.Windows.Forms.Label lblArg;
        private System.Windows.Forms.Button btnBrowseApp;
        public System.Windows.Forms.TextBox txtApp;
        public System.Windows.Forms.TextBox txtArg;
        public System.Windows.Forms.CheckBox chkOpenFolder;
        public System.Windows.Forms.CheckBox chkShutdown;
        private System.Windows.Forms.Label lblWave;
        public System.Windows.Forms.TextBox txtWav;
        private System.Windows.Forms.Button btnBrowseWav;
    }
}