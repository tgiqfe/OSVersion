using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSVersion
{
    class Program
    {
        static void Main(string[] args)
        {
            OSVersion thisPC = OSVersion.GetCurrent();

            Console.WriteLine(
                "Name: {0}\r\n" +
                "Version: {1}\r\n" +
                "Alias: {2}\r\n" +
                "BuildNumber: {3}\r\n" +
                "FullVersion: {4}\r\n" +
                "ReleaseDate: {5}\r\n" +
                "EndSupportDate_HomePro: {6}\r\n" +
                "EndSupportDate_EntEdu: {7}\r\n" +
                "EndSupportDate_LTS: {8}\r\n" +
                "Edition: {9}",
                    thisPC.Name, thisPC.Version, thisPC.Alias, thisPC.BuildNumber, thisPC.FullVersion,
                    thisPC.ReleaseDate, thisPC.EndSupport_HomePro, thisPC.EndSupport_EntEdu,
                    thisPC.EndSupport_LTS, thisPC.Edition);
            Console.WriteLine();

            OSVersion os1511 = new OSVersion(VersionName.v1511);
            if (thisPC > os1511)
            {
                Console.WriteLine("このPCは、バージョン1511より新しいです。");
            }
            if (thisPC > OSVersion.v1607)
            {
                Console.WriteLine("このPCは、バージョン1607より新しいです。");
            }
            if (thisPC != 1511)
            {
                Console.WriteLine("このPCは、バージョン1703ではありません。");
            }
            if (thisPC == OSVersion.GetVersion(1709))
            {
                Console.WriteLine("このPCは、バージョン1709です。");
            }
            if (thisPC < OSVersion.GetVersion(2010))
            {
                Console.WriteLine("このPCは、バージョン20H2より古いです。");
            }


            var versions = OSVersion.GetVersion(
                new string[] { "1507, 1607, 1809", "1803", "1909", "" }
                ).Select(x => x.ToString()).ToArray();
            Console.WriteLine(string.Join("|", versions));

            Console.ReadLine();
        }
    }
}
