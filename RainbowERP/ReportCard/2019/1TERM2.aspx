<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1TERM2.aspx.cs" Inherits="RainbowERP.ReportCard._2019._1TERM2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <style>
        table {
            border-collapse: collapse;
        }

        table, th, td {
            border: 1px solid black;
        }

        .strong {
            font-weight: bold;
        }

        .alignleft {
            float: left;
            text-align: left;
            width: 33.33333%;
        }

        .aligncenter {
            float: left;
            text-align: center;
            width: 33.33333%;
        }

        .alignright {
            float: left;
            text-align: right;
            width: 33.33333%;
        }

        .word-right {
            float: right;
            padding-right: 5em;
        }

        .word-left {
            text-align: left;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="border: 1px solid black;">
            <br />
            <asp:Image ID="imgLogo" runat="server" Width="100%" ImageUrl="logo.jpg" Style="padding-left: 50px;" />
            <p style="text-align: center"><b>ACHIEVEMENT RECORD (FINAL TERMINAL EXAMINATION)</b></p>
            <p style="text-align: center">SESSION 2019-20</p>
            <br />
            <table style="width: 100%; height: 150px;">
                <tr>
                    <td style="border: 0">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;<asp:Label ID="Label1" runat="server" Text="Student Name : "></asp:Label>
                        <asp:Label ID="lblStudentName" runat="server"></asp:Label><br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;<asp:Label ID="Label4" runat="server" Text="Admission No. :"></asp:Label>
                        <asp:Label ID="lblAdmissionNo" runat="server"></asp:Label><br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;Father's Name : 
                        <asp:Label ID="lblFatherName" runat="server"></asp:Label><br />
                        <br />
                    </td>
                    <td style="border: 0">&nbsp;</td>
                    <td style="border: 0">&nbsp;</td>
                    <td style="border: 0">&nbsp;</td>
                    <td style="border: 0">&nbsp;</td>
                    <td style="border: 0">&nbsp;</td>
                    <td style="border: 0">
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Class-Sec :"></asp:Label>
                        <asp:Label ID="lblClassSec" runat="server"></asp:Label>
                        <br />
                        <br />
                        Attendance :
                        <asp:Label ID="lblAttendance" runat="server"></asp:Label><br />
                        <br />
                        Mother's Name : 
                        <asp:Label ID="lblMotherName" runat="server"></asp:Label>
                        <br />
                    </td>
                </tr>
            </table>
            <br />
            <table width="100%" style="table-layout: fixed">
                <tbody>
                    <tr>
                        <td colspan="2" class="strong">
                            <p>
                                Scholastic Area
			
                            </p>
                        </td>
                        <td colspan="5" class="strong">
                            <p>
                                Term-1
			
                            </p>
                        </td>
                        <td colspan="5" class="strong">
                            <p>
                                Term-2
			
                            </p>
                        </td>
                        <td colspan="4" class="strong"?
                            <p>
                               OVERALL Term-1(50)+Term-2(50)
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="strong">
                            <p>
                                Subject Name
			
                            </p>
                        </td>
                        <td class="strong">
                            <p>
                                PT
			
                                (30)</p>
                        </td>
                        <td class="strong">
                            <p>
                                NS
			
                                (5)</p>
                        </td>
                        <td class="strong">
                            <p>
                                SEA
			
                                (5)</p>
                        </td>
                        <td class="strong">
                            <p>
                                Term-1
			
                                (60)</p>
                        </td>
                        <td class="strong">
                            <p>
                                Total
			
                                (100)</p>
                        </td>
                        <td class="strong">
                            <p>
                                PT
			
                                (30)</p>
                        </td>
                        <td class="strong">
                            <p>
                                NS
			
                                (5)</p>
                        </td>
                        <td class="strong">
                            <p>
                                SEA
			
                                (5)</p>
                        </td>
                        <td class="strong">
                            <p>
                                Term-2
			
                                (60)</p>
                        </td>
                        <td class="strong">
                            <p>
                                Total
			
                                (100)</p>
                        </td>
                        <td colspan="2" class="strong">
                            <p>
                                Grand Total
			
                            </p>
                        </td>
                        <td colspan="2" class="strong">
                            <p>
                                Grade
			
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" class="strong">
                            <p>
                                ENGLISH
			
                            </p>
                        </td>
                        <td style="text-align: center"><asp:Label ID="lblEnglishPT" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblEnglishNS" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblEnglishSEA" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblEnglishTerm1" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblEnglishTotalTerm1" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblEnglishPT2" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblEnglishNS2" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblEnglishSEA2" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblEnglishTerm2" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblEnglishTotalTerm2" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center"><asp:Label ID="lblEnglishTotal" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center"><asp:Label ID="lblEnglishGrade" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2" class="strong">
                            <p>
                                HINDI
			
                            </p>
                        </td>
                        <td style="text-align: center"><asp:Label ID="lblHindiPT" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblHindiNS" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblHindiSEA" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblHindiTerm1" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblHindiTotalTerm1" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblHindiPT2" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblHindiNS2" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblHindiSEA2" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblHindiTerm2" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblHindiTotalTerm2" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center"><asp:Label ID="lblHindiTotal" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center"><asp:Label ID="lblHindiGrade" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2" class="strong">
                            <p>
                                MATHEMATICS
			
                            </p>
                        </td>
                        <td style="text-align: center"><asp:Label ID="lblMathematicsPT" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblMathematicsNS" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblMathematicsSEA" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblMathematicsTerm1" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblMathematicsTotalTerm1" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblMathematicsPT2" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblMathematicsNS2" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblMathematicsSEA2" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblMathematicsTerm2" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblMathematicsTotalTerm2" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center"><asp:Label ID="lblMathematicsTotal" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center"><asp:Label ID="lblMathematicsGrade" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2" class="strong">
                            <p>
                                EVS
			
                            </p>
                        </td>
                        <td style="text-align: center"><asp:Label ID="lblEVSPT" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblEVSNS" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblEVSSEA" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblEVSTerm1" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblEVSTotalTerm1" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblEVSPT2" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblEVSNS2" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblEVSSEA2" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblEVSTerm2" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblEVSTotalTerm2" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center"><asp:Label ID="lblEVSTotal" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center"><asp:Label ID="lblEVSGrade" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="2" class="strong">
                            <p>
                                G.K./MSC
			
                            </p>
                        </td>
                        <td style="text-align: center"><asp:Label ID="lblGKPT" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblGKNS" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblGKSEA" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblGKTerm1" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblGKTotalTerm1" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblGKPT2" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblGKNS2" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblGKSEA2" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblGKTerm2" runat="server"></asp:Label></td>
                        <td style="text-align: center"><asp:Label ID="lblGKTotalTerm2" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center"><asp:Label ID="lblGKTotal" runat="server"></asp:Label></td>
                        <td colspan="2" style="text-align: center"><asp:Label ID="lblGKGrade" runat="server"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
            <%--<table style="width: 100%; height: 400px" border="1" cellspacing="0" cellpadding="0" align="center">
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
                        <td><strong>EVS</strong></td>
                        <td width="86" style="text-align: center">
                            <asp:Label ID="lblEVSPT" runat="server"></asp:Label></td>
                        <td width="102" style="text-align: center">
                            <asp:Label ID="lblEVSNS" runat="server"></asp:Label></td>
                        <td width="114" style="text-align: center">
                            <asp:Label ID="lblEVSSEA" runat="server"></asp:Label></td>
                        <td width="108" style="text-align: center">
                            <asp:Label ID="lblEVSTerm1" runat="server"></asp:Label></td>
                        <td width="132" style="text-align: center">
                            <asp:Label ID="lblEVSTotal" runat="server"></asp:Label></td>
                        <td width="103" style="text-align: center">
                            <asp:Label ID="lblEVSGrade" runat="server"></asp:Label></td>
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
            </table>--%>
             <br />
            <table width="100%" style="table-layout: fixed">
                <tbody>
                    <tr>
                        <td colspan="8" class="strong">
                            <p>
                                Co-Scholastic Areas [ on a 3 point (A-C) grading scale ]
			
                            </p>
                        </td>
                        <td colspan="2" class="strong" align="center">
                            <p>
                                Term-1
			
                            </p>
                        </td>
                        <td colspan="2" class="strong" align="center">
                            <p>
                                Term-2
			
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8" class="strong">
                            <p>
                                Work Education (or Pre-vocational Education)
			
                            </p>
                        </td>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblWorkEduTerm1" runat="server"></asp:Label></td>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblWorkEduTerm2" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="8" class="strong">
                            <p>
                                Art Education
			
                            </p>
                        </td>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblArtEduTerm1" runat="server"></asp:Label></td>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblArtEduTerm2" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="8" class="strong">
                            <p>
                                Health & Physical Education
			
                            </p>
                        </td>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblPhysicalEduTerm1" runat="server"></asp:Label></td>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblPhysicalEduTerm2" runat="server"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
            </br>
            <table width="100%" style="table-layout: fixed">
                <tbody>
                    <tr class="strong">
                        <td colspan="8">
                            <p>
                                Discipline [ on a 3 point (A-C) grading scale ]
			
                            </p>
                        </td>
                        <td colspan="2" align="center">
                            <p>
                                Term-1
			
                            </p>
                        </td>
                        <td colspan="2" align="center">
                            <p>
                                Term-2
			
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="8">
                            <p>
                                1. Regularity and Punctuality
			
                            </p>
                        </td>
                        <td colspan="2" align="center"><asp:Label ID="lblRegularityTerm1" runat="server"></asp:Label></td>
                        <td colspan="2" align="center"><asp:Label ID="lblRegularityTerm2" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="8">
                            <p>
                                2. Sincerity
			
                            </p>
                        </td>
                        <td colspan="2" align="center"><asp:Label ID="lblSincerityTerm1" runat="server"></asp:Label></td>
                        <td colspan="2" align="center"><asp:Label ID="lblSincerityTerm2" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="8">
                            <p>
                                3. Behaviour
			
                            </p>
                        </td>
                        <td colspan="2" align="center"><asp:Label ID="lblBehaviourTerm1" runat="server"></asp:Label></td>
                        <td colspan="2" align="center"><asp:Label ID="lblBehaviourTerm2" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="8">
                            <p>
                                4. Attitude towards Teachers
			
                            </p>
                        </td>
                        <td colspan="2" align="center"><asp:Label ID="lblAttitudeTeachersTerm1" runat="server"></asp:Label></td>
                        <td colspan="2" align="center"><asp:Label ID="lblAttitudeTeachersTerm2" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td colspan="8">
                            <p>
                                5. Attitude towards Students
			
                            </p>
                        </td>
                        <td colspan="2" align="center"><asp:Label ID="lblAttitudeStudentsTerm1" runat="server"></asp:Label></td>
                        <td colspan="2" align="center"><asp:Label ID="lblAttitudeStudentsTerm2" runat="server"></asp:Label></td>
                    </tr>
                </tbody>
            </table>
             <p class="word-left">
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GRADE : <u><asp:Label ID="lblGrade" runat="server"></asp:Label></u><span class="word-right">RANK : <u><asp:Label ID="lblRank" runat="server"></asp:Label></u></span>
            </p>
            <table width="100%" height="100px">
                <tbody>
                    <tr>
                        <td width="698">
                            <p>
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Class Teacher's Remarks :
                                <asp:Label ID="lblRemarks" runat="server"></asp:Label>
                        </td>

                        </p>
                        </td>
                    </tr>
                </tbody>
            </table>
            <%--<table style="width: 100%; height: 250px;" border="1" cellspacing="0" cellpadding="0" align="center">
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
            </table>--%>            <%--<br />
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
                        <td colspan="3" style="text-align: center" border="1">
                            <asp:Label ID="lblRegularity" runat="server"></asp:Label></td>
                        <td colspan="6" align="center">GRADE: <u>
                            <asp:Label ID="lblGrade" runat="server"></asp:Label></u></td>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td colspan="5">2. Sincerity</td>
                        <td colspan="3" style="text-align: center">
                            <asp:Label ID="lblSincerity" runat="server"></asp:Label></td>
                        <td colspan="6"></td>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td colspan="5">3. Behaviour</td>
                        <td colspan="3" style="text-align: center">
                            <asp:Label ID="lblBehaviour" runat="server"></asp:Label></td>
                        <td colspan="6"></td>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td colspan="5">4. Attitude Towards Teachers</td>
                        <td colspan="3" style="text-align: center">
                            <asp:Label ID="lblAttitudeTeachers" runat="server"></asp:Label></td>
                        <td colspan="6" align="center">RANK: <u>
                            <asp:Label ID="lblRank" runat="server"></asp:Label></u></td>
                        <td colspan="2"></td>
                    </tr>
                    <tr>
                        <td colspan="5">5. Attitude Towards Students</td>
                        <td colspan="3" style="text-align: center">
                            <asp:Label ID="lblAttitudeStudents" runat="server"></asp:Label></td>
                        <td colspan="6"></td>
                        <td colspan="2"></td>
                    </tr>
                </tbody>
            </table>--%>
            <br />
            <br />
            <%--<table style="width: 100%; height: 150px; border: 1px solid black;">
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
            </table>--%>
            <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Place: 
                <br />
                <p class="alignleft">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Date: </p>
                <p class="aligncenter">Signature of Class Teacher:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
                <p class="alignright">Principal's Signature&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
            </p>
            <br /><br /><br />
            <%-- &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Date:</span><span style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Signature of Class Teacher</span><span style="float: right; padding-right: 2em;">Signature of HOS</span>
            
        </div> --%>
        </div>
    </form>
</body>
</html>
