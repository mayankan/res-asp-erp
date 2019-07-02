using CommunicationLayer;
using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class UserBLL
    {
        rainbowjanakpuriEntities dbcontext = new rainbowjanakpuriEntities();
        public Dictionary<int, string> UserLogin(string userName, string password)
        {
            User getUser = (from x in dbcontext.Users where x.Username == userName && x.Password == password && x.IsDeleted == false select x).FirstOrDefault();
            Role getRole = (from x in dbcontext.Users where x.Username == userName && x.Password == password select x.Role).FirstOrDefault();
            Dictionary<int, string> UserDetails = new Dictionary<int, string>();
            if (getUser == null)
            {
                UserDetails.Add(-1, "");
            }
            else if (getRole == null)
            {
                UserDetails.Add(-2, "");
            }
            else
            {
                UserDetails.Add(getUser.Id, getUser.Role.RoleName);
                getUser.DateModified = DateTime.Now;
                dbcontext.Logs.Add(new Log
                {
                    Id = 79,
                    DateOfAction = DateTime.Now,
                    LogAction = getUser.Username + " - Logged In",
                    Module = "Dashboard",
                    UserId = getUser.Id,
                });
                dbcontext.SaveChanges();
            }
            return UserDetails;
        }
    }
}
