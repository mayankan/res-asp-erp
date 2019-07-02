using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunicationLayer
{
    [Serializable]
    public class StudentCL
    {
        public int id { get; set; }
        public string session { get; set; }
        public int classId { get; set; }
        public string classSection { get; set; }
        public string studentCategory { get; set; }
        public int studentCategoryId { get; set; }
        public int admissionNo { get; set; }
        public string studentName { get; set; }
        public string fatherName { get; set; }
        public string fatherMobileNumber { get; set; }
        public string motherName { get; set; }
        public bool gender { get; set; }
        public string address { get; set; }
        public string emailAddress { get; set; }
        public DateTime dob { get; set; }
        public int? siblingAdmissionNo { get; set; }
        public string aadharCardNo { get; set; }
        public string birthCertificate { get; set; }
        public string transferCertificate { get; set; }
        public string miscellaneous1Name { get; set; }
        public string miscellaneous1Link { get; set; }
        public string miscellaneous2Name { get; set; }
        public string miscellaneous2Link { get; set; }
        public string miscellaneous3Name { get; set; }
        public string miscellaneous3Link { get; set; }
        public string deletedTransferCertificate { get; set; }
        public bool isDeleted { get; set; }
        public DateTime? dateDeleted { get; set; }
        public DateTime dateCreated { get; set; }
        public DateTime dateModified { get; set; }
    }
}
