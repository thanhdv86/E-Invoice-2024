<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="ThongtinKhachhang.aspx.cs" Inherits="cskh.huewaco.vn.ThongtinKhachhang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnMainPlace" ContentPlaceHolderID="ContentPlace" Runat="Server">
    <div style="margin:0 0 0 5px">
        <div style="margin:0px 10px 0 5px; font-family:Tahoma; font-size:12px; line-height:23px; text-align:justify">
            <asp:ScriptManager ID="ScriptManager1" runat="server"/>   
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server">
        <ContentTemplate>
    <div>
        <table>
            <tr height = 2px>
                <td></td>
            </tr>
        </table>
    </div>
    
    <div class="TitPage" style="margin-left:8px; margin-right:8px">
        <img style="border-width:0px;" src="Source/ReportIcon.gif" class="icon_image">
        <span class="subNavLink">THAY ĐỔI THÔNG TIN KHÁCH HÀNG</span>
    </div>
    
    <div style="margin-left:5px; margin-right:5px">
        <fieldset class="Fieldset_border">
            <legend align="left">
                <span class="Fieldset_title_text">Thông tin hiện tại của khách hàng</span>                
            </legend>
            <div class="box_space" style="padding-top:10px; padding-bottom:5px">
                <table cellpadding=2 cellspacing=0>
                    <tr>
                        <td width = "200px">Mã khách hàng:</td>
                        <td>
                            <asp:Label runat = "server" ID = "lblMA_KHANG"  Font-Names = "Arial" Font-Size = "12px"></asp:Label>
                            
                        </td>
                    </tr>
                    <tr>
                        <td>Tên khách hàng:</td>
                        <td>
                            <asp:Label runat = "server" ID = "lblTEN_KHANG" Font-Names = "Arial" Font-Size = "12px"></asp:Label>                                                    
                        </td>
                    </tr>   
                    <tr>
                        <td>Địa chỉ:</td>
                        <td>
                            <asp:Label runat = "server" ID = "lblAddress" Font-Names = "Arial" Font-Size = "12px"></asp:Label>
                        </td>
                    </tr> 
                    <tr>
                        <td>Số điện thoại:</td>
                        <td>
                            <asp:Label runat = "server" ID = "lblTel" Font-Names = "Arial" Font-Size = "12px"></asp:Label>
                        </td>
                    </tr>                    
                </table>
            </div>
        </fieldset>
    </div>
    <div style="margin-left:5px; margin-right:5px">
        <fieldset class="Fieldset_border">
            <legend align="left">
                <span class="Fieldset_title_text">Thông tin khách hàng cần thay đổi</span>                
            </legend>
            <div class="box_space" style="padding-top:10px; padding-bottom:5px">
                <table cellpadding=2 cellspacing=0>                    
                    <tr>
                        <td width = "200px">Tên khách hàng:</td>
                        <td>
                            <asp:TextBox runat = "server" ID ="txtTEN_KHANG" Font-Names = "Arial" Font-Size = "12px" Width = "200px"/>
                        </td>
                    </tr>   
                    <tr>
                        <td>Địa chỉ:</td>
                        <td>
                            <asp:TextBox runat = "server" ID ="txtDIACHI" Font-Names = "Arial" Font-Size = "12px" Width = "380px"/>                                                    
                        </td>
                    </tr> 
                   <tr>
                        <td>SĐT:</td>
                        <td>
                            <asp:TextBox runat = "server" ID ="txtSDT" Font-Names = "Arial" Font-Size = "12px" Width = "380px"/>                                                    
                        </td>
                    </tr> 
                </table>
            </div>
        </fieldset>
    </div>
    <div style="padding-left:8px; padding-top: 10px">
        <asp:Button runat="server" ID="btnGui" Width="100px" OnClick="btnGui_OnClick" CssClass="button cyan validate" 
            Text = "Gửi yêu cầu" />
        
    </div>   
    
    </ContentTemplate>
    </asp:UpdatePanel> 
        </div>
    </div>    
</asp:Content>
