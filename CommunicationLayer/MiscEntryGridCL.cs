using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    [Serializable]
    public class MiscEntryGridCL
    {
        public int id { get; set; }
        public int classId { get; set; }
        public string classSection { get; set; }
        public int examinationId { get; set; }
        public string examinationName { get; set; }
        public string remarks { get; set; }
        public string attendance { get; set; }
    }
}
