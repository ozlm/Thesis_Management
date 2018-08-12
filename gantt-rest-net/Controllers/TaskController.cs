using gantt_rest_net.Helpers;
using gantt_rest_net.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using gantt_rest_net.Controllers;
using System.Web;


namespace gantt_rest_net.Controllers
{
    public class TaskController : ApiController
    {
        private GanttContext db = new GanttContext();


        SupervisorController sup = new SupervisorController();

        [HttpPost]
        public IHttpActionResult Post(Task task)
        {
            short grID = 0;
            HttpContext context = HttpContext.Current;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Tasks.Add(task);
                    db.SaveChanges();
                    grID = sup.grID();
                    sup.groupTaskAdd(grID, task.id);
                 
                    return Json(GanttResponseHelper.GetResult("inserted", task.id));
                }               
            }
            catch (Exception) { }
            
            return Json(GanttResponseHelper.GetResult("error", null));
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var task = db.Tasks.Find(id);
                db.Tasks.Remove(task);
                db.SaveChanges();
                return Json(GanttResponseHelper.GetResult("deleted", null));
            }
            catch (Exception) { }
            return Json(GanttResponseHelper.GetResult("error", null));
        }

        [HttpPut]
        public IHttpActionResult Put(int id, Task task)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    task.id = id;
                    db.Entry(task).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(GanttResponseHelper.GetResult("updated", null));
                }
            }
            catch (Exception) { }
            return Json(GanttResponseHelper.GetResult("error", null));
        }
    }
}