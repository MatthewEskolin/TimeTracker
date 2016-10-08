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

        public bool IsRunning { get; set; }

        public static JobTiming NewJobTiming(int jobItemId, int developerId)
        {
            JobTiming newTiming = _DAL.CreateNewJobTiming(jobItemId, developerId);
            return newTiming;          
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
            var startTime = _DAL.StartTiming(JobTimingId);
            this.StartTime = startTime;
            this.IsRunning = true;

        }

        public void Stop()
        {

        }
    }
}