<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="ThongTinGiaNuoc.aspx.cs" Inherits="cskh.huewaco.vn.ThongTinGiaNuoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlace" runat="server">
    <div style="height: 5px">
    </div>
    <div class="TitPage" style="margin-left: 8px; margin-right: 8px">
        <img style="border-width: 0px;" src="Source/ReportIcon.gif" class="icon_image">
        <span class="subNavLink">THÔNG TIN GIÁ BÁN NƯỚC</span>
        <div style="position: absolute; text-align: right; right: 205px; top: 330px;">
            <%--<a href = "A01_ThongTinGiaDienCu.aspx">Giá Nước cũ</a> áp dụng trước ngày 16/03/2015--%>
        </div>
    </div>
    <div style="margin-left: 8px; margin-right: 8px; margin-top: 20px">
        <asp:Label runat="server" ID="lblContent" Font-Names="Arial" Font-Size="12px" ForeColor="#565656" />
    </div>
</asp:Content>
