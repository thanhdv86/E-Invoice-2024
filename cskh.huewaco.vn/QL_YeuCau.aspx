<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="QL_YeuCau.aspx.cs" Inherits="cskh.huewaco.vn.QL_YeuCau" %>

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
                <span class="subNavLink">QUẢN LÝ YÊU CẦU</span>
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
                        <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataComboBoxColumn Caption="Loại YC" FieldName="LoaiYC"
                            Name="LoaiYC" ReadOnly="True" VisibleIndex="6" Width="15%">
                            <PropertiesComboBox TextField="LoaiYC"
                                ValueField="LoaiYC">
                                <Items>
                                    <dx:ListEditItem Text="Lắp mới" Value="YCCM" />
                                    <dx:ListEditItem Text="Ngắn hạn" Value="YCNH" />
                                    <dx:ListEditItem Text="Sửa chữa" Value="YCSC" />

                                </Items>
                            </PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataColumn Caption="Tên khách hàng" FieldName="TenKH" VisibleIndex="1" />
                        <dx:GridViewDataColumn Caption="Số nhà" FieldName="SoNha" VisibleIndex="2" />
                        <dx:GridViewDataColumn Caption="Đường phố" FieldName="DuongPho" VisibleIndex="3" />
                        <dx:GridViewDataColumn Caption="Điện thoại" FieldName="SDT" VisibleIndex="4" />
                        <dx:GridViewDataColumn Caption="Email" FieldName="Email" VisibleIndex="5" />
                        <dx:GridViewDataColumn Caption="Xử lý" FieldName="XuLy" VisibleIndex="8" />
                        <dx:GridViewDataDateColumn Caption="Ngày gửi" FieldName="NgayTao" VisibleIndex="7">
                            <PropertiesDateEdit DisplayFormatString="">
                            </PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
                    </Columns>
                    <Templates>
                        <DetailRow>
                            <div>
                                <b>Nội dung yêu cầu:</b> <%#Eval("NoiDung") %>
                            </div>
                            <div>
                                <b>Nội dung xử lý:</b> <%#Eval("XuLy") %>
                            </div>
                        </DetailRow>
                    </Templates>
                    <Settings ShowFilterRow="True" />
                    <SettingsDetail ShowDetailRow="true" />
                    <SettingsText CommandEdit="Sửa" CommandDelete="Xóa"
                        CommandCancel="Bỏ qua" CommandUpdate="Lưu"></SettingsText>
                </dx:ASPxGridView>

                <asp:SqlDataSource ID="YeucauDatasource" runat="server"
                    ConnectionString="<%$ ConnectionStrings:huewaco %>"
                    SelectCommand="Select * from tblYeuCau order by NgayTao desc"
                    UpdateCommand="update tblYeuCau set XuLy = @XuLy where ID=@ID">
                    <UpdateParameters>
                        <asp:Parameter Name="XuLy" />
                        <asp:Parameter Name="ID" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource ID="KhuVucDataSource" runat="server"
                    ConnectionString="<%$ ConnectionStrings:huewaco %>"
                    SelectCommand="Select * from tblKhuVuc"></asp:SqlDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
