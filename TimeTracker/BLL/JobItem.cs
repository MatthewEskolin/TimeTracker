using System;
using System.Collections.Generic;

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



    }
}
