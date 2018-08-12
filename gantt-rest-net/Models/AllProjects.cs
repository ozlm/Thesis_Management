using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gantt_rest_net.Models
{
    public class AllProjects:Inheritance
    {
        public AllProjects()
        {
            base.db = new Data.Entities7();

        }
        public List<Data.listedProject_Result> All()
        {
            return db.listedProject().ToList();

        }
    }
}