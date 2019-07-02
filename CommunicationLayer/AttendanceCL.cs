using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    public class AttendanceCL
    {
        public int id { get; set; }
        public int studentLeaveTypeId { get; set; }
        public string studentLeaveType { get; set; }
        public string class1 { get; set; }
        public string section { get; set; }
        public DateTime date { get; set; }
        public int studentId { get; set; }
        public int classId { get; set; }
        public bool isDeleted { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
    }
}
