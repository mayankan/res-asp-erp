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
//using System.Printing;
using System.Drawing.Printing;

namespace RAINBOW_ERP.ReportCard
{
    public partial class PrintReportCard : System.Web.UI.Page
    {
        ClassBLL classBLL = new ClassBLL();
        StudentBLL studentBLL = new StudentBLL();
        int sessionId;
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
                        sessionId = Convert.ToInt32(Session["sessionId"]);
                        Collection<ClassCL> classCol = classBLL.viewClasses(sessionId);
                        ddlClass.DataSource = classCol;
                        ddlClass.DataValueField = "id";
                        ddlClass.DataTextField = "classSection";
                        ddlClass.DataBind();
                        ddlClass.Items.Insert(0, new ListItem("Select", "-1"));
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int classId = Convert.ToInt32(ddlClass.SelectedValue);
            Collection<StudentCL> studentCol = studentBLL.viewStudentsByClassId(classId);
            PrintDocument printDoc = new PrintDocument();
            string subjectIdCol="";
            foreach (StudentCL item in studentCol)
            {
                subjectIdCol = subjectIdCol + "</br>" + item.id;
            }
            lblOutput.Text = subjectIdCol;
        }
    }
}