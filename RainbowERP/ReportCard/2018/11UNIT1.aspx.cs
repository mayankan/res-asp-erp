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

namespace RAINBOW_ERP.ReportCard._2018
{
    public partial class _12UNIT1 : System.Web.UI.Page
    {
        SubjectBLL subjectBLL = new SubjectBLL();
        ReportCardEntryBLL reportBLL = new ReportCardEntryBLL();
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
                    if (Session["sessionId"] == null)
                    {
                        Response.Redirect("index.aspx");
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
                            int studentId = 0;
                            StudentCL studentCL = new StudentCL();
                            studentId = Convert.ToInt32(Request.QueryString["studentId"]);
                            if (studentId != 0)
                            {
                                studentId = Convert.ToInt32(Request.QueryString["studentId"]);
                                studentCL = studentBLL.viewStudentById(studentId, sessionId);
                            }
                            else
                            {
                                studentId = Convert.ToInt32(Request.QueryString["admNo"]);
                                studentCL = studentBLL.viewStudentByAdmissionNo(studentId, sessionId);
                                studentId = studentCL.id;
                            }
                            imgLogo.ImageUrl = "logo.jpg";
                            lblStudentName.Text = studentCL.studentName;
                            lblFatherName.Text = studentCL.fatherName;
                            lblMotherName.Text = studentCL.motherName;
                            lblAdmissionNo.Text = studentCL.admissionNo.ToString();
                            lblClassSec.Text = studentCL.classSection;
                            lblExamination.Text = "UNIT 1";
                            int examinationId = reportBLL.viewExamIdByClass(studentCL.classId, "UNIT 1");
                            Collection<SubjectCL> subjectCol = subjectBLL.viewSubjectByClassId(studentCL.classId);
                            Collection<MarksEntryCL> marksCol = reportBLL.viewMarksByStudentId(studentId, examinationId);
                            MiscEntryCL remarksAttendance = reportBLL.viewMiscByStudentId(studentId, examinationId);
                            lblAttendance.Text = remarksAttendance.attendance;
                            lblRemarks.Text = remarksAttendance.remarks;
                            var subjectColl = subjectCol.OrderBy(x => x.name);
                            DataTable dt = new DataTable();
                            DataRow dr = null;
                            dt.Columns.Add(new DataColumn("Subjects", typeof(string)));
                            dt.Columns.Add(new DataColumn("Max. Marks", typeof(int)));
                            dt.Columns.Add(new DataColumn("Min. Marks", typeof(int)));
                            dt.Columns.Add(new DataColumn("Obtained Marks", typeof(string)));
                            IDictionary<int, string> marksSubjectDict = new Dictionary<int, string>();
                            foreach (MarksEntryCL item in marksCol)
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                            }
                            double grandTotal = 0;
                            for (int i = 54; i <= 71; i++)
                            {
                                DeletePractical(subjectCol, i);
                            }
                            DeletePractical(subjectCol, 116);
                            foreach (SubjectCL item in subjectCol)
                            {
                                dr = dt.NewRow();
                                dr["Subjects"] = item.name;
                                dr["Max. Marks"] = 20;
                                dr["Min. Marks"] = 8;
                                if (marksSubjectDict.ContainsKey(item.id))
                                {
                                    dr["Obtained Marks"] = marksSubjectDict[item.id];
                                    grandTotal = grandTotal + Convert.ToDouble(marksSubjectDict[item.id]);
                                }
                                else
                                {
                                    dr["Obtained Marks"] = string.Empty;
                                }
                                dt.Rows.Add(dr);
                            }
                            grdMarksReport.DataSource = dt;
                            grdMarksReport.DataBind();
                            lblGrandTotal.Text = grandTotal.ToString();
                            lblPercentage.Text = grandTotal + "%";
                        }
                    }
                }
            }
        }
        private void DeletePractical(Collection<SubjectCL> marksCol, int subjectId)
        {
            if (marksCol.Where(x => x.id == subjectId).FirstOrDefault() != null)
            {
                marksCol.Remove(marksCol.Where(x => x.id == subjectId).FirstOrDefault());
            }
        }
    }
}