<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="3TERM1.aspx.cs" Inherits="RAINBOW_ERP.ReportCard._2018._3TERM1" %>

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
            <p style="text-align: center"><b>ACHIEVEMENT RECORD (FIRST TERMINAL EXAMINATION)</b></p>
            <p style="text-align: center">SESSION 2018-19</p>
            <br />
            <table style="width: 100%; height: 150px;">
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label1" runat="server" Text="Student Name : "></asp:Label>
                        <asp:Label ID="lblStudentName" runat="server"></asp:Label><br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<asp:Label ID="Label4" runat="server" Text="Admission No. :"></asp:Label>
                        <asp:Label ID="lblAdmissionNo" runat="server"></asp:Label><br />
                        <br />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Class-Sec :"></asp:Label>
                        <asp:Label ID="lblClassSec" runat="server"></asp:Label>
                        <br />
                        <br />
                        Attendance :
                        <asp:Label ID="lblAttendance" runat="server"></asp:Label><br />
                        <br />
                    </td>
                </tr>
            </table>
            <table style="width: 100%; height: 400px" border="1" cellspacing="0" cellpadding="0" align="center">
                <tbody>
                    <tr>
                        <td style="border: 1px solid black; border-spacing: 0px;"><strong>Scholastic Area</strong></td>
                        <td colspan="6" style="text-align: center"><strong>TERM – 1 (100 marks)</strong></td>
                    </tr>
                    <tr style="border: 1px solid black;">
                        <td><strong>Subject Name</strong></td>
                        <td><strong>PT </strong>

                            <strong>(30)</strong></td>
                        <td><strong>NS </strong>

                            <strong>(5)</strong></td>
                        <td><strong>SEA </strong>

                            <strong>(5)</strong></td>
                        <td><strong>Term-1 </strong>

                            <strong>(60)</strong></td>
                        <td><strong>Marks Obtained (100)</strong></td>
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
                        <td width="132" style="text-align: center">
                            <asp:Label ID="lblEnglishTotal" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblEnglishGrade" runat="server"></asp:Label></td>
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
                        <td width="132" style="text-align: center">
                            <asp:Label ID="lblHindiTotal" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblHindiGrade" runat="server"></asp:Label></td>
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
                        <td width="132" style="text-align: center">
                            <asp:Label ID="lblMathematicsTotal" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblMathematicsGrade" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>SCIENCE</strong></td>
                        <td width="86" style="text-align: center"><asp:Label ID="lblSciencePT" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center"><asp:Label ID="lblScienceNS" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center"><asp:Label ID="lblScienceSEA" runat="server"></asp:Label></td>
                        <td width="108" style="text-align: center"><asp:Label ID="lblScienceTerm1" runat="server"></asp:Label></td>
                        <td width="132" style="text-align: center"><asp:Label ID="lblScienceTotal" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center"><asp:Label ID="lblScienceGrade" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>SOCIAL SCIENCE</strong></td>
                        <td width="86" style="text-align: center"><asp:Label ID="lblSocialSciencePT" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center"><asp:Label ID="lblSocialScienceNS" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center"><asp:Label ID="lblSocialScienceSEA" runat="server"></asp:Label></td>
                        <td width="108" style="text-align: center"><asp:Label ID="lblSocialScienceTerm1" runat="server"></asp:Label></td>
                        <td width="132" style="text-align: center"><asp:Label ID="lblSocialScienceTotal" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center"><asp:Label ID="lblSocialScienceGrade" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>G.K./MSC</strong></td>
                        <td width="86" style="text-align: center">
                            <asp:Label ID="lblGKPT" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblGKNS" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center">
                            <asp:Label ID="lblGKSEA" runat="server"></asp:Label></td>
                        <td width="108" style="text-align: center">
                            <asp:Label ID="lblGKTerm1" runat="server"></asp:Label></td>
                        <td width="132" style="text-align: center">
                            <asp:Label ID="lblGKTotal" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblGKGrade" runat="server"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
            <br />
            <table style="width: 100%; height: 250px;" border="1" cellspacing="0" cellpadding="0" align="center">
                <tbody>
                    <tr>
                        <td colspan="11"><strong>Co-Scholastic Areas : Term – 1 [on a 3 point (A-C) grading scale]</strong>
                            <td colspan="4" style="text-align: center"><strong>Grade</strong></td>
                    </tr>
                    <tr>
                        <td colspan="11"><strong>Work Education (or Pre-vocational Education)</strong></td>
                        <td colspan="4" style="text-align: center"><strong>
                            <asp:Label ID="lblWorkEdu" runat="server"></asp:Label></strong></td>
                    </tr>
                    <tr>
                        <td colspan="11"><strong>Art Education</strong></td>
                        <td colspan="4" style="text-align: center"><strong>
                            <asp:Label ID="lblArtEdu" runat="server"></asp:Label></strong></td>
                    </tr>
                    <tr>
                        <td colspan="11"><strong>Health &amp; Physical Education</strong></td>
                        <td colspan="4" style="text-align: center"><strong>
                            <asp:Label ID="lblPhysicalEdu" runat="server"></asp:Label></strong></td>
                    </tr>
                </tbody>
            </table>
            <br />
            <table style="width: 100%; height: 250px;" border="1" cellspacing="0" cellpadding="0" align="center">
                <tbody>
                    <tr>
                        <td colspan="15" align="center"><strong>Discipline : Term – 1 [on a 3 point (A-C) grading scale]</strong></td>
                    </tr>
                    <tr>
                        <td colspan="5" width="645" border="1"><strong>ELEMENT</strong></td>
                        <td colspan="3" width="100" style="text-align: center" border="1"><strong>T1</strong></td>
                        <td colspan="6" width="645"></td>
                        <td colspan="2" style="text-align: center"></td>
                    </tr>
                    <tr>
                        <td colspan="5" border="1">1. Regularity and Punctuality</td>
                        <td colspan="3" style="text-align: center" border="1"><asp:Label ID="lblRegularity" runat="server"></asp:Label></td>
                        <td colspan="6" align="center">GRADE: <u><asp:Label ID="lblGrade" runat="server"></asp:Label></u></td>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td colspan="5">2. Sincerity</td>
                        <td colspan="3" style="text-align: center"><asp:Label ID="lblSincerity" runat="server"></asp:Label></td>
                        <td colspan="6"></td>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td colspan="5">3. Behaviour</td>
                        <td colspan="3" style="text-align: center"><asp:Label ID="lblBehaviour" runat="server"></asp:Label></td>
                        <td colspan="6"></td>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td colspan="5">4. Attitude Towards Teachers</td>
                        <td colspan="3" style="text-align: center"><asp:Label ID="lblAttitudeTeachers" runat="server"></asp:Label></td>
                        <td colspan="6" align="center">RANK: <u><asp:Label ID="lblRank" runat="server"></asp:Label></u></td>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td colspan="5">5. Attitude Towards Students</td>
                        <td colspan="3" style="text-align: center"><asp:Label ID="lblAttitudeStudents" runat="server"></asp:Label></td>
                        <td colspan="6"></td>
                        <td colspan="2"></td>
                    </tr>
                </tbody>
            </table>
            <br />
            <br />
            <br />
            <br />
            <table style="width: 100%; height: 150px; border: 1px solid black;">
                <tr>
                    <td>&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Class Teacher's Remarks:
                        <asp:Label ID="lblRemarks" runat="server"></asp:Label></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
                <tr>
                    <td></td>
                </tr>
            </table>
            <span>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Place: 
            <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date:</span><span style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Signature of Class Teacher</span><span style="float: right; padding-right: 2em;">Signature of HOS</span>
            <br />
            <br />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
