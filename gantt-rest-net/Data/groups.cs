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
    
    public partial class groups
    {
        public groups()
        {
            this.projects = new HashSet<projects>();
        }
    
        public short groupID { get; set; }
        public short studentID1 { get; set; }
        public Nullable<short> studentID2 { get; set; }
        public Nullable<short> studentID3 { get; set; }
        public Nullable<short> studentID4 { get; set; }
        public short supervisorID { get; set; }
    
        public virtual student student { get; set; }
        public virtual student student1 { get; set; }
        public virtual student student2 { get; set; }
        public virtual student student3 { get; set; }
        public virtual student student4 { get; set; }
        public virtual supervisor supervisor { get; set; }
        public virtual ICollection<projects> projects { get; set; }
    }
}