<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true" CodeBehind="ManageGClassSubjectMap.aspx.cs" Inherits="RAINBOW_ERP.ReportCard.ManageGClassSubject" %>

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
            <asp:DropDownList ID="ddlClass" runat="server" Width="149px" AutoPostBack="true"></asp:DropDownList>
            <br />
            <br />
            Subject 1&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject1" runat="server" Width="149px" AutoPostBack="true">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="valSubject" runat="server" ErrorMessage="*" ControlToValidate="txtSubject1" ForeColor="Red" ValidationGroup="Required"></asp:RequiredFieldValidator>
            <br />
            Subject 2&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject2" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
            <br />
            Subject 3&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject3" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
            <br />
            Subject 4&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject4" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>

            </asp:DropDownList>
            <br />
            Subject 5&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject5" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
            <br />
            Subject 6&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject6" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
            <br />
            Subject 7&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject7" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
            <br />
            Subject 8&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject8" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
            <br />
            Subject 9&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject9" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
            <br />
            Subject 10&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject10" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
            <br />
            Subject 11&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject11" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
            <br />
            Subject 12&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject12" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
            <br />
            Subject 13&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject13" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
            <br />
            Subject 14&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject14" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
            <br />
            Subject 15&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject15" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
            <br />
            Subject 16&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject16" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
            <br />
            Subject 17&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject17" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
            <br />
            Subject 18&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject18" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
            <br />
            Subject 19&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject19" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
            <br />
            Subject 20&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject20" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
            <br />
        </p>
    </section>
    <section style="width: 50%; float: right">
        <br />
        Subject 21&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject21" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
        <br />
        Subject 22&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject22" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
        <br />
        Subject 23&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject23" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
        <br />
        Subject 24&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject24" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>

            </asp:DropDownList>
        <br />
        Subject 25&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject25" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
        <br />
        Subject 26&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject26" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
        <br />
        Subject 27&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject27" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
        <br />
        Subject 28&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject28" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
        <br />
        Subject 29&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject29" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
        <br />
        Subject 30&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject30" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
        <br />
        Subject 31&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject31" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
        <br />
        Subject 32&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject32" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
        <br />
        Subject 33&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject33" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
        <br />
        Subject 34&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject34" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>

            </asp:DropDownList>
        <br />
        Subject 35&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject35" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
        <br />
        Subject 36&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject36" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
        <br />
        Subject 37&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject37" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
        <br />
        Subject 38&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject38" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
        <br />
        Subject 39&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject39" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
        <br />
        Subject 40&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="txtSubject40" runat="server" Width="149px">
                <asp:ListItem Selected="True">Select</asp:ListItem>
            </asp:DropDownList>
        <br />
    </section>
    <section style="width: 100%; float: left">
        <asp:Label ID="lblUpdate" runat="server"></asp:Label>
        <span style="color: red">Fields marked (*) are required.</span><br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" ValidationGroup="Required" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnDelete" runat="server" OnClick="btnDelete_Click" Text="Delete" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" />
        <br />
    </section>
</asp:Content>
