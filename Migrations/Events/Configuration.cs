namespace ZenithSociety.Migrations.Events
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ZenithSocietyLib.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ZenithSocietyLib.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Migrations\Events";
        }

        protected override void Seed(ZenithSocietyLib.Models.ApplicationDbContext context)
        {
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Admin" };

                manager.Create(role);
            }

            if (!context.Roles.Any(r => r.Name == "Member"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "Member" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "a"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "a", Email = "a@a.a" };

                manager.Create(user, "P@$$w0rd");
                manager.AddToRole(user.Id, "Admin");
            }

            if (!context.Users.Any(u => u.UserName == "m"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "m", Email = "m@m.m" };

                manager.Create(user, "P@$$w0rd");
                manager.AddToRole(user.Id, "Member");
            }
            context.Activities.AddOrUpdate(a => a.ActivityId, getActivities());
            context.SaveChanges();
            context.Events.AddOrUpdate(e => e.EventId, getEvents(context));
            context.SaveChanges();
        }

        private Events[] getEvents(ApplicationDbContext context)
        {
            List<Events> events = new List<Events>
            {
                new Events() {StartDate = new DateTime(2017,4,4), StartTime = new TimeSpan(8, 30, 0),
                             EndTime =  new TimeSpan(10, 30, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Senior's  Golf Tournament").ActivityId },

                new Events() {StartDate = new DateTime(2017,4,5), StartTime = new TimeSpan(8, 30, 0),
                             EndTime =  new TimeSpan(10, 30, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Leadership General Assembly Meeting").ActivityId },

                new Events() {StartDate = new DateTime(2017,4,7), StartTime = new TimeSpan(5, 30, 0),
                             EndTime =  new TimeSpan(7, 15, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Youth Bowling Tournament").ActivityId },

                new Events() {StartDate = new DateTime(2017,4,7), StartTime = new TimeSpan(7, 0, 0),
                             EndTime =  new TimeSpan(8, 0, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Young ladies cooking lessons").ActivityId },

                new Events() {StartDate = new DateTime(2017,4,8), StartTime = new TimeSpan(8, 30, 0),
                             EndTime =  new TimeSpan(10, 30, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Youth craft lessons").ActivityId },

                new Events() {StartDate = new DateTime(2017,4,8), StartTime = new TimeSpan(10, 30, 0),
                             EndTime =  new TimeSpan(12, 0, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Youth choir practice").ActivityId },

                new Events() {StartDate = new DateTime(2017,4,8), StartTime = new TimeSpan(12, 0, 0),
                             EndTime =  new TimeSpan(13, 30, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Lunch").ActivityId },

                new Events() {StartDate = new DateTime(2017,4,9), StartTime = new TimeSpan(7, 30, 0),
                             EndTime =  new TimeSpan(8, 30, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Pancake Breakfast").ActivityId },

                new Events() {StartDate = new DateTime(2017,4,9), StartTime = new TimeSpan(8, 30, 0),
                             EndTime =  new TimeSpan(10, 30, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Swimming Lessons for the youth").ActivityId },

                new Events() {StartDate = new DateTime(2017,4,9), StartTime = new TimeSpan(8, 30, 0),
                             EndTime =  new TimeSpan(10, 30, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Swimming Exercise for parents").ActivityId },

                new Events() {StartDate = new DateTime(2017,4,9), StartTime = new TimeSpan(10, 30, 0),
                             EndTime =  new TimeSpan(12, 0, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Bingo Tournament").ActivityId },

                new Events() {StartDate = new DateTime(2017,4,9), StartTime = new TimeSpan(12, 0, 0),
                             EndTime =  new TimeSpan(13, 0, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "BBQ Lunch").ActivityId },

                new Events() {StartDate = new DateTime(2017,4,9), StartTime = new TimeSpan(13, 0, 0),
                             EndTime =  new TimeSpan(18, 0, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Garage Sale").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,6), StartTime = new TimeSpan(8, 30, 0),
                             EndTime =  new TimeSpan(10, 30, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Senior's  Golf Tournament").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,7), StartTime = new TimeSpan(8, 30, 0),
                             EndTime =  new TimeSpan(10, 30, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Leadership General Assembly Meeting").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,8), StartTime = new TimeSpan(5, 30, 0),
                             EndTime =  new TimeSpan(7, 15, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Youth Bowling Tournament").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,8), StartTime = new TimeSpan(7, 0, 0),
                             EndTime =  new TimeSpan(8, 0, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Young ladies cooking lessons").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,9), StartTime = new TimeSpan(8, 30, 0),
                             EndTime =  new TimeSpan(10, 30, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Youth craft lessons").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,9), StartTime = new TimeSpan(10, 30, 0),
                             EndTime =  new TimeSpan(12, 0, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Youth choir practice").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,9), StartTime = new TimeSpan(12, 0, 0),
                             EndTime =  new TimeSpan(13, 30, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Lunch").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,10), StartTime = new TimeSpan(7, 30, 0),
                             EndTime =  new TimeSpan(8, 30, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Pancake Breakfast").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,10), StartTime = new TimeSpan(8, 30, 0),
                             EndTime =  new TimeSpan(10, 30, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Swimming Lessons for the youth").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,10), StartTime = new TimeSpan(8, 30, 0),
                             EndTime =  new TimeSpan(10, 30, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Swimming Exercise for parents").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,10), StartTime = new TimeSpan(10, 30, 0),
                             EndTime =  new TimeSpan(12, 0, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Bingo Tournament").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,10), StartTime = new TimeSpan(12, 0, 0),
                             EndTime =  new TimeSpan(13, 0, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "BBQ Lunch").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,10), StartTime = new TimeSpan(13, 0, 0),
                             EndTime =  new TimeSpan(18, 0, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Garage Sale").ActivityId },



                new Events() {StartDate = new DateTime(2017,2,13, 8, 30, 0), StartTime = new TimeSpan(8, 30, 0),
                             EndTime =  new TimeSpan(10, 30, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Senior's  Golf Tournament").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,14), StartTime = new TimeSpan(8, 30, 0),
                             EndTime =  new TimeSpan(10, 30, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Leadership General Assembly Meeting").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,15), StartTime = new TimeSpan(5, 30, 0),
                             EndTime =  new TimeSpan(7, 15, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Youth Bowling Tournament").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,15), StartTime = new TimeSpan(7, 0, 0),
                             EndTime =  new TimeSpan(8, 0, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Young ladies cooking lessons").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,15), StartTime = new TimeSpan(8, 30, 0),
                             EndTime =  new TimeSpan(10, 30, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Youth craft lessons").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,15), StartTime = new TimeSpan(10, 30, 0),
                             EndTime =  new TimeSpan(12, 0, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Youth choir practice").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,15), StartTime = new TimeSpan(12, 0, 0),
                             EndTime =  new TimeSpan(13, 30, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Lunch").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,16), StartTime = new TimeSpan(7, 30, 0),
                             EndTime =  new TimeSpan(8, 30, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Pancake Breakfast").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,16), StartTime = new TimeSpan(8, 30, 0),
                             EndTime =  new TimeSpan(10, 30, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Swimming Lessons for the youth").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,17), StartTime = new TimeSpan(8, 30, 0),
                             EndTime =  new TimeSpan(10, 30, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Swimming Exercise for parents").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,17), StartTime = new TimeSpan(10, 30, 0),
                             EndTime =  new TimeSpan(12, 0, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Bingo Tournament").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,17), StartTime = new TimeSpan(12, 0, 0),
                             EndTime =  new TimeSpan(13, 0, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "BBQ Lunch").ActivityId },

                new Events() {StartDate = new DateTime(2017,2,17), StartTime = new TimeSpan(13, 0, 0),
                             EndTime =  new TimeSpan(18, 0, 0), UserName = "a",
                             CreationDate = DateTime.Now, isActive = true,
                             ActivityId = context.Activities.FirstOrDefault(e => e.ActivityDescription == "Garage Sale").ActivityId }
            };
            return events.ToArray();
        }

        private Activities[] getActivities()
        {
            var activities = new List<Activities>()
            {
                new Activities() { ActivityDescription = "Senior's  Golf Tournament", CreationDate = DateTime.Now },
                new Activities() { ActivityDescription = "Leadership General Assembly Meeting", CreationDate = DateTime.Now },
                new Activities() { ActivityDescription = "Youth Bowling Tournament", CreationDate = DateTime.Now },
                new Activities() { ActivityDescription = "Young ladies cooking lessons", CreationDate = DateTime.Now },
                new Activities() { ActivityDescription = "Youth craft lessons", CreationDate = DateTime.Now },
                new Activities() { ActivityDescription = "Youth choir practice", CreationDate = DateTime.Now },
                new Activities() { ActivityDescription = "Lunch", CreationDate = DateTime.Now },
                new Activities() { ActivityDescription = "Pancake Breakfast", CreationDate = DateTime.Now },
                new Activities() { ActivityDescription = "Swimming Lessons for the youth", CreationDate = DateTime.Now },
                new Activities() { ActivityDescription = "Swimming Exercise for parents", CreationDate = DateTime.Now },
                new Activities() { ActivityDescription = "Bingo Tournament", CreationDate = DateTime.Now },
                new Activities() { ActivityDescription = "BBQ Lunch", CreationDate = DateTime.Now },
                new Activities() { ActivityDescription = "Garage Sale", CreationDate = DateTime.Now }
            };
            return activities.ToArray();

        }
    }
}
