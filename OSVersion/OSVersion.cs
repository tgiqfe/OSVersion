using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Management;
using System.Text.RegularExpressions;

namespace OSVersion
{
    public enum VersionName
    {
        v1507 = 1507,
        v1511 = 1511,
        v1607 = 1607,
        v1703 = 1703,
        v1709 = 1709,
        v1803 = 1803,
        v1809 = 1809,
        v1903 = 1903,
        v1909 = 1909,
        v2004 = 2004,
        v20H2 = 2010,
        v21H1 = 2105,
    }

    /// <summary>
    /// Windows OSのバージョン情報の取得/確認
    /// </summary>
    public class OSVersion
    {
        //  参考URL)
        //  https://ja.wikipedia.org/wiki/Microsoft_Windows_10#Redstone_2%EF%BC%88ver1703%EF%BC%89
        //  https://pc-karuma.net/windows-10-version/

        #region Class Parameter

        public virtual string Name { get; set; }
        public virtual VersionName Version { get; set; }
        public virtual string Alias { get; set; }
        public virtual string CodeName { get; set; }
        public virtual string BuildNumber { get; set; }
        public virtual string FullVersion { get; set; }
        public virtual DateTime ReleaseDate { get; set; }
        public virtual DateTime EndSupport_HomePro { get; set; }
        public virtual DateTime EndSupport_EntEdu { get; set; }
        public virtual DateTime? EndSupport_LTS { get; set; }
        public virtual string Edition { get; set; }

        #endregion

        public static v1507 v1507 = new v1507();
        public static v1511 v1511 = new v1511();
        public static v1607 v1607 = new v1607();
        public static v1703 v1703 = new v1703();
        public static v1709 v1709 = new v1709();
        public static v1803 v1803 = new v1803();
        public static v1809 v1809 = new v1809();
        public static v1903 v1903 = new v1903();
        public static v1909 v1909 = new v1909();
        public static v2004 v2004 = new v2004();
        public static v20H2 v20H2 = new v20H2();
        public static v21H1 v21H1 = new v21H1();


        private static readonly OSVersion[] Windows10Versions = new OSVersion[]
        {
            new v1507(),
            new v1511(),
            new v1607(),
            new v1703(),
            new v1709(),
            new v1803(),
            new v1809(),
            new v1903(),
            new v1909(),
            new v2004(),
            new v20H2(),
            new v21H1()
        };

        /// <summary>
        /// パラメータ無しのコンストラクタ。とりあえず作るだけ。
        /// </summary>
        public OSVersion() { }

        /// <summary>
        /// VersionName型から
        /// </summary>
        /// <param name="version"></param>
        public OSVersion(VersionName version)
        {
            CreateInstance(version);
        }

        /// <summary>
        /// 文字列のBuildVersion, FullVersion、Alias等から
        /// </summary>
        /// <param name="fullVersion"></param>
        public OSVersion(string fullVersion)
        {
            OSVersion osver = Windows10Versions.FirstOrDefault(x =>
                x.Version.ToString().Equals(fullVersion, StringComparison.OrdinalIgnoreCase) ||
                x.Name.Equals(fullVersion, StringComparison.OrdinalIgnoreCase) ||
                x.Alias.Equals(fullVersion, StringComparison.OrdinalIgnoreCase) ||
                x.CodeName.Equals(fullVersion, StringComparison.OrdinalIgnoreCase) ||
                x.BuildNumber.Equals(fullVersion, StringComparison.OrdinalIgnoreCase) ||
                x.FullVersion.Equals(fullVersion, StringComparison.OrdinalIgnoreCase));
            if (!ReferenceEquals(osver, null))
            {
                this.Version = osver.Version;
                this.Name = osver.Name;
                this.Alias = osver.Alias;
                this.CodeName = osver.CodeName;
                this.BuildNumber = osver.BuildNumber;
                this.FullVersion = osver.FullVersion;
                this.ReleaseDate = osver.ReleaseDate;
                this.EndSupport_HomePro = osver.EndSupport_HomePro;
                this.EndSupport_EntEdu = osver.EndSupport_EntEdu;
                this.EndSupport_LTS = osver.EndSupport_LTS;
            }
        }

        /// <summary>
        /// VersionName型から対象のOSバージョン情報を生成
        /// </summary>
        /// <param name="version"></param>
        private void CreateInstance(VersionName version)
        {
            OSVersion osver = Windows10Versions.FirstOrDefault(x => x.Version == version);
            this.Version = osver.Version;
            this.Name = osver.Name;
            this.Alias = osver.Alias;
            this.CodeName = osver.CodeName;
            this.BuildNumber = osver.BuildNumber;
            this.FullVersion = osver.FullVersion;
            this.ReleaseDate = osver.ReleaseDate;
            this.EndSupport_HomePro = osver.EndSupport_HomePro;
            this.EndSupport_EntEdu = osver.EndSupport_EntEdu;
            this.EndSupport_LTS = osver.EndSupport_LTS;
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
        public static OSVersion GetVersion(int versionNumber)
        {
            VersionName version = (VersionName)Enum.ToObject(typeof(VersionName), versionNumber);
            return new OSVersion(version);
        }

        /// <summary>
        /// 指定したバージョンのOSVersionインスタンスの配列を取得
        /// </summary>
        /// <param name="versions"></param>
        /// <returns></returns>
        public static OSVersion[] GetVersion(int[] versions)
        {
            return versions.
                Select(x => new OSVersion((VersionName)Enum.ToObject(typeof(VersionName), x))).
                ToArray();
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
        public static bool operator <(OSVersion x, int y) { return (int)x.Version < y; }
        public static bool operator <(int x, OSVersion y) { return x < (int)y.Version; }

        /// <summary>
        /// 比較演算子 > 大なり
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator >(OSVersion x, OSVersion y) { return x.Version > y.Version; }
        public static bool operator >(OSVersion x, int y) { return (int)x.Version > y; }
        public static bool operator >(int x, OSVersion y) { return x > (int)y.Version; }

        /// <summary>
        /// 比較演算子 <= 小なりイコール
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator <=(OSVersion x, OSVersion y) { return x.Version <= y.Version; }
        public static bool operator <=(OSVersion x, int y) { return (int)x.Version <= y; }
        public static bool operator <=(int x, OSVersion y) { return x <= (int)y.Version; }

        /// <summary>
        /// 比較演算子 >= 大なりイコール
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator >=(OSVersion x, OSVersion y) { return x.Version >= y.Version; }
        public static bool operator >=(OSVersion x, int y) { return (int)x.Version >= y; }
        public static bool operator >=(int x, OSVersion y) { return x >= (int)y.Version; }

        /// <summary>
        /// 比較演算子 ==
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator ==(OSVersion x, OSVersion y) { return x.Version == y.Version; }
        public static bool operator ==(OSVersion x, int y) { return (int)x.Version == y; }
        public static bool operator ==(int x, OSVersion y) { return x == (int)y.Version; }

        /// <summary>
        /// 比較演算子 !=
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public static bool operator !=(OSVersion x, OSVersion y) { return x.Version != y.Version; }
        public static bool operator !=(OSVersion x, int y) { return (int)x.Version != y; }
        public static bool operator !=(int x, OSVersion y) { return x != (int)y.Version; }

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
                case int numInt:
                    return (int)this.Version == numInt;
                case long numLong:
                    return (int)this.Version == numLong;
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

    public class v1507 : OSVersion
    {
        public override VersionName Version { get { return VersionName.v1507; } }
        public override string Name { get { return "1507"; } }
        public override string Alias { get { return "Released in July 2015"; } }
        public override string CodeName { get { return "Threshold 1 "; } }
        public override string BuildNumber { get { return "10240"; } }
        public override string FullVersion { get { return "10.0.10240"; } }
        public override DateTime ReleaseDate { get { return new DateTime(2015, 7, 29); } }
        public override DateTime EndSupport_HomePro { get { return new DateTime(2017, 5, 9); } }
        public override DateTime EndSupport_EntEdu { get { return new DateTime(2017, 5, 9); } }
        public override DateTime? EndSupport_LTS { get { return new DateTime(2025, 10, 14); } }
    }

    public class v1511 : OSVersion
    {
        public override VersionName Version { get { return VersionName.v1511; } }
        public override string Name { get { return "1511"; } }
        public override string Alias { get { return "November Update"; } }
        public override string CodeName { get { return " 	Threshold 2 "; } }
        public override string BuildNumber { get { return "10586"; } }
        public override string FullVersion { get { return "10.0.10586"; } }
        public override DateTime ReleaseDate { get { return new DateTime(2015, 11, 10); } }
        public override DateTime EndSupport_HomePro { get { return new DateTime(2017, 10, 10); } }
        public override DateTime EndSupport_EntEdu { get { return new DateTime(2018, 4, 10); } }
        public override DateTime? EndSupport_LTS { get { return null; } }
    }

    public class v1607 : OSVersion
    {
        public override VersionName Version { get { return VersionName.v1607; } }
        public override string Name { get { return "1607"; } }
        public override string Alias { get { return "Anniversary Update"; } }
        public override string CodeName { get { return "Redstone 1 "; } }
        public override string BuildNumber { get { return "14393"; } }
        public override string FullVersion { get { return "10.0.14393"; } }
        public override DateTime ReleaseDate { get { return new DateTime(2016, 8, 2); } }
        public override DateTime EndSupport_HomePro { get { return new DateTime(2018, 4, 10); } }
        public override DateTime EndSupport_EntEdu { get { return new DateTime(2019, 4, 9); } }
        public override DateTime? EndSupport_LTS { get { return new DateTime(2026, 10, 13); } }
    }

    public class v1703 : OSVersion
    {
        public override VersionName Version { get { return VersionName.v1703; } }
        public override string Name { get { return "1703"; } }
        public override string Alias { get { return "Creators Update"; } }
        public override string CodeName { get { return "Redstone 2"; } }
        public override string BuildNumber { get { return "15063"; } }
        public override string FullVersion { get { return "10.0.15063"; } }
        public override DateTime ReleaseDate { get { return new DateTime(2017, 4, 5); } }
        public override DateTime EndSupport_HomePro { get { return new DateTime(2018, 10, 9); } }
        public override DateTime EndSupport_EntEdu { get { return new DateTime(2019, 10, 8); } }
        public override DateTime? EndSupport_LTS { get { return null; } }
    }

    public class v1709 : OSVersion
    {
        public override VersionName Version { get { return VersionName.v1709; } }
        public override string Name { get { return "1709"; } }
        public override string Alias { get { return "Fall Creators Update"; } }
        public override string CodeName { get { return " 	Redstone 3 "; } }
        public override string BuildNumber { get { return "16299"; } }
        public override string FullVersion { get { return "10.0.16299"; } }
        public override DateTime ReleaseDate { get { return new DateTime(2017, 10, 17); } }
        public override DateTime EndSupport_HomePro { get { return new DateTime(2019, 4, 9); } }
        public override DateTime EndSupport_EntEdu { get { return new DateTime(2020, 10, 13); } }
        public override DateTime? EndSupport_LTS { get { return null; } }
    }

    public class v1803 : OSVersion
    {
        public override VersionName Version { get { return VersionName.v1803; } }
        public override string Name { get { return "1803"; } }
        public override string Alias { get { return "April 2018 Update"; } }
        public override string CodeName { get { return "Redstone 4 "; } }
        public override string BuildNumber { get { return "17134"; } }
        public override string FullVersion { get { return "10.0.17134"; } }
        public override DateTime ReleaseDate { get { return new DateTime(2018, 4, 30); } }
        public override DateTime EndSupport_HomePro { get { return new DateTime(2019, 11, 12); } }
        public override DateTime EndSupport_EntEdu { get { return new DateTime(2021, 5, 11); } }
        public override DateTime? EndSupport_LTS { get { return null; } }
    }

    public class v1809 : OSVersion
    {
        public override VersionName Version { get { return VersionName.v1809; } }
        public override string Name { get { return "1809"; } }
        public override string Alias { get { return "October 2018 Update"; } }
        public override string CodeName { get { return "Redstone 5 "; } }
        public override string BuildNumber { get { return "17763"; } }
        public override string FullVersion { get { return "10.0.17763"; } }
        public override DateTime ReleaseDate { get { return new DateTime(2018, 11, 13); } }
        public override DateTime EndSupport_HomePro { get { return new DateTime(2020, 11, 10); } }
        public override DateTime EndSupport_EntEdu { get { return new DateTime(2021, 5, 11); } }
        public override DateTime? EndSupport_LTS { get { return new DateTime(2029, 1, 9); } }
    }

    public class v1903 : OSVersion
    {
        public override VersionName Version { get { return VersionName.v1903; } }
        public override string Name { get { return "1903"; } }
        public override string Alias { get { return "May 2019 Update"; } }
        public override string CodeName { get { return "19H1"; } }
        public override string BuildNumber { get { return "18362"; } }
        public override string FullVersion { get { return "10.0.18362"; } }
        public override DateTime ReleaseDate { get { return new DateTime(2019, 5, 21); } }
        public override DateTime EndSupport_HomePro { get { return new DateTime(2020, 12, 8); } }
        public override DateTime EndSupport_EntEdu { get { return new DateTime(2020, 12, 8); } }
        public override DateTime? EndSupport_LTS { get { return null; } }
    }

    public class v1909 : OSVersion
    {
        public override VersionName Version { get { return VersionName.v1909; } }
        public override string Name { get { return "1909"; } }
        public override string Alias { get { return "November 2019 Update"; } }
        public override string CodeName { get { return "19H2"; } }
        public override string BuildNumber { get { return "18636"; } }
        public override string FullVersion { get { return "10.0.18636"; } }
        public override DateTime ReleaseDate { get { return new DateTime(2019, 11, 12); } }
        public override DateTime EndSupport_HomePro { get { return new DateTime(2021, 5, 11); } }
        public override DateTime EndSupport_EntEdu { get { return new DateTime(2022, 5, 10); } }
        public override DateTime? EndSupport_LTS { get { return null; } }
    }

    public class v2004 : OSVersion
    {
        public override VersionName Version { get { return VersionName.v2004; } }
        public override string Name { get { return "2004"; } }
        public override string Alias { get { return "May 2020 Update"; } }
        public override string CodeName { get { return "20H1"; } }
        public override string BuildNumber { get { return "19041"; } }
        public override string FullVersion { get { return "10.0.19041"; } }
        public override DateTime ReleaseDate { get { return new DateTime(2020, 5, 27); } }
        public override DateTime EndSupport_HomePro { get { return new DateTime(2021, 12, 14); } }
        public override DateTime EndSupport_EntEdu { get { return new DateTime(2021, 12, 14); } }
        public override DateTime? EndSupport_LTS { get { return null; } }
    }

    public class v20H2 : OSVersion
    {
        public override VersionName Version { get { return VersionName.v20H2; } }
        public override string Name { get { return "20H2"; } }
        public override string Alias { get { return "October 2020 Update"; } }
        public override string CodeName { get { return "20H2"; } }
        public override string BuildNumber { get { return "19042"; } }
        public override string FullVersion { get { return "10.0.19042"; } }
        public override DateTime ReleaseDate { get { return new DateTime(2020, 10, 20); } }
        public override DateTime EndSupport_HomePro { get { return new DateTime(2022, 5, 10); } }
        public override DateTime EndSupport_EntEdu { get { return new DateTime(2023, 5, 9); } }
        public override DateTime? EndSupport_LTS { get { return null; } }
    }

    public class v21H1 : OSVersion
    {
        public override VersionName Version { get { return VersionName.v21H1; } }
        public override string Name { get { return "21H1"; } }
        public override string Alias { get { return "May 2021 Update"; } }
        public override string CodeName { get { return "21H1"; } }
        public override string BuildNumber { get { return "19043"; } }
        public override string FullVersion { get { return "10.0.19043"; } }
        public override DateTime ReleaseDate { get { return new DateTime(2021, 5, 18); } }
        public override DateTime EndSupport_HomePro { get { return new DateTime(2022, 12, 13); } }
        public override DateTime EndSupport_EntEdu { get { return new DateTime(2022, 12, 13); } }
        public override DateTime? EndSupport_LTS { get { return null; } }
    }
}
