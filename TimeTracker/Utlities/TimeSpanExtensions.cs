using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.Utlities
{
    public static class TimeSpanExtensions
    {
        public static TimeSpan RemoveMilliSeconds(this TimeSpan source)
        {
            var rtn = new TimeSpan(source.Hours, source.Minutes, source.Seconds);
            return rtn;
        }
    }
}
