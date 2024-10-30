<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="QL_Noidung.aspx.cs" Inherits="cskh.huewaco.vn.QL_Noidung" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnMainPlace" ContentPlaceHolderID="ContentPlace" runat="Server">

    <div>
        <table width="100%" cellpadding="2" cellspacing="5" style="background-color: #FFFFFF; font-family: Verdana; font-size: 13px">
            <tr>
                <td colspan="2" align="center"><b>CẬP NHẬT NỘI DUNG TRANG WEB</b></td>
            </tr>
            <tr valign="top">
                <td align="left">Danh mục:</td>
                <td>
                    <asp:DropDownList runat="server" ID="drlDanhmuc" DataSourceID="NoiDungDataSource"
                        OnSelectedIndexChanged="drlDanhmuc_SelectedIndexChanged" DataValueField="intDocID" DataTextField="strDocName"
                        AutoPostBack="True">
                    </asp:DropDownList>
                    <asp:SqlDataSource runat="server" ID="NoiDungDataSource"
                        ConnectionString="<%$ ConnectionStrings:huewaco %>"
                        SelectCommand="Select * from tblDocuments"></asp:SqlDataSource>
                </td>
            </tr>
            <tr valign="top">
                <td align="left">Nội dung:</td>
                <td></td>
            </tr>
            <tr>
                <td colspan="2">
                    <dx:ASPxHtmlEditor ID="ASPxHtmlEditor1" Height="1000px" runat="server" Width="100%">
                        <Settings AllowHtmlView="False"></Settings>
                    </dx:ASPxHtmlEditor>
                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:Button runat="server" ID="btnSave" Text="Lưu lại" OnClick="btnSave_Click" />
                </td>
            </tr>
        </table>
    </div>

</asp:Content>
