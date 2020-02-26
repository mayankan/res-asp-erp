<%@ Page Title="" Language="C#" MasterPageFile="~/ERP.Master" AutoEventWireup="true" CodeBehind="UserLogin.aspx.cs" Inherits="RAINBOW_ERP.Login.UserLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="text-align: center;">
        <div style="width: 400px; margin-left: auto; margin-right: auto;">
            <asp:Login ID="Login1" runat="server" OnAuthenticate="Login1_Authenticate" Width="400px" DisplayRememberMe="false"></asp:Login>
        </div>
    </div>
</asp:Content>
