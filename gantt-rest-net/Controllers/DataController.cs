using gantt_rest_net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace gantt_rest_net.Controllers
{
    public class DataController : ApiController
    {
        private string _dateFormat = "yyyy-MM-dd HH:mm";
        private GanttContext db = new GanttContext();

        Models.Inheritance inh = new Models.Inheritance();

        SupervisorController sup = new SupervisorController();
       

        [HttpGet]
        public IHttpActionResult Get()
        {short grID = 0;
            var events = new List<object>();
            grID = sup.grID();
        
         
            foreach(var itemm in inh.db.groupTaskk){
                if (itemm.groupID == grID)
                {
                    foreach (var item in db.Tasks)
                    {

                        if (itemm.taskID == item.id)
                        {
                            events.Add(new
                            {
                                id = item.id,
                                text = item.text,
                                start_date = item.start_date.ToString(_dateFormat),
                                duration = item.duration,
                                progress = item.progress,
                                parent = item.parent
                            });
                        }                       
                    }


                }
            }
            
            //foreach (var item in db.Tasks)
            //{
            //    //if (item.id==)
            //    //{

            //    //}
            //    events.Add(new
            //    {
            //        id = item.id,
            //        text = item.text,
            //        start_date = item.start_date.ToString(_dateFormat),
            //        duration = item.duration,
            //        progress = item.progress,
            //        parent = item.parent
            //    });
            //}

            return Json(new { data = events, links = db.Links });
        }
    }
}