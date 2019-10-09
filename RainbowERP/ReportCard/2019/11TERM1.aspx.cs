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

namespace RainbowERP.ReportCard._2019
{
    public partial class _11TERM1 : System.Web.UI.Page
    {
        SubjectBLL subjectBLL = new SubjectBLL();
        ReportCardEntryBLL reportBLL = new ReportCardEntryBLL();
        StudentBLL studentBLL = new StudentBLL();
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
                        Response.Redirect("../index.aspx");
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
                        lblExamination.Text = "TERM 1";
                        int term1ExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 1");
                        Collection<SubjectCL> subjectCol = subjectBLL.viewSubjectByClassId(studentCL.classId);
                        Collection<MarksEntryCL> marksCol = reportBLL.viewMarksByStudentId(studentId, term1ExamId);
                        Collection<MarksEntryCL> marksColCopy = marksCol;
                        Collection<GradeEntryCL> gradesColTERM1 = reportBLL.viewGradesByStudentId(studentId, term1ExamId);
                        MiscEntryCL remarksAttendance = reportBLL.viewMiscByStudentId(studentId, term1ExamId);
                        for (int i = 55; i <= 66; i++)
                        {
                            DeletePractical(subjectCol, i);
                        }
                        DeletePractical(subjectCol, 121);
                        DeletePractical(subjectCol, 122);
                        for (int i = 145; i <= 149; i++)
                        {
                            DeletePractical(subjectCol, i);
                        }
                        DeletePractical(subjectCol, 122);
                        for (int i = 67; i <= 71; i++)
                        {
                            DeletePractical(subjectCol, i);
                        }
                        var subjectColl = subjectCol.OrderBy(x => x.name);
                        DataTable dt = new DataTable();
                        DataRow dr = null;
                        dt.Columns.Add(new DataColumn("Subjects", typeof(string)));
                        dt.Columns.Add(new DataColumn("Max. Marks", typeof(int)));
                        dt.Columns.Add(new DataColumn("Min. Marks", typeof(int)));
                        dt.Columns.Add(new DataColumn("Theory", typeof(string)));
                        dt.Columns.Add(new DataColumn("Practical", typeof(string)));
                        dt.Columns.Add(new DataColumn("Total", typeof(string)));
                        IDictionary<int, string> marksSubjectDict = new Dictionary<int, string>();
                        IDictionary<int, string> marksPracticalSubjectDict = new Dictionary<int, string>();
                        int count = 0;
                        foreach (MarksEntryCL item in marksCol)
                        {
                            if (item.subjectName == "Physics(042)")
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 55));
                            }
                            else if (item.subjectName == "Chemistry(043)")
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 56));
                            }
                            else if (item.subjectName == "Biology(044)")
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 57));
                            }
                            else if (item.subjectName == "Engineering Graphics(046)")
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 58));
                            }
                            else if (item.subjectName == "Computer Science(083)" || item.subjectName == "Computer Science(283)")
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 59));
                            }
                            else if (item.subjectName == "Physical Education(048)")
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 60));
                            }
                            else if (item.subjectName == "Psychology(037)")
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 61));
                            }
                            else if (item.subjectName == "Marketing(783)")
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 62));
                            }
                            else if (item.subjectName == "Business Studies(054)")
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 63));
                            }
                            else if (item.subjectName == "Accountancy(055)")
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 63));
                            }
                            else if (item.subjectName == "Economics(030)")
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 64));
                            }
                            else if (item.subjectName == "History(027)")
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 65));
                            }
                            else if (item.subjectName == "Hindi(302)")
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 121));
                            }
                            else if (item.subjectName == "English(301)")
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 145));
                            }
                            else if (item.subjectName == "Political Science(028)")
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 146));
                            }
                            else if (item.subjectName == "Mathematics(041)")
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 147));
                            }
                            else if (item.subjectName == "Information Practices(065)"|| item.subjectName == "Information Practices(265)")
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 148));
                            }
                            else
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, string.Empty);
                            }
                        }
                        double grandTotal = 0;
                        foreach (SubjectCL item in subjectCol)
                        {
                            dr = dt.NewRow();
                            dr["Subjects"] = item.name;
                            dr["Max. Marks"] = 100;
                            dr["Min. Marks"] = 40;
                            if (marksSubjectDict.ContainsKey(item.id))
                            {
                                count++;
                                dr["Theory"] = marksSubjectDict[item.id];
                                if (marksPracticalSubjectDict[item.id] == string.Empty)
                                {
                                    dr["Total"] = marksSubjectDict[item.id];
                                    grandTotal = grandTotal + Convert.ToDouble(marksSubjectDict[item.id]);
                                }
                                else
                                {
                                    dr["Practical"] = marksPracticalSubjectDict[item.id];
                                    dr["Total"] = Convert.ToDouble(marksSubjectDict[item.id]) + Convert.ToDouble(marksPracticalSubjectDict[item.id]);
                                    grandTotal = grandTotal + Convert.ToDouble(Convert.ToDouble(marksSubjectDict[item.id]) + Convert.ToDouble(marksPracticalSubjectDict[item.id]));
                                }
                            }
                            else
                            {
                                dr["Theory"] = string.Empty;
                                dr["Practical"] = string.Empty;
                                dr["Total"] = string.Empty;
                            }
                            dt.Rows.Add(dr);
                        }
                        grdMarksReport.DataSource = dt;
                        grdMarksReport.DataBind();
                        lblGrandTotal.Text = grandTotal.ToString();
                        lblPercentage.Text = Math.Round(grandTotal / 5, 2) + "%";
                        try
                        {
                            lblDiscipline.Text = gradesColTERM1.Where(x => x.subjectId == 71).FirstOrDefault().grade;
                            lblPunctuality.Text = gradesColTERM1.Where(x => x.subjectId == 67).FirstOrDefault().grade;
                            lblRespectToGender.Text = gradesColTERM1.Where(x => x.subjectId == 68).FirstOrDefault().grade;
                            lblAttitudeClassmates.Text = gradesColTERM1.Where(x => x.subjectId == 69).FirstOrDefault().grade;
                            lblAttitudeTeachers.Text = gradesColTERM1.Where(x => x.subjectId == 70).FirstOrDefault().grade;
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        lblAttendance.Text = remarksAttendance.attendance;
                        lblRemarks.Text = remarksAttendance.remarks;
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
        private string CheckSubjectInCol(Collection<MarksEntryCL> marksCol, int subjectId)
        {
            if (marksCol.Where(x => x.subjectId == subjectId).FirstOrDefault() == null)
            {
                return string.Empty;
            }
            else
            {
                return marksCol.Where(x => x.subjectId == subjectId).FirstOrDefault().marks;
            }
        }
    }
}