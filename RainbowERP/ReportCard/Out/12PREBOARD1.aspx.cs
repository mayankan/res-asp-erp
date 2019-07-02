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
    public partial class _12PREBOARD1 : System.Web.UI.Page
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
                        StudentCL studentCL = new StudentCL();
                        //StudentCL studentCL = studentBLL.viewStudentById(studentId);
                        lblStudentName.Text = studentCL.studentName;
                        lblFatherName.Text = studentCL.fatherName;
                        lblMotherName.Text = studentCL.motherName;
                        lblAdmissionNo.Text = studentCL.admissionNo.ToString();
                        lblClassSec.Text = studentCL.classSection;
                        lblExamination.Text = "PRE-BOARD 1";
                        int examinationId = reportBLL.viewExamIdByClass(studentCL.classId, "PRE-BOARD 1");
                        Collection<SubjectCL> subjectCol = subjectBLL.viewSubjectByClassId(studentCL.classId);
                        Collection<MarksEntryCL> marksCol = reportBLL.viewMarksByStudentId(studentId, examinationId);
                        Collection<GradeEntryCL> gradeCol = reportBLL.viewGradesByStudentId(studentId, examinationId);
                        Collection<MarksEntryCL> marksColCopy = marksCol;
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
                        dt.Columns.Add(new DataColumn("Theory", typeof(string)));
                        dt.Columns.Add(new DataColumn("Practical", typeof(string)));
                        dt.Columns.Add(new DataColumn("Total", typeof(string)));
                        IDictionary<int, string> marksSubjectDict = new Dictionary<int, string>();
                        IDictionary<int, string> marksPracticalSubjectDict = new Dictionary<int, string>();
                        foreach (MarksEntryCL item in marksCol)
                        {
                            if (item.subjectId != 2 && item.subjectId != 3 && item.subjectId != 4 && item.subjectId != 5 && item.subjectId != 6 && item.subjectId != 15 && item.subjectId != 7 && item.subjectId != 11 && item.subjectId != 9 && item.subjectId != 8 && item.subjectId != 10 && item.subjectId != 14)
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
                        lblPercentage.Text = (grandTotal / 5) + "%";
                        lblPunctuality.Text = gradeCol.Where(x => x.subjectId == 67).FirstOrDefault().grade;
                        lblOppGender.Text = gradeCol.Where(x => x.subjectId == 68).FirstOrDefault().grade;
                        lblClassMates.Text = gradeCol.Where(x => x.subjectId == 69).FirstOrDefault().grade;
                        lblTeachers.Text = gradeCol.Where(x => x.subjectId == 70).FirstOrDefault().grade;
                        lblDiscipline.Text = gradeCol.Where(x => x.subjectId == 71).FirstOrDefault().grade;
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