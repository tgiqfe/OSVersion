using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSVersion.Lib.OSVersion.Any;

namespace OSVersion.Lib.OSVersion.Windows
{
    internal class WindowsOSRange
    {
        public OSInfo[] Minimum { get; set; }
        public OSInfo[] Maximum { get; set; }
        public WindowsOSRange(OSCollection collection, string text)
        {
            string[] osWord = text.Contains("~") ?
                new[] { text.Substring(0, text.IndexOf("~")), text.Substring(text.IndexOf("~") + 1) } :
                new[] { text, text };
            this.Minimum = string.IsNullOrEmpty(osWord[0]) ?
                new OSInfo[] { AnyOS.CreateMinimum() } :
                collection.Where(x => x.IsMatch(osWord[0])).ToArray();
            this.Maximum = string.IsNullOrEmpty(osWord[1]) ?
                new OSInfo[] { AnyOS.CreateMaximum() } :
                collection.Where(x => x.IsMatch(osWord[1])).ToArray();
        }
        public bool Within(WindowsOS current)
        {
            bool minRet = Minimum.Where(x => x.OSFamily == OSFamily.Any || x.Name == current.Name).
                Any(x => x <= current);
            bool maxRet = Maximum.Where(x => x.OSFamily == OSFamily.Any || x.Name == current.Name).
                Any(x => x >= current);

            return minRet && maxRet;
        }
    }
}
