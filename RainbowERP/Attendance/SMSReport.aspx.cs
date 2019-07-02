using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAINBOW_ERP.Attendance
{
    public partial class SMSReport : System.Web.UI.Page
    {
        SessionBLL sessionBLL = new SessionBLL();
        ClassBLL classBLL = new ClassBLL();
        StudentBLL studentBLL = new StudentBLL();
        StudentLeaveTypesBLL studentLTBLL = new StudentLeaveTypesBLL();
        int sessionId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!Request.IsAuthenticated || Session["auth"]==null)
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
                    else if (role.ToLower() != "admin")
                    {
                        Response.Redirect("../UnAuthorized.aspx");
                    }
                    else
                    {
                        sessionId = Convert.ToInt32(Session["sessionId"]);
                        sessionBLL.createLog(new LogCL
                        {
                            dateOfAction = DateTime.Now,
                            logAction = "SMS Report Page Entered by " + Session["user"],
                            module = "Attendance",
                            userId = Convert.ToInt32(Session["user"]),
                        });
                        Collection<ClassCL> classCol = classBLL.viewClasses(sessionId);
                        ddlClass.DataSource = classCol;
                        ddlClass.DataValueField = "id";
                        ddlClass.DataTextField = "classSection";
                        ddlClass.DataBind();
                        ddlClass.Items.Insert(0, new ListItem("All", "-1"));
                        Collection<StudentLeaveTypeCL> studentLT = studentLTBLL.viewStudentLeaveTypes();
                        ddlCategory.DataSource = studentLT;
                        ddlCategory.DataValueField = "id";
                        ddlCategory.DataTextField = "name";
                        ddlCategory.DataBind();
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DateTime dateFrom = Convert.ToDateTime(txtDateFrom.Text);
            DateTime dateTo = Convert.ToDateTime(txtDateTo.Text);
            int classId = Convert.ToInt32(ddlClass.SelectedValue);
            int studentLeaveTypeId = Convert.ToInt32(ddlCategory.SelectedValue);

            //ADD Table Output for SMS Report


            //Collection<StudentCL> studentCol = studentBLL.viewStudentsByClassId(classId);
            //PrintDocument printDoc = new PrintDocument();
            //string subjectIdCol = "";
            //foreach (StudentCL item in studentCol)
            //{
            //    subjectIdCol = subjectIdCol + "</br>" + item.id;
            //}
            //lblOutput.Text = subjectIdCol;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }
    }
}