using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gantt_rest_net.Helpers
{
    public class SessionHelper : Controller
    {
        public static SessionHelper Instance
        {
            get
            {
                return new SessionHelper();
            }
        }
        public struct Constants
        {
            public const string CurrentReportID = "CurrentReportID";
            public const string StudentID = "studentID";
            public const string AuthenticatedUserMail = "AuthenticatedUserMail";
            public const string CurrentReportGetLatestDate = "CurrentReportGetLatestDate";
        }

        // GET: SessionHelper
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// Check Session[sessionKey] value. If session is empty, return false
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <returns></returns>
        public bool HasValue(string sessionKey, HttpSessionStateBase session)
        {
            return session[sessionKey] != null;
        }
        /// <summary>
        /// Check user session. If user hasn't session, return false
        /// </summary>
        /// <returns></returns>
        public bool HasSession(HttpSessionStateBase session)
        {
            bool hasMail = HasValue(Constants.AuthenticatedUserMail, session);
            bool hasStudentID = HasValue(Constants.StudentID, session);
            return hasMail && hasStudentID;
        }
        /// <summary>
        /// Set Session[sessionKey]
        /// </summary>
        /// <param name="sessionKey"></param>
        /// <param name="value"></param>
        /// <param name="session"></param>
        public void SetValue(string sessionKey, object value, HttpSessionStateBase session)
        {
            session[sessionKey] = value;
        }
        /// <summary>
        /// Get session value to T
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sessionKey"></param>
        /// <returns></returns>
        /// 
        //public T GetValue<T>(string sessionKey) where T : struct
        //{
        //    object value = Session[sessionKey];
        //    if (value != null && value is T)
        //    {
        //        return (T)value;
        //    }
        //    else
        //    {
        //        object ıbj = new object();
        //        return (T)ıbj;
        //    }
        //}
        //public object GetValue(string sessionKey) where T : struct
        //{
        //    object value = Session[sessionKey];
        //    if (value != null && value is T)
        //    {
        //        return (T)value;
        //    }
        //    else
        //    {
        //        return null;
        //        object ıbj = new object();
        //        return (T)ıbj;
        //    }
        //}
        //public string GetValue<T>(string sessionKey) where T : struct
        //{
        //    object value = Session[sessionKey];
        //    if (value != null && value is T)
        //    {
        //        return (T)value;
        //    }
        //    else
        //    {
        //        return null;
        //        object ıbj = new object();
        //        return (T)ıbj;
        //    }
        //}
    }
}