<%@ Page Title="" Language="C#" MasterPageFile="~/admin/yonetim.Master" AutoEventWireup="true" CodeBehind="makaleEkle.aspx.cs" Inherits="evde28kasim.admin.makaleEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="form-group">
        <div class="row">
            <asp:Label ID="Label1" runat="server" Text="Başlık"></asp:Label>
            <asp:TextBox ID="txtBaslik" CssClass="form-control" runat="server" placeholder="Başlık"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="Kısa Yazı"></asp:Label>
            <asp:TextBox ID="txtKisaYazi" CssClass="form-control" runat="server" placeholder="Kısa Yazı"></asp:TextBox>
            <asp:Label ID="Label3" runat="server" Text="Makale İçerik"></asp:Label>
            <asp:TextBox ID="txtYazi" CssClass="form-control" runat="server" TextMode="MultiLine" placeholder="Makale İçerik"></asp:TextBox>
            <asp:Label ID="Label4" runat="server" Text="Makale Resim"></asp:Label>
            <asp:FileUpload ID="flResimYukle" CssClass="form-control-file" runat="server" />
            <asp:Label ID="Label6" runat="server" Text="Kategori Seçimi"></asp:Label>
            <asp:DropDownList ID="drpKategoriListe"  CssClass="form-control"  runat="server">
            </asp:DropDownList> <br />  <br />  
            <asp:Button ID="btnKaydet"  CssClass="btn btn-primary" runat="server" OnClick="Button1_Click" Text="Makale Kaydet" />
            <asp:Label ID="lblSonuc" runat="server"></asp:Label>  </div>
    </div>
</asp:Content>
