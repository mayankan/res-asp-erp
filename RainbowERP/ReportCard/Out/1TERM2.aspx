<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="1TERM2.aspx.cs" Inherits="RAINBOW_ERP.ReportCard.Out._1TERM2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        th, td {
            text-align: center;
            font-family: Arial;
            font: bold;
            padding-top: 0px;
            padding-bottom: 0px;
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
            <table style="width: 100%; height: 150px;">
                <tr>
                    <td style="text-align:left">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Student Name : 
                        <asp:Label ID="lblStudentName" runat="server"></asp:Label><br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Father's Name : 
                        <asp:Label ID="lblFatherName" runat="server"></asp:Label><br />
                        <br />
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        Mother's Name : 
                        <asp:Label ID="lblMotherName" runat="server"></asp:Label>
                        <br />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td style="text-align:left">
                        <br />
                        <asp:Label ID="Label4" runat="server" Text="Admission No. :"></asp:Label>
                        <asp:Label ID="lblAdmissionNo" runat="server"></asp:Label><br />
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Class-Sec :"></asp:Label>
                        <asp:Label ID="lblClassSec" runat="server"></asp:Label>
                    </td>
                </tr>
            </table>
            </br>
            <table style="width: 100%; height: 1200px" border="1" cellspacing="0" cellpadding="0" align="center">
                <tbody>
                    <tr>
                        <td colspan="3">
                            <p><strong>A. </strong><strong>Language</strong></p>
                        </td>
                        <td>
                            <p><center><strong>Term 1</strong></center></p>
                        </td>
                        <td>
                            <p><center><strong>Term 2</strong></center></p>
                        </td>
                        <td rowspan="29">
                            <p></p>
                        </td>
                        <td colspan="5">
                            <p><strong>C. Environmental Science</strong></p>
                        </td>
                        <td>
                            <p><center><strong>Term 1</strong></center></p>
                        </td>
                        <td>
                            <p><center><strong>Term 2</strong></center></p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <p><strong>English</strong></p>
                        </td>
                        <td colspan="3">
                            <p><strong>Aspects:</strong></p>
                        </td>
                        <td colspan="2" rowspan="2">
                            <p><strong>Environmental Sensitivity</strong></p>
                            <p><strong>Activity/ Project</strong></p>
                            <p><strong>Group Discussion</strong></p>
                            <p><strong>Written Work</strong></p>
                        </td>
                        <td rowspan="2">
                            <p><center><asp:Label ID="lblEnvironmentalStudiesTerm1" runat="server"></asp:Label></center></p>
                            <p><center><asp:Label ID="lblEnvironmentalActivityTerm1" runat="server"></asp:Label></center></p>
                            <p><center><asp:Label ID="lblEnvironmentalGDTerm1" runat="server"></asp:Label></center></p>
                            <p><center><asp:Label ID="lblEnvironmentalWrittenWorkTerm1" runat="server"></asp:Label></center></p>
                        </td>
                        <td rowspan="2">
                            <p><center><asp:Label ID="lblEnvironmentalStudiesTerm2" runat="server"></asp:Label></center></p>
                            <p><center><asp:Label ID="lblEnvironmentalActivityTerm2" runat="server"></asp:Label></center></p>
                            <p><center><asp:Label ID="lblEnvironmentalGDTerm2" runat="server"></asp:Label></center></p>
                            <p><center><asp:Label ID="lblEnvironmentalWrittenWorkTerm2" runat="server"></asp:Label></center></p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p><strong>1</strong></p>
                        </td>
                        <td>
                            <p><strong>Reading Skills</strong></p>
                        </td>
                        <td>
                            <p><strong>Pronunciation</strong></p>
                            <p><strong>Fluency</strong></p>
                            <p><strong>Comprehension</strong></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblEnglishReadingTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblEnglishReadingTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td colspan="2">
                            <p></p>
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="2">
                            <p><strong>2</strong></p>
                        </td>
                        <td rowspan="2">
                            <p><strong>Writing Skills</strong></p>
                        </td>
                        <td rowspan="2">
                            <p><strong>Creative Writing</strong></p>
                            <p><strong>Handwriting</strong></p>
                            <p><strong>Grammar</strong></p>
                            <p><strong>Spellings</strong></p>
                            <p><strong>Vocabulary</strong></p>
                        </td>
                        <td rowspan="2">
                            <p>
                                <asp:Label ID="lblEnglishWritingTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td rowspan="2">
                            <p>
                                <asp:Label ID="lblEnglishWritingTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td colspan="5">
                            <p><strong>D. Science </strong></p>
                        </td>
                        <td>
                            <p></p>
                        </td>
                        <td>
                            <p></p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <p><strong>Aspects:</strong></p>
                        </td>
                        <td colspan="2">
                            <p><strong>Concept</strong></p>
                            <p><strong>Activity/ Project</strong></p>
                            <p><strong>Scientific Skills</strong></p>
                            <p><strong>Group Discussion</strong></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblScienceConceptTerm1" runat="server"></asp:Label>
                            </p>
                            <p>
                                <asp:Label ID="lblScienceActivityTerm1" runat="server"></asp:Label>
                            </p>
                            <p>
                                <asp:Label ID="lblScienceScientificTerm1" runat="server"></asp:Label>
                            </p>
                            <p>
                                <asp:Label ID="lblScienceGDTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblScienceConceptTerm2" runat="server"></asp:Label>
                            </p>
                            <p>
                                <asp:Label ID="lblScienceActivityTerm2" runat="server"></asp:Label>
                            </p>
                            <p>
                                <asp:Label ID="lblScienceScientificTerm2" runat="server"></asp:Label>
                            </p>
                            <p>
                                <asp:Label ID="lblScienceGDTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="2">
                            <p><strong>3</strong></p>
                        </td>
                        <td rowspan="2">
                            <p><strong>Speaking Skills</strong></p>
                        </td>
                        <td rowspan="2">
                            <p><strong>Conversation</strong></p>
                            <p><strong>Recitation</strong></p>
                        </td>
                        <td rowspan="2">
                            <p>
                                <asp:Label ID="lblEnglishSpeakingTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td rowspan="2">
                            <p>
                                <asp:Label ID="lblEnglishSpeakingTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td colspan="6">
                            <p><strong>E. Computer</strong></p>
                        </td>
                        <td>
                            <p></p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" rowspan="2">
                            <p><strong>Aspects:</strong></p>
                        </td>
                        <td colspan="2" rowspan="2">
                            <p><strong>Skills</strong></p>
                            <p><strong>Aptitude</strong></p>
                        </td>
                        <td rowspan="2">
                            <p>
                                <asp:Label ID="lblComputerTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td rowspan="2">
                            <p>
                                <asp:Label ID="lblComputerTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="2">
                            <p><strong>4</strong></p>
                        </td>
                        <td rowspan="2">
                            <p><strong>Listening Skills</strong></p>
                        </td>
                        <td rowspan="2">
                            <p><strong>Comprehension</strong></p>
                        </td>
                        <td rowspan="2">
                            <p>
                                <asp:Label ID="lblEnglishListeningTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td rowspan="2">
                            <p>
                                <asp:Label ID="lblEnglishListeningTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <p><strong>F. Co- Curricular Activities</strong></p>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <p><strong>5</strong></p>
                        </td>
                        <td colspan="2">
                            <p><strong>Extra Reading</strong></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblEnglishExtraReadingTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblEnglishExtraReadingTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p><strong>1.</strong></p>
                        </td>
                        <td colspan="2">
                            <p><strong>Games</strong></p>
                        </td>
                        <td colspan="2">
                            <p><strong>Enthusiasm</strong></p>
                        </td>
                        <td rowspan="4">
                            <p>
                                <asp:Label ID="lblGamesTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td rowspan="4">
                            <p>
                                <asp:Label ID="lblGamesTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p><strong>6</strong></p>
                        </td>
                        <td colspan="2">
                            <p><strong>Activity/ Project</strong></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblEnglishActivityTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblEnglishActivityTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p></p>
                        </td>
                        <td colspan="2">
                            <p></p>
                        </td>
                        <td colspan="2">
                            <p><strong>Discipline</strong></p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <p><strong>Hindi/ Mother Tongue</strong></p>
                        </td>
                        <td>
                            <p></p>
                        </td>
                        <td colspan="2">
                            <p></p>
                        </td>
                        <td colspan="2">
                            <p><strong>Team Spirit</strong></p>
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="2">
                            <p><strong>1</strong></p>
                        </td>
                        <td rowspan="2">
                            <p><strong>Reading Skills</strong></p>
                        </td>
                        <td rowspan="2">
                            <p><strong>Pronunciation</strong></p>
                            <p><strong>Fluency</strong></p>
                            <p><strong>Comprehension</strong></p>
                        </td>
                        <td rowspan="2">
                            <p>
                                <asp:Label ID="lblHindiReadingTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td rowspan="2">
                            <p>
                                <asp:Label ID="lblHindiReadingTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p></p>
                        </td>
                        <td colspan="2">
                            <p></p>
                        </td>
                        <td colspan="2">
                            <p><strong>Talent</strong></p>
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="2">
                            <p><strong>2.</strong></p>
                        </td>
                        <td colspan="2" rowspan="2">
                            <p><strong>Art/ Craft</strong></p>
                        </td>
                        <td colspan="2" rowspan="2">
                            <p><strong>Interest</strong></p>
                            <p><strong>Creativity</strong></p>
                            <p><strong>Skills</strong></p>
                        </td>
                        <td rowspan="2">
                            <p>
                                <asp:Label ID="lblArtTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td rowspan="2">
                            <p>
                                <asp:Label ID="lblArtTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="3">
                            <p><strong>2</strong></p>
                        </td>
                        <td rowspan="3">
                            <p><strong>Writing Skills</strong></p>
                        </td>
                        <td rowspan="3">
                            <p><strong>Creative Writing</strong></p>
                            <p><strong>Handwriting</strong></p>
                            <p><strong>Grammar</strong></p>
                            <p><strong>Spellings</strong></p>
                            <p><strong>Vocabulary</strong></p>
                        </td>
                        <td rowspan="3">
                            <p>
                                <asp:Label ID="lblHindiWritingTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td rowspan="3">
                            <p>
                                <asp:Label ID="lblHindiWritingTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p><strong>3.</strong></p>
                        </td>
                        <td colspan="2">
                            <p><strong>Music/</strong></p>
                            <p><strong>Dance</strong></p>
                        </td>
                        <td colspan="2">
                            <p><strong>Interest</strong></p>
                            <p><strong>Rhythm</strong></p>
                            <p><strong>Melody</strong></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblMusicTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblMusicTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <p><strong>G. General Knowledge &amp; Moral Education</strong></p>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <p><strong>3</strong></p>
                        </td>
                        <td>
                            <p><strong>Speaking Skills</strong></p>
                        </td>
                        <td>
                            <p><strong>Conversation</strong></p>
                            <p><strong>Recitation</strong></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblHindiSpeakingTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblHindiSpeakingTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td colspan="5">
                            <p></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblGKTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblGKTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td rowspan="2">
                            <p><strong>4</strong></p>
                        </td>
                        <td rowspan="2">
                            <p><strong>Listening Skills</strong></p>
                        </td>
                        <td rowspan="2">
                            <p><strong>Comprehension</strong></p>
                        </td>
                        <td rowspan="2">
                            <p>
                                <asp:Label ID="lblHindiListeningTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td rowspan="2">
                            <p>
                                <asp:Label ID="lblHindiListeningTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td colspan="5">
                            <p><strong>Personality Development</strong></p>
                        </td>
                        <td></td>
                        <td></td>
                    </tr>
                    <tr>
                        <td>
                            <p><strong>1</strong></p>
                        </td>
                        <td colspan="4">
                            <p><strong>Courteousness</strong></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblCourteousnessTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblCourteousnessTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p><strong>5</strong></p>
                        </td>
                        <td colspan="2">
                            <p><strong>Extra Reading</strong></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblHindiExtraReadingTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblHindiExtraReadingTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p><strong>2</strong></p>
                        </td>
                        <td colspan="4">
                            <p><strong>Confidence</strong></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblConfidenceTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblConfidenceTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5">
                            <p><strong>B. </strong><strong>Mathematics</strong></p>
                        </td>
                        <td>
                            <p><strong>3</strong></p>
                        </td>
                        <td colspan="4">
                            <p><strong>Care of belongings</strong></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblCOBTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblCOBTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" rowspan="4">
                            <p></p>
                            <p></p>
                            <p><strong>Aspects</strong></p>
                        </td>
                        <td rowspan="4">
                            <p><strong>Concept</strong></p>
                            <p><strong>Activity</strong></p>
                            <p><strong>Tables</strong></p>
                            <p><strong>Mental Ability</strong></p>
                            <p><strong>Written Work</strong></p>
                        </td>
                        <td rowspan="4">
                            <p>
                                <asp:Label ID="lblMathematicsConceptTerm1" runat="server"></asp:Label>
                            </p>
                            <p>
                                <asp:Label ID="lblMathematicsActivityTerm1" runat="server"></asp:Label>
                            </p>
                            <p>
                                <asp:Label ID="lblMathematicsTablesTerm1" runat="server"></asp:Label>
                            </p>
                            <p>
                                <asp:Label ID="lblMathematicsMentalAbilityTerm1" runat="server"></asp:Label>
                            </p>
                            <p>
                                <asp:Label ID="lblMathematicsWrittenWorkTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td rowspan="4">
                            <p>
                                <asp:Label ID="lblMathematicsConceptTerm2" runat="server"></asp:Label>
                            </p>
                            <p>
                                <asp:Label ID="lblMathematicsActivityTerm2" runat="server"></asp:Label>
                            </p>
                            <p>
                                <asp:Label ID="lblMathematicsTablesTerm2" runat="server"></asp:Label>
                            </p>
                            <p>
                                <asp:Label ID="lblMathematicsMentalAbilityTerm2" runat="server"></asp:Label>
                            </p>
                            <p>
                                <asp:Label ID="lblMathematicsWrittenWorkTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p><strong>4</strong></p>
                        </td>
                        <td colspan="4">
                            <p><strong>Neatness</strong></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblNeatnessTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblNeatnessTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p><strong>5</strong></p>
                        </td>
                        <td colspan="4">
                            <p><strong>Regularity/ Punctuality</strong></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblRegularityTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblRegularityTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p><strong>6</strong></p>
                        </td>
                        <td colspan="4">
                            <p><strong>Initiative</strong></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblInitiativeTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblInitiativeTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p><strong>7</strong></p>
                        </td>
                        <td colspan="4">
                            <p><strong>Sharing/ Caring</strong></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblSharingTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblSharingTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="5" rowspan="3">
                            <p><strong></strong></p>
                            <table>
                                <tbody>
                                    <tr>
                                        <td>
                                            <p><strong>Attendance</strong></p>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <p>
                        <asp:Label ID="lblAttendance" runat="server"></asp:Label></p>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                        <td>
                            <p><strong>8</strong></p>
                        </td>
                        <td colspan="4">
                            <p><strong>Respect to others property</strong></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblRespectTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblRespectTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p><strong>9</strong></p>
                        </td>
                        <td colspan="4">
                            <p><strong>Self-Control</strong></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblSelfControlTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblSelfControlTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <p><strong>10</strong></p>
                        </td>
                        <td colspan="4">
                            <p><strong>Spirit of Service</strong></p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblSOSTerm1" runat="server"></asp:Label>
                            </p>
                        </td>
                        <td>
                            <p>
                                <asp:Label ID="lblSOSTerm2" runat="server"></asp:Label>
                            </p>
                        </td>
                    </tr>
                </tbody>
            </table>
            <br />
            <table width="100%">
                <tr>
                    <td>
                        <table style="width: 90%; height: 100px; border: 1px solid black;" align="center">
                            <tr>
                                <td>&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>General Remarks:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblGeneralRemarks" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table style="width: 90%; height: 100px; border: 1px solid black;" align="center">
                            <tr>
                                <td>&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <strong>Specefic Remarks:</strong>&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="lblSpecificRemarks" runat="server"></asp:Label></td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td></td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
            <span>
                <br />
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span><span style="text-align: center"><br />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Parent&#39;s Signature&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Signature of Class Teacher</span><span style="float: right; padding-right: 2em;">Signature of HOS</span>
            <br />
            <br />
        </div>
    </form>
</body>
</html>
