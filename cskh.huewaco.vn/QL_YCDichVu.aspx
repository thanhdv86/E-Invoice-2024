<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="QL_YCDichVu.aspx.cs" Inherits="cskh.huewaco.vn.QL_YCDichVu" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlace" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server">
        <ContentTemplate>
            <div>
                <table>
                    <tr height="2px">
                        <td></td>
                    </tr>
                </table>
            </div>
            <div class="TitPage" style="margin-left: 8px; margin-right: 8px">
                <img style="border-width: 0px;" src="Images/reg-icon.jpg" class="icon_image">
                <span class="subNavLink">QUẢN LÝ YÊU CẦU ĐĂNG KÝ SỬ DỤNG DỊCH VỤ</span>
            </div>

            <div style="margin-left: 5px; margin-right: 5px">
                <div style="text-align: center">
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel_Search" DisplayAfter="1">
                        <ProgressTemplate>
                            <img alt="" width="50px" src="Images/processing.gif" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
                <dx:ASPxGridView ID="grdYeuCau" ClientInstanceName="grid" DataSourceID="YeucauDatasource" runat="server" KeyFieldName="ID" Width="100%" EnableRowsCache="False" AutoGenerateColumns="False" Theme="MetropolisBlue" EnableTheming="True">
                    <Columns>
                        <dx:GridViewCommandColumn ShowEditButton="true" ShowDeleteButton="True" VisibleIndex="0" Width="10%" />
                        <dx:GridViewDataComboBoxColumn Caption="Loại DV" FieldName="LoaiDV"
                            Name="LoaiDV" ReadOnly="True" VisibleIndex="7" Width="15%">
                            <PropertiesComboBox TextField="LoaiDV"
                                ValueField="LoaiDV">
                                <Items>
                                    <dx:ListEditItem Text="Tất cả" Value="" />
                                    <dx:ListEditItem Text="Nhận HDĐT qua email" Value="EMAIL" />
                                    <dx:ListEditItem Text="Nhận thông báo qua SMS" Value="SMS" />
                                </Items>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataColumn Caption="Mã KH" FieldName="IDKH" VisibleIndex="1" />
                        <dx:GridViewDataColumn Caption="Tên khách hàng" FieldName="TenKH" VisibleIndex="2" />
                        <dx:GridViewDataColumn Caption="SĐT" FieldName="SDT" VisibleIndex="3" />
                        <dx:GridViewDataColumn Caption="Email" FieldName="Email" VisibleIndex="4" />
                        <dx:GridViewDataColumn Caption="Đã duyệt" FieldName="IsApproved" VisibleIndex="6" />
                        <dx:GridViewDataColumn Caption="Xử lý" FieldName="XuLy" VisibleIndex="8" />
                        <dx:GridViewDataDateColumn Caption="Ngày gửi" FieldName="NgayDK" VisibleIndex="5">
                            <PropertiesDateEdit DisplayFormatString="">
                            </PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
                    </Columns>

                    <Settings ShowFilterRow="True" />

<%--                    <SettingsPager AlwaysShowPager="False" EnableAdaptivity="True">
                        <AllButton Visible="False">
                        </AllButton>
                    </SettingsPager>--%>

                    <SettingsDetail ShowDetailRow="False" />
                    <SettingsText CommandEdit="Sửa" CommandDelete="Xóa"
                        CommandCancel="Bỏ qua" CommandUpdate="Lưu"></SettingsText>
                </dx:ASPxGridView>

                <asp:SqlDataSource ID="YeucauDatasource" runat="server"
                    ConnectionString="<%$ ConnectionStrings:huewaco %>"
                    SelectCommand="Select * from tblDichVu order by NgayDK desc"
                    UpdateCommand="update tblDichVu set IsApproved=@IsApproved, Email=@Email, XuLy = @XuLy where ID=@ID"
                    DeleteCommand="delete tblDichVu where ID=@ID">
                    <UpdateParameters>
                        <asp:Parameter Type="Boolean" Name="IsApproved" />
                        <asp:Parameter Type="String" Name="Email" />
                        <asp:Parameter Type="String" Name="XuLy" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
