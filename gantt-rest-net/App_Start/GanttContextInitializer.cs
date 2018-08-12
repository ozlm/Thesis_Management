using gantt_rest_net.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace gantt_rest_net.App_Start
{
    public class GanttContextInitializer : DropCreateDatabaseIfModelChanges<GanttContext>
    {
        protected override void Seed(GanttContext context)
        {
            context.Tasks.AddRange(new List<Task>
            {
                new Task { id = 1, text = "Test Event 1",
                    start_date = new DateTime(2016, 5, 26), duration = 4 },
                new Task { id = 2, text = "Test Event 2",
                    start_date = new DateTime(2016, 5, 25), duration = 6 },
                new Task { id = 3, text = "Test Event 3",
                    start_date = new DateTime(2016, 5, 27), duration = 8 },
                new Task { id = 4, text = "Test Event 4",
                    start_date = new DateTime(2016, 5, 31), duration = 2 },
                new Task { id = 5, text = "Test Event 5",
                    start_date = new DateTime(2016, 5, 26), duration = 7 },
            });

            context.Links.AddRange(new List<Link>
            {
                new Link { id = 1, source = 1, target = 4, type = "0" },
                new Link { id = 2, source = 3, target = 4, type = "1" },
            });
        }
    }
}