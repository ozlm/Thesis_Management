using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gantt_rest_net.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult ListProjects()
        {
            var result = new Models.AllProjects().All();
            return View(result);
        }

        public ActionResult AddProject()
        {
            return View();
        }

        public ActionResult AddStudent()
        {

            return View();
        }

        [HttpPost]
        public ActionResult AddStudent(Data.student model)
        {
            var result = new Models.AddStudent().New(model);
            if (result)
            {
                return RedirectToAction("AddStudent", "Admin");
            }
            return View();
        }

        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult ListGroups()
        {
            return View();
        }
    }
}