<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="QL_YeuCauTDThongTin.aspx.cs" Inherits="cskh.huewaco.vn.QL_YeuCauTDThongTin" %>
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
                        <dx:GridViewDataColumn Caption="Tên khách hàng" FieldName="TenKhachHang" VisibleIndex="1" PropertiesEditType="TextBox" />
                        <dx:GridViewDataColumn Caption="Xử lý" FieldName="XuLy" VisibleIndex="3" PropertiesEditType="TextBox" />
                        <dx:GridViewDataDateColumn Caption="Ngày gửi" FieldName="NgayGui" VisibleIndex="2">
                            <PropertiesDateEdit DisplayFormatString="">
                            </PropertiesDateEdit>
                        </dx:GridViewDataDateColumn>
                    </Columns>
                    <Templates>
                        <DetailRow>
                            <div>
                                <table>
                                    <tr>
                                        <td colspan="3">
                                            <b>Thông tin hiện tại:</b> 
                                        </td>
                                    </tr>
                                    <tr>
                                        <td></td>
                                        <td><b>Tên KH:</b> <%#Eval("TenKhachHang") %></td>
                                        <td><b>Địa chỉ</b>  <%#Eval("DiaChi") %></td>
                                        <td><b>SĐT:</b>  <%#Eval("SDT") %></td>
                                    </tr>
                                </table>
                              
                            </div>
                               <table>
                                    <tr>
                                        <td colspan="3">
                                            <b>Thông tin yêu cầu thay đổi:</b>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td> </td>
                                        <td><b>Tên KH:</b> <%#Eval("TenMoi") %></td>
                                        <td><b>Địa chỉ mới:</b>  <%#Eval("DiaChiMoi") %></td>
                                        <td><b>SĐT mới:</b>  <%#Eval("SDTMoi") %></td>
                                    </tr>
                                </table>
                            </div>

                        </DetailRow>
                    </Templates>
                    <Settings ShowFilterRow="True" />
                    <SettingsText CommandCancel="Bỏ qua" CommandEdit="Sửa" CommandUpdate="Lưu" />
                    <SettingsDetail ShowDetailRow="true" />
                    
                </dx:ASPxGridView>

                <asp:SqlDataSource ID="YeucauDatasource" runat="server"
                    ConnectionString="<%$ ConnectionStrings:huewaco %>"
                    SelectCommand="SELECT ID,us.TenKhachHang,us.DiaChi,us.SDT,yc.TenKhachHang TenMoi,yc.DiaChi DiaChiMoi, yc.SDT SDTMoi,NgayGui, yc.XuLy FROM dbo.tblYeuCauDoiThongTin yc 
JOIN dbo.tblUsers us ON us.IdKh = yc.IDKH  ORDER BY NgayGui DESC" 
                    UpdateCommand="Update dbo.tblYeuCauDoiThongTin Set XuLy=@XuLy Where ID=@ID">                    
                    <UpdateParameters>
                        <asp:Parameter Name="XuLy" />
                        <asp:Parameter Name="ID" />
                    </UpdateParameters>
                </asp:SqlDataSource>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
