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
    public partial class ManageClass : System.Web.UI.Page
    {
        ClassBLL classBLL = new ClassBLL();
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
                    else
                    {
                        if (Request.QueryString["classId"] != null)
                        {
                            int classId = Convert.ToInt32(Request.QueryString["classId"]);
                            lblHeading.Text = "Update Class";
                            ClassCL classCL = classBLL.viewClassById(classId);
                            txtClass.Text = classCL.class1;
                            txtSection.Text = classCL.section;
                            txtTotalStrength.Text = classCL.totalStrength.ToString();
                            txtDateCreated.Text = classCL.dateCreated.ToString("dd MMMM yyyy");
                            txtDateUpdated.Text = classCL.dateModified.ToString("dd MMMM yyyy");
                        }
                        else
                        {
                            lblHeading.Text = "Add Class";
                        }
                    }
                }
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Class.aspx");
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DateTime dateHosting = DateTime.UtcNow;
            TimeZoneInfo indianZoneId = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime dateNow = TimeZoneInfo.ConvertTimeFromUtc(dateHosting, indianZoneId);
            if (Request.QueryString["classId"] != null)
            {
                ClassCL classCL = new ClassCL();
                classCL.id = Convert.ToInt32(Request.QueryString["classId"]);
                classCL.class1 = txtClass.Text;
                classCL.section = txtSection.Text;
                classCL.sessionId = Convert.ToInt32(Session["sessionId"]);
                classCL.dateCreated = Convert.ToDateTime(txtDateCreated.Text);
                classCL.dateModified = dateNow;
                classCL.isDeleted = false;
                ClassCL classReturn = classBLL.updateClass(classCL);
                Response.Redirect("ManageClass.aspx?classid=" + classReturn.id);
            }
            else
            {
                ClassCL classCL = new ClassCL();
                classCL.class1 = txtClass.Text;
                classCL.section = txtSection.Text;
                classCL.sessionId = Convert.ToInt32(Session["sessionId"]);
                classCL.dateCreated= dateNow;
                classCL.dateModified= dateNow;
                classCL.isDeleted = false;
                int classId = classBLL.addClass(classCL);
                Response.Redirect("ManageClass.aspx?classId=" + classId);
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}