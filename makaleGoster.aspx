<%@ Page Title="" Language="C#" MasterPageFile="~/anasayfa.Master" AutoEventWireup="true" CodeBehind="makaleGoster.aspx.cs" Inherits="evde28kasim.makaleGoster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12">
            <h3>
                <asp:Label ID="lblMakaleBaslik" runat="server" Text=""></asp:Label></h3>
            <asp:Image ID="ImgMakaleResim" runat="server" CssClass="img-thumbnail" />
            <small class="col-form-label"></small>
            <p>
                <asp:Label ID="lblKategori" runat="server" Text=""></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblKisaYazi" runat="server" Text=""></asp:Label>
            </p>
            <p>
                <asp:Label ID="lblYazi" runat="server" Text=""></asp:Label>
            </p>

        </div>
    </div>
</asp:Content>
