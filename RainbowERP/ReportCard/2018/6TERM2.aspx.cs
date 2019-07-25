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

namespace RAINBOW_ERP.ReportCard._2019
{
    public partial class _6TERM2 : System.Web.UI.Page
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
                        lblFatherName.Text = studentCL.fatherName;
                        lblMotherName.Text = studentCL.motherName;
                        int term1ExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 1");
                        int term2ExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 2");
                        int ptId = reportBLL.viewExamIdByClass(studentCL.classId, "PT(10)");
                        int pt2Id = reportBLL.viewExamIdByClass(studentCL.classId, "PT2(10)");
                        int nsId = reportBLL.viewExamIdByClass(studentCL.classId, "NS(5)");
                        int ns2Id = reportBLL.viewExamIdByClass(studentCL.classId, "NS2(5)");
                        int seaId = reportBLL.viewExamIdByClass(studentCL.classId, "SEA(5)");
                        int sea2Id = reportBLL.viewExamIdByClass(studentCL.classId, "SEA2(5)");
                        int term2GenExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 2 - GENERAL");
                        MiscEntryCL remarksAttendance = reportBLL.viewMiscByStudentId(studentId, term2GenExamId);
                        //int examinationId = Convert.ToInt32(Request.QueryString["examId"]);
                        //Collection<SubjectCL> subjectCol = subjectBLL.viewSubjectByClassId(studentCL.classId);
                        Collection<MarksEntryCL> marksTerm1Col = reportBLL.viewMarksByStudentId(studentId, term1ExamId);
                        Collection<MarksEntryCL> marksPTCol = reportBLL.viewMarksByStudentId(studentId, ptId);
                        Collection<MarksEntryCL> markNSsCol = reportBLL.viewMarksByStudentId(studentId, nsId);
                        Collection<MarksEntryCL> marksSEACol = reportBLL.viewMarksByStudentId(studentId, seaId);
                        Collection<GradeEntryCL> gradeCol = reportBLL.viewGradesByStudentId(studentId, term1ExamId);
                        Collection<MarksEntryCL> marksTerm2Col = reportBLL.viewMarksByStudentId(studentId, term2ExamId);
                        Collection<MarksEntryCL> marksPT2Col = reportBLL.viewMarksByStudentId(studentId, pt2Id);
                        Collection<MarksEntryCL> marksNS2Col = reportBLL.viewMarksByStudentId(studentId, ns2Id);
                        Collection<MarksEntryCL> marksSEA2Col = reportBLL.viewMarksByStudentId(studentId, sea2Id);
                        Collection<GradeEntryCL> grade2Col = reportBLL.viewGradesByStudentId(studentId, term2ExamId);
                        lblEnglishPT.Text = marksPTCol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblEnglishPT2.Text = marksPT2Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblEnglishNS.Text = markNSsCol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblEnglishNS2.Text = marksNS2Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblEnglishSEA.Text = marksSEACol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblEnglishSEA2.Text = marksSEA2Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblEnglishTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblEnglishTerm2.Text = marksTerm2Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        lblEnglishTotalTerm1.Text = (Convert.ToDouble(lblEnglishPT.Text) + Convert.ToDouble(lblEnglishNS.Text) + Convert.ToDouble(lblEnglishSEA.Text) + Convert.ToDouble(lblEnglishTerm1.Text)).ToString();
                        lblEnglishTotalTerm2.Text = (Convert.ToDouble(lblEnglishPT2.Text) + Convert.ToDouble(lblEnglishNS2.Text) + Convert.ToDouble(lblEnglishSEA2.Text) + Convert.ToDouble(lblEnglishTerm2.Text)).ToString();
                        lblEnglishTotal.Text = Math.Ceiling((Convert.ToDouble(lblEnglishTotalTerm1.Text) / 2) + (Convert.ToDouble(lblEnglishTotalTerm2.Text) / 2)).ToString();
                        lblEnglishGrade.Text = ConvertToGrade(Convert.ToDouble(lblEnglishTotal.Text));
                        lblHindiPT.Text = Convert.ToDouble(marksPTCol.Where(x => x.subjectId == 13).FirstOrDefault().marks).ToString();
                        lblHindiPT2.Text = marksPT2Col.Where(x => x.subjectId == 13).FirstOrDefault().marks;
                        lblHindiNS.Text = markNSsCol.Where(x => x.subjectId == 13).FirstOrDefault().marks;
                        lblHindiNS2.Text = marksNS2Col.Where(x => x.subjectId == 13).FirstOrDefault().marks;
                        lblHindiSEA.Text = marksSEACol.Where(x => x.subjectId == 13).FirstOrDefault().marks;
                        lblHindiSEA2.Text = marksSEA2Col.Where(x => x.subjectId == 13).FirstOrDefault().marks;
                        lblHindiTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 13).FirstOrDefault().marks;
                        lblHindiTerm2.Text = marksTerm2Col.Where(x => x.subjectId == 13).FirstOrDefault().marks;
                        lblHindiTotalTerm1.Text = (Convert.ToDouble(lblHindiPT.Text) + Convert.ToDouble(lblHindiNS.Text) + Convert.ToDouble(lblHindiSEA.Text) + Convert.ToDouble(lblHindiTerm1.Text)).ToString();
                        lblHindiTotalTerm2.Text = (Convert.ToDouble(lblHindiPT2.Text) + Convert.ToDouble(lblHindiNS2.Text) + Convert.ToDouble(lblHindiSEA2.Text) + Convert.ToDouble(lblHindiTerm2.Text)).ToString();
                        lblHindiTotal.Text = Math.Ceiling((Convert.ToDouble(lblHindiTotalTerm1.Text) / 2) + (Convert.ToDouble(lblHindiTotalTerm2.Text) / 2)).ToString();
                        lblHindiGrade.Text = ConvertToGrade(Convert.ToDouble(lblHindiTotal.Text));
                        lblSanskritPT.Text = Convert.ToDouble(marksPTCol.Where(x => x.subjectId == 46).FirstOrDefault().marks).ToString();
                        lblSanskritPT2.Text = marksPT2Col.Where(x => x.subjectId == 46).FirstOrDefault().marks;
                        lblSanskritNS.Text = markNSsCol.Where(x => x.subjectId == 46).FirstOrDefault().marks;
                        lblSanskritNS2.Text = marksNS2Col.Where(x => x.subjectId == 46).FirstOrDefault().marks;
                        lblSanskritSEA.Text = marksSEACol.Where(x => x.subjectId == 46).FirstOrDefault().marks;
                        lblSanskritSEA2.Text = marksSEA2Col.Where(x => x.subjectId == 46).FirstOrDefault().marks;
                        lblSanskritTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 46).FirstOrDefault().marks;
                        lblSanskritTerm2.Text = marksTerm2Col.Where(x => x.subjectId == 46).FirstOrDefault().marks;
                        lblSanskritTotalTerm1.Text = (Convert.ToDouble(lblSanskritPT.Text) + Convert.ToDouble(lblSanskritNS.Text) + Convert.ToDouble(lblSanskritSEA.Text) + Convert.ToDouble(lblSanskritTerm1.Text)).ToString();
                        lblSanskritTotalTerm2.Text = (Convert.ToDouble(lblSanskritPT2.Text) + Convert.ToDouble(lblSanskritNS2.Text) + Convert.ToDouble(lblSanskritSEA2.Text) + Convert.ToDouble(lblSanskritTerm2.Text)).ToString();
                        lblSanskritTotal.Text = Math.Ceiling((Convert.ToDouble(lblSanskritTotalTerm1.Text) / 2) + (Convert.ToDouble(lblSanskritTotalTerm2.Text) / 2)).ToString();
                        lblSanskritGrade.Text = ConvertToGrade(Convert.ToDouble(lblSanskritTotal.Text));
                        lblSciencePT.Text = marksPTCol.Where(x => x.subjectId == 29).FirstOrDefault().marks;
                        lblSciencePT2.Text = marksPT2Col.Where(x => x.subjectId == 29).FirstOrDefault().marks;
                        lblScienceNS.Text = markNSsCol.Where(x => x.subjectId == 29).FirstOrDefault().marks;
                        lblScienceNS2.Text = marksNS2Col.Where(x => x.subjectId == 29).FirstOrDefault().marks;
                        lblScienceSEA.Text = marksSEACol.Where(x => x.subjectId == 29).FirstOrDefault().marks;
                        lblScienceSEA2.Text = marksSEA2Col.Where(x => x.subjectId == 29).FirstOrDefault().marks;
                        lblScienceTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 29).FirstOrDefault().marks;
                        lblScienceTerm2.Text = marksTerm2Col.Where(x => x.subjectId == 29).FirstOrDefault().marks;
                        lblScienceTotalTerm1.Text = (Convert.ToDouble(lblSciencePT.Text) + Convert.ToDouble(lblScienceNS.Text) + Convert.ToDouble(lblScienceSEA.Text) + Convert.ToDouble(lblScienceTerm1.Text)).ToString();
                        lblScienceTotalTerm2.Text = (Convert.ToDouble(lblSciencePT2.Text) + Convert.ToDouble(lblScienceNS2.Text) + Convert.ToDouble(lblScienceSEA2.Text) + Convert.ToDouble(lblScienceTerm2.Text)).ToString();
                        lblScienceTotal.Text = Math.Ceiling((Convert.ToDouble(lblScienceTotalTerm1.Text) / 2) + (Convert.ToDouble(lblScienceTotalTerm2.Text) / 2)).ToString();
                        lblScienceGrade.Text = ConvertToGrade(Convert.ToDouble(lblScienceTotal.Text));
                        lblSocialSciencePT.Text = marksPTCol.Where(x => x.subjectId == 35).FirstOrDefault().marks;
                        lblSocialSciencePT2.Text = marksPT2Col.Where(x => x.subjectId == 35).FirstOrDefault().marks;
                        lblSocialScienceNS.Text = markNSsCol.Where(x => x.subjectId == 35).FirstOrDefault().marks;
                        lblSocialScienceNS2.Text = marksNS2Col.Where(x => x.subjectId == 35).FirstOrDefault().marks;
                        lblSocialScienceSEA.Text = marksSEACol.Where(x => x.subjectId == 35).FirstOrDefault().marks;
                        lblSocialScienceSEA2.Text = marksSEA2Col.Where(x => x.subjectId == 35).FirstOrDefault().marks;
                        lblSocialScienceTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 35).FirstOrDefault().marks;
                        lblSocialScienceTerm2.Text = marksTerm2Col.Where(x => x.subjectId == 35).FirstOrDefault().marks;
                        lblSocialScienceTotalTerm1.Text = (Convert.ToDouble(lblSocialSciencePT.Text) + Convert.ToDouble(lblSocialScienceNS.Text) + Convert.ToDouble(lblSocialScienceSEA.Text) + Convert.ToDouble(lblSocialScienceTerm1.Text)).ToString();
                        lblSocialScienceTotalTerm2.Text = (Convert.ToDouble(lblSocialSciencePT2.Text) + Convert.ToDouble(lblSocialScienceNS2.Text) + Convert.ToDouble(lblSocialScienceSEA2.Text) + Convert.ToDouble(lblSocialScienceTerm2.Text)).ToString();
                        lblSocialScienceTotal.Text = Math.Ceiling((Convert.ToDouble(lblSocialScienceTotalTerm1.Text) / 2) + (Convert.ToDouble(lblSocialScienceTotalTerm2.Text) / 2)).ToString();
                        lblSocialScienceGrade.Text = ConvertToGrade(Convert.ToDouble(lblSocialScienceTotal.Text));
                        lblMathematicsPT.Text = marksPTCol.Where(x => x.subjectId == 1).FirstOrDefault().marks;
                        lblMathematicsPT2.Text = marksPT2Col.Where(x => x.subjectId == 1).FirstOrDefault().marks;
                        lblMathematicsNS.Text = markNSsCol.Where(x => x.subjectId == 1).FirstOrDefault().marks;
                        lblMathematicsNS2.Text = marksNS2Col.Where(x => x.subjectId == 1).FirstOrDefault().marks;
                        lblMathematicsSEA.Text = marksSEACol.Where(x => x.subjectId == 1).FirstOrDefault().marks;
                        lblMathematicsSEA2.Text = marksSEA2Col.Where(x => x.subjectId == 1).FirstOrDefault().marks;
                        lblMathematicsTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 1).FirstOrDefault().marks;
                        lblMathematicsTerm2.Text = marksTerm2Col.Where(x => x.subjectId == 1).FirstOrDefault().marks;
                        lblMathematicsTotalTerm1.Text = (Convert.ToDouble(lblMathematicsPT.Text) + Convert.ToDouble(lblMathematicsNS.Text) + Convert.ToDouble(lblMathematicsSEA.Text) + Convert.ToDouble(lblMathematicsTerm1.Text)).ToString();
                        lblMathematicsTotalTerm2.Text = (Convert.ToDouble(lblMathematicsPT2.Text) + Convert.ToDouble(lblMathematicsNS2.Text) + Convert.ToDouble(lblMathematicsSEA2.Text) + Convert.ToDouble(lblMathematicsTerm2.Text)).ToString();
                        lblMathematicsTotal.Text = Math.Ceiling((Convert.ToDouble(lblMathematicsTotalTerm1.Text) / 2) + (Convert.ToDouble(lblMathematicsTotalTerm2.Text) / 2)).ToString();
                        lblMathematicsGrade.Text = ConvertToGrade(Convert.ToDouble(lblMathematicsTotal.Text));
                        lblGKPT.Text = marksPTCol.Where(x => x.subjectId == 48).FirstOrDefault().marks;
                        lblGKPT2.Text = marksPT2Col.Where(x => x.subjectId == 48).FirstOrDefault().marks;
                        lblGKNS.Text = markNSsCol.Where(x => x.subjectId == 48).FirstOrDefault().marks;
                        lblGKNS2.Text = marksNS2Col.Where(x => x.subjectId == 48).FirstOrDefault().marks;
                        lblGKSEA.Text = marksSEACol.Where(x => x.subjectId == 48).FirstOrDefault().marks;
                        lblGKSEA2.Text = marksSEA2Col.Where(x => x.subjectId == 48).FirstOrDefault().marks;
                        lblGKTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 48).FirstOrDefault().marks;
                        lblGKTerm2.Text = marksTerm2Col.Where(x => x.subjectId == 48).FirstOrDefault().marks;
                        lblGKTotalTerm1.Text = (Convert.ToDouble(lblGKPT.Text) + Convert.ToDouble(lblGKNS.Text) + Convert.ToDouble(lblGKSEA.Text) + Convert.ToDouble(lblGKTerm1.Text)).ToString();
                        lblGKTotalTerm2.Text = (Convert.ToDouble(lblGKPT2.Text) + Convert.ToDouble(lblGKNS2.Text) + Convert.ToDouble(lblGKSEA2.Text) + Convert.ToDouble(lblGKTerm2.Text)).ToString();
                        lblGKTotal.Text = Math.Ceiling((Convert.ToDouble(lblGKTotalTerm1.Text) / 2) + (Convert.ToDouble(lblGKTotalTerm2.Text) / 2)).ToString();
                        lblGKGrade.Text = ConvertToGrade(Convert.ToDouble(lblGKTotal.Text));
                        lblArtEduTerm1.Text = gradeCol.Where(x => x.subjectId == 52).FirstOrDefault().grade;
                        lblArtEduTerm2.Text = grade2Col.Where(x => x.subjectId == 52).FirstOrDefault().grade;
                        lblWorkEduTerm1.Text = gradeCol.Where(x => x.subjectId == 51).FirstOrDefault().grade;
                        lblWorkEduTerm2.Text = grade2Col.Where(x => x.subjectId == 51).FirstOrDefault().grade;
                        lblPhysicalEduTerm1.Text = gradeCol.Where(x => x.subjectId == 53).FirstOrDefault().grade;
                        lblPhysicalEduTerm2.Text = grade2Col.Where(x => x.subjectId == 53).FirstOrDefault().grade;
                        lblRegularityTerm1.Text = gradeCol.Where(x => x.subjectId == 67).FirstOrDefault().grade;
                        lblRegularityTerm2.Text = grade2Col.Where(x => x.subjectId == 67).FirstOrDefault().grade;
                        lblSincerityTerm1.Text = gradeCol.Where(x => x.subjectId == 119).FirstOrDefault().grade;
                        lblSincerityTerm2.Text = grade2Col.Where(x => x.subjectId == 119).FirstOrDefault().grade;
                        lblBehaviourTerm1.Text = gradeCol.Where(x => x.subjectId == 120).FirstOrDefault().grade;
                        lblBehaviourTerm2.Text = grade2Col.Where(x => x.subjectId == 120).FirstOrDefault().grade;
                        lblAttitudeTeachersTerm1.Text = gradeCol.Where(x => x.subjectId == 70).FirstOrDefault().grade;
                        lblAttitudeTeachersTerm2.Text = grade2Col.Where(x => x.subjectId == 70).FirstOrDefault().grade;
                        lblAttitudeStudentsTerm1.Text = gradeCol.Where(x => x.subjectId == 69).FirstOrDefault().grade;
                        lblAttitudeStudentsTerm2.Text = grade2Col.Where(x => x.subjectId == 69).FirstOrDefault().grade;
                        lblGrade.Text = ConvertToGrade((Convert.ToDouble(lblEnglishTotal.Text) + Convert.ToDouble(lblSanskritTotal.Text) + Convert.ToDouble(lblHindiTotal.Text) + Convert.ToDouble(lblScienceTotal.Text) + Convert.ToDouble(lblSocialScienceTotal.Text) + Convert.ToDouble(lblMathematicsTotal.Text) + Convert.ToDouble(lblGKTotal.Text)) / 7);
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