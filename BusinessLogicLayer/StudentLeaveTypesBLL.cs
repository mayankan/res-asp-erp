using CommunicationLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class StudentLeaveTypesBLL
    {
        rainbowjanakpuriEntities dbcontext = new rainbowjanakpuriEntities();
        /// <summary>
        /// This method fetches the data from the Database and Return Collection of Student Leave Types from the Database.
        /// </summary>
        /// <returns></returns>
        public Collection<StudentLeaveTypeCL> viewStudentLeaveTypes()
        {
            Collection<StudentLeaveTypeCL> querySLT = new Collection<StudentLeaveTypeCL>();
            IQueryable<StudentLeaveType> querySLTDB = from x in dbcontext.StudentLeaveTypes where x.IsDeleted == false select x;
            foreach (StudentLeaveType item in querySLTDB)
            {
                querySLT.Add(
                    new StudentLeaveTypeCL()
                    {
                        dateCreated = item.DateCreated,
                        dateModified = item.DateModified,
                        id = item.Id,
                        isDeleted = item.IsDeleted,
                        name = item.Name,
                    });
            }
            return querySLT;
        }
        /// <summary>
        /// This method fetches the particular Student Leave Types via SLT Id from the database.
        /// </summary>
        /// <param name="sltId">Details of SLT Id to be fetched</param>
        /// <returns></returns>
        public StudentLeaveTypeCL viewSLTById(int sltId)
        {
            StudentLeaveType item = (from x in dbcontext.StudentLeaveTypes where x.Id == sltId && x.IsDeleted == false select x).FirstOrDefault();
            StudentLeaveTypeCL sltCL = new StudentLeaveTypeCL()
            {
                dateCreated = item.DateCreated,
                dateModified = item.DateModified,
                id = item.Id,
                isDeleted = item.IsDeleted,
                name = item.Name,
            };
            return sltCL;
        }
        /// <summary>
        /// Adds a student leave type instance of Database from the client Data.
        /// </summary>
        /// <param name="sltInput">The input data from the client side.</param>
        /// <returns></returns>
        public int addSlt(StudentLeaveTypeCL sltInput)
        {
            StudentLeaveType sltQuery = dbcontext.StudentLeaveTypes.Add(new StudentLeaveType
            {
                Id = sltInput.id,
                Name = sltInput.name,
                DateCreated = sltInput.dateCreated,
                DateModified = sltInput.dateModified,
                IsDeleted = sltInput.isDeleted,
            });
            dbcontext.SaveChanges();
            int SltId = sltQuery.Id;
            return SltId;
        }
        /// <summary>
        /// Updates the Student Leave Type instance of Database from the client data.
        /// </summary>
        /// <param name="sltInput">Class Data from the Client Side.</param>
        /// <returns></returns>
        public StudentLeaveTypeCL updateSLT(StudentLeaveTypeCL sltInput)
        {
            StudentLeaveTypeCL sltReturn = new StudentLeaveTypeCL();
            StudentLeaveType sltQuery = (from x in dbcontext.StudentLeaveTypes where x.Id == sltInput.id select x).FirstOrDefault();
            sltQuery.Name = sltInput.name;
            sltQuery.DateCreated = sltInput.dateCreated;
            sltQuery.DateModified = sltInput.dateModified;
            sltQuery.IsDeleted = sltInput.isDeleted;
            dbcontext.SaveChanges();
            sltReturn.dateCreated = sltQuery.DateCreated;
            sltReturn.dateModified = sltQuery.DateModified;
            sltReturn.isDeleted = sltQuery.IsDeleted;
            sltReturn.name = sltQuery.Name;
            return sltReturn;
        }
        /// <summary>
        /// Updates the isDeleted column from the database.
        /// </summary>
        /// <param name="sltId">Student Leave Type Instance to be deleted.</param>
        public void deleteSLT(int sltId)
        {
            StudentLeaveType SLTQuery = (from x in dbcontext.StudentLeaveTypes where x.Id == sltId select x).FirstOrDefault();
            SLTQuery.IsDeleted = true;
            dbcontext.SaveChanges();
        }
    }
}
