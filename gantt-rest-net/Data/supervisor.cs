//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace gantt_rest_net.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class supervisor
    {
        public supervisor()
        {
            this.announcement = new HashSet<announcement>();
            this.groups = new HashSet<groups>();
            this.version = new HashSet<version>();
        }
    
        public short supervisorID { get; set; }
        public string supervisorEmail { get; set; }
        public string supervisorPassword { get; set; }
        public string supervisorName { get; set; }
        public string supervisorSurname { get; set; }
        public bool isAdmin { get; set; }
    
        public virtual ICollection<announcement> announcement { get; set; }
        public virtual ICollection<groups> groups { get; set; }
        public virtual ICollection<version> version { get; set; }
    }
}
