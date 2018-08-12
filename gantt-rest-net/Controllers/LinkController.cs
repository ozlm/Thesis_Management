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

namespace gantt_rest_net.Controllers
{
    public class LinkController : ApiController
    {
        private GanttContext db = new GanttContext();

        [HttpPost]
        public IHttpActionResult Post(Link link)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Links.Add(link);
                    db.SaveChanges();
                    return Json(GanttResponseHelper.GetResult("inserted", link.id));
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
                var link = db.Links.Find(id);
                db.Links.Remove(link);
                db.SaveChanges();
                return Json(GanttResponseHelper.GetResult("deleted", null));
            }
            catch (Exception) { }
            return Json(GanttResponseHelper.GetResult("error", null));
        }

        [HttpPut]
        public IHttpActionResult Put(int id, Link link)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    link.id = id;
                    db.Entry(link).State = EntityState.Modified;
                    db.SaveChanges();
                    return Json(GanttResponseHelper.GetResult("updated", null));
                }
            }
            catch (Exception) { }
            return Json(GanttResponseHelper.GetResult("error", null));
        }
    }
}