<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="QL_CauHoi.aspx.cs" Inherits="cskh.huewaco.vn.QL_CauHoi" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web.ASPxHtmlEditor" Assembly="DevExpress.Web.ASPxHtmlEditor.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlace" runat="server">
    <div class="TitPage" style="margin-left: 8px; margin-right: 8px">
        <img style="border-width: 0px;" src="Images/reg-icon.jpg" class="icon_image">
        <span class="subNavLink">QUẢN LÝ CÂU HỎI</span>
    </div>
    <dx:ASPxGridView ID="grvCauHoi" ClientInstanceName="grvCauHoi" EnableRowsCache="False" DataSourceID="DiemThuDataSource"
        runat="server" KeyFieldName="ID" Width="100%" AutoGenerateColumns="False" Theme="MetropolisBlue">
        <Columns>
            <dx:GridViewCommandColumn ShowEditButton="true" ShowDeleteButton="True" VisibleIndex="0" Width="10%" />
            <dx:GridViewDataTextColumn Caption="Tiêu đề" FieldName="TieuDe" VisibleIndex="1" Width="60%"></dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Ngày gửi" FieldName="NgayTao" VisibleIndex="2" Width="10%">
                <PropertiesTextEdit DisplayFormatString="dd/MM/yyyy"></PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataCheckColumn FieldName="Visible" Caption="Duyệt" VisibleIndex="3" Width="10%">
                <PropertiesCheckEdit DisplayTextChecked="Hiển thị" DisplayTextUnchecked="Không hiển thị">
                </PropertiesCheckEdit>
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataCheckColumn FieldName="ShowTop" Caption="Hiển thị top" VisibleIndex="4" Width="10%">
                <PropertiesCheckEdit DisplayTextChecked="Hiển thị" DisplayTextUnchecked="Không hiển thị">
                </PropertiesCheckEdit>
            </dx:GridViewDataCheckColumn>
            <dx:GridViewDataMemoColumn FieldName="TraLoi" Visible="False" />
        </Columns>

        <Templates>
            <EditForm>
                <div style="padding: 4px 4px 3px 4px">
                    <dx:ASPxCheckBox runat="server" Text="Duyệt tin" ID="cbVisible" Checked='<%# Bind("Visible")%>' />
                    <dx:ASPxCheckBox runat="server" Text="Hiển thị lên mục câu hỏi thường gặp" ID="cbShowTop" Checked='<%# Bind("ShowTop")%>' />
                    <dx:ASPxPageControl runat="server" ID="pageControl" Width="100%">
                        <TabPages>
                            <dx:TabPage Text="Câu hỏi" Visible="true">
                                <ContentCollection>
                                    <dx:ContentControl runat="server">
                                        <table>
                                            <tr>
                                            </tr>
                                            <tr>
                                                <td><b>Tiêu đề:</b></td>
                                                <td>
                                                    <dx:ASPxLabel runat="server" ID="lblTieuDe" Text='<%# Eval("TieuDe")%>'></dx:ASPxLabel>

                                                </td>
                                            </tr>
                                            <tr>
                                                <td><b>Nội dung câu hỏi:</b></td>
                                                <td>
                                                    <dx:ASPxLabel runat="server" ID="lblNoiDung" Text='<%# Eval("NoiDung")%>'></dx:ASPxLabel>

                                                </td>
                                            </tr>
                                             <tr>
                                                <td><b>Thông tin người gửi:</b></td>
                                                <td>
                                                    <dx:ASPxLabel runat="server" ID="ASPxLabel1" Text='<%# Eval("NguoiTao")%>'></dx:ASPxLabel>

                                                </td>
                                            </tr>
                                        </table>

                                    </dx:ContentControl>
                                </ContentCollection>
                            </dx:TabPage>

                        </TabPages>
                        <TabStyle Font-Bold="True"></TabStyle>
                    </dx:ASPxPageControl>
                    <br />
                    <b style="font-size: 14px">Trả lời:</b>
                    <dx:ASPxHtmlEditor runat="server" ID="traloiEditor" Width="100%" EncodeHtml="False" Html='<%# Bind("TraLoi")%>'
                        Height="400px">
                    </dx:ASPxHtmlEditor>
                </div>
                <div style="text-align: right; padding: 2px 2px 2px 2px">
                    <dx:ASPxGridViewTemplateReplacement ID="UpdateButton" ReplacementType="EditFormUpdateButton"
                        runat="server"></dx:ASPxGridViewTemplateReplacement>
                    <dx:ASPxGridViewTemplateReplacement ID="CancelButton" ReplacementType="EditFormCancelButton"
                        runat="server"></dx:ASPxGridViewTemplateReplacement>
                </div>
            </EditForm>
        </Templates>
        <Settings ShowFilterRow="True" />
        <SettingsPopup>
            <EditForm Width="600" Modal="true" />
        </SettingsPopup>
        <SettingsEditing Mode="EditFormAndDisplayRow"></SettingsEditing>
        <SettingsText CommandEdit="Sửa" CommandDelete="Xóa"
            CommandCancel="Bỏ qua" CommandUpdate="Lưu"></SettingsText>
    </dx:ASPxGridView>

    <asp:SqlDataSource ID="DiemThuDataSource" runat="server"
        ConnectionString="<%$ ConnectionStrings:huewaco %>"
        SelectCommand="Select * from tblCauHoi order by NgayTao desc"
        DeleteCommand="delete from tblCauHoi where ID=@ID"
        UpdateCommand="update tblCauHoi set TraLoi = @TraLoi, ShowTop = @ShowTop, Visible = @Visible where ID = @ID"
        ProviderName="System.Data.SqlClient">
        <UpdateParameters>
            <asp:Parameter Name="TraLoi" Type="String" />
            <asp:Parameter Name="ShowTop" Type="Boolean" />
            <asp:Parameter Name="Visible" Type="Boolean" />
        </UpdateParameters>
    </asp:SqlDataSource>

</asp:Content>
