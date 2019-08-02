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
    public class ClassSubjectBLL
    {
        rainbowjanakpuriEntities dbcontext = new rainbowjanakpuriEntities();
        SubjectBLL subjectBLL = new SubjectBLL();
        public Collection<ClassSubjectMapGridCL> viewClassSubjectMaps(int sessionId)
        {
            Collection<ClassSubjectMapGridCL> subjectClassReturn = new Collection<ClassSubjectMapGridCL>();
            IQueryable<ClassSubjectMap> classSubjectData = from x in dbcontext.ClassSubjectMaps where x.IsDeleted == false && x.Class.SessionId==sessionId select x;
            classSubjectData = classSubjectData.GroupBy(x => x.ClassId).Select(y => y.FirstOrDefault());
            foreach (ClassSubjectMap item in classSubjectData)
            {
                subjectClassReturn.Add(new ClassSubjectMapGridCL()
                {
                    classId = item.ClassId,
                    id = item.Id,
                    sessionId = item.SessionId,
                    subjectId = item.SubjectId,
                    classSection = item.Class.Class1 + "-" + item.Class.Section,
                    noOfSubjects = item.Class.ClassSubjectMaps.Where(x=>x.IsDeleted==false).Count(),
                    subject = item.Subject.Name,
                    dateCreated = item.DateCreated,
                    dateModified = item.DateModified,
                    isDeleted = item.IsDeleted,
                });
            }
            return subjectClassReturn;
        }
        public Collection<ClassSubjectMapGridCL> viewClassSubjectMapsByClassId(int classId)
        {
            Collection<ClassSubjectMapGridCL> subjectClassReturn = new Collection<ClassSubjectMapGridCL>();
            IQueryable<ClassSubjectMap> classSubjectData = from x in dbcontext.ClassSubjectMaps where x.ClassId == classId && x.IsDeleted == false select x;
            foreach (ClassSubjectMap item in classSubjectData)
            {
                subjectClassReturn.Add(new ClassSubjectMapGridCL()
                {
                    classId = item.ClassId,
                    id = item.Id,
                    sessionId = item.SessionId,
                    subjectId = item.SubjectId,
                    classSection = item.Class.Class1 + "-" + item.Class.Section,
                    noOfSubjects = item.Class.ClassSubjectMaps.Count(),
                    subject = item.Subject.Name,
                    dateCreated = item.DateCreated,
                    dateModified = item.DateModified,
                    isDeleted = item.IsDeleted,
                });
            }
            return subjectClassReturn;
        }
        public bool addClassSubjectMap(int classId, Collection<ClassSubjectMapGridCL> subjectData)
        {
            bool flag = false;
            foreach (ClassSubjectMapGridCL item in subjectData)
            {
                int count =(from x in dbcontext.ClassSubjectMaps where x.ClassId == item.classId && x.SubjectId == item.subjectId && x.IsDeleted==false select x).Count();
                if (count>0)
                {
                    flag = true;
                }
                else
                {
                    ClassSubjectMap subjectClassMap = dbcontext.ClassSubjectMaps.Add(new ClassSubjectMap()
                    {
                        ClassId = classId,
                        SessionId = item.sessionId,
                        SubjectId = item.subjectId,
                        IsDeleted = false,
                        DateCreated = DateTime.Now,
                        DateModified = DateTime.Now,
                    });
                }
            }
            dbcontext.SaveChanges();
            return flag;
        }
        public bool updateClassSubjectMap(int classId, Collection<ClassSubjectMapGridCL> subjectData)
        {
            bool flag = false;
            Collection<SubjectCL> subjectCol = subjectBLL.viewSubjectByClassId(classId);
            Collection<ClassSubjectMapGridCL> classSubjectCol = new Collection<ClassSubjectMapGridCL>();
            foreach (SubjectCL item in subjectCol)
            {
                ClassSubjectMap query = (from x in dbcontext.ClassSubjectMaps where x.SubjectId == item.id select x).FirstOrDefault();
                classSubjectCol.Add(new ClassSubjectMapGridCL()
                {
                    classId = query.ClassId,
                    id = query.Id,
                    sessionId = query.SessionId,
                    subjectId = query.SubjectId,
                    classSection = query.Class.Class1 + "-" + query.Class.Section,
                    noOfSubjects = query.Class.ClassSubjectMaps.Count(),
                    subject = query.Subject.Name,
                    dateCreated = query.DateCreated,
                    dateModified = query.DateModified,
                    isDeleted = query.IsDeleted,
                });
            }
            var inputNotData = subjectData.Except(classSubjectCol);
            var dataNotInput = classSubjectCol.Except(subjectData);

            if (subjectData.Where(x=>classSubjectCol.Select(y=>y.subjectId).Contains(x.subjectId)).Count()>0)
            {
                foreach (var item in dataNotInput)
                {
                    ClassSubjectMap subjectClassMap = (from x in dbcontext.ClassSubjectMaps where x.ClassId == item.classId && x.SubjectId == item.subjectId && x.IsDeleted == false select x).FirstOrDefault();
                    if (subjectClassMap != null)
                        subjectClassMap.IsDeleted = true;
                }
                foreach (var item in inputNotData)
                {
                    ClassSubjectMap subjectClassMap = dbcontext.ClassSubjectMaps.Add(new ClassSubjectMap()
                    {
                        ClassId = classId,
                        SessionId = item.sessionId,
                        SubjectId = item.subjectId,
                        IsDeleted = false,
                        DateModified = DateTime.Now,
                        DateCreated = DateTime.Now,
                    });
                }
                dbcontext.SaveChanges();
            }
            else
            {
                flag = true;
            }
            return flag;
        }
        public int deleteClassSubjectMap(int classId, Collection<ClassSubjectMapGridCL> subjectData)
        {
            int count = 0;
            IQueryable<ClassSubjectMap> deleteClassSubject = from x in dbcontext.ClassSubjectMaps where x.ClassId == classId && x.IsDeleted == false select x;
            foreach (ClassSubjectMapGridCL item in subjectData)
            {
                ClassSubjectMap subjectClassMap = (from x in dbcontext.ClassSubjectMaps where x.ClassId == item.classId && x.SubjectId == item.subjectId && x.IsDeleted == false select x).FirstOrDefault();
                if (subjectClassMap != null)
                    subjectClassMap.IsDeleted = true;
            }
            dbcontext.SaveChanges();
            return count;
        }
    }
}
