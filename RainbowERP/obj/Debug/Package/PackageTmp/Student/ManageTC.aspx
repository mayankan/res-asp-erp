<%@ Page Title="" Language="C#" MasterPageFile="../ERP.Master" AutoEventWireup="true" CodeBehind="ManageTC.aspx.cs" Inherits="RAINBOW_ERP.Student.ManageTC" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Header -->
    <header id="header">
        <a href="index.aspx" class="logo"><strong>
            <asp:Label ID="lblHeading" runat="server" Text=""></asp:Label></strong></a>
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
    <section style="float: left; width: 50%">
        <p>
            Student Class&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlClass" runat="server" Width="149px" Enabled="false"></asp:DropDownList>
            <br />
            Admission Number&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
            <asp:TextBox ID="txtAdmissionNo" runat="server" Width="149px" TextMode="Number" ReadOnly="true" OnTextChanged="txtAdmissionNo_TextChanged" AutoPostBack="true"></asp:TextBox>
            <br />
            <br />
            Student Name&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtStudentName" runat="server" Width="149px" ReadOnly="true"></asp:TextBox>
            <br />
            Father's Name&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtFatherName" runat="server" Width="149px" ReadOnly="true"></asp:TextBox>
            <br />
            Mobile Number&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
            <asp:TextBox ID="txtMobileNumber" runat="server" Width="149px" TextMode="Number" ReadOnly="true"></asp:TextBox>
            <br />
            <br />
            Gender&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlGender" runat="server" Width="149px" Enabled="false">
                <asp:ListItem Value="true">Male</asp:ListItem>
                <asp:ListItem Value="false">Female</asp:ListItem>
            </asp:DropDownList>
            <br />
            Address&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAddress" runat="server" Width="149px" ReadOnly="true"></asp:TextBox>
            <br />
            Email Address&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtEmailAddress" runat="server" Width="149px" ReadOnly="true"></asp:TextBox>
            <br />
            Date of Birth&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
            <asp:TextBox ID="txtDOB" runat="server" Width="149px" TextMode="Date" ReadOnly="true"></asp:TextBox>
            <br />
            <br />
    </section>
    <section style="width: 50%; float: right">
        Transfer Certificate&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
        <asp:FileUpload ID="fuTransferCertificate" runat="server" />
        <br />
        <asp:HyperLink ID="linkTC" runat="server" Font-Underline="True" ForeColor="Blue">[linkTC]</asp:HyperLink>
        <br />
        Date of Issue<br />
        <asp:TextBox ID="txtDateofIssue" runat="server" Width="149px" TextMode="Date"></asp:TextBox>
        <asp:RequiredFieldValidator Display="Dynamic" ID="valDateOfIssue" runat="server" ErrorMessage="*" ValidationGroup="Required" ForeColor="Red" ControlToValidate="txtDateofIssue"></asp:RequiredFieldValidator>
        <br />
        <br />
        Date Updated&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtDateUpdated" runat="server" Width="149px" ReadOnly="true"></asp:TextBox>
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </section>
    <section style="width: 100%; float: left">
        <span style="color: red">Fields marked (*) are required.</span><br />
        </p>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnSubmit_Click" ValidationGroup="Required" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
    </section>
</asp:Content>
