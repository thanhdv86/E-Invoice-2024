<%@ Page Language="C#" MasterPageFile="~/CSKH.master" AutoEventWireup="false" CodeBehind="SignIn.aspx.cs" Inherits="cskh.huewaco.vn.SignIn" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register Src="~/Control/ctrlSearchCustomer.ascx" TagPrefix="uc1" TagName="ctrlSearchCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function OnGridFocusedRowChanged() {
            // Query the server for the "EmployeeID" and "Notes" fields from the focused row 
            // The values will be returned to the OnGetRowValues() function
            grdKetQua.GetRowValues(grdKetQua.GetFocusedRowIndex(), 'idkh', OnGetRowValues);
        }
        // Value array contains "EmployeeID" and "Notes" field values returned from the server 
        function OnGetRowValues(values) {
            txtUsername.SetText(values);
        }
    </script>
</asp:Content>
<asp:Content ID="ctnMainPlace" ContentPlaceHolderID="ContentPlace" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UDPLogin" runat="server">
        <ContentTemplate>
            <div class="TitPage" style="margin-left: 8px; margin-right: 8px;">
                <img style="border-width: 0px;" src="Source/ReportIcon.gif" class="icon_image">
                <span class="subNavLink"><% =getString("strSignInTitle").ToUpper()%></span>
            </div>
            <div style="width: 700px; margin: 0px 0 0 20px;">
                <table cellspacing="0" cellpadding="0" border="0" width="100%">
                    <tr>
                        <td>
                            <table cellspacing="2" cellpadding="1" border="0" style="margin: 10px 0 0 0" width="100%">
                                <tbody>
                                    <tr align="left" valign="top">
                                        <td colspan="2">
                                            <div style="margin: 0 0 10px 0; line-height: 19px">
                                                Lưu ý, nếu bạn là khách hàng dùng Nước và đã đăng ký tài khoản trên website thì có thể đăng nhập để việc tra cứu thông tin được thuận tiện hơn
                                            </div>
                                        </td>
                                    </tr>
                                    <tr align="left" valign="top">
                                        <td style="width: 102px; padding-left: 20px"><%= getString("strUsername")%>:</td>
                                        <td style="width: 313px">
                                            <dx:ASPxTextBox ID="txtUsername" ClientInstanceName="txtUsername" runat="server" Width="180px"></dx:ASPxTextBox>
                                            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" Display="Dynamic" ControlToValidate="txtUsername" ErrorMessage="*" ValidationGroup="Login" ForeColor="Red" />
                                        </td>
                                    </tr>
                                    <tr align="left" valign="top">
                                        <td style="width: 102px; padding-left: 20px"><%= getString("strPassword")%>:</td>
                                        <td style="width: 313px">
                                            <dx:ASPxTextBox ID="txtPassword" runat="server" Width="180px" Password="True"></dx:ASPxTextBox>
                                        </td>
                                    </tr>
                                    <%--<tr align="left" valign="top" class="font33">
                                <td style="width: 102px"><%= getString("strAuthorCode")%>:</Mã xác thực:</Mã xác thực:</td>
                                <td style="width: 313px">
                                    <asp:TextBox ID="txtVerifyCode" runat="server" Width="180px"  />
                                    <cc1:CaptchaControl ID="ccJoin"
                                    runat="server" 
                                    CaptchaBackgroundNoise="Extreme" 
                                    CaptchaLength="4" 
                                    CaptchaHeight="31" 
                                    CaptchaWidth="90" 
                                    CaptchaMinTimeout="5"
                                    CaptchaMaxTimeout="240"/>
                                    <asp:Label ID="Label1" runat="server" style="color: #FF3300"></asp:Label>
                                </td>
                            </tr>--%>
                                    <tr align="left">
                                        <td style="width: 102px"></td>
                                        <td style="width: 313px">
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
                <asp:Button runat="server" ID="btnLogin" CssClass="button cyan validate" Text="Đăng nhập" OnClick="btnLogin_Click" CausesValidation="true" ValidationGroup="Login" />
                <asp:Button runat="server" ID="btnRemindPass" CssClass="button cyan validate" Width="100px" Text="Quên mật khẩu" OnClick="btnRemindPass_Click" CausesValidation="true" ValidationGroup="Login" />
            </div>
               <br />
            <hr />
        </ContentTemplate>
    </asp:UpdatePanel>
    <uc1:ctrlSearchCustomer runat="server" id="ctrlSearchCustomer" />
</asp:Content>
