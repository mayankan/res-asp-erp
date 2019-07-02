using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    [Serializable]
    public class SubjectCL
    {
        public int id { get; set; }
        public string name { get; set; }
        public int totalClasses { get; set; }
        public bool isDeleted { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
    }
}
