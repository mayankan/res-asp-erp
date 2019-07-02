using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    [Serializable]
    public class GradeEntryGridCL
    {
        public int id { get; set; }
        public int classId { get; set; }
        public string classSection { get; set; }
        public int examinationId { get; set; }
        public string examinationName { get; set; }
        public int subjectId { get; set; }
        public string subjectName { get; set; }
        public int classSubjectId { get; set; }
    }
}
