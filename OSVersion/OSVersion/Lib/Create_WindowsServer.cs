
namespace OSVersion.Lib
{
    #region Windows Server

    internal class WindowsServer
    {
        public static WindowsOS Create2012()
        {
            return new WindowsOS()
            {
                Name = "Windows Server",
                Alias = new[] { "WindowsServer", "Windows SV", "WindowsSV", "WinSV", "WinSrv" },
                VersionName = "6.2.9200",
                VersionAlias = new[] { "2012", "WindowsSevrer2012", "WinSrv2012", "Win2012", "NT 6.2", "NT6.2" },
                ServerOS = true,
            };
        }

        //  2012R2, 2016, 2019, 2022
    }

    #endregion
}


/*

めも

2012年 	Windows Server 2012 	NT 6.2 	9200 	2023年10月10日[13]
2013年 	Windows Server 2012 R2 	NT 6.3 	9600
2016年 	Windows Server 2016 	NT 10.0 	14393 	2027年1月12日[14]
2018年 	Windows Server 2019 	NT 10.0 	17763 	2029年1月9日[15]
2021年 	Windows Server 2022 	NT 10.0 	20348 	2031年10月14日[16]

*/