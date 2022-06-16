using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace OSVersion.Lib.OSVersion.Windows
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    internal class WindowsOS : OSCompare
    {
        #region Public parameter

        public WindowsEdition Edition { get; set; }

        #endregion
        #region Serial calcurate

        private int _serial = -1;

        protected override int Serial
        {
            get
            {
                if (_serial < 0) _serial = GetSerial();
                return _serial;
            }
        }

        /// <summary>
        /// プライオリティ値を取得してシリアル番号として返す
        /// </summary>
        /// <returns></returns>
        private int GetSerial()
        {
            //  OS名からプライオリティ値を取得
            int priorityOS = Name switch
            {
                "Windows 10" => 10 * 100000,
                "Windows 11" => 11 * 100000,
                "Windows Server" => 50 * 100000,
                _ => 0,
            };

            //

            //  バージョン名(バージョンのビルド番号)からプライオリティ値を取得
            string tempVerText = "";
            if (VersionName.Contains("."))
            {
                var array = VersionName.Split('.');

                //  第3フィールド(ビルド番号)の数値をプライオリティ値にセット
                //  第2フィールドまでしか無い場合は、末尾フィールドをプライオリティ値にセット
                tempVerText = array.Length >= 3 ? array[2] : array[array.Length - 1];
            }
            else
            {
                tempVerText = VersionName;
            }
            int priorityVer = int.TryParse(tempVerText, out int tempNum) ? tempNum : 0;

            //  OS+バージョンの各プライオリティ値の合計を返す
            return priorityOS + priorityVer;
        }

        #endregion

        public WindowsOS()
        {
            OSFamily = OSFamily.Windows;
        }

        #region Check ServerOS

        [DllImport("shlwapi.dll", SetLastError = true, EntryPoint = "#437")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsOS(uint os);

        //  OSType
        //  参考
        //  https://www.pinvoke.net/default.aspx/shlwapi.isos

        //private const uint OS_Windows = 0;
        //private const uint OS_NT = 1;
        //private const uint OS_Win95OrGreater = 2;
        //private const uint OS_NT4OrGreater = 3;
        //private const uint OS_Win98OrGreater = 5;
        //private const uint OS_Win98Gold = 6;
        //private const uint OS_Win2000OrGreater = 7;
        //private const uint OS_Win2000Pro = 8;
        //private const uint OS_Win2000Server = 9;
        //private const uint OS_Win2000AdvancedServer = 10;
        //private const uint OS_Win2000DataCenter = 11;
        //private const uint OS_Win2000Terminal = 12;
        //private const uint OS_Embedded = 13;
        //private const uint OS_TerminalClient = 14;
        //private const uint OS_TerminalRemoteAdmin = 15;
        //private const uint OS_Win95Gold = 16;
        //private const uint OS_MEOrGreater = 17;
        //private const uint OS_XPOrGreater = 18;
        //private const uint OS_Home = 19;
        //private const uint OS_Professional = 20;
        //private const uint OS_DataCenter = 21;
        //private const uint OS_AdvancedServer = 22;
        //private const uint OS_Server = 23;
        //private const uint OS_TerminalServer = 24;
        //private const uint OS_PersonalTerminalServer = 25;
        //private const uint OS_FastUserSwitching = 26;
        //private const uint OS_WelcomeLogonUI = 27;
        //private const uint OS_DomainMember = 28;
        private const uint OS_AnyServer = 29;
        //private const uint OS_WOW6432 = 30;
        //private const uint OS_WebServer = 31;
        //private const uint OS_SmallBusinessServer = 32;
        //private const uint OS_TabletPC = 33;
        //private const uint OS_ServerAdminUI = 34;
        //private const uint OS_MediaCenter = 35;
        //private const uint OS_Appliance = 36;

        public static bool IsWindowsServer()
        {
            return IsOS(OS_AnyServer);
        }

        #endregion

        public static WindowsOS GetCurrent(WindowsOSCollection collection, string dbDir)
        {
            var mo = new ManagementClass("Win32_OperatingSystem").
                GetInstances().
                OfType<ManagementObject>().
                First();
            string caption = mo["Caption"]?.ToString();
            string editionText = caption.Split(" ").Last();

            collection ??= WindowsOSCollection.Load(dbDir);

            bool isServer = IsOS(OS_AnyServer);
            string osName = caption switch
            {
                string s when s.StartsWith("Microsoft Windows 10") => "Windows 10",
                string s when s.StartsWith("Microsoft Windows 11") => "Windows 11",
                string s when s.StartsWith("Microsoft Windows Server") => "Windows Server",
                _ => null,
            };
            var winOS = collection.
                Where(x => (x.ServerOS ?? false) == isServer).
                Where(x => x.Name == osName).
                FirstOrDefault(x => x.VersionName == (mo["Version"]?.ToString() ?? ""));
            winOS.Edition = Enum.TryParse(editionText, out WindowsEdition tempEdition) ? tempEdition : WindowsEdition.None;

            return winOS;
        }

        public static WindowsOS GetCurrent(WindowsOSCollection collection)
        {
            var mo = new ManagementClass("Win32_OperatingSystem").
                GetInstances().
                OfType<ManagementObject>().
                First();
            string caption = mo["Caption"]?.ToString();
            string editionText = caption.Split(" ").Last();

            bool isServer = IsOS(OS_AnyServer);
            string osName = caption switch
            {
                string s when s.StartsWith("Microsoft Windows 10") => "Windows 10",
                string s when s.StartsWith("Microsoft Windows 11") => "Windows 11",
                string s when s.StartsWith("Microsoft Windows Server") => "Windows Server",
                _ => null,
            };
            var winOS = collection.
                Where(x => (x.ServerOS ?? false) == isServer).
                Where(x => x.Name == osName).
                FirstOrDefault(x => x.VersionName == (mo["Version"]?.ToString() ?? ""));
            winOS.Edition = Enum.TryParse(editionText, out WindowsEdition tempEdition) ? tempEdition : WindowsEdition.None;

            return winOS;
        }
    }
}
