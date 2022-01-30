using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSVersion.Lib
{
    internal class OSInfo
    {
        #region Public parameter

        /// <summary>
        /// OSの名前
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// OS名のエイリアス
        /// </summary>
        public string[] Alias { get; set; }

        /// <summary>
        /// OS種類。Windows/Linux/Mac
        /// ※今回のバージョンでは全部Windows
        /// </summary>
        public OSFamily OSFamily { get; set; }

        /// <summary>
        /// バージョン名称
        /// </summary>
        public string VersionName { get; set; }

        /// <summary>
        /// バージョン名のエイリアス
        /// </summary>
        public string[] VersionAlias { get; set; }

        /// <summary>
        /// サーバOSかどうか
        /// </summary>
        public bool? ServerOS { get; set; }

        /// <summary>
        /// 組み込みOSかどうか
        /// </summary>
        public bool? EmbeddedOS { get; set; }

        #endregion

        protected int Serial { get; }


    }
}
