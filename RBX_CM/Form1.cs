using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RBX_C.Functions;
using System.Net.Http;
using System.IO;
using SharpUpdate;
using System.Reflection;
using System.Net.Sockets;
using System.Text.RegularExpressions;

namespace RBX_C
{
    public partial class Form1 : Form, ISharpUpdatable
    {
        private SharpUpdater updater;

        public Form1()
        {
            InitializeComponent();
            updater = new SharpUpdater(this);
            updater.DoUpdate();
        }

        public string ApplicationName
        {
            get
            {
                return "RBX_CM";
            }
        }

        public string ApplicationID
        {
            get
            {
                return "RBX_CM";
            }
        }

        public Assembly ApplicationAssembly
        {
            get
            {
                return Assembly.GetExecutingAssembly();
            }
        }

        public Uri UpdateXmlLocation
        {
            get
            {
                return new Uri("http://jjelamb.com/RBX-C/app/update.xml");
            }
        }

        public Form Context
        {
            get
            {
                return this;
            }
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void ShowBrowser()
        {
            UploadAsset.Hide();
            FileDialogName.Hide();
            FileDialogOpen.Hide();
            SongInfo.Hide();
            SongName.Hide();
            AuthorInfo.Hide();
            AuthorName.Hide();
            ProgressDisplay.Hide();
            DownloadAll.Hide();
            Download.Hide();
            ListInfo.Hide();
            Browser.Show();
        }

        private bool Navigate = true;

        private void Form1_Load(object sender, EventArgs e)
        {
            ShowBrowser();
            Browser.Hide();
            SetDocumentStream(Browser);
        }

        private void ListButton_Click(object sender, EventArgs e)
        {
            if (Navigate == true)
            {
                Dictionary<string, string> siteinfo = Functions.ReturnSiteInfo();
                var songlist = Functions.ReturnSongList(siteinfo);

                //Check if empty
                if (songlist.ToArray().Length == 0)
                {
                    //Nothing there. Failed Request.
                }
                else
                {
                    ShowBrowser();
                    Browser.Hide();
                    ListInfo.Show();
                    Download.Show();
                    DownloadAll.Show();
                    ProgressDisplay.Show();
                    label1.Text = "Music List";

                    ListInfo.DataSource = songlist;
                }
            }
        }

        private void ListInfo_MouseClick(object sender, EventArgs e)
        {

        }

        private void SetDocumentStream(WebBrowser browser)
        {
            Console.Write("Loaded");
        }

        private void HomeButton_Click(object sender, EventArgs e)
        {
            if (Navigate == true)
            {
                ShowBrowser();
                Dictionary<string, string> siteinfo = Functions.ReturnSiteInfo();
                Functions.NavigateToPage(siteinfo["Main"] + "RBX-C/home.html", Browser);
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (Navigate == true)
            {
                string client = Functions.RBXCheck("client");
                string studio = Functions.RBXCheck("studio");

                if (client != "none")
                {
                    Functions.Copy("music", client + "content\\music");
                }

                if (studio != "none")
                {
                    Functions.Copy("music", studio + "content\\music");
                }
            }
        }

        private void Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void CloseOut_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            dynamic doc = Browser.Document;
            label1.Text = doc.Title;
        }

        private bool enabled = false;

        public async void Download_Click(object sender, EventArgs e)
        {
            if (enabled == false)
            {
                if (ListInfo.SelectedItem != null)
                {
                    enabled = true;
                    Navigate = false;
                    Download.ForeColor = Color.FromArgb(255, 100, 100, 100);
                    DownloadAll.ForeColor = Color.FromArgb(255, 100, 100, 100);

                    var down_name = ListInfo.SelectedItem.ToString();
                    var regex = "(\\[.*\\])|(\".*\")|('.*')|(\\(.*\\))";
                    down_name = Regex.Replace(down_name, regex, "");
                    down_name = down_name.Trim();

                    await Functions.DownloadSong(down_name, ProgressDisplay);

                    string status = FormProperties.DownloadStatus("Get", null);

                    if (status == "Failure")
                    {
                        Download.ForeColor = Color.FromArgb(255, 100, 0, 0);
                        DownloadAll.ForeColor = Color.FromArgb(255, 255, 255, 255);
                    }
                    else if (status == "Completed")
                    {
                        Download.ForeColor = Color.FromArgb(255, 255, 255, 255);
                        DownloadAll.ForeColor = Color.FromArgb(255, 255, 255, 255);
                    }

                    enabled = false;
                    Navigate = true;
                }
            }
        }

        private async void DownloadAll_Click(object sender, EventArgs e)
        {
            if (enabled == false)
            {
                enabled = true;
                Navigate = false;
                Download.ForeColor = Color.FromArgb(255, 100, 100, 100);
                DownloadAll.ForeColor = Color.FromArgb(255, 100, 100, 100);
                await Functions.DownloadAllSongs(ListInfo, ProgressDisplay);

                string status = FormProperties.DownloadStatus("Get", null);

                if (status == "Failure")
                {
                    Download.ForeColor = Color.FromArgb(255, 255, 255, 255);
                    DownloadAll.ForeColor = Color.FromArgb(255, 100, 0, 0);
                }
                else if (status == "Completed")
                {
                    Download.ForeColor = Color.FromArgb(255, 255, 255, 255);
                    DownloadAll.ForeColor = Color.FromArgb(255, 255, 255, 255);
                }

                enabled = false;
                Navigate = true;
            }
        }

        private void ProgressDisplay_Click(object sender, EventArgs e)
        {

        }

        private void FileDialogName_TextChanged(object sender, EventArgs e)
        {

        }

        private void UploadButton_Click(object sender, EventArgs e)
        {
            ShowBrowser();
            Browser.Hide();
            try
            {
                FileDialogName.Show();
                FileDialogOpen.Show();
                SongInfo.Show();
                SongName.Show();
                AuthorInfo.Show();
                AuthorName.Show();
                UploadAsset.Show();
                label1.Text = "Upload Audio";
            }
            catch
            {
                Console.WriteLine("Failure.");
            }
        }

        private void FileDialogOpen_Click(object sender, EventArgs e)
        {
            DialogResult result = FileDialog.ShowDialog();
            if (result == DialogResult.OK) // Test result.
            {
                FileDialogName.Text = FileDialog.FileName;
            }
            Console.WriteLine(result); // <-- For debugging use.
        }

        private void AuthorInfo_Click(object sender, EventArgs e)
        {

        }

        private void AuthorName_TextChanged(object sender, EventArgs e)
        {

        }

        private void UploadAsset_Click(object sender, EventArgs e)
        {
            if (FileDialogName.Text != null & FileDialogName.Text != "")
            {
                if (SongName.Text != null & SongName.Text != "")
                {
                    if (AuthorName.Text != null & AuthorName.Text != "")
                    {
                        //
                        var dic = new Dictionary<string, object>();
                        string ext = System.IO.Path.GetExtension(FileDialogName.Text).ToLower();
                        Console.WriteLine(ext);

                        if(ext != null) {

                            if (ext == ".ogg" || ext == ".mp3")
                            {
                                var file = new FormUpload.FileParameter(File.ReadAllBytes(FileDialogName.Text), "asset-upload" + ext, "application/octet-stream");
                                dic.Add("SongName", SongName.Text);
                                dic.Add("Author", AuthorName.Text);
                                dic.Add("Type", ext);
                                dic.Add("Content", file);
                                Functions.UploadAsset("audio", dic);
                            }

                        }

                    }
                }
            }
        }

    }
}
