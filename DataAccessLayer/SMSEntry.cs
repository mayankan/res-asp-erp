//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class SMSEntry
    {
        public int Id { get; set; }
        public int AttendanceId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public bool IsDeleted { get; set; }
        public int SMSTemplateId { get; set; }
        public string MobileNumber { get; set; }
    
        public virtual Attendance Attendance { get; set; }
        public virtual SM SM { get; set; }
    }
}
