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
    public class ReportCardEntryBLL
    {
        rainbowjanakpuriEntities dbcontext = new rainbowjanakpuriEntities();
        public Collection<MarksEntryGridCL> viewMarksGrid(int sessionId)
        {
            Collection<MarksEntryGridCL> returnMarksGrid = new Collection<MarksEntryGridCL>();
            IEnumerable<MarksEntry> queryMarksDB = from x in dbcontext.MarksEntries where x.IsDeleted == false && x.SessionId == sessionId select x;
            //queryMarksDB = queryMarksDB.GroupBy(x => x.ClassSubjectMap.ClassId).Select(y => y.FirstOrDefault());
            queryMarksDB = queryMarksDB.DistinctBy(x => new { x.ExaminationId, x.ClassSubjectId });
            foreach (MarksEntry item in queryMarksDB)
            {
                returnMarksGrid.Add(new MarksEntryGridCL()
                {
                    classId = item.ClassSubjectMap.ClassId,
                    classSection = item.ClassSubjectMap.Class.Class1 + "-" + item.ClassSubjectMap.Class.Section,
                    examinationId = item.ExaminationId,
                    examinationName = item.Examination.Name,
                    id = item.Id,
                    subjectId = item.ClassSubjectMap.SubjectId,
                    subjectName = item.ClassSubjectMap.Subject.Name,
                    classSubjectId = item.ClassSubjectId,
                });
            }
            return returnMarksGrid;
        }
        public Collection<MarksEntryCL> viewMarksByStudentId(int studentId, int examId)
        {
            Collection<MarksEntryCL> returnQueryMarksDB = new Collection<MarksEntryCL>();
            IQueryable<MarksEntry> queryMarksDB = from x in dbcontext.MarksEntries where x.StudentId == studentId && x.ExaminationId == examId && x.IsDeleted == false select x;
            foreach (MarksEntry item in queryMarksDB)
            {
                returnQueryMarksDB.Add(new MarksEntryCL()
                {
                    classId = item.ClassSubjectMap.ClassId,
                    classSubjectId = item.ClassSubjectId,
                    dateCreated = item.DateCreated,
                    dateModified = item.DateModified,
                    examinationId = item.ExaminationId,
                    isDeleted = item.IsDeleted,
                    marks = item.Marks,
                    sessionId = item.SessionId,
                    studentId = item.StudentId,
                    subjectId = item.ClassSubjectMap.SubjectId,
                    subjectName = item.ClassSubjectMap.Subject.Name,
                    id = item.Id,
                });
            }
            return returnQueryMarksDB;
        }
        public string viewMarksByStudentSubjectExam(int studentId, int subjectId, int examId)
        {
            MarksEntry queryMarksDB = (from x in dbcontext.MarksEntries where x.ClassSubjectMap.SubjectId == subjectId && x.ExaminationId == examId && x.StudentId == studentId && x.IsDeleted == false select x).FirstOrDefault();
            if (queryMarksDB == null)
            {
                return string.Empty;
            }
            else
            {
                return queryMarksDB.Marks;
            }
        }
        public int addMarksEntry(Collection<MarksEntryCL> marksEntryCol, int classId)
        {
            int count = 0;
            foreach (MarksEntryCL item in marksEntryCol)
            {
                MarksEntry marksQuery = dbcontext.MarksEntries.Add(new MarksEntry()
                {
                    ClassSubjectId = item.classSubjectId,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ExaminationId = item.examinationId,
                    IsDeleted = false,
                    Marks = item.marks,
                    SessionId = item.sessionId,
                    StudentId = item.studentId,
                });
                count++;
            }
            dbcontext.SaveChanges();
            return count;
        }
        public int updateMarksEntry(Collection<MarksEntryCL> marksEntryCol, int classId)
        {
            IQueryable<MarksEntry> queryMarksDB = from x in dbcontext.MarksEntries where x.ClassSubjectMap.ClassId == classId select x;
            foreach (MarksEntry item in queryMarksDB)
            {
                item.IsDeleted = true;
            }
            dbcontext.SaveChanges();
            int count = 0;
            foreach (MarksEntryCL item in marksEntryCol)
            {
                MarksEntry marksQuery = dbcontext.MarksEntries.Add(new MarksEntry()
                {
                    ClassSubjectId = item.classSubjectId,
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ExaminationId = item.examinationId,
                    IsDeleted = false,
                    Marks = item.marks,
                    SessionId = item.sessionId,
                    StudentId = item.studentId,
                });
                count++;
            }
            dbcontext.SaveChanges();
            return count;

        }
        public int deleteMarksEntry(int classId)
        {
            int count = 0;
            IQueryable<MarksEntry> queryMarksDB = from x in dbcontext.MarksEntries where x.ClassSubjectMap.ClassId == classId select x;
            foreach (MarksEntry item in queryMarksDB)
            {
                item.IsDeleted = true;
                count++;
            }
            dbcontext.SaveChanges();
            return count;
        }
        public void addMarksFromSubjectExam(int classId, int subjectId, int examId, Collection<MarksEntryCL> marksCol)
        {
            int classSubjectId = (from x in dbcontext.ClassSubjectMaps where x.ClassId == classId && x.SubjectId == subjectId select x.Id).FirstOrDefault();
            foreach (MarksEntryCL item in marksCol)
            {
                dbcontext.MarksEntries.Add(new MarksEntry()
                {
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ExaminationId = examId,
                    IsDeleted = false,
                    Marks = item.marks,
                    SessionId = item.sessionId,
                    StudentId = item.studentId,
                    ClassSubjectId = classSubjectId,
                });
            }
            dbcontext.SaveChanges();
        }
        public void updateMarksFromSubjectExam(int classId, int subjectId, int examId, Collection<MarksEntryCL> marksCol)
        {
            IQueryable<MarksEntry> queryMarksDB = from x in dbcontext.MarksEntries where x.ClassSubjectMap.ClassId == classId && x.ClassSubjectMap.SubjectId == subjectId && x.ExaminationId == examId && x.IsDeleted == false select x;
            int classSubjectId = (from x in dbcontext.MarksEntries where x.ClassSubjectMap.ClassId == classId && x.ClassSubjectMap.SubjectId == subjectId && x.ExaminationId == examId && x.IsDeleted == false select x.ClassSubjectId).FirstOrDefault();
            foreach (MarksEntry item in queryMarksDB)
            {
                dbcontext.MarksEntries.Remove(item);
            }
            dbcontext.SaveChanges();
            foreach (MarksEntryCL item in marksCol)
            {
                dbcontext.MarksEntries.Add(new MarksEntry()
                {
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ExaminationId = examId,
                    IsDeleted = false,
                    Marks = item.marks,
                    SessionId = item.sessionId,
                    StudentId = item.studentId,
                    ClassSubjectId = classSubjectId,
                });
            }
            dbcontext.SaveChanges();
        }
        public void deleteMarksFromSubjectExam(int classId, int subjectId, int examId)
        {
            IQueryable<MarksEntry> queryMarksDB = from x in dbcontext.MarksEntries where x.ClassSubjectMap.ClassId == classId && x.ClassSubjectMap.SubjectId == subjectId && x.ExaminationId == examId && x.IsDeleted == false select x;
            foreach (MarksEntry item in queryMarksDB)
            {
                dbcontext.MarksEntries.Remove(item);
            }
            dbcontext.SaveChanges();
        }


        public Collection<GradeEntryGridCL> viewGradesGrid(int sessionId)
        {
            Collection<GradeEntryGridCL> returnGradesGrid = new Collection<GradeEntryGridCL>();
            IEnumerable<GradeEntry> queryMarksDB = from x in dbcontext.GradeEntries where x.IsDeleted == false && x.SessionId == sessionId select x;
            //queryMarksDB = queryMarksDB.GroupBy(x => x.ClassSubjectMap.ClassId).Select(y => y.FirstOrDefault());
            queryMarksDB = queryMarksDB.DistinctBy(x => new { x.ExaminationId, x.ClassSubjectId });
            foreach (GradeEntry item in queryMarksDB)
            {
                returnGradesGrid.Add(new GradeEntryGridCL()
                {
                    classId = item.ClassSubjectMap.ClassId,
                    classSection = item.ClassSubjectMap.Class.Class1 + "-" + item.ClassSubjectMap.Class.Section,
                    examinationId = item.ExaminationId,
                    examinationName = item.Examination.Name,
                    id = item.Id,
                    subjectId = item.ClassSubjectMap.SubjectId,
                    subjectName = item.ClassSubjectMap.Subject.Name,
                    classSubjectId = item.ClassSubjectId,
                });
            }
            return returnGradesGrid;
        }
        public Collection<GradeEntryCL> viewGradesByStudentId(int studentId, int examId)
        {
            Collection<GradeEntryCL> returnQueryGradesDB = new Collection<GradeEntryCL>();
            IQueryable<GradeEntry> queryMarksDB = from x in dbcontext.GradeEntries where x.StudentId == studentId && x.ExaminationId == examId && x.IsDeleted == false select x;
            foreach (GradeEntry item in queryMarksDB)
            {
                returnQueryGradesDB.Add(new GradeEntryCL()
                {
                    classId = item.ClassSubjectMap.ClassId,
                    classSubjectId = item.ClassSubjectId,
                    dateCreated = item.DateCreated,
                    dateModified = item.DateModified,
                    examinationId = item.ExaminationId,
                    isDeleted = item.IsDeleted,
                    grade = item.Grade,
                    sessionId = item.SessionId,
                    studentId = item.StudentId,
                    subjectId = item.ClassSubjectMap.SubjectId,
                    subjectName = item.ClassSubjectMap.Subject.Name,
                    id = item.Id,
                });
            }
            return returnQueryGradesDB;
        }
        public string viewGradesByStudentSubjectExam(int studentId, int subjectId, int examId)
        {
            GradeEntry queryMarksDB = (from x in dbcontext.GradeEntries where x.ClassSubjectMap.SubjectId == subjectId && x.ExaminationId == examId && x.StudentId == studentId && x.IsDeleted == false  select x).FirstOrDefault();
            if (queryMarksDB == null)
            {
                return string.Empty;
            }
            else
            {
                return queryMarksDB.Grade;
            }
        }
        public Collection<GradeEntryGridCL> viewGradesGridPrimary()
        {
            Collection<GradeEntryGridCL> returnGradesGrid = new Collection<GradeEntryGridCL>();
            IEnumerable<GradeEntry> queryMarksDB = from x in dbcontext.GradeEntries where x.IsDeleted == false && (x.ClassSubjectMap.Class.Class1 == "1" || x.ClassSubjectMap.Class.Class1 == "2" || x.ClassSubjectMap.Class.Class1 == "3" || x.ClassSubjectMap.Class.Class1 == "4" || x.ClassSubjectMap.Class.Class1 == "5") select x;
            //queryMarksDB = queryMarksDB.GroupBy(x => x.ClassSubjectMap.ClassId).Select(y => y.FirstOrDefault());
            queryMarksDB = queryMarksDB.DistinctBy(x => new { x.ExaminationId, x.ClassSubjectId });
            foreach (GradeEntry item in queryMarksDB)
            {
                returnGradesGrid.Add(new GradeEntryGridCL()
                {
                    classId = item.ClassSubjectMap.ClassId,
                    classSection = item.ClassSubjectMap.Class.Class1 + "-" + item.ClassSubjectMap.Class.Section,
                    examinationId = item.ExaminationId,
                    examinationName = item.Examination.Name,
                    id = item.Id,
                    subjectId = item.ClassSubjectMap.SubjectId,
                    subjectName = item.ClassSubjectMap.Subject.Name,
                    classSubjectId = item.ClassSubjectId,
                });
            }
            return returnGradesGrid;
        }
        public Collection<GradeEntryCL> viewGradesByStudentIdPrimary(int studentId, int examId)
        {
            Collection<GradeEntryCL> returnQueryGradesDB = new Collection<GradeEntryCL>();
            IQueryable<GradeEntry> queryMarksDB = from x in dbcontext.GradeEntries where x.StudentId == studentId && x.ExaminationId == examId && (x.ClassSubjectMap.Class.Class1 == "1" || x.ClassSubjectMap.Class.Class1 == "2" || x.ClassSubjectMap.Class.Class1 == "3" || x.ClassSubjectMap.Class.Class1 == "4" || x.ClassSubjectMap.Class.Class1 == "5") select x;
            foreach (GradeEntry item in queryMarksDB)
            {
                returnQueryGradesDB.Add(new GradeEntryCL()
                {
                    classId = item.ClassSubjectMap.ClassId,
                    classSubjectId = item.ClassSubjectId,
                    dateCreated = item.DateCreated,
                    dateModified = item.DateModified,
                    examinationId = item.ExaminationId,
                    isDeleted = item.IsDeleted,
                    grade = item.Grade,
                    sessionId = item.SessionId,
                    studentId = item.StudentId,
                    subjectId = item.ClassSubjectMap.SubjectId,
                    subjectName = item.ClassSubjectMap.Subject.Name,
                    id = item.Id,
                });
            }
            return returnQueryGradesDB;
        }
        public string viewGradesByStudentSubjectExamPrimary(int studentId, int subjectId, int examId)
        {
            GradeEntry queryMarksDB = (from x in dbcontext.GradeEntries where x.ClassSubjectMap.SubjectId == subjectId && x.ExaminationId == examId && x.StudentId == studentId && x.IsDeleted == false && (x.ClassSubjectMap.Class.Class1 == "1" || x.ClassSubjectMap.Class.Class1 == "2" || x.ClassSubjectMap.Class.Class1 == "3" || x.ClassSubjectMap.Class.Class1 == "4" || x.ClassSubjectMap.Class.Class1 == "5") select x).FirstOrDefault();
            if (queryMarksDB == null)
            {
                return string.Empty;
            }
            else
            {
                return queryMarksDB.Grade;
            }
        }
        public void addGradesFromSubjectExam(int classId, int subjectId, int examId, Collection<GradeEntryCL> gradesCol)
        {
            int classSubjectId = (from x in dbcontext.ClassSubjectMaps where x.ClassId == classId && x.SubjectId == subjectId select x.Id).FirstOrDefault();
            foreach (GradeEntryCL item in gradesCol)
            {
                dbcontext.GradeEntries.Add(new GradeEntry()
                {
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ExaminationId = examId,
                    IsDeleted = false,
                    Grade = item.grade,
                    SessionId = item.sessionId,
                    StudentId = item.studentId,
                    ClassSubjectId = classSubjectId,
                });
            }
            dbcontext.SaveChanges();
        }
        public void updateGradesFromSubjectExam(int classId, int subjectId, int examId, Collection<GradeEntryCL> gradesCol)
        {
            IQueryable<GradeEntry> queryGradesDB = from x in dbcontext.GradeEntries where x.ClassSubjectMap.ClassId == classId && x.ClassSubjectMap.SubjectId == subjectId && x.ExaminationId == examId && x.IsDeleted == false select x;
            int classSubjectId = (from x in dbcontext.GradeEntries where x.ClassSubjectMap.ClassId == classId && x.ClassSubjectMap.SubjectId == subjectId && x.ExaminationId == examId && x.IsDeleted == false select x.ClassSubjectId).FirstOrDefault();
            foreach (GradeEntry item in queryGradesDB)
            {
                dbcontext.GradeEntries.Remove(item);
            }
            dbcontext.SaveChanges();
            foreach (GradeEntryCL item in gradesCol)
            {
                dbcontext.GradeEntries.Add(new GradeEntry()
                {
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ExaminationId = examId,
                    IsDeleted = false,
                    Grade = item.grade,
                    SessionId = item.sessionId,
                    StudentId = item.studentId,
                    ClassSubjectId = classSubjectId,
                });
            }
            dbcontext.SaveChanges();
        }
        public void deleteGradesFromSubjectExam(int classId, int subjectId, int examId)
        {
            IQueryable<GradeEntry> queryGradesDB = from x in dbcontext.GradeEntries where x.ClassSubjectMap.ClassId == classId && x.ClassSubjectMap.SubjectId == subjectId && x.ExaminationId == examId && x.IsDeleted == false select x;
            foreach (GradeEntry item in queryGradesDB)
            {
                dbcontext.GradeEntries.Remove(item);
            }
            dbcontext.SaveChanges();
        }

        public Collection<MiscEntryGridCL> viewMiscellaneous(int sessionId)
        {
            Collection<MiscEntryGridCL> returnMisc = new Collection<MiscEntryGridCL>();
            IEnumerable<MiscEntry> queryMiscDB = from x in dbcontext.MiscEntries where x.IsDeleted == false && x.SessionId == sessionId select x;
            //queryMarksDB = queryMarksDB.GroupBy(x => x.ClassSubjectMap.ClassId).Select(y => y.FirstOrDefault());
            queryMiscDB = queryMiscDB.DistinctBy(x => new { x.ExaminationId, x.Student.ClassId });
            foreach (MiscEntry item in queryMiscDB)
            {
                returnMisc.Add(new MiscEntryGridCL()
                {
                    classId = item.Student.ClassId,
                    attendance = item.Attendance,
                    remarks = item.Remarks,
                    classSection = item.Student.Class.Class1 + "-" + item.Student.Class.Section,
                    examinationId = item.ExaminationId,
                    examinationName = item.Examination.Name,
                    id = item.Id,
                });
            }
            return returnMisc;
        }
        public MiscEntryCL viewMiscByStudentId(int studentId, int examId)
        {
            MiscEntryCL miscEntry = new MiscEntryCL();
            MiscEntry queryMiscDB = (from x in dbcontext.MiscEntries where x.ExaminationId == examId && x.StudentId == studentId && x.IsDeleted == false select x).FirstOrDefault();
            if (queryMiscDB == null)
            {
                miscEntry.attendance = string.Empty;
                miscEntry.remarks = string.Empty;
            }
            else
            {
                miscEntry.attendance = queryMiscDB.Attendance;
                miscEntry.remarks = queryMiscDB.Remarks;
            }
            return miscEntry;
        }
        public void addMiscFromClassExam(int classId, int examId, Collection<MiscEntryCL> miscCol)
        {
            int classSubjectId = (from x in dbcontext.ClassSubjectMaps where x.ClassId == classId select x.Id).FirstOrDefault();
            foreach (MiscEntryCL item in miscCol)
            {
                dbcontext.MiscEntries.Add(new MiscEntry()
                {
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now,
                    ExaminationId = examId,
                    IsDeleted = false,
                    Attendance = item.attendance,
                    Remarks = item.remarks,
                    SessionId = item.sessionId,
                    StudentId = item.studentId,
                    ClassSubjectId = classSubjectId,
                });
            }
            dbcontext.SaveChanges();
        }
        public void updateMiscFromClassExam(int classId, int examId, Collection<MiscEntryCL> miscCol)
        {
            foreach (MiscEntryCL item in miscCol)
            {
                MiscEntry queryMiscDB = (from x in dbcontext.MiscEntries where x.ExaminationId == examId && x.StudentId == item.studentId && x.IsDeleted == false select x).FirstOrDefault();
                if(queryMiscDB==null)
                {
                    dbcontext.MiscEntries.Add(new MiscEntry()
                    {
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                        ExaminationId = examId,
                        IsDeleted = false,
                        Attendance = item.attendance,
                        Remarks = item.remarks,
                        SessionId = item.sessionId,
                        StudentId = item.studentId,
                        ClassSubjectId = 0,
                    });
                }
                else
                {
                    queryMiscDB.DateModified = DateTime.Now;
                    queryMiscDB.Attendance = item.attendance;
                    queryMiscDB.Remarks = item.remarks; 
                }
                dbcontext.SaveChanges();
            }
        }
        public void deleteMiscFromClassExam(int classId, int examId)
        {
            var queryMiscDB = from x in dbcontext.MiscEntries where x.Student.ClassId == classId && x.ExaminationId == examId && x.IsDeleted == false select x;
            foreach (MiscEntry item in queryMiscDB)
            {
                item.IsDeleted = true;
            }
            dbcontext.SaveChanges();
        }

        //public Collection<GradeEntryGridCL> viewGradesByStudentId(int studentId)
        //{
        //    Collection<GradeEntryGridCL> returnQueryMarksDB = new Collection<GradeEntryGridCL>();
        //    IQueryable<GradeEntry> queryMarksDB = from x in dbcontext.GradeEntries where x.StudentId == studentId && x.IsDeleted == false select x;
        //    foreach (GradeEntry item in queryMarksDB)
        //    {
        //        returnQueryMarksDB.Add(new MarksEntryCL()
        //        {
        //            classId = item.ClassSubjectMap.ClassId,
        //            classSubjectId = item.ClassSubjectId,
        //            dateCreated = item.DateCreated,
        //            dateModified = item.DateModified,
        //            examinationId = item.ExaminationId,
        //            isDeleted = item.IsDeleted,
        //            gr = item.Grade,
        //            sessionId = item.SessionId,
        //            studentId = item.StudentId,
        //            subjectId = item.ClassSubjectMap.SubjectId,
        //        });
        //    }
        //    return returnQueryMarksDB;
        //}
        //public int addMarksEntry(Collection<MarksEntryCL> marksEntryCol, int classId)
        //{
        //    int count = 0;
        //    foreach (MarksEntryCL item in marksEntryCol)
        //    {
        //        MarksEntry marksQuery = dbcontext.MarksEntries.Add(new MarksEntry()
        //        {
        //            ClassSubjectId = item.classSubjectId,
        //            DateCreated = DateTime.Now,
        //            DateModified = DateTime.Now,
        //            ExaminationId = item.examinationId,
        //            IsDeleted = false,
        //            Marks = item.marks,
        //            SessionId = item.sessionId,
        //            StudentId = item.studentId,
        //        });
        //        count++;
        //    }
        //    dbcontext.SaveChanges();
        //    return count;
        //}
        //public int updateMarksEntry(Collection<MarksEntryCL> marksEntryCol, int classId)
        //{
        //    IQueryable<MarksEntry> queryMarksDB = from x in dbcontext.MarksEntries where x.ClassSubjectMap.ClassId == classId select x;
        //    foreach (MarksEntry item in queryMarksDB)
        //    {
        //        item.IsDeleted = true;
        //    }
        //    dbcontext.SaveChanges();
        //    int count = 0;
        //    foreach (MarksEntryCL item in marksEntryCol)
        //    {
        //        MarksEntry marksQuery = dbcontext.MarksEntries.Add(new MarksEntry()
        //        {
        //            ClassSubjectId = item.classSubjectId,
        //            DateCreated = DateTime.Now,
        //            DateModified = DateTime.Now,
        //            ExaminationId = item.examinationId,
        //            IsDeleted = false,
        //            Marks = item.marks,
        //            SessionId = item.sessionId,
        //            StudentId = item.studentId,
        //        });
        //        count++;
        //    }
        //    dbcontext.SaveChanges();
        //    return count;

        //}
        //public int deleteMarksEntry(int classId)
        //{
        //    int count = 0;
        //    IQueryable<MarksEntry> queryMarksDB = from x in dbcontext.MarksEntries where x.ClassSubjectMap.ClassId == classId select x;
        //    foreach (MarksEntry item in queryMarksDB)
        //    {
        //        item.IsDeleted = true;
        //        count++;
        //    }
        //    dbcontext.SaveChanges();
        //    return count;
        //}

        public int viewExamIdByClass(int classId, string name)
        {
            Examination queryExamId = (from x in dbcontext.Examinations where x.ClassId == classId && x.Name == name && x.IsDeleted == false select x).FirstOrDefault();
            if (queryExamId == null)
            {
                return 10000;
            }
            else
            {
                return queryExamId.Id;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="classId"></param>
        /// <param name="examId"></param>
        /// <param name="subjectId"></param>
        /// <returns>True if Entry is Not there</returns>
        public bool CheckMarksEntry(int classId, int examId, int subjectId)
        {
            bool returnType;
            var query = from x in dbcontext.MarksEntries where x.ExaminationId == examId && x.Student.ClassId == classId && x.ClassSubjectMap.SubjectId == subjectId select x;
            if (query.Count() == 0)
                returnType = true;
            else
                returnType = false;
            return returnType;
        }
        public bool CheckGradesEntry(int classId, int examId, int subjectId)
        {
            bool returnType;
            var query = from x in dbcontext.GradeEntries where x.ExaminationId == examId && x.Student.ClassId == classId && x.ClassSubjectMap.SubjectId == subjectId select x;
            if (query.Count() == 0)
                returnType = true;
            else
                returnType = false;
            return returnType;
        }
        public bool CheckMiscEntry(int classId, int examId)
        {
            bool returnType;
            var query = from x in dbcontext.MiscEntries where x.ExaminationId == examId && x.Student.ClassId == classId && x.IsDeleted==false select x;
            if (query.Count() == 0)
                returnType = true;
            else
                returnType = false;
            return returnType;
        }
    }
}
