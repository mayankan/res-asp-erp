using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    public class FeeEntryCL
    {
        public int id { get; set; }
        public int studentId { get; set; }
        public int classFeeMapId { get; set; }
        public int concessionId { get; set; }
        public int transportId { get; set; }
        public string paidFee { get; set; }
    }
}
