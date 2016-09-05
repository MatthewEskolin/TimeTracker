using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TimeTracker.BLL;

namespace TimeTracker.DAL
{
    public static class _DAL
    {

        public static List<JobItem> GetDailyItems()
        {
            var ctx = new TimeTrackerEntities();
            List<JobItem> rtn = ctx.DJobItems.Where(x => DbFunctions.TruncateTime(x.StartDate.Value) >= DbFunctions.TruncateTime(DateTime.Now)).ToList().Select(x => new JobItem()
            {
            }).ToList();
            return rtn;
        }

        public static List<DCustomer> GetCustomers()
        {
            var ctx = new TimeTrackerEntities();
            return ctx.DCustomers.OrderBy(x => x.CustomerName).ToList();
        }

        public static DDeveloper getDeveloperById(int devId)
        {
            var ctx = new TimeTrackerEntities();
            return ctx.DDevelopers.FirstOrDefault(x => x.DeveloperId == devId);
        }

        public static List<DRequestor> GetRequestors()
        {
            var ctx = new TimeTrackerEntities();
            return ctx.DRequestors.OrderBy(x => x.RequestorName).ToList();
        }
    }
}