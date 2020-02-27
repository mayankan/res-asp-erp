<%@ Page Title="" Language="C#" MasterPageFile="../ERP.Master" AutoEventWireup="true" CodeBehind="ManageAttendance.aspx.cs" Inherits="RAINBOW_ERP.Attendance.ManageAttendance" %>

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
									</ul>--%>&nbsp;<%--<ul class="icons">
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
            <span style="float: left;">&nbsp;&nbsp;&nbsp; Student Class</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlClass" runat="server" Width="149px" AutoPostBack="true" OnSelectedIndexChanged="ddlClass_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
            <span style="float: left;">Date&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="txtDate" runat="server" Width="149px" TextMode="Date"></asp:TextBox>&nbsp;&nbsp;&nbsp; 
            <asp:RequiredFieldValidator ID="rdDate" runat="server" ErrorMessage="*" ControlToValidate="txtDate" ValidationGroup="Required" ForeColor="Red"></asp:RequiredFieldValidator>
            <br />
            <br />
        </p>
    </section>
    <section style="float: right; width: 50%">
        <span>Student Leave Type&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            <asp:DropDownList AppendDataBoundItems="true" ID="ddlStudentLeaveType" runat="server" Width="149px">
            </asp:DropDownList>&nbsp;&nbsp;&nbsp; 
            <br />
        <asp:Button ID="btnApplyAll" runat="server" Text="Apply To All" OnClick="btnApplyAll_Click" />
    </section>
    <section>
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
                <asp:BoundField DataField="studentLeaveType" HeaderText="Student Leave Type" SortExpression="studentLeaveType" />
                <asp:TemplateField HeaderText="Gender">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<% #GetGender(Eval("gender")) %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Student Leave Type">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:DropDownList AppendDataBoundItems="true" ID="ddlGrdStudentLeaveType" runat="server" DataTextField="studentLeaveType" DataValueField="studentLeaveTypeId">
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
        <asp:Label ID="lblUpdate" runat="server"></asp:Label>
        <br />
    </section>
</asp:Content>
