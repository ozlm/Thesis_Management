using gantt_rest_net.Data;
using gantt_rest_net.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Reflection;
using Newtonsoft.Json;
using gantt_rest_net.Helpers;

namespace gantt_rest_net.Controllers
{
    public class StudentController : Controller
    {
        // GET: Student
        // GET: Student
        public static short groupId;

        public ActionResult Announcement()
        {
            return View();
        }
        /// <summary>
        /// Get report from DB and return to client when page loading
        /// </summary>
        /// <returns></returns>
        public ActionResult CreateReport()
        {
            bool hasSession = SessionHelper.Instance.HasSession(Session);
            if (!hasSession) return RedirectToAction("Login", "Account");

            ReportsViewModel reportsViewModel = new ReportsViewModel();
            reportsViewModel.ReportData = GetReportDataText();
            return View(reportsViewModel);
        }

        public ActionResult ShowGanttChart()
        {
            Inheritance inh = new Inheritance();
            var stuID = Session["studentID"];

            //studentID den grupIyi çek. grupIdyi gruptasktan bakarak taskları bul diger controller classında


            var grupID = inh.db.findID(Convert.ToInt16(stuID)).First();

            groupId = Convert.ToInt16(grupID);
            return View();

        }

        public short grID()
        {
            short asd = 0;
            asd = groupId;
            return asd;
        }

        public ActionResult UploadReport()
        {
            return View();
        }

        [HttpPost]
        public void Upload()
        {
            for (int i = 0; i < Request.Files.Count; i++)
            {
                var file = Request.Files[i];

                var fileName = Path.GetFileName(file.FileName);

                var path = Path.Combine(Server.MapPath("~/Junk/"), fileName);
                file.SaveAs(path);
            }
        }
        /// <summary>
        /// Save report data to DB from client
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveReportData(string data)
        {
            // ToDo - CBOLEL: User reportu save etmeye çalışırken session düşerse, kaydedilmemiş datanın kaybolmaması için belki direk logine atmak istemeyebiliriz.
            bool hasSession = SessionHelper.Instance.HasSession(Session);
            if (!hasSession) return RedirectToAction("Login", "Account");
            // ToDo - CBOLEL: User reportu save etmeye çalışırken session düşerse, kaydedilmemiş datanın kaybolmaması için belki direk logine atmak istemeyebiliriz.

            Inheritance inh = new Inheritance();
            short reportID = (short)Session["CurrentReportID"];
            DateTime getLatestDate = (DateTime)Session["CurrentReportGetLatestDate"];
            short studentID = (short)Session["studentID"];
            report currentReport = inh.db.report.Where<report>(item => item.reportID == reportID).First<report>();
            string jsonObject = string.Empty;
            if (getLatestDate < currentReport.date)
            {
                jsonObject = JsonConvert.SerializeObject(new
                {
                    result = false,
                    lastUpdatedDate = currentReport.date.ToString(),
                    lastUpdatedBy = string.Concat(currentReport.student.studentName, " ", currentReport.student.studentSurname)
                });
            }
            else
            {
                DateTime updatedDateTime = DateTime.Now;
                currentReport.text = data;
                currentReport.date = updatedDateTime;
                currentReport.updatedBy = studentID;
                inh.db.SaveChanges();

                jsonObject = JsonConvert.SerializeObject(new
                {
                    result = true,
                });
                SessionHelper.Instance.SetValue(SessionHelper.Constants.CurrentReportGetLatestDate, updatedDateTime, Session);
            }
            return Json(data: jsonObject);
        }
        /// <summary>
        /// Get report from DB and return to client
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetReportData()
        {
            bool hasSession = SessionHelper.Instance.HasSession(Session);
            if (!hasSession) return RedirectToAction("Login", "Account");

            string reportData = GetReportDataText();
            string jsonObject = JsonConvert.SerializeObject(new
            {
                result = true,
                data = reportData
            });
            return Json(data: jsonObject);
        }
        /// <summary>
        /// Helper method for getting report data
        /// </summary>
        /// <returns></returns>
        private string GetReportDataText()
        {
            Inheritance inh = new Inheritance();
            string authenticatedUserMail = Session["AuthenticatedUserMail"] as string;
            student stud = inh.db.student.Where<student>(item => item.studentEmail == authenticatedUserMail).First<student>();
            int studentId = stud.studentID;
            groups group = inh.db.groups.Where<groups>(item => item.student1.studentID == studentId
            || item.student2.studentID == studentId
            || item.student3.studentID == studentId
            || item.student4.studentID == studentId).First<groups>();
            projects project = inh.db.projects.Where<projects>(item => item.groupID == group.groupID).First<projects>();
            int projectID = project.projectID;
            report currentReport = inh.db.report.Where<report>(item => item.projectID == project.projectID).First<report>();
            Session["CurrentReportID"] = currentReport.reportID;
            Session["CurrentReportGetLatestDate"] = currentReport.date;
            return currentReport.text;
        }
        /// <summary>
        /// Upload image to server from client
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult UploadImage()
        {
            HttpPostedFileBase image = Request.Files[0];
            string[] splitImageName = Path.GetFileName(image.FileName).Split('.');
            string fileName = string.Empty;
            for (int indexer = 0; indexer < splitImageName.Length; indexer++)
            {
                if (indexer < splitImageName.Length - 1) fileName += splitImageName[indexer];
                else fileName += DateTime.Now.ToFileTime() + "." + splitImageName[indexer];
            }
            string path = Path.Combine(Server.MapPath("~/Content/images"), fileName);
            image.SaveAs(path);
            return Json(fileName);
        }

        #region ToDo - CBOLEL: Şu kendi kendine yerini, düzenini bilen başlık kaydırma sistemini hayata geçiremedim ya, kıyıp silemiyorum da kodları
        //private int GetChangingLevel(int currentChangingLevel, List<int> headlineNumbers)
        //{
        //    if (headlineNumbers[headlineNumbers.Count - currentChangingLevel] == 1)
        //        return GetChangingLevel(currentChangingLevel++, headlineNumbers);
        //    else return currentChangingLevel;
        //}
        //private Headline FindHeadlineByNumber(List<Headline> headlineList, List<int> headlineNumbers)
        //{
        //    Headline headline = null;
        //    for (int reportIndexer = 0; reportIndexer < headlineList.Count; reportIndexer++)
        //    {
        //        List<int> innerHeadlineNumbers = headlineList[reportIndexer].HeadlineNumbers;
        //        bool innerResult = true;
        //        for (int headlineNumberIndexer = 0; headlineNumberIndexer < innerHeadlineNumbers.Count; headlineNumberIndexer++)
        //        {
        //            if (innerHeadlineNumbers.Count != headlineNumbers.Count || innerHeadlineNumbers[headlineNumberIndexer] != headlineNumbers[headlineNumberIndexer]) innerResult = false;
        //        }
        //        if (innerResult) return headlineList[reportIndexer];
        //        else headline = FindHeadlineByNumber(headlineList[reportIndexer].SubHeadlines, headlineNumbers);

        //        if (headline != null) return headline;
        //        else continue;
        //    }
        //    return headline;
        //}
        //private void SaveHeadline(Headline updatedHeadline)
        //{
        //    Inheritance inh = new Inheritance();
        //    report currentReport = inh.db.report.Where<report>(item => item.reportID == updatedHeadline.ID).First<report>();
        //    currentReport.reportName = updatedHeadline.HeadlineName;
        //    inh.db.SaveChanges();
        //    for (int headlineIndexer = 0; headlineIndexer < updatedHeadline.SubHeadlines.Count; headlineIndexer++)
        //    {
        //        SaveHeadline(updatedHeadline.SubHeadlines[headlineIndexer]);
        //    }
        //}
        //private Headline UpdateHeadline(Headline headline, string oldValue, string newValue)
        //{
        //    headline.HeadlineName = headline.HeadlineName.Replace(oldValue, newValue);
        //    for (int subHeadlineIndexer = 0; subHeadlineIndexer < headline.SubHeadlines.Count; subHeadlineIndexer++)
        //    {
        //        headline.SubHeadlines[subHeadlineIndexer] = UpdateHeadline(headline.SubHeadlines[subHeadlineIndexer], oldValue, newValue);
        //    }
        //    return headline;
        //}
        //private Headline FindSelectedReportByID(List<Headline> headlineList, int selectedValue)
        //{
        //    Headline selectedHeadline = null;
        //    for (int reportIndexer = 0; reportIndexer < headlineList.Count; reportIndexer++)
        //    {
        //        if (headlineList[reportIndexer].ID == selectedValue)
        //        {
        //            return headlineList[reportIndexer];
        //        }
        //        else selectedHeadline = FindSelectedReportByID(headlineList[reportIndexer].SubHeadlines, selectedValue);

        //        if (selectedHeadline != null) return selectedHeadline;
        //        else continue;
        //    }
        //    return selectedHeadline;
        //}
        //private Headline FindSelectedReportByName(List<Headline> headlineList, string reportName)
        //{
        //    Headline selectedHeadline = null;
        //    for (int reportIndexer = 0; reportIndexer < headlineList.Count; reportIndexer++)
        //    {
        //        if (headlineList[reportIndexer].HeadlineName == reportName)
        //        {
        //            return headlineList[reportIndexer];
        //        }
        //        else selectedHeadline = FindSelectedReportByName(headlineList[reportIndexer].SubHeadlines, reportName);

        //        if (selectedHeadline != null) return selectedHeadline;
        //        else continue;
        //    }
        //    return selectedHeadline;

        //}
        //private string ConvertHeadlineListToTextList(List<Headline> headlineList)
        //{
        //    string headlineString = string.Empty;
        //    for (int headlineIndexer = 0; headlineIndexer < headlineList.Count; headlineIndexer++)
        //    {
        //        Headline headline = headlineList[headlineIndexer];
        //        string subHeadlineString = ConvertHeadlineListToTextList(headline.SubHeadlines);
        //        headlineString = string.Concat(headlineString, headline.HeadlineName, ";", subHeadlineString);
        //    }
        //    return headlineString;
        //}
        //private List<Headline> SortHeadlineList(List<Headline> headlineList)
        //{
        //    for (int headlineIndexer = 0; headlineIndexer < headlineList.Count; headlineIndexer++)
        //    {
        //        Headline headline = headlineList[headlineIndexer];
        //        headline.SubHeadlines = SortHeadlineList(headline.SubHeadlines);
        //    }
        //    return headlineList.OrderBy(headline => headline.HeadlineName).ToList();
        //}
        //public List<Headline> GetHeadlineList()
        //{
        //    Inheritance inh = new Inheritance();
        //    //ToDo - students dif
        //    List<report> reportList = inh.db.report.ToList<report>();
        //    List<Headline> headlineList = new List<Headline>();
        //    for (int reportIndexer = 0; reportIndexer < reportList.Count; reportIndexer++)
        //    {
        //        string reportName = reportList[reportIndexer].reportName;
        //        if (reportName.Length > 1) continue;
        //        Headline headline = new Headline(reportList[reportIndexer]);
        //        headline.SubHeadlines = headline.GetSubHeadlines(reportList);
        //        headlineList.Add(headline);
        //    }
        //    return SortHeadlineList(headlineList);
        //}
        #endregion
    }

    public class Headline
    {
        public int ID;
        public string HeadlineName;
        public List<int> HeadlineNumbers;
        //public string[] HeadlineID;
        public Headline ParentHeadline;
        public List<Headline> SubHeadlines;

        public Headline(report reportItem)
        {
            this.ID = reportItem.reportID;
            this.HeadlineName = reportItem.reportName;
            this.HeadlineNumbers = GetHeadlineNumbers(this.HeadlineName);
        }
        public Headline(report reportItem, Headline parentHeadline)
        {
            this.ID = reportItem.reportID;
            this.HeadlineName = reportItem.reportName;
            this.ParentHeadline = parentHeadline;
            this.HeadlineNumbers = GetHeadlineNumbers(this.HeadlineName);
        }

        private List<int> GetHeadlineNumbers(string headlineName)
        {
            List<int> headlineNumbers = new List<int>();
            string[] splitReportName = headlineName.Split('.');
            for (int headlineNumbersIndexer = 0; headlineNumbersIndexer < splitReportName.Length; headlineNumbersIndexer++)
            {
                int headlineNumber;
                int.TryParse(splitReportName[headlineNumbersIndexer], out headlineNumber);
                headlineNumbers.Add(headlineNumber);
            }
            return headlineNumbers;
        }

        //public Headline(string headlineName)
        //{
        //    this.HeadlineName = headlineName;
        //    //this.HeadlineID = headlineName.Split('.');
        //}
        //public Headline(Headline parentHeadline, string headlineName)
        //{
        //    this.HeadlineName = headlineName;
        //    this.ParentHeadline = parentHeadline;
        //    //this.HeadlineID = headlineName.Split('.');
        //}
        internal List<Headline> GetSubHeadlines(List<report> reportList)
        {
            List<Headline> headlineList = new List<Headline>();
            for (int reportIndexer = 0; reportIndexer < reportList.Count; reportIndexer++)
            {
                string reportName = reportList[reportIndexer].reportName;
                // hiyerarşik olarak alakasız title kontrolü & aynı title kontrolü
                // headlineName üst başlık
                // reportName alt başlık
                if (!reportName.Contains(this.HeadlineName) || reportName.Equals(this.HeadlineName)) continue;
                if (reportName.IndexOf(this.HeadlineName) != 0) continue;
                int headlineNameLengthWithDot = this.HeadlineName.Length + 1;
                int leftReportNameLenght = reportName.Length - headlineNameLengthWithDot;
                if (reportName.Substring(headlineNameLengthWithDot, leftReportNameLenght).Length > 1) continue;
                //if (reportName.Contains('.'))
                //{
                //    string leftReportName = GetLeftReportName(reportName, this.HeadlineName);
                //    // hiyerarşik olarak iki ve daha fazla alt title kontrolü
                //    if (leftReportName.Split('.').Length > 1) continue;
                //}
                Headline headline = new Headline(reportList[reportIndexer], this);
                headline.SubHeadlines = headline.GetSubHeadlines(reportList);
                headlineList.Add(headline);
                //string leftReportName = GetLeftReportName(reportList[reportIndexer].reportName, HeadlineName);



                //string[] headlineNumbers = reportList[reportIndexer].reportName.Split('.');
                //Headline headline = new Headline(headlineNumbers);
                //headline.SubHeadlines = headline.GetSubHeadlines(reportList);

            }
            //for (int headlineNumberIndexer = 0; headlineNumberIndexer < headLineNumbers.Length - 1; headlineNumberIndexer++)
            //{
            //    string subHeadlineNumber = headLineNumbers[headlineNumberIndexer];
            //    Headline newHeadline = new Headline();
            //    newHeadline.HeadlineID = headline.HeadlineID;
            //    int intSubHeadlineNumber;
            //    int.TryParse(subHeadlineNumber, out intSubHeadlineNumber);
            //    headlines[intSubHeadlineNumber].SubHeadlines.Add(newHeadline);
            //}
            return headlineList;
        }

        //private string GetLeftReportName(string reportName, string headlineName)
        //{
        //    int index = reportName.IndexOf(headlineName);
        //    if(index > 0 ) 
        //    int startIndex = index + headlineName.Length + 1;
        //    int substringLength = reportName.Length - startIndex;
        //    return reportName.Substring(startIndex, substringLength);
        //}

    }
}