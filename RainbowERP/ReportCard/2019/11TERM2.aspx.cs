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
                        lblStudentName.Text = studentCL.studentName;
                        lblFatherName.Text = studentCL.fatherName;
                        lblMotherName.Text = studentCL.motherName;
                        lblAdmissionNo.Text = studentCL.admissionNo.ToString();
                        lblClassSec.Text = studentCL.classSection;
                        int utExamId = reportBLL.viewExamIdByClass(studentCL.classId, "UT(5)");
                        int term1ExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 1(Reduced)");
                        int term2ExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 2");
                        Collection<SubjectCL> subjectCol = subjectBLL.viewSubjectByClassId(studentCL.classId);
                        Collection<MarksEntryCL> marksColUT = reportBLL.viewMarksByStudentId(studentId, utExamId);
                        Collection<MarksEntryCL> marksColTERM1 = reportBLL.viewMarksByStudentId(studentId, term1ExamId);
                        Collection<MarksEntryCL> marksColTERM2 = reportBLL.viewMarksByStudentId(studentId, term2ExamId);
                        Collection<MarksEntryCL> marksColCopy = marksColTERM2;
                        Collection<GradeEntryCL> gradesColTERM2 = reportBLL.viewGradesByStudentId(studentId, term2ExamId);
                        int term2GenExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 2 - GENERAL");
                        MiscEntryCL remarksAttendance = reportBLL.viewMiscByStudentId(studentId, term2GenExamId);
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
                        dt.Columns.Add(new DataColumn("UT(5)", typeof(int)));
                        dt.Columns.Add(new DataColumn("Term-1", typeof(int)));
                        dt.Columns.Add(new DataColumn("Term-2", typeof(int)));
                        dt.Columns.Add(new DataColumn("Theory", typeof(int)));
                        dt.Columns.Add(new DataColumn("Practical", typeof(int)));
                        dt.Columns.Add(new DataColumn("Total", typeof(int)));
                        IDictionary<int, string> marksSubjectDictUT = new Dictionary<int, string>();
                        IDictionary<int, string> marksSubjectDictTERM1 = new Dictionary<int, string>();
                        IDictionary<int, string> marksSubjectDictTERM2 = new Dictionary<int, string>();
                        IDictionary<int, string> marksPracticalSubjectDict = new Dictionary<int, string>();
                        int count = 0;
                        foreach (MarksEntryCL item in marksColUT)
                        {
                            if (item.subjectName == "Physics(042)")
                            {
                                marksSubjectDictUT.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Chemistry(043)")
                            {
                                marksSubjectDictUT.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Biology(044)")
                            {
                                marksSubjectDictUT.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Engineering Graphics(046)")
                            {
                                marksSubjectDictUT.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Computer Science(083)" || item.subjectName == "Computer Science(283)")
                            {
                                marksSubjectDictUT.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Physical Education(048)")
                            {
                                marksSubjectDictUT.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Psychology(037)")
                            {
                                marksSubjectDictUT.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Marketing(783)")
                            {
                                marksSubjectDictUT.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Business Studies(054)")
                            {
                                marksSubjectDictUT.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Accountancy(055)")
                            {
                                marksSubjectDictUT.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Economics(030)")
                            {
                                marksSubjectDictUT.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "History(027)")
                            {
                                marksSubjectDictUT.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Hindi(302)")
                            {
                                marksSubjectDictUT.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "English(301)")
                            {
                                marksSubjectDictUT.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Political Science(028)")
                            {
                                marksSubjectDictUT.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Mathematics(041)")
                            {
                                marksSubjectDictUT.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Information Practices(065)" || item.subjectName == "Information Practices(265)")
                            {
                                marksSubjectDictUT.Add(item.subjectId, item.marks);
                            }
                            else
                            {
                                marksSubjectDictUT.Add(item.subjectId, item.marks);
                            }
                        }
                        foreach (MarksEntryCL item in marksColTERM1)
                        {
                            if (item.subjectName == "Physics(042)")
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Chemistry(043)")
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Biology(044)")
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Engineering Graphics(046)")
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Computer Science(083)" || item.subjectName == "Computer Science(283)")
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Physical Education(048)")
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Psychology(037)")
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Marketing(783)")
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Business Studies(054)")
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Accountancy(055)")
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Economics(030)")
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "History(027)")
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Hindi(302)")
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "English(301)")
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Political Science(028)")
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Mathematics(041)")
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Information Practices(065)" || item.subjectName == "Information Practices(265)")
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                            }
                            else
                            {
                                marksSubjectDictTERM1.Add(item.subjectId, item.marks);
                            }
                        }
                        foreach (MarksEntryCL item in marksColTERM2)
                        {
                            if (item.subjectName == "Physics(042)")
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 55));
                            }
                            else if (item.subjectName == "Chemistry(043)")
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 56));
                            }
                            else if (item.subjectName == "Biology(044)")
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 57));
                            }
                            else if (item.subjectName == "Engineering Graphics(046)")
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 58));
                            }
                            else if (item.subjectName == "Computer Science(083)" || item.subjectName == "Computer Science(283)")
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 59));
                            }
                            else if (item.subjectName == "Physical Education(048)")
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 60));
                            }
                            else if (item.subjectName == "Psychology(037)")
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 61));
                            }
                            else if (item.subjectName == "Marketing(783)")
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 62));
                            }
                            else if (item.subjectName == "Business Studies(054)")
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 63));
                            }
                            else if (item.subjectName == "Accountancy(055)")
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 64));
                            }
                            else if (item.subjectName == "Economics(030)")
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 65));
                            }
                            else if (item.subjectName == "History(027)")
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 66));
                            }
                            else if (item.subjectName == "Hindi(302)")
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 121));
                            }
                            else if (item.subjectName == "English(301)")
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 145));
                            }
                            else if (item.subjectName == "Political Science(028)")
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 146));
                            }
                            else if (item.subjectName == "Mathematics(041)")
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 147));
                            }
                            else if (item.subjectName == "Information Practices(065)" || item.subjectName == "Information Practices(265)")
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, CheckSubjectInCol(marksColCopy, 148));
                            }
                            else
                            {
                                marksSubjectDictTERM2.Add(item.subjectId, item.marks);
                                marksPracticalSubjectDict.Add(item.subjectId, string.Empty);
                            }
                        }
                        double grandTotal = 0;
                        foreach (SubjectCL item in subjectCol)
                        {
                            dr = dt.NewRow();
                            dr["Subjects"] = item.name;
                            if (marksSubjectDictTERM2.ContainsKey(item.id)|| marksSubjectDictUT.ContainsKey(item.id)|| marksSubjectDictTERM1.ContainsKey(item.id))
                            {
                                if (marksSubjectDictUT.ContainsKey(item.id))
                                {
                                    count++;
                                    dr["UT(5)"] = marksSubjectDictUT[item.id];
                                    grandTotal = grandTotal + Convert.ToDouble(marksSubjectDictUT[item.id]);
                                }
                                if (marksSubjectDictTERM1.ContainsKey(item.id))
                                {
                                    count++;
                                    dr["Term-1"] = marksSubjectDictTERM1[item.id];
                                    grandTotal = grandTotal + Convert.ToDouble(marksSubjectDictTERM1[item.id]);
                                }
                                if (marksSubjectDictTERM2.ContainsKey(item.id))
                                {
                                    count++;
                                    dr["Term-2"] = marksSubjectDictTERM2[item.id];
                                    dr["Theory"] = Math.Round(Convert.ToDouble(marksSubjectDictUT[item.id])+Convert.ToDouble(marksSubjectDictTERM1[item.id])+Convert.ToDouble(marksSubjectDictTERM2[item.id])/5,2);
                                    if (marksPracticalSubjectDict[item.id] == string.Empty)
                                    {
                                        dr["Total"] = marksSubjectDictTERM2[item.id];
                                        grandTotal = grandTotal + Convert.ToDouble(marksSubjectDictTERM2[item.id]);
                                    }
                                    else
                                    {
                                        dr["Practical"] = marksPracticalSubjectDict[item.id];
                                        dr["Total"] = Convert.ToDouble(marksSubjectDictTERM2[item.id]) + Convert.ToDouble(marksPracticalSubjectDict[item.id]);
                                        grandTotal = grandTotal + Convert.ToDouble(Convert.ToDouble(marksSubjectDictTERM2[item.id]) + Convert.ToDouble(marksPracticalSubjectDict[item.id]));
                                    }
                                }
                            }
                            else
                            {
                                dr["UT(5)"] = string.Empty;
                                dr["Term-1"] = string.Empty;
                                dr["Term-2"] = string.Empty;
                                dr["Practical"] = string.Empty;
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
                            lblPunctuality.Text = gradesColTERM2.Where(x => x.subjectId == 67).FirstOrDefault().grade;
                            lblRespectToGender.Text = gradesColTERM2.Where(x => x.subjectId == 68).FirstOrDefault().grade;
                            lblAttitudeClassmates.Text = gradesColTERM2.Where(x => x.subjectId == 69).FirstOrDefault().grade;
                            lblAttitudeTeachers.Text = gradesColTERM2.Where(x => x.subjectId == 70).FirstOrDefault().grade;
                            lblDiscipline.Text = gradesColTERM2.Where(x => x.subjectId == 71).FirstOrDefault().grade;
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