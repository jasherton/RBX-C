using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyUpdater
{
    class Functions
    {

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

        public static void DeleteDirectory(string dir)
        {
            try
            {

                foreach (var file in Directory.GetFiles(dir))
                {
                    File.Delete(file);
                }

                Directory.Delete(dir);

            }
            catch
            {
                return;
            }
        }

        public static void MoveFromDirectory(string dir, string targetdir)
        {
            try
            {

                foreach (var file in Directory.GetFiles(dir))
                {

                    if (File.Exists(targetdir + "\\" + Path.GetFileName(file)))
                    {
                        Console.WriteLine("deleting");
                        Console.WriteLine(targetdir + "\\" + Path.GetFileName(file));
                        File.Delete(targetdir + "\\" + Path.GetFileName(file));
                    }

                    File.Move(file, targetdir + "\\" + Path.GetFileName(file));
                }

                Directory.Delete(dir);

            }
            catch
            {
                return;
            }
        }

    }
}
