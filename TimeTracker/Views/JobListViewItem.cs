using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.BLL;

namespace TimeTracker.Views
{
    class JobListViewItem
    {
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

        //flattened from JobItem.
        public bool TimingIsActive { get; set; }


        public static JobListViewItem CreateViewFromJobItem(JobItem item)
        {
            var newItem = new JobListViewItem();
            newItem.JobItemId = item.JobItemId;
            newItem.StartDate = item.StartDate;
            newItem.EndDate = item.EndDate;
            newItem.BillTo = item.BillTo;
            newItem.Description = item.Description;
            newItem.RequestedBy = item.RequestedBy;
            newItem.RequestorId = item.RequestorId;
            newItem.Time = item.Time;
            newItem.EstimateId = item.EstimateId;
            newItem.DeveloperCode = item.DeveloperCode;
            newItem.CustomerId = item.CustomerId;
            newItem.DeveloperId = item.DeveloperId;
            newItem.TimingIsActive = item.JobTimings.Any(x => x.IsRunning);

            return newItem;

        }

    }
}
