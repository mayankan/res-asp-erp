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
    public class SMSBLL
    {
        rainbowjanakpuriEntities dbcontext = new rainbowjanakpuriEntities();
        /// <summary>
        /// This method fetches the data from the Database and Return Collection of SMS Templates from the Database.
        /// </summary>
        /// <returns></returns>
        public Collection<SMSCL> viewSMSTemplates()
        {
            Collection<SMSCL> querySMS = new Collection<SMSCL>();
            IQueryable<SM> querySMSDB = from x in dbcontext.SMS where x.IsDeleted == false select x;
            foreach (SM item in querySMSDB)
            {
                querySMS.Add(
                    new SMSCL()
                    {
                        dateCreated = item.DateCreated,
                        dateModified = item.DateModified,
                        id = item.Id,
                        isDeleted = item.IsDeleted,
                        studentLeaveTypeId = item.StudentLeaveTypeId,
                        template = item.Template,
                        studentLeaveType = item.StudentLeaveType.Name,
                    });
            }
            return querySMS;
        }
        /// <summary>
        /// This method fetches the particular SMS Templates via SMS Template Id from the database.
        /// </summary>
        /// <param name="smsId">Details of SMS Template Id to be fetched</param>
        /// <returns></returns>
        public SMSCL viewSMSTemplatesById(int smsId)
        {
            SM item = (from x in dbcontext.SMS where x.Id == smsId && x.IsDeleted == false select x).FirstOrDefault();
            SMSCL smsCL = new SMSCL()
            {
                dateCreated = item.DateCreated,
                dateModified = item.DateModified,
                id = item.Id,
                isDeleted = item.IsDeleted,
                studentLeaveTypeId = item.StudentLeaveTypeId,
                template = item.Template,
            };
            return smsCL;
        }
        /// <summary>
        /// Adds a student leave type instance of Database from the client Data.
        /// </summary>
        /// <param name="smsInput">The input data from the client side.</param>
        /// <returns></returns>
        public int addSMS(SMSCL smsInput)
        {
            SM smsQuery = dbcontext.SMS.Add(new SM
            {
                Id = smsInput.id,
                Template = smsInput.template,
                StudentLeaveTypeId = smsInput.studentLeaveTypeId,
                DateCreated = smsInput.dateCreated,
                DateModified = smsInput.dateModified,
                IsDeleted = smsInput.isDeleted,
            });
            dbcontext.SaveChanges();
            int SMSId = smsQuery.Id;
            return SMSId;
        }
        /// <summary>
        /// Updates the Student Leave Type instance of Database from the client data.
        /// </summary>
        /// <param name="smsInput">Class Data from the Client Side.</param>
        /// <returns></returns>
        public SMSCL updateSMS(SMSCL smsInput)
        {
            SMSCL smsReturn = new SMSCL();
            SM smsQuery = (from x in dbcontext.SMS where x.Id == smsInput.id select x).FirstOrDefault();
            smsQuery.StudentLeaveTypeId = smsInput.studentLeaveTypeId;
            smsQuery.Template = smsInput.template;
            smsQuery.DateCreated = smsInput.dateCreated;
            smsQuery.DateModified = smsInput.dateModified;
            smsQuery.IsDeleted = smsInput.isDeleted;
            dbcontext.SaveChanges();
            smsReturn.studentLeaveTypeId = smsQuery.StudentLeaveTypeId;
            smsReturn.template = smsQuery.Template;
            smsReturn.dateCreated = smsQuery.DateCreated;
            smsReturn.dateModified = smsQuery.DateModified;
            smsReturn.isDeleted = smsQuery.IsDeleted;
            return smsReturn;
        }
        /// <summary>
        /// Updates the isDeleted column from the database.
        /// </summary>
        /// <param name="smsId">Student Leave Type Instance to be deleted.</param>
        public void deleteSMS(int smsId)
        {
            SM SMSQuery = (from x in dbcontext.SMS where x.Id == smsId select x).FirstOrDefault();
            SMSQuery.IsDeleted = true;
            dbcontext.SaveChanges();
        }
    }
}
