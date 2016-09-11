﻿using System;
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

            var jobsWithTimingToday = ctx.DJobItems
                .Include(x => x.DCustomer)
                .Include(x => x.DRequestor)
                .Include(x => x.DDeveloper)
                .Where(x => x.DJobTimings.Any( y => DbFunctions.TruncateTime(y.StartTime.Value) == DbFunctions.TruncateTime(DateTime.Now)) || DbFunctions.TruncateTime(x.StartDate) == DbFunctions.TruncateTime(DateTime.Now)); 
            IQueryable<DJobItem> jobItemsToday = (from jobItems in jobsWithTimingToday select jobItems);

            var result = jobItemsToday.Select(x => new JobItem()
            {
                JobItemId = x.JobItemId,
                JobTimings = x.DJobTimings.Select(y => new JobTiming()).ToList(),
                Description = x.Description,
                BillTo = x.DRequestor.RequestorName,
                CustomerId = (int)x.CustomerId,
                DeveloperCode = x.DDeveloper.DeveloperShortName,
                RequestedBy = x.DRequestor.RequestorName
                
            }).ToList();

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

        public static DJobTiming CreateNewJobTiming(int jobItemId, int developerId)
        {
            var ctx = new TimeTrackerEntities();
            var newTiming = new DJobTiming();

            newTiming.JobItemId = jobItemId;
            newTiming.DeveloperId = developerId;
            ctx.DJobTimings.Add(newTiming);
            ctx.SaveChanges();
            return newTiming;

        }
    }
}