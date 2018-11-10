namespace RBX_C
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
            this.Browser = new System.Windows.Forms.WebBrowser();
            this.label1 = new System.Windows.Forms.Label();
            this.CloseOut = new System.Windows.Forms.Button();
            this.Minimize = new System.Windows.Forms.Button();
            this.HomeButton = new System.Windows.Forms.Button();
            this.ListButton = new System.Windows.Forms.Button();
            this.UploadButton = new System.Windows.Forms.Button();
            this.SendButton = new System.Windows.Forms.Button();
            this.ListInfo = new System.Windows.Forms.ListBox();
            this.Download = new System.Windows.Forms.Button();
            this.DownloadAll = new System.Windows.Forms.Button();
            this.ProgressDisplay = new System.Windows.Forms.Label();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.FileDialogName = new System.Windows.Forms.TextBox();
            this.FileDialogOpen = new System.Windows.Forms.Button();
            this.SongName = new System.Windows.Forms.TextBox();
            this.SongInfo = new System.Windows.Forms.Label();
            this.UploadAsset = new System.Windows.Forms.Button();
            this.AuthorInfo = new System.Windows.Forms.Label();
            this.AuthorName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Browser
            // 
            this.Browser.IsWebBrowserContextMenuEnabled = false;
            this.Browser.Location = new System.Drawing.Point(5, 28);
            this.Browser.MinimumSize = new System.Drawing.Size(20, 20);
            this.Browser.Name = "Browser";
            this.Browser.Size = new System.Drawing.Size(720, 470);
            this.Browser.TabIndex = 0;
            this.Browser.Url = new System.Uri("http://jjelamb.com/Sandbox/home.html", System.UriKind.Absolute);
            this.Browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.Browser_DocumentCompleted);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.label1.Font = new System.Drawing.Font("Arial", 8F);
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 1;
            // 
            // CloseOut
            // 
            this.CloseOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CloseOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CloseOut.ForeColor = System.Drawing.Color.White;
            this.CloseOut.Location = new System.Drawing.Point(679, 0);
            this.CloseOut.Name = "CloseOut";
            this.CloseOut.Size = new System.Drawing.Size(46, 20);
            this.CloseOut.TabIndex = 3;
            this.CloseOut.Text = "X";
            this.CloseOut.UseVisualStyleBackColor = true;
            this.CloseOut.Click += new System.EventHandler(this.CloseOut_Click);
            // 
            // Minimize
            // 
            this.Minimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Minimize.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Minimize.ForeColor = System.Drawing.Color.White;
            this.Minimize.Location = new System.Drawing.Point(634, 0);
            this.Minimize.Name = "Minimize";
            this.Minimize.Size = new System.Drawing.Size(46, 20);
            this.Minimize.TabIndex = 4;
            this.Minimize.Text = "-";
            this.Minimize.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Minimize.UseVisualStyleBackColor = true;
            this.Minimize.Click += new System.EventHandler(this.Minimize_Click);
            // 
            // HomeButton
            // 
            this.HomeButton.BackColor = System.Drawing.Color.Black;
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HomeButton.ForeColor = System.Drawing.Color.Silver;
            this.HomeButton.Location = new System.Drawing.Point(158, -1);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(77, 30);
            this.HomeButton.TabIndex = 5;
            this.HomeButton.Text = "Home";
            this.HomeButton.UseVisualStyleBackColor = false;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // ListButton
            // 
            this.ListButton.BackColor = System.Drawing.Color.Black;
            this.ListButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ListButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ListButton.ForeColor = System.Drawing.Color.Silver;
            this.ListButton.Location = new System.Drawing.Point(234, -1);
            this.ListButton.Name = "ListButton";
            this.ListButton.Size = new System.Drawing.Size(77, 30);
            this.ListButton.TabIndex = 6;
            this.ListButton.Text = "List";
            this.ListButton.UseVisualStyleBackColor = false;
            this.ListButton.Click += new System.EventHandler(this.ListButton_Click);
            // 
            // UploadButton
            // 
            this.UploadButton.BackColor = System.Drawing.Color.Black;
            this.UploadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UploadButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UploadButton.ForeColor = System.Drawing.Color.Silver;
            this.UploadButton.Location = new System.Drawing.Point(310, -1);
            this.UploadButton.Name = "UploadButton";
            this.UploadButton.Size = new System.Drawing.Size(77, 30);
            this.UploadButton.TabIndex = 7;
            this.UploadButton.Text = "Upload";
            this.UploadButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.UploadButton.UseVisualStyleBackColor = false;
            this.UploadButton.Click += new System.EventHandler(this.UploadButton_Click);
            // 
            // SendButton
            // 
            this.SendButton.BackColor = System.Drawing.Color.Black;
            this.SendButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SendButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendButton.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.SendButton.Location = new System.Drawing.Point(386, -1);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(77, 30);
            this.SendButton.TabIndex = 8;
            this.SendButton.Text = "Send";
            this.SendButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.SendButton.UseVisualStyleBackColor = false;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // ListInfo
            // 
            this.ListInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(27)))), ((int)(((byte)(40)))), ((int)(((byte)(56)))));
            this.ListInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ListInfo.ForeColor = System.Drawing.Color.White;
            this.ListInfo.FormattingEnabled = true;
            this.ListInfo.Location = new System.Drawing.Point(5, 28);
            this.ListInfo.Name = "ListInfo";
            this.ListInfo.Size = new System.Drawing.Size(720, 418);
            this.ListInfo.TabIndex = 9;
            this.ListInfo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ListInfo_MouseClick);
            this.ListInfo.SelectedIndexChanged += new System.EventHandler(this.ListInfo_SelectedIndexChanged);
            // 
            // Download
            // 
            this.Download.BackColor = System.Drawing.Color.Black;
            this.Download.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Download.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Download.ForeColor = System.Drawing.Color.White;
            this.Download.Location = new System.Drawing.Point(15, 454);
            this.Download.Name = "Download";
            this.Download.Size = new System.Drawing.Size(105, 35);
            this.Download.TabIndex = 11;
            this.Download.Text = "Download Content";
            this.Download.UseVisualStyleBackColor = false;
            this.Download.Click += new System.EventHandler(this.Download_Click);
            // 
            // DownloadAll
            // 
            this.DownloadAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DownloadAll.ForeColor = System.Drawing.Color.White;
            this.DownloadAll.Location = new System.Drawing.Point(130, 454);
            this.DownloadAll.Name = "DownloadAll";
            this.DownloadAll.Size = new System.Drawing.Size(105, 35);
            this.DownloadAll.TabIndex = 12;
            this.DownloadAll.Text = "Download All";
            this.DownloadAll.UseVisualStyleBackColor = true;
            this.DownloadAll.Click += new System.EventHandler(this.DownloadAll_Click);
            // 
            // ProgressDisplay
            // 
            this.ProgressDisplay.Location = new System.Drawing.Point(241, 459);
            this.ProgressDisplay.Name = "ProgressDisplay";
            this.ProgressDisplay.Size = new System.Drawing.Size(146, 25);
            this.ProgressDisplay.TabIndex = 13;
            this.ProgressDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ProgressDisplay.Click += new System.EventHandler(this.ProgressDisplay_Click);
            // 
            // FileDialog
            // 
            this.FileDialog.Filter = "Audio|*.mp3;*.ogg";
            // 
            // FileDialogName
            // 
            this.FileDialogName.AcceptsReturn = true;
            this.FileDialogName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.FileDialogName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FileDialogName.ForeColor = System.Drawing.Color.White;
            this.FileDialogName.Location = new System.Drawing.Point(20, 54);
            this.FileDialogName.Name = "FileDialogName";
            this.FileDialogName.Size = new System.Drawing.Size(200, 13);
            this.FileDialogName.TabIndex = 15;
            this.FileDialogName.TextChanged += new System.EventHandler(this.FileDialogName_TextChanged);
            // 
            // FileDialogOpen
            // 
            this.FileDialogOpen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.FileDialogOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FileDialogOpen.ForeColor = System.Drawing.Color.White;
            this.FileDialogOpen.Location = new System.Drawing.Point(244, 46);
            this.FileDialogOpen.Name = "FileDialogOpen";
            this.FileDialogOpen.Size = new System.Drawing.Size(80, 30);
            this.FileDialogOpen.TabIndex = 16;
            this.FileDialogOpen.Text = "Open File";
            this.FileDialogOpen.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.FileDialogOpen.UseVisualStyleBackColor = true;
            this.FileDialogOpen.Click += new System.EventHandler(this.FileDialogOpen_Click);
            // 
            // SongName
            // 
            this.SongName.AcceptsReturn = true;
            this.SongName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.SongName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.SongName.ForeColor = System.Drawing.Color.White;
            this.SongName.Location = new System.Drawing.Point(20, 94);
            this.SongName.Name = "SongName";
            this.SongName.Size = new System.Drawing.Size(200, 13);
            this.SongName.TabIndex = 17;
            this.SongName.TextChanged += new System.EventHandler(this.AuthorName_TextChanged);
            // 
            // SongInfo
            // 
            this.SongInfo.Location = new System.Drawing.Point(244, 93);
            this.SongInfo.Name = "SongInfo";
            this.SongInfo.Size = new System.Drawing.Size(80, 15);
            this.SongInfo.TabIndex = 18;
            this.SongInfo.Text = "Song Name";
            this.SongInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.SongInfo.Click += new System.EventHandler(this.AuthorInfo_Click);
            // 
            // UploadAsset
            // 
            this.UploadAsset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.UploadAsset.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UploadAsset.ForeColor = System.Drawing.Color.White;
            this.UploadAsset.Location = new System.Drawing.Point(343, 70);
            this.UploadAsset.Name = "UploadAsset";
            this.UploadAsset.Size = new System.Drawing.Size(120, 30);
            this.UploadAsset.TabIndex = 19;
            this.UploadAsset.Text = "Upload Asset";
            this.UploadAsset.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.UploadAsset.UseVisualStyleBackColor = true;
            this.UploadAsset.Click += new System.EventHandler(this.UploadAsset_Click);
            // 
            // AuthorInfo
            // 
            this.AuthorInfo.Location = new System.Drawing.Point(244, 120);
            this.AuthorInfo.Name = "AuthorInfo";
            this.AuthorInfo.Size = new System.Drawing.Size(80, 15);
            this.AuthorInfo.TabIndex = 21;
            this.AuthorInfo.Text = "Author Name";
            this.AuthorInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AuthorName
            // 
            this.AuthorName.AcceptsReturn = true;
            this.AuthorName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.AuthorName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.AuthorName.ForeColor = System.Drawing.Color.White;
            this.AuthorName.Location = new System.Drawing.Point(20, 121);
            this.AuthorName.Name = "AuthorName";
            this.AuthorName.Size = new System.Drawing.Size(200, 13);
            this.AuthorName.TabIndex = 20;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(729, 511);
            this.Controls.Add(this.AuthorInfo);
            this.Controls.Add(this.AuthorName);
            this.Controls.Add(this.UploadAsset);
            this.Controls.Add(this.SongInfo);
            this.Controls.Add(this.SongName);
            this.Controls.Add(this.FileDialogOpen);
            this.Controls.Add(this.FileDialogName);
            this.Controls.Add(this.ProgressDisplay);
            this.Controls.Add(this.DownloadAll);
            this.Controls.Add(this.Download);
            this.Controls.Add(this.ListInfo);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.UploadButton);
            this.Controls.Add(this.ListButton);
            this.Controls.Add(this.HomeButton);
            this.Controls.Add(this.Minimize);
            this.Controls.Add(this.CloseOut);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Browser);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.WebBrowser Browser;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button CloseOut;
        public System.Windows.Forms.Button Minimize;
        public System.Windows.Forms.Button HomeButton;
        public System.Windows.Forms.Button ListButton;
        public System.Windows.Forms.Button UploadButton;
        public System.Windows.Forms.Button SendButton;
        public System.Windows.Forms.ListBox ListInfo;
        public System.Windows.Forms.Button Download;
        public System.Windows.Forms.Button DownloadAll;
        private System.Windows.Forms.Label ProgressDisplay;
        private System.Windows.Forms.OpenFileDialog FileDialog;
        private System.Windows.Forms.TextBox FileDialogName;
        public System.Windows.Forms.Button FileDialogOpen;
        private System.Windows.Forms.TextBox SongName;
        private System.Windows.Forms.Label SongInfo;
        public System.Windows.Forms.Button UploadAsset;
        private System.Windows.Forms.Label AuthorInfo;
        private System.Windows.Forms.TextBox AuthorName;
    }
}

