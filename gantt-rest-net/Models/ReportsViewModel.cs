using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace gantt_rest_net.Models
{
    public class ReportsViewModel
    {
        //public IEnumerable<string> SelectedReport { get; set; }
        public IEnumerable<SelectListItem> Reports { get; set; }
        public string ReportData { get; set; }
    }
}