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
    public class ClassBLL
    {
        rainbowjanakpuriEntities dbcontext = new rainbowjanakpuriEntities();
        /// <summary>
        /// This method fetches the data from the Database and Return Collection of Classes from the Database.
        /// </summary>
        /// <param name="sessionId">The id of Current Session or Session being used.</param>
        /// <returns></returns>
        public Collection<ClassCL> viewClasses(int sessionId)
        {
            Collection<ClassCL> queryClass = new Collection<ClassCL>();
            IQueryable<Class> queryClassDB = (from x in dbcontext.Classes where x.SessionId == sessionId && x.IsDeleted == false select x).OrderBy(x => x.Class1 + x.Section);
            int totalStrength = queryClassDB.Count();
            foreach (Class item in queryClassDB)
            {
                queryClass.Add(
                    new ClassCL()
                    {
                        class1 = item.Class1,
                        id = item.Id,
                        section = item.Section,
                        sessionId = item.SessionId,
                        totalStrength = item.Students.Count(),
                        dateCreated = item.DateCreated,
                        dateModified = item.DateModified,
                        isDeleted = item.IsDeleted,
                        classSection = item.Class1 + "-" + item.Section,
                    });
            }
            return queryClass;
        }
        /// <summary>
        /// This method fetches the particular Class via ClassId from the database.
        /// </summary>
        /// <param name="classId">Details of ClassId to be fetched</param>
        /// <returns></returns>
        public ClassCL viewClassById(int classId)
        {
            Class queryClassDB = (from x in dbcontext.Classes where x.Id == classId && x.IsDeleted == false select x).FirstOrDefault();
            ClassCL classCL = new ClassCL()
            {
                class1 = queryClassDB.Class1,
                id = queryClassDB.Id,
                section = queryClassDB.Section,
                sessionId = queryClassDB.SessionId,
                totalStrength = queryClassDB.Students.Count(),
                dateCreated = queryClassDB.DateCreated,
                dateModified = queryClassDB.DateModified,
                isDeleted = queryClassDB.IsDeleted,
                classSection = queryClassDB.Class1 + "-" + queryClassDB.Section,
            };
            return classCL;
        }
        /// <summary>
        /// Adds a class instance of Database from the client Data.
        /// </summary>
        /// <param name="classesInput">The input data from the client side.</param>
        /// <returns></returns>
        public int addClass(ClassCL classesInput)
        {
            Class classQuery = dbcontext.Classes.Add(new Class
            {
                Id = classesInput.id,
                Class1 = classesInput.class1,
                Section = classesInput.section,
                SessionId = classesInput.sessionId,
                DateCreated = classesInput.dateCreated,
                DateModified = classesInput.dateModified,
                IsDeleted = classesInput.isDeleted,
            });
            dbcontext.SaveChanges();
            int ClassId = classQuery.Id;
            return ClassId;
        }
        /// <summary>
        /// Updates the class instance of Database from the client data
        /// </summary>
        /// <param name="classesInput">Class Data from the Client Side.</param>
        /// <returns></returns>
        public ClassCL updateClass(ClassCL classesInput)
        {
            ClassCL classReturn = new ClassCL();
            Class classQuery = (from x in dbcontext.Classes where x.Id == classesInput.id select x).FirstOrDefault();
            classQuery.Class1 = classesInput.class1;
            classQuery.Section = classesInput.section;
            classQuery.SessionId = classesInput.sessionId;
            classQuery.DateCreated = classesInput.dateCreated;
            classQuery.DateModified = classesInput.dateModified;
            classQuery.IsDeleted = classesInput.isDeleted;
            dbcontext.SaveChanges();
            classReturn.dateCreated = classQuery.DateCreated;
            classReturn.dateModified = classQuery.DateModified;
            classReturn.isDeleted = classQuery.IsDeleted;
            classReturn.id = classQuery.Id;
            classReturn.class1 = classQuery.Class1;
            classReturn.section = classQuery.Section;
            classReturn.totalStrength = classQuery.Students.Count();
            return classReturn;
        }
        /// <summary>
        /// Updates the isDeleted column from the database.
        /// </summary>
        /// <param name="classesInput">Class Instance to be deleted.</param>
        public void deleteClass(int classId)
        {
            Class classQuery = (from x in dbcontext.Classes where x.Id == classId select x).FirstOrDefault();
            classQuery.IsDeleted = true;
            dbcontext.SaveChanges();
        }
        public int getSessionIdByClassId(int classId)
        {
            Class query = (from x in dbcontext.Classes where x.Id == classId && x.IsDeleted == false select x).FirstOrDefault();
            return query.SessionId;
        }
    }
}
