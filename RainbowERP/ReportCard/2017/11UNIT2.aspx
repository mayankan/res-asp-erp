<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="11UNIT2.aspx.cs" Inherits="RAINBOW_ERP.ReportCard.Out._11UNIT2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            font-size: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Image ID="imgLogo" runat="server" Width="100%" />
            <p style="text-align: center">SESSION 2017-18</p>
            <br />
            <table style="width: 100%; height: 200px; border: 1px solid black;">
                <tr>
                    <td>&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" Text="Student Name : "></asp:Label>
                        <asp:Label ID="lblStudentName" runat="server"></asp:Label><br />
                        <br />
                        &nbsp;&nbsp;<asp:Label ID="Label2" runat="server" Text="Father's Name : "></asp:Label>
                        <asp:Label ID="lblFatherName" runat="server"></asp:Label><br />
                        <br />
                        &nbsp;&nbsp;<asp:Label ID="Label10" runat="server" Text="Mother's Name : "></asp:Label>
                        <asp:Label ID="lblMotherName" runat="server"></asp:Label><br />
                        <br />
                        &nbsp;&nbsp;<asp:Label ID="Label3" runat="server" Text="Examination : "></asp:Label>
                        <asp:Label ID="lblExamination" runat="server"></asp:Label><br />
                        <br />
                    </td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Admission No. :"></asp:Label>
                        <asp:Label ID="lblAdmissionNo" runat="server"></asp:Label><br />
                        <br />
                        <asp:Label ID="Label5" runat="server" Text="Class-Sec :"></asp:Label>
                        <asp:Label ID="lblClassSec" runat="server"></asp:Label><br />
                        <br />
                        <asp:Label ID="Label6" runat="server" Text="Attendance :"></asp:Label>
                        <br />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:GridView ID="grdMarksReport" runat="server" BorderColor="Black" Width="100%" Height="850px" BorderStyle="Solid" RowStyle-BorderColor="Black" RowStyle-BorderStyle="Solid">
                <RowStyle HorizontalAlign="Center" />
                <AlternatingRowStyle HorizontalAlign="Center" />
            </asp:GridView>
            <br />
            <br />
            <table style="width: 30%; height: 150px; float: right; border: 1px solid black;">
                <tr>
                    <td>
                        <p style="text-align: center">Grand Total:-<asp:Label ID="lblGrandTotal" runat="server"></asp:Label></p>
                    </td>
                    <td>
                        <p style="text-align: center"></p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p style="text-align: center">Percentage:-<asp:Label ID="lblPercentage" runat="server"></asp:Label></p>
                    </td>
                    <td>
                        <p style="text-align: center"></p>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <strong>
            <br />
            <br />
            <br />
            <br />
            Personal Assessment Record and Remarks</strong>
            <table style="width: 100%; height: 500px" border="1" cellspacing="0" cellpadding="0" align="center">
                <tbody>
                    <tr>
                        <td colspan="1"><strong>&nbsp;&nbsp;S. No.</strong></td>
                        <td colspan="5"><strong>&nbsp;&nbsp;Traits</strong></td>
                        <td colspan="2" style="text-align: center"><strong>Grade</strong></td>
                    </tr>
                    <tr>
                        <td colspan="1"><strong>&nbsp;&nbsp;1</strong></td>
                        <td colspan="5" width="645"><strong>&nbsp;&nbsp;Punctuality/Regularity</strong></td>
                        <td colspan="2" style="text-align: center"><strong>
                            <asp:Label ID="lblPunctuality" runat="server"></asp:Label></strong></td>
                    </tr>
                    <tr>
                        <td colspan="1"><strong>&nbsp;&nbsp;2</strong></td>
                        <td colspan="5" width="645"><strong>&nbsp;&nbsp;Discipline</strong></td>
                        <td colspan="2" style="text-align: center"><strong>
                            <asp:Label ID="lblDiscipline" runat="server"></asp:Label></strong></td>
                    </tr>
                    <tr>
                        <td colspan="1"><strong></strong></td>
                        <td colspan="5" width="645"><strong>&nbsp;&nbsp;Value System</strong></td>
                        <td colspan="2" style="text-align: center"><strong></strong></td>
                    </tr>
                    <tr>
                        <td colspan="1"><strong>&nbsp;&nbsp;A.</strong></td>
                        <td colspan="5"><strong>&nbsp;&nbsp;Respect to Opposite Gender</strong></td>
                        <td colspan="2" style="text-align: center;"><strong>
                            <asp:Label ID="lblOppGender" runat="server"></asp:Label></strong></td>
                    </tr>
                    <tr>
                        <td colspan="1"><strong>&nbsp;&nbsp;B.</strong></td>
                        <td colspan="5" width="645"><strong>&nbsp;&nbsp;Attitude towards Class Mates</strong></td>
                        <td colspan="2" style="text-align: center"><strong>
                            <asp:Label ID="lblClassMates" runat="server"></asp:Label></strong></td>
                    </tr>
                    <tr>
                        <td colspan="1"><strong>&nbsp;&nbsp;C.</strong></td>
                        <td colspan="5" width="645"><strong>&nbsp;&nbsp;Attitude towards Teachers</strong></td>
                        <td colspan="2" style="text-align: center"><strong>
                            <asp:Label ID="lblTeachers" runat="server"></asp:Label></strong></td>
                    </tr>
                </tbody>
            </table>
            <br />
            <br />
            <br />
            <br />
            <table style="width: 100%; height: 150px; border: 1px solid black;">
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Remarks:</td>
                </tr>
            </table>
            <span>
                <br />
                <br />
                <br />
                <br />
                <br />
                Class Teacher Signature</span><span style="text-align: center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Parent's Signature</span><span style="float: right">HOS Signature</span>
        </div>
    </form>
</body>
</html>
