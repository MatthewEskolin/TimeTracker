//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TimeTracker.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class DJobTiming
    {
        public int JobTimingId { get; set; }
        public int JobItemId { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
        public Nullable<System.DateTime> EndTime { get; set; }
        public int DeveloperId { get; set; }
    
        public virtual DDeveloper DDeveloper { get; set; }
        public virtual DJobItem DJobItem { get; set; }
    }
}
