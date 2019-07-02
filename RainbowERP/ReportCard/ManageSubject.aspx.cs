using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAINBOW_ERP.ReportCard
{
    public partial class ManageStudent : System.Web.UI.Page
    {
        SubjectBLL subjectBLL = new SubjectBLL();
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
                        Response.Redirect("index.aspx");
                    }
                    else if (role.ToLower() == "teacher" || role.ToLower() == "attendanceo")
                    {
                        Response.Redirect("../UnAuthorized.aspx");
                    }
                    else
                    {
                        if (Request.QueryString["subjectId"] != null)
                        {
                            int subjectId = Convert.ToInt32(Request.QueryString["subjectId"]);
                            lblHeading.Text = "Update Subject";
                            SubjectCL subjectCL = subjectBLL.viewSubjectById(subjectId);
                            txtSubject.Text = subjectCL.name;
                            txtTotalStrength.Text = subjectCL.totalClasses.ToString();
                            txtDateCreated.Text = subjectCL.dateCreated.ToString("dd MMMM yyyy");
                            txtDateUpdated.Text = subjectCL.dateModified.ToString("dd MMMM yyyy");
                        }
                        else
                        {
                            lblHeading.Text = "Add Subject";
                        } 
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DateTime dateHosting = DateTime.UtcNow;
            TimeZoneInfo indianZoneId = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime dateNow = TimeZoneInfo.ConvertTimeFromUtc(dateHosting, indianZoneId);
            if (Request.QueryString["subjectId"] != null)
            {
                SubjectCL subjectCL = new SubjectCL();
                subjectCL.id = Convert.ToInt32(Request.QueryString["subjectId"]);
                subjectCL.name = txtSubject.Text;
                subjectCL.dateCreated = Convert.ToDateTime(txtDateCreated.Text);
                subjectCL.dateModified = dateNow;
                subjectCL.isDeleted = false;
                SubjectCL subjectReturn = subjectBLL.updateSubject(subjectCL);
                Response.Redirect("ManageSubject.aspx?subjectid=" + subjectReturn.id);
            }
            else
            {
                SubjectCL subjectCL = new SubjectCL();
                subjectCL.name = txtSubject.Text;
                subjectCL.dateCreated = dateNow;
                subjectCL.dateModified = dateNow;
                subjectCL.isDeleted = false;
                int subjectId = subjectBLL.addSubject(subjectCL);
                Response.Redirect("ManageSubject.aspx?subjectId=" + subjectId);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Subject.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}