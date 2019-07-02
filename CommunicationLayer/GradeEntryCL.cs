using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    public class GradeEntryCL
    {
        public int id{get;set;}
        public int examinationId{get;set;}
        public int sessionId{get;set;}
        public int classSubjectId{get;set; }
        public int subjectId { get; set; }
        public string subjectName { get; set; }
        public int classId { get; set; }
        public int studentId { get; set; }
        public string grade{get;set;}
        public DateTime dateCreated{get;set;}
        public DateTime dateModified{get;set;}
        public bool isDeleted{get;set;}
    }
}
