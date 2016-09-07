using System;
using System.Collections.Generic;
using TimeTracker.DAL;

namespace TimeTracker.BLL
{
    public class JobItem
    {

        public List<JobTiming> JobTimings { get; set; }

        public int JobItemId { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string BillTo { get; set; }
        public string Description { get; set; }
        public string RequestedBy { get; set; }
        public Nullable<long> Time { get; set; }
        public Nullable<int> EstimateId { get; set; }
        public string DeveloperCode { get; set; }
        public int CustomerId { get; set; }
    }
    public class JobTiming
    {
        public int JobTimingId { get; set; }
        public int JobItemId { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int DeveloperId { get; set; }


        public static JobTiming StartNewTiming(int jobItemId, int developerId)
        {
            var newTiming = _DAL.CreateNewJobTiming(jobItemId, developerId);
            var newJobTiming = new JobTiming()
            {
                DeveloperId = newTiming.DeveloperId,
                JobTimingId = newTiming.JobTimingId,
                JobItemId = newTiming.JobItemId
            };

            newJobTiming.Start();

            return newJobTiming;
        }

        public void Start()
        {
            StartTime = DateTime.Now;

            throw new NotImplementedException();
        }

        public void Stop()
        {

        }
    }


    
}
