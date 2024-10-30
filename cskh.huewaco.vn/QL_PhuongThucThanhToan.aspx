<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="QL_PhuongThucThanhToan.aspx.cs" Inherits="cskh.huewaco.vn.QL_PhuongThucThanhToan" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function OnUpdateClick() {
            fileUpload.UploadFile();
            grvThanhToan.UpdateEdit();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlace" runat="server">
    <div class="TitPage" style="margin-left: 8px; margin-right: 8px">
        <img style="border-width: 0px;" src="Images/reg-icon.jpg" class="icon_image">
        <span class="subNavLink">QUẢN LÝ PHƯƠNG THỨC THANH TOÁN</span>
    </div>
    <dx:ASPxGridView ID="grvThanhToan" ClientInstanceName="grvThanhToan" EnableRowsCache="False" DataSourceID="ThanhToanDataSource"  OnRowInserting="grvThanhToan_OnRowInserting" OnRowUpdating="grvThanhToan_OnRowUpdating"
        runat="server" KeyFieldName="ID" Width="100%" AutoGenerateColumns="False" Theme="MetropolisBlue">
        <Columns>
            <dx:GridViewCommandColumn ShowNewButtonInHeader="true" ShowDeleteButton="True" ShowEditButton="true" VisibleIndex="0" Width="10%" />
            <dx:GridViewDataTextColumn Caption="Tiêu đề" FieldName="TieuDe" VisibleIndex="1" Width="60%"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Ngày tạo" FieldName="NgayTao" VisibleIndex="2" Width="10%">
                <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy"></PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataMemoColumn FieldName="NoiDung" Visible="False" />
        </Columns>
        <Templates>
            <EditForm>
                <div style="padding: 4px 4px 3px 4px; width: 600px">
                    <table>
                        <tr>
                            <td>Tiêu đề:</td>
                            <td>
                                <dx:ASPxTextBox runat="server" ID="txtTieuDe" MaxLength="500" Text='<%# Bind("TieuDe")%>' Width="100%"></dx:ASPxTextBox>
                            </td>
                        </tr>

                        <tr>
                            <td>Tóm tắt:</td>
                            <td>
                                <dx:ASPxMemo runat="server" Rows="5" ID="txtTomTat" MaxLength="500" Text='<%# Bind("TomTat")%>' Width="100%"></dx:ASPxMemo>
                            </td>
                        </tr>

                        <tr>
                            <td>Nội dung:</td>
                            <td>
                                <dx:ASPxHtmlEditor ID="htmlNoiDung" Width="650px" Html='<%# Bind("NoiDung")%>' runat="server"></dx:ASPxHtmlEditor>
                            </td>
                        </tr>
                          <tr>
                            <td>Hình ảnh:</td>
                            <td>
                                <img src="Images/PTTT/<%#Eval("LinkHinh") %>" height="100px"/>
                            </td>
                        </tr>

                        <tr>
                            <td>Upload file:</td>
                            <td>
                                <dx:ASPxUploadControl ID="fileUpload" Width="650px"  runat="server" ClientInstanceName="fileUpload"  OnFileUploadComplete="ASPxUploadControl1_FileUploadComplete">
                                    <ValidationSettings AllowedFileExtensions=".jpg,.jpeg,.jpe,.png" MaxFileSize="4000000">
                                    </ValidationSettings>
                                  
                                </dx:ASPxUploadControl>
                            </td>
                        </tr>
                    </table>
                </div>
                <div style="text-align: right; padding: 2px 2px 2px 2px">
                     <a href="#" onclick="OnUpdateClick()">Lưu</a> 
                    <dx:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton"
                        runat="server"></dx:ASPxGridViewTemplateReplacement>
                </div>
            </EditForm>
        </Templates>

        <SettingsBehavior AllowSort="False"></SettingsBehavior>
        <SettingsEditing Mode="EditFormAndDisplayRow"></SettingsEditing><SettingsText CommandEdit="Sửa" CommandDelete="Xóa" CommandNew="Thêm"
            CommandCancel="Bỏ qua" CommandUpdate="Lưu"></SettingsText>
        <Styles>
            <Header Font-Bold="True">
            </Header>
        </Styles>
    </dx:ASPxGridView>

    <asp:SqlDataSource ID="ThanhToanDataSource" runat="server"
        ConnectionString="<%$ ConnectionStrings:huewaco %>"
        SelectCommand="SELECT * FROM dbo.tblPhuongThucTT order by NgayTao Desc"
        InsertCommand="INSERT INTO dbo.tblPhuongThucTT( TieuDe ,NoiDung ,NgayTao,TomTat,LinkHinh) VALUES  ( @TieuDe , @NoiDung , GETDATE(),@TomTat,@LinkHinh)"
        UpdateCommand="UPDATE dbo.tblPhuongThucTT SET TieuDe=@TieuDe ,NoiDung=@NoiDung,TomTat=@TomTat,LinkHinh=@LinkHinh WHERE ID = @ID"
        DeleteCommand="Delete from tblPhuongThucTT where ID = @ID"
        ProviderName="System.Data.SqlClient">
        <UpdateParameters>
            <asp:Parameter Name="TieuDe" Type="String" />
            <asp:Parameter Name="TomTat" Type="String" />
            <asp:Parameter Name="NoiDung" Type="String" />
            <asp:Parameter Name="LinkHinh" Type="String" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="TieuDe" Type="String" />
            <asp:Parameter Name="TomTat" Type="String" />
            <asp:Parameter Name="NoiDung" Type="String" />
            <asp:Parameter Name="LinkHinh" Type="String" />
        </InsertParameters>
    </asp:SqlDataSource>
</asp:Content>
