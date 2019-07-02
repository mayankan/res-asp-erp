using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    public class TransportCL
    {
        public int id { get; set; }
        public int transportRouteId { get; set; }
        public string chargesSlab { get; set; }
        public string chargesSlabAmount { get; set; }
        public string noOfStops { get; set; }
    }
}
