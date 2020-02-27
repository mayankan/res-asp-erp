<%@ Page Title="" Language="C#" MasterPageFile="../ERP.Master" AutoEventWireup="true" CodeBehind="TC.aspx.cs" Inherits="RAINBOW_ERP.Student.TC" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Header -->
    <header id="header">
        <strong>Manage Transfer Certificate</strong>
        <%--<ul class="icons">
										<li><a href="#" class="icon fa-twitter"><span class="label">Twitter</span></a></li>
										<li><a href="#" class="icon fa-facebook"><span class="label">Facebook</span></a></li>
										<li><a href="#" class="icon fa-snapchat-ghost"><span class="label">Snapchat</span></a></li>
										<li><a href="#" class="icon fa-instagram"><span class="label">Instagram</span></a></li>
										<li><a href="#" class="icon fa-medium"><span class="label">Medium</span></a></li>
									</ul>--%>
    &nbsp;<%--<ul class="icons">
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
        &nbsp;&nbsp;&nbsp;
        <asp:button id="btnAddTC" runat="server" text="Add Transfer Certificate" onclick="btnAddTC_Click" />
        <br />
        <br />
<span style="float:left;">&nbsp;Admission No&nbsp;</span>
        <asp:TextBox ID="ftAdmissionNo" runat="server" Width="149px" style="float:left;"></asp:TextBox>&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp; <span style="float:left;">Student Name&nbsp;&nbsp;&nbsp;&nbsp; </span>
        <asp:TextBox ID="ftStudentName" runat="server" Width="149px" style="float:left;"></asp:TextBox>&nbsp;&nbsp;&nbsp;
    <span style="float:left;">Father&#39;s Name&nbsp;&nbsp;&nbsp; </span>
        <asp:TextBox ID="ftFatherName" runat="server" Width="149px" style="float:left;"></asp:TextBox>&nbsp;
        <span style="float:left;">Mobile Number&nbsp; </span>
        <asp:TextBox ID="ftMobileNumber" runat="server" Width="149px" TextMode="Number" style="float:left;"></asp:TextBox>&nbsp;&nbsp;&nbsp;
        <br />
        <span style="float:left;">&nbsp;&nbsp;&nbsp;&nbsp;Date Of TC Issue&nbsp;&nbsp;</span>
        <asp:TextBox ID="ftDateFrom" runat="server" Width="149px" TextMode="Date" style="float:left;"></asp:TextBox>&nbsp;&nbsp;&nbsp;<span style="float:left;">&nbsp;&nbsp;to&nbsp;&nbsp;</span>
        <asp:TextBox ID="ftDateTo" runat="server" Width="149px" TextMode="Date" style="float:left;"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" />
        <br />
        <br />
        <br />
        <asp:GridView ID="grdTC" AutoGenerateColumns="False" runat="server" CellPadding="1" ForeColor="#333333" GridLines="None" AllowPaging="True" EmptyDataText="No data available." OnRowCommand="grdTC_RowCommand" OnPageIndexChanging="grdTC_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Serial No." ItemStyle-Width="100">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="admissionNo" HeaderText="Admission Number" />
                <asp:BoundField DataField="studentName" HeaderText="Student Name" />
                <asp:BoundField DataField="classSection" HeaderText="Class Section" />
                <asp:BoundField DataField="fatherMobileNumber" HeaderText="Mobile Number" />
                <asp:BoundField DataField="dateDeleted" HeaderText="Date Of TC Issue" DataFormatString="{0:dd-MM-yyyy}" />
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Button runat="server" Text="Edit" CommandName="Select" CommandArgument='<%#Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
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
