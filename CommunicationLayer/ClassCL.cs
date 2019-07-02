using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    [Serializable]
    public class ClassCL
    {
        public int id { get; set; }
        public string class1{ get;set;}
        public string section { get; set; }
        public string classSection { get; set; }
        public int sessionId { get; set; }
        public int totalStrength { get; set; }
        public bool isDeleted { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
    }
}
