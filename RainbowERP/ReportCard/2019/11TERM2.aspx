﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="11TERM2.aspx.cs" Inherits="RainbowERP.ReportCard._2019._11TERM2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            font-size: 40px;
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
        th { font-size: 40px; }
        td { font-size: 40px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <br />
            <asp:Image ID="imgLogo" runat="server" Width="100%" ImageUrl="logo.jpg" />
            <p style="text-align: center"><b>REPORT CARD</b></p>
            <p style="text-align: center">SESSION 2019-20</p>
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
                        <asp:Label ID="lblExamination" runat="server">Annual Examination (Grand Result)</asp:Label><br />
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
                        <asp:Label ID="lblAttendance" runat="server"></asp:Label><br />
                        <br />
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <asp:GridView ID="grdMarksReport" runat="server" BorderColor="Black" Width="100%" Height="1000px" BorderStyle="Solid" RowStyle-BorderColor="Black" RowStyle-BorderStyle="Solid">
                <RowStyle HorizontalAlign="Center" />
                <AlternatingRowStyle HorizontalAlign="Center" />
            </asp:GridView>
            <br />
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
            <br />
            <br />
            <br />
            <br />
            <br />
            <table style="width: 100%; height: 100px" border="1">
                <tr>
                    <td>
                        <p>S. No.</p>
                    </td>
                    <td>
                        <p>TRAITS</p>
                    </td>
                    <td>
                        <p>Grade</p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 1.</p>
                    </td>
                    <td>
                        <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Punctuality & Regularity</p>
                    </td>
                    <td>
                        <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblPunctuality" runat="server"></asp:Label></p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 2.</p>
                    </td>
                    <td>
                        <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Discipline</p>
                    </td>
                    <td>
                        <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblDiscipline" runat="server"></asp:Label></p>
                    </td>
                </tr>
                <tr>
                    <td>
                        <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 3.</p>
                    </td>
                    <td>
                        <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Value System and Attitude</p>
                    </td>
                    <td>
                        <p>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Label ID="lblValueSystem" runat="server"></asp:Label></p>
                    </td>
                </tr>
            </table>
            <br />
            <br />
            <br />
            <table style="width: 100%; height: 200px; border: 1px solid black;">
                <tr>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Class Teacher's Remarks:
                        <asp:Label ID="lblRemarks" runat="server"></asp:Label></td>
                </tr>
            </table>
            <span>
                <br />
                <br />
                &nbsp;&nbsp;&nbsp;&nbsp; * - Total &amp; Weightage Marks<br />
                <p>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Place: 
                <br />
                <p class="alignleft">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Date: </p>
                <p class="aligncenter">Signature of Class Teacher:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </p>
                <p class="alignright">Principal's Signature&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</p>
            </p>
            <br /><br /><br />
    </div>
    </form>
</body>
</html>
