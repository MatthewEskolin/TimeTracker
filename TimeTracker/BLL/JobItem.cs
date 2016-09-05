using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker.BLL
{
    public class JobItem
    {
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
}
