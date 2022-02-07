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

    internal class WindowsServer2012R2
    {
        public static WindowsOS Create()
        {
            return new WindowsOS()
            {
                OSFamily = OSFamily.Windows,
                Name = "Windows Server",
                Alias = new string[] { "WindowsSevrer2012R2", "WinSrv2012R2" },
            };
        }
    }

    internal class WindowsServer2016
    {
        public static WindowsOS Create()
        {
            return new WindowsOS()
            {
                OSFamily = OSFamily.Windows,
                Name = "Windows Server",
                Alias = new string[] { "WindowsSevrer2016", "WinSrv2016" },
            };
        }
    }
}
