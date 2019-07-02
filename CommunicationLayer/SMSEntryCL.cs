using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    public class SMSEntryCL
    {
        public int id { get; set; }
        public int attendanceId { get; set; }
        public DateTime dateCreated { get; set; }
        public bool isDeleted { get; set; }
        public int smsTemplateId { get; set; }
        public int mobileNumber { get; set; }
    }
}
