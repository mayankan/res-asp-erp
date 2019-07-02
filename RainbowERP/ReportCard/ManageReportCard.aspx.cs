using BusinessLogicLayer;
using CommunicationLayer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAINBOW_ERP.ReportCard
{
    public partial class ManageReportCard : System.Web.UI.Page
    {
        ExaminationBLL examBLL = new ExaminationBLL();
        ReportCardEntryBLL reportBLL = new ReportCardEntryBLL();
        SubjectBLL subjectBLL = new SubjectBLL();
        ClassBLL classBLL = new ClassBLL();
        StudentBLL studentBLL = new StudentBLL();
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
                        Response.Redirect("index.aspx");
                    }
                    else if (role.ToLower() == "teacher" || role.ToLower() == "attendanceo")
                    {
                        Response.Redirect("../UnAuthorized.aspx");
                    }
                    else
                    {
                        if (Session["sessionId"] == null)
                        {
                            SessionCL sessionCL = sessionBLL.addorCheckSession();
                            Session["sessionId"] = sessionCL.id;
                        }
                        else
                        {
                            sessionId = Convert.ToInt32(Session["sessionId"]);
                            Collection<ClassCL> classCol = classBLL.viewClasses(sessionId);
                            ddlClass.DataSource = classCol;
                            ddlClass.DataValueField = "id";
                            ddlClass.DataTextField = "classSection";
                            ddlClass.DataBind();
                        }
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int classId = Convert.ToInt32(ddlClass.SelectedValue);
            int examId = Convert.ToInt32(ddlExamination.SelectedValue);
            Collection<SubjectCL> subjectCol = subjectBLL.viewSubjectByClassId(classId);
            var subjectColl = subjectCol.OrderBy(x => x.name);
            Collection<StudentCL> studentCol = studentBLL.viewStudentsByClassId(classId);
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("Admission No", typeof(string)));
            dt.Columns.Add(new DataColumn("Student Name", typeof(string)));
            foreach (var item in subjectCol)
            {
                dt.Columns.Add(new DataColumn(item.name, typeof(string)));
            }
            dt.Columns.Add(new DataColumn("Grand Total", typeof(int)));
            dt.Columns.Add(new DataColumn("Percentage", typeof(string)));
            foreach (StudentCL x in studentCol)
            {
                int studentId = x.id;
                Collection<MarksEntryCL> marksCol = reportBLL.viewMarksByStudentId(studentId, examId);
                IDictionary<int, string> marksSubjectDict = new Dictionary<int, string>();
                foreach (MarksEntryCL y in marksCol)
                {
                    marksSubjectDict.Add(y.subjectId, y.marks);
                }
                double grandTotal = 0;
                dr = dt.NewRow();
                dr["Admission No"] = x.admissionNo;
                dr["Student Name"] = x.studentName;
                foreach (var item in subjectCol)
                {
                    if (marksSubjectDict.ContainsKey(item.id))
                    {
                        dr[item.name] = marksSubjectDict[item.id];
                        grandTotal = grandTotal + Convert.ToDouble(marksSubjectDict[item.id]);
                    }
                    else
                    {
                        dr[item.name] = string.Empty;
                    }
                }
                dr["Grand Total"] = grandTotal;
                dr["Percentage"] = (grandTotal / 5) + "%";
                dt.Rows.Add(dr);
            }
            grdMarksReport.DataSource = dt;
            grdMarksReport.DataBind();
        }

        protected void ddlClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            Collection<ExaminationCL> examCol = examBLL.viewExaminationsByClassId(Convert.ToInt32(ddlClass.SelectedValue));
            ddlExamination.DataSource = examCol;
            ddlExamination.DataValueField = "id";
            ddlExamination.DataTextField = "name";
            ddlExamination.DataBind();
            ddlExamination.Items.Insert(0, new ListItem("Select", "-1"));
        }
    }
}