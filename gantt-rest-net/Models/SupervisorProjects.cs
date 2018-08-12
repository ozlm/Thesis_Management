using gantt_rest_net.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace gantt_rest_net.Models
{
    public class SupervisorProjects:Inheritance
    {
        public SupervisorProjects()
        {
            base.db = new Data.Entities7();

        }

        public List<Data.supListProject_Result> All()
        {

          //  AccountController c = new AccountController();
        //    var supID = Session["supID"];

            return db.supListProject(1).ToList();
        }



    }
}