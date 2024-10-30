<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="Gopy.aspx.cs" Inherits="cskh.huewaco.vn.Gopy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnMainPlace" ContentPlaceHolderID="ContentPlace" runat="server">

  
    <div style="height: 5px">
    </div>
    <div class="TitPage" style="margin-left: 8px; margin-right: 8px">
        <img style="border-width: 0px;" src="Source/ReportIcon.gif" class="icon_image">
        <span class="subNavLink">Đóng góp ý kiến</span>
    </div>
    <div style="margin: 0px 0 0 20px;">
        <table border="0" runat="server" style="padding-left: 100px">

            <tr align="left">
                <td>Tên khách hàng</td>
                <td>
                    <asp:TextBox runat="server" ClientIDMode="Static" ID="TxtTenKH" Width="215px" />
                    <span class="text_label" style="color: red">(*)</span>
                    <asp:RequiredFieldValidator runat="server" Display="Dynamic" ControlToValidate="TxtTenKH" ErrorMessage=" Nhập tên" ValidationGroup="Submit" ForeColor="Red" />
                </td>
            </tr>
            <tr align="left">
                <td>Địa chỉ khách hàng</td>
                <td>
                    <asp:TextBox runat="server" TextMode="MultiLine" Rows="3" ID="txtDiaChi" Width="215px" />
                </td>
            </tr>
            <tr align="left">
                <td>Số ĐT</td>
                <td>
                    <asp:TextBox runat="server" ID="txtSDT" Width="215px" />
                    <span class="text_label" style="color: red">(*)</span>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtSDT" ErrorMessage=" Nhập SĐT" ValidationGroup="Submit" ForeColor="Red" />
                </td>
            </tr>
            <tr align="left">
                <td>Email</td>
                <td>
                    <asp:TextBox runat="server" ID="txtEmail" ClientIDMode="Static" Width="215px" />
                </td>
            </tr>
            <tr align="left">
                <td>Nội dung góp ý</td>
                <td>
                    <asp:TextBox runat="server" ClientIDMode="Static" TextMode="MultiLine" Rows="5" ID="txtNoiDung" Width="300px" />
                    <span  class="text_label" style="color: red">(*)</span>
                    <asp:RequiredFieldValidator  runat="server" Display="Dynamic" ControlToValidate="txtNoiDung" ErrorMessage=" Nhập nội dung" ValidationGroup="Submit" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr></tr>
            <tr align="left">
                <td></td>
                <td>
                    <asp:Label runat="server" ForeColor="Red" Text="Vui lòng nhập thông tin số Nước thoại hoặc email để chúng tôi có thể liên hệ lại với khách hàng" Width="400" />
                </td>
            </tr>
            <tr align="right">
                <td></td>
                <td>
                    <asp:Button runat="server" ID="btnGui" ClientIDMode="Static" ValidationGroup="Submit" CssClass="button cyan validate" Text="Gửi" OnClick="btnGui_OnClick" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
