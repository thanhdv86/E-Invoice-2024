<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlSearchCustomer.ascx.cs" Inherits="cskh.huewaco.vn.Control.ctrlSearchCustomer" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<script>
    function ValidateKeypress(numcheck, e) {
        var keynum, keychar;
        if (window.event) {//IE
            keynum = e.keyCode;
        }
        else if (e.which) {// Netscape/Firefox/Opera
            keynum = e.which;
        }
        if (keynum == 8 || keynum == 127 || keynum == null || keynum == 9 || keynum == 0 || keynum == 13) return true;
        keychar = String.fromCharCode(keynum);
        var result = numcheck.test(keychar);
        return result;
    }
    //function PerformCallbackControl(s, e) {

    //}
</script>
<asp:UpdatePanel ID="UDPSearch" runat="server">
    <ContentTemplate>
        <div>
            <div style="margin: 10px 0 0 0px; padding: 5px 5px 5px 5px">
                <asp:LinkButton ID="lnkShowSearch" runat="server" OnClick="lnkShowSearch_OnClick">Tìm tên đăng ký theo tên khách hàng</asp:LinkButton>
            </div>
            <div id="Timten" runat="server" visible="False">
                <table border="0"
                    style="font-size: 11px; margin: 10px 0 10px 10px">

                        <tr align="left">
                            <td>Chi nhánh:</td>
                            <td>
                                <asp:DropDownList ID="ddlKhuVuc" runat="server" Height="20px" Width="220px" DataValueField="MAKV"
                                    DataTextField="TENKV" Font-Size="11px">
                                </asp:DropDownList>

                            </td>
                            <td rowspan="7" style="text-align: left">
                            <div class="box_space" style="padding-left: 25px">
                                <b>Nhập mã xác thực</b>
                                <dx:ASPxCaptcha runat="server" ID="Captcha">
                                    <TextBoxStyle Width="110px" />
                                    <ValidationSettings SetFocusOnError="False" ErrorText="" />
                                    <RefreshButton Text="Hiện mã khác"></RefreshButton>
                                    <TextBox LabelText="Nhập mã bên cạnh:" />
                                    <ChallengeImage ForegroundColor="#000000">
                                    </ChallengeImage>
                                </dx:ASPxCaptcha>
                            </div>                                
                            </td>
                        </tr>
                        <tr align="left">
                            <td>Quận (Huyện):</td>
                            <td>
                                <asp:DropDownList ID="ddlQuan" runat="server" Height="20px" Width="220px" DataValueField="MAQUAN"
                                    DataTextField="TENQUAN"
                                    AutoPostBack="True" Font-Size="11px" OnSelectedIndexChanged="ddlQuan_SelectedIndexChanged">
                                </asp:DropDownList>
                            </td>                            
                        </tr>
                        <tr align="left">
                            <td>Phường (Xã):</td>
                            <td>
                                <asp:DropDownList ID="ddlPhuong" runat="server" Height="20px" Width="220px" DataValueField="MAPHUONG"
                                    DataTextField="TENPHUONG" Font-Size="11px">
                                </asp:DropDownList>

                            </td>
                        </tr>                    
                    <tr>
                        <td style="text-align: left">Tên khách hàng</td>
                        <td>
                            <asp:TextBox runat="server" ID="TxtTenKH" Width="215px" Font-Size="11px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">Số điện thoại</td>
                        <td>
                            <asp:TextBox runat="server" ID="TxtSDT" Width="215px" Font-Size="11px" />
                        </td>
                    </tr>
                    <%--                    <tr>
                        <td style="text-align: left">Số CMND</td>
                        <td>
                            <asp:TextBox runat="server" ID="TxtCMND" Width="215px" Font-Size="11px" onkeypress="return ValidateKeypress(/\d/,event);" />
                        </td>
                    </tr>
                        --%>
                    <tr>
                        <td style="text-align: left">Số nhà</td>
                        <td>
                            <asp:TextBox runat="server" ID="TxtSoNha" Width="215px" Font-Size="11px" />
                        </td>
                    </tr>
                    <tr>
                        <td style="text-align: left">Tên đường phố</td>
                        <td>
                            <asp:TextBox runat="server" ID="TxtTenDuongPho" Width="215px" Font-Size="11px" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" style="text-align: center">
                            <asp:Button ID="btnTim" runat="server" CssClass="button cyan validate" OnClick="btnTim_OnClick" Text="Tìm kiếm" />
                        </td>
                    </tr>
                </table>
                <div style="text-align: center">
                    <asp:UpdateProgress runat="server" ID="UpdateProgress" AssociatedUpdatePanelID="UDPSearch" DisplayAfter="0" DynamicLayout="True">
                        <ProgressTemplate>
                            <img alt="" src="../Images/processing.gif" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
            </div>
        </div>
        <dx:ASPxGridView ID="grdKetQua" EnableRowsCache="False" OnDataBinding="grdKetQua_OnDataBinding" ClientVisible="False" ClientInstanceName="grdKetQua" runat="server" Width="100%" KeyFieldName="idkh" AutoGenerateColumns="False" Theme="MetropolisBlue">
            <Columns>
                <dx:GridViewDataColumn Caption="Mã khách hàng" FieldName="idkh" VisibleIndex="0">
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="Tên khách hàng" FieldName="tenkh" VisibleIndex="1" />
                <dx:GridViewDataColumn Caption="Số điện thoại" FieldName="sodt" VisibleIndex="2" />
                <dx:GridViewDataColumn Caption="Địa chỉ" FieldName="diachi" VisibleIndex="3" />                
            </Columns>
            <ClientSideEvents FocusedRowChanged="function(s, e) { OnGridFocusedRowChanged(); }" />
            <SettingsPager PageSize="10"></SettingsPager>
            <SettingsBehavior AllowFocusedRow="True" />
        </dx:ASPxGridView>
    </ContentTemplate>
</asp:UpdatePanel>
