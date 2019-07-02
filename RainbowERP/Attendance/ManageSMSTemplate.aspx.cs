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
    public partial class ManageSMSTemplate : System.Web.UI.Page
    {
        StudentLeaveTypesBLL studentLTypeBLL = new StudentLeaveTypesBLL();
        SMSBLL smsBLL = new SMSBLL();
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
                        if (Request.QueryString["smsId"] != null)
                        {
                            lblHeading.Text = "Update SMS Template";
                            int smsId = Convert.ToInt32(Request.QueryString["smsId"]);
                            SMSCL smsCL = smsBLL.viewSMSTemplatesById(smsId);
                            ddlStudentLeaveType.DataSource = studentLTypeBLL.viewStudentLeaveTypes();
                            ddlStudentLeaveType.DataValueField = "id";
                            ddlStudentLeaveType.DataTextField = "name";
                            ddlStudentLeaveType.Items.Insert(0, new ListItem("Select", "-1"));
                            ddlStudentLeaveType.DataBind();
                            ddlStudentLeaveType.SelectedValue = smsCL.studentLeaveTypeId.ToString();
                            txtSMS.Text = smsCL.template;
                            txtDateCreated.Text = smsCL.dateCreated.ToString();
                            txtDateUpdated.Text = smsCL.dateModified.ToString();
                        }
                        else
                        {
                            lblHeading.Text = "Add SMS Template";
                            ddlStudentLeaveType.DataSource = studentLTypeBLL.viewStudentLeaveTypes();
                            ddlStudentLeaveType.DataValueField = "id";
                            ddlStudentLeaveType.DataTextField = "name";
                            ddlStudentLeaveType.Items.Insert(0, new ListItem("Select", "-1"));
                            ddlStudentLeaveType.DataBind();
                        } 
                    }
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DateTime dateHosting = DateTime.UtcNow;
            TimeZoneInfo indianZoneId = TimeZoneInfo.FindSystemTimeZoneById("India Standard Time");
            DateTime dateNow = TimeZoneInfo.ConvertTimeFromUtc(dateHosting, indianZoneId);
            SMSCL smsNew = new SMSCL();
            if (Request.QueryString["smsId"] != null)
            {
                smsNew.id = Convert.ToInt32(Request.QueryString["smsId"]);
                smsNew.template = txtSMS.Text;
                smsNew.studentLeaveTypeId = Convert.ToInt32(ddlStudentLeaveType.SelectedValue);
                smsNew.dateModified = dateNow;
                smsBLL.updateSMS(smsNew);
                Response.Redirect("ManageSMSTemplate.aspx?smsId=" + smsNew.id);
            }
            else
            {
                smsNew.template = txtSMS.Text;
                smsNew.studentLeaveTypeId = Convert.ToInt32(ddlStudentLeaveType.SelectedValue);
                smsNew.id = 0;
                smsNew.isDeleted = false;
                smsNew.dateCreated = dateNow;
                smsNew.dateModified = dateNow;
                int smsIdUpdated = smsBLL.addSMS(smsNew);
                Response.Redirect("ManageSMSTemplate.aspx?smsId=" + smsIdUpdated);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("SMSTemplate.aspx");
        }
    }
}