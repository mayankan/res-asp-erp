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

namespace RAINBOW_ERP.ReportCard._2018
{
    public partial class _3TERM1 : System.Web.UI.Page
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
            //            lblAdmissionNo.Text = studentCL.admissionNo.ToString();
            //            lblClassSec.Text = studentCL.classSection;
            //            int term1ExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 1");
            //            int ptId = reportBLL.viewExamIdByClass(studentCL.classId, "PT(30)");
            //            int nsId = reportBLL.viewExamIdByClass(studentCL.classId, "NS(5)");
            //            int seaId = reportBLL.viewExamIdByClass(studentCL.classId, "SEA(5)");
            //            //int examinationId = Convert.ToInt32(Request.QueryString["examId"]);
            //            //Collection<SubjectCL> subjectCol = subjectBLL.viewSubjectByClassId(studentCL.classId);
            //            Collection<MarksEntryCL> marksTerm1Col = reportBLL.viewMarksByStudentId(studentId, term1ExamId);
            //            Collection<MarksEntryCL> marksPTCol = reportBLL.viewMarksByStudentId(studentId, ptId);
            //            Collection<MarksEntryCL> markNSsCol = reportBLL.viewMarksByStudentId(studentId, nsId);
            //            Collection<MarksEntryCL> marksSEACol = reportBLL.viewMarksByStudentId(studentId, seaId);
            //            Collection<GradeEntryCL> gradeCol = reportBLL.viewGradesByStudentId(studentId, term1ExamId);
            //            MiscEntryCL remarksAttendance = reportBLL.viewMiscByStudentId(studentId, term1ExamId);
            //            lblEnglishPT.Text = marksPTCol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
            //            lblEnglishNS.Text = markNSsCol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
            //            lblEnglishSEA.Text = marksSEACol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
            //            lblEnglishTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
            //            lblEnglishTotal.Text = (Convert.ToDouble(lblEnglishPT.Text) + Convert.ToDouble(lblEnglishNS.Text) + Convert.ToDouble(lblEnglishSEA.Text) + Convert.ToDouble(lblEnglishTerm1.Text)).ToString();
            //            lblEnglishGrade.Text = ConvertToGrade(Convert.ToDouble(lblEnglishTotal.Text));
            //            lblHindiPT.Text = marksPTCol.Where(x => x.subjectId == 13).FirstOrDefault().marks;
            //            lblHindiNS.Text = markNSsCol.Where(x => x.subjectId == 13).FirstOrDefault().marks;
            //            lblHindiSEA.Text = marksSEACol.Where(x => x.subjectId == 13).FirstOrDefault().marks;
            //            lblHindiTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 13).FirstOrDefault().marks;
            //            lblHindiTotal.Text = (Convert.ToDouble(lblHindiPT.Text) + Convert.ToDouble(lblHindiNS.Text) + Convert.ToDouble(lblHindiSEA.Text) + Convert.ToDouble(lblHindiTerm1.Text)).ToString();
            //            lblHindiGrade.Text = ConvertToGrade(Convert.ToDouble(lblHindiTotal.Text));
            //            lblSciencePT.Text = marksPTCol.Where(x => x.subjectId == 29).FirstOrDefault().marks;
            //            lblScienceNS.Text = markNSsCol.Where(x => x.subjectId == 29).FirstOrDefault().marks;
            //            lblScienceSEA.Text = marksSEACol.Where(x => x.subjectId == 29).FirstOrDefault().marks;
            //            lblScienceTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 29).FirstOrDefault().marks;
            //            lblScienceTotal.Text = (Convert.ToDouble(lblSciencePT.Text) + Convert.ToDouble(lblScienceNS.Text) + Convert.ToDouble(lblScienceSEA.Text) + Convert.ToDouble(lblScienceTerm1.Text)).ToString();
            //            lblScienceGrade.Text = ConvertToGrade(Convert.ToDouble(lblScienceTotal.Text));
            //            lblSocialSciencePT.Text = marksPTCol.Where(x => x.subjectId == 35).FirstOrDefault().marks;
            //            lblSocialScienceNS.Text = markNSsCol.Where(x => x.subjectId == 35).FirstOrDefault().marks;
            //            lblSocialScienceSEA.Text = marksSEACol.Where(x => x.subjectId == 35).FirstOrDefault().marks;
            //            lblSocialScienceTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 35).FirstOrDefault().marks;
            //            lblSocialScienceTotal.Text = (Convert.ToDouble(lblSocialSciencePT.Text) + Convert.ToDouble(lblSocialScienceNS.Text) + Convert.ToDouble(lblSocialScienceSEA.Text) + Convert.ToDouble(lblSocialScienceTerm1.Text)).ToString();
            //            lblSocialScienceGrade.Text = ConvertToGrade(Convert.ToDouble(lblSocialScienceTotal.Text));
            //            lblMathematicsPT.Text = marksPTCol.Where(x => x.subjectId == 1).FirstOrDefault().marks;
            //            lblMathematicsNS.Text = markNSsCol.Where(x => x.subjectId == 1).FirstOrDefault().marks;
            //            lblMathematicsSEA.Text = marksSEACol.Where(x => x.subjectId == 1).FirstOrDefault().marks;
            //            lblMathematicsTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 1).FirstOrDefault().marks;
            //            lblMathematicsTotal.Text = (Convert.ToDouble(lblMathematicsPT.Text) + Convert.ToDouble(lblMathematicsNS.Text) + Convert.ToDouble(lblMathematicsSEA.Text) + Convert.ToDouble(lblMathematicsTerm1.Text)).ToString();
            //            lblMathematicsGrade.Text = ConvertToGrade(Convert.ToDouble(lblMathematicsTotal.Text));
            //            lblGKPT.Text = marksPTCol.Where(x => x.subjectId == 104).FirstOrDefault().marks;
            //            lblGKNS.Text = markNSsCol.Where(x => x.subjectId == 104).FirstOrDefault().marks;
            //            lblGKSEA.Text = marksSEACol.Where(x => x.subjectId == 104).FirstOrDefault().marks;
            //            lblGKTerm1.Text = marksTerm1Col.Where(x => x.subjectId == 104).FirstOrDefault().marks;
            //            lblGKTotal.Text = (Convert.ToDouble(lblGKPT.Text) + Convert.ToDouble(lblGKNS.Text) + Convert.ToDouble(lblGKSEA.Text) + Convert.ToDouble(lblGKTerm1.Text)).ToString();
            //            lblGKGrade.Text = ConvertToGrade(Convert.ToDouble(lblGKTotal.Text));
            //            lblArtEdu.Text = gradeCol.Where(x => x.subjectId == 52).FirstOrDefault().grade;
            //            lblWorkEdu.Text = gradeCol.Where(x => x.subjectId == 51).FirstOrDefault().grade;
            //            lblPhysicalEdu.Text = gradeCol.Where(x => x.subjectId == 53).FirstOrDefault().grade;
            //            lblRegularity.Text = gradeCol.Where(x => x.subjectId == 67).FirstOrDefault().grade;
            //            lblSincerity.Text = gradeCol.Where(x => x.subjectId == 119).FirstOrDefault().grade;
            //            lblBehaviour.Text = gradeCol.Where(x => x.subjectId == 120).FirstOrDefault().grade;
            //            lblAttitudeTeachers.Text = gradeCol.Where(x => x.subjectId == 70).FirstOrDefault().grade;
            //            lblAttitudeStudents.Text = gradeCol.Where(x => x.subjectId == 69).FirstOrDefault().grade;
            //            lblGrade.Text = ConvertToGrade((Convert.ToDouble(lblSocialScienceTotal.Text) + Convert.ToDouble(lblEnglishTotal.Text) + Convert.ToDouble(lblHindiTotal.Text) + Convert.ToDouble(lblScienceTotal.Text) + Convert.ToDouble(lblMathematicsTotal.Text) + Convert.ToDouble(lblGKTotal.Text)) / 6);
            //            lblAttendance.Text = remarksAttendance.attendance;
            //            lblRemarks.Text = remarksAttendance.remarks;
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