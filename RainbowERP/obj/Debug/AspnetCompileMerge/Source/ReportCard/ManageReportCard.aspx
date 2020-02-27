<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true" CodeBehind="ManageReportCard.aspx.cs" Inherits="RAINBOW_ERP.ReportCard.ManageReportCard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">    
            <span style="float: left;">&nbsp;&nbsp;&nbsp; Student Class</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlClass" runat="server" Width="149px" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
            </asp:DropDownList>
            <span style="float: left;">&nbsp;&nbsp;&nbsp; Examination</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlExamination" runat="server" Width="149px">
            </asp:DropDownList>
            <br />
            <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ValidationGroup="Required" Text="Print" />
            <br />
            <br />
            <br />
            <br />
            <asp:GridView ID="grdMarksReport" runat="server" BorderColor="Black" Width="100%" Height="850px" BorderStyle="Solid" RowStyle-BorderColor="Black" RowStyle-BorderStyle="Solid">

            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="#ffffff" />
            <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1" BackColor="#3AB4E8" Font-Bold="True" ForeColor="#000000" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1" BackColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            </asp:GridView>
</asp:Content>
