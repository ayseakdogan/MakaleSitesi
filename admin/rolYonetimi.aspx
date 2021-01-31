<%@ Page Title="" Language="C#" MasterPageFile="~/admin/yonetim.Master" AutoEventWireup="true" CodeBehind="rolYonetimi.aspx.cs" Inherits="evde28kasim.admin.rolYonetimi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Rol Yönetim</h3>
    <asp:TextBox ID="txtRolAd" runat="server"></asp:TextBox>
    <asp:Button ID="btnROlEkle" runat="server" Text="Rol Ekle" OnClick="btnROlEkle_Click" /><br />

    <asp:ListBox ID="lstUyeler" runat="server"></asp:ListBox>
    <asp:ListBox ID="lstRoller" runat="server"></asp:ListBox>

    <asp:Label ID="lblSonuc" runat="server" Text=""></asp:Label>
    <asp:Button ID="btnRoleKullaniciEkle" runat="server" OnClick="btnRoleKullaniciEkle_Click" Text="Role Kullanıcı Ekle" />

</asp:Content>
