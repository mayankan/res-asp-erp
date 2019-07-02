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
    public class StudentCategoryBLL
    {
        rainbowjanakpuriEntities dbcontext = new rainbowjanakpuriEntities();
        public Collection<StudentCategoryCL> viewStudentCategories()
        {
            Collection<StudentCategoryCL> queryStudentCategory = new Collection<StudentCategoryCL>();
            IQueryable<StudentCategory> queryStudentCategoryDB = from x in dbcontext.StudentCategories where x.IsDeleted==false select x;
            foreach (StudentCategory item in queryStudentCategoryDB)
            {
                queryStudentCategory.Add(
                    new StudentCategoryCL()
                    {
                        id = item.Id,
                        name = item.Name,
                        dateCreated=item.DateCreated,
                        dateModified=item.DateModified,
                        isDeleted=item.IsDeleted,
                        totalStrength=item.Students.Count(),
                    });
            }
            return queryStudentCategory;
        }
        public StudentCategoryCL viewSCById(int scId)
        {
            StudentCategory querySCDB = (from x in dbcontext.StudentCategories where x.Id == scId && x.IsDeleted==false select x).FirstOrDefault();
            StudentCategoryCL scCL = new StudentCategoryCL()
            {
                id = querySCDB.Id,
                name = querySCDB.Name,
                dateCreated=querySCDB.DateCreated,
                dateModified=querySCDB.DateModified,
                isDeleted=querySCDB.IsDeleted,
                totalStrength = querySCDB.Students.Count(),
            };
            return scCL;
        }
        public int addSC(StudentCategoryCL scInput)
        {
            StudentCategory scQuery = dbcontext.StudentCategories.Add(new StudentCategory
            {
                Id = scInput.id,
                Name = scInput.name,
                DateCreated=scInput.dateCreated,
                DateModified=scInput.dateModified,
                IsDeleted=scInput.isDeleted,
            });
            dbcontext.SaveChanges();
            int SCId = scQuery.Id;
            return SCId;
        }
        public StudentCategoryCL updateSC(StudentCategoryCL scInput)
        {
            StudentCategoryCL scReturn = new StudentCategoryCL();
            StudentCategory scQuery = (from x in dbcontext.StudentCategories where x.Id == scInput.id select x).FirstOrDefault();
            scQuery.Id = scInput.id;
            scQuery.Name = scInput.name;
            scQuery.IsDeleted = scInput.isDeleted;
            scQuery.DateCreated = scInput.dateCreated;
            scQuery.DateModified = scInput.dateModified;
            dbcontext.SaveChanges();
            scReturn.id = scQuery.Id;
            scReturn.name = scQuery.Name;
            scReturn.dateCreated = scQuery.DateCreated;
            scReturn.dateModified = scQuery.DateModified;
            scReturn.isDeleted = scQuery.IsDeleted;
            return scReturn;
        }
        public void deleteSC(int scId)
        {
            StudentCategory scQuery = (from x in dbcontext.StudentCategories where x.Id == scId select x).FirstOrDefault();
            scQuery.IsDeleted = true;
            dbcontext.SaveChanges();
        }
    }
}
