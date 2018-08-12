using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Results;

namespace gantt_rest_net.Helpers
{
    public class GanttResponseHelper
    {
        public static Dictionary<string, string> GetResult(string action, int? tid)
        {
            var res = new Dictionary<string, string>();
            res.Add("action", action);
            if (tid != null)
                res.Add("tid", tid.ToString());
            return res;
        }
    }
}