using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSVersion.Lib
{
    #region Windows 10

    internal class Windows10
    {
        public static WindowsOS Create1507()
        {
            return new WindowsOS()
            {
                Name = "Windows 10",
                Alias = new[] { "Windows10", "Windows_10", "Win10" },
                VersionName = "10.0.10240",
                VersionAlias = new[] { "1507", "v1507", "Released in July 2015", "ReleasedinJuly2015", "Threshold 1", "Threshold1", "Release Version", "ReleaseVersion" },
            };
        }

        public static WindowsOS Create1511()
        {
            return new WindowsOS()
            {
                Name = "Windows 10",
                Alias = new[] { "Windows10", "Windows_10", "Win10" },
                VersionName = "10.0.10586",
                VersionAlias = new[] { "1511", "v1511", "November Update", "NovemberUpdate", "Threshold 2", "Threshold2" },
            };
        }

        public static WindowsOS Create1607()
        {
            return new WindowsOS()
            {
                Name = "Windows 10",
                Alias = new[] { "Windows10", "Windows_10", "Win10" },
                VersionName = "10.0.14393",
                VersionAlias = new[] { "1607", "v1607", "Anniversary Update", "AnniversaryUpdate", "Redstone 1", "Redstone1" },
            };
        }

        public static WindowsOS Create1703()
        {
            return new WindowsOS()
            {
                Name = "Windows 10",
                Alias = new[] { "Windows10", "Windows_10", "Win10" },
                VersionName = "10.0.15063",
                VersionAlias = new[] { "1703", "v1703", "Creators Update", "CreatorsUpdate", "Redstone 2", "Redstone2" },
            };
        }

        public static WindowsOS Create1709()
        {
            return new WindowsOS()
            {
                Name = "Windows 10",
                Alias = new[] { "Windows10", "Windows_10", "Win10" },
                VersionName = "10.0.16299",
                VersionAlias = new[] { "1709", "v1709", "Fall Creators Update", "FallCreatorsUpdate", "Redstone 3", "Redstone3" },
            };
        }

        public static WindowsOS Create1803()
        {
            return new WindowsOS()
            {
                Name = "Windows 10",
                Alias = new[] { "Windows10", "Windows_10", "Win10" },
                VersionName = "10.0.17134",
                VersionAlias = new[] { "1803", "v1803", "April 2018 Update", "April2018Update", "Redstone 4", "Redstone4" },
            };
        }

        public static WindowsOS Create1809()
        {
            return new WindowsOS()
            {
                Name = "Windows 10",
                Alias = new[] { "Windows10", "Windows_10", "Win10" },
                VersionName = "10.0.17763",
                VersionAlias = new[] { "1809", "v1809", "October 2018 Update", "October2018Update", "Redstone 5", "Redstone5" },
            };
        }

        public static WindowsOS Create1903()
        {
            return new WindowsOS()
            {
                Name = "Windows 10",
                Alias = new[] { "Windows10", "Windows_10", "Win10" },
                VersionName = "10.0.18362",
                VersionAlias = new[] { "1903", "v1903", "May 2019 Update", "May2019Update", "19H1" },
            };
        }

        public static WindowsOS Create1909()
        {
            return new WindowsOS()
            {
                Name = "Windows 10",
                Alias = new[] { "Windows10", "Windows_10", "Win10" },
                VersionName = "10.0.18636",
                VersionAlias = new[] { "1909", "v1909", "November 2019 Update", "November2019Update", "19H2" },
            };
        }

        public static WindowsOS Create2004()
        {
            return new WindowsOS()
            {
                Name = "Windows 10",
                Alias = new[] { "Windows10", "Windows_10", "Win10" },
                VersionName = "10.0.19041",
                VersionAlias = new[] { "2004", "v2004", "May 2020 Update", "May2020Update", "20H1" },
            };
        }

        public static WindowsOS Create20H2()
        {
            return new WindowsOS()
            {
                Name = "Windows 10",
                Alias = new[] { "Windows10", "Windows_10", "Win10" },
                VersionName = "10.0.19042",
                VersionAlias = new[] { "20H2", "v20H2", "October 2020 Update", "October2020Update" },
            };
        }

        public static WindowsOS Create21H1()
        {
            return new WindowsOS()
            {
                Name = "Windows 10",
                Alias = new[] { "Windows10", "Windows_10", "Win10" },
                VersionName = "10.0.19043",
                VersionAlias = new[] { "21H1", "v21H1", "May 2021 Update", "May2021Update" },
            };
        }

        public static WindowsOS Create21H2()
        {
            return new WindowsOS()
            {
                Name = "Windows 10",
                Alias = new[] { "Windows10", "Windows_10", "Win10" },
                VersionName = "10.0.19044",
                VersionAlias = new[] { "21H2", "v21H2", "November 2021 Update", "November2021Update" },
            };
        }

        public static WindowsOS Create(int version)
        {
            var windowsOS = new WindowsOS()
            {
                OSFamily = OSFamily.Windows,
                Name = "Windows 10",
                Alias = new string[] { "Windows10", "Windows_10", "Win10" },
            };
            windowsOS.VersionName = version.ToString();
            return windowsOS;
        }
    }

    #endregion
    #region Windows 11

    internal class Windows11
    {
        public static WindowsOS Create21H2()
        {
            return new WindowsOS()
            {
                Name = "Windows 11",
                Alias = new[] { "Windows11", "Windows_11", "Win11" },
                VersionName = "10.0.22000",
                VersionAlias = new[] { "21H2", "v21H2", "22000", "Sun Valley", "Release Version", "ReleaseVersion" },
            };
        }
    }

    #endregion
}
