<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true" CodeBehind="ManageGradeEntryB.aspx.cs" Inherits="RainbowERP.ReportCard.ManageGradeEntryB" %>

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
									</ul>--%><%--<ul class="icons">
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
            <span style="float: left;">&nbsp;&nbsp;&nbsp; Student Class</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlClass" runat="server" Width="149px" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
            </asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="-1" ID="valClass" Display="Dynamic" ValidationGroup="Required" runat="server" ForeColor="Red" ControlToValidate="ddlClass" ErrorMessage="Enter Class"></asp:RequiredFieldValidator>
            <br />
            <span style="float: left;">&nbsp;&nbsp;&nbsp; Subject Name</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="ddlSubjectName" runat="server" Width="149px">
            </asp:DropDownList>
            <asp:RequiredFieldValidator InitialValue="-1" ID="valSubject" Display="Dynamic" ValidationGroup="Required" runat="server" ForeColor="Red" ControlToValidate="ddlSubjectName" ErrorMessage="Enter Subject"></asp:RequiredFieldValidator>
            <br />
        </p>
    </section>
    <section style="float: right; width: 50%">
        <span>Examination Name&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:DropDownList ID="ddlExamination" runat="server" Width="149px">
            </asp:DropDownList>
        <asp:RequiredFieldValidator InitialValue="-1" ID="valExamination" Display="Dynamic" ValidationGroup="Required" runat="server" ForeColor="Red" ControlToValidate="ddlExamination" ErrorMessage="Enter Examination"></asp:RequiredFieldValidator>
        &nbsp;&nbsp;&nbsp; 
            <asp:Label ID="lblUpdate1" runat="server" ForeColor="Red"></asp:Label>
        <br />
    </section>
    <section>
        <asp:GridView ID="grdStudent" DataKeyNames="id" AutoGenerateColumns="False" runat="server" CellPadding="0" ForeColor="#333333" GridLines="None" EmptyDataText="No data available." OnRowDataBound="grdStudent_RowDataBound" Width="100%">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="S. No." ItemStyle-Width="100">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                    </ItemTemplate>
                    <ItemStyle Width="100px"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="admissionNo" HeaderText="Admission Number" />
                <asp:BoundField DataField="studentName" HeaderText="Student Name" />
                <asp:TemplateField HeaderText="Grade">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:DropDownList AppendDataBoundItems="true" ID="ddlGrades" runat="server" DataTextField="name" DataValueField="id">
                            <asp:ListItem Selected="True" Value="0">Select</asp:ListItem>
                            <asp:ListItem Value="A">A Grade</asp:ListItem>
                            <asp:ListItem Value="B">B Grade</asp:ListItem>
                            <asp:ListItem Value="C">C Grade</asp:ListItem>
                            <asp:ListItem Value="B">D Grade</asp:ListItem>
                            <asp:ListItem Value="C">E Grade</asp:ListItem>
                        </asp:DropDownList>
                    </ItemTemplate>
                </asp:TemplateField>
                <%--<asp:BoundField DataField="classSection" HeaderText="Class Section" />
                <asp:BoundField DataField="studentCategory" HeaderText="Student Category" />
                <asp:BoundField DataField="fatherName" HeaderText="Father's Name" />
                <asp:BoundField DataField="fatherMobileNumber" HeaderText="Mobile Number" />
                <asp:BoundField DataField="dob" HeaderText="Date Of Birth" DataFormatString="{0:dd-MM-yyyy}" /><asp:BoundField DataField="address" HeaderText="Address" />
                <asp:BoundField DataField="aadharCardNo" HeaderText="Aadhar Card No" />
                <asp:BoundField DataField="motherName" HeaderText="Mother's Name" />
                <asp:BoundField DataField="emailAddress" HeaderText="Email Address" />
                <asp:BoundField DataField="siblingAdmissionNo" HeaderText="Sibling Admission No" />
                        <asp:TemplateField ItemStyle-CssClass="Gender">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<% #GetGender(Eval("gender")) %>' />
                            </ItemTemplate>
                         </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button runat="server" Text="Edit" CommandName="Select" CommandArgument='<%#Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>--%>
            </Columns>
            <EditRowStyle BackColor="#7C6F57" />
            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="#ffffff" />
            <HeaderStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1" BackColor="#3AB4E8" Font-Bold="True" ForeColor="#000000" />
            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1" BackColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
    </section>
    <section style="width: 100%; float: left">
        <span style="color: red">Fields marked (*) are required.</span><br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ValidationGroup="Required" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
        &nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        <br />
        <br />
        <asp:Label ID="lblUpdate" runat="server" ForeColor="Red"></asp:Label>
        <br />
    </section>
</asp:Content>
