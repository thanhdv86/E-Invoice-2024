<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="QL_QuayThu.aspx.cs" Inherits="cskh.huewaco.vn.QL_QuayThu" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnMainPlace" ContentPlaceHolderID="ContentPlace" runat="Server">
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
                <span class="subNavLink">QUẢN LÝ QUẦY THU</span>
            </div>

            <div style="margin-left: 5px; margin-right: 5px">
                <div style="text-align: center">
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel_Search" DisplayAfter="1">
                        <ProgressTemplate>
                            <img alt="" width="50px" src="Images/processing.gif" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
                <dx:ASPxGridView ID="grdDiemThu" ClientInstanceName="grid" DataSourceID="DiemThuDataSource" runat="server" KeyFieldName="ID" Width="100%" EnableRowsCache="False" AutoGenerateColumns="False" Theme="MetropolisBlue">
                    <Columns>
                        <dx:GridViewCommandColumn ShowNewButtonInHeader="true" ShowDeleteButton="True" ShowEditButton="true" VisibleIndex="0" />
                        <dx:GridViewDataColumn Caption="Tên quầy thu" FieldName="TenQuayThu" VisibleIndex="1" />
                        <dx:GridViewDataColumn Caption="Địa chỉ" FieldName="DiaChi" VisibleIndex="2" />
                        <dx:GridViewDataColumn Caption="Ghi chú" FieldName="GhiChu" VisibleIndex="3" />
                        <dx:GridViewDataComboBoxColumn Caption="Khu vực" FieldName="MaKV"
                            Name="TenKhuVuc"  VisibleIndex="4" Width="15%">
                            <PropertiesComboBox DataSourceID="KhuVucDataSource" TextField="TenKhuVuc"
                                ValueField="MaKV"></PropertiesComboBox>
                        </dx:GridViewDataComboBoxColumn>
                        <dx:GridViewDataColumn Caption="Kinh độ" FieldName="KinhDo" VisibleIndex="5" />
                        <dx:GridViewDataColumn Caption="Vĩ độ" FieldName="ViDo" VisibleIndex="6" />

                    </Columns>
                    <Settings ShowFilterRow="True" ShowFilterRowMenu="True" />
                    <SettingsPopup>
                        <EditForm Width="600" />
                    </SettingsPopup>
                    <SettingsEditing Mode="EditForm"></SettingsEditing>
                    <SettingsText CommandEdit="Sửa" CommandNew="Thêm" CommandDelete="X&#243;a"
                        CommandCancel="Bỏ qua" CommandUpdate="Lưu"></SettingsText>
                </dx:ASPxGridView>
             
                <asp:SqlDataSource ID="DiemThuDataSource" runat="server"
                    ConnectionString="<%$ ConnectionStrings:huewaco %>"
                    SelectCommand="Select * from tblQuayThu"
                    UpdateCommand="UPDATE tblQuayThu SET TenQuayThu=@TenQuayThu, DiaChi=@DiaChi,GhiChu=@GhiChu, MaKV = @MaKV, KinhDo = @Kinhdo, ViDo=@ViDo where ID=@ID"
                    InsertCommand="INSERT INTO dbo.tblQuayThu ( TenQuayThu, DiaChi, GhiChu, MaKV, KinhDo,ViDo) VALUES (@TenQuayThu,@DiaChi,@GhiChu,@MaKV,@KinhDo,@ViDo)"
                    DeleteCommand="delete from tblQuayThu where ID=@ID"
                    ProviderName="System.Data.SqlClient">
                    <UpdateParameters>
                        <%--<asp:Parameter Name="IDDV" Type="String" />--%>
                        <asp:Parameter Name="TenQuayThu" Type="String" />
                        <asp:Parameter Name="DiaChi" Type="String" />
                        <asp:Parameter Name="GhiChu" Type="String" />
                        <asp:Parameter Name="MaKV" Type="String" />
                        <asp:Parameter Name="KinhDo" Type="Double" />
                        <asp:Parameter Name="ViDo" Type="Double" />
                    </UpdateParameters>

                </asp:SqlDataSource>
                <asp:SqlDataSource ID="KhuVucDataSource" runat="server"
                    ConnectionString="<%$ ConnectionStrings:huewaco %>"
                    SelectCommand="Select * from tblKhuVuc"></asp:SqlDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

