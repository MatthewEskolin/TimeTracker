using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using log4net;
using TimeTracker.DAL;

namespace TimeTracker.BLL
{
    public class JobTiming
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(JobTiming));


        public int JobTimingId { get; set; }
        public int JobItemId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int DeveloperId { get; set; }


        private Stopwatch MyStopWatch { get; set; }


        public bool IsRunning { get; set; }

        public static JobTiming NewJobTiming(int jobItemId, int developerId)
        {
            JobTiming newTiming = _DAL.CreateNewJobTiming(jobItemId, developerId);
            return newTiming;          
        }

        public JobTiming()
        {
            MyStopWatch = new Stopwatch();
             logger.Debug("Caution: Using Default Developer ID.");
            DeveloperId = Properties.Settings.Default.Developer;

        }

        public void StartTimers()
        {
            if(IsRunning)MyStopWatch.Start();
        }

        public void Start()
        {
            var startTime = _DAL.StartTiming(JobTimingId);
            this.StartTime = startTime;
            this.IsRunning = true;
            MyStopWatch.Start();

        }

        public TimeSpan GetEllapsedTime()
        {
            return MyStopWatch.Elapsed;
        }

        public void Stop()
        {
            IsRunning = false;
            MyStopWatch.Stop();
            EndTime = DateTime.Now;

            var ctx = new TimeTrackerEntities();
            DJobTiming timing = ctx.DJobTimings.FirstOrDefault(x => x.JobTimingId == JobTimingId);
            timing.EndTime = EndTime;
            timing.IsRunning = false;
            ctx.SaveChanges();
        }
    }
}