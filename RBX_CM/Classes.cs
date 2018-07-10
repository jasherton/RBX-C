using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Windows.Forms;
using System.Reflection;
using System.Web;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;

namespace RBX_C
{

    public class FormProperties
    {
        //Define Properties
        private static string D_Status = "none";

        public static string DownloadStatus(string type, string set)
        {
            if (type != null)
            {
                if (type == "Get")
                {
                    return D_Status;
                } else if (type == "Set")
                {
                    if (set != null)
                    {
                        D_Status = set;
                        return D_Status;
                    } else
                    {
                        return "null";
                    }
                } else
                {
                    return "null";
                }
            }
            else
            {
                return "null";
            }
        }

    }

    public class Functions
    {

        public static void Copy(string sourceDir, string targetDir)
        {
            try
            {
                if (Directory.Exists(targetDir))
                {
                    Directory.Delete(targetDir, true);
                }

                Directory.CreateDirectory(targetDir);

                foreach (var file in Directory.GetFiles(sourceDir))
                    File.Copy(file, Path.Combine(targetDir, Path.GetFileName(file)), true);

                foreach (var directory in Directory.GetDirectories(sourceDir))
                    Copy(directory, Path.Combine(targetDir, Path.GetFileName(directory)));
            }catch
            {
                return;
            }
        }

        public static string RBXCheck(string search)
        {

            if (search != null)
            {

                string client = "none";
                string studio = "none";

                WebClient webclient = new WebClient();
                webclient.Proxy = null;

                //Get Client Directory
                try
                {
                    client = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Roblox\\Versions\\" + webclient.DownloadString("http://setup.roblox.com/version") + "\\";
                }
                catch
                {
                    Console.WriteLine("Could not find ROBLOX Client Directory.");
                }

                //Get Studio Directory
                try
                {
                    studio = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) + "\\Roblox\\Versions\\" + webclient.DownloadString("http://setup.roblox.com/versionQTStudio") + "\\";
                }
                catch
                {
                    Console.WriteLine("Could not find ROBLOX Studio Directory.");
                }

                if (search == "client")
                {
                    return client;
                }
                else if (search == "studio")
                {
                    return studio;
                }
                else
                {
                    return "none";
                }

            }
            else
            {
                return "none";
            }

        }

        public static string ReturnIP()
        {
            try
            {
                string direction;
                HttpWebRequest request = WebRequest.CreateHttp("http://checkip.dyndns.org/");
                request.UserAgent = "Mozilla/5.0 (Linux; U; Android 4.0.4; pt-br; MZ608 Build/7.7.1-141-7-FLEM-UMTS-LA) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Safari/534.30";
                WebResponse response = request.GetResponse();
                StreamReader stream = new StreamReader(response.GetResponseStream());
                direction = stream.ReadToEnd();
                stream.Close();
                response.Close(); //Search for the ip in the html
                int first = direction.IndexOf("Address: ") + 9;
                int last = direction.LastIndexOf("</body");
                direction = direction.Substring(first, last - first);
                return direction;
            }
            catch
            {
                return "Could Not Find. Default.";
            }
        }

        public static Dictionary<string, string> ReturnSiteInfo()
        {
            //string ipinfo = ReturnIP();
            var siteinfo = new Dictionary<string, string> { };

            //if (ipinfo != null)
            //{

            //if (ipinfo == "24.14.6.117")
            //{

            //    siteinfo = new Dictionary<string, string>
            //    {
            //        { "Main", "http://10.0.0.2/jjelamb/"},
            //        { "Home", "http://10.0.0.2/jjelamb/RBX-CM/home.html"},
            //    };
            //}else
            //{
            siteinfo = new Dictionary<string, string>
                    {
                        { "Main", "http://24.14.6.117/jjelamb/"},
                        { "Home", "http://24.14.6.117/jjelamb/RBX-CM/home.html"},
                    };
            //}

            //}



            return siteinfo;
        }

        public static WebProxy setProxy()
        {
            string[] filedata = System.IO.File.ReadAllLines("resources/settings.txt");
            var proxyinfo = filedata[0].Split(':');
            string[] proxydata = null;

            if (proxyinfo[0] == "Proxy")
            {
                string[] sep = proxyinfo[1].Split(',');
                proxydata = sep;
            }

            if (proxydata != null)
            {
                WebProxy proxy = new WebProxy( proxydata[0].ToString().Trim(), Convert.ToInt32(proxydata[1].ToString().Trim()));
                if (proxy.Address != null)
                {
                    proxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                    WebHeaderCollection headers = new WebHeaderCollection();
                    WebRequest.DefaultWebProxy = new System.Net.WebProxy(proxy.Address, proxy.BypassProxyOnLocal, proxy.BypassList, proxy.Credentials);
                }
                return proxy;
            }else
            {
                WebProxy proxy = new WebProxy("35.231.153.77", 80);
                if (proxy.Address != null)
                {
                    proxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                    WebHeaderCollection headers = new WebHeaderCollection();
                    WebRequest.DefaultWebProxy = new System.Net.WebProxy(proxy.Address, proxy.BypassProxyOnLocal, proxy.BypassList, proxy.Credentials);
                }
                return proxy;
            }

        }

        public static WebResponse GetPageResponse(string site)
        {
            try
            {
                HttpWebRequest request = WebRequest.CreateHttp(site);
                request.Timeout = 1000;
                request.Proxy = setProxy();
                request.UserAgent = "Mozilla/5.0 (Linux; U; Android 4.0.4; pt-br; MZ608 Build/7.7.1-141-7-FLEM-UMTS-LA) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Safari/534.30";
                WebResponse response = request.GetResponse();
                return response;
            }
            catch
            {
                return null;
            }

        }

        public static string StripTagsCharArray(string source)
        {
            char[] array = new char[source.Length];
            int arrayIndex = 0;
            bool inside = false;
            for (int i = 0; i < source.Length; i++)
            {
                char let = source[i];
                if (let == '<')
                {
                    inside = true; continue;
                }
                if (let == '>')
                {
                    inside = false; continue;
                }
                if (!inside)
                {
                    array[arrayIndex] = let; arrayIndex++;
                }
            }
            return new string(array, 0, arrayIndex);
        }

        public static List<string> ReturnSongList(Dictionary<string, string> siteinfo)
        {
            try
            {
                var response = Functions.GetPageResponse(siteinfo["Main"] + "RBX-C/list.php");
                StreamReader stream = new StreamReader(response.GetResponseStream());
                string html = stream.ReadToEnd();
                Console.WriteLine(html);
                stream.Close();
                response.Close();

                List<string> songlist = new List<string>();
                string[] result = html.Split(new string[] { "<br>" }, StringSplitOptions.None);

                foreach (var value in result)
                {
                    if (Functions.StripTagsCharArray(value) != "")
                    {
                        if (Functions.StripTagsCharArray(value).All(Char.IsWhiteSpace))
                        {
                            //not valid either
                        }
                        else
                        {
                            //valid songnames
                            songlist.Add(Functions.StripTagsCharArray(value).Trim());
                        }
                    }
                }
                return songlist;
            }
            catch
            {
                List<string> songlist = new List<string>();
                return songlist;
            }
        }

        public static void NavigateToPage(string site, WebBrowser Browser)
        {
            try
            {
                //Read Page with Proxy
                var response = GetPageResponse(site);
                StreamReader stream = new StreamReader(response.GetResponseStream());
                string html = stream.ReadToEnd();
                stream.Close();
                response.Close();
                byte[] bytes = Encoding.UTF8.GetBytes(html);
                MemoryStream ms = new MemoryStream();
                ms.Write(bytes, 0, bytes.Length);
                ms.Position = 0;
                Browser.DocumentStream = ms;
            }
            catch
            {
                string errorpage = Resources.errorpage();
                byte[] bytes = Encoding.UTF8.GetBytes(errorpage);
                MemoryStream ms = new MemoryStream();
                ms.Write(bytes, 0, bytes.Length);
                ms.Position = 0;
                Browser.DocumentStream = ms;
            }
        }


        static readonly string[] SizeSuffixes =
                   { "bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        static string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} bytes", 0); }

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }


        public static Int64 GetStreamLength(Stream stream)
        {
            Stream test = new MemoryStream();
            stream.CopyToAsync(test);
            test.Close();
            return Convert.ToInt64(test.Length.ToString());
        }


        public static async Task DownloadSong(string name, Label ProgressBar)
        {
            if (name != null & name != "")
            {
                //
                var values = new Dictionary<string, string>
{
                {"submit", "submit"},
                {"cmdownloadname", name}
};
                var content = new FormUrlEncodedContent(values);

                try
                {
                    Dictionary<string, string> siteinfo = ReturnSiteInfo();

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(siteinfo["Main"] + "RBX-C/phpget.php");
                    request.Method = "POST";
                    request.Timeout = 1000;
                    request.Proxy = setProxy();
                    request.UserAgent = "Mozilla/5.0 (Linux; U; Android 4.0.4; pt-br; MZ608 Build/7.7.1-141-7-FLEM-UMTS-LA) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Safari/534.30";

                    byte[] contents = await content.ReadAsByteArrayAsync();
                    request.ContentLength = contents.Length;
                    request.ContentType = "application/x-www-form-urlencoded";
                    Stream dataStream = request.GetRequestStream();
                    dataStream.Write(contents, 0, contents.Length);
                    dataStream.Close();
                    WebResponse response = await request.GetResponseAsync();
                    Stream data = response.GetResponseStream();

                    string DIR = "music";

                    int total = new int();
                    //var datatotal = SizeSuffix(GetStreamLength(data));

                    FormProperties.DownloadStatus("Set", "Start");

                    var ctype = response.Headers.Get("Content-Type");
                    var ext = ".unknown";

                    if (ctype == "audio/mpeg")
                    {
                        ext = ".mp3";
                    }else if (ctype == "audio/ogg")
                    {
                        ext = ".ogg";
                    }


                    using (FileStream DestinationStream = File.Create(DIR + "\\" + values["cmdownloadname"] + ext))
                    {
                        FormProperties.DownloadStatus("Set", "InProgress");
                        byte[] buffer = new byte[16 * 2048];
                        int read;

                        while ((read = data.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            string totalstring = SizeSuffix(total);
                            total = total + read;
                            ProgressBar.Text = totalstring;
                            await DestinationStream.WriteAsync(buffer, 0, read);
                            ProgressBar.Text = "Completed";
                        }
                        DestinationStream.Close();
                        FormProperties.DownloadStatus("Set", "Completed");
                        return;
                    }

                }
                catch
                {
                    Console.Write("Failure.");
                    FormProperties.DownloadStatus("Set", "Failure");
                }

                //
            }
        }

        public static async Task DownloadAllSongs(ListBox InfoList, Label ProgressBar)
        {
            foreach (var value in InfoList.Items)
            {

                try
                {
                    var down_name = value.ToString();
                    var regex = "(\\[.*\\])|(\".*\")|('.*')|(\\(.*\\))";
                    down_name = Regex.Replace(down_name, regex, "");
                    down_name = down_name.Trim();

                    await Functions.DownloadSong(down_name, ProgressBar);
                    FormProperties.DownloadStatus("Set", "Start");
                    FormProperties.DownloadStatus("Set", "InProgress");
                    FormProperties.DownloadStatus("Set", "Completed");
                    ProgressBar.Text = "Completed";
                }
                catch
                {
                    Console.Write("Failure.");
                    FormProperties.DownloadStatus("Set", "Failure");
                }

            }
            return;

        }

        public static string CreateFormDataBoundary()
        {
            return "---------------------------" + DateTime.Now.Ticks.ToString("x");
        }

        public static void UploadAsset(string type, Dictionary<string,object> content)
        {
            if (type == "audio")
            {
                //Original Asset Type
                //audioupload.php
                try
                {
                    Dictionary<string, string> siteinfo = ReturnSiteInfo();
                    var proxy = setProxy();
                    Functions.FormUpload.MultipartFormDataPost(siteinfo["Main"] + "RBX-C/uploadaudio.php", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/60.0.3112.113 Safari/537.36", proxy, content);
                    return;

                }
                catch
                {
                    Console.Write("Failure.");
                    return;
                }
            }
        }


        public static class FormUpload
        {
            private static readonly Encoding encoding = Encoding.UTF8;
            public static HttpWebResponse MultipartFormDataPost(string postUrl, string userAgent, WebProxy proxy, Dictionary<string, object> postParameters)
            {
                string formDataBoundary = String.Format("----------{0:N}", Guid.NewGuid());
                string contentType = "multipart/form-data; boundary=" + formDataBoundary;

                byte[] formData = GetMultipartFormData(postParameters, formDataBoundary);

                return PostForm(postUrl, userAgent, proxy, contentType, formData);
            }
            private static HttpWebResponse PostForm(string postUrl, string userAgent, WebProxy proxy, string contentType, byte[] formData)
            {
                HttpWebRequest request = WebRequest.Create(postUrl) as HttpWebRequest;

                if (request == null)
                {
                    throw new NullReferenceException("request is not a http request");
                }

                // Set up the request properties.
                request.Method = "POST";
                request.ContentType = contentType;
                request.UserAgent = userAgent;
                request.Proxy = proxy;
                request.CookieContainer = new CookieContainer();
                request.ContentLength = formData.Length;

                // You could add authentication here as well if needed:
                // request.PreAuthenticate = true;
                // request.AuthenticationLevel = System.Net.Security.AuthenticationLevel.MutualAuthRequested;
                // request.Headers.Add("Authorization", "Basic " + Convert.ToBase64String(System.Text.Encoding.Default.GetBytes("username" + ":" + "password")));

                // Send the form data to the request.
                using (Stream requestStream = request.GetRequestStream())
                {
                    requestStream.Write(formData, 0, formData.Length);
                    requestStream.Close();
                }

                return request.GetResponse() as HttpWebResponse;
            }

            private static byte[] GetMultipartFormData(Dictionary<string, object> postParameters, string boundary)
            {
                Stream formDataStream = new System.IO.MemoryStream();
                bool needsCLRF = false;

                foreach (var param in postParameters)
                {
                    // Thanks to feedback from commenters, add a CRLF to allow multiple parameters to be added.
                    // Skip it on the first parameter, add it to subsequent parameters.
                    if (needsCLRF)
                        formDataStream.Write(encoding.GetBytes("\r\n"), 0, encoding.GetByteCount("\r\n"));

                    needsCLRF = true;

                    if (param.Value is FileParameter)
                    {
                        FileParameter fileToUpload = (FileParameter)param.Value;

                        // Add just the first part of this param, since we will write the file data directly to the Stream
                        string header = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"; filename=\"{2}\";\r\nContent-Type: {3}\r\n\r\n",
                            boundary,
                            param.Key,
                            fileToUpload.FileName ?? param.Key,
                            fileToUpload.ContentType ?? "application/octet-stream");

                        formDataStream.Write(encoding.GetBytes(header), 0, encoding.GetByteCount(header));

                        // Write the file data directly to the Stream, rather than serializing it to a string.
                        formDataStream.Write(fileToUpload.File, 0, fileToUpload.File.Length);
                    }
                    else
                    {
                        string postData = string.Format("--{0}\r\nContent-Disposition: form-data; name=\"{1}\"\r\n\r\n{2}",
                            boundary,
                            param.Key,
                            param.Value);
                        formDataStream.Write(encoding.GetBytes(postData), 0, encoding.GetByteCount(postData));
                    }
                }

                // Add the end of the request.  Start with a newline
                string footer = "\r\n--" + boundary + "--\r\n";
                formDataStream.Write(encoding.GetBytes(footer), 0, encoding.GetByteCount(footer));

                // Dump the Stream into a byte[]
                formDataStream.Position = 0;
                byte[] formData = new byte[formDataStream.Length];
                formDataStream.Read(formData, 0, formData.Length);
                formDataStream.Close();

                return formData;
            }

            public class FileParameter
            {
                public byte[] File { get; set; }
                public string FileName { get; set; }
                public string ContentType { get; set; }
                public FileParameter(byte[] file) : this(file, null) { }
                public FileParameter(byte[] file, string filename) : this(file, filename, null) { }
                public FileParameter(byte[] file, string filename, string contenttype)
                {
                    File = file;
                    FileName = filename;
                    ContentType = contenttype;
                }
            }
        }


    }

}
