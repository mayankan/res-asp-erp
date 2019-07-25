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

namespace RAINBOW_ERP.ReportCard.Out
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
                        int studentId = Convert.ToInt32(Request.QueryString["studentId"]);
                        imgLogo.ImageUrl = "logo.jpg";
                        StudentCL studentCL = studentBLL.viewStudentById(studentId,sessionId);
                        lblStudentName.Text = studentCL.studentName;
                        lblFatherName.Text = studentCL.fatherName;
                        lblMotherName.Text = studentCL.motherName;
                        lblAdmissionNo.Text = studentCL.admissionNo.ToString();
                        lblClassSec.Text = studentCL.classSection;
                        int ut1ExamId = reportBLL.viewExamIdByClass(studentCL.classId, "UNIT 1");
                        int ut2ExamId = reportBLL.viewExamIdByClass(studentCL.classId, "UNIT 2");
                        int term1ExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 1");
                        int term2ExamId = reportBLL.viewExamIdByClass(studentCL.classId, "ANNUAL(100)");
                        Collection<SubjectCL> subjectCol = subjectBLL.viewSubjectByClassId(studentCL.classId);
                        Collection<MarksEntryCL> marksColUT1 = reportBLL.viewMarksByStudentId(studentId, ut1ExamId);
                        Collection<MarksEntryCL> marksColUT2 = reportBLL.viewMarksByStudentId(studentId, ut2ExamId);
                        Collection<MarksEntryCL> marksColTERM1 = reportBLL.viewMarksByStudentId(studentId, term1ExamId);
                        Collection<MarksEntryCL> marksColTERM2 = reportBLL.viewMarksByStudentId(studentId, term2ExamId);
                        Collection<GradeEntryCL> gradesColTERM2 = reportBLL.viewGradesByStudentId(studentId, term2ExamId);
                        int term2GenExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 2 - GENERAL");
                        MiscEntryCL remarksAttendance = reportBLL.viewMiscByStudentId(studentId, term2GenExamId);
                        for (int i = 55; i <= 71; i++)
                        {
                            DeletePractical(subjectCol, i);
                        }
                        var subjectColl = subjectCol.OrderBy(x => x.name);
                        DataTable dt = new DataTable();
                        DataRow dr = null;
                        dt.Columns.Add(new DataColumn("Subjects", typeof(string)));
                        dt.Columns.Add(new DataColumn("Max. Marks", typeof(int)));
                        dt.Columns.Add(new DataColumn("Min. Marks", typeof(int)));
                        dt.Columns.Add(new DataColumn("UT-1", typeof(string)));
                        dt.Columns.Add(new DataColumn("Term-1 Theory", typeof(string)));
                        dt.Columns.Add(new DataColumn("Term-1 Practical", typeof(string)));
                        dt.Columns.Add(new DataColumn("UT-2", typeof(string)));
                        dt.Columns.Add(new DataColumn("Annual Theory", typeof(string)));
                        dt.Columns.Add(new DataColumn("Annual Practical", typeof(string)));
                        dt.Columns.Add(new DataColumn("Obtained Marks Theory", typeof(string)));
                        dt.Columns.Add(new DataColumn("Obtained Marks Practical", typeof(string)));
                        IDictionary<int, string> marksSubjectDictUT1 = new Dictionary<int, string>();
                        IDictionary<int, string> marksSubjectDictUT2 = new Dictionary<int, string>();
                        IDictionary<int, string> marksSubjectDictTERM1 = new Dictionary<int, string>();
                        IDictionary<int, string> marksPracticalSubjectDictTERM1 = new Dictionary<int, string>();
                        IDictionary<int, string> marksSubjectDictTERM2 = new Dictionary<int, string>();
                        IDictionary<int, string> marksPracticalSubjectDictTERM2 = new Dictionary<int, string>();
                        foreach (MarksEntryCL item in marksColUT1)
                        {
                            if (item.subjectId != 2 && item.subjectId != 3 && item.subjectId != 4 && item.subjectId != 5 && item.subjectId != 6 && item.subjectId != 15 && item.subjectId != 7 && item.subjectId != 11 && item.subjectId != 9 && item.subjectId != 8 && item.subjectId != 10 && item.subjectId != 14)
                            {
                                marksSubjectDictUT1.Add(item.subjectId, item.marks);
                            }
                            else
                            {
                                marksSubjectDictUT1.Add(item.subjectId, item.marks);
                            }
                        }
                        foreach (MarksEntryCL item in marksColUT2)
                        {
                            if (item.subjectId != 2 && item.subjectId != 3 && item.subjectId != 4 && item.subjectId != 5 && item.subjectId != 6 && item.subjectId != 15 && item.subjectId != 7 && item.subjectId != 11 && item.subjectId != 9 && item.subjectId != 8 && item.subjectId != 10 && item.subjectId != 14)
                            {
                                marksSubjectDictUT2.Add(item.subjectId, item.marks);
                            }
                            else
                            {
                                marksSubjectDictUT2.Add(item.subjectId, item.marks);
                            }
                        }
                        foreach (MarksEntryCL item in marksColTERM1)
                        {
                            if (item.subjectId != 2 && item.subjectId != 3 && item.subjectId != 4 && item.subjectId != 5 && item.subjectId != 6 && item.subjectId != 15 && item.subjectId != 7 && item.subjectId != 11 && item.subjectId != 9 && item.subjectId != 8 && item.subjectId != 10 && item.subjectId != 14)
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM1.Add(item.subjectId, string.Empty);
                            }
                            if (item.subjectId == 14)
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM1.Add(item.subjectId, CheckSubjectInCol(marksColTERM1, 66));
                            }
                            if (item.subjectId == 2)
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM1.Add(item.subjectId, CheckSubjectInCol(marksColTERM1, 55));
                            }
                            if (item.subjectId == 3)
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM1.Add(item.subjectId, CheckSubjectInCol(marksColTERM1, 56));
                            }
                            if (item.subjectId == 4)
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM1.Add(item.subjectId, CheckSubjectInCol(marksColTERM1, 57));
                            }
                            if (item.subjectId == 5)
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM1.Add(item.subjectId, CheckSubjectInCol(marksColTERM1, 58));
                            }
                            if (item.subjectId == 6)
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM1.Add(item.subjectId, CheckSubjectInCol(marksColTERM1, 59));
                            }
                            if (item.subjectId == 15)
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM1.Add(item.subjectId, CheckSubjectInCol(marksColTERM1, 60));
                            }
                            if (item.subjectId == 7)
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM1.Add(item.subjectId, CheckSubjectInCol(marksColTERM1, 61));
                            }
                            if (item.subjectId == 11)
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM1.Add(item.subjectId, CheckSubjectInCol(marksColTERM1, 62));
                            }
                            if (item.subjectId == 9)
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM1.Add(item.subjectId, CheckSubjectInCol(marksColTERM1, 63));
                            }
                            if (item.subjectId == 8)
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM1.Add(item.subjectId, CheckSubjectInCol(marksColTERM1, 64));
                            }
                            if (item.subjectId == 10)
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM1.Add(item.subjectId, CheckSubjectInCol(marksColTERM1, 65));
                            }
                        }
                        foreach (MarksEntryCL item in marksColTERM2)
                        {
                            if (item.subjectId != 2 && item.subjectId != 3 && item.subjectId != 4 && item.subjectId != 5 && item.subjectId != 6 && item.subjectId != 15 && item.subjectId != 7 && item.subjectId != 11 && item.subjectId != 9 && item.subjectId != 8 && item.subjectId != 10 && item.subjectId != 14)
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM2.Add(item.subjectId, string.Empty);
                            }
                            if (item.subjectId == 14)
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM2.Add(item.subjectId, CheckSubjectInCol(marksColTERM2, 66));
                            }
                            if (item.subjectId == 2)
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM2.Add(item.subjectId, CheckSubjectInCol(marksColTERM2, 55));
                            }
                            if (item.subjectId == 3)
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM2.Add(item.subjectId, CheckSubjectInCol(marksColTERM2, 56));
                            }
                            if (item.subjectId == 4)
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM2.Add(item.subjectId, CheckSubjectInCol(marksColTERM2, 57));
                            }
                            if (item.subjectId == 5)
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM2.Add(item.subjectId, CheckSubjectInCol(marksColTERM2, 58));
                            }
                            if (item.subjectId == 6)
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM2.Add(item.subjectId, CheckSubjectInCol(marksColTERM2, 59));
                            }
                            if (item.subjectId == 15)
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM2.Add(item.subjectId, CheckSubjectInCol(marksColTERM2, 60));
                            }
                            if (item.subjectId == 7)
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM2.Add(item.subjectId, CheckSubjectInCol(marksColTERM2, 61));
                            }
                            if (item.subjectId == 11)
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM2.Add(item.subjectId, CheckSubjectInCol(marksColTERM2, 62));
                            }
                            if (item.subjectId == 9)
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM2.Add(item.subjectId, CheckSubjectInCol(marksColTERM2, 63));
                            }
                            if (item.subjectId == 8)
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM2.Add(item.subjectId, CheckSubjectInCol(marksColTERM2, 64));
                            }
                            if (item.subjectId == 10)
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDictTERM2.Add(item.subjectId, CheckSubjectInCol(marksColTERM2, 65));
                            }
                        }
                        double grandTotal = 0;
                        foreach (SubjectCL item in subjectCol)
                        {
                            dr = dt.NewRow();
                            dr["Subjects"] = item.name;
                            dr["Max. Marks"] = 240;
                            dr["Min. Marks"] = 96;
                            if ((marksSubjectDictUT1.ContainsKey(item.id) && marksSubjectDictTERM1.ContainsKey(item.id) && marksSubjectDictUT2.ContainsKey(item.id) && marksSubjectDictTERM2.ContainsKey(item.id)))
                            {
                                double grandTotalTheory = 0;
                                double grandTotalPractical = 0;
                                if (marksSubjectDictUT1.ContainsKey(item.id))
                                {
                                    dr["UT-1"] = marksSubjectDictUT1[item.id];
                                    grandTotalTheory = grandTotalTheory + Convert.ToDouble(marksSubjectDictUT1[item.id]);
                                }
                                else
                                {
                                    dr["UT-1"] = string.Empty;
                                }
                                if (marksSubjectDictTERM1.ContainsKey(item.id))
                                {
                                    dr["Term-1 Theory"] = marksSubjectDictTERM1[item.id];
                                    if (marksPracticalSubjectDictTERM1[item.id] == string.Empty)
                                    {
                                        grandTotalTheory = grandTotalTheory + Convert.ToDouble(marksSubjectDictTERM1[item.id]);
                                    }
                                    else
                                    {
                                        dr["Term-1 Practical"] = marksPracticalSubjectDictTERM1[item.id];
                                        grandTotalTheory = grandTotalTheory + Convert.ToDouble(marksSubjectDictTERM1[item.id]);
                                        grandTotalPractical = grandTotalPractical + Convert.ToDouble(marksPracticalSubjectDictTERM1[item.id]);
                                    }
                                }
                                else
                                {
                                    dr["Term-1 Theory"] = string.Empty;
                                    dr["Term-1 Practical"] = string.Empty;
                                }
                                if (marksSubjectDictUT2.ContainsKey(item.id))
                                {
                                    dr["UT-2"] = marksSubjectDictUT2[item.id];
                                    grandTotalTheory = grandTotalTheory + Convert.ToDouble(marksSubjectDictUT2[item.id]);
                                }
                                else
                                {
                                    dr["UT-2"] = string.Empty;
                                }
                                if (marksSubjectDictTERM2.ContainsKey(item.id))
                                {
                                    dr["Annual Theory"] = marksSubjectDictTERM2[item.id];
                                    if (marksPracticalSubjectDictTERM2[item.id] == string.Empty)
                                    {
                                        grandTotalTheory = grandTotalTheory + Convert.ToDouble(marksSubjectDictTERM2[item.id]);
                                    }
                                    else
                                    {
                                        dr["Annual Practical"] = marksPracticalSubjectDictTERM2[item.id];
                                        grandTotalTheory = grandTotalTheory + Convert.ToDouble(marksSubjectDictTERM2[item.id]);
                                        grandTotalPractical = grandTotalPractical + Convert.ToDouble(marksPracticalSubjectDictTERM2[item.id]);
                                    }
                                }
                                else
                                {
                                    dr["Annual Theory"] = string.Empty;
                                    dr["Annual Practical"] = string.Empty;
                                }
                                dr["Obtained Marks Theory"] = grandTotalTheory;
                                if(grandTotalPractical!=0)
                                    dr["Obtained Marks Practical"] = grandTotalPractical;
                                grandTotal = grandTotal + grandTotalTheory + grandTotalPractical;
                            }
                            else
                            {
                                dr["UT-1"] = string.Empty;
                                dr["Term-1 Theory"] = string.Empty;
                                dr["Term-1 Practical"] = string.Empty;
                                dr["UT-2"] = string.Empty;
                                dr["Annual Theory"] = string.Empty;
                                dr["Annual Practical"] = string.Empty;
                                dr["Obtained Marks Theory"] = string.Empty;
                                dr["Obtained Marks Practical"] = string.Empty;
                            }
                            dt.Rows.Add(dr);
                        }
                        grdMarksReport.DataSource = dt;
                        grdMarksReport.DataBind();
                        lblGrandTotal.Text = grandTotal.ToString();
                        lblPercentage.Text = Math.Round(grandTotal/12,2) + "%";
                        lblDiscipline.Text = gradesColTERM2.Where(x => x.subjectId == 71).FirstOrDefault().grade;
                        lblPunctuality.Text = gradesColTERM2.Where(x => x.subjectId == 67).FirstOrDefault().grade;
                        lblRespectToGender.Text = gradesColTERM2.Where(x => x.subjectId == 68).FirstOrDefault().grade;
                        lblAttitudeClassmates.Text = gradesColTERM2.Where(x => x.subjectId == 69).FirstOrDefault().grade;
                        lblAttitudeTeachers.Text = gradesColTERM2.Where(x => x.subjectId == 70).FirstOrDefault().grade;
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