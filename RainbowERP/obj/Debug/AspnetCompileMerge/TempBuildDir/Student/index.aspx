<%@ Page Title="" Language="C#" MasterPageFile="../ERP.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="RAINBOW_ERP.Student.index" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Header -->
    <header id="header">
        <strong>Manage Student</strong>
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
        <br />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAddStudent" runat="server" Text="Add Student" OnClick="btnAddStudent_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnTC" runat="server" Text="Transfer Cerificate" OnClick="btnTC_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnImport" runat="server" Text="Import Student" OnClick="btnImport_Click" />
        <br />
        <br />
        <span style="float: left;">&nbsp;&nbsp;&nbsp; Admission No&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="ftAdmissionNo" runat="server" Width="149px" Style="float: left;"></asp:TextBox>&nbsp;&nbsp;&nbsp; 
        <span style="float: left;">Student Name&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="ftStudentName" runat="server" Width="149px" Style="float: left;"></asp:TextBox>&nbsp;&nbsp;&nbsp;
        <span style="float: left;">Class&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="ftClass" runat="server" Width="149px" Style="float: left;"></asp:TextBox>&nbsp;&nbsp;&nbsp;
        <span style="float: left;">Section&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp; 
        <asp:TextBox ID="ftSection" runat="server" Width="149px" Style="float: left;"></asp:TextBox>&nbsp;&nbsp;&nbsp;
        <span style="float: left;">&nbsp;&nbsp;&nbsp;Student Category&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
        <asp:TextBox ID="ftStudentCategory" runat="server" Width="149px" Style="float: left;"></asp:TextBox>&nbsp;&nbsp;&nbsp;
        <span style="float: left;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Father&#39;s Name&nbsp;&nbsp;&nbsp; </span>
        <asp:TextBox ID="ftFatherName" runat="server" Width="149px" Style="float: left;"></asp:TextBox>&nbsp;&nbsp;&nbsp;
        <span style="float: left;">&nbsp;&nbsp;&nbsp;Mobile Number&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="ftMobileNumber" runat="server" Width="149px" TextMode="Number" Style="float: left;"></asp:TextBox>&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" />
        <asp:Button ID="btnExcel" runat="server" Text="Export To Excel" OnClick="btnExcel_Click" />
        <br />
        <br />
        <asp:GridView ID="grdStudent" PageSize="20" AutoGenerateColumns="False" runat="server" CellPadding="0" GridLines="None" AllowPaging="True" EmptyDataText="No data available." OnRowCommand="grdStudent_RowCommand" Width="100%" AllowSorting="true" OnSorting="grdStudent_Sorting" OnPageIndexChanging="grdStudent_PageIndexChanging">
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
                <asp:BoundField DataField="studentCategory" HeaderText="Student Category" SortExpression="studentCategory" />
                <asp:BoundField DataField="fatherName" HeaderText="Father's Name" SortExpression="fatherName" />
                <asp:BoundField DataField="fatherMobileNumber" HeaderText="Mobile Number" SortExpression="fatherMobileNumber" />
                <asp:BoundField DataField="dob" HeaderText="Date Of Birth" DataFormatString="{0:dd-MM-yyyy}" SortExpression="dob" />
                <%--<asp:BoundField DataField="address" HeaderText="Address" />
                <asp:BoundField DataField="aadharCardNo" HeaderText="Aadhar Card No" />
                <asp:BoundField DataField="motherName" HeaderText="Mother's Name" />
                <asp:BoundField DataField="emailAddress" HeaderText="Email Address" />
                <asp:BoundField DataField="siblingAdmissionNo" HeaderText="Sibling Admission No" />--%>
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
