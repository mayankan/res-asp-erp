<%@ Page Title="" Language="C#" MasterPageFile="../ERP.Master" AutoEventWireup="true" CodeBehind="Class.aspx.cs" Inherits="RAINBOW_ERP.Student.Class" EnableViewState="true" ViewStateEncryptionMode="Always" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function Confirm() {
            var confirm_value = document.createElement("INPUT");
            confirm_value.type = "hidden";
            confirm_value.name = "confirm_value";
            if (confirm("Are you sure want to Delete this Class?")) {
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
        <strong>Manage Class</strong>
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
        <asp:Button ID="btnAddClass" runat="server" Text="Add Class" OnClick="btnAddClass_Click" />
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnTC" runat="server" Text="Transfer Cerificate" OnClick="btnTC_Click" />
        <br />
        <br />
 <span style="float:left;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;CLASS&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;<asp:TextBox ID="ftClass" runat="server" Width="149px" style="float:left;"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <span style="float:left;">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;SECTION&nbsp;&nbsp;&nbsp;</span>&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="ftSection" runat="server" Width="149px" style="float:left;"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnFilter" runat="server" Text="Filter" OnClick="btnFilter_Click" />
        <br />
        <br />
        <br />
        <asp:GridView ID="grdClass" runat="server" AutoGenerateColumns="False" AllowSorting="true" AllowPaging="true" OnSorting="grdClass_Sorting" OnPageIndexChanging="grdClass_PageIndexChanging" PageSize="20" CellPadding="1" ForeColor="#333333" EmptyDataText="No data available." OnRowCommand="grdClass_RowCommand">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:TemplateField HeaderText="Serial No." ItemStyle-Width="100">
                    <ItemTemplate>
                        <asp:Label ID="lblRowNumber" Text='<%# Container.DataItemIndex + 1 %>' runat="server" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="class1" HeaderText="Class" SortExpression="class1" />
                <asp:BoundField DataField="section" HeaderText="Section" SortExpression="section" />
                <asp:BoundField DataField="totalStrength" HeaderText="Total No. of Students" SortExpression="totalStrength" />
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
            <PagerStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1" BackColor="#3AB4E8" ForeColor="Black" VerticalAlign="Middle" Font-Size="Medium" HorizontalAlign="Center" Height="20%" Wrap="true" Width="20%"  />
            <RowStyle BorderColor="Black" BorderStyle="Solid" BorderWidth="1" BackColor="White" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
        </asp:GridView>
    </section>
</asp:Content>
