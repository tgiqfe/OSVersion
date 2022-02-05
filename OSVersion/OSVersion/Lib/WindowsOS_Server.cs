using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSVersion.Lib
{
    internal class WindowsServer2012
    {
        public static WindowsOS Create()
        {
            return new WindowsOS()
            {
                OSFamily = OSFamily.Windows,
                Name = "Windows Server",
                Alias = new string[] { "WindowsSevrer2012", "WinSrv2012" },

            };
        }
    }
}
