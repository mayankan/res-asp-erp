using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    public class SMSCL
    {
        public int id { get; set; }
        public int studentLeaveTypeId { get; set; }
        public string studentLeaveType { get; set; }
        public string template { get; set; }
        public bool isDeleted { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
    }
}
