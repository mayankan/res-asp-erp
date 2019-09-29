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

namespace RAINBOW_ERP.ReportCard.Out
{
    public partial class _6TERM2 : System.Web.UI.Page
    {
        SubjectBLL subjectBLL = new SubjectBLL();
        ReportCardEntryBLL reportBLL = new ReportCardEntryBLL();
        StudentBLL studentBLL = new StudentBLL();
        public int sessionId;
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (!IsPostBack)
            //{
            //    if (!Request.IsAuthenticated)
            //    {
            //        FormsAuthentication.RedirectToLoginPage();
            //    }
            //    else
            //    {
            //        if (Session["sessionId"] == null)
            //        {
            //            Response.Redirect("../index.aspx");
            //        }
            //        else
            //        {
            //            sessionId = Convert.ToInt32(Session["sessionId"]);
            //            int studentId = 0;
            //            StudentCL studentCL = new StudentCL();
            //            studentId = Convert.ToInt32(Request.QueryString["studentId"]);
            //            if (studentId != 0)
            //            {
            //                studentId = Convert.ToInt32(Request.QueryString["studentId"]);
            //                studentCL = studentBLL.viewStudentById(studentId, sessionId);
            //            }
            //            else
            //            {
            //                studentId = Convert.ToInt32(Request.QueryString["admNo"]);
            //                studentCL = studentBLL.viewStudentByAdmissionNo(studentId, sessionId);
            //                studentId = studentCL.id;
            //            }
            //            imgLogo.ImageUrl = "logo.jpg";
            //            lblStudentName.Text = studentCL.studentName;
            //            lblFatherName.Text = studentCL.fatherName;
            //            lblMotherName.Text = studentCL.motherName;
            //            lblAdmissionNo.Text = studentCL.admissionNo.ToString();
            //            lblClassSec.Text = studentCL.classSection;
            //            int term1ExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 1");
            //            int term2ExamId = reportBLL.viewExamIdByClass(studentCL.classId, "ANNUAL(80)");
            //            int ptId = reportBLL.viewExamIdByClass(studentCL.classId, "PT(10)");
            //            int pt2Id = reportBLL.viewExamIdByClass(studentCL.classId, "PT - TERM2(10)");
            //            int nsId = reportBLL.viewExamIdByClass(studentCL.classId, "NS(5)");
            //            int ns2Id = reportBLL.viewExamIdByClass(studentCL.classId, "NS - TERM2(5)");
            //            int seaId = reportBLL.viewExamIdByClass(studentCL.classId, "SEA(5)");
            //            int sea2Id = reportBLL.viewExamIdByClass(studentCL.classId, "SEA - TERM2(5)");
            //            int term2GenExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 2 - GENERAL");
            //            MiscEntryCL remarksAttendance = reportBLL.viewMiscByStudentId(studentId, term2GenExamId);
            //            //int examinationId = Convert.ToInt32(Request.QueryString["examId"]);
            //            //Collection<SubjectCL> subjectCol = subjectBLL.viewSubjectByClassId(studentCL.classId);
            //            lblAttendance.Text = remarksAttendance.attendance;
            //            lblRemarks.Text = remarksAttendance.remarks;
            //            Collection<MarksEntryCL> marksTerm1Col = reportBLL.viewMarksByStudentId(studentId, term1ExamId);
            //            Collection<MarksEntryCL> marksTerm2Col = reportBLL.viewMarksByStudentId(studentId, term2ExamId);
            //            Collection<MarksEntryCL> marksPTCol = reportBLL.viewMarksByStudentId(studentId, ptId);
            //            Collection<MarksEntryCL> marksPT2Col = reportBLL.viewMarksByStudentId(studentId, pt2Id);
            //            Collection<MarksEntryCL> markNSsCol = reportBLL.viewMarksByStudentId(studentId, nsId);
            //            Collection<MarksEntryCL> markNS2Col = reportBLL.viewMarksByStudentId(studentId, ns2Id);
            //            Collection<MarksEntryCL> marksSEACol = reportBLL.viewMarksByStudentId(studentId, seaId);
            //            Collection<MarksEntryCL> marksSEA2Col = reportBLL.viewMarksByStudentId(studentId, sea2Id);
            //            Collection<GradeEntryCL> gradeCol = reportBLL.viewGradesByStudentId(studentId, term1ExamId);
            //            Collection<GradeEntryCL> grade2Col = reportBLL.viewGradesByStudentId(studentId, term2ExamId);
            //            lblEnglishPT.Text = marksPTCol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
            //            lblEnglishNS.Text = markNSsCol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
            //            lblEnglishSEA.Text = marksSEACol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
            //            lblEnglishTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
            //            lblEnglishTotal.Text = (Convert.ToDouble(lblEnglishPT.Text) + Convert.ToDouble(lblEnglishNS.Text) + Convert.ToDouble(lblEnglishSEA.Text) + Convert.ToDouble(lblEnglishTerm1.Text)).ToString();
            //            lblEnglishGrade.Text = ConvertToGrade(Convert.ToDouble(lblEnglishTotal.Text));
            //            lblEnglishPT2.Text = marksPT2Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
            //            lblEnglishNS2.Text = markNS2Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
            //            lblEnglishSEA2.Text = marksSEA2Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
            //            lblEnglishTerm2.Text = marksTerm2Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
            //            lblEnglishTotal2.Text = (Convert.ToDouble(lblEnglishPT2.Text) + Convert.ToDouble(lblEnglishNS2.Text) + Convert.ToDouble(lblEnglishSEA2.Text) + Convert.ToDouble(lblEnglishTerm2.Text)).ToString();
            //            lblEnglishGrade2.Text = ConvertToGrade(Convert.ToDouble(lblEnglishTotal2.Text));
            //            lblHindiPT.Text = marksPTCol.Where(x => x.subjectId == 13).FirstOrDefault().marks;
            //            lblHindiNS.Text = markNSsCol.Where(x => x.subjectId == 13).FirstOrDefault().marks;
            //            lblHindiSEA.Text = marksSEACol.Where(x => x.subjectId == 13).FirstOrDefault().marks;
            //            lblHindiTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 13).FirstOrDefault().marks;
            //            lblHindiTotal.Text = (Convert.ToDouble(lblHindiPT.Text) + Convert.ToDouble(lblHindiNS.Text) + Convert.ToDouble(lblHindiSEA.Text) + Convert.ToDouble(lblHindiTerm1.Text)).ToString();
            //            lblHindiGrade.Text = ConvertToGrade(Convert.ToDouble(lblHindiTotal.Text));
            //            lblHindiPT2.Text = marksPT2Col.Where(x => x.subjectId == 13).FirstOrDefault().marks;
            //            lblHindiNS2.Text = markNS2Col.Where(x => x.subjectId == 13).FirstOrDefault().marks;
            //            lblHindiSEA2.Text = marksSEA2Col.Where(x => x.subjectId == 13).FirstOrDefault().marks;
            //            lblHindiTerm2.Text = marksTerm2Col.Where(x => x.subjectId == 13).FirstOrDefault().marks;
            //            lblHindiTotal2.Text = (Convert.ToDouble(lblHindiPT2.Text) + Convert.ToDouble(lblHindiNS2.Text) + Convert.ToDouble(lblHindiSEA2.Text) + Convert.ToDouble(lblHindiTerm2.Text)).ToString();
            //            lblHindiGrade2.Text = ConvertToGrade(Convert.ToDouble(lblHindiTotal2.Text));
            //            lblSanskritPT.Text = marksPTCol.Where(x => x.subjectId == 46).FirstOrDefault().marks;
            //            lblSanskritNS.Text = markNSsCol.Where(x => x.subjectId == 46).FirstOrDefault().marks;
            //            lblSanskritSEA.Text = marksSEACol.Where(x => x.subjectId == 46).FirstOrDefault().marks;
            //            lblSanskritTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 46).FirstOrDefault().marks;
            //            lblSanskritTotal.Text = (Convert.ToDouble(lblSanskritPT.Text) + Convert.ToDouble(lblSanskritNS.Text) + Convert.ToDouble(lblSanskritSEA.Text) + Convert.ToDouble(lblSanskritTerm1.Text)).ToString();
            //            lblSanskritGrade.Text = ConvertToGrade(Convert.ToDouble(lblSanskritTotal.Text));
            //            lblSanskritPT2.Text = marksPT2Col.Where(x => x.subjectId == 46).FirstOrDefault().marks;
            //            lblSanskritNS2.Text = markNS2Col.Where(x => x.subjectId == 46).FirstOrDefault().marks;
            //            lblSanskritSEA2.Text = marksSEA2Col.Where(x => x.subjectId == 46).FirstOrDefault().marks;
            //            lblSanskritTerm2.Text = marksTerm2Col.Where(x => x.subjectId == 46).FirstOrDefault().marks;
            //            lblSanskritTotal2.Text = (Convert.ToDouble(lblSanskritPT2.Text) + Convert.ToDouble(lblSanskritNS2.Text) + Convert.ToDouble(lblSanskritSEA2.Text) + Convert.ToDouble(lblSanskritTerm2.Text)).ToString();
            //            lblSanskritGrade2.Text = ConvertToGrade(Convert.ToDouble(lblSanskritTotal2.Text));
            //            lblMathematicsPT.Text = marksPTCol.Where(x => x.subjectId == 1).FirstOrDefault().marks;
            //            lblMathematicsNS.Text = markNSsCol.Where(x => x.subjectId == 1).FirstOrDefault().marks;
            //            lblMathematicsSEA.Text = marksSEACol.Where(x => x.subjectId == 1).FirstOrDefault().marks;
            //            lblMathematicsTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 1).FirstOrDefault().marks;
            //            lblMathematicsTotal.Text = (Convert.ToDouble(lblMathematicsPT.Text) + Convert.ToDouble(lblMathematicsNS.Text) + Convert.ToDouble(lblMathematicsSEA.Text) + Convert.ToDouble(lblMathematicsTerm1.Text)).ToString();
            //            lblMathematicsGrade.Text = ConvertToGrade(Convert.ToDouble(lblMathematicsTotal.Text));
            //            lblMathematicsPT2.Text = marksPT2Col.Where(x => x.subjectId == 1).FirstOrDefault().marks;
            //            lblMathematicsNS2.Text = markNS2Col.Where(x => x.subjectId == 1).FirstOrDefault().marks;
            //            lblMathematicsSEA2.Text = marksSEA2Col.Where(x => x.subjectId == 1).FirstOrDefault().marks;
            //            lblMathematicsTerm2.Text = marksTerm2Col.Where(x => x.subjectId == 1).FirstOrDefault().marks;
            //            lblMathematicsTotal2.Text = (Convert.ToDouble(lblMathematicsPT2.Text) + Convert.ToDouble(lblMathematicsNS2.Text) + Convert.ToDouble(lblMathematicsSEA2.Text) + Convert.ToDouble(lblMathematicsTerm2.Text)).ToString();
            //            lblMathematicsGrade2.Text = ConvertToGrade(Convert.ToDouble(lblMathematicsTotal2.Text));
            //            lblSciencePT.Text = marksPTCol.Where(x => x.subjectId == 29).FirstOrDefault().marks;
            //            lblScienceNS.Text = markNSsCol.Where(x => x.subjectId == 29).FirstOrDefault().marks;
            //            lblScienceSEA.Text = marksSEACol.Where(x => x.subjectId == 29).FirstOrDefault().marks;
            //            lblScienceTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 29).FirstOrDefault().marks;
            //            lblScienceTotal.Text = (Convert.ToDouble(lblSciencePT.Text) + Convert.ToDouble(lblScienceNS.Text) + Convert.ToDouble(lblScienceSEA.Text) + Convert.ToDouble(lblScienceTerm1.Text)).ToString();
            //            lblScienceGrade.Text = ConvertToGrade(Convert.ToDouble(lblScienceTotal.Text));
            //            lblSciencePT2.Text = marksPT2Col.Where(x => x.subjectId == 29).FirstOrDefault().marks;
            //            lblScienceNS2.Text = markNS2Col.Where(x => x.subjectId == 29).FirstOrDefault().marks;
            //            lblScienceSEA2.Text = marksSEA2Col.Where(x => x.subjectId == 29).FirstOrDefault().marks;
            //            lblScienceTerm2.Text = marksTerm2Col.Where(x => x.subjectId == 29).FirstOrDefault().marks;
            //            lblScienceTotal2.Text = (Convert.ToDouble(lblSciencePT2.Text) + Convert.ToDouble(lblScienceNS2.Text) + Convert.ToDouble(lblScienceSEA2.Text) + Convert.ToDouble(lblScienceTerm2.Text)).ToString();
            //            lblScienceGrade2.Text = ConvertToGrade(Convert.ToDouble(lblScienceTotal2.Text));
            //            lblSocialSciencePT.Text = marksPTCol.Where(x => x.subjectId == 35).FirstOrDefault().marks;
            //            lblSocialScienceNS.Text = markNSsCol.Where(x => x.subjectId == 35).FirstOrDefault().marks;
            //            lblSocialScienceSEA.Text = marksSEACol.Where(x => x.subjectId == 35).FirstOrDefault().marks;
            //            lblSocialScienceTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 35).FirstOrDefault().marks;
            //            lblSocialScienceTotal.Text = (Convert.ToDouble(lblSocialSciencePT.Text) + Convert.ToDouble(lblSocialScienceNS.Text) + Convert.ToDouble(lblSocialScienceSEA.Text) + Convert.ToDouble(lblSocialScienceTerm1.Text)).ToString();
            //            lblSocialScienceGrade.Text = ConvertToGrade(Convert.ToDouble(lblSocialScienceTotal.Text));
            //            lblSocialSciencePT2.Text = marksPT2Col.Where(x => x.subjectId == 35).FirstOrDefault().marks;
            //            lblSocialScienceNS2.Text = markNS2Col.Where(x => x.subjectId == 35).FirstOrDefault().marks;
            //            lblSocialScienceSEA2.Text = marksSEA2Col.Where(x => x.subjectId == 35).FirstOrDefault().marks;
            //            lblSocialScienceTerm2.Text = marksTerm2Col.Where(x => x.subjectId == 35).FirstOrDefault().marks;
            //            lblSocialScienceTotal2.Text = (Convert.ToDouble(lblSocialSciencePT2.Text) + Convert.ToDouble(lblSocialScienceNS2.Text) + Convert.ToDouble(lblSocialScienceSEA2.Text) + Convert.ToDouble(lblSocialScienceTerm2.Text)).ToString();
            //            lblSocialScienceGrade2.Text = ConvertToGrade(Convert.ToDouble(lblSocialScienceTotal2.Text));
            //            lblGKPT.Text = marksPTCol.Where(x => x.subjectId == 48).FirstOrDefault().marks;
            //            lblGKNS.Text = markNSsCol.Where(x => x.subjectId == 48).FirstOrDefault().marks;
            //            lblGKSEA.Text = marksSEACol.Where(x => x.subjectId == 48).FirstOrDefault().marks;
            //            lblGKTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 48).FirstOrDefault().marks;
            //            lblGKTotal.Text = (Convert.ToDouble(lblGKPT.Text) + Convert.ToDouble(lblGKNS.Text) + Convert.ToDouble(lblGKSEA.Text) + Convert.ToDouble(lblGKTerm1.Text)).ToString();
            //            lblGKGrade.Text = ConvertToGrade(Convert.ToDouble(lblGKTotal.Text));
            //            lblGKPT2.Text = marksPT2Col.Where(x => x.subjectId == 48).FirstOrDefault().marks;
            //            lblGKNS2.Text = markNS2Col.Where(x => x.subjectId == 48).FirstOrDefault().marks;
            //            lblGKSEA2.Text = marksSEA2Col.Where(x => x.subjectId == 48).FirstOrDefault().marks;
            //            lblGKTerm2.Text = marksTerm2Col.Where(x => x.subjectId == 48).FirstOrDefault().marks;
            //            lblGKTotal2.Text = (Convert.ToDouble(lblGKPT2.Text) + Convert.ToDouble(lblGKNS2.Text) + Convert.ToDouble(lblGKSEA2.Text) + Convert.ToDouble(lblGKTerm2.Text)).ToString();
            //            lblGKGrade2.Text = ConvertToGrade(Convert.ToDouble(lblGKTotal2.Text));
            //            lblArtEdu.Text = gradeCol.Where(x => x.subjectId == 52).FirstOrDefault().grade;
            //            lblWorkEdu.Text = gradeCol.Where(x => x.subjectId == 51).FirstOrDefault().grade;
            //            lblPhysicalEdu.Text = gradeCol.Where(x => x.subjectId == 53).FirstOrDefault().grade;
            //            lblDiscipline.Text = gradeCol.Where(x => x.subjectId == 54).FirstOrDefault().grade;
            //            lblArtEdu2.Text = grade2Col.Where(x => x.subjectId == 52).FirstOrDefault().grade;
            //            lblWorkEdu2.Text = grade2Col.Where(x => x.subjectId == 51).FirstOrDefault().grade;
            //            lblPhysicalEdu2.Text = grade2Col.Where(x => x.subjectId == 53).FirstOrDefault().grade;
            //            lblDiscipline2.Text = grade2Col.Where(x => x.subjectId == 54).FirstOrDefault().grade;
            //        }
            //    }
            //}
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