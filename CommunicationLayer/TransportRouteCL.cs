using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    public class TransportRouteCL
    {
        public int id { get; set; }
        public string routeName { get; set; }
        public string totalNoOfStops { get; set; }
        public string totalAmount { get; set; }
        public bool isDeleted { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
    }
}
