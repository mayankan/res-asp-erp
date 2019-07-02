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
    public class SessionBLL
    {
        rainbowjanakpuriEntities dbcontext = new rainbowjanakpuriEntities();
        public Collection<SessionCL> viewSession()
        {
            Collection<SessionCL> querySession = new Collection<SessionCL>();
            IQueryable<Session> querySessionDB = from x in dbcontext.Sessions select x;
            foreach (Session item in querySessionDB)
            {
                querySession.Add(
                    new SessionCL()
                    {
                        id = item.Id,
                        startingYear = item.StartingYear,
                        endingYear = item.EndingYear,
                    });
            }
            return querySession;
        }
        public SessionCL viewSessionById(int sessionId)
        {
            Session querySessionDB = (from x in dbcontext.Sessions where x.Id == sessionId select x).FirstOrDefault();
            SessionCL SessionCL = new SessionCL()
            {
                id = querySessionDB.Id,
                endingYear = querySessionDB.EndingYear,
                startingYear = querySessionDB.StartingYear,
            };
            return SessionCL;
        }
        /// <summary>
        /// This method Checks If Session for current Year is there or Adds it if it is not there.
        /// </summary>
        /// <returns>SessionCL Class for Checked or Current Session.</returns>
        public SessionCL addorCheckSession()
        {
            SessionCL sessionCL = new SessionCL();
            bool sessionAvailable = false;
            foreach (SessionCL item in viewSession())
            {
                DateTime dateToday = new DateTime(item.endingYear, 03, 31);
                if (dateToday <= DateTime.Now)
                {
                    sessionAvailable = true;
                    sessionCL.id = item.id;
                    sessionCL.startingYear = item.startingYear;
                    sessionCL.endingYear = item.endingYear;
                }
            }
            if (sessionAvailable == false)
            {
                Session sessionQuery = dbcontext.Sessions.Add(new Session
                {
                    Id = 0,
                    StartingYear = (DateTime.Now.Year) - 1,
                    EndingYear = DateTime.Now.Year,
                });
                dbcontext.SaveChanges();
                sessionCL.id = sessionQuery.Id;
                sessionCL.startingYear = sessionQuery.StartingYear;
                sessionCL.endingYear = sessionQuery.EndingYear;
            };
            return sessionCL;
        }
        public LogCL createLog(LogCL logEntry)
        {
            Log entry = dbcontext.Logs.Add(new Log
            {
                Id = 0,
                DateOfAction = DateTime.Now,
                LogAction = logEntry.logAction,
                Module = logEntry.module,
                UserId = logEntry.userId,
            });
            //dbcontext.SaveChanges();
            LogCL logCL = new LogCL
            {
                dateOfAction = entry.DateOfAction,
                id = entry.Id,
                logAction = entry.LogAction,
                module = entry.Module,
                userId = entry.UserId,
            };
            return logCL;
        }
    }
}
