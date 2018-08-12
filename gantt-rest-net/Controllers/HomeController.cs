using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gantt_rest_net.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
     
        public ActionResult Index()
        {
            var result = new Models.AllProjects().All();
            
            return View(result);
        }

    }
}