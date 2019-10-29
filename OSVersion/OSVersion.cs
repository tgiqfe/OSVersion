using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;

namespace OSVersion
{
    class OSVersion
    {
        public const int v1507 = 1507;
        public const int v1511 = 1511;
        public const int v1607 = 1607;
        public const int v1703 = 1703;
        public const int v1709 = 1709;
        public const int v1803 = 1803;
        public const int v1809 = 1809;
        public const int v1903 = 1903;
        public const int v1909 = 1909;

        public string Name { get { return this.Version.ToString(); } }
        public int Version { get; set; }
        public string Alias { get; set; }
        public string BuildNumber { get; set; }
        public string FullVersion { get; set; }
        public DateTime ReleaseDate { get; set; }
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
            switch (version)
            {
                case v1507:
                    this.Version = v1507;
                    this.Alias = "Released in July 2015";
                    this.BuildNumber = "10240";
                    this.FullVersion = "10.0.10240";
                    this.ReleaseDate = DateTime.Parse("2015/07/29");
                    break;
                case v1511:
                    this.Version = v1511;
                    this.Alias = "November Update";
                    this.BuildNumber = "10586";
                    this.FullVersion = "10.0.10586";
                    this.ReleaseDate = DateTime.Parse("2015/11/12");
                    break;
                case v1607:
                    this.Version = v1607;
                    this.Alias = "Anniversary Update";
                    this.BuildNumber = "14393";
                    this.FullVersion = "10.0.14393";
                    this.ReleaseDate = DateTime.Parse("2016/08/02");
                    break;
                case v1703:
                    this.Version = v1703;
                    this.Alias = "Creators Update";
                    this.BuildNumber = "15063";
                    this.FullVersion = "10.0.15063";
                    this.ReleaseDate = DateTime.Parse("2017/04/11");
                    break;
                case v1709:
                    this.Version = v1709;
                    this.Alias = "Fall Creators Update";
                    this.BuildNumber = "16299";
                    this.FullVersion = "10.0.16299";
                    this.ReleaseDate = DateTime.Parse("2017/10/17");
                    break;
                case v1803:
                    this.Version = v1803;
                    this.Alias = "April 2018 Update";
                    this.BuildNumber = "17134";
                    this.FullVersion = "10.0.17134";
                    this.ReleaseDate = DateTime.Parse("2018/04/30");
                    break;
                case v1809:
                    this.Version = v1809;
                    this.Alias = "October 2018 Update";
                    this.BuildNumber = "17763";
                    this.FullVersion = "10.0.17763";
                    this.ReleaseDate = DateTime.Parse("2018/11/13");
                    break;
                case v1903:
                    this.Version = v1903;
                    this.Alias = "May 2019 Update";
                    this.BuildNumber = "18362";
                    this.FullVersion = "10.0.18362";
                    this.ReleaseDate = DateTime.Parse("2019/05/21");
                    break;
                case v1909:
                    Version = v1909;
                    Alias = "November 2019 Update";
                    BuildNumber = "-----";
                    FullVersion = "10.0.-----";
                    ReleaseDate = DateTime.Parse("2019/11/11");  //  ←まだ不明
                    break;
            }
        }



        public OSVersion(string fullVersion)
        {

        }


        public static OSVersion GetOSVersion()
        {
            ManagementObject mo = new ManagementClass("Win32_OperatingSystem").
                GetInstances().
                OfType<ManagementObject>().
                First();
            OSVersion osver = DefaultOSVersions.GetOSVersions().FirstOrDefault(x => x.FullVersion == mo["Version"].ToString());
            osver.Edition = mo["Caption"] as string;

            return osver;
        }

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
        public static bool operator >(OSVersion x, OSVersion y) { return x.Version < y.Version; }
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

        /// <summary>
        /// 比較演算子 !=
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(OSVersion x, OSVersion y) { return x.Version != y.Version; }

        /// <summary>
        /// Equals
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj) { return this.Version == ((OSVersion)obj).Version; }

        /// <summary>
        /// GetHashCode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode() { return base.GetHashCode(); }
    }
}
