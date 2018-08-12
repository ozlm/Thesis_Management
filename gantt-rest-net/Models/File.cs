using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace gantt_rest_net.Models
{
    public class File
    {
      
            public int Id { get; set; }
            public string Name { get; set; }
            public HttpPostedFileBase FileName { get; set; }
        
    }
}