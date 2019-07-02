using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    public class FeeGroupCL
    {
        public int id { get; set; }
        public string session { get; set; }
        public int sessionId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string months { get; set; }
        public bool isDeleted { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
    }
}
