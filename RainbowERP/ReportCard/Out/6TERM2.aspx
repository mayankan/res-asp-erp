<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="6TERM2.aspx.cs" Inherits="RAINBOW_ERP.ReportCard.Out._6TERM2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font-size: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="border: 1px solid black;">
            <br />
            <asp:Image ID="imgLogo" runat="server" Width="90%" Style="padding-left: 50px;" />
            <p style="text-align: center"><b>REPORT CARD</b></p>
            <p style="text-align: center">SESSION 2017-18</p>
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
            </br>
            <table style="width: 100%; height: 1200px" border="1" cellspacing="0" cellpadding="0" align="center">
                <tbody>
                    <tr>
                        <td style="border: 1px solid black; border-spacing: 0px;"><strong>Scholastic Area</strong></td>
                        <td colspan="7" style="text-align: center"><strong>TERM – 1 (100 marks)</strong></td>
                        <td colspan="7" style="text-align: center"><strong>TERM – 2 (100 marks)</strong></td>
                    </tr>
                    <tr style="border: 1px solid black;">
                        <td><strong>Subject Name</strong></td>
                        <td><strong>PT </strong>

                            <strong>(10)</strong></td>
                        <td><strong>NS </strong>

                            <strong>(5)</strong></td>
                        <td><strong>SEA </strong>

                            <strong>(5)</strong></td>
                        <td><strong>Term-1 </strong>

                            <strong>(80)</strong></td>
                        <td colspan="2"><strong>Marks Obtained (100)</strong></td>
                        <td><strong>Grade</strong></td>
                        <td><strong>PT </strong>

                            <strong>(10)</strong></td>
                        <td><strong>NS </strong>

                            <strong>(5)</strong></td>
                        <td><strong>SEA </strong>

                            <strong>(5)</strong></td>
                        <td><strong>Term-1 </strong>

                            <strong>(80)</strong></td>
                        <td colspan="2"><strong>Marks Obtained (100)</strong></td>
                        <td><strong>Grade</strong></td>
                    </tr>
                    <tr>
                        <td><strong>ENGLISH</strong></td>
                        <td width="86" style="text-align: center">
                            <asp:Label ID="lblEnglishPT" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblEnglishNS" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center">
                            <asp:Label ID="lblEnglishSEA" runat="server"></asp:Label></td>
                        <td width="108" style="text-align: center">
                            <asp:Label ID="lblEnglishTerm1" runat="server"></asp:Label></td>
                        <td colspan="2" width="132" style="text-align: center">
                            <asp:Label ID="lblEnglishTotal" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblEnglishGrade" runat="server"></asp:Label></td>
                        <td width="86" style="text-align: center">
                            <asp:Label ID="lblEnglishPT2" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblEnglishNS2" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center">
                            <asp:Label ID="lblEnglishSEA2" runat="server"></asp:Label></td>
                        <td width="108" style="text-align: center">
                            <asp:Label ID="lblEnglishTerm2" runat="server"></asp:Label></td>
                        <td colspan="2" width="132" style="text-align: center">
                            <asp:Label ID="lblEnglishTotal2" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblEnglishGrade2" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>HINDI</strong></td>
                        <td width="86" style="text-align: center">
                            <asp:Label ID="lblHindiPT" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblHindiNS" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center">
                            <asp:Label ID="lblHindiSEA" runat="server"></asp:Label></td>
                        <td width="108" style="text-align: center">
                            <asp:Label ID="lblHindiTerm1" runat="server"></asp:Label></td>
                        <td colspan="2" width="132" style="text-align: center">
                            <asp:Label ID="lblHindiTotal" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblHindiGrade" runat="server"></asp:Label></td>
                        <td width="86" style="text-align: center">
                            <asp:Label ID="lblHindiPT2" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblHindiNS2" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center">
                            <asp:Label ID="lblHindiSEA2" runat="server"></asp:Label></td>
                        <td width="108" style="text-align: center">
                            <asp:Label ID="lblHindiTerm2" runat="server"></asp:Label></td>
                        <td colspan="2" width="132" style="text-align: center">
                            <asp:Label ID="lblHindiTotal2" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblHindiGrade2" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>SANSKRIT</strong></td>
                        <td width="86" style="text-align: center">
                            <asp:Label ID="lblSanskritPT" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblSanskritNS" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center">
                            <asp:Label ID="lblSanskritSEA" runat="server"></asp:Label></td>
                        <td width="108" style="text-align: center">
                            <asp:Label ID="lblSanskritTerm1" runat="server"></asp:Label></td>
                        <td colspan="2" width="132" style="text-align: center">
                            <asp:Label ID="lblSanskritTotal" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblSanskritGrade" runat="server"></asp:Label></td>
                        <td width="86" style="text-align: center">
                            <asp:Label ID="lblSanskritPT2" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblSanskritNS2" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center">
                            <asp:Label ID="lblSanskritSEA2" runat="server"></asp:Label></td>
                        <td width="108" style="text-align: center">
                            <asp:Label ID="lblSanskritTerm2" runat="server"></asp:Label></td>
                        <td colspan="2" width="132" style="text-align: center">
                            <asp:Label ID="lblSanskritTotal2" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblSanskritGrade2" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>MATHEMATICS</strong></td>
                        <td width="86" style="text-align: center">
                            <asp:Label ID="lblMathematicsPT" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblMathematicsNS" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center">
                            <asp:Label ID="lblMathematicsSEA" runat="server"></asp:Label></td>
                        <td width="108" style="text-align: center">
                            <asp:Label ID="lblMathematicsTerm1" runat="server"></asp:Label></td>
                        <td colspan="2" width="132" style="text-align: center">
                            <asp:Label ID="lblMathematicsTotal" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblMathematicsGrade" runat="server"></asp:Label></td>
                        <td width="86" style="text-align: center">
                            <asp:Label ID="lblMathematicsPT2" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblMathematicsNS2" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center">
                            <asp:Label ID="lblMathematicsSEA2" runat="server"></asp:Label></td>
                        <td width="108" style="text-align: center">
                            <asp:Label ID="lblMathematicsTerm2" runat="server"></asp:Label></td>
                        <td colspan="2" width="132" style="text-align: center">
                            <asp:Label ID="lblMathematicsTotal2" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblMathematicsGrade2" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>SCIENCE</strong></td>
                        <td width="86" style="text-align: center">
                            <asp:Label ID="lblSciencePT" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblScienceNS" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center">
                            <asp:Label ID="lblScienceSEA" runat="server"></asp:Label></td>
                        <td width="108" style="text-align: center">
                            <asp:Label ID="lblScienceTerm1" runat="server"></asp:Label></td>
                        <td colspan="2" width="132" style="text-align: center">
                            <asp:Label ID="lblScienceTotal" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblScienceGrade" runat="server"></asp:Label></td>
                        <td width="86" style="text-align: center">
                            <asp:Label ID="lblSciencePT2" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblScienceNS2" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center">
                            <asp:Label ID="lblScienceSEA2" runat="server"></asp:Label></td>
                        <td width="108" style="text-align: center">
                            <asp:Label ID="lblScienceTerm2" runat="server"></asp:Label></td>
                        <td colspan="2" width="132" style="text-align: center">
                            <asp:Label ID="lblScienceTotal2" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblScienceGrade2" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>SOCIAL SCIENCE</strong></td>
                        <td width="86" style="text-align: center">
                            <asp:Label ID="lblSocialSciencePT" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblSocialScienceNS" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center">
                            <asp:Label ID="lblSocialScienceSEA" runat="server"></asp:Label></td>
                        <td width="108" style="text-align: center">
                            <asp:Label ID="lblSocialScienceTerm1" runat="server"></asp:Label></td>
                        <td colspan="2" width="132" style="text-align: center">
                            <asp:Label ID="lblSocialScienceTotal" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblSocialScienceGrade" runat="server"></asp:Label></td>
                        <td width="86" style="text-align: center">
                            <asp:Label ID="lblSocialSciencePT2" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblSocialScienceNS2" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center">
                            <asp:Label ID="lblSocialScienceSEA2" runat="server"></asp:Label></td>
                        <td width="108" style="text-align: center">
                            <asp:Label ID="lblSocialScienceTerm2" runat="server"></asp:Label></td>
                        <td colspan="2" width="132" style="text-align: center">
                            <asp:Label ID="lblSocialScienceTotal2" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblSocialScienceGrade2" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>G.K./Value Education</strong></td>
                        <td width="86" style="text-align: center">
                            <asp:Label ID="lblGKPT" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblGKNS" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center">
                            <asp:Label ID="lblGKSEA" runat="server"></asp:Label></td>
                        <td width="108" style="text-align: center">
                            <asp:Label ID="lblGKTerm1" runat="server"></asp:Label></td>
                        <td colspan="2" width="132" style="text-align: center">
                            <asp:Label ID="lblGKTotal" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblGKGrade" runat="server"></asp:Label></td>
                        <td width="86" style="text-align: center">
                            <asp:Label ID="lblGKPT2" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblGKNS2" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center">
                            <asp:Label ID="lblGKSEA2" runat="server"></asp:Label></td>
                        <td width="108" style="text-align: center">
                            <asp:Label ID="lblGKTerm2" runat="server"></asp:Label></td>
                        <td colspan="2" width="132" style="text-align: center">
                            <asp:Label ID="lblGKTotal2" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblGKGrade2" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="6"><strong>Co-Scholastic Areas : Term – 1 [on a 3 point (A-C) grading scale]</strong>
                            <td colspan="2" style="text-align: center"><strong>Grade</strong></td>
                            <td colspan="5"><strong>Co-Scholastic Areas : Term – 2 [on a 3 point (A-C) grading scale]</strong>
                                <td colspan="2" style="text-align: center"><strong>Grade</strong></td>
                    </tr>
                    <tr>
                        <td colspan="6" width="645"><strong>Work Education (or Pre-vocational Education)</strong></td>
                        <td colspan="2" style="text-align: center"><strong>
                            <asp:Label ID="lblWorkEdu" runat="server"></asp:Label></strong></td>
                        <td colspan="6" width="645"><strong>Work Education (or Pre-vocational Education)</strong></td>
                        <td colspan="2" style="text-align: center"><strong>
                            <asp:Label ID="lblWorkEdu2" runat="server"></asp:Label></strong></td>
                    </tr>
                    <tr>
                        <td colspan="6" width="645"><strong>Art Education</strong></td>
                        <td colspan="2" style="text-align: center"><strong>
                            <asp:Label ID="lblArtEdu" runat="server"></asp:Label></strong></td>
                        <td colspan="6" width="645"><strong>Art Education</strong></td>
                        <td colspan="2" style="text-align: center"><strong>
                            <asp:Label ID="lblArtEdu2" runat="server"></asp:Label></strong></td>
                    </tr>
                    <tr>
                        <td colspan="6" width="645"><strong>Health &amp; Physical Education</strong></td>
                        <td colspan="2" style="text-align: center"><strong>
                            <asp:Label ID="lblPhysicalEdu" runat="server"></asp:Label></strong></td>
                        <td colspan="6" width="645"><strong>Health &amp; Physical Education</strong></td>
                        <td colspan="2" style="text-align: center"><strong>
                            <asp:Label ID="lblPhysicalEdu2" runat="server"></asp:Label></strong></td>
                    </tr>
                    <tr>
                        <td colspan="6" style="text-align: center;"><strong></strong></td>
                        <td colspan="2" style="text-align: center;"><strong>Grade</strong></td>
                        <td colspan="6" style="text-align: center;"><strong></strong></td>
                        <td colspan="2" style="text-align: center;"><strong>Grade</strong></td>
                    </tr>
                    <tr>
                        <td colspan="6" width="645"><strong>Discipline : Term – 1 [on a 3 point (A-C) grading scale]</strong></td>
                        <td colspan="2" style="text-align: center"><strong>
                            <asp:Label ID="lblDiscipline" runat="server"></asp:Label></strong></td>
                        <td colspan="6" width="645"><strong>Discipline : Term – 2 [on a 3 point (A-C) grading scale]</strong></td>
                        <td colspan="2" style="text-align: center"><strong>
                            <asp:Label ID="lblDiscipline2" runat="server"></asp:Label></strong></td>
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
                    <td>&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Class Teacher's Remarks:&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblRemarks" runat="server"></asp:Label></td>
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
