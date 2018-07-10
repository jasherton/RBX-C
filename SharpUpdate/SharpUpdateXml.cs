using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace SharpUpdate
{
    internal class SharpUpdateXml
    {
        private Version version;
        private Uri uri;
        private string fileName;
        private string md5;
        private string description;
        private string launchArgs;

        internal Version Version
        {
            get { return this.version; }
        }

        internal Uri Uri
        {
            get { return this.uri; }
        }

        internal string FileName
        {
            get { return this.fileName; }
        }

        internal string MD5
        {
            get { return this.md5; }
        }

        internal string Description
        {
            get { return this.description; }
        }

        internal string LaunchArgs
        {
            get { return this.launchArgs; }
        }

        internal SharpUpdateXml(Version version, Uri uri, string fileName, string md5, string description, string launchArgs)
        {
            this.version = version;
            this.uri = uri;
            this.fileName = fileName;
            this.md5 = md5;
            this.description = description;
            this.launchArgs = launchArgs;
        }

        internal bool IsNewerThan(Version version)
        {
            return this.version > version;
        }



        private static WebProxy setProxy()
        {
            string[] filedata = System.IO.File.ReadAllLines(@"resources/settings.txt");
            var proxyinfo = filedata[0].Split(':');
            string[] proxydata = null;

            if (proxyinfo[0] == "Proxy")
            {
                string[] sep = proxyinfo[1].Split(',');
                proxydata = sep;
            }

            if (proxydata != null)
            {
                WebProxy proxy = new WebProxy(proxydata[0].ToString().Trim(), Convert.ToInt32(proxydata[1].ToString().Trim()));
                if (proxy.Address != null)
                {
                    proxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                    WebHeaderCollection headers = new WebHeaderCollection();
                    WebRequest.DefaultWebProxy = new System.Net.WebProxy(proxy.Address, proxy.BypassProxyOnLocal, proxy.BypassList, proxy.Credentials);
                }
                return proxy;
            }
            else
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


        internal static bool ExistsOnServer(Uri location)
        {
            try
            {
                //Custom Request
                HttpWebRequest req = (HttpWebRequest)WebRequest.Create(location.AbsoluteUri);
                req.Timeout = 1000;
                req.Proxy = setProxy();
                req.UserAgent = "Mozilla/5.0 (Linux; U; Android 4.0.4; pt-br; MZ608 Build/7.7.1-141-7-FLEM-UMTS-LA) AppleWebKit/534.30 (KHTML, like Gecko) Version/4.0 Safari/534.30";
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                resp.Close();

                return resp.StatusCode == HttpStatusCode.OK;
            }
            catch { return false; }
        }

        internal static SharpUpdateXml Parse(Uri location, string appID)
        {
            Version version = null;
            string url = "", fileName = "", md5 = "", description = "", launchArgs = "";

            try
            {
                XmlDocument doc = new XmlDocument();
                doc.Load(location.AbsoluteUri);

                XmlNode node = doc.DocumentElement.SelectSingleNode("//update[@appId='" + appID + "']");

                if (node == null)
                    return null;

                version = Version.Parse(node["version"].InnerText);
                url = node["url"].InnerText;
                fileName = node["fileName"].InnerText;
                md5 = node["md5"].InnerText;
                description = node["description"].InnerText;
                launchArgs = node["launchArgs"].InnerText;

                return new SharpUpdateXml(version, new Uri(url), fileName, md5, description, launchArgs);
            }
            catch { return null; }
        }
    }
}
