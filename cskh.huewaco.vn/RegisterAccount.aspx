<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="RegisterAccount.aspx.cs" Inherits="cskh.huewaco.vn.RegisterAccount" %>

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
            txtContractNumber.SetText(values);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlace" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UDPDangKy" runat="server">
        <ContentTemplate>
            <div class="TitPage" style="margin-left: 8px; margin-right: 8px; margin-top: 20px">
                <img style="border-width: 0px;" src="Source/ReportIcon.gif" class="icon_image">
                <span class="subNavLink">ĐĂNG KÝ TÀI KHOẢN WEBSITE</span>
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
                                                Nếu bạn đã có mã số khách hàng dùng nước, nhưng chưa đăng ký tài khoản trên website, xin vui lòng đăng ký thông tin bên dưới để thuận tiện truy cập website hơn về sau
                                            </div>
                                        </td>
                                    </tr>
                                    <tr align="left" valign="top">
                                        <td style="width: 102px; padding-left: 20px">Mã khách hàng:</td>
                                        <td style="width: 300px">
                                            <dx:ASPxTextBox ID="txtContractNumber" ClientInstanceName="txtContractNumber" runat="server" Width="180px" MaxLength="13" ValidationGroup="REG"></dx:ASPxTextBox>
                                            <asp:RequiredFieldValidator ID="rfvMaKH" runat="server" ErrorMessage="*" Display="Dynamic" ControlToValidate="txtContractNumber" ValidationGroup="REG" ForeColor="Red" />
                                        </td>

                                    </tr>
                                    <tr align="left" valign="top">
                                        <td style="padding-left: 20px">Tên đăng nhập:</td>
                                        <td style="width: 300px">
                                            <dx:ASPxTextBox ID="txtTenDangNhap" MaxLength="20" runat="server" Width="180px" ValidationGroup="REG"></dx:ASPxTextBox>
                                            <asp:RequiredFieldValidator ID="rfvTenDangNhap" runat="server" Display="Dynamic" ControlToValidate="txtTenDangNhap" ErrorMessage="*" ValidationGroup="REG" ForeColor="Red" />
                                            <asp:RegularExpressionValidator ID="revTenDangNhap" ValidationGroup="REG" runat="server" Display="Dynamic" ControlToValidate="txtTenDangNhap" ErrorMessage="*" ValidationExpression="^[a-zA-Z0-9]+([._]?[a-zA-Z0-9]+)*$" ForeColor="Red">Tên đăng nhập chỉ bao gồm các ký tự hoặc các ký số.</asp:RegularExpressionValidator>
                                        </td>

                                    </tr>
                                    <tr align="left" valign="top">
                                        <td style="padding-left: 20px">Mật khẩu:</td>
                                        <td style="width: 300px">
                                            <dx:ASPxTextBox ID="txtMatKhau" runat="server" Width="180px" Password="True" ValidationGroup="REG"></dx:ASPxTextBox>
                                            <asp:RequiredFieldValidator ID="frvMatKhau" runat="server" Display="Dynamic" ControlToValidate="txtMatKhau" ErrorMessage="*" ValidationGroup="REG" ForeColor="Red" />
                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" 
                                ControlToValidate="txtPassword" 
                                ErrorMessage="mật khẩu từ 6-32 ký tự gồm [0_9][a_z] và dấu &quot;_&quot;" 
                                ForeColor="Red" ValidationExpression="\w{6,32}"></asp:RegularExpressionValidator>--%>
                                            <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="Txtpass" ErrorMessage="*" ValidationExpression=".{8}.*">Tối thiểu 8 ký tự</asp:RegularExpressionValidator>--%>
                                        </td>
                                    </tr>
                                    <tr align="left" valign="top">
                                        <td style="padding-left: 20px">Nhập lại mật khẩu:</td>
                                        <td style="width: 300px">
                                            <dx:ASPxTextBox ID="txtVerifyPassword" runat="server" Width="180px" Password="True" ValidationGroup="REG"></dx:ASPxTextBox>
                                            <asp:RequiredFieldValidator ID="rfvVerifyPassword" runat="server" Display="Dynamic" ControlToValidate="txtVerifyPassword" ErrorMessage="*" ValidationGroup="REG" ForeColor="Red" />
                                        </td>
                                    </tr>
                                    <tr style="display: None">
                                        <td></td>
                                        <td style="width: 300px">
                                            <asp:CompareValidator ID="cvlVerifyPassword" runat="server" ControlToCompare="txtMatKhau" ControlToValidate="txtVerifyPassword" ErrorMessage="Mật mã / Nhập lại mật mã không khớp. Vui lòng kiểm tra lại." ValidationGroup="REG" ForeColor="Red" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td style="width: 300px">
                                            <asp:Label runat="server" ID="lbError" ForeColor="Red"></asp:Label>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="text-align: center">
                <asp:UpdateProgress runat="server" ID="UpdateProgressDK" AssociatedUpdatePanelID="UDPDangKy" DisplayAfter="0" DynamicLayout="True">
                    <ProgressTemplate>
                        <img alt="" width="50px" src="Images/processing.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
            <div style="padding-left: 340px; padding-top: 10px">
                <asp:Button runat="server" ID="btnRegister" CssClass="button cyan validate" Text="Đăng ký" ValidationGroup="REG" OnClick="btnRegister_OnClick" />
            </div>
            <br />
            <hr />
        </ContentTemplate>
    </asp:UpdatePanel>
    <uc1:ctrlSearchCustomer runat="server" id="ctrlSearchCustomer" />
    
</asp:Content>
