using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAINBOW_ERP.Student
{
    public partial class Session : System.Web.UI.Page
    {
        SessionBLL sessionBLL = new SessionBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Request.IsAuthenticated)
                {
                    FormsAuthentication.RedirectToLoginPage();
                }
                else
                {
                    FormsAuthenticationTicket ticket = (FormsAuthentication.Decrypt(Session["auth"].ToString()));
                    string userId = ticket.UserData.Split(';')[0];
                    string role = ticket.UserData.Split(';')[1];
                    if (Session["sessionId"] == null)
                    {
                        SessionCL sessionCL = sessionBLL.addorCheckSession();
                        Session["sessionId"] = sessionCL.id;
                    }
                    else if (role.ToLower() == "teacher" || role.ToLower() == "attendanceo")
                    {
                        Response.Redirect("../UnAuthorized.aspx");
                    }
                    grdSession.DataSource = sessionBLL.viewSession();
                    grdSession.DataBind();
                }
            }
        }

        protected void grdSession_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int sessionId = Convert.ToInt32(e.CommandArgument);
            Session["sessionId"] = sessionId;
            Response.Redirect("Session.aspx");
        }
        
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void grdSession_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdSession.PageIndex = e.NewPageIndex;
                grdSession.DataSource = sessionBLL.viewSession();
                grdSession.DataBind();
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.Message));
            }
        }
    }
}