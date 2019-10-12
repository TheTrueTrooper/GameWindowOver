using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameWindowOver
{
    class AppListComparer : IEqualityComparer<KeyValuePair<string, Process>>
    {
        public int GetHashCode(KeyValuePair<string, Process> co)
        {
            return 0;
        }

        public bool Equals(KeyValuePair<string, Process> x1, KeyValuePair<string, Process> x2)
        {
            return x1.Value.ProcessName == x2.Value.ProcessName && x1.Value.Id == x2.Value.Id;
        }
    }
}
