using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Text.RegularExpressions;

namespace OSVersion
{
    /// <summary>
    /// Windows OSのバージョン情報の取得/確認
    /// </summary>
    class OSVersion
    {
        //  参考URL)
        //  https://docs.microsoft.com/ja-jp/windows/release-information/
        //  https://ja.wikipedia.org/wiki/Microsoft_Windows_10#Redstone_2%EF%BC%88ver1703%EF%BC%89

        public const int v1507 = 1507;
        public const int v1511 = 1511;
        public const int v1607 = 1607;
        public const int v1703 = 1703;
        public const int v1709 = 1709;
        public const int v1803 = 1803;
        public const int v1809 = 1809;
        public const int v1903 = 1903;
        public const int v1909 = 1909;
        public const int v2004 = 2004;

        public string Name { get { return this.Version.ToString(); } }
        public int Version { get; set; }
        public string Alias { get; set; }
        public string BuildNumber { get; set; }
        public string FullVersion { get; set; }
        public string ReleaseDate { get; set; }
        public string EndSupportDate_HomePro { get; set; }
        public string EndSupportDate_EntEdu { get; set; }
        public string EndSupportDate_LTS { get; set; }
        public string Edition { get; set; }

        /// <summary>
        /// パラメータ無しのコンストラクタ。とりあえず作るだけ。
        /// </summary>
        public OSVersion() { }

        /// <summary>
        /// int型のバージョン名から
        /// </summary>
        /// <param name="version"></param>
        public OSVersion(int version)
        {
            CreateInstance(version);
        }

        /// <summary>
        /// 文字列のBuildVersion, FullVersion、Aliasから
        /// </summary>
        /// <param name="fullVersion"></param>
        public OSVersion(string fullVersion)
        {
            switch (fullVersion)
            {
                case "1507":
                case "Released in July 2015":
                case "10240":
                case "10.0.10240":
                    CreateInstance(v1507);
                    break;
                case "1511":
                case "November Update":
                case "10586":
                case "10.0.10586":
                    CreateInstance(v1511);
                    break;
                case "1607":
                case "Anniversary Update":
                case "14393":
                case "10.0.14393":
                    CreateInstance(v1607);
                    break;
                case "1703":
                case "Creators Update":
                case "15063":
                case "10.0.15063":
                    CreateInstance(v1703);
                    break;
                case "1709":
                case "Fall Creators Update":
                case "16299":
                case "10.0.16299":
                    CreateInstance(v1709);
                    break;
                case "1803":
                case "April 2018 Update":
                case "17134":
                case "10.0.17134":
                    CreateInstance(v1803);
                    break;
                case "1809":
                case "October 2018 Update":
                case "17763":
                case "10.0.17763":
                    CreateInstance(v1809);
                    break;
                case "1903":
                case "May 2019 Update":
                case "18362":
                case "10.0.18362":
                    CreateInstance(v1903);
                    break;
                case "1909":
                case "November 2019 Update":
                case "18363":
                case "10.0.18363":
                    CreateInstance(v1909);
                    break;
                case "2004":
                case "May 2020 Update":
                case "19041":
                case "10.0.19041":
                    CreateInstance(v2004);
                    break;
            }
        }

        /// <summary>
        /// int型のVersionから対象のOSバージョン情報を生成
        /// </summary>
        /// <param name="version"></param>
        private void CreateInstance(int version)
        {
            switch (version)
            {
                case v1507:
                    this.Version = v1507;
                    this.Alias = "Released in July 2015";
                    this.BuildNumber = "10240";
                    this.FullVersion = "10.0.10240";
                    this.ReleaseDate = "2015/07/29";
                    this.EndSupportDate_HomePro = "2017/05/09";
                    this.EndSupportDate_EntEdu = "2017/05/09";
                    this.EndSupportDate_LTS = "2025/10/24";
                    break;
                case v1511:
                    this.Version = v1511;
                    this.Alias = "November Update";
                    this.BuildNumber = "10586";
                    this.FullVersion = "10.0.10586";
                    this.ReleaseDate = "2015/11/12";
                    this.EndSupportDate_HomePro = "2017/10/10";
                    this.EndSupportDate_EntEdu = "2018/04/10";
                    break;
                case v1607:
                    this.Version = v1607;
                    this.Alias = "Anniversary Update";
                    this.BuildNumber = "14393";
                    this.FullVersion = "10.0.14393";
                    this.ReleaseDate = "2016/08/02";
                    this.EndSupportDate_HomePro = "2018/04/10";
                    this.EndSupportDate_EntEdu = "2019/04/09";
                    this.EndSupportDate_LTS = "2026/10/13";
                    break;
                case v1703:
                    this.Version = v1703;
                    this.Alias = "Creators Update";
                    this.BuildNumber = "15063";
                    this.FullVersion = "10.0.15063";
                    this.ReleaseDate = "2017/04/11";
                    this.EndSupportDate_HomePro = "2018/10/09";
                    this.EndSupportDate_EntEdu = "2019/10/08";
                    break;
                case v1709:
                    this.Version = v1709;
                    this.Alias = "Fall Creators Update";
                    this.BuildNumber = "16299";
                    this.FullVersion = "10.0.16299";
                    this.ReleaseDate = "2017/10/17";
                    this.EndSupportDate_HomePro = "2019/04/09";
                    this.EndSupportDate_EntEdu = "2020/04/14";
                    break;
                case v1803:
                    this.Version = v1803;
                    this.Alias = "April 2018 Update";
                    this.BuildNumber = "17134";
                    this.FullVersion = "10.0.17134";
                    this.ReleaseDate = "2018/04/30";
                    this.EndSupportDate_HomePro = "2019/11/12";
                    this.EndSupportDate_EntEdu = "2020/11/10";
                    break;
                case v1809:
                    this.Version = v1809;
                    this.Alias = "October 2018 Update";
                    this.BuildNumber = "17763";
                    this.FullVersion = "10.0.17763";
                    this.ReleaseDate = "2018/11/13";
                    this.EndSupportDate_HomePro = "2020/05/12";
                    this.EndSupportDate_EntEdu = "2021/05/11";
                    this.EndSupportDate_LTS = "2029/01/09";
                    break;
                case v1903:
                    this.Version = v1903;
                    this.Alias = "May 2019 Update";
                    this.BuildNumber = "18362";
                    this.FullVersion = "10.0.18362";
                    this.ReleaseDate = "2019/05/21";
                    this.EndSupportDate_HomePro = "2020/12/08";
                    this.EndSupportDate_EntEdu = "2021/12/07";
                    break;
                case v1909:
                    this.Version = v1909;
                    this.Alias = "November 2019 Update";
                    this.BuildNumber = "18636";
                    this.FullVersion = "10.0.18636";
                    this.ReleaseDate = "2019/11/12";
                    this.EndSupportDate_HomePro = "2021/05/11";
                    this.EndSupportDate_EntEdu = "2022/05/10";
                    break;
                case v2004:
                    this.Version = v2004;
                    this.Alias = "May 2020 Update";
                    this.BuildNumber = "19041";
                    this.FullVersion = "10.0.19041";
                    this.ReleaseDate = "2020/05/27";
                    this.EndSupportDate_HomePro = "2021/12/14";
                    this.EndSupportDate_EntEdu = "2021/12/14";
                    break;
            }
        }

        /// <summary>
        /// 実行中PCのOSバージョンを取得
        /// </summary>
        /// <returns></returns>
        public static OSVersion GetCurrent()
        {
            ManagementObject mo = new ManagementClass("Win32_OperatingSystem").
                GetInstances().
                OfType<ManagementObject>().
                First();
            return new OSVersion(mo["Version"] as string) { Edition = mo["Caption"] as string };
        }

        /// <summary>
        /// 指定したバージョンのOSVersionインスタンスを取得
        /// </summary>
        /// <param name="version"></param>
        /// <returns></returns>
        public static OSVersion GetVersion(int version)
        {
            return new OSVersion(version);
        }

        /// <summary>
        /// 指定したバージョンのOSVersionインスタンスの配列を取得
        /// </summary>
        /// <param name="versions"></param>
        /// <returns></returns>
        public static OSVersion[] GetVersion(int[] versions)
        {
            return versions.Select(x => new OSVersion(x)).ToArray();
        }

        /// <summary>
        /// 指定したバージョンのOSVersionインスタンスを取得
        /// </summary>
        /// <param name="fullVersion"></param>
        /// <returns></returns>
        public static OSVersion[] GetVersion(string fullVersion)
        {
            return GetVersion(new string[1] { fullVersion });
        }

        /// <summary>
        /// 指定したバージョンのOSVersionインスタンスの配列を取得
        /// </summary>
        /// <param name="fullVersions"></param>
        /// <returns></returns>
        public static OSVersion[] GetVersion(string[] fullVersions)
        {
            List<OSVersion> osVersionList = new List<OSVersion>();
            Regex reg_comma = new Regex(@",\s?");
            foreach (string fullVersion in fullVersions)
            {
                if (string.IsNullOrEmpty(fullVersion)) { continue; }
                foreach (string version in reg_comma.Split(fullVersion))
                {
                    osVersionList.Add(new OSVersion(version));
                }
            }
            return osVersionList.ToArray();
        }

        #region Operator

        /// <summary>
        /// 比較演算子 < 小なり
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator <(OSVersion x, OSVersion y) { return x.Version < y.Version; }
        public static bool operator <(OSVersion x, int y) { return x.Version < y; }
        public static bool operator <(int x, OSVersion y) { return x < y.Version; }

        /// <summary>
        /// 比較演算子 > 大なり
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator >(OSVersion x, OSVersion y) { return x.Version > y.Version; }
        public static bool operator >(OSVersion x, int y) { return x.Version > y; }
        public static bool operator >(int x, OSVersion y) { return x > y.Version; }

        /// <summary>
        /// 比較演算子 <= 小なりイコール
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator <=(OSVersion x, OSVersion y) { return x.Version <= y.Version; }
        public static bool operator <=(OSVersion x, int y) { return x.Version <= y; }
        public static bool operator <=(int x, OSVersion y) { return x <= y.Version; }

        /// <summary>
        /// 比較演算子 >= 大なりイコール
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator >=(OSVersion x, OSVersion y) { return x.Version >= y.Version; }
        public static bool operator >=(OSVersion x, int y) { return x.Version >= y; }
        public static bool operator >=(int x, OSVersion y) { return x >= y.Version; }

        /// <summary>
        /// 比較演算子 ==
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator ==(OSVersion x, OSVersion y) { return x.Version == y.Version; }
        public static bool operator ==(OSVersion x, int y) { return x.Version == y; }
        public static bool operator ==(int x, OSVersion y) { return x == y.Version; }

        /// <summary>
        /// 比較演算子 !=
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(OSVersion x, OSVersion y) { return x.Version != y.Version; }
        public static bool operator !=(OSVersion x, int y) { return x.Version != y; }
        public static bool operator !=(int x, OSVersion y) { return x != y.Version; }

        /// <summary>
        /// Equals()
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            switch (obj)
            {
                case OSVersion osver:
                    return this.Version == osver.Version;
                case int num:
                    return this.Version == num;
            }
            return false;
        }

        #endregion

        /// <summary>
        /// GetHashCode()
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.Version.ToString();
        }
    }
}
