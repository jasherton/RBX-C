using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyUpdater
{
        public interface UpdateInfo
        {
            string ApplicationName { get; }
            string ApplicationID { get; }
            Assembly ApplicationAssembly { get; }
            Uri UpdateXmlLocation { get; }
            Form Context { get; }
            Timer tick { get; }
        }
}
