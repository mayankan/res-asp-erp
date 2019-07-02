using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    [Serializable]
    public class ClassSubjectMapGridCL
    {
        public int id { get; set; }
        public int classId { get; set; }
        public string classSection{ get;set;}
        public int subjectId { get; set; }
        public string subject { get; set; }
        public int noOfSubjects { get; set; }
        public int sessionId { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
        public bool isDeleted { get; set; }
    }
}
