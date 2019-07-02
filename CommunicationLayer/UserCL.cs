using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    public class UserCL
    {
        public int id { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
        public bool isDeleted { get; set; }
        public int roleId { get; set; }
    }
}
