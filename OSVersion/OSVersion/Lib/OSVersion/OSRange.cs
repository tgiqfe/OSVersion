using OSVersion.Lib.OSVersion.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSVersion.Lib.OSVersion
{
    [System.Runtime.Versioning.SupportedOSPlatform("windows")]
    internal class WindowsOSRange
    {
        private List<WindowsOS> StartA { get; set; }
        private List<WindowsOS> EndA { get; set; }
        private List<WindowsOS> StartB { get; set; }
        private List<WindowsOS> EndB { get; set; }

        public void Within<T>(OSCollection<T> collection, WindowsOS current, string groupA, string groupB)
        {
            string tempStartA = groupA.Substring(0, groupA.IndexOf("~"));
            string tempEndA = groupA.Substring(groupA.IndexOf("~") + 1);
            string tempStartB = groupB.Substring(0, groupB.IndexOf("~"));
            string tempEndB = groupB.Substring(groupB.IndexOf("~") + 1);

            /*
            if (!string.IsNullOrEmpty(tempStartA)) StartA = collection.GetMatchOS(tempStartA);
            if (!string.IsNullOrEmpty(tempEndA)) EndB = collection.GetMatchOS(tempEndA);
            if (!string.IsNullOrEmpty(tempStartB)) StartB = collection.GetMatchOS(tempStartB);
            if (!string.IsNullOrEmpty(tempEndB)) EndB = collection.GetMatchOS(tempEndB);
            */



        }
    }
}
