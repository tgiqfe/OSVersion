﻿using System;
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
        public string Description { get; set; }

        public static OSVersions[] GetVersions()
        {
            List<OSVersions> list = new List<OSVersions>();

            list.Add(new OSVersions()
            {
                Name = "1507",
                Candidate = new string[] { "1507", "v1507", "10.0.10240", "Released in July 2015", "ReleasedinJuly2015", "Threshold 1", "Threshold1" },
                Description = "Windows 10のリリース時バージョン"
            });
            list.Add(new OSVersions()
            {
                Name = "1511",
                Candidate = new string[] { "1511", "v1511" },
                Description = "Windows 10のリリース後の次のバージョン"
            });
            list.Add(new OSVersions()
            {
                Name = "1607",
                Candidate = new string[] { "1607", "v1607" },
                Description = ""
            });
            list.Add(new OSVersions()
            {
                Name = "1703",
                Candidate = new string[] { "1703", "v1703" },
                Description = ""
            });
            list.Add(new OSVersions()
            {
                Name = "1709",
                Candidate = new string[] { "1709", "v1709" },
                Description = ""
            });
            list.Add(new OSVersions()
            {
                Name = "1803",
                Candidate = new string[] { "1803", "v1803" },
                Description = ""
            });
            list.Add(new OSVersions()
            {
                Name = "1809",
                Candidate = new string[] { "1809", "v1809" },
                Description = ""
            });
            list.Add(new OSVersions()
            {
                Name = "1903",
                Candidate = new string[] { "1903", "v1903" },
                Description = ""
            });
            list.Add(new OSVersions()
            {
                Name = "2004",
                Candidate = new string[] { "2004", "v2004" },
                Description = ""
            });
            list.Add(new OSVersions()
            {
                Name = "20H2",
                Candidate = new string[] { "20H2", "v20H2" },
                Description = ""
            });
            list.Add(new OSVersions()
            {
                Name = "21H1",
                Candidate = new string[] { "21H1", "v21H1" },
                Description = ""
            });


            return null;
        }
    }
}