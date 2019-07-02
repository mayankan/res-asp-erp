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
    
    public partial class MarksEntry
    {
        public int Id { get; set; }
        public int ExaminationId { get; set; }
        public string Marks { get; set; }
        public int SessionId { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime DateCreated { get; set; }
        public System.DateTime DateModified { get; set; }
        public int ClassSubjectId { get; set; }
        public int StudentId { get; set; }
    
        public virtual ClassSubjectMap ClassSubjectMap { get; set; }
        public virtual Examination Examination { get; set; }
        public virtual Session Session { get; set; }
        public virtual Student Student { get; set; }
    }
}
