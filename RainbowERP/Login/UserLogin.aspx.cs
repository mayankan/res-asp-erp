using BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAINBOW_ERP.Login
{
    public partial class UserLogin : System.Web.UI.Page
    {
        UserBLL userBLL = new UserBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            int userId = 0;
            string roles = string.Empty;
            Dictionary<int, string> getUser = userBLL.UserLogin(Login1.UserName, Login1.Password);
            userId = getUser.FirstOrDefault().Key;
            roles = getUser.FirstOrDefault().Value+";"+Login1.UserName;
            string userData = userId + ";" + getUser.FirstOrDefault().Value; //Includes userId & role of User
            switch (getUser.Keys.FirstOrDefault())
            {
                case -1:
                    Login1.FailureText = "Username and/or password is incorrect.";
                    break;
                case -2:
                    Login1.FailureText = "Account has not been activated.";
                    break;
                default:
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, Login1.UserName, DateTime.Now, DateTime.Now.AddMinutes(20), Login1.RememberMeSet, userData, FormsAuthentication.FormsCookiePath);
                    string hash = FormsAuthentication.Encrypt(ticket);
                    //HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                    //if (ticket.IsPersistent)
                    //{
                    //    cookie.Expires = ticket.Expiration;
                    //}
                    //Response.Cookies.Add(cookie);
                    if (ticket.IsPersistent)
                    {
                        Session.Remove("auth");
                    }
                    Session["auth"] = hash;
                    //Session["role"] = roles;
                    //Session["user"] = userId;
                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
                    break;
            }
        }
    }
}