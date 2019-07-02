using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    public class StudentCategoryCL
    {
        public int id { get; set; }
        public string name { get; set; }
        public bool isDeleted { get; set; }
        public int totalStrength { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
    }
}
