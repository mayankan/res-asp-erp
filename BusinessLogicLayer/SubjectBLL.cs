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
    public class SubjectBLL
    {
        rainbowjanakpuriEntities dbcontext = new rainbowjanakpuriEntities();
        public Collection<SubjectCL> viewSubjects()
        {
            Collection<SubjectCL> querySubject = new Collection<SubjectCL>();
            IQueryable<Subject> querySubjectDB = from x in dbcontext.Subjects where x.IsDeleted == false select x;
            foreach (Subject item in querySubjectDB)
            {
                querySubject.Add(
                    new SubjectCL()
                    {
                        name = item.Name,
                        id = item.Id,
                        totalClasses = item.ClassSubjectMaps.Count(),
                        dateCreated = item.DateCreated,
                        dateModified = item.DateModified,
                        isDeleted = item.IsDeleted,
                    });
            }
            return querySubject;
        }
        public SubjectCL viewSubjectById(int subjectId)
        {
            Subject querySubjectDB = (from x in dbcontext.Subjects where x.Id == subjectId && x.IsDeleted == false select x).FirstOrDefault();
            SubjectCL subjectCL = new SubjectCL()
            {
                name = querySubjectDB.Name,
                id = querySubjectDB.Id,
                totalClasses = querySubjectDB.ClassSubjectMaps.Count(),
                dateCreated = querySubjectDB.DateCreated,
                dateModified = querySubjectDB.DateModified,
                isDeleted = querySubjectDB.IsDeleted,
            };
            return subjectCL;
        }
        public Collection<SubjectCL> viewSubjectByClassId(int classId)
        {
            Collection<SubjectCL> returnSubjectData = new Collection<SubjectCL>();
            IQueryable<Subject> querySubjectDB = from x in dbcontext.ClassSubjectMaps where x.ClassId == classId && x.IsDeleted == false select x.Subject;
            foreach (Subject item in querySubjectDB)
            {
                returnSubjectData.Add(new SubjectCL()
                {
                    name = item.Name,
                    id = item.Id,
                    totalClasses = item.ClassSubjectMaps.Count(),
                    dateCreated = item.DateCreated,
                    dateModified = item.DateModified,
                    isDeleted = item.IsDeleted,
                });
            }
            return returnSubjectData;
        }
        public Collection<SubjectCL> viewSubjectMarksByClassId(int classId)
        {
            Collection<SubjectCL> returnSubjectData = new Collection<SubjectCL>();
            IQueryable<Subject> querySubjectDB = from x in dbcontext.ClassSubjectMaps where x.ClassId == classId  && x.IsDeleted == false && (x.SubjectId<67 || x.SubjectId>71) select x.Subject;
            foreach (Subject item in querySubjectDB)
            {
                returnSubjectData.Add(new SubjectCL()
                {
                    name = item.Name,
                    id = item.Id,
                    totalClasses = item.ClassSubjectMaps.Count(),
                    dateCreated = item.DateCreated,
                    dateModified = item.DateModified,
                    isDeleted = item.IsDeleted,
                });
            }
            return returnSubjectData;
        }
        public Collection<SubjectCL> viewSubjectGradesByClassId(int classId)
        {
            Collection<SubjectCL> returnSubjectData = new Collection<SubjectCL>();
            IQueryable<Subject> querySubjectDB = from x in dbcontext.ClassSubjectMaps where x.ClassId == classId && ((x.SubjectId==51||x.SubjectId==52||x.SubjectId==53||x.SubjectId==119||x.SubjectId==120)||(x.SubjectId > 66 && x.SubjectId < 72)) && x.IsDeleted == false select x.Subject;
            foreach (Subject item in querySubjectDB)
            {
                returnSubjectData.Add(new SubjectCL()
                {
                    name = item.Name,
                    id = item.Id,
                    totalClasses = item.ClassSubjectMaps.Count(),
                    dateCreated = item.DateCreated,
                    dateModified = item.DateModified,
                    isDeleted = item.IsDeleted,
                });
            }
            return returnSubjectData;
        }
        public int addSubject(SubjectCL subjectsInput)
        {
            Subject subjectQuery = dbcontext.Subjects.Add(new Subject
            {
                Id = subjectsInput.id,
                Name = subjectsInput.name,
                DateCreated = subjectsInput.dateCreated,
                DateModified = subjectsInput.dateModified,
                IsDeleted = subjectsInput.isDeleted,
            });
            dbcontext.SaveChanges();
            int SubjectId = subjectQuery.Id;
            return SubjectId;
        }
        public SubjectCL updateSubject(SubjectCL subjectInput)
        {
            SubjectCL subjectReturn = new SubjectCL();
            Subject subjectQuery = (from x in dbcontext.Subjects where x.Id == subjectInput.id && x.IsDeleted == false select x).FirstOrDefault();
            subjectQuery.Name = subjectInput.name;
            subjectQuery.DateCreated = subjectInput.dateCreated;
            subjectQuery.DateModified = subjectInput.dateModified;
            subjectQuery.IsDeleted = subjectInput.isDeleted;
            dbcontext.SaveChanges();
            subjectReturn.dateCreated = subjectQuery.DateCreated;
            subjectReturn.dateModified = subjectQuery.DateModified;
            subjectReturn.isDeleted = subjectQuery.IsDeleted;
            subjectReturn.id = subjectQuery.Id;
            subjectReturn.name = subjectQuery.Name;
            subjectReturn.totalClasses = subjectQuery.ClassSubjectMaps.Count();
            return subjectReturn;
        }
        public void deleteSubject(int subjectId)
        {
            Subject subjectQuery = (from x in dbcontext.Subjects where x.Id == subjectId && x.IsDeleted == false select x).FirstOrDefault();
            subjectQuery.IsDeleted = true;
            dbcontext.SaveChanges();
        }
    }
}
