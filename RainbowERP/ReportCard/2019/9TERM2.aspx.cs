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
                        int term1ExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 1");
                        int ptId = reportBLL.viewExamIdByClass(studentCL.classId, "PT(10)");
                        int nsId = reportBLL.viewExamIdByClass(studentCL.classId, "NS(5)");
                        int seaId = reportBLL.viewExamIdByClass(studentCL.classId, "SEA(5)");
                        int pt2Id = reportBLL.viewExamIdByClass(studentCL.classId, "PT2(10)");
                        int pt3Id = reportBLL.viewExamIdByClass(studentCL.classId, "PT3(10)");
                        int annualId = reportBLL.viewExamIdByClass(studentCL.classId, "ANNUAL(80)");
                        int term2GenExamId = reportBLL.viewExamIdByClass(studentCL.classId, "TERM 2 - GENERAL");
                        //int examinationId = Convert.ToInt32(Request.QueryString["examId"]);
                        //Collection<SubjectCL> subjectCol = subjectBLL.viewSubjectByClassId(studentCL.classId);
                        MiscEntryCL remarksAttendance = reportBLL.viewMiscByStudentId(studentId, term2GenExamId);
                        Collection<MarksEntryCL> marksTerm1Col = reportBLL.viewMarksByStudentId(studentId, term1ExamId);
                        Collection<MarksEntryCL> marksPTCol = reportBLL.viewMarksByStudentId(studentId, ptId);
                        Collection<MarksEntryCL> marksPT2Col = reportBLL.viewMarksByStudentId(studentId, pt2Id);
                        Collection<MarksEntryCL> marksPT3Col = reportBLL.viewMarksByStudentId(studentId, pt3Id);
                        Collection<MarksEntryCL> marksAnnualCol = reportBLL.viewMarksByStudentId(studentId, annualId);
                        Collection<MarksEntryCL> markNSsCol = reportBLL.viewMarksByStudentId(studentId, nsId);
                        Collection<MarksEntryCL> marksSEACol = reportBLL.viewMarksByStudentId(studentId, seaId);
                        Collection<GradeEntryCL> gradeCol = reportBLL.viewGradesByStudentId(studentId, term1ExamId);
                        lblAttendance.Text = remarksAttendance.attendance;
                        lblRemarks.Text = remarksAttendance.remarks;
                        //lblEnglishPT1.Text = marksPTCol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        //lblEnglishPT2.Text = marksPT2Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        //lblEnglishPT3.Text = marksPT3Col.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        //lblEnglishAvgPT.Text = returnHighest(Convert.ToDouble(lblEnglishPT1.Text), Convert.ToDouble(lblEnglishPT2.Text), Convert.ToDouble(lblEnglishPT3.Text)).ToString();
                        //lblEnglishNS.Text = markNSsCol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        //lblEnglishSEA.Text = marksSEACol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        //lblEnglishTotal.Text = (Convert.ToDouble(lblEnglishAvgPT.Text) + Convert.ToDouble(lblEnglishNS.Text) + Convert.ToDouble(lblEnglishSEA.Text)).ToString();
                        //lblEnglishAnnual.Text = marksAnnualCol.Where(x => x.subjectId == 0).FirstOrDefault().marks;
                        //lblEnglishGrandTotal.Text = (Convert.ToDouble(lblEnglishAnnual.Text) + Convert.ToDouble(lblEnglishTotal.Text)).ToString();
                        //lblEnglishGrade.Text = ConvertToGrade(Convert.ToDouble(lblEnglishGrandTotal.Text));
                        //lblHindiPT1.Text = marksPTCol.Where(x => x.subjectId == 13).FirstOrDefault().marks;
                        //lblHindiPT2.Text = marksPT2Col.Where(x => x.subjectId == 13).FirstOrDefault().marks;
                        //lblHindiPT3.Text = marksPT3Col.Where(x => x.subjectId == 13).FirstOrDefault().marks;
                        //lblHindiAvgPT.Text = returnHighest(Convert.ToDouble(lblHindiPT1.Text), Convert.ToDouble(lblHindiPT2.Text), Convert.ToDouble(lblHindiPT3.Text)).ToString();
                        //lblHindiNS.Text = markNSsCol.Where(x => x.subjectId == 13).FirstOrDefault().marks;
                        //lblHindiSEA.Text = marksSEACol.Where(x => x.subjectId == 13).FirstOrDefault().marks;
                        //lblHindiTotal.Text = (Convert.ToDouble(lblHindiAvgPT.Text) + Convert.ToDouble(lblHindiNS.Text) + Convert.ToDouble(lblHindiSEA.Text)).ToString();
                        //lblHindiAnnual.Text = marksAnnualCol.Where(x => x.subjectId == 13).FirstOrDefault().marks;
                        //lblHindiGrandTotal.Text = (Convert.ToDouble(lblHindiAnnual.Text) + Convert.ToDouble(lblHindiTotal.Text)).ToString();
                        //lblHindiGrade.Text = ConvertToGrade(Convert.ToDouble(lblHindiGrandTotal.Text));
                        //lblMathematicsPT1.Text = marksPTCol.Where(x => x.subjectId == 1).FirstOrDefault().marks;
                        //lblMathematicsPT2.Text = marksPT2Col.Where(x => x.subjectId == 1).FirstOrDefault().marks;
                        //lblMathematicsPT3.Text = marksPT3Col.Where(x => x.subjectId == 1).FirstOrDefault().marks;
                        //lblMathematicsAvgPT.Text = returnHighest(Convert.ToDouble(lblMathematicsPT1.Text), Convert.ToDouble(lblMathematicsPT2.Text), Convert.ToDouble(lblMathematicsPT3.Text)).ToString();
                        //lblMathematicsNS.Text = markNSsCol.Where(x => x.subjectId == 1).FirstOrDefault().marks;
                        //lblMathematicsSEA.Text = marksSEACol.Where(x => x.subjectId == 1).FirstOrDefault().marks;
                        //lblMathematicsTotal.Text = (Convert.ToDouble(lblMathematicsAvgPT.Text) + Convert.ToDouble(lblMathematicsNS.Text) + Convert.ToDouble(lblMathematicsSEA.Text)).ToString();
                        //lblMathematicsAnnual.Text = marksAnnualCol.Where(x => x.subjectId == 1).FirstOrDefault().marks;
                        //lblMathematicsGrandTotal.Text = (Convert.ToDouble(lblMathematicsAnnual.Text) + Convert.ToDouble(lblMathematicsTotal.Text)).ToString();
                        //lblMathematicsGrade.Text = ConvertToGrade(Convert.ToDouble(lblMathematicsGrandTotal.Text));
                        //lblSciencePT1.Text = marksPTCol.Where(x => x.subjectId == 29).FirstOrDefault().marks;
                        //lblSciencePT2.Text = marksPT2Col.Where(x => x.subjectId == 29).FirstOrDefault().marks;
                        //lblSciencePT3.Text = marksPT3Col.Where(x => x.subjectId == 29).FirstOrDefault().marks;
                        //lblScienceAvgPT.Text = returnHighest(Convert.ToDouble(lblSciencePT1.Text), Convert.ToDouble(lblSciencePT2.Text), Convert.ToDouble(lblSciencePT3.Text)).ToString();
                        //lblScienceNS.Text = markNSsCol.Where(x => x.subjectId == 29).FirstOrDefault().marks;
                        //lblScienceSEA.Text = marksSEACol.Where(x => x.subjectId == 29).FirstOrDefault().marks;
                        //lblScienceTotal.Text = (Convert.ToDouble(lblScienceAvgPT.Text) + Convert.ToDouble(lblScienceNS.Text) + Convert.ToDouble(lblScienceSEA.Text)).ToString();
                        //lblScienceAnnual.Text = marksAnnualCol.Where(x => x.subjectId == 29).FirstOrDefault().marks;
                        //lblScienceGrandTotal.Text = (Convert.ToDouble(lblScienceAnnual.Text) + Convert.ToDouble(lblScienceTotal.Text)).ToString();
                        //lblScienceGrade.Text = ConvertToGrade(Convert.ToDouble(lblScienceGrandTotal.Text));
                        //lblSocialSciencePT1.Text = marksPTCol.Where(x => x.subjectId == 35).FirstOrDefault().marks;
                        //lblSocialSciencePT2.Text = marksPT2Col.Where(x => x.subjectId == 35).FirstOrDefault().marks;
                        //lblSocialSciencePT3.Text = marksPT3Col.Where(x => x.subjectId == 35).FirstOrDefault().marks;
                        //lblSocialScienceAvgPT.Text = returnHighest(Convert.ToDouble(lblSocialSciencePT1.Text), Convert.ToDouble(lblSocialSciencePT2.Text), Convert.ToDouble(lblSocialSciencePT3.Text)).ToString();
                        //lblSocialScienceNS.Text = markNSsCol.Where(x => x.subjectId == 35).FirstOrDefault().marks;
                        //lblSocialScienceSEA.Text = marksSEACol.Where(x => x.subjectId == 35).FirstOrDefault().marks;
                        //lblSocialScienceTotal.Text = (Convert.ToDouble(lblSocialScienceAvgPT.Text) + Convert.ToDouble(lblSocialScienceNS.Text) + Convert.ToDouble(lblSocialScienceSEA.Text)).ToString();
                        //lblSocialScienceAnnual.Text = marksAnnualCol.Where(x => x.subjectId == 35).FirstOrDefault().marks;
                        //lblSocialScienceGrandTotal.Text = (Convert.ToDouble(lblSocialScienceAnnual.Text) + Convert.ToDouble(lblSocialScienceTotal.Text)).ToString();
                        //lblSocialScienceGrade.Text = ConvertToGrade(Convert.ToDouble(lblSocialScienceGrandTotal.Text));
                        //lblArtEdu.Text = gradeCol.Where(x => x.subjectId == 52).FirstOrDefault().grade;
                        //lblWorkEdu.Text = gradeCol.Where(x => x.subjectId == 51).FirstOrDefault().grade;
                        //lblPhysicalEdu.Text = gradeCol.Where(x => x.subjectId == 53).FirstOrDefault().grade;
                        //lblGrandTotal.Text = Math.Ceiling(Convert.ToDouble(lblEnglishGrandTotal.Text) + Convert.ToDouble(lblHindiGrandTotal.Text) + Convert.ToDouble(lblMathematicsGrandTotal.Text) + Convert.ToDouble(lblScienceGrandTotal.Text) + Convert.ToDouble(lblSocialScienceGrandTotal.Text)).ToString();
                        //lblPercentage.Text = Math.Ceiling(Convert.ToDouble(lblGrandTotal.Text) / 5).ToString();
                        //lblGrade.Text = ConvertToGrade(Convert.ToDouble(lblPercentage.Text)).ToString();
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
        private double returnHighest(double FirstValue, double SecondValue, double ThirdValue)
        {
            double[] highestTwo = new double[2];
            double avgOfTwo;
            int firstValueChecked = 0;
            if (FirstValue >= SecondValue && FirstValue >= ThirdValue)
            {
                if (FirstValue == SecondValue)
                {
                    highestTwo[0] = FirstValue;
                    highestTwo[1] = SecondValue;
                }
                else if (FirstValue == ThirdValue)
                {
                    highestTwo[0] = FirstValue;
                    highestTwo[1] = ThirdValue;
                }
                else
                {
                    highestTwo[0] = FirstValue;
                    firstValueChecked = 1;
                }
            }
            else if (SecondValue >= FirstValue && SecondValue >= ThirdValue)
            {
                if (SecondValue == FirstValue)
                {
                    highestTwo[0] = FirstValue;
                    highestTwo[1] = SecondValue;
                }
                else if (SecondValue == ThirdValue)
                {
                    highestTwo[0] = SecondValue;
                    highestTwo[1] = ThirdValue;
                }
                else
                {
                    highestTwo[0] = SecondValue;
                    firstValueChecked = 2;
                }
            }
            else if (ThirdValue >= FirstValue && ThirdValue >= SecondValue)
            {
                if (ThirdValue == FirstValue)
                {
                    highestTwo[0] = FirstValue;
                    highestTwo[1] = ThirdValue;
                }
                else if (ThirdValue == SecondValue)
                {
                    if (ThirdValue == SecondValue)
                    {
                        highestTwo[0] = SecondValue;
                        highestTwo[1] = ThirdValue;
                    }
                }
                else
                {
                    highestTwo[0] = ThirdValue;
                    firstValueChecked = 3;
                }
            }
            switch (firstValueChecked)
            {
                case 1:
                    if (SecondValue > ThirdValue)
                        highestTwo[1] = SecondValue;
                    else
                        highestTwo[1] = ThirdValue;
                    break;
                case 2:
                    if (ThirdValue > FirstValue)
                        highestTwo[1] = ThirdValue;
                    else
                        highestTwo[1] = FirstValue;
                    break;
                case 3:
                    if (FirstValue > SecondValue)
                        highestTwo[1] = FirstValue;
                    else
                        highestTwo[1] = SecondValue;
                    break;
                default:
                    break;
            }
            avgOfTwo = highestTwo[0] + highestTwo[1];
            avgOfTwo = avgOfTwo / 2;
            return avgOfTwo;
        }
    }
}