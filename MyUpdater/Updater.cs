using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MyUpdater
{
    public class Updater
    {

        private UpdateInfo AppInfo;
        private BackgroundWorker bgWorker;

        public Updater(UpdateInfo AppInfo)
        {
            this.AppInfo = AppInfo;

            Console.WriteLine("hi2");
            AppInfo.tick.Tick += new System.EventHandler(this.TickHandler);

            this.bgWorker = new BackgroundWorker();
            this.bgWorker.DoWork += new DoWorkEventHandler(bgWorker_DoWork);
            this.bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgWorker_RunWorkerCompleted);

        }

        public void DoUpdate()
        {
            Console.Write("DoUpdate");
            if (!this.bgWorker.IsBusy)
                this.bgWorker.RunWorkerAsync(this.AppInfo);
        }

        private void TickHandler(object sender, EventArgs e)
        {
            Console.WriteLine("Tick");
        }

        public static async Task retupdate(UpdateInfo AppInfo)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(AppInfo.UpdateXmlLocation);
                request.Method = "GET";
                request.Timeout = 1000;
                request.UserAgent = "Mozilla/5.0 (Linux; U; Android 4.0.4; pt-br; MZ608 Build/7.7.1-141-7-FLEM-UMTS-LA) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Safari/534.30";

                WebResponse response = await request.GetResponseAsync();
                Stream data = response.GetResponseStream();

                MemoryStream xmldata = new MemoryStream();
                XmlDocument doc = new XmlDocument();

                byte[] buffer = new byte[16 * 2048];
                int read;

                while ((read = data.Read(buffer, 0, buffer.Length)) > 0)
                {
                    await xmldata.WriteAsync(buffer, 0, read);
                }

                xmldata.Position = 0;
                doc.Load(xmldata);
                doc.Save("updateinfo.xml");
                xmldata.Close();
            }catch
            {
                Console.WriteLine("not found.");
            }

            return;
        }

        public static async Task UpdateRequest(string location)
        {
                //main update
                var uri = new Uri(location);
                var filename = uri.Segments.Last();

                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(location);
                    request.Method = "GET";
                    request.Timeout = 1000;
                    request.UserAgent = "Mozilla/5.0 (Linux; U; Android 4.0.4; pt-br; MZ608 Build/7.7.1-141-7-FLEM-UMTS-LA) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Safari/534.30";

                    WebResponse response = await request.GetResponseAsync();
                    Stream data = response.GetResponseStream();

                    byte[] buffer = new byte[16 * 2048];
                    int read;

                if (Directory.Exists("dwntmp"))
                {
                    //ok
                }
                else
                {
                    Directory.CreateDirectory("dwntmp");
                }
                    
                    using (FileStream deststream = File.Create("dwntmp//"+filename))
                    {
                        while ((read = data.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            await deststream.WriteAsync(buffer, 0, read);
                        }
                        deststream.Close();
                    }
                    return;
                }
                catch
                {
                    Console.WriteLine("could not get required data.");
                    return;
                }
        }

        private async void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("checking for xml");
            UpdateInfo application = (UpdateInfo)e.Argument;

            //perform request
            int i = 0;
            while (!File.Exists("updateinfo.xml") && i < 5)
            {
                Thread.Sleep(500);
                i++;

                //clear last update file
                if (File.Exists("updateinfo.xml"))
                {
                    File.Delete("updateinfo.xml");
                }

                await retupdate(AppInfo);
                Console.WriteLine("grabbed");
            }

            return;
        }

        private async void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            XmlDocument doc = new XmlDocument();

            //wait a bit
            int i = 0;
            while (!File.Exists("updateinfo.xml") && i < 3)
            {
                Thread.Sleep(700);
                i++;
            }

            //load file info
            if (File.Exists("updateinfo.xml"))
            {
                doc.Load("updateinfo.xml");
                Console.WriteLine(doc.SelectSingleNode("GrandUpdate").SelectSingleNode("update").Name);
                Version xmlversion = Version.Parse(doc.SelectSingleNode("GrandUpdate").SelectSingleNode("update").SelectSingleNode("version").InnerText);
                Console.WriteLine(xmlversion);
                //check file version
                if (xmlversion > AppInfo.ApplicationAssembly.GetName().Version)
                {
                    Console.WriteLine("update valid");
                    //process update

                    if (new InfoForm(this,doc.SelectSingleNode("GrandUpdate").SelectSingleNode("update")).ShowDialog(this.AppInfo.Context) == DialogResult.Yes)
                    {
                        Console.WriteLine("perform update");
                        int filecount = 0;

                        //app
                        XmlNode apploc = doc.SelectSingleNode("GrandUpdate").SelectSingleNode("update").SelectSingleNode("apploc");
                        filecount = filecount + 1;
                        await UpdateRequest(apploc.InnerText);

                        //dlls
                        XmlNode appdll = doc.SelectSingleNode("GrandUpdate").SelectSingleNode("update").SelectSingleNode("appdll");
                        foreach (XmlNode childNode in appdll.ChildNodes)
                        {
                            filecount = filecount + 1;

                            await UpdateRequest(childNode.InnerText);
                        }

                        Console.WriteLine(filecount.ToString());

                        Console.WriteLine(Directory.GetFiles("dwntmp").Count());
                        if (Directory.GetFiles("dwntmp").Count() == filecount)
                        {
                            Application.Exit();
                            Console.WriteLine("all files created properly.");
                            Functions.MoveFromDirectory("dwntmp", Directory.GetCurrentDirectory().ToString());
                            
                        }
                        else
                        {
                            Console.WriteLine("not every file was grabbed. update failed.");
                            Functions.DeleteDirectory("dwntmp");
                        }

                    }

                
                    Console.WriteLine("a");
                }

                
            }
            else
            {
                Console.WriteLine("failed to get updateinfo");
            }

            //delete file
            if (File.Exists("updateinfo.xml"))
            {
                File.Delete("updateinfo.xml");
            }


            //print result if existant
            if (e.Result != null)
            {
                Console.WriteLine(e.Result.ToString());
            }

        }

    }
}
