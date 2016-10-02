using System;
using System.Collections.Generic;
using System.Linq;
using TimeTracker.DAL;

namespace TimeTracker.BLL
{
    public class JobTiming
    {

        public int JobTimingId { get; set; }
        public int JobItemId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int DeveloperId { get; set; }

        private bool IsRunning { get; set; }

        public static JobTiming StartNewTiming(int jobItemId, int developerId)
        {

            var list = new List<int>();
            list.Where(x => x.Equals(1));
            var newTiming = _DAL.CreateNewJobTiming(jobItemId, developerId);
            var newJobTiming = new JobTiming()
            {
                DeveloperId = newTiming.DeveloperId,
                JobTimingId = newTiming.JobTimingId,
                JobItemId = newTiming.JobItemId,
                IsRunning = true
            };

            newJobTiming.Start();

            return newJobTiming;
        }


        private JobTiming(int itemId, int developerId)
        {
            JobItemId = itemId;
            DeveloperId = developerId;
        }

        public JobTiming()
        {
        }

        public void Start()
        {
            StartTime = DateTime.Now;

            var timing = new DJobTiming()
            {
                DeveloperId = this.DeveloperId
            };

            var ctx = new TimeTrackerEntities();
            ctx.DJobTimings.Add(timing);
            ctx.SaveChanges();

        }

        public void Stop()
        {

        }
    }
}