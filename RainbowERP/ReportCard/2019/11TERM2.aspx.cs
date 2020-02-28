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
                        int utExamId = reportBLL.viewExamIdByClass(studentCL.classId, "UT(40)");
                        int utNewExamId = reportBLL.viewExamIdByClass(studentCL.classId, "UT(5)");
                        int term1ExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 1(Original)");
                        int term1NewExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 1(Reduced)");
                        int term2ExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 2(Original)");
                        int term2NewExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 2(Reduced)");
                        Collection<SubjectCL> subjectCol = subjectBLL.viewSubjectByClassId(studentCL.classId);
                        Collection<MarksEntryCL> marksColUT = reportBLL.viewMarksByStudentId(studentId, utExamId);
                        Collection<MarksEntryCL> marksColTERM1 = reportBLL.viewMarksByStudentId(studentId, term1ExamId);
                        Collection<MarksEntryCL> marksColTERM2 = reportBLL.viewMarksByStudentId(studentId, term2ExamId);
                        Collection<MarksEntryCL> marksColUTNew = reportBLL.viewMarksByStudentId(studentId, utNewExamId);
                        Collection<MarksEntryCL> marksColTERM1New = reportBLL.viewMarksByStudentId(studentId, term1NewExamId);
                        Collection<MarksEntryCL> marksColTERM1Copy = marksColTERM1New;
                        Collection<MarksEntryCL> marksColTERM2New = reportBLL.viewMarksByStudentId(studentId, term2NewExamId);
                        Collection<MarksEntryCL> marksColTERM2Copy = marksColTERM2New;
                        Collection<GradeEntryCL> gradesColTERM2 = reportBLL.viewGradesByStudentId(studentId, term2NewExamId);
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
                        dt.Columns.Add(new DataColumn("UT(40)", typeof(string)));
                        dt.Columns.Add(new DataColumn("UT(5)", typeof(string)));
                        dt.Columns.Add(new DataColumn("Term-1(70)", typeof(string)));
                        dt.Columns.Add(new DataColumn("Term-1", typeof(string)));
                        dt.Columns.Add(new DataColumn("Term-2", typeof(string)));
                        dt.Columns.Add(new DataColumn("Annual", typeof(string)));
                        dt.Columns.Add(new DataColumn("UT+Term-1+Term-2", typeof(string)));
                        dt.Columns.Add(new DataColumn("Practical - Term 1", typeof(string)));
                        dt.Columns.Add(new DataColumn("Practical - Term 2", typeof(string)));
                        dt.Columns.Add(new DataColumn("Grand Total", typeof(string)));
                        IDictionary<int, string> marksSubjectDictUTOld = new Dictionary<int, string>();
                        IDictionary<int, string> marksSubjectDictUTNew = new Dictionary<int, string>();
                        IDictionary<int, string> marksSubjectDictTERM1Old = new Dictionary<int, string>();
                        IDictionary<int, string> marksSubjectDictTERM2Old = new Dictionary<int, string>();
                        IDictionary<int, string> marksSubjectDictNew = new Dictionary<int, string>();
                        IDictionary<int, string> marksSubjectDictTERM1New = new Dictionary<int, string>();
                        IDictionary<int, string> marksSubjectDictTERM2New = new Dictionary<int, string>();
                        IDictionary<int, string> marksPracticalTERM1SubjectDictNew = new Dictionary<int, string>();
                        IDictionary<int, string> marksPracticalTERM2SubjectDictNew = new Dictionary<int, string>();
                        int count = 0;
                        foreach (MarksEntryCL item in marksColUT)
                        {
                            if (item.subjectName == "Physics(042)")
                            {
                                marksSubjectDictUTOld.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Chemistry(043)")
                            {
                                marksSubjectDictUTOld.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Biology(044)")
                            {
                                marksSubjectDictUTOld.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Engineering Graphics(046)")
                            {
                                marksSubjectDictUTOld.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Computer Science(083)" || item.subjectName == "Computer Science(283)")
                            {
                                marksSubjectDictUTOld.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Physical Education(048)")
                            {
                                marksSubjectDictUTOld.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Psychology(037)")
                            {
                                marksSubjectDictUTOld.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Marketing(783)")
                            {
                                marksSubjectDictUTOld.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Business Studies(054)")
                            {
                                marksSubjectDictUTOld.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Accountancy(055)")
                            {
                                marksSubjectDictUTOld.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Economics(030)")
                            {
                                marksSubjectDictUTOld.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "History(027)")
                            {
                                marksSubjectDictUTOld.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Hindi(302)")
                            {
                                marksSubjectDictUTOld.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "English(301)")
                            {
                                marksSubjectDictUTOld.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Political Science(028)")
                            {
                                marksSubjectDictUTOld.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Mathematics(041)")
                            {
                                marksSubjectDictUTOld.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Information Practices(065)" || item.subjectName == "Information Practices(265)")
                            {
                                marksSubjectDictUTOld.Add(item.subjectId, item.marks);
                            }
                            else
                            {
                                marksSubjectDictUTOld.Add(item.subjectId, item.marks);
                            }
                        }
                        foreach (MarksEntryCL item in marksColUTNew)
                        {
                            if (item.subjectName == "Physics(042)")
                            {
                                marksSubjectDictUTNew.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Chemistry(043)")
                            {
                                marksSubjectDictUTNew.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Biology(044)")
                            {
                                marksSubjectDictUTNew.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Engineering Graphics(046)")
                            {
                                marksSubjectDictUTNew.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Computer Science(083)" || item.subjectName == "Computer Science(283)")
                            {
                                marksSubjectDictUTNew.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Physical Education(048)")
                            {
                                marksSubjectDictUTNew.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Psychology(037)")
                            {
                                marksSubjectDictUTNew.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Marketing(783)")
                            {
                                marksSubjectDictUTNew.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Business Studies(054)")
                            {
                                marksSubjectDictUTNew.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Accountancy(055)")
                            {
                                marksSubjectDictUTNew.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Economics(030)")
                            {
                                marksSubjectDictUTNew.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "History(027)")
                            {
                                marksSubjectDictUTNew.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Hindi(302)")
                            {
                                marksSubjectDictUTNew.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "English(301)")
                            {
                                marksSubjectDictUTNew.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Political Science(028)")
                            {
                                marksSubjectDictUTNew.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Mathematics(041)")
                            {
                                marksSubjectDictUTNew.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Information Practices(065)" || item.subjectName == "Information Practices(265)")
                            {
                                marksSubjectDictUTNew.Add(item.subjectId, item.marks);
                            }
                            else
                            {
                                marksSubjectDictUTNew.Add(item.subjectId, item.marks);
                            }
                        }
                        foreach (MarksEntryCL item in marksColTERM1)
                        {
                            if (item.subjectName == "Physics(042)")
                            {
                                marksSubjectDictTERM1Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Chemistry(043)")
                            {
                                marksSubjectDictTERM1Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Biology(044)")
                            {
                                marksSubjectDictTERM1Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Engineering Graphics(046)")
                            {
                                marksSubjectDictTERM1Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Computer Science(083)" || item.subjectName == "Computer Science(283)")
                            {
                                marksSubjectDictTERM1Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Physical Education(048)")
                            {
                                marksSubjectDictTERM1Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Psychology(037)")
                            {
                                marksSubjectDictTERM1Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Marketing(783)")
                            {
                                marksSubjectDictTERM1Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Business Studies(054)")
                            {
                                marksSubjectDictTERM1Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Accountancy(055)")
                            {
                                marksSubjectDictTERM1Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Economics(030)")
                            {
                                marksSubjectDictTERM1Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "History(027)")
                            {
                                marksSubjectDictTERM1Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Hindi(302)")
                            {
                                marksSubjectDictTERM1Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "English(301)")
                            {
                                marksSubjectDictTERM1Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Political Science(028)")
                            {
                                marksSubjectDictTERM1Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Mathematics(041)")
                            {
                                marksSubjectDictTERM1Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Information Practices(065)" || item.subjectName == "Information Practices(265)")
                            {
                                marksSubjectDictTERM1Old.Add(item.subjectId, item.marks);
                            }
                            else
                            {
                                marksSubjectDictTERM1Old.Add(item.subjectId, item.marks);
                            }
                        }
                        foreach (MarksEntryCL item in marksColTERM1New)
                        {
                            if (item.subjectName == "Physics(042)")
                            {
                                marksSubjectDictTERM1New.Add(item.subjectId, item.marks);
                                marksPracticalTERM1SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM1Copy, 55));
                            }
                            else if (item.subjectName == "Chemistry(043)")
                            {
                                marksSubjectDictTERM1New.Add(item.subjectId, item.marks);
                                marksPracticalTERM1SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM1Copy, 56));
                            }
                            else if (item.subjectName == "Biology(044)")
                            {
                                marksSubjectDictTERM1New.Add(item.subjectId, item.marks);
                                marksPracticalTERM1SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM1Copy, 57));
                            }
                            else if (item.subjectName == "Engineering Graphics(046)")
                            {
                                marksSubjectDictTERM1New.Add(item.subjectId, item.marks);
                                marksPracticalTERM1SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM1Copy, 58));
                            }
                            else if (item.subjectName == "Computer Science(083)" || item.subjectName == "Computer Science(283)")
                            {
                                marksSubjectDictTERM1New.Add(item.subjectId, item.marks);
                                marksPracticalTERM1SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM1Copy, 59));
                            }
                            else if (item.subjectName == "Physical Education(048)")
                            {
                                marksSubjectDictTERM1New.Add(item.subjectId, item.marks);
                                marksPracticalTERM1SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM1Copy, 60));
                            }
                            else if (item.subjectName == "Psychology(037)")
                            {
                                marksSubjectDictTERM1New.Add(item.subjectId, item.marks);
                                marksPracticalTERM1SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM1Copy, 61));
                            }
                            else if (item.subjectName == "Marketing(783)")
                            {
                                marksSubjectDictTERM1New.Add(item.subjectId, item.marks);
                                marksPracticalTERM1SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM1Copy, 62));
                            }
                            else if (item.subjectName == "Business Studies(054)")
                            {
                                marksSubjectDictTERM1New.Add(item.subjectId, item.marks);
                                marksPracticalTERM1SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM1Copy, 63));
                            }
                            else if (item.subjectName == "Accountancy(055)")
                            {
                                marksSubjectDictTERM1New.Add(item.subjectId, item.marks);
                                marksPracticalTERM1SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM1Copy, 64));
                            }
                            else if (item.subjectName == "Economics(030)")
                            {
                                marksSubjectDictTERM1New.Add(item.subjectId, item.marks);
                                marksPracticalTERM1SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM1Copy, 65));
                            }
                            else if (item.subjectName == "History(027)")
                            {
                                marksSubjectDictTERM1New.Add(item.subjectId, item.marks);
                                marksPracticalTERM1SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM1Copy, 66));
                            }
                            else if (item.subjectName == "Hindi(302)")
                            {
                                marksSubjectDictTERM1New.Add(item.subjectId, item.marks);
                                marksPracticalTERM1SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM1Copy, 121));
                            }
                            else if (item.subjectName == "English(301)")
                            {
                                marksSubjectDictTERM1New.Add(item.subjectId, item.marks);
                                marksPracticalTERM1SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM1Copy, 145));
                            }
                            else if (item.subjectName == "Political Science(028)")
                            {
                                marksSubjectDictTERM1New.Add(item.subjectId, item.marks);
                                marksPracticalTERM1SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM1Copy, 146));
                            }
                            else if (item.subjectName == "Mathematics(041)")
                            {
                                marksSubjectDictTERM1New.Add(item.subjectId, item.marks);
                                marksPracticalTERM1SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM1Copy, 147));
                            }
                            else if (item.subjectName == "Information Practices(065)" || item.subjectName == "Information Practices(265)")
                            {
                                marksSubjectDictTERM1New.Add(item.subjectId, item.marks);
                                marksPracticalTERM1SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM1Copy, 148));
                            }
                            else
                            {
                                marksSubjectDictTERM1New.Add(item.subjectId, item.marks);
                                marksPracticalTERM1SubjectDictNew.Add(item.subjectId, string.Empty);
                            }
                        }
                        foreach (MarksEntryCL item in marksColTERM2)
                        {
                            if (item.subjectName == "Physics(042)")
                            {
                                marksSubjectDictTERM2Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Chemistry(043)")
                            {
                                marksSubjectDictTERM2Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Biology(044)")
                            {
                                marksSubjectDictTERM2Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Engineering Graphics(046)")
                            {
                                marksSubjectDictTERM2Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Computer Science(083)" || item.subjectName == "Computer Science(283)")
                            {
                                marksSubjectDictTERM2Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Physical Education(048)")
                            {
                                marksSubjectDictTERM2Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Psychology(037)")
                            {
                                marksSubjectDictTERM2Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Marketing(783)")
                            {
                                marksSubjectDictTERM2Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Business Studies(054)")
                            {
                                marksSubjectDictTERM2Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Accountancy(055)")
                            {
                                marksSubjectDictTERM2Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Economics(030)")
                            {
                                marksSubjectDictTERM2Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "History(027)")
                            {
                                marksSubjectDictTERM2Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Hindi(302)")
                            {
                                marksSubjectDictTERM2Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "English(301)")
                            {
                                marksSubjectDictTERM2Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Political Science(028)")
                            {
                                marksSubjectDictTERM2Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Mathematics(041)")
                            {
                                marksSubjectDictTERM2Old.Add(item.subjectId, item.marks);
                            }
                            else if (item.subjectName == "Information Practices(065)" || item.subjectName == "Information Practices(265)")
                            {
                                marksSubjectDictTERM2Old.Add(item.subjectId, item.marks);
                            }
                            else
                            {
                                marksSubjectDictTERM2Old.Add(item.subjectId, item.marks);
                            }
                        }
                        foreach (MarksEntryCL item in marksColTERM2New)
                        {
                            if (item.subjectName == "Physics(042)")
                            {
                                marksSubjectDictTERM2New.Add(item.subjectId, item.marks);
                                marksPracticalTERM2SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM2Copy, 55));
                            }
                            else if (item.subjectName == "Chemistry(043)")
                            {
                                marksSubjectDictTERM2New.Add(item.subjectId, item.marks);
                                marksPracticalTERM2SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM2Copy, 56));
                            }
                            else if (item.subjectName == "Biology(044)")
                            {
                                marksSubjectDictTERM2New.Add(item.subjectId, item.marks);
                                marksPracticalTERM2SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM2Copy, 57));
                            }
                            else if (item.subjectName == "Engineering Graphics(046)")
                            {
                                marksSubjectDictTERM2New.Add(item.subjectId, item.marks);
                                marksPracticalTERM2SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM2Copy, 58));
                            }
                            else if (item.subjectName == "Computer Science(083)" || item.subjectName == "Computer Science(283)")
                            {
                                marksSubjectDictTERM2New.Add(item.subjectId, item.marks);
                                marksPracticalTERM2SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM2Copy, 59));
                            }
                            else if (item.subjectName == "Physical Education(048)")
                            {
                                marksSubjectDictTERM2New.Add(item.subjectId, item.marks);
                                marksPracticalTERM2SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM2Copy, 60));
                            }
                            else if (item.subjectName == "Psychology(037)")
                            {
                                marksSubjectDictTERM2New.Add(item.subjectId, item.marks);
                                marksPracticalTERM2SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM2Copy, 61));
                            }
                            else if (item.subjectName == "Marketing(783)")
                            {
                                marksSubjectDictTERM2New.Add(item.subjectId, item.marks);
                                marksPracticalTERM2SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM2Copy, 62));
                            }
                            else if (item.subjectName == "Business Studies(054)")
                            {
                                marksSubjectDictTERM2New.Add(item.subjectId, item.marks);
                                marksPracticalTERM2SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM2Copy, 63));
                            }
                            else if (item.subjectName == "Accountancy(055)")
                            {
                                marksSubjectDictTERM2New.Add(item.subjectId, item.marks);
                                marksPracticalTERM2SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM2Copy, 64));
                            }
                            else if (item.subjectName == "Economics(030)")
                            {
                                marksSubjectDictTERM2New.Add(item.subjectId, item.marks);
                                marksPracticalTERM2SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM2Copy, 65));
                            }
                            else if (item.subjectName == "History(027)")
                            {
                                marksSubjectDictTERM2New.Add(item.subjectId, item.marks);
                                marksPracticalTERM2SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM2Copy, 66));
                            }
                            else if (item.subjectName == "Hindi(302)")
                            {
                                marksSubjectDictTERM2New.Add(item.subjectId, item.marks);
                                marksPracticalTERM2SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM2Copy, 121));
                            }
                            else if (item.subjectName == "English(301)")
                            {
                                marksSubjectDictTERM2New.Add(item.subjectId, item.marks);
                                marksPracticalTERM2SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM2Copy, 145));
                            }
                            else if (item.subjectName == "Political Science(028)")
                            {
                                marksSubjectDictTERM2New.Add(item.subjectId, item.marks);
                                marksPracticalTERM2SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM2Copy, 146));
                            }
                            else if (item.subjectName == "Mathematics(041)")
                            {
                                marksSubjectDictTERM2New.Add(item.subjectId, item.marks);
                                marksPracticalTERM2SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM2Copy, 147));
                            }
                            else if (item.subjectName == "Information Practices(065)" || item.subjectName == "Information Practices(265)")
                            {
                                marksSubjectDictTERM2New.Add(item.subjectId, item.marks);
                                marksPracticalTERM2SubjectDictNew.Add(item.subjectId, CheckSubjectInCol(marksColTERM2Copy, 148));
                            }
                            else
                            {
                                marksSubjectDictTERM2New.Add(item.subjectId, item.marks);
                                marksPracticalTERM2SubjectDictNew.Add(item.subjectId, string.Empty);
                            }
                        }
                        double grandTotal = 0;
                        foreach (SubjectCL item in subjectCol)
                        {
                            double theory = 0;
                            double total = 0;
                            dr = dt.NewRow();
                            dr["Subjects"] = item.name;
                            if (marksSubjectDictUTOld.ContainsKey(item.id)|| marksSubjectDictUTNew.ContainsKey(item.id)|| marksSubjectDictTERM1Old.ContainsKey(item.id)|| marksSubjectDictTERM1New.ContainsKey(item.id)|| marksSubjectDictTERM2Old.ContainsKey(item.id)|| marksSubjectDictTERM2New.ContainsKey(item.id))
                            {
                                if (marksSubjectDictUTOld.ContainsKey(item.id))
                                {
                                    count++;
                                    dr["UT(40)"] = Convert.ToDouble(marksSubjectDictUTOld[item.id]);
                                }
                                if (marksSubjectDictUTNew.ContainsKey(item.id))
                                {
                                    count++;
                                    dr["UT(5)"] = marksSubjectDictUTNew[item.id];
                                    theory = theory + Convert.ToDouble(marksSubjectDictUTNew[item.id]);
                                }
                                if (marksSubjectDictTERM1Old.ContainsKey(item.id))
                                {
                                    count++;
                                    dr["Term-1(70)"] = marksSubjectDictTERM1Old[item.id];
                                }
                                if (marksSubjectDictTERM1New.ContainsKey(item.id))
                                {
                                    count++;
                                    dr["Term-1"] = marksSubjectDictTERM1New[item.id];
                                    theory = theory + Convert.ToDouble(marksSubjectDictTERM1New[item.id]);
                                    dr["Practical - Term 1"] = marksPracticalTERM1SubjectDictNew[item.id];
                                    total = total + Convert.ToDouble(marksPracticalTERM1SubjectDictNew[item.id]);
                                }
                                if (marksSubjectDictTERM2Old.ContainsKey(item.id))
                                {
                                    count++;
                                    dr["Term-2"] = marksSubjectDictTERM2Old[item.id];
                                }
                                if (marksSubjectDictTERM2New.ContainsKey(item.id))
                                {
                                    count++;
                                    dr["Annual"] = marksSubjectDictTERM2New[item.id];
                                    theory = theory + Convert.ToDouble(marksSubjectDictTERM2New[item.id]);
                                    dr["Practical - Term 2"] = marksPracticalTERM2SubjectDictNew[item.id];
                                    total = total + Convert.ToDouble(marksPracticalTERM2SubjectDictNew[item.id]);
                                }
                                dr["UT+Term-1+Term-2"] = theory;
                                grandTotal = grandTotal + total;
                                dr["Grand Total"] = total;
                            }
                            else
                            {
                                dr["UT(40)"] = string.Empty;
                                dr["UT(5)"] = string.Empty;
                                dr["Term-1(70)"] = string.Empty;
                                dr["Term-1"] = string.Empty;
                                dr["Term-2"] = string.Empty;
                                dr["Annual"] = string.Empty;
                                dr["UT+Term-1+Term-2"] = string.Empty;
                                dr["Practical - Term 1"] = string.Empty;
                                dr["Practical - Term 2"] = string.Empty;
                                dr["Grand Total"] = string.Empty;
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
                        catch (Exception ex)
                        {
                            throw(ex);
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