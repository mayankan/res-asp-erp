<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrintStudentFromClass.aspx.cs" Inherits="RAINBOW_ERP.ReportCard.PrintReportCard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
            <span style="float: left;">&nbsp;&nbsp;&nbsp; Student Class</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlClass" runat="server" Width="149px">
            </asp:DropDownList>
            <br />
            <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ValidationGroup="Required" Text="Print" />
            <br />
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblOutput" runat="server" Text="Label"></asp:Label>
    </div>
    </form>
</body>
</html>
