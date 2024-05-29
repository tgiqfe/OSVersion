namespace OSVersion.Lib.OSVersion.Windows
{
    #region Windows Server

    /// <summary>
    /// Windows Server生成用クラス
    /// </summary>
    internal class WindowsServer
    {
        public static WindowsOS Create2012()
        {
            return new WindowsOS()
            {
                Name = "Windows Server",
                Alias = new[] { "WindowsServer", "Windows SV", "WindowsSV", "WinSV", "WinSrv" },
                VersionName = "6.2.9200",
                VersionAlias = new[] { "2012", "9200", "Windows Server 2012", "WindowsSevrer2012", "WinSrv2012", "Win2012", "NT 6.2", "NT6.2", "NT 6.2.9200", "NT6.2.9200" },
                ServerOS = true,
            };
        }

        public static WindowsOS Create2012R2()
        {
            return new WindowsOS()
            {
                Name = "Windows Server",
                Alias = new[] { "WindowsServer", "Windows SV", "WindowsSV", "WinSV", "WinSrv" },
                VersionName = "6.2.9600",
                VersionAlias = new[] { "2012 R2", "2012R2", "9600", "Windows Server 2012R2", "WindowsSevrer2012R2", "WinSrv2012R2", "Win2012R2", "NT 6.3", "NT6.3", "NT 6.3.9600", "NT6.3.9600" },
                ServerOS = true,
            };
        }

        public static WindowsOS Create2016()
        {
            return new WindowsOS()
            {
                Name = "Windows Server",
                Alias = new[] { "WindowsServer", "Windows SV", "WindowsSV", "WinSV", "WinSrv" },
                VersionName = "10.0.14393",
                VersionAlias = new[] { "2016", "14393", "Windows Server 2016", "WindowsSevrer2016", "WinSrv2016", "Win2016", "NT 10.0.14393", "NT10.0.14393" },
                ServerOS = true,
            };
        }

        public static WindowsOS Create2019()
        {
            return new WindowsOS()
            {
                Name = "Windows Server",
                Alias = new[] { "WindowsServer", "Windows SV", "WindowsSV", "WinSV", "WinSrv" },
                VersionName = "10.0.17763",
                VersionAlias = new[] { "2019", "17763", "Windows Server 2019", "WindowsSevrer2019", "WinSrv2019", "Win2019", "NT 10.0.17763", "NT10.0.17763" },
                ServerOS = true,
            };
        }

        public static WindowsOS Create2022()
        {
            return new WindowsOS()
            {
                Name = "Windows Server",
                Alias = new[] { "WindowsServer", "Windows SV", "WindowsSV", "WinSV", "WinSrv" },
                VersionName = "10.0.20348",
                VersionAlias = new[] { "2022", "20348", "Windows Server 2022", "WindowsSevrer2022", "WinSrv2022", "Win2022", "NT 10.0.20348", "NT10.0.20348" },
                ServerOS = true,
            };
        }
    }

    #endregion
}
