using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeTracker.BLL;
using TimeTracker.Utlities;

namespace TimeTracker.Views
{
    public class JobListViewItem
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

        public string ElapsedTime { get; set; }


        public static void FillViewFromJobItem(JobListViewItem views, JobItem item)
        {
            views.JobItemId = item.JobItemId;
            views.StartDate = item.StartDate;
            views.EndDate = item.EndDate;
            views.BillTo = item.BillTo;
            views.Description = item.Description;
            views.RequestedBy = item.RequestedBy;
            views.RequestorId = item.RequestorId;
            views.Time = item.Time;
            views.EstimateId = item.EstimateId;
            views.DeveloperCode = item.DeveloperCode;
            views.CustomerId = item.CustomerId;
            views.DeveloperId = item.DeveloperId;
            views.TimingIsActive = item.JobTimings.Any(x => x.IsRunning);
            views.ElapsedTime = item.GetActiveEllapsedTime().RemoveMilliSeconds().ToString();
        }

        public static JobListViewItem CreateViewFromJobItem(JobItem item)
        {
            var newItem = new JobListViewItem
            {
                JobItemId = item.JobItemId,
                StartDate = item.StartDate,
                EndDate = item.EndDate,
                BillTo = item.BillTo,
                Description = item.Description,
                RequestedBy = item.RequestedBy,
                RequestorId = item.RequestorId,
                Time = item.Time,
                EstimateId = item.EstimateId,
                DeveloperCode = item.DeveloperCode,
                CustomerId = item.CustomerId,
                DeveloperId = item.DeveloperId,
                TimingIsActive = item.JobTimings.Any(x => x.IsRunning),
                ElapsedTime = item.GetActiveEllapsedTime().RemoveMilliSeconds().ToString()
            };



            return newItem;

        }

    }
}
