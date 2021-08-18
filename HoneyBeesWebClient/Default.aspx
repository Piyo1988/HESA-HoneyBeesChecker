<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="HoneyBeesWebClient._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <asp:ListBox ID="lbBeesStatus" runat="server" Height="20%" Rows="33" Width="70%">

    </asp:ListBox> 
    <asp:Button ID="Button1" runat="server" Text="Update Bees Health Check" OnClick="Button1_Click" />
    <asp:ListBox ID="lbUpdatedBeesStatus" runat="server" Rows="33" Width="70%" Height="20%"></asp:ListBox>
   
</asp:Content>
