using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using gantt_rest_net.Data;
using System.Linq.Expressions;
using gantt_rest_net.Models;
using gantt_rest_net.Controllers;

namespace gantt_rest_net.Controllers
{
    public class SupervisorController : Controller
    {
        
       public static short groupId;
        
        public ActionResult Announcement()
        {
            return View();
        }


        public ActionResult ViewReports()
        {           
           Inheritance inh = new Inheritance();
           var supID = Session["supID"];
           var result = inh.db.supListProject(Convert.ToInt16(supID)).ToList();
         
            return View(result);
        }

        public ActionResult Index(short Id)
        {
            groupId = Id;
            Session["grId"] = Id;
            return View();
        }

        public short grID()
        {
            short asd = 0;
            asd = groupId;
            return asd;
        }



        public ActionResult groupTaskAdd(short grId,int taskId)
        {
            var result = new Models.AddGroupTask().New(grId, taskId);

             if (result)
             {
                 return RedirectToAction("Index", "Supervisor");
             }
             return View();
        }

    }
}