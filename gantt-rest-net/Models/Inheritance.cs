using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using gantt_rest_net.Data;

namespace gantt_rest_net.Models
{
    public class Inheritance
    {
        public Entities7 db { get; set; }
        public Inheritance()
        {
            this.db = new Data.Entities7();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
        ~Inheritance()
        {
            this.Dispose();
        }
    }
}