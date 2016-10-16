using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using log4net;
using TimeTracker.BLL;

namespace TimeTracker.DAL
{
    public static class _DAL
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(_DAL));

        public static List<JobItem> GetDailyItems()
        {
            //test comment.//testing github connection
            var ctx = new TimeTrackerEntities();

            var jobsWithTimingToday = ctx.DJobItems
                .Include(x => x.DCustomer)
                .Include(x => x.DRequestor)
                .Include(x => x.DDeveloper)
                .Where(x => x.DJobTimings.Any( y => DbFunctions.TruncateTime(y.StartTime.Value) == DbFunctions.TruncateTime(DateTime.Now)) || DbFunctions.TruncateTime(x.StartDate) == DbFunctions.TruncateTime(DateTime.Now)); 
            IQueryable<DJobItem> jobItemsToday = (from jobItems in jobsWithTimingToday select jobItems);

            var result = jobItemsToday.Select(x => new JobItem()
            {
                JobItemId = x.JobItemId,
                JobTimings = x.DJobTimings.Select(y => new JobTiming()
                {
                    DeveloperId = y.DeveloperId,
                    EndTime = y.EndTime,
                    IsRunning  = y.IsRunning,
                    JobItemId = y.JobItemId,
                    JobTimingId = y.JobTimingId,
                    StartTime = y.StartTime
                }).ToList(),
                Description = x.Description,
                BillTo = x.DRequestor.RequestorName,
                CustomerId = (int)x.CustomerId,
                DeveloperCode = x.DDeveloper.DeveloperShortName,
                RequestedBy = x.DRequestor.RequestorName
                
            }).ToList();

            return result;
        }


        public static JobItem GetJobItem(int jobItemId)
        {
            var ctx = new TimeTrackerEntities();

            var jobItem = ctx.DJobItems
                .Include(x => x.DCustomer)
                .Include(x => x.DRequestor)
                .Include(x => x.DDeveloper)
                .Where(x => x.DJobTimings.Any(y => DbFunctions.TruncateTime(y.StartTime.Value) == DbFunctions.TruncateTime(DateTime.Now)) || DbFunctions.TruncateTime(x.StartDate) == DbFunctions.TruncateTime(DateTime.Now));
            IQueryable<DJobItem> jobItemsToday = (from jobItems in jobItem select jobItems);

            var result = jobItemsToday.Select(x => new JobItem()
            {
                JobItemId = x.JobItemId,
                JobTimings = x.DJobTimings.Select(y => new JobTiming()).ToList(),
                Description = x.Description,
                BillTo = x.DRequestor.RequestorName,
                CustomerId = (int) x.CustomerId,
                DeveloperCode = x.DDeveloper.DeveloperShortName,
                RequestedBy = x.DRequestor.RequestorName

            }).FirstOrDefault(x => x.JobItemId == jobItemId);

            if (result == null)
            {
                logger.Warn("attempted to get non-existent job item. returning null");
            }

            return result;
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

        public static JobTiming CreateNewJobTiming(int jobItemId, int developerId)
        {
            var ctx = new TimeTrackerEntities();
            var newTiming = new DJobTiming
            {
                JobItemId = jobItemId,
                DeveloperId = developerId,
            };

            ctx.DJobTimings.Add(newTiming);
            ctx.SaveChanges();

            JobTiming newJobTiming = new JobTiming()
            {
                DeveloperId = newTiming.DeveloperId,
                JobTimingId = newTiming.JobTimingId,
                JobItemId = newTiming.JobItemId,
                IsRunning = newTiming.IsRunning
            };

            return newJobTiming;

        }

        public static DateTime StartTiming(int jobTimingId)
        {
            var startTime = DateTime.Now;

            var ctx = new TimeTrackerEntities();
            var timing = ctx.DJobTimings.FirstOrDefault(x => x.JobTimingId == jobTimingId);
            if (timing != null)
            {
                timing.StartTime = startTime;
                timing.IsRunning = true; 
                ctx.SaveChanges();
                return startTime;
            }

            throw new Exception("Could not start Timing!");
        }

    }
}