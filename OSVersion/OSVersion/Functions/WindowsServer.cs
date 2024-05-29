using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace OSVersion.Functions
{
    [SupportedOSPlatform("windows")]
    public class WindowsServer
    {
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

        public static bool Check()
        {
            return IsOS(OS_AnyServer);
        }

        #endregion
    }
}
