<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="QL_TTLienHe.aspx.cs" Inherits="cskh.huewaco.vn.QL_TTLienHe" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxHtmlEditor" Assembly="DevExpress.Web.ASPxHtmlEditor.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlace" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>   
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server">
        <ContentTemplate>
            <div>
        <table width="100%" cellpadding=2 cellspacing=5 style="background-color:#FFFFFF; font-family:Verdana; font-size:13px">
            <tr>
                <td colspan="2" align="center"><b>CẬP NHẬT THÔNG TIN LIÊN HỆ</b></td>
            </tr>                 
            <tr valign = "top">
                <td align="right">Đơn vị:</td>
                <td>
                    <asp:DropDownList runat = "server" ID = "drlDonvi" OnSelectedIndexChanged="drlDonvi_SelectedIndexChanged" AutoPostBack="True">
                        <asp:ListItem Value = "CPC" Text = "Tổng Công ty Điện lực Miền Trung" />
                        <asp:ListItem Value = "PC01" Text = "Công ty Điện lực Quảng Bình" />
                        <asp:ListItem Value = "PC02" Text = "Công ty Điện lực Quảng Trị" />
                        <asp:ListItem Value = "PC03" Text = "Công ty Điện lực TT Huế" />
                        <asp:ListItem Value = "PP" Text = "Công ty Điện lực Đà Nẵng" />
                        <asp:ListItem Value = "PC05" Text = "Công ty Điện lực Quảng Nam" />
                        <asp:ListItem Value = "PC06" Text = "Công ty Điện lực Quảng Ngãi" />
                        <asp:ListItem Value = "PC07" Text = "Công ty Điện lực Bình Định" />
                        <asp:ListItem Value = "PC08" Text = "Công ty Điện lực Phú Yên" />
                        <asp:ListItem Value = "PQ" Text = "Công ty Điện lực Khách Hòa" />
                        <asp:ListItem Value = "PC10" Text = "Công ty Điện lực Gia Lai" />
                        <asp:ListItem Value = "PC11" Text = "Công ty Điện lực Kon Tum" />
                        <asp:ListItem Value = "PC12" Text = "Công ty Điện lực Đăk Lăk" />
                        <asp:ListItem Value = "PC13" Text = "Công ty Điện lực Đăk Nông" />
                        <asp:ListItem Value = "CPC_DEFAULT" Text = "Trang chủ - Giới thiệu - EVNCPC" />
                        <asp:ListItem Value = "PC01_DEFAULT" Text = "Trang chủ - Giới thiệu - Quảng Bình" />
                        <asp:ListItem Value = "PC02_DEFAULT" Text = "Trang chủ - Giới thiệu - Quảng Trị" />
                        <asp:ListItem Value = "PC03_DEFAULT" Text = "Trang chủ - Giới thiệu - TT Huế" />
                        <asp:ListItem Value = "PP_DEFAULT" Text = "Trang chủ - Giới thiệu - Đà Nẵng" />
                        <asp:ListItem Value = "PC05_DEFAULT" Text = "Trang chủ - Giới thiệu - Quảng Nam" />
                        <asp:ListItem Value = "PC06_DEFAULT" Text = "Trang chủ - Giới thiệu - Quảng Ngãi" />
                        <asp:ListItem Value = "PC07_DEFAULT" Text = "Trang chủ - Giới thiệu - Bình Định" />
                        <asp:ListItem Value = "PC08_DEFAULT" Text = "Trang chủ - Giới thiệu - Phú Yên" />
                        <asp:ListItem Value = "PQ_DEFAULT" Text = "Trang chủ - Giới thiệu - Khách Hòa" />
                        <asp:ListItem Value = "PC10_DEFAULT" Text = "Trang chủ - Giới thiệu - Gia Lai" />
                        <asp:ListItem Value = "PC11_DEFAULT" Text = "Trang chủ - Giới thiệu - Kon Tum" />
                        <asp:ListItem Value = "PC12_DEFAULT" Text = "Trang chủ - Giới thiệu - Đăk Lăk" />
                        <asp:ListItem Value = "PC13_DEFAULT" Text = "Trang chủ - Giới thiệu - Đăk Nông" />                        
                    </asp:DropDownList>
                </td>
            </tr>
            <tr valign = "top">
                <td align="right">Thông tin LH:</td>
                <td> <dx:ASPxHtmlEditor ID="ftbDocContent"  Height="1000px"  runat="server" Width="100%">
                                 <Settings AllowHtmlView="False"></Settings>
                            </dx:ASPxHtmlEditor></td>
            </tr>            
            <tr>
                <td></td>
                <td>
                    <asp:Button runat=server ID = btnSave Text = "Lưu lại" onclick="btnSave_Click"/>
                </td>
            </tr>
        </table>
    </div>
        </ContentTemplate>
    </asp:UpdatePanel> 
</asp:Content>
