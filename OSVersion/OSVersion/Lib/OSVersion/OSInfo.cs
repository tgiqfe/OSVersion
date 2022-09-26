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

        public bool IsMatch(string keyword)
        {
            if (this.VersionName == keyword) return true;
            if (this.VersionAlias?.Any(x => x.Equals(keyword, StringComparison.OrdinalIgnoreCase)) ?? false) return true;
            if ((keyword.StartsWith(this.Name) || (this.Alias?.Any(x => keyword.StartsWith(x)) ?? false)) &&
                keyword.EndsWith(this.VersionName) || (this.VersionAlias?.Any(x => keyword.EndsWith(x)) ?? false)) return true;

            return false;
        }

        public override string ToString()
        {
            return $"{Name} [ver {VersionName}]";
        }
    }
}
