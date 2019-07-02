using CommunicationLayer;
using DataAccessLayer;
using MoreLinq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class AttendanceBLL
    {
        rainbowjanakpuriEntities dbcontext = new rainbowjanakpuriEntities();
        public Collection<AttendanceGridCL> viewAttendance(int sessionId)
        {
            Collection<AttendanceGridCL> queryAttendance = new Collection<AttendanceGridCL>();
            IEnumerable<Attendance> queryAttendanceDB = from x in dbcontext.Attendances where x.Student.Class.SessionId == sessionId && x.IsDeleted == false select x;
            queryAttendanceDB = queryAttendanceDB.DistinctBy(x => new { x.Student.ClassId, x.Date });
            foreach (Attendance item in queryAttendanceDB)
            {
                queryAttendance.Add(
                    new AttendanceGridCL()
                    {
                        dateCreated = item.DateCreated,
                        studentLeaveType = item.StudentLeaveType.Name,
                        dateModified = item.DateModified,
                        date = item.Date,
                        id = item.Id,
                        isDeleted = item.IsDeleted,
                        studentId = item.StudentId,
                        studentLeaveTypeId = item.StudentLeaveTypeId,
                        classId = item.Student.ClassId,
                        class1 = item.Student.Class.Class1,
                        section = item.Student.Class.Section,
                        noOfAbsentees = queryAttendance.Where(x => x.classId == item.Student.ClassId).Count(),
                    });
            }
            return queryAttendance;
        }
        public Collection<AttendanceGridCL> viewAttendanceSortedByDate(int sessionId)
        {
            Collection<AttendanceGridCL> queryAttendance = new Collection<AttendanceGridCL>();
            IEnumerable<Attendance> queryAttendanceDB = from x in dbcontext.Attendances where x.Student.Class.SessionId == sessionId && x.IsDeleted == false select x;
            queryAttendanceDB = queryAttendanceDB.DistinctBy(x => new { x.Student.ClassId, x.Date });
            queryAttendanceDB = queryAttendanceDB.OrderByDescending(x => x.Date);
            foreach (Attendance item in queryAttendanceDB)
            {
                queryAttendance.Add(
                    new AttendanceGridCL()
                    {
                        dateCreated = item.DateCreated,
                        studentLeaveType = item.StudentLeaveType.Name,
                        dateModified = item.DateModified,
                        date = item.Date,
                        id = item.Id,
                        isDeleted = item.IsDeleted,
                        studentId = item.StudentId,
                        studentLeaveTypeId = item.StudentLeaveTypeId,
                        classId = item.Student.ClassId,
                        class1 = item.Student.Class.Class1,
                        section = item.Student.Class.Section,
                        noOfAbsentees = (from x in dbcontext.Attendances where x.Student.ClassId == item.Student.ClassId && x.IsDeleted == false select x).DistinctBy(x => new { x.Student.ClassId, x.Date }).Count(),
                    });
            }
            return queryAttendance;
        }
        public AttendanceCL viewAttendanceByStudentIdandDate(int studentId, DateTime date)
        {
            Attendance queryAttendanceDB = (from x in dbcontext.Attendances where x.StudentId == studentId && x.Date == date && x.IsDeleted == false select x).FirstOrDefault();
            AttendanceCL attendanceCL = new AttendanceCL();
            if (queryAttendanceDB == null)
            {
                attendanceCL.studentLeaveTypeId = -1;
                attendanceCL.studentId = studentId;
            }
            else
            {
                attendanceCL.dateCreated = queryAttendanceDB.DateCreated;
                attendanceCL.studentLeaveType = queryAttendanceDB.StudentLeaveType.Name;
                attendanceCL.dateModified = queryAttendanceDB.DateModified;
                attendanceCL.date = queryAttendanceDB.Date;
                attendanceCL.id = queryAttendanceDB.Id;
                attendanceCL.isDeleted = queryAttendanceDB.IsDeleted;
                attendanceCL.studentId = queryAttendanceDB.StudentId;
                attendanceCL.studentLeaveTypeId = queryAttendanceDB.StudentLeaveTypeId;
                attendanceCL.classId = queryAttendanceDB.Student.ClassId;
                attendanceCL.class1 = queryAttendanceDB.Student.Class.Class1;
                attendanceCL.section = queryAttendanceDB.Student.Class.Section;
            }
            return attendanceCL;
        }
        public AttendanceCL viewAttendanceById(int attendanceId)
        {
            Attendance queryAttendanceDB = (from x in dbcontext.Attendances where x.Id == attendanceId && x.IsDeleted == false select x).FirstOrDefault();
            AttendanceCL attendanceCL = new AttendanceCL();
            if (queryAttendanceDB == null)
            {
                attendanceCL.studentLeaveTypeId = -1;
            }
            else
            {
                attendanceCL.dateCreated = queryAttendanceDB.DateCreated;
                attendanceCL.studentLeaveType = queryAttendanceDB.StudentLeaveType.Name;
                attendanceCL.dateModified = queryAttendanceDB.DateModified;
                attendanceCL.date = queryAttendanceDB.Date;
                attendanceCL.id = queryAttendanceDB.Id;
                attendanceCL.isDeleted = queryAttendanceDB.IsDeleted;
                attendanceCL.studentId = queryAttendanceDB.StudentId;
                attendanceCL.studentLeaveTypeId = queryAttendanceDB.StudentLeaveTypeId;
                attendanceCL.classId = queryAttendanceDB.Student.ClassId;
                attendanceCL.class1 = queryAttendanceDB.Student.Class.Class1;
                attendanceCL.section = queryAttendanceDB.Student.Class.Section;
            }
            return attendanceCL;
        }
        public Collection<AttendanceCL> addAttendance(Collection<AttendanceCL> attendanceInput)
        {
            Collection<AttendanceCL> returnAttendance = new Collection<AttendanceCL>();
            foreach (AttendanceCL item in attendanceInput)
            {
                Attendance attendanceQuery = dbcontext.Attendances.Add(new Attendance
                {
                    DateCreated = item.dateCreated,
                    DateModified = item.dateModified,
                    Date = item.date,
                    Id = item.id,
                    IsDeleted = item.isDeleted,
                    StudentId = item.studentId,
                    StudentLeaveTypeId = item.studentLeaveTypeId,
                });
                dbcontext.SaveChanges();
            }
            return returnAttendance;
        }
        public AttendanceCL updateAttendance(Collection<AttendanceCL> attendanceInput)
        {
            AttendanceCL returnAttendance = new AttendanceCL();
            foreach (AttendanceCL item in attendanceInput)
            {
                Attendance attendanceQuery = (from x in dbcontext.Attendances where x.Id == item.id select x).FirstOrDefault();
                if (attendanceQuery == null)
                {
                    Attendance attendanceQueryAdd = dbcontext.Attendances.Add(new Attendance
                    {
                        DateCreated = item.dateCreated,
                        DateModified = item.dateModified,
                        Date = item.date,
                        Id = item.id,
                        IsDeleted = item.isDeleted,
                        StudentId = item.studentId,
                        StudentLeaveTypeId = item.studentLeaveTypeId,
                    });
                    dbcontext.SaveChanges();
                }
                else
                {
                    attendanceQuery.Date = item.date;
                    attendanceQuery.DateCreated = item.dateCreated;
                    attendanceQuery.DateModified = item.dateModified;
                    attendanceQuery.Id = item.id;
                    attendanceQuery.IsDeleted = item.isDeleted;
                    attendanceQuery.StudentId = item.studentId;
                    attendanceQuery.StudentLeaveTypeId = item.studentLeaveTypeId;
                    dbcontext.SaveChanges();
                    returnAttendance.classId = attendanceQuery.Student.ClassId;
                    returnAttendance.date = attendanceQuery.Date;
                }
            }
            return returnAttendance;
        }
        public int deleteAttendance(Collection<AttendanceCL> attendanceInput)
        {
            int count = 0;
            foreach (AttendanceCL item in attendanceInput)
            {
                Attendance attendanceQuery = (from x in dbcontext.Attendances where x.Id == item.id select x).FirstOrDefault();
                attendanceQuery.Date = item.date;
                attendanceQuery.DateCreated = item.dateCreated;
                attendanceQuery.DateModified = item.dateModified;
                attendanceQuery.Id = item.id;
                attendanceQuery.IsDeleted = true;
                attendanceQuery.StudentId = item.studentId;
                attendanceQuery.StudentLeaveTypeId = item.studentLeaveTypeId;
                dbcontext.SaveChanges();
                count++;
            }
            return count;
        }
        public void deleteAttendanceCL(AttendanceCL attendanceInput)
        {
            Attendance attendanceQuery = (from x in dbcontext.Attendances where x.Id == attendanceInput.id select x).FirstOrDefault();
            attendanceQuery.IsDeleted = true;
            dbcontext.SaveChanges();
        }
        public SMSEntryCL addSMSEntry(SMSEntryCL smsEntryInput)
        {
            SMSEntry smsQuery = dbcontext.SMSEntries.Add(new SMSEntry
            {
                AttendanceId = smsEntryInput.attendanceId,
                DateCreated = smsEntryInput.dateCreated,
                IsDeleted = smsEntryInput.isDeleted,
                SMSTemplateId = smsEntryInput.smsTemplateId,
                MobileNumber = smsEntryInput.mobileNumber.ToString(),
            });
            dbcontext.SaveChanges();
            SMSEntryCL smsReturn = new SMSEntryCL
            {
                id = smsQuery.Id,
                attendanceId = smsQuery.AttendanceId,
                dateCreated = smsQuery.DateCreated,
                isDeleted = smsQuery.IsDeleted,
                smsTemplateId = smsQuery.SMSTemplateId,
                mobileNumber = smsEntryInput.mobileNumber,
            };
            return smsReturn;
        }
    }
}
