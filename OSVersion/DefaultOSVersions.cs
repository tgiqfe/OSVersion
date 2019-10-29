using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSVersion
{
    class DefaultOSVersions
    {
        public static OSVersion[] GetOSVersions()
        {
            return new OSVersion[]
            {
                new OSVersion()
                {
                    Version = OSVersion.v1507,
                    Alias = "Released in July 2015",
                    BuildNumber = "10240",
                    FullVersion = "10.0.10240",
                    ReleaseDate = DateTime.Parse("2015/07/29")
                },
                new OSVersion()
                {
                    Version = OSVersion.v1511,
                    Alias = "November Update",
                    BuildNumber = "10586",
                    FullVersion = "10.0.10586",
                    ReleaseDate = DateTime.Parse("2015/11/12")
                },
                new OSVersion()
                {
                    Version = OSVersion.v1607,
                    Alias = "Anniversary Update",
                    BuildNumber = "14393",
                    FullVersion = "10.0.14393",
                    ReleaseDate = DateTime.Parse("2016/08/02")
                },
                new OSVersion()
                {
                    Version = OSVersion.v1703,
                    Alias = "Creators Update",
                    BuildNumber = "15063",
                    FullVersion = "10.0.15063",
                    ReleaseDate = DateTime.Parse("2017/04/11")
                },
                new OSVersion()
                {
                    Version = OSVersion.v1709,
                    Alias = "Fall Creators Update",
                    BuildNumber = "16299",
                    FullVersion = "10.0.16299",
                    ReleaseDate = DateTime.Parse("2017/10/17")
                },
                new OSVersion()
                {
                    Version = OSVersion.v1803,
                    Alias = "April 2018 Update",
                    BuildNumber = "17134",
                    FullVersion = "10.0.17134",
                    ReleaseDate = DateTime.Parse("2018/04/30")
                },
                new OSVersion()
                {
                    Version = OSVersion.v1809,
                    Alias = "October 2018 Update",
                    BuildNumber = "17763",
                    FullVersion = "10.0.17763",
                    ReleaseDate = DateTime.Parse("2018/11/13")
                },
                new OSVersion()
                {
                    Version = OSVersion.v1903,
                    Alias = "May 2019 Update",
                    BuildNumber = "18362",
                    FullVersion = "10.0.18362",
                    ReleaseDate = DateTime.Parse("2019/05/21")
                },
                new OSVersion()
                {
                    Version = OSVersion.v1909,
                    Alias = "November 2019 Update",
                    BuildNumber = "-----",
                    FullVersion = "10.0.-----",
                    ReleaseDate = DateTime.Parse("2019/11/11")  //  ←まだ不明
                },
            };
        }
    }
}
