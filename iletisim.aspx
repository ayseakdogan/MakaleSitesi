<%@ Page Title="" Language="C#" MasterPageFile="~/anasayfa.Master" AutoEventWireup="true" CodeBehind="iletisim.aspx.cs" Inherits="evde28kasim.iletisim" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-8">
            <div class="form-group">
                Email 

            <asp:TextBox ID="txtEmail" CssClass="form-control" runat="server"></asp:TextBox><br />

            </div>
            <div class="form-group">
                Konu:
            <asp:TextBox ID="txtKonu" CssClass="form-control" runat="server"></asp:TextBox><br />

            </div> 

            <div class="form-group">
                Mesajınız 
          <asp:TextBox ID="txtMesaj" CssClass="form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>

            <asp:Button ID="btnGonder" runat="server" Text="Mesaj ilet" OnClick="btnGonder_Click"/>
        </div>

    </div>

</asp:Content>
