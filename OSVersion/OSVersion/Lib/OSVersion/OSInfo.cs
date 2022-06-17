using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using OSVersion.Lib.OSVersion.Windows;

namespace OSVersion.Lib.OSVersion
{
    internal class OSInfo : OSCompare
    {
        #region Public parameter

        /// <summary>
        /// OS種類。Windows/Linux/Mac
        /// ※今回のバージョンでは全部Windows
        /// </summary>
        public OSFamily OSFamily { get; set; }

        /// <summary>
        /// OSの名前
        /// </summary>
        public override string Name { get; set; }

        /// <summary>
        /// OS名のエイリアス
        /// </summary>
        public string[] Alias { get; set; }

        /// <summary>
        /// バージョン名称
        /// </summary>
        public string VersionName { get; set; }

        /// <summary>
        /// バージョン名のエイリアス
        /// </summary>
        public string[] VersionAlias { get; set; }

        /// <summary>
        /// OSのエディション
        /// </summary>
        public Edition? Edition { get; set; }

        /// <summary>
        /// サーバOSかどうか
        /// </summary>
        public bool? ServerOS { get; set; }

        /// <summary>
        /// 組み込みOSかどうか
        /// </summary>
        public bool? EmbeddedOS { get; set; }

        /// <summary>
        /// 単純なバージョン比較用
        /// </summary>
        protected override int Serial { get; }

        #endregion

        //private static WindowsOSCollection windowsCollection = null;

        public static OSInfo GetCurrent(string dbDir)
        {
            if (OperatingSystem.IsWindows())
            {
                //  Windowsの場合
                //return WindowsOS.GetCurrent(windowsCollection, dbDir);
            }
            else if (OperatingSystem.IsMacOS())
            {
                //  Macの場合 (そのうち実装する、、、かも?)
            }
            else if (OperatingSystem.IsLinux())
            {
                //  Linuxの場合 (そのうち実装する、、、かも?)
            }

            return null;
        }

        

    }
}
