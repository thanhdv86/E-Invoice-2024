<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="QL_NguoiDung.aspx.cs" Inherits="cskh.huewaco.vn.QL_NguoiDung" %>

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
                <span class="subNavLink">QUẢN LÝ NGƯỜI DÙNG</span>
            </div>

            <div style="margin-left: 5px; margin-right: 5px">
                <div style="text-align: center">
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel_Search" DisplayAfter="1">
                        <ProgressTemplate>
                            <img alt="" width="50px" src="Images/processing.gif" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
                <dx:ASPxGridView ID="grvNguoiDung" ClientInstanceName="grvNguoiDung" DataSourceID="NguoiDungDataSource" runat="server" KeyFieldName="IdKh" Width="100%" EnableRowsCache="False" AutoGenerateColumns="False" Theme="MetropolisBlue">
                    <Columns>
                        <dx:GridViewCommandColumn ShowNewButtonInHeader="False" ShowDeleteButton="True" ShowEditButton="True" VisibleIndex="0" ShowApplyFilterButton="True" />
                        <dx:GridViewDataColumn Caption="Mã khách hàng" FieldName="IdKh" VisibleIndex="1">
                            <Settings AutoFilterCondition="Contains"></Settings>
                        </dx:GridViewDataColumn>
                        <dx:GridViewDataColumn Caption="Tên khách hàng" FieldName="TenKhachHang" VisibleIndex="2">
                            <Settings AutoFilterCondition="Contains"></Settings>
                        </dx:GridViewDataColumn>
                        <dx:GridViewDataColumn Caption="Tên đăng nhập" FieldName="Username" VisibleIndex="3">
                            <Settings AutoFilterCondition="Contains"></Settings>
                        </dx:GridViewDataColumn>
                        <dx:GridViewDataColumn Caption="Địa chỉ" FieldName="DiaChi" VisibleIndex="4">
                            <Settings AutoFilterCondition="Contains"></Settings>
                        </dx:GridViewDataColumn>

                        <dx:GridViewDataColumn Caption="SĐT" FieldName="SDT" VisibleIndex="5">
                            <Settings AutoFilterCondition="Contains"></Settings>
                        </dx:GridViewDataColumn>

                    </Columns>
                    <Settings ShowFilterRow="True" ShowFilterRowMenu="True" />
                    <SettingsPopup>
                        <EditForm Width="600" />
                    </SettingsPopup>
                    <SettingsEditing Mode="EditForm"></SettingsEditing>
                    <SettingsText CommandEdit="Sửa" CommandNew="Thêm" CommandDelete="X&#243;a"
                        CommandCancel="   Bỏ qua" CommandUpdate="Lưu"></SettingsText>
                </dx:ASPxGridView>

                <asp:SqlDataSource ID="NguoiDungDataSource" runat="server"
                    ConnectionString="<%$ ConnectionStrings:huewaco %>"
                    SelectCommand="Select * from tblUsers"
                    DeleteCommand="delete from tblUsers where IdKh = @IdKh"
                    UpdateCommand="Update tblUsers set DiaChi = @DiaChi where IdKh=@IdKh">                    
                    <UpdateParameters>
                        <asp:Parameter Name="DiaChi" />
                        <asp:Parameter Name="IdKh" />
                    </UpdateParameters>
                    </asp:SqlDataSource>
                <asp:SqlDataSource ID="KhuVucDataSource" runat="server"
                    ConnectionString="<%$ ConnectionStrings:huewaco %>"
                    SelectCommand="Select * from tblKhuVuc"></asp:SqlDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
