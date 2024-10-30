<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="Thutuccapnuoc.aspx.cs" Inherits="cskh.huewaco.vn.Thutuccapnuoc" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnMainPlace" ContentPlaceHolderID="ContentPlace" Runat="Server">
    <div style="height: 5px">        
    </div>    
    <div class="TitPage" style="margin-left:8px; margin-right:8px">
        <img style="border-width:0px;" src="Source/ReportIcon.gif" class="icon_image">
        <span class="subNavLink">THỦ TỤC HỢP ĐỒNG MB NƯỚC SINH HOẠT</span>
    </div>
    <div style="margin-left:8px; margin-right:8px; margin-top: 20px">
        <asp:Label runat="server" ID = "lblContent" Font-Names = "Arial" Font-Size = "12px" ForeColor = "#000000"/>
    </div>
</asp:Content>