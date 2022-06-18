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
    internal class WindowsOS : OSInfo
    {
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
    }
}
