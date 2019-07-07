using CommunicationLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class StudentBLL
    {
        rainbowjanakpuriEntities dbcontext = new rainbowjanakpuriEntities();
        public Collection<StudentCL> viewStudents(int sessionId)
        {
            Collection<StudentCL> queryStudent = new Collection<StudentCL>();
            IQueryable<Student> queryStudentDB = from x in dbcontext.Students where x.Class.SessionId == sessionId && x.IsDeleted == false select x;
            foreach (Student item in queryStudentDB)
            {
                queryStudent.Add(
                    new StudentCL()
                    {
                        aadharCardNo = item.AadharCard,
                        address = item.Address,
                        admissionNo = item.AdmissionNo,
                        classId = item.ClassId,
                        dob = item.DOB,
                        emailAddress = item.EmailAddress,
                        fatherMobileNumber = item.FatherMobileNumber,
                        fatherName = item.FatherName,
                        gender = item.Gender,
                        id = item.Id,
                        motherName = item.MotherName,
                        siblingAdmissionNo = item.SiblingAdmissionNo,
                        studentCategoryId = item.StudentCategoryId,
                        studentName = item.StudentName,
                        birthCertificate = item.BirthCertificate,
                        classSection = item.Class.Class1 + "-" + item.Class.Section,
                        dateCreated = item.DateCreated,
                        dateModified = item.DateModified,
                        deletedTransferCertificate = item.DeletedTransferCertificate,
                        isDeleted = item.IsDeleted,
                        miscellaneous1Link = item.Miscellaneous1Link,
                        miscellaneous1Name = item.Miscellaneous1Name,
                        miscellaneous2Link = item.Miscellaneous2Link,
                        miscellaneous2Name = item.Miscellaneous2Name,
                        miscellaneous3Link = item.Miscellaneous3Link,
                        miscellaneous3Name = item.Miscellaneous3Name,
                        session = item.Class.Session.StartingYear + "-" + item.Class.Session.EndingYear,
                        studentCategory = item.StudentCategory.Name,
                        transferCertificate = item.TransferCertificate,
                        dateDeleted = item.DateDeleted,
                    });
            }
            return queryStudent;
        }
        public Collection<StudentCL> viewStudentsByClassId(int classId)
        {
            Collection<StudentCL> queryStudent = new Collection<StudentCL>();
            IQueryable<Student> queryStudentDB = from x in dbcontext.Students where x.ClassId == classId && x.IsDeleted == false select x;
            queryStudentDB = queryStudentDB.OrderBy(x => x.StudentName);
            foreach (Student item in queryStudentDB)
            {
                queryStudent.Add(
                    new StudentCL()
                    {
                        aadharCardNo = item.AadharCard,
                        address = item.Address,
                        admissionNo = item.AdmissionNo,
                        classId = item.ClassId,
                        dob = item.DOB,
                        emailAddress = item.EmailAddress,
                        fatherMobileNumber = item.FatherMobileNumber,
                        fatherName = item.FatherName,
                        gender = item.Gender,
                        id = item.Id,
                        motherName = item.MotherName,
                        siblingAdmissionNo = item.SiblingAdmissionNo,
                        studentCategoryId = item.StudentCategoryId,
                        studentName = item.StudentName,
                        birthCertificate = item.BirthCertificate,
                        classSection = item.Class.Class1 + "-" + item.Class.Section,
                        dateCreated = item.DateCreated,
                        dateModified = item.DateModified,
                        deletedTransferCertificate = item.DeletedTransferCertificate,
                        isDeleted = item.IsDeleted,
                        miscellaneous1Link = item.Miscellaneous1Link,
                        miscellaneous1Name = item.Miscellaneous1Name,
                        miscellaneous2Link = item.Miscellaneous2Link,
                        miscellaneous2Name = item.Miscellaneous2Name,
                        miscellaneous3Link = item.Miscellaneous3Link,
                        miscellaneous3Name = item.Miscellaneous3Name,
                        session = item.Class.Session.StartingYear + "-" + item.Class.Session.EndingYear,
                        studentCategory = item.StudentCategory.Name,
                        transferCertificate = item.TransferCertificate,
                        dateDeleted = item.DateDeleted,
                    });
            }
            return queryStudent;
        }
        public StudentCL viewStudentById(int studentId, int sessionId)
        {
            Student item = (from x in dbcontext.Students where x.Id == studentId && x.Class.SessionId == sessionId select x).FirstOrDefault();
            StudentCL studentCL = new StudentCL()
            {
                aadharCardNo = item.AadharCard,
                address = item.Address,
                admissionNo = item.AdmissionNo,
                classId = item.ClassId,
                dob = item.DOB,
                emailAddress = item.EmailAddress,
                fatherMobileNumber = item.FatherMobileNumber,
                fatherName = item.FatherName,
                gender = item.Gender,
                id = item.Id,
                motherName = item.MotherName,
                siblingAdmissionNo = item.SiblingAdmissionNo,
                studentCategoryId = item.StudentCategoryId,
                studentName = item.StudentName,
                birthCertificate = item.BirthCertificate,
                classSection = item.Class.Class1 + "-" + item.Class.Section,
                dateCreated = item.DateCreated,
                dateModified = item.DateModified,
                deletedTransferCertificate = item.DeletedTransferCertificate,
                isDeleted = item.IsDeleted,
                miscellaneous1Link = item.Miscellaneous1Link,
                miscellaneous1Name = item.Miscellaneous1Name,
                miscellaneous2Link = item.Miscellaneous2Link,
                miscellaneous2Name = item.Miscellaneous2Name,
                miscellaneous3Link = item.Miscellaneous3Link,
                miscellaneous3Name = item.Miscellaneous3Name,
                session = item.Class.Session.StartingYear + "-" + item.Class.Session.EndingYear,
                studentCategory = item.StudentCategory.Name,
                transferCertificate = item.TransferCertificate,
                dateDeleted = item.DateDeleted,
            };
            return studentCL;
        }
        public StudentCL viewStudentByAdmissionNo(int admissionNo, int sessionId)
        {
            Student item = (from x in dbcontext.Students where x.AdmissionNo == admissionNo && x.Class.SessionId == sessionId && x.IsDeleted == false select x).FirstOrDefault();
            StudentCL studentCL = new StudentCL()
            {
                aadharCardNo = item.AadharCard,
                address = item.Address,
                admissionNo = item.AdmissionNo,
                classId = item.Class.Id,
                dob = item.DOB,
                emailAddress = item.EmailAddress,
                fatherMobileNumber = item.FatherMobileNumber,
                fatherName = item.FatherName,
                gender = item.Gender,
                id = item.Id,
                motherName = item.MotherName,
                siblingAdmissionNo = item.SiblingAdmissionNo,
                studentCategoryId = item.StudentCategoryId,
                studentName = item.StudentName,
                birthCertificate = item.BirthCertificate,
                classSection = item.Class.Class1 + "-" + item.Class.Section,
                dateCreated = item.DateCreated,
                dateModified = item.DateModified,
                deletedTransferCertificate = item.DeletedTransferCertificate,
                isDeleted = item.IsDeleted,
                miscellaneous1Link = item.Miscellaneous1Link,
                miscellaneous1Name = item.Miscellaneous1Name,
                miscellaneous2Link = item.Miscellaneous2Link,
                miscellaneous2Name = item.Miscellaneous2Name,
                miscellaneous3Link = item.Miscellaneous3Link,
                miscellaneous3Name = item.Miscellaneous3Name,
                session = item.Class.Session.StartingYear + "-" + item.Class.Session.EndingYear,
                studentCategory = item.StudentCategory.Name,
                transferCertificate = item.TransferCertificate,
                dateDeleted = item.DateDeleted,
            };
            return studentCL;
        }
        public int addStudent(StudentCL studentsInput)
        {
            Student studentQuery = dbcontext.Students.Add(new Student
            {
                AadharCard = studentsInput.aadharCardNo,
                Address = studentsInput.address,
                AdmissionNo = studentsInput.admissionNo,
                TransferCertificate = studentsInput.transferCertificate,
                BirthCertificate = studentsInput.birthCertificate,
                ClassId = studentsInput.classId,
                DateCreated = studentsInput.dateCreated,
                DateModified = studentsInput.dateModified,
                DeletedTransferCertificate = studentsInput.deletedTransferCertificate,
                DOB = studentsInput.dob,
                EmailAddress = studentsInput.emailAddress,
                FatherMobileNumber = studentsInput.fatherMobileNumber,
                FatherName = studentsInput.fatherName,
                Gender = studentsInput.gender,
                Id = studentsInput.id,
                IsDeleted = studentsInput.isDeleted,
                Miscellaneous1Link = studentsInput.miscellaneous1Link,
                Miscellaneous1Name = studentsInput.miscellaneous1Name,
                Miscellaneous2Link = studentsInput.miscellaneous2Link,
                Miscellaneous2Name = studentsInput.miscellaneous2Name,
                Miscellaneous3Link = studentsInput.miscellaneous3Link,
                Miscellaneous3Name = studentsInput.miscellaneous3Name,
                MotherName = studentsInput.motherName,
                SiblingAdmissionNo = studentsInput.siblingAdmissionNo,
                StudentCategoryId = studentsInput.studentCategoryId,
                StudentName = studentsInput.studentName,
                DateDeleted = null,
            });
            dbcontext.SaveChanges();
            int StudentId = studentQuery.Id;
            return StudentId;
        }
        public int createupdateStudentCollection(Collection<StudentCL> studentCL)
        {
            int count = 0;
            foreach (StudentCL item in studentCL)
            {
                Student query = (from x in dbcontext.Students where x.AdmissionNo == item.admissionNo && x.ClassId == item.classId && x.IsDeleted == false select x).FirstOrDefault();
                if (query == null)
                {
                    Student student = dbcontext.Students.Add(new Student
                    {
                        Address = item.address,
                        AdmissionNo = item.admissionNo,
                        AadharCard = item.aadharCardNo,
                        ClassId = item.classId,
                        StudentCategoryId = item.studentCategoryId,
                        BirthCertificate = item.birthCertificate,
                        DateCreated = item.dateCreated,
                        DateModified = item.dateModified,
                        DOB = item.dob,
                        EmailAddress = item.emailAddress,
                        FatherMobileNumber = item.fatherMobileNumber,
                        FatherName = item.fatherName,
                        Gender = item.gender,
                        IsDeleted = item.isDeleted,
                        StudentName = item.studentName,
                        MotherName = item.motherName,
                    });
                    count++;
                }
                else
                {
                    query.AadharCard = item.aadharCardNo;
                    query.Address = item.address;
                    query.BirthCertificate = item.birthCertificate;
                    query.ClassId = item.classId;
                    query.DateCreated = item.dateCreated;
                    query.DateDeleted = item.dateDeleted;
                    query.DateModified = item.dateModified;
                    query.DeletedTransferCertificate = item.deletedTransferCertificate;
                    query.DOB = item.dob;
                    query.EmailAddress = item.emailAddress;
                    query.FatherMobileNumber = item.fatherMobileNumber;
                    query.FatherName = item.fatherName;
                    query.Gender = item.gender;
                    query.IsDeleted = item.isDeleted;
                    query.Miscellaneous1Link = item.miscellaneous1Link;
                    query.MotherName = item.motherName;
                    query.SiblingAdmissionNo = item.siblingAdmissionNo;
                    query.StudentCategoryId = item.studentCategoryId;
                    query.StudentName = item.studentName;
                    count++;
                }
            }
            dbcontext.SaveChanges();
            return count;
        }
        public StudentCL updateStudent(StudentCL studentsInput)
        {
            StudentCL studentReturn = new StudentCL();
            Student studentsQuery = (from x in dbcontext.Students where x.Id == studentsInput.id select x).FirstOrDefault();
            studentsQuery.AadharCard = studentsInput.aadharCardNo;
            studentsQuery.Address = studentsInput.address;
            studentsQuery.AdmissionNo = studentsInput.admissionNo;
            studentsQuery.ClassId = studentsInput.classId;
            studentsQuery.DateCreated = studentsInput.dateCreated;
            studentsQuery.DateModified = studentsInput.dateModified;
            studentsQuery.DOB = studentsInput.dob;
            studentsQuery.EmailAddress = studentsInput.emailAddress;
            studentsQuery.FatherMobileNumber = studentsInput.fatherMobileNumber;
            studentsQuery.FatherName = studentsInput.fatherName;
            studentsQuery.Gender = studentsInput.gender;
            studentsQuery.MotherName = studentsInput.motherName;
            studentsQuery.SiblingAdmissionNo = studentsInput.siblingAdmissionNo;
            studentsQuery.StudentCategoryId = studentsInput.studentCategoryId;
            studentsQuery.StudentName = studentsInput.studentName;
            dbcontext.SaveChanges();
            studentReturn.aadharCardNo = studentsQuery.AadharCard;
            studentReturn.address = studentsQuery.Address;
            studentReturn.admissionNo = studentsQuery.AdmissionNo;
            studentReturn.classId = studentsQuery.ClassId;
            studentReturn.dateCreated = studentsQuery.DateCreated;
            studentReturn.dateModified = studentsQuery.DateModified;
            studentReturn.dob = studentsQuery.DOB;
            studentReturn.emailAddress = studentsQuery.EmailAddress;
            studentReturn.fatherMobileNumber = studentsQuery.FatherMobileNumber;
            studentReturn.fatherName = studentsQuery.FatherName;
            studentReturn.gender = studentsQuery.Gender;
            studentReturn.motherName = studentsQuery.MotherName;
            studentReturn.siblingAdmissionNo = studentsQuery.SiblingAdmissionNo;
            studentReturn.studentCategoryId = studentsQuery.StudentCategoryId;
            studentReturn.studentName = studentsQuery.StudentName;
            studentReturn.id = studentsQuery.Id;
            return studentReturn;
        }
        public Collection<StudentCL> viewTCStudents(int sessionId)
        {
            Collection<StudentCL> queryStudent = new Collection<StudentCL>();
            IQueryable<Student> queryStudentDB = from x in dbcontext.Students where x.Class.SessionId == sessionId && x.IsDeleted == true select x;
            foreach (Student item in queryStudentDB)
            {
                queryStudent.Add(
                    new StudentCL()
                    {
                        aadharCardNo = item.AadharCard,
                        address = item.Address,
                        admissionNo = item.AdmissionNo,
                        classId = item.ClassId,
                        dob = item.DOB,
                        emailAddress = item.EmailAddress,
                        fatherMobileNumber = item.FatherMobileNumber,
                        fatherName = item.FatherName,
                        gender = item.Gender,
                        id = item.Id,
                        motherName = item.MotherName,
                        siblingAdmissionNo = item.SiblingAdmissionNo,
                        studentCategoryId = item.StudentCategoryId,
                        studentName = item.StudentName,
                        birthCertificate = item.BirthCertificate,
                        classSection = item.Class.Class1 + "-" + item.Class.Section,
                        dateCreated = item.DateCreated,
                        dateModified = item.DateModified,
                        deletedTransferCertificate = item.DeletedTransferCertificate,
                        isDeleted = item.IsDeleted,
                        miscellaneous1Link = item.Miscellaneous1Link,
                        miscellaneous1Name = item.Miscellaneous1Name,
                        miscellaneous2Link = item.Miscellaneous2Link,
                        miscellaneous2Name = item.Miscellaneous2Name,
                        miscellaneous3Link = item.Miscellaneous3Link,
                        miscellaneous3Name = item.Miscellaneous3Name,
                        session = item.Class.Session.StartingYear + "-" + item.Class.Session.EndingYear,
                        studentCategory = item.StudentCategory.Name,
                        transferCertificate = item.TransferCertificate,
                        dateDeleted = item.DateDeleted,
                    });
            }
            return queryStudent;
        }
        public StudentCL updateTCStudent(StudentCL studentsInput)
        {
            StudentCL studentReturn = new StudentCL();
            Student studentsQuery = (from x in dbcontext.Students where x.Id == studentsInput.id select x).FirstOrDefault();
            studentsQuery.IsDeleted = studentsInput.isDeleted;
            studentsQuery.DeletedTransferCertificate = studentsInput.deletedTransferCertificate;
            studentsQuery.DateDeleted = studentsInput.dateDeleted;
            dbcontext.SaveChanges();
            studentReturn.id = studentsQuery.Id;
            studentReturn.isDeleted = studentsQuery.IsDeleted;
            studentReturn.deletedTransferCertificate = studentsQuery.DeletedTransferCertificate;
            studentReturn.dateDeleted = studentsQuery.DateDeleted;
            return studentReturn;
        }
    }
}
