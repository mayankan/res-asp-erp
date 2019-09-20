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
    public partial class _11TERM2 : System.Web.UI.Page
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
                        lblExamination.Text = "TERM 2";
                        int term1ExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 2");
                        Collection<SubjectCL> subjectCol = subjectBLL.viewSubjectByClassId(studentCL.classId);
                        Collection<MarksEntryCL> marksCol = reportBLL.viewMarksByStudentId(studentId, term1ExamId);
                        Collection<MarksEntryCL> marksColCopy = marksCol;
                        Collection<GradeEntryCL> gradesColTERM1 = reportBLL.viewGradesByStudentId(studentId, term1ExamId);
                        MiscEntryCL remarksAttendance = reportBLL.viewMiscByStudentId(studentId, term1ExamId);
                        for (int i = 54; i <= 71; i++)
                        {
                            DeletePractical(subjectCol, i);
                        }
                        DeletePractical(subjectCol, 116);
                        DeletePractical(subjectCol, 54);
                        DeletePractical(subjectCol, 121);
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
                            if (item.subjectId != 2 && item.subjectId != 3 && item.subjectId != 4 && item.subjectId != 5 && item.subjectId != 6 && item.subjectId != 15 && item.subjectId != 7 && item.subjectId != 11 && item.subjectId != 9 && item.subjectId != 8 && item.subjectId != 10 && item.subjectId != 14 && item.subjectId != 115 && item.subjectId != 13)
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, string.Empty);
                            }
                            if (item.subjectId == 14)
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 66));
                            }
                            if (item.subjectId == 2)
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 55));
                            }
                            if (item.subjectId == 3)
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 56));
                            }
                            if (item.subjectId == 4)
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 57));
                            }
                            if (item.subjectId == 5)
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 58));
                            }
                            if (item.subjectId == 6)
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 59));
                            }
                            if (item.subjectId == 15)
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 60));
                            }
                            if (item.subjectId == 7)
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 61));
                            }
                            if (item.subjectId == 11)
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 62));
                            }
                            if (item.subjectId == 9)
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 63));
                            }
                            if (item.subjectId == 8)
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 64));
                            }
                            if (item.subjectId == 10)
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 65));
                            }
                            if (item.subjectId == 115)
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 116));
                            }
                            if (item.subjectId == 13)
                            {
                                marksSubjectDict.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 121));
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
                        lblDiscipline.Text = gradesColTERM1.Where(x => x.subjectId == 71).FirstOrDefault().grade;
                        lblPunctuality.Text = gradesColTERM1.Where(x => x.subjectId == 67).FirstOrDefault().grade;
                        lblRespectToGender.Text = gradesColTERM1.Where(x => x.subjectId == 68).FirstOrDefault().grade;
                        lblAttitudeClassmates.Text = gradesColTERM1.Where(x => x.subjectId == 69).FirstOrDefault().grade;
                        lblAttitudeTeachers.Text = gradesColTERM1.Where(x => x.subjectId == 70).FirstOrDefault().grade;
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