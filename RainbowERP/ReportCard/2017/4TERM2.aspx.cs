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
    public partial class _4TERM2 : System.Web.UI.Page
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
            //            int term2GeneralExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 2 - GENERAL");
            //            int term2ExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 2");
            //            int term2SpeceficExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 2 - SPECIFIC");
            //            MiscEntryCL remarksAttendanceGeneral = reportBLL.viewMiscByStudentId(studentId, term2GeneralExamId);
            //            MiscEntryCL remarksSpecefic = reportBLL.viewMiscByStudentId(studentId, term2SpeceficExamId);
            //            //int examinationId = Convert.ToInt32(Request.QueryString["examId"]);
            //            //Collection<SubjectCL> subjectCol = subjectBLL.viewSubjectByClassId(studentCL.classId);
            //            Collection<GradeEntryCL> gradeCol = reportBLL.viewGradesByStudentIdPrimary(studentId, term1ExamId);
            //            Collection<GradeEntryCL> grade2Col = reportBLL.viewGradesByStudentIdPrimary(studentId, term2ExamId);
            //            lblAttendance.Text = remarksAttendanceGeneral.attendance;
            //            lblGeneralRemarks.Text = remarksAttendanceGeneral.remarks;
            //            lblSpecificRemarks.Text = remarksSpecefic.remarks;
            //            lblEnglishReadingTerm1.Text = gradeCol.Where(x => x.subjectId == 72).FirstOrDefault().grade;
            //            lblEnglishReadingTerm2.Text = grade2Col.Where(x => x.subjectId == 72).FirstOrDefault().grade;
            //            lblEnglishWritingTerm1.Text = gradeCol.Where(x => x.subjectId == 75).FirstOrDefault().grade;
            //            lblEnglishWritingTerm2.Text = grade2Col.Where(x => x.subjectId == 75).FirstOrDefault().grade;
            //            lblEnglishSpeakingTerm1.Text = gradeCol.Where(x => x.subjectId == 76).FirstOrDefault().grade;
            //            lblEnglishSpeakingTerm2.Text = grade2Col.Where(x => x.subjectId == 76).FirstOrDefault().grade;
            //            lblEnglishListeningTerm1.Text = gradeCol.Where(x => x.subjectId == 77).FirstOrDefault().grade;
            //            lblEnglishListeningTerm2.Text = grade2Col.Where(x => x.subjectId == 77).FirstOrDefault().grade;
            //            lblEnglishExtraReadingTerm1.Text = CheckValue(gradeCol.Where(x => x.subjectId == 78));
            //            lblEnglishExtraReadingTerm2.Text = CheckValue(grade2Col.Where(x => x.subjectId == 78));
            //            lblEnglishActivityTerm1.Text = CheckValue(gradeCol.Where(x => x.subjectId == 79));
            //            lblEnglishActivityTerm2.Text = CheckValue(grade2Col.Where(x => x.subjectId == 79));
            //            lblHindiReadingTerm1.Text = gradeCol.Where(x => x.subjectId == 95).FirstOrDefault().grade;
            //            lblHindiReadingTerm2.Text = grade2Col.Where(x => x.subjectId == 95).FirstOrDefault().grade;
            //            lblHindiWritingTerm1.Text = gradeCol.Where(x => x.subjectId == 96).FirstOrDefault().grade;
            //            lblHindiWritingTerm2.Text = grade2Col.Where(x => x.subjectId == 96).FirstOrDefault().grade;
            //            lblHindiSpeakingTerm1.Text = gradeCol.Where(x => x.subjectId == 97).FirstOrDefault().grade;
            //            lblHindiSpeakingTerm2.Text = grade2Col.Where(x => x.subjectId == 97).FirstOrDefault().grade;
            //            lblHindiListeningTerm1.Text = gradeCol.Where(x => x.subjectId == 98).FirstOrDefault().grade;
            //            lblHindiListeningTerm2.Text = grade2Col.Where(x => x.subjectId == 98).FirstOrDefault().grade;
            //            lblHindiExtraReadingTerm1.Text = CheckValue(gradeCol.Where(x => x.subjectId == 99));
            //            lblHindiExtraReadingTerm2.Text = CheckValue(grade2Col.Where(x => x.subjectId == 99));
            //            lblMathematicsConceptTerm1.Text = gradeCol.Where(x => x.subjectId == 73).FirstOrDefault().grade;
            //            lblMathematicsConceptTerm2.Text = grade2Col.Where(x => x.subjectId == 73).FirstOrDefault().grade;
            //            lblMathematicsActivityTerm1.Text = gradeCol.Where(x => x.subjectId == 74).FirstOrDefault().grade;
            //            lblMathematicsActivityTerm2.Text = grade2Col.Where(x => x.subjectId == 74).FirstOrDefault().grade;
            //            lblMathematicsTablesTerm1.Text = gradeCol.Where(x => x.subjectId == 80).FirstOrDefault().grade;
            //            lblMathematicsTablesTerm2.Text = grade2Col.Where(x => x.subjectId == 80).FirstOrDefault().grade;
            //            lblMathematicsMentalAbilityTerm1.Text = gradeCol.Where(x => x.subjectId == 81).FirstOrDefault().grade;
            //            lblMathematicsMentalAbilityTerm2.Text = grade2Col.Where(x => x.subjectId == 81).FirstOrDefault().grade;
            //            lblMathematicsWrittenWorkTerm1.Text = CheckValue(gradeCol.Where(x => x.subjectId == 82));
            //            lblMathematicsWrittenWorkTerm2.Text = CheckValue(grade2Col.Where(x => x.subjectId == 82));
            //            lblSocialConceptTerm1.Text = gradeCol.Where(x => x.subjectId == 91).FirstOrDefault().grade;
            //            lblSocialConceptTerm2.Text = grade2Col.Where(x => x.subjectId == 91).FirstOrDefault().grade;
            //            lblSocialActivityTerm1.Text = gradeCol.Where(x => x.subjectId == 92).FirstOrDefault().grade;
            //            lblSocialActivityTerm2.Text = grade2Col.Where(x => x.subjectId == 92).FirstOrDefault().grade;
            //            lblSocialGDTerm1.Text = gradeCol.Where(x => x.subjectId == 93).FirstOrDefault().grade;
            //            lblSocialGDTerm2.Text = grade2Col.Where(x => x.subjectId == 93).FirstOrDefault().grade;
            //            lblSocialWrittenWorkTerm1.Text = gradeCol.Where(x => x.subjectId == 94).FirstOrDefault().grade;
            //            lblSocialWrittenWorkTerm2.Text = grade2Col.Where(x => x.subjectId == 94).FirstOrDefault().grade;
            //            lblScienceConceptTerm1.Text = CheckValue(gradeCol.Where(x => x.subjectId == 87));
            //            lblScienceConceptTerm2.Text = CheckValue(grade2Col.Where(x => x.subjectId == 87));
            //            lblScienceActivityTerm1.Text = CheckValue(gradeCol.Where(x => x.subjectId == 88));
            //            lblScienceActivityTerm2.Text = CheckValue(grade2Col.Where(x => x.subjectId == 88));
            //            lblScienceScientificTerm1.Text = CheckValue(gradeCol.Where(x => x.subjectId == 89));
            //            lblScienceScientificTerm2.Text = CheckValue(grade2Col.Where(x => x.subjectId == 89));
            //            lblScienceGDTerm1.Text = CheckValue(grade2Col.Where(x => x.subjectId == 90));
            //            lblScienceGDTerm2.Text = CheckValue(grade2Col.Where(x => x.subjectId == 90));
            //            lblComputerTerm1.Text = gradeCol.Where(x => x.subjectId == 100).FirstOrDefault().grade;
            //            lblComputerTerm2.Text = grade2Col.Where(x => x.subjectId == 100).FirstOrDefault().grade;
            //            lblGamesTerm1.Text = gradeCol.Where(x => x.subjectId == 101).FirstOrDefault().grade;
            //            lblGamesTerm2.Text = grade2Col.Where(x => x.subjectId == 101).FirstOrDefault().grade;
            //            lblArtTerm1.Text = gradeCol.Where(x => x.subjectId == 102).FirstOrDefault().grade;
            //            lblArtTerm2.Text = grade2Col.Where(x => x.subjectId == 102).FirstOrDefault().grade;
            //            lblMusicTerm1.Text = gradeCol.Where(x => x.subjectId == 103).FirstOrDefault().grade;
            //            lblMusicTerm2.Text = grade2Col.Where(x => x.subjectId == 103).FirstOrDefault().grade;
            //            lblGKTerm1.Text = gradeCol.Where(x => x.subjectId == 104).FirstOrDefault().grade;
            //            lblGKTerm2.Text = grade2Col.Where(x => x.subjectId == 104).FirstOrDefault().grade;
            //            lblCourteousnessTerm1.Text = gradeCol.Where(x => x.subjectId == 105).FirstOrDefault().grade;
            //            lblCourteousnessTerm2.Text = grade2Col.Where(x => x.subjectId == 105).FirstOrDefault().grade;
            //            lblConfidenceTerm1.Text = gradeCol.Where(x => x.subjectId == 106).FirstOrDefault().grade;
            //            lblConfidenceTerm2.Text = grade2Col.Where(x => x.subjectId == 106).FirstOrDefault().grade;
            //            lblCOBTerm1.Text = gradeCol.Where(x => x.subjectId == 107).FirstOrDefault().grade;
            //            lblCOBTerm2.Text = grade2Col.Where(x => x.subjectId == 107).FirstOrDefault().grade;
            //            lblNeatnessTerm1.Text = gradeCol.Where(x => x.subjectId == 108).FirstOrDefault().grade;
            //            lblNeatnessTerm2.Text = grade2Col.Where(x => x.subjectId == 108).FirstOrDefault().grade;
            //            lblRegularityTerm1.Text = gradeCol.Where(x => x.subjectId == 109).FirstOrDefault().grade;
            //            lblRegularityTerm2.Text = grade2Col.Where(x => x.subjectId == 109).FirstOrDefault().grade;
            //            lblInitiativeTerm1.Text = gradeCol.Where(x => x.subjectId == 110).FirstOrDefault().grade;
            //            lblInitiativeTerm2.Text = grade2Col.Where(x => x.subjectId == 110).FirstOrDefault().grade;
            //            lblSharingTerm1.Text = gradeCol.Where(x => x.subjectId == 111).FirstOrDefault().grade;
            //            lblSharingTerm2.Text = grade2Col.Where(x => x.subjectId == 111).FirstOrDefault().grade;
            //            lblRespectTerm1.Text = gradeCol.Where(x => x.subjectId == 112).FirstOrDefault().grade;
            //            lblRespectTerm2.Text = grade2Col.Where(x => x.subjectId == 112).FirstOrDefault().grade;
            //            lblSelfControlTerm1.Text = gradeCol.Where(x => x.subjectId == 113).FirstOrDefault().grade;
            //            lblSelfControlTerm2.Text = grade2Col.Where(x => x.subjectId == 113).FirstOrDefault().grade;
            //            lblSOSTerm1.Text = gradeCol.Where(x => x.subjectId == 114).FirstOrDefault().grade;
            //            lblSOSTerm2.Text = grade2Col.Where(x => x.subjectId == 114).FirstOrDefault().grade;
            //        }
            //    }
            //}
        }
        private string CheckValue(IEnumerable<GradeEntryCL> input)
        {
            if (input.FirstOrDefault() == null)
            {
                return string.Empty;
            }
            else
            {
                return input.FirstOrDefault().grade;
            }
        }
    }
}