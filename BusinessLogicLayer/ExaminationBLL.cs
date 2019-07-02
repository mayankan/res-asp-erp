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
    public class ExaminationBLL
    {
        rainbowjanakpuriEntities dbcontext = new rainbowjanakpuriEntities();
        public Collection<ExaminationCL> viewExaminations(int sessionId)
        {
            Collection<ExaminationCL> queryExamination = new Collection<ExaminationCL>();
            IQueryable<Examination> queryExaminationDB = from x in dbcontext.Examinations where x.IsDeleted == false && x.Class.SessionId==sessionId select x;
            foreach (Examination item in queryExaminationDB)
            {
                queryExamination.Add(
                    new ExaminationCL()
                    {
                        name = item.Name,
                        id = item.Id,
                        classId = item.ClassId,
                        classSection = item.Class.Class1 + "-" + item.Class.Section,
                        dateCreated = item.DateCreated,
                        dateModified = item.DateModified,
                        isDeleted = item.IsDeleted,
                    });
            }
            return queryExamination;
        }
        public ExaminationCL viewExaminationById(int examId)
        {
            Examination queryExamDB = (from x in dbcontext.Examinations where x.Id == examId && x.IsDeleted == false select x).FirstOrDefault();
            ExaminationCL examinationCL = new ExaminationCL()
            {
                name = queryExamDB.Name,
                id = queryExamDB.Id,
                classSection = queryExamDB.Class.Class1 + "-" + queryExamDB.Class.Section,
                classId = queryExamDB.ClassId,
                dateCreated = queryExamDB.DateCreated,
                dateModified = queryExamDB.DateModified,
                isDeleted = queryExamDB.IsDeleted,
            };
            return examinationCL;
        }
        public Collection<ExaminationCL> viewExaminationsByClassId(int classId)
        {
            Collection<ExaminationCL> queryExamination = new Collection<ExaminationCL>();
            IQueryable<Examination> queryExaminationDB = from x in dbcontext.Examinations where x.ClassId== classId && x.IsDeleted == false select x;
            foreach (Examination item in queryExaminationDB)
            {
                queryExamination.Add(
                    new ExaminationCL()
                    {
                        name = item.Name,
                        id = item.Id,
                        classId = item.ClassId,
                        classSection = item.Class.Class1 + "-" + item.Class.Section,
                        dateCreated = item.DateCreated,
                        dateModified = item.DateModified,
                        isDeleted = item.IsDeleted,
                    });
            }
            return queryExamination;
        }
        public int addExamination(ExaminationCL examInput)
        {
            Examination examinationQuery = dbcontext.Examinations.Add(new Examination
            {
                Id = examInput.id,
                Name = examInput.name,
                ClassId= examInput.classId,
                DateCreated = examInput.dateCreated,
                DateModified = examInput.dateModified,
                IsDeleted = examInput.isDeleted,
            });
            dbcontext.SaveChanges();
            int ExaminationId = examinationQuery.Id;
            return ExaminationId;
        }
        public ExaminationCL updateExamination(ExaminationCL examInput)
        {
            ExaminationCL examReturn = new ExaminationCL();
            Examination examQuery = (from x in dbcontext.Examinations where x.Id == examInput.id select x).FirstOrDefault();
            examQuery.Name = examInput.name;
            examQuery.ClassId = examInput.classId;
            examQuery.DateCreated = examInput.dateCreated;
            examQuery.DateModified = examInput.dateModified;
            examQuery.IsDeleted = examInput.isDeleted;
            dbcontext.SaveChanges();
            examReturn.dateCreated = examQuery.DateCreated;
            examReturn.dateModified = examQuery.DateModified;
            examReturn.isDeleted = examQuery.IsDeleted;
            examReturn.id = examQuery.Id;
            examReturn.name = examQuery.Name;
            examReturn.classId = examQuery.ClassId;
            return examReturn;
        }
        public void deleteExamination(int examId)
        {
            Examination examQuery = (from x in dbcontext.Examinations where x.Id == examId select x).FirstOrDefault();
            examQuery.IsDeleted = true;
            dbcontext.SaveChanges();
        }
    }
}
