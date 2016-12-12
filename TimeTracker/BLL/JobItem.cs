using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using TimeTracker.DAL;
namespace TimeTracker.BLL
{
    public class JobItem
    {

        public List<JobTiming> JobTimings { get; set; }

        public int JobItemId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string BillTo { get; set; }
        public string Description { get; set; }
        public string RequestedBy { get; set; }
        public int? RequestorId { get; set; }
        public long? Time { get; set; }
        public int? EstimateId { get; set; }
        public string DeveloperCode { get; set; }
        public int CustomerId { get; set; }
        public int DeveloperId { get; set; }

        public JobItem()
        {
            JobTimings = new List<JobTiming>();
        }

        public void SaveToDb()
        {
            StartDate = DateTime.Now;

            var item = new DJobItem
            {
                StartDate = this.StartDate,
                CustomerId = this.CustomerId,
                RequestorId = this.RequestorId,
                Description = this.Description,
                EstimateId = this.EstimateId,
                DeveloperId = this.DeveloperId,
            };

            var ctx = new TimeTrackerEntities();
            ctx.DJobItems.Add(item);
            ctx.SaveChanges();

            JobItemId = item.JobItemId;
        }

        public static JobItem NewJobItem(DateTime startDate, int custId, int requestId, string desc, int? estimateId, int devId)
        {
            var newItem = new JobItem()
            {
                StartDate = startDate,
                CustomerId = custId,
                RequestorId = requestId,
                Description = desc,
                EstimateId = estimateId,
                DeveloperId = devId
                
            };
            newItem.SaveToDb();
            
            
            return newItem;
        }

        public void CreateNewTiming()
        {
            JobTiming newTiming = JobTiming.NewJobTiming(JobItemId, DeveloperId);
            newTiming.Start();
            JobTimings.Add(newTiming);
        }

        public void StartActiveTimer()
        {
            var activeTiming = JobTimings.FirstOrDefault(x => x.IsRunning);
            activeTiming?.StartTimers();
        }

        public TimeSpan GetActiveEllapsedTime()
        {
            JobTiming activeTiming = JobTimings.FirstOrDefault(x => x.IsRunning);
            return activeTiming.GetEllapsedTime();
        }
    }
}
