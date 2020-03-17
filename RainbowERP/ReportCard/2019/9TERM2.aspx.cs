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
    public partial class _9TERM2 : System.Web.UI.Page
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
                        int ptId = reportBLL.viewExamIdByClass(studentCL.classId, "Avg of Best 2 PT(5)");
                        int maId = reportBLL.viewExamIdByClass(studentCL.classId, "MA2(5)");
                        int seaId = reportBLL.viewExamIdByClass(studentCL.classId, "SEA2(5)");
                        int portfolioId = reportBLL.viewExamIdByClass(studentCL.classId, "Portfolio2(5)");
                        int term1Id = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 1(20)");
                        int term2Id = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 2(60)");
                        int itTheoryId = reportBLL.viewExamIdByClass(studentCL.classId, "IT Theory(50)");
                        int itPracticalId = reportBLL.viewExamIdByClass(studentCL.classId, "IT Practical(50)");
                        int term2GenExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 2 - GENERAL");
                        //int examinationId = Convert.ToInt32(Request.QueryString["examId"]);
                        //Collection<SubjectCL> subjectCol = subjectBLL.viewSubjectByClassId(studentCL.classId);
                        MiscEntryCL remarksAttendance = reportBLL.viewMiscByStudentId(studentId, term2GenExamId);
                        Collection<MarksEntryCL> marksPTCol = reportBLL.viewMarksByStudentId(studentId, ptId);
                        Collection<MarksEntryCL> marksMACol = reportBLL.viewMarksByStudentId(studentId, maId);
                        Collection<MarksEntryCL> marksSEACol = reportBLL.viewMarksByStudentId(studentId, seaId);
                        Collection<MarksEntryCL> marksPortfolioCol = reportBLL.viewMarksByStudentId(studentId, portfolioId);
                        Collection<MarksEntryCL> marksTERM1Col = reportBLL.viewMarksByStudentId(studentId, term1Id);
                        Collection<MarksEntryCL> marksTERM2Col = reportBLL.viewMarksByStudentId(studentId, term2Id);
                        Collection<MarksEntryCL> marksTheoryCol = reportBLL.viewMarksByStudentId(studentId, itTheoryId);
                        Collection<MarksEntryCL> marksPracticalCol = reportBLL.viewMarksByStudentId(studentId, itPracticalId);
                        Collection<GradeEntryCL> gradeCol = reportBLL.viewGradesByStudentId(studentId, term2GenExamId);
                        lblAttendance.Text = remarksAttendance.attendance;
                        lblRemarks.Text = remarksAttendance.remarks;
                        lblEnglishPT.Text = marksPTCol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblEnglishMA.Text = marksMACol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblEnglishSEA.Text = marksSEACol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblEnglishPortfolio.Text = marksPortfolioCol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblEnglishTerm1.Text = marksTERM1Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblEnglishTerm2.Text = marksTERM2Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblEnglishTotal.Text = (Convert.ToDouble(lblEnglishPT.Text) + Convert.ToDouble(lblEnglishMA.Text) + Convert.ToDouble(lblEnglishSEA.Text) + Convert.ToDouble(lblEnglishPortfolio.Text) + Convert.ToDouble(lblEnglishTerm1.Text) + Convert.ToDouble(lblEnglishTerm2.Text)).ToString();
                        lblEnglishGrade.Text = ConvertToGrade(Convert.ToDouble(lblEnglishTotal.Text));
                        lblHindiPT.Text = marksPTCol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblHindiMA.Text = marksMACol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblHindiSEA.Text = marksSEACol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblHindiPortfolio.Text = marksPortfolioCol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblHindiTerm1.Text = marksTERM1Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblHindiTerm2.Text = marksTERM2Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblHindiTotal.Text = (Convert.ToDouble(lblHindiPT.Text) + Convert.ToDouble(lblHindiMA.Text) + Convert.ToDouble(lblHindiSEA.Text) + Convert.ToDouble(lblHindiPortfolio.Text) + Convert.ToDouble(lblHindiTerm1.Text) + Convert.ToDouble(lblHindiTerm2.Text)).ToString();
                        lblHindiGrade.Text = ConvertToGrade(Convert.ToDouble(lblHindiTotal.Text)); 
                        lblMathematicsPT.Text = marksPTCol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblMathematicsMA.Text = marksMACol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblMathematicsSEA.Text = marksSEACol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblMathematicsPortfolio.Text = marksPortfolioCol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblMathematicsTerm1.Text = marksTERM1Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblMathematicsTerm2.Text = marksTERM2Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblMathematicsTotal.Text = (Convert.ToDouble(lblMathematicsPT.Text) + Convert.ToDouble(lblMathematicsMA.Text) + Convert.ToDouble(lblMathematicsSEA.Text) + Convert.ToDouble(lblMathematicsPortfolio.Text) + Convert.ToDouble(lblMathematicsTerm1.Text) + Convert.ToDouble(lblMathematicsTerm2.Text)).ToString();
                        lblMathematicsGrade.Text = ConvertToGrade(Convert.ToDouble(lblMathematicsTotal.Text));
                        lblSciencePT.Text = marksPTCol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblScienceMA.Text = marksMACol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblScienceSEA.Text = marksSEACol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblSciencePortfolio.Text = marksPortfolioCol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblScienceTerm1.Text = marksTERM1Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblScienceTerm2.Text = marksTERM2Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblScienceTotal.Text = (Convert.ToDouble(lblSciencePT.Text) + Convert.ToDouble(lblScienceMA.Text) + Convert.ToDouble(lblScienceSEA.Text) + Convert.ToDouble(lblSciencePortfolio.Text) + Convert.ToDouble(lblScienceTerm1.Text) + Convert.ToDouble(lblScienceTerm2.Text)).ToString();
                        lblScienceGrade.Text = ConvertToGrade(Convert.ToDouble(lblScienceTotal.Text));
                        lblSocialSciencePT.Text = marksPTCol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblSocialScienceMA.Text = marksMACol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblSocialScienceSEA.Text = marksSEACol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblSocialSciencePortfolio.Text = marksPortfolioCol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblSocialScienceTerm1.Text = marksTERM1Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblSocialScienceTerm2.Text = marksTERM2Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblSocialScienceTotal.Text = (Convert.ToDouble(lblSocialSciencePT.Text) + Convert.ToDouble(lblSocialScienceMA.Text) + Convert.ToDouble(lblSocialScienceSEA.Text) + Convert.ToDouble(lblSocialSciencePortfolio.Text) + Convert.ToDouble(lblSocialScienceTerm1.Text) + Convert.ToDouble(lblSocialScienceTerm2.Text)).ToString();
                        lblSocialScienceGrade.Text = ConvertToGrade(Convert.ToDouble(lblSocialScienceTotal.Text));
                        lblITTheory.Text = marksTheoryCol.FirstOrDefault().marks;
                        lblITPractical.Text = marksPracticalCol.FirstOrDefault().marks;
                        lblITTotal.Text = Convert.ToDouble(lblITTheory.Text) + Convert.ToDouble(lblITPractical.Text).ToString();
                        lblITGrade.Text = ConvertToGrade(Convert.ToDouble(lblITTotal.Text));
                        lblGrandTotal.Text = Math.Ceiling(Convert.ToDouble(lblEnglishTotal.Text) + Convert.ToDouble(lblHindiTotal.Text) + Convert.ToDouble(lblMathematicsTotal.Text) + Convert.ToDouble(lblScienceTotal.Text) + Convert.ToDouble(lblSocialScienceTotal.Text)).ToString();
                        lblPercentage.Text = Math.Ceiling(Convert.ToDouble(lblGrandTotal.Text) / 5).ToString();
                        lblGrade.Text = ConvertToGrade(Convert.ToDouble(lblPercentage.Text)).ToString();
                        lblArtEdu.Text = gradeCol.Where(x => x.subjectId == 52).FirstOrDefault().grade;
                        lblWorkEdu.Text = gradeCol.Where(x => x.subjectId == 51).FirstOrDefault().grade;
                        lblPhysicalEdu.Text = gradeCol.Where(x => x.subjectId == 53).FirstOrDefault().grade;
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