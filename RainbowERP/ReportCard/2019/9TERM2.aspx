<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="9TERM2.aspx.cs" Inherits="RainbowERP.ReportCard._2019._9TERM2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="border: 1px solid black;">
            <br />
            <asp:Image ID="imgLogo" runat="server" ImageUrl="logo.jpg" Width="90%" Style="padding-left: 50px;" />
            <p style="text-align: center"><b>REPORT CARD</b></p>
            <p style="text-align: center">CLASS : IX</p>
            <p style="text-align: center">SESSION 2019-20</p>
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
                        <td><strong>Subject Name</strong></td>
                        <td><strong>Avg of </strong></br>
                            <strong>Best 2 PT<br />
                                (5)</strong></td>
                        <td><strong>MA </strong>
                            <strong>(5)</strong></td>
                        <td><strong>SEA </strong>
                            <strong>(5)</strong></td>
                        <td><strong>Portfolio </strong>
                            <strong>(5)</strong></td>
                        <td><strong>Term-1 (80)</strong></td>
                        <td><strong>Marks Obtained (100)</strong></td>
                        <td><strong>Grade</strong></td>
                    </tr>
                    <tr>
                        <td><strong>ENGLISH</strong></td>
                        <td width="86" style="text-align: center">
                            <asp:Label ID="lblEnglishPT" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblEnglishMA" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center">
                            <asp:Label ID="lblEnglishSEA" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblEnglishPortfolio" runat="server"></asp:Label></td>
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
                            <asp:Label ID="lblHindiMA" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center">
                            <asp:Label ID="lblHindiSEA" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblHindiPortfolio" runat="server"></asp:Label></td>
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
                            <asp:Label ID="lblMathematicsMA" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center">
                            <asp:Label ID="lblMathematicsSEA" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblMathematicsPortfolio" runat="server"></asp:Label></td>
                        <td width="108" style="text-align: center">
                            <asp:Label ID="lblMathematicsTerm1" runat="server"></asp:Label></td>
                        <td width="132" style="text-align: center">
                            <asp:Label ID="lblMathematicsTotal" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblMathematicsGrade" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>SCIENCE</strong></td>
                        <td width="86" style="text-align: center">
                            <asp:Label ID="lblSciencePT" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblScienceMA" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center">
                            <asp:Label ID="lblScienceSEA" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblSciencePortfolio" runat="server"></asp:Label></td>
                        <td width="108" style="text-align: center">
                            <asp:Label ID="lblScienceTerm1" runat="server"></asp:Label></td>
                        <td width="132" style="text-align: center">
                            <asp:Label ID="lblScienceTotal" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblScienceGrade" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td><strong>SOCIAL SCIENCE</strong></td>
                        <td width="86" style="text-align: center">
                            <asp:Label ID="lblSocialSciencePT" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblSocialScienceMA" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center">
                            <asp:Label ID="lblSocialScienceSEA" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblSocialSciencePortolio" runat="server"></asp:Label></td>
                        <td width="108" style="text-align: center">
                            <asp:Label ID="lblSocialScienceTerm1" runat="server"></asp:Label></td>
                        <td width="132" style="text-align: center">
                            <asp:Label ID="lblSocialScienceTotal" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblSocialScienceGrade" runat="server"></asp:Label></td>
                    </tr>
                    <tr style="border: 1px solid black;">
                        <td><strong>Subject Name</strong></td>
                        <td colspan="3"><strong>Theory (50)</strong></td>
                        <td colspan="2"><strong>Practical (50)</strong></td>
                        <td><strong>Marks Obtained (100)</strong></td>
                        <td><strong>Grade</strong></td>
                    </tr>
                    <tr>
                        <td><strong>I.T.</strong></td>
                        <td colspan="3" width="86" style="text-align: center">
                            <asp:Label ID="lblITTheory" runat="server"></asp:Label></td>
                        <td colspan="2" width="108" style="text-align: center">
                            <asp:Label ID="lblITPractical" runat="server"></asp:Label></td>
                        <td width="132" style="text-align: center">
                            <asp:Label ID="lblITTotal" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblITGrade" runat="server"></asp:Label></td>
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
                                        <td>Grade</td>
                                        <td>
                                            <asp:Label ID="lblGrade" runat="server"></asp:Label></td>
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
                                        <td>Grand Total</td>
                                        <td>
                                            <asp:Label ID="lblGrandTotal" runat="server"></asp:Label></td>
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
