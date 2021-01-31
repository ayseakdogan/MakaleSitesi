<%@ Page Title="" Language="C#" MasterPageFile="~/anasayfa.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="evde28kasim._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 
    <div class="row">

        <asp:Repeater ID="rptMakaleler" runat="server">
            <ItemTemplate>
                <div class="col-md-4">
                    <div class="card mb-4 shadow-sm">
                        <h3 class="text-center"><%#Eval("BASLIK") %></h3>
                        <img alt="" class="img-thumbnail" src="<%#Eval("RESIMYOL")%>" /> 
                        <div class="card-body">
                            <p class="card-text"><%#Eval("KISAYAZI") %></p>
                            <div class="d-flex justify-content-between align-items-center">
                            </div>
                            <small class="text-right small">Kategori:<%#Eval("KATEGORIAD") %></small></div>
                        <asp:LinkButton ID="lnkMakaleGoster" CommandName='<%#Eval("ID")%>'
                            CssClass="btn btn-primary"  OnClick="lnkMakaleGoster_Click" runat="server">Makale Göster</asp:LinkButton>
                  
                        </div>
                </div> 
            </ItemTemplate>

        </asp:Repeater>

    </div>
</asp:Content>
