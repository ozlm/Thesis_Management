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
    
    public partial class version
    {
        public version()
        {
            this.announcement = new HashSet<announcement>();
        }
    
        public short versionID { get; set; }
        public string versionName { get; set; }
        public System.DateTime dateofCreation { get; set; }
        public short supervisorID { get; set; }
        public string notificationofVersion { get; set; }
    
        public virtual ICollection<announcement> announcement { get; set; }
        public virtual supervisor supervisor { get; set; }
    }
}