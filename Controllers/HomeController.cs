using System.Linq;
using System.Web.Mvc;
using ZenithSocietyLib.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System;

namespace ZenithSociety.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            var events = db.Events.Include(e => e.Activity)
                                  .OrderBy(e => e.StartDate)
                                  .ToList();
            var weekEvents = new List<Events>();
            var result = new List<List<Events>>();
            DateTime startOfWeek = DateTime.Today.AddDays(-1 * (int)(DateTime.Today.DayOfWeek)+1);
            int startDate = -1;
            for (int i=0; i < events.Count; i++)
            {
                // make sure database has this week data
                if(startOfWeek.CompareTo(events[i].StartDate) == 0 || startOfWeek.CompareTo(events[i].StartDate) < 0)
                {
                    startDate = i;
                    break;
                }
            }

            if(startDate != -1)
            {
                while(events[startDate].StartDate.CompareTo(startOfWeek.AddDays(7)) < 0)
                {
                    weekEvents.Add(events[startDate++]);
                }
            }

            for(int i = 0; i < weekEvents.Count; i++)
            {
                if(i != 0 && weekEvents[i-1].StartDate.CompareTo(weekEvents[i].StartDate) == 0)
                {
                    result[result.Count - 1].Add(weekEvents[i]);
                }
                else
                {
                    result.Add(new List<Events>() { weekEvents[i]});
                }

            }
            return View(result);
        }
    }
}