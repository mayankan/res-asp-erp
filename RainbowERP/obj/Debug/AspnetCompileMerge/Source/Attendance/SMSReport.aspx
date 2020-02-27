<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true" CodeBehind="SMSReport.aspx.cs" Inherits="RAINBOW_ERP.Attendance.SMSReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Header -->
    <header id="header">
        <a href="index.aspx" class="logo"><strong>SMS Entry</strong></a>        <%--<ul class="icons">
										<li><a href="#" class="icon fa-twitter"><span class="label">Twitter</span></a></li>
										<li><a href="#" class="icon fa-facebook"><span class="label">Facebook</span></a></li>
										<li><a href="#" class="icon fa-snapchat-ghost"><span class="label">Snapchat</span></a></li>
										<li><a href="#" class="icon fa-instagram"><span class="label">Instagram</span></a></li>
										<li><a href="#" class="icon fa-medium"><span class="label">Medium</span></a></li>
									</ul>--%>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnLogout" runat="server" OnClick="btnLogout_Click" Text="Logout" />
    </header>
    <!-- Section -->
    <section>
        Date From :
    <asp:TextBox ID="txtDateFrom" runat="server" TextMode="Date"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    Date To :
    <asp:TextBox ID="txtDateTo" runat="server" TextMode="Date"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    Class :
    <asp:DropDownList ID="ddlClass" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    Student Leave Type :
    <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:GridView ID="grdStudent" DataKeyNames="studentId" AutoGenerateColumns="False" runat="server" CellPadding="0" GridLines="None" EmptyDataText="No data available." OnRowDataBound="grdStudent_RowDataBound" Width="100%" AllowSorting="true" OnSorting="grdStudent_Sorting">
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="S. No." ItemStyle-Width="100">
                        <ItemTemplate>
                            <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                        </ItemTemplate>

                        <ItemStyle Width="100px"></ItemStyle>
                    </asp:TemplateField>
                    <asp:BoundField DataField="admissionNo" HeaderText="Admission Number" SortExpression="admissionNo" />
                    <asp:BoundField DataField="studentName" HeaderText="Student Name" SortExpression="studentName" />
                    <asp:BoundField DataField="classSection" HeaderText="Class Section" SortExpression="classSection" />
                    <asp:BoundField DataField="fatherMobileNumber" HeaderText="Mobile Number" SortExpression="fatherMobileNumber" />
                    <asp:BoundField DataField="template" HeaderText="SMS Template" SortExpression="template" />
                    <asp:BoundField DataField="dateSent" HeaderText="Date Sent" DataFormatString="{0:dd-MM-yyyy}" SortExpression="dateSent" />
                    <asp:BoundField DataField="dateEntered" HeaderText="Date Of Entry" DataFormatString="{0:dd-MM-yyyy}" SortExpression="dateEntry" />
                </Columns>
                <EditRowStyle BackColor="#7C6F57" />
                <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="#ffffff" />
                <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1" BackColor="#3AB4E8" Font-Bold="True" ForeColor="#000000" />
                <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1" BackColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
            </asp:GridView>
    </section>
</asp:Content>
