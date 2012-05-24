namespace ExampleApp
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.apikey = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.GetUserInfo = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.GetProfiles = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.DownloadSave = new System.Windows.Forms.Button();
            this.dlid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.pfid = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "API Key";
            // 
            // apikey
            // 
            this.apikey.Location = new System.Drawing.Point(57, 23);
            this.apikey.Name = "apikey";
            this.apikey.Size = new System.Drawing.Size(298, 20);
            this.apikey.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.apikey);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 59);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "API Key";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(361, 21);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 23);
            this.button5.TabIndex = 2;
            this.button5.Text = "Save";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // GetUserInfo
            // 
            this.GetUserInfo.Location = new System.Drawing.Point(12, 77);
            this.GetUserInfo.Name = "GetUserInfo";
            this.GetUserInfo.Size = new System.Drawing.Size(86, 23);
            this.GetUserInfo.TabIndex = 3;
            this.GetUserInfo.Text = "Get User Info";
            this.GetUserInfo.UseVisualStyleBackColor = true;
            this.GetUserInfo.Click += new System.EventHandler(this.GetUserInfo_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(12, 107);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(408, 212);
            this.listBox1.TabIndex = 4;
            // 
            // GetProfiles
            // 
            this.GetProfiles.Location = new System.Drawing.Point(104, 77);
            this.GetProfiles.Name = "GetProfiles";
            this.GetProfiles.Size = new System.Drawing.Size(86, 23);
            this.GetProfiles.TabIndex = 5;
            this.GetProfiles.Text = "Get Profiles";
            this.GetProfiles.UseVisualStyleBackColor = true;
            this.GetProfiles.Click += new System.EventHandler(this.GetProfiles_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(375, 76);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(45, 23);
            this.button3.TabIndex = 6;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // DownloadSave
            // 
            this.DownloadSave.Location = new System.Drawing.Point(196, 77);
            this.DownloadSave.Name = "DownloadSave";
            this.DownloadSave.Size = new System.Drawing.Size(75, 23);
            this.DownloadSave.TabIndex = 7;
            this.DownloadSave.Text = "Download";
            this.DownloadSave.UseVisualStyleBackColor = true;
            this.DownloadSave.Click += new System.EventHandler(this.DownloadSave_Click);
            // 
            // dlid
            // 
            this.dlid.Location = new System.Drawing.Point(277, 79);
            this.dlid.Name = "dlid";
            this.dlid.Size = new System.Drawing.Size(36, 20);
            this.dlid.TabIndex = 8;
            this.dlid.Text = "DL ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 335);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 9;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(12, 332);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(408, 48);
            this.richTextBox1.TabIndex = 10;
            this.richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // pfid
            // 
            this.pfid.Location = new System.Drawing.Point(315, 79);
            this.pfid.Name = "pfid";
            this.pfid.Size = new System.Drawing.Size(52, 20);
            this.pfid.TabIndex = 11;
            this.pfid.Text = "Profile ID";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(432, 387);
            this.Controls.Add(this.pfid);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dlid);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.DownloadSave);
            this.Controls.Add(this.GetProfiles);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.GetUserInfo);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "XboxSDK API Example C# Application 1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox apikey;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button GetUserInfo;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button GetProfiles;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button DownloadSave;
        private System.Windows.Forms.TextBox dlid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.TextBox pfid;
    }
}

