<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="DoiMatKhau.aspx.cs" Inherits="cskh.huewaco.vn.DoiMatKhau" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlace" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UDPLogin" runat="server">
        <ContentTemplate>
            <div class="TitPage" style="margin-left: 8px; margin-right: 8px;">
                <img style="border-width: 0px;" src="Source/ReportIcon.gif" class="icon_image">
                <span class="subNavLink">THAY ĐỔI MẬT KHẨU</span>
            </div>
            <div style="width: 700px; margin: 0px 0 0 20px;">
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tr>
                        <td>
                            <table cellspacing="2" cellpadding="1" border="0" style="margin: 10px 0 0 0" width="100%">
                                <tbody>
                                    <tr align="left" valign="top">
                                        <td colspan="3">
                                            <div style="margin: 0 0 10px 0; line-height: 19px">
                                                Xin vui lòng nhập lại mật khẩu cũ và mật khẩu mới để thay đổi.
                                            </div>
                                        </td>
                                    </tr>
                                    <tr align="left" valign="top">
                                        <td style="width: 150px; padding-left: 20px">Mật khẩu cũ:</td>
                                        <td style="width: 200px">
                                            <dx:ASPxTextBox ID="txtPassword" ClientInstanceName="txtUsername" runat="server" Width="100%"></dx:ASPxTextBox>

                                           
                                        </td>
                                        <td> <asp:RequiredFieldValidator ID="rfvPassword"  runat="server" Display="Dynamic"  ControlToValidate="txtPassword" ErrorMessage="*" ValidationGroup="Login" ForeColor="Red" /></td>
                                    </tr>
                                    <tr align="left" valign="top">
                                        <td style="width: 102px; padding-left: 20px">Mật khẩu mới:</td>
                                        <td>
                                            <dx:ASPxTextBox ID="txtNewPassword"  runat="server" Width="100%" Password="True"></dx:ASPxTextBox>
                                           
                                        </td>
                                        <td> <asp:RequiredFieldValidator ID="RequiredFieldValidator1" Display="Dynamic" ValidationGroup="Login"  runat="server" ControlToValidate="txtNewPassword" ErrorMessage="*" ForeColor="Red"/></td>
                                    </tr>
                                    <tr align="left" valign="top">
                                        <td style="width: 102px; padding-left: 20px">Nhập lại mật khẩu mới:</td>
                                        <td >
                                            <dx:ASPxTextBox ID="txtVerifyPassword"  runat="server" Width="100%" Password="True"></dx:ASPxTextBox>
                                            
                                        </td>
                                        <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ValidationGroup="Login" runat="server" ControlToValidate="txtVerifyPassword" ErrorMessage="*" ForeColor="Red"/></td>
                                    </tr>
                                    <tr align="left" valign="top" class="font33">
                                        <td></td>
                                        <td style="width: 300px" colspan="2">
                                            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="txtNewPassword" ControlToValidate="txtVerifyPassword"
                                                ErrorMessage="CompareValidator" ValidationGroup="Login" ForeColor="Red">Mật khẩu / Mật khẩu nhập lại không khớp. Vui lòng 
                                kiểm tra lại.</asp:CompareValidator>
                                            <asp:Label ID="lblError" runat="server" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr align="left">
                                        <td style="width: 102px"></td>
                                        <td style="width: 100px">
                                            <asp:Label ID="lblMessageLogin" runat="server" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="text-align: center">

                <asp:UpdateProgress runat="server" ID="UpdateProgressDK" AssociatedUpdatePanelID="UDPLogin" DisplayAfter="0" DynamicLayout="True">
                    <ProgressTemplate>
                        <img alt="" width="50px" src="Images/processing.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
            <div style="padding-left: 235px; padding-top: 10px">
                <asp:Button runat="server" ID="btnThayDoi" CssClass="button cyan validate" Text="Thay đổi" OnClick="btnThayDoi_OnClick" CausesValidation="true" ValidationGroup="Login" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
