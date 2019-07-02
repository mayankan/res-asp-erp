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
    public partial class ManageExamination : System.Web.UI.Page
    {
        ExaminationBLL examinationBLL = new ExaminationBLL();
        ClassBLL classBLL = new ClassBLL();
        SessionBLL sessionBLL = new SessionBLL();
        public int sessionId;
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
                        sessionId = Convert.ToInt32(Session["sessionId"]);
                        if (Request.QueryString["examinationId"] != null)
                        {
                            int examId = Convert.ToInt32(Request.QueryString["examinationId"]);
                            lblHeading.Text = "Update Examination";
                            ddlClass.DataSource = classBLL.viewClasses(sessionId);
                            ddlClass.DataValueField = "id";
                            ddlClass.DataTextField = "classSection";
                            ddlClass.DataBind();
                            ExaminationCL examCL = examinationBLL.viewExaminationById(examId);
                            ddlClass.SelectedValue = examCL.classId.ToString();
                            txtExamination.Text = examCL.name;
                            txtDateCreated.Text = examCL.dateCreated.ToString("dd MMMM yyyy");
                            txtDateUpdated.Text = examCL.dateModified.ToString("dd MMMM yyyy");
                            btnSubmit.Text = "Update";
                            btnDelete.Visible = true;
                        }
                        else
                        {
                            lblHeading.Text = "Add Examination";
                            ddlClass.DataSource = classBLL.viewClasses(sessionId);
                            ddlClass.DataValueField = "id";
                            ddlClass.DataTextField = "classSection";
                            ddlClass.DataBind();
                            btnSubmit.Text = "Submit";
                            btnDelete.Visible = false;
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
            if (Request.QueryString["examinationId"] != null)
            {
                ExaminationCL examCL = new ExaminationCL();
                examCL.id = Convert.ToInt32(Request.QueryString["examinationId"]);
                examCL.classId = Convert.ToInt32(ddlClass.SelectedValue);
                examCL.name = txtExamination.Text;
                examCL.dateCreated = Convert.ToDateTime(txtDateCreated.Text);
                examCL.dateModified = dateNow;
                examCL.isDeleted = false;
                ExaminationCL examReturn = examinationBLL.updateExamination(examCL);
                Response.Redirect("ManageExamination.aspx?examinationid=" + examReturn.id);
            }
            else
            {
                ExaminationCL examCL = new ExaminationCL();
                examCL.name = txtExamination.Text;
                examCL.classId = Convert.ToInt32(ddlClass.SelectedValue);
                examCL.dateCreated = dateNow;
                examCL.dateModified = dateNow;
                examCL.isDeleted = false;
                int examId = examinationBLL.addExamination(examCL);
                Response.Redirect("ManageExamination.aspx?examinationid=" + examId);
            }
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Examination.aspx");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            ExaminationCL examCL = new ExaminationCL();
            examCL.id = Convert.ToInt32(Request.QueryString["examinationId"]);
            examinationBLL.deleteExamination(examCL.id);
            Response.Redirect("ManageExamination.aspx");
        }
    }
}