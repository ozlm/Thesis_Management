using gantt_rest_net.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using gantt_rest_net.Data;
using gantt_rest_net.Helpers;
using Newtonsoft.Json;

namespace gantt_rest_net.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public short ID { get; set; }


        // GET: Account
        [AllowAnonymous]
        public ActionResult Login()
        {

            if (String.IsNullOrEmpty(HttpContext.User.Identity.Name))
            {
                FormsAuthentication.SignOut();
                return View();
            }
            return Redirect("~/Account/Login");

        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginModel model, string returnurl)
        {

            if (ModelState.IsValid)
            {
                Inheritance ın = new Inheritance();

                var studentt = ın.db.student.Where(ww => ww.studentEmail == model.EMail && ww.studentPassword == model.Password);
                var supervisorr = ın.db.supervisor.Where(ww => ww.supervisorEmail == model.EMail && ww.supervisorPassword == model.Password);

                var admin = ın.db.supervisor.Where(ww => ww.supervisorEmail == model.EMail && ww.supervisorPassword == model.Password && ww.isAdmin == true);

                //Aşağıdaki if komutu gönderilen mail ve şifre doğrultusunda kullanıcı kontrolu yapar. Eğer kullanıcı var ise login olur.
                if (studentt.Count() > 0)
                {

                    FormsAuthentication.SetAuthCookie(model.EMail, true);
                    // Session ["stuName"]= ın.db.student.Find(model.EMail.ToString()).studentName.ToString();
                    //  Session["stuName"] = ın.db.spFindName(model.EMail,stu,sup).ToString();
                    Session["AuthenticatedUserMail"] = model.EMail;
                    var stuEmail = Session["AuthenticatedUserMail"];
                    student stu = ın.db.student.Where<student>(item => item.studentEmail.Equals(stuEmail.ToString())).First<student>();
                    Session["studentID"] = stu.studentID;

                    return RedirectToAction("CreateReport", "Student");
                }
                else if (supervisorr.Count() > 0)
                {
                    FormsAuthentication.SetAuthCookie(model.EMail, true);
                    //yeni eklendi
                    Session["supEmail"] = model.EMail;
                    var supEmail = Session["supEmail"];
                    supervisor sup = ın.db.supervisor.Where<supervisor>(item => item.supervisorEmail.Equals(supEmail.ToString())).First<supervisor>();
                    Session["supID"] = sup.supervisorID;

                    //   ID=Convert.ToInt16(ın.db.spname(model.EMail));

                    if (admin.Count() > 0)
                    {

                        return RedirectToAction("ListProjects", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("ViewReports", "Supervisor");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "EMail veya şifre hatalı!");
                }
            }
            return View(model);
        }

        //private string _user;
        //public string user { get { return this._user; } set {this._user=maill;}}

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
        /// <summary>
        /// Check session via SessionHelper, than return to client
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult CheckSession()
        {
            bool hasSession = SessionHelper.Instance.HasSession(Session);
            if (hasSession)
            {
                object response = new
                {
                    result = hasSession
                };
                string serializedObject = JsonConvert.SerializeObject(response);
                return Json(data: serializedObject);
            }
            else
            {
                return RedirectToAction("Login", "Account");
            }
        }
    }
}