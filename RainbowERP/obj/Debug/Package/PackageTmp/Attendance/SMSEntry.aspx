<%@ Page Title="" Language="C#" MasterPageFile="../ERP.Master" AutoEventWireup="true" CodeBehind="SMSEntry.aspx.cs" Inherits="RAINBOW_ERP.Attendance.SMSEntry" %>
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

        <br />
        &nbsp;&nbsp;&nbsp;
        <br />
        <br />
<span style="float:left;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Student Leave Type&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlStudentLeaveType" runat="server" Width="149px" style="float:left;"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
       <asp:RequiredFieldValidator ID="valStudentLeaveType" runat="server" ErrorMessage="*" ControlToValidate="ddlStudentLeaveType" ForeColor="Red" ValidationGroup="Required"></asp:RequiredFieldValidator>
         &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;<br />
<span style="float:left;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SMS Template&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;<asp:RadioButtonList ID="lstSMSTemplate" runat="server" style="float:left;"></asp:RadioButtonList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:RequiredFieldValidator ID="valSMSTemplate" runat="server" ErrorMessage="*" ControlToValidate="lstSMSTemplate" ForeColor="Red" ValidationGroup="Required"></asp:RequiredFieldValidator>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:GridView ID="grdAttendance" PageSize="20" DataKeyNames="id" AllowSorting="true" OnSorting="grdAttendance_Sorting" AutoGenerateColumns="False" runat="server" CellPadding="0" GridLines="None" AllowPaging="True" EmptyDataText="No data available." OnPageIndexChanging="grdAttendance_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Serial No." ItemStyle-Width="100">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                    </ItemTemplate>

<ItemStyle Width="100px"></ItemStyle>
                </asp:TemplateField>
                <asp:BoundField DataField="class1" HeaderText="Class" SortExpression="class1" />
                <asp:BoundField DataField="section" HeaderText="Section" SortExpression="section" />
                <asp:BoundField DataField="date" HeaderText="Date" DataFormatString="{0:dd-MM-yyyy}" SortExpression="date" />
                <asp:BoundField DataField="studentLeaveType" HeaderText="Student Leave Type" SortExpression="studentLeaveType" />
                <asp:TemplateField HeaderText="Student Leave Type">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:DropDownList AppendDataBoundItems="true" ID="ddlSelection" runat="server">
                            <asp:ListItem Text="Select" Value="-1"></asp:ListItem>
                            <asp:ListItem Text="Send" Value="0"></asp:ListItem>
                        </asp:DropDownList>
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
    <section style="width: 100%; float: left">
        <span style="color: red">Fields marked (*) are required.</span><br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ValidationGroup="Required" Text="Send" />
        <br />
        <br />
        <asp:Label ID="lblUpdate" runat="server"></asp:Label>
        <br />
    </section>
</asp:Content>
