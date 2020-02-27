<%@ Page Title="" Language="C#" MasterPageFile="../ERP.Master" AutoEventWireup="true" CodeBehind="SMSTemplate.aspx.cs" Inherits="RAINBOW_ERP.Attendance.SMSTemplate" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure want to Delete this SMS Template?")) {
                confirm_value.value = "Yes";
            } else {
                confirm_value.value = "No";
            }
            document.forms[0].appendChild(confirm_value);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Header -->
    <header id="header">
        <a href="index.aspx" class="logo"><strong>Manage Student Leave Type</strong></a>
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
        <asp:Button ID="btnAddSMSTemplate" runat="server" Text="Add SMS Template" OnClick="btnAddSMSTemplate_Click" />
        <br />
        <br />
<span style="float:left;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Student Leave Type &nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;<asp:DropDownList ID="ddlStudentLeaveType" runat="server" Width="149px" style="float:left;" AppendDataBoundItems="true"></asp:DropDownList>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
<span style="float:left;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SMS Template&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;<asp:TextBox ID="ftSMS" runat="server" Width="149px" style="float:left;"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" />
        <br />
        <br />
        <asp:GridView ID="grdSMS" PageSize="20" AutoGenerateColumns="False" runat="server" CellPadding="0" GridLines="None" AllowPaging="True" EmptyDataText="No data available." OnSelectedIndexChanging="grdSMS_SelectedIndexChanging" OnRowCommand="grdSMS_RowCommand" AllowSorting="true" OnSorting="grdSMS_Sorting">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Serial No." ItemStyle-Width="100">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="studentLeaveType" HeaderText="Student Leave Type" SortExpression="studentLeaveType" />
                <asp:BoundField DataField="template" HeaderText="SMS Template" SortExpression="template" />
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Button runat="server" Text="Edit" CommandName="Select" CommandArgument='<%#Eval("id") %>' />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="">
                    <ItemTemplate>
                        <asp:Button runat="server" Text="Delete" OnClientClick="Confirm()" CommandName="Delete" CommandArgument='<%#Eval("id") %>' />
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
