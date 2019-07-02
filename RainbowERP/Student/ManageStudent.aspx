<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true" CodeBehind="ManageStudent.aspx.cs" Inherits="RAINBOW_ERP.Student.ManageStudent" %>

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
            Student Category&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlStudentCategory" runat="server" Width="149px"></asp:DropDownList>
            <br />
            Student Class&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlClass" runat="server" Width="149px"></asp:DropDownList>
            <br />
            Admission Number&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
            <asp:TextBox ID="txtAdmissionNo" runat="server" Width="149px" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valAdmissionNO" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Required" ControlToValidate="txtAdmissionNo"></asp:RequiredFieldValidator>
            <br />
            <br />
            Student Name&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtStudentName" runat="server" Width="149px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valStudentName" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Required" ControlToValidate="txtStudentName"></asp:RequiredFieldValidator>
            <br />
            Father's Name&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtFatherName" runat="server" Width="149px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valFatherName" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Required" ControlToValidate="txtFatherName"></asp:RequiredFieldValidator>
            <br />
            Mother's Name&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtMotherName" runat="server" Width="149px"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valMotherName" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Required" ControlToValidate="txtMotherName"></asp:RequiredFieldValidator>
            <br />
            Mobile Number&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
            <asp:TextBox ID="txtMobileNumber" runat="server" Width="149px" TextMode="Number"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valMobileNumber" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Required" ControlToValidate="txtMobileNumber"></asp:RequiredFieldValidator>
            <br />
            <br />
            Gender&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlGender" runat="server" Width="149px">
                <asp:ListItem Value="true">Male</asp:ListItem>
                <asp:ListItem Value="false">Female</asp:ListItem>
            </asp:DropDownList>
            <br />
            Address&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtAddress" runat="server" Width="149px" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valAddress" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Required" ControlToValidate="txtAddress"></asp:RequiredFieldValidator>
            <br />
            Email Address&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtEmailAddress" runat="server" Width="149px"></asp:TextBox>
            <br />
            Date of Birth&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
            <asp:TextBox ID="txtDOB" runat="server" Width="175px" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator ID="valDOB" runat="server" ErrorMessage="*" ForeColor="Red" ValidationGroup="Required" ControlToValidate="txtDOB"></asp:RequiredFieldValidator>
            <br />
            <br />
            Sibling Admission Number&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
            <asp:TextBox ID="txtSiblingAdmissionNo" runat="server" Width="149px" TextMode="Number"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSiblingEnable" runat="server" OnClick="btnSiblingEnable_Click" Text="Enable" Font-Size="Smaller" />
            <br />
            <br />
            Aadhar Card Number&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
            <asp:TextBox ID="txtAadharCardNo" runat="server" Width="149px" TextMode="Number"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnAadharEnable" runat="server" OnClick="btnAadharEnable_Click" Text="Enable" Font-Size="Smaller" />
            <br />
            <br />
        </p>
    </section>
    <section style="width: 50%; float: right">
        Birth Certificate&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <asp:FileUpload ID="fuBirthCertificate" runat="server" />
        <br />
        <asp:HyperLink ID="linkBirthC" runat="server" Font-Underline="True" ForeColor="Blue">[linkTC]</asp:HyperLink>
        <br />
        Transfer Certificate&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
        <asp:FileUpload ID="fuTransferCertificate" runat="server" />
        <br />
        <asp:HyperLink ID="linkTC" runat="server" Font-Underline="True" ForeColor="Blue">[linkTC]</asp:HyperLink>
        <br />
        <b>Miscellaneous File Upload 1</b>&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
        <br />
        Name 
        <asp:TextBox ID="txtFileUpload1" runat="server" Width="149px"></asp:TextBox>
        File  
        <br />
        <asp:FileUpload ID="fuMisc1" runat="server" />
        <br />
        <asp:HyperLink ID="linkMisc1" runat="server" Font-Underline="True" ForeColor="Blue">[linkTC]</asp:HyperLink>
        <br />
        <b>Miscellaneous File Upload 2</b>&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
        <br />
        Name 
        <asp:TextBox ID="txtFileUpload2" runat="server" Width="149px"></asp:TextBox>
        File  
        <br />
        <asp:FileUpload ID="fuMisc2" runat="server" />
        <br />
        <asp:HyperLink ID="linkMisc2" runat="server" Font-Underline="True" ForeColor="Blue">[linkTC]</asp:HyperLink>
        <br />
        <b>Miscellaneous File Upload 3</b>&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
        <br />
        Name 
        <asp:TextBox ID="txtFileUpload3" runat="server" Width="149px"></asp:TextBox>
        File  
        <br />
        <asp:FileUpload ID="fuMisc3" runat="server" />
        <br />
        <asp:HyperLink ID="linkMisc3" runat="server" Font-Underline="True" ForeColor="Blue">[linkTC]</asp:HyperLink>
        <br />
        Date Created&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtDateCreated" runat="server" Width="149px" ReadOnly="true"></asp:TextBox>
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
    </section>
    <section style="width: 100%; float: left">
        <span style="color: red">Fields marked (*) are required.</span><br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" ValidationGroup="Required" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        <br />
    </section>
</asp:Content>
