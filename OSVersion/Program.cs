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

            OSVersion os1511 = new OSVersion(1511);
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

            var versions = OSVersion.GetVersion(
                new string[] { "1507, 1607, 1809", "1803", "1909", "" }
                ).Select(x => x.ToString()).ToArray();
            Console.WriteLine(string.Join("=", versions));

            Console.ReadLine();
        }
    }
}
