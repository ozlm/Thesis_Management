using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gantt_rest_net.Models
{
    public class QueryProject:Inheritance
    {
        public QueryProject()
        {
            base.db = new Data.Entities7();
        }
        public string NameQuery(int? id)
        {
            return db.supervisor.Find(id).supervisorName.ToString();

        }
    }
}