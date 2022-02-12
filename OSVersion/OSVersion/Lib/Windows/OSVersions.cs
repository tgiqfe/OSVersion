using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSVersion.Lib.Windows
{
    internal class OSVersions
    {
        public string Name { get; set; }
        public string[] Candidate { get; set; }

        public static OSVersions[] GetVersions()
        {
            new OSVersions()
            {
                Name = "1507",
                Candidate = new string[]
                {
                    "1507", "10.0.10240", "Released in July 2015", "ReleasedinJuly2015", "Threshold 1", "Threshold1"
                }
            };


            return null;
        }
    }
}
