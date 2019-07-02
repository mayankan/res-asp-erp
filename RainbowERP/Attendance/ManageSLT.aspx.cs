using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAINBOW_ERP.Attendance
{
    public partial class ManageSLT : System.Web.UI.Page
    {
        StudentLeaveTypesBLL studentSLT = new StudentLeaveTypesBLL();
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
                        if (Request.QueryString["sltId"] != null)
                        {
                            int sltId = Convert.ToInt32(Request.QueryString["sltId"]);
                            lblHeading.Text = "Update Student Leave Type";
                            StudentLeaveTypeCL sltCL = studentSLT.viewSLTById(sltId);
                            txtSLTName.Text = sltCL.name;
                            txtDateCreated.Text = sltCL.dateCreated.ToString("dd MMMM yyyy");
                            txtDateUpdated.Text = sltCL.dateModified.ToString("dd MMMM yyyy");
                        }
                        else
                        {
                            lblHeading.Text = "Add Student Leave Type";
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
            if (Request.QueryString["sltId"] != null)
            {
                StudentLeaveTypeCL sltCL = new StudentLeaveTypeCL();
                sltCL.id = Convert.ToInt32(Request.QueryString["scId"]);
                sltCL.name = txtSLTName.Text;
                sltCL.dateCreated = Convert.ToDateTime(txtDateCreated.Text);
                sltCL.dateModified = dateNow;
                sltCL.isDeleted = false;
                StudentLeaveTypeCL sltReturn = studentSLT.updateSLT(sltCL);
                Response.Redirect("ManageSLT.aspx?sltId=" + sltReturn.id);
            }
            else
            {
                StudentLeaveTypeCL sltCL = new StudentLeaveTypeCL();
                sltCL.name = txtSLTName.Text;
                sltCL.dateCreated = dateNow;
                sltCL.dateModified = dateNow;
                sltCL.isDeleted = false;
                int sltId = studentSLT.addSlt(sltCL);
                Response.Redirect("ManageSLT.aspx?sltId=" + sltId);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("StudentLeaveType.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}