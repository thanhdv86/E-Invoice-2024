<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="QL_YeuCauBaocaoSuco.aspx.cs" Inherits="cskh.huewaco.vn.QL_YeuCauBaocaoSuco" %>

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
                <span class="subNavLink">QUẢN LÝ BÁO CÁO SỰ CỐ</span>
            </div>

            <div style="margin-left: 5px; margin-right: 5px">
                <div style="text-align: center">
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel_Search" DisplayAfter="1">
                        <ProgressTemplate>
                            <img alt="" width="50px" src="Images/processing.gif" />
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </div>
                <dx:ASPxGridView ID="grdBaocaoSuco" ClientInstanceName="grid" DataSourceID="BaocaoSucoDatasource" runat="server" KeyFieldName="Id" Width="100%" EnableRowsCache="False" AutoGenerateColumns="False" Theme="MetropolisBlue" EnableTheming="True">
                    <Columns>
                        <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0">
                        </dx:GridViewCommandColumn>
                        <dx:GridViewDataColumn Caption="Tên khách hàng" FieldName="TenKH" VisibleIndex="1" />
                        <dx:GridViewDataColumn Caption="SĐT" FieldName="SDT" VisibleIndex="2" /> 
                        <dx:GridViewDataColumn Caption="Địa chỉ" FieldName="DiaChi" VisibleIndex="3" />
                        <dx:GridViewDataDateColumn Caption="Ngày gửi" FieldName="NgayTao" VisibleIndex="4">
                            <PropertiesDateEdit DisplayFormatString="dd/mm/yyyy">
                            </PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
                        <dx:GridViewDataCheckColumn FieldName="IsDuyet">
                            <PropertiesCheckEdit AllowGrayed="true" AllowGrayedByClick="false" />
                        </dx:GridViewDataCheckColumn>
                    </Columns>
                    <Templates>
                        <DetailRow>
                            <dx:ASPxGridView ID="Details_Grid" runat="server" AutoGenerateColumns="False" ClientInstanceName="Details_Grid" KeyFieldName="IdSuco"
                                Theme="Metropolis" Width="100%" DataSourceID="adsProducts" OnBeforePerformDataSelect="Details_Grid_BeforePerformDataSelect">
                                <Templates>
                                    <DataRow>
                                        <div style="padding: 5px">
                                            <table class="templateTable">
                                                <tr>
                                                    <td class="imageCell" rowspan="4">
                                                        <dx:ASPxImage ID="ASPxImage1" runat="server" ImageUrl='<%# Eval("DuongDan") %>' Width="550px" Height="350px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </div>
                                    </DataRow>
                                </Templates>
                                <SettingsBehavior AllowSelectSingleRowOnly="True" />
                                <Settings ShowColumnHeaders="False" />
                            </dx:ASPxGridView>
                        </DetailRow>
                    </Templates>
                    <Settings ShowFilterRow="True" />
                    <SettingsText CommandCancel="Bỏ qua" CommandEdit="Duyệt" CommandUpdate="Lưu" />
                    <SettingsEditing Mode="EditForm"></SettingsEditing>
                    <SettingsDetail ShowDetailRow="true" />

                </dx:ASPxGridView>

                <asp:SqlDataSource ID="BaocaoSucoDatasource" runat="server"
                    ConnectionString="<%$ ConnectionStrings:huewaco %>"
                    SelectCommand="Select t1.Id, t1.TenKH, t1.SDT, t1.IsDuyet, t1.SoNha +', ' + t1.DuongPho +', ' + d.TenDonVi as DiaChi
                                    , t1.NgayTao, t1.IsDuyet
                                    from tblBaocaoSuco t1
                                    left join tblDonViDiaChinh d on t1.MaPhuong = d.MaPhuong
                                    order by t1.NgayTao desc"
                    UpdateCommand="Update dbo.tblBaocaoSuco Set IsDuyet=@IsDuyet Where Id=@Id">
                    <UpdateParameters>
                        <asp:Parameter Name="IsDuyet" />
                        <asp:Parameter Name="Id" />
                    </UpdateParameters>
                </asp:SqlDataSource>
                <asp:SqlDataSource runat="server" ConnectionString="<%$ ConnectionStrings:huewaco %>" ID="adsProducts" SelectCommand="Select t1.IdSuco, t2.DuongDan
                                                                from tblSuco_File t1 
                                                                join tblFileAnhSuco t2 on t1.IdFileAnh = t2.Id
                                                                where (t1.IdSuco = @IdSuco)">
                    <SelectParameters>
                        <asp:SessionParameter Name="IdSuco" SessionField="Id" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
