using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    public class LogCL
    {
        public int id { get; set; }
        public string logAction { get; set; }
        public DateTime dateOfAction { get; set; }
        public int userId { get; set; }
        public string module { get; set; }
    }
}
