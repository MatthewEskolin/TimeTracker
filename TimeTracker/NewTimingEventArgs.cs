using System;

namespace TimeTracker
{
    public class NewTimingEventArgs:EventArgs
    {
        public int JobItemId { get; set; }
    }
}