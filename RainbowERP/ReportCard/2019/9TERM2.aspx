<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="9TERM2.aspx.cs" Inherits="RAINBOW_ERP.ReportCard._2019._9TERM2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <div style="border: 1px solid black;">
            <br />
            <asp:Image ID="imgLogo" runat="server" Width="90%" Style="padding-left: 50px;" />
            <p style="text-align: center"><b>REPORT CARD</b></p>
            <p style="text-align: center">CLASS : IX</p>
            <p style="text-align: center">SESSION 2018-19</p>
            <br />
            <table style="width: 100%; height: 150px;">
                <tr>
                    <td>
                        <br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label1" runat="server" Text="Student Name : "></asp:Label>
                        <asp:Label ID="lblStudentName" runat="server"></asp:Label><br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label3" runat="server" Text="Father's Name : "></asp:Label>
                        <asp:Label ID="lblFatherName" runat="server"></asp:Label><br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label9" runat="server" Text="Mother's Name : "></asp:Label>
                        <asp:Label ID="lblMotherName" runat="server"></asp:Label><br />
                        <br />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="Admission No. :"></asp:Label>
                        <asp:Label ID="lblAdmissionNo" runat="server"></asp:Label><br />
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Class-Sec :"></asp:Label>
                        <asp:Label ID="lblClassSec" runat="server"></asp:Label><br />
                        <br />
                        <asp:Label ID="Label2" runat="server" Text="Attendance :"></asp:Label>
                        <asp:Label ID="lblAttendance" runat="server"></asp:Label><br />
                        <br />
                    </td>
                </tr>
            </table>
            <br />
            <table style="width: 100%; height: 400px" border="1" cellspacing="0" cellpadding="0" align="center">
                <tbody>
                    <tr>
                        <td colspan="16" style="text-align: center; border: 1px solid black; border-spacing: 0px;"><strong>SCHOLASTIC AREA</strong></td>
                    </tr>
                    <tr style="border: 1px solid black;">
                        <td colspan="2" style="text-align: center"><strong>Subject Name</strong></td>
                        <td width="40" style="text-align: center"><strong>PT1<br />
                            (10)</strong></td>
                        <td width="40" style="text-align: center"><strong>PT2<br />
                            (10)</strong></td>
                        <td width="40" style="text-align: center"><strong>PT3<br />
                            (10)</strong></td>
                        <td colspan="2" style="text-align: center"><strong>Avg of </strong></br>
                            <strong>Best 2 PT<br />
                                (10)</strong></td>
                        <td style="text-align: center"><strong>NS<br />
                            (5)</strong></td>
                        <td style="text-align: center"><strong>SEA<br />
                            (5)</strong></td>
                        <td colspan="2" style="text-align: center"><strong>Total<br />
                            (20)</strong></td>
                        <td colspan="2" style="text-align: center"><strong>Annual</strong>
                            <strong>Exam<br />
                                (80)</strong></td>
                        <td colspan="2" style="text-align: center"><strong>Grand Total<br />
                            (100)</strong></td>
                        <td style="text-align: center"><strong>Grade</strong></td>
                    </tr>
                    <tr>
                        <td colspan="2"><strong>ENGLISH</strong></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblEnglishPT1" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblEnglishPT2" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblEnglishPT3" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblEnglishAvgPT" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblEnglishNS" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblEnglishSEA" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblEnglishTotal" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblEnglishAnnual" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblEnglishGrandTotal" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblEnglishGrade" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2"><strong>HINDI</strong></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblHindiPT1" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblHindiPT2" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblHindiPT3" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblHindiAvgPT" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblHindiNS" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblHindiSEA" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblHindiTotal" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblHindiAnnual" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblHindiGrandTotal" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblHindiGrade" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2"><strong>MATHEMATICS</strong></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblMathematicsPT1" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblMathematicsPT2" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblMathematicsPT3" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblMathematicsAvgPT" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblMathematicsNS" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblMathematicsSEA" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblMathematicsTotal" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblMathematicsAnnual" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblMathematicsGrandTotal" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblMathematicsGrade" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2"><strong>SCIENCE</strong></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblSciencePT1" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblSciencePT2" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblSciencePT3" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblScienceAvgPT" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblScienceNS" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblScienceSEA" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblScienceTotal" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblScienceAnnual" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblScienceGrandTotal" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblScienceGrade" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2"><strong>SOCIAL SCIENCE</strong></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblSocialSciencePT1" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblSocialSciencePT2" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblSocialSciencePT3" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblSocialScienceAvgPT" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblSocialScienceNS" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblSocialScienceSEA" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblSocialScienceTotal" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblSocialScienceAnnual" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center">
                            <asp:Label ID="lblSocialScienceGrandTotal" runat="server"></asp:Label></td>
                        <td style="text-align: center">
                            <asp:Label ID="lblSocialScienceGrade" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2"><strong>I.T.</strong></td>
                        <td style="text-align: center">
                            &nbsp;</td>
                        <td style="text-align: center">
                            &nbsp;</td>
                        <td style="text-align: center">
                            &nbsp;</td>
                        <td colspan="2" style="text-align: center">
                            &nbsp;</td>
                        <td style="text-align: center">
                            &nbsp;</td>
                        <td style="text-align: center">
                            &nbsp;</td>
                        <td colspan="2" style="text-align: center">
                            &nbsp;</td>
                        <td colspan="2" style="text-align: center">
                            &nbsp;</td>
                        <td colspan="2" style="text-align: center">
                            &nbsp;</td>
                        <td style="text-align: center">
                            &nbsp;</td>
                    </tr>
                </tbody>
            </table>
            </br>
            </br>
            <table width="100%">
                <tbody>
                    <tr>
                        <td>
                            <table border="1" cellspacing="0" cellpadding="10">
                                <tbody>
                                    <tr>
                                        <td>Grand Total</td>
                                        <td>
                                            <asp:Label ID="lblGrandTotal" runat="server"></asp:Label></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td>
                            <table border="1" cellspacing="0" cellpadding="10" align="center">
                                <tbody>
                                    <tr>
                                        <td>Percentage</td>
                                        <td>
                                            <asp:Label ID="lblPercentage" runat="server"></asp:Label></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td>
                            <table border="1" cellspacing="0" cellpadding="10" align="right">
                                <tbody>
                                    <tr>
                                        <td>Grade</td>
                                        <td>
                                            <asp:Label ID="lblGrade" runat="server"></asp:Label></td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </tbody>
            </table>
            </br>
            </br>
            <table style="width: 100%; height: 300px" border="1" cellspacing="0" cellpadding="0" align="center">
                <tbody>
                    <tr>
                        <td colspan="6"><strong>Co-Scholastic Areas : Term – 1 [on a 3 point (A-C) grading scale]</strong>
                            <td colspan="2" style="text-align: center"><strong>Grade</strong></td>
                    </tr>
                    <tr>
                        <td colspan="6" width="645"><strong>Work Education (or Pre-vocational Education)</strong></td>
                        <td colspan="2" style="text-align: center"><strong>
                            <asp:Label ID="lblWorkEdu" runat="server"></asp:Label></strong></td>
                    </tr>
                    <tr>
                        <td colspan="6" width="645"><strong>Art Education</strong></td>
                        <td colspan="2" style="text-align: center"><strong>
                            <asp:Label ID="lblArtEdu" runat="server"></asp:Label></strong></td>
                    </tr>
                    <tr>
                        <td colspan="6" width="645"><strong>Health &amp; Physical Education</strong></td>
                        <td colspan="2" style="text-align: center"><strong>
                            <asp:Label ID="lblPhysicalEdu" runat="server"></asp:Label></strong></td>
                    </tr>
                </tbody>
            </table>
            <br />
            <br />
            <br />
            <br />
            <br />
            <table style="width: 100%; height: 150px; border: 1px solid black;">
                <tr>
                    <td>&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Class Teacher's Remarks:&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label ID="lblRemarks" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </table>
            <span>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="text-align: center"><br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Parent&#39;s Signature&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Signature of Class Teacher</span><span style="float: right; padding-right: 2em;">Signature of HOS</span>
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
