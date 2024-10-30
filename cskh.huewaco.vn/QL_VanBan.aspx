<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="QL_VanBan.aspx.cs" Inherits="cskh.huewaco.vn.QL_VanBan" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function OnUpdateClick() {
            uploader.UploadFile();
            grvCauHoi.UpdateEdit();}
    </script><style type="text/css">
        .note {
            color: black;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlace" runat="server">
    <div class="TitPage" style="margin-left: 8px; margin-right: 8px">
        <img style="border-width: 0px;" src="Images/reg-icon.jpg" class="icon_image">
        <span class="subNavLink">QUẢN LÝ VĂN BẢN</span>
    </div>
    <dx:ASPxGridView ID="grvCauHoi" ClientInstanceName="grvCauHoi" EnableRowsCache="False" DataSourceID="VanBanDataSource"
        runat="server" KeyFieldName="ID" Width="100%" AutoGenerateColumns="False" Theme="MetropolisBlue" OnRowInserting="grvCauHoi_OnRowInserting"  OnRowUpdating="grvCauHoi_OnRowUpdating">
        <Columns>
            <dx:GridViewCommandColumn ShowNewButtonInHeader="true" ShowDeleteButton="True" ShowEditButton="true" VisibleIndex="0" Width="10%" />
            <dx:GridViewDataTextColumn Caption="Tiêu đề" FieldName="TieuDe" VisibleIndex="1" Width="60%"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="KieuVB" Caption="Loại VB"></dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn Caption="Ngày cập nhật" FieldName="NgayCapNhat" VisibleIndex="3">
                <PropertiesDateEdit DisplayFormatString="">
                </PropertiesDateEdit>
            </dx:GridViewDataDateColumn>
        </Columns>
        <Templates>
            <EditForm>
                <div style="padding: 4px 4px 3px 4px; width: 600px">
                    <table>
                        <tr>
                            <td style="width: 20%">Tiêu đề:</td>
                            <td style="width: 80%">
                                <dx:ASPxTextBox runat="server" ID="txtTieuDe" MaxLength="500" Text='<%# Bind("TieuDe")%>' Width="100%"></dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%">File hiện tại:</td>
                            <td>
                                <dx:ASPxLabel runat="server" Text='<%#Eval("FileLink") %>'></dx:ASPxLabel>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%">Upload file khác:</td>
                            <td>
                                <dx:ASPxUploadControl runat="server" ClientInstanceName="uploader" Size="35" ID="ASPxUploadControl1" OnFileUploadComplete="ulFile_OnFileUploadComplete">
                                    <ValidationSettings AllowedFileExtensions=".doc,.pdf,.docx,.xls,.xlsx" MaxFileSize="4000000">
                                    </ValidationSettings>
                              
                                </dx:ASPxUploadControl>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 20%">Loại văn bản:</td>
                            <td>
                                <dx:ASPxComboBox runat="server" ID="ddlLoai" Value='<%#Bind("LoaiVB") %>'>
                                    <Items>
                                        <dx:ListEditItem Text="Nhà nước" Value="NN" />
                                        <dx:ListEditItem Text="Tỉnh" Value="TI" />
                                        <dx:ListEditItem Text="Công ty" Value="CT" />
                                    </Items>
                                </dx:ASPxComboBox>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="text-align: right; padding: 2px 2px 2px 2px">
                    <a href="#" onclick="OnUpdateClick()">Cập nhật</a> 
                    <dx:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton"
                        runat="server"></dx:ASPxGridViewTemplateReplacement>
                </div>
            </EditForm>
        </Templates>
        <SettingsPopup>
            <EditForm Width="600" Modal="true" />
        </SettingsPopup>
        <SettingsBehavior AllowSort="False"></SettingsBehavior>
        <SettingsEditing Mode="EditFormAndDisplayRow"></SettingsEditing>
        <SettingsText CommandEdit="Sửa" CommandDelete="Xóa" CommandNew="Thêm"
            CommandCancel="Bỏ qua" CommandUpdate="Lưu"></SettingsText>
        <Styles>
            <Header Font-Bold="True">
            </Header>
        </Styles>
    </dx:ASPxGridView>

    <asp:SqlDataSource ID="VanBanDataSource" runat="server"
        ConnectionString="<%$ ConnectionStrings:huewaco %>"
        SelectCommand="Select *, (SELECT CASE LoaiVB WHEN 'CT' THEN N'Công ty' WHEN 'NN' THEN N'Nhà nước' WHEN 'TI' THEN N'Tỉnh' END) AS KieuVB  from tblVanBan order by NgayCapNhat DESC, LoaiVB"
        InsertCommand="INSERT INTO dbo.tblVanBan( TieuDe, FileLink ,LoaiVB, NgayCapNhat) VALUES  ( @TieuDe ,@FileLink , @LoaiVB, GetDate())"
        UpdateCommand="UPDATE dbo.tblVanBan SET TieuDe=@TieuDe ,FileLink =@FileLink,LoaiVB=@LoaiVB, NgayCapNhat=GetDate() WHERE ID = @ID"
        DeleteCommand="delete from tblVanBan where ID = @ID"
        ProviderName="System.Data.SqlClient">
        <UpdateParameters>
            <asp:Parameter Name="TieuDe" Type="String" />
            <asp:Parameter Name="FileLink" Type="String" />
            <asp:Parameter Name="LoaiVB" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="TieuDe" Type="String" />
            <asp:Parameter Name="FileLink" Type="String" />
            <asp:Parameter Name="LoaiVB" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>
