using System;
using System.Collections.Generic;
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

        public void SaveToDb()
        {
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
        }
    }
}
