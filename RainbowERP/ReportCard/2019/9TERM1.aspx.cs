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

namespace RainbowERP.ReportCard._2019
{
    public partial class _9TERM1 : System.Web.UI.Page
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
                        lblAdmissionNo.Text = studentCL.admissionNo.ToString();
                        lblClassSec.Text = studentCL.classSection;
                        int term1ExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 1");
                        int ptId = reportBLL.viewExamIdByClass(studentCL.classId, "PT(10)");
                        int maId = reportBLL.viewExamIdByClass(studentCL.classId, "MA(5)");
                        int seaId = reportBLL.viewExamIdByClass(studentCL.classId, "SEA(5)");
                        int portId = reportBLL.viewExamIdByClass(studentCL.classId, "Portfolio(5)");
                        //int examinationId = Convert.ToInt32(Request.QueryString["examId"]);
                        //Collection<SubjectCL> subjectCol = subjectBLL.viewSubjectByClassId(studentCL.classId);
                        Collection<MarksEntryCL> marksTerm1Col = reportBLL.viewMarksByStudentId(studentId, term1ExamId);
                        Collection<MarksEntryCL> marksPTCol = reportBLL.viewMarksByStudentId(studentId, ptId);
                        Collection<MarksEntryCL> marksMACol = reportBLL.viewMarksByStudentId(studentId, maId);
                        Collection<MarksEntryCL> marksSEACol = reportBLL.viewMarksByStudentId(studentId, seaId);
                        Collection<MarksEntryCL> marksPortCol = reportBLL.viewMarksByStudentId(studentId, portId);
                        Collection<GradeEntryCL> gradeCol = reportBLL.viewGradesByStudentId(studentId, term1ExamId);
                        MiscEntryCL remarksAttendance = reportBLL.viewMiscByStudentId(studentId, term1ExamId);
                        lblEnglishPT.Text = marksPTCol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblEnglishMA.Text = marksMACol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblEnglishSEA.Text = marksSEACol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblEnglishPortfolio.Text = marksPortCol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblEnglishTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblEnglishTotal.Text = (Convert.ToDouble(lblEnglishPT.Text) + Convert.ToDouble(lblEnglishMA.Text) + Convert.ToDouble(lblEnglishSEA.Text) + Convert.ToDouble(lblEnglishPortfolio.Text) + Convert.ToDouble(lblEnglishTerm1.Text)).ToString();
                        lblEnglishGrade.Text = ConvertToGrade(Convert.ToDouble(lblEnglishTotal.Text));
                        lblHindiPT.Text = marksPTCol.Where(x => x.subjectId == 13).FirstOrDefault().marks;
                        lblHindiMA.Text = marksMACol.Where(x => x.subjectId == 13).FirstOrDefault().marks;
                        lblHindiSEA.Text = marksSEACol.Where(x => x.subjectId == 13).FirstOrDefault().marks;
                        lblHindiPortfolio.Text = marksPortCol.Where(x => x.subjectId == 13).FirstOrDefault().marks;
                        lblHindiTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 13).FirstOrDefault().marks;
                        lblHindiTotal.Text = (Convert.ToDouble(lblHindiPT.Text) + Convert.ToDouble(lblHindiMA.Text) + Convert.ToDouble(lblHindiSEA.Text) + Convert.ToDouble(lblHindiPortfolio.Text) + Convert.ToDouble(lblHindiTerm1.Text)).ToString();
                        lblHindiGrade.Text = ConvertToGrade(Convert.ToDouble(lblHindiTotal.Text));
                        lblMathematicsPT.Text = marksPTCol.Where(x => x.subjectId == 1).FirstOrDefault().marks;
                        lblMathematicsMA.Text = marksMACol.Where(x => x.subjectId == 1).FirstOrDefault().marks;
                        lblMathematicsSEA.Text = marksSEACol.Where(x => x.subjectId == 1).FirstOrDefault().marks;
                        lblMathematicsPortfolio.Text = marksPortCol.Where(x => x.subjectId == 1).FirstOrDefault().marks;
                        lblMathematicsTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 1).FirstOrDefault().marks;
                        lblMathematicsTotal.Text = (Convert.ToDouble(lblMathematicsPT.Text) + Convert.ToDouble(lblMathematicsMA.Text) + Convert.ToDouble(lblMathematicsSEA.Text) + Convert.ToDouble(lblMathematicsPortfolio.Text) + Convert.ToDouble(lblMathematicsTerm1.Text)).ToString();
                        lblMathematicsGrade.Text = ConvertToGrade(Convert.ToDouble(lblMathematicsTotal.Text));
                        lblSciencePT.Text = marksPTCol.Where(x => x.subjectId == 29).FirstOrDefault().marks;
                        lblScienceMA.Text = marksMACol.Where(x => x.subjectId == 29).FirstOrDefault().marks;
                        lblScienceSEA.Text = marksSEACol.Where(x => x.subjectId == 29).FirstOrDefault().marks;
                        lblSciencePortfolio.Text = marksPortCol.Where(x => x.subjectId == 29).FirstOrDefault().marks;
                        lblScienceTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 29).FirstOrDefault().marks;
                        lblScienceTotal.Text = (Convert.ToDouble(lblSciencePT.Text) + Convert.ToDouble(lblScienceMA.Text) + Convert.ToDouble(lblScienceSEA.Text) + Convert.ToDouble(lblSciencePortfolio.Text) + Convert.ToDouble(lblScienceTerm1.Text)).ToString();
                        lblScienceGrade.Text = ConvertToGrade(Convert.ToDouble(lblScienceTotal.Text));
                        lblSocialSciencePT.Text = marksPTCol.Where(x => x.subjectId == 35).FirstOrDefault().marks;
                        lblSocialScienceMA.Text = marksMACol.Where(x => x.subjectId == 35).FirstOrDefault().marks;
                        lblSocialScienceSEA.Text = marksSEACol.Where(x => x.subjectId == 35).FirstOrDefault().marks;
                        lblSocialSciencePortolio.Text = marksPortCol.Where(x => x.subjectId == 35).FirstOrDefault().marks;
                        lblSocialScienceTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 35).FirstOrDefault().marks;
                        lblSocialScienceTotal.Text = (Convert.ToDouble(lblSocialSciencePT.Text) + Convert.ToDouble(lblSocialScienceMA.Text) + Convert.ToDouble(lblSocialScienceSEA.Text) + Convert.ToDouble(lblSocialSciencePortolio.Text) + Convert.ToDouble(lblSocialScienceTerm1.Text)).ToString();
                        lblSocialScienceGrade.Text = ConvertToGrade(Convert.ToDouble(lblSocialScienceTotal.Text));
                        lblITTheory.Text = marksTerm1Col.Where(x => x.subjectId == 47).FirstOrDefault().marks;
                        lblITPractical.Text = marksTerm1Col.Where(x => x.subjectId == 122).FirstOrDefault().marks;
                        lblITTotal.Text = (Convert.ToDouble(lblITTheory.Text) + Convert.ToDouble(lblITPractical.Text)).ToString();
                        lblITGrade.Text = ConvertToGrade(Convert.ToDouble(lblITTotal.Text));
                        lblArtEdu.Text = gradeCol.Where(x => x.subjectId == 52).FirstOrDefault().grade;
                        lblWorkEdu.Text = gradeCol.Where(x => x.subjectId == 51).FirstOrDefault().grade;
                        lblPhysicalEdu.Text = gradeCol.Where(x => x.subjectId == 53).FirstOrDefault().grade;
                        lblRegularity.Text = gradeCol.Where(x => x.subjectId == 67).FirstOrDefault().grade;
                        lblSincerity.Text = gradeCol.Where(x => x.subjectId == 119).FirstOrDefault().grade;
                        lblBehaviour.Text = gradeCol.Where(x => x.subjectId == 120).FirstOrDefault().grade;
                        lblAttitudeTeachers.Text = gradeCol.Where(x => x.subjectId == 70).FirstOrDefault().grade;
                        lblAttitudeStudents.Text = gradeCol.Where(x => x.subjectId == 69).FirstOrDefault().grade;
                        lblGrade.Text = ConvertToGrade((Convert.ToDouble(lblScienceTotal.Text) + Convert.ToDouble(lblEnglishTotal.Text) + Convert.ToDouble(lblHindiTotal.Text) + Convert.ToDouble(lblSocialScienceTotal.Text) + Convert.ToDouble(lblMathematicsTotal.Text) + Convert.ToDouble(lblITTotal.Text)) / 6);
                        lblAttendance.Text = remarksAttendance.attendance;
                        lblRemarks.Text = remarksAttendance.remarks;
                    }
                }
            }
        }
        private string ConvertToGrade(double total)
        {
            string Grade;
            if (total >= 91 && total <= 100)
            {
                Grade = "A1";
            }
            else if (total >= 81 && total < 91)
            {
                Grade = "A2";
            }
            else if (total >= 71 && total < 81)
            {
                Grade = "B1";
            }
            else if (total >= 61 && total < 71)
            {
                Grade = "B2";
            }
            else if (total >= 51 && total < 61)
            {
                Grade = "C1";
            }
            else if (total >= 41 && total < 51)
            {
                Grade = "C2";
            }
            else if (total > 32 && total < 41)
            {
                Grade = "D";
            }
            else
            {
                Grade = "E (NEED Impovement)";
            }
            return Grade;
        }
    }
}