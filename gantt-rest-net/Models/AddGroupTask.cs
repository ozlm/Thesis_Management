using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gantt_rest_net.Models
{
    public class AddGroupTask : Inheritance
    {
        public AddGroupTask()
        {
            base.db = new Data.Entities7();
        }

        public bool New(short a,int b)
        {
            try
            {                
                db.addGroupTask(a,b);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

    }

}