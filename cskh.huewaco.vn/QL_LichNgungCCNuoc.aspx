<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="QL_LichNgungCCNuoc.aspx.cs" Inherits="cskh.huewaco.vn.QL_LichNgungCCNuoc" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        var lastCountry = null;
        function OnCountryChanged(cmbCountry) {
            if (grdLich.GetEditor("MaLoTrinh").InCallback())
                lastCountry = cmbCountry.GetValue().toString();
            else
                grdLich.GetEditor("MaLoTrinh").PerformCallback(cmbCountry.GetValue().toString());
        }
        function OnEndCallback(s, e) {
            if (lastCountry) {
                grdLich.GetEditor("MaLoTrinh").PerformCallback(lastCountry);
                lastCountry = null;
            }
        }
        var textSeparator = ";";
        function OnListBoxSelectionChanged(listBox, args) {
            if (args.index == 0)
                args.isSelected ? listBox.SelectAll() : listBox.UnselectAll();
            UpdateSelectAllItemState();
            UpdateText();
        }
        function UpdateSelectAllItemState() {
            IsAllSelected() ? checkListBox.SelectIndices([0]) : checkListBox.UnselectIndices([0]);
        }
        function IsAllSelected() {
            var selectedDataItemCount = checkListBox.GetItemCount() - (checkListBox.GetItem(0).selected ? 0 : 1);
            return checkListBox.GetSelectedItems().length == selectedDataItemCount;
        }
        function UpdateText() {
            var selectedItems = checkListBox.GetSelectedItems();
            checkComboBox.SetText(GetSelectedItemsText(selectedItems));
        }
        function SynchronizeListBoxValues(dropDown, args) {
            checkListBox.UnselectAll();
            var texts = dropDown.GetText().split(textSeparator);
            var values = GetValuesByTexts(texts);
            checkListBox.SelectValues(values);
            UpdateSelectAllItemState();
            UpdateText(); // for remove non-existing texts
        }
        function GetSelectedItemsText(items) {
            var texts = [];
            for (var i = 0; i < items.length; i++)
                if (items[i].index != 0)
                    texts.push(items[i].text);
            return texts.join(textSeparator);
        }
        function GetValuesByTexts(texts) {
            var actualValues = [];
            var item;
            for (var i = 0; i < texts.length; i++) {
                item = checkListBox.FindItemByText(texts[i]);
                if (item != null)
                    actualValues.push(item.value);
            }
            return actualValues;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlace" runat="server">
    <div>
        <table>
            <tr height="2px">
                <td></td>
            </tr>
        </table>
    </div>
    <div class="TitPage" style="margin-left: 8px; margin-right: 8px;">
        <img style="border-width: 0px;" src="Images/reg-icon.jpg" class="icon_image">
        <span class="subNavLink">QUẢN LÝ LỊCH CẮT NƯỚC</span>
    </div>

    <div style="margin-left: 5px; margin-right: 5px; margin-bottom: 10px;">
        <table class="dxgvTable_MetropolisBlue">
            <tr>
                <td class="dxgvEditFormCaption_MetropolisBlue">Khu vực
                </td>
                <td class="dxgvEditFormCell_MetropolisBlue">
                    <dx:ASPxComboBox ID="cbKhuvuc" DataSourceID="KhuVucDataSource" TextField="TenKhuVuc" ValueField="MaKV" AutoPostBack="true" runat="server" ValueType="System.String" OnSelectedIndexChanged="cbKhuvuc_SelectedIndexChanged"></dx:ASPxComboBox>
                </td>
                <td class="dxgvEditFormCaption_MetropolisBlue">Mã lộ
                </td>
                <td class="dxgvEditFormCell_MetropolisBlue" colspan="3" style="width: 100%">
                    <dx:ASPxDropDownEdit ClientInstanceName="checkComboBox" ID="drllo" runat="server" AnimationType="None" Width="90%">
                        <DropDownWindowStyle BackColor="#EDEDED" />
                        <DropDownWindowTemplate>
                            <dx:ASPxListBox ID="lblo" ClientInstanceName="checkListBox" SelectionMode="CheckColumn" runat="server" Style="width: 100%">
                                <Border BorderStyle="None" />
                                <BorderBottom BorderStyle="Solid" BorderWidth="1px" BorderColor="#DCDCDC" />
                                <ClientSideEvents SelectedIndexChanged="OnListBoxSelectionChanged" />
                            </dx:ASPxListBox>
                            <table style="width: 100%">
                                <tr>
                                    <td style="padding: 4px">
                                        <dx:ASPxButton ID="ASPxButton1" AutoPostBack="False" runat="server" Text="Xong" Style="float: right">
                                            <ClientSideEvents Click="function(s, e){ checkComboBox.HideDropDown(); }" />
                                        </dx:ASPxButton>
                                    </td>
                                </tr>
                            </table>
                        </DropDownWindowTemplate>
                        <ClientSideEvents TextChanged="SynchronizeListBoxValues" DropDown="SynchronizeListBoxValues" />
                    </dx:ASPxDropDownEdit>
                </td>
            </tr>
            <tr>
                <td class="dxgvEditFormCaption_MetropolisBlue">Ngày bắt đầu</td>
                <td class="dxgvEditFormCell_MetropolisBlue">
                    <dx:ASPxDateEdit runat="server" ID="datebegin" DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" DisplayFormatInEditMode="True">
                        <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="Text" ErrorText="*">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxDateEdit>
                </td>
                <td class="dxgvEditFormCaption_MetropolisBlue">Giờ bắt đầu
                </td>
                <td class="dxgvEditFormCell_MetropolisBlue">
                    <dx:ASPxSpinEdit runat="server" ID="hourbegin" Width="100%" Height="21px" Number="0" MaxValue="23" MinValue="0" ClientInstanceName="GioBatDau">
                    </dx:ASPxSpinEdit>
                </td>
                <td class="dxgvEditFormCaption_MetropolisBlue">Phút bắt đầu
                </td>
                <td class="dxgvEditFormCell_MetropolisBlue">
                    <dx:ASPxSpinEdit runat="server" ID="minbegin" Width="100%" Height="21px" Number="0" ClientInstanceName="PhutKetThuc" MaxValue="59" MinValue="0"></dx:ASPxSpinEdit>
                </td>
            </tr>
            <tr>
                <td class="dxgvEditFormCaption_MetropolisBlue">Ngày kết thúc </td>
                <td class="dxgvEditFormCell_MetropolisBlue">
                    <dx:ASPxDateEdit runat="server" ID="dateend" DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" DisplayFormatInEditMode="True">
                        <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="Text" ErrorText="*">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </dx:ASPxDateEdit>
                </td>
                <td class="dxgvEditFormCaption_MetropolisBlue">Giờ kết thúc
                </td>
                <td class="dxgvEditFormCell_MetropolisBlue">
                    <dx:ASPxSpinEdit runat="server" ID="hourend" Height="21px" Width="100%" Number="0" MaxValue="23" MinValue="0" ClientInstanceName="GioBatDau"></dx:ASPxSpinEdit>
                </td>
                <td class="dxgvEditFormCaption_MetropolisBlue">Phút kết thúc
                </td>
                <td class="dxgvEditFormCell_MetropolisBlue">
                    <dx:ASPxSpinEdit runat="server" ID="minend" Height="21px" Width="100%" Number="0" ClientInstanceName="PhutBatDau" MaxValue="59" MinValue="0"></dx:ASPxSpinEdit>
                </td>
            </tr>
            <tr>
                <td class="dxgvEditFormCaption_MetropolisBlue">Lý do
                </td>
                <td class="dxgvEditFormCell_MetropolisBlue" colspan="3">
                    <dx:ASPxMemo runat="server" ID="mmLydo" Columns="50" Rows="3"></dx:ASPxMemo>
                </td>
                <td class="dxgvEditFormCaption_MetropolisBlue">Sự cố
                </td>
                <td class="dxgvEditFormCell_MetropolisBlue">
                    <dx:ASPxCheckBox runat="server" ID="cbSuco"></dx:ASPxCheckBox>
                </td>
            </tr>
            <tr>
                <td></td>
                <td class="dxgvEditFormCell_MetropolisBlue">
                    <dx:ASPxButton ID="btnLuu" runat="server" Text="Lưu" OnClick="btnLuu_Click"></dx:ASPxButton>
                </td>
            </tr>
        </table>
    </div>

    <div style="margin-left: 5px; margin-right: 5px; margin-bottom: 10px;">
        <dx:ASPxGridView ID="grdLich" ClientInstanceName="grdLich" Font-Size="11pt" class="dxgvTable_MetropolisBlue" DataSourceID="LichDataSource" runat="server" KeyFieldName="ID" EnableRowsCache="False" AutoGenerateColumns="False" Theme="MetropolisBlue" OnCellEditorInitialize="grdLich_OnCellEditorInitialize" OnCustomColumnDisplayText="grdLich_OnCustomColumnDisplayText" Width="100%">
            <SettingsEditing Mode="EditForm"></SettingsEditing>
            <Columns>
                <dx:GridViewCommandColumn ShowNewButtonInHeader="true" ShowDeleteButton="True" ShowEditButton="true" VisibleIndex="0" />
                <%--  <dx:GridViewDataColumn Caption="Mã lộ trình" FieldName="MaLoTrinh" VisibleIndex="1" />--%>
                <dx:GridViewDataComboBoxColumn Caption="Khu vực" FieldName="MaKV"
                    VisibleIndex="4">
                    <EditFormSettings Visible="True" VisibleIndex="1" />
                    <PropertiesComboBox DataSourceID="KhuVucDataSource" TextField="TenKhuVuc" EnableSynchronization="False"
                        ValueField="MaKV">
                        <ClientSideEvents SelectedIndexChanged="function(s, e) { OnCountryChanged(s); }"></ClientSideEvents>
                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="Text">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataComboBoxColumn Caption="Mã lộ" FieldName="MaLoTrinh" Name="MaLoTrinh"
                    VisibleIndex="5">
                    <EditFormSettings ColumnSpan="2" Visible="True" VisibleIndex="2" />
                    <PropertiesComboBox TextField="MaLoTrinh" ValueField="MaLoTrinh" EnableSynchronization="False">
                        <ClientSideEvents EndCallback="OnEndCallback" />
                        <ValidationSettings Display="Dynamic" ErrorDisplayMode="Text">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </PropertiesComboBox>
                </dx:GridViewDataComboBoxColumn>
                <dx:GridViewDataDateColumn Caption="Ngày bắt đầu" FieldName="NgayBatDau" Visible="False" VisibleIndex="1">
                    <EditFormSettings Visible="True" VisibleIndex="3" />
                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" DisplayFormatInEditMode="True">
                        <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="Text" ErrorText="*">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataSpinEditColumn Caption="Giờ bắt đầu" FieldName="GioBatDau" Visible="False" ShowInCustomizationForm="True" VisibleIndex="6">
                    <EditFormSettings Visible="True" VisibleIndex="4" />
                    <PropertiesSpinEdit ClientInstanceName="GioBatDau" MaxValue="23" MinValue="0">
                    </PropertiesSpinEdit>
                </dx:GridViewDataSpinEditColumn>
                <dx:GridViewDataSpinEditColumn Caption="Phút bắt đầu" FieldName="PhutBatDau" Visible="False" ShowInCustomizationForm="True" VisibleIndex="7">
                    <EditFormSettings Visible="True" VisibleIndex="5" />
                    <PropertiesSpinEdit ClientInstanceName="PhutKetThuc" MaxValue="59" MinValue="0">
                    </PropertiesSpinEdit>
                </dx:GridViewDataSpinEditColumn>
                <dx:GridViewDataDateColumn Caption="Ngày kết thúc" FieldName="NgayKetThuc" Visible="False" VisibleIndex="2">
                    <EditFormSettings Visible="True" VisibleIndex="6" />
                    <PropertiesDateEdit DisplayFormatString="dd/MM/yyyy" EditFormat="Custom" DisplayFormatInEditMode="True">
                        <ValidationSettings CausesValidation="True" Display="Dynamic" ErrorDisplayMode="Text" ErrorText="*">
                            <RequiredField IsRequired="True" />
                        </ValidationSettings>
                    </PropertiesDateEdit>
                </dx:GridViewDataDateColumn>
                <dx:GridViewDataSpinEditColumn Caption="Giờ kết thúc" FieldName="GioKetThuc" Visible="False" ShowInCustomizationForm="True" VisibleIndex="8">
                    <EditFormSettings Visible="True" VisibleIndex="7" />
                    <PropertiesSpinEdit ClientInstanceName="GioKetThuc" MaxValue="23" MinValue="0">
                    </PropertiesSpinEdit>
                </dx:GridViewDataSpinEditColumn>
                <dx:GridViewDataSpinEditColumn Caption="Phút kết thúc" FieldName="PhutKetThuc" Visible="False" ShowInCustomizationForm="True" VisibleIndex="9">
                    <EditFormSettings Visible="True" VisibleIndex="8" />
                    <PropertiesSpinEdit ClientInstanceName="PhutKetThuc" MaxValue="59" MinValue="0">
                    </PropertiesSpinEdit>
                </dx:GridViewDataSpinEditColumn>
                <dx:GridViewDataMemoColumn Caption="Lý do" FieldName="LyDo" Visible="False" VisibleIndex="3">
                    <EditFormSettings ColumnSpan="2" Visible="True" VisibleIndex="8" />
                </dx:GridViewDataMemoColumn>
                <dx:GridViewDataCheckColumn Caption="Sự cố" FieldName="SuCo" Visible="False" VisibleIndex="10">
                    <EditFormSettings Visible="True" VisibleIndex="9" />
                </dx:GridViewDataCheckColumn>

            </Columns>
            <Templates>
                <DetailRow>
                    <div>
                      <b>Lý do: </b><%#Eval("LyDo") %>
                    </div>
                </DetailRow>
            </Templates>

            <SettingsPager AlwaysShowPager="True" EnableAdaptivity="True">
                <AllButton Visible="True">
                </AllButton>
            </SettingsPager>
            <SettingsEditing EditFormColumnCount="3" />
            <Settings ShowFilterRow="True" ShowGroupPanel="False" />
            <SettingsText CommandEdit="Sửa" CommandNew="Thêm" CommandDelete="X&#243;a"
                CommandCancel="Bỏ qua" CommandUpdate="Lưu"></SettingsText>
            <SettingsDetail ShowDetailButtons="True" AllowOnlyOneMasterRowExpanded="True" ShowDetailRow="True"></SettingsDetail>
        </dx:ASPxGridView>
    </div>

    <asp:SqlDataSource ID="KhuVucDataSource" runat="server"
        ConnectionString="<%$ ConnectionStrings:huewaco %>"
        SelectCommand="Select * from tblKhuVuc"></asp:SqlDataSource>

    <asp:SqlDataSource ID="LichDataSource" runat="server"
        ConnectionString="<%$ ConnectionStrings:huewaco %>"
        SelectCommand="SELECT * FROM tblLichCatNuoc ORDER BY NgayBatDau DESC"
        InsertCommand="insert into tblLichCatNuoc (MaLoTrinh,MaKV,NgayBatDau,GioBatDau,PhutBatDau,NgayKetThuc,GioKetThuc,PhutKetThuc,Lydo,SuCo) values (@MaLoTrinh,@MaKV,@NgayBatDau,@GioBatDau,@PhutBatDau,@NgayKetThuc,@GioKetThuc,@PhutKetThuc,@Lydo,@SuCo)"
        UpdateCommand="Update tblLichCatNuoc set MaLoTrinh=@MaLoTrinh,MaKV = @MaKV, NgayBatDau=@NgayBatDau, GioBatDau = @GioBatDau, PhutBatDau=@PhutBatDau,NgayKetThuc=@NgayKetThuc, GioKetThuc=@GioKetThuc,PhutKetThuc= @PhutKetThuc, LyDo=@LyDo,SuCo=@SuCo where ID=@ID"
        DeleteCommand="delete tblLichCatNuoc where ID=@ID">
        <DeleteParameters>
            <asp:Parameter Name="ID" Type="Int32" />
        </DeleteParameters>
        <UpdateParameters>
            <asp:Parameter Name="MaLoTrinh" Type="String" />
            <asp:Parameter Name="MaKV" Type="String" />
            <asp:Parameter Name="NgayBatDau" Type="DateTime" />
            <asp:Parameter Name="GioBatDau" Type="Int32" />
            <asp:Parameter Name="PhutBatDau" Type="Int32" />
            <asp:Parameter Name="NgayKetThuc" Type="DateTime" />
            <asp:Parameter Name="GioKetThuc" Type="Int32" />
            <asp:Parameter Name="PhutKetThuc" Type="Int32" />
            <asp:Parameter Name="Lydo" Type="String" />
            <asp:Parameter Name="SuCo" Type="Boolean" />
            <asp:SessionParameter Name="ID" SessionField="ID" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="MaLoTrinh" Type="String" />
            <asp:Parameter Name="MaKV" Type="String" />
            <asp:Parameter Name="NgayBatDau" Type="DateTime" />
            <asp:Parameter Name="GioBatDau" Type="Int32" />
            <asp:Parameter Name="PhutBatDau" Type="Int32" />
            <asp:Parameter Name="NgayKetThuc" Type="DateTime" />
            <asp:Parameter Name="GioKetThuc" Type="Int32" />
            <asp:Parameter Name="PhutKetThuc" Type="Int32" />
            <asp:Parameter Name="Lydo" Type="String" />
            <asp:Parameter Name="SuCo" Type="Boolean" />
        </InsertParameters>
    </asp:SqlDataSource>

    <%--<asp:SqlDataSource ID="DetailDataSource" runat="server"
        ConnectionString="<%$ ConnectionStrings:huewaco %>"
        SelectCommand="Select * from tblLichChiTiet Where IDLich = @IDLich"
        UpdateCommand="update tblLichChiTiet set GioBatDau = @GioBatDau, PhutBatDau=@PhutBatDau, GioKetThuc=@GioKetThuc,PhutKetThuc= @PhutKetThuc, LyDo=@LyDo where ID=@ID"
        InsertCommand="insert into tblLichChiTiet (IDLich,GioBatDau,PhutBatDau,GioKetThuc,PhutKetThuc,LyDo) values (@IDLich,@GioBatDau,@PhutBatDau,@GioKetThuc,@PhutKetThuc,@LyDo)"
        DeleteCommand="delete tblLichChiTiet where ID = @ID"
        ProviderName="System.Data.SqlClient">
        <SelectParameters>
            <asp:SessionParameter Name="IDLich" SessionField="IDLich" Type="Int32" />
        </SelectParameters>
        <UpdateParameters>
            <asp:Parameter Name="GioBatDau" Type="Int32" />
            <asp:Parameter Name="PhutBatDau" Type="Int32" />
            <asp:Parameter Name="GioKetThuc" Type="Int32" />
            <asp:Parameter Name="PhutKetThuc" Type="Int32" />
            <asp:Parameter Name="Lydo" Type="String" />
            <asp:SessionParameter Name="IDLich" SessionField="IDLich" Type="Int32" />
        </UpdateParameters>
        <InsertParameters>
            <asp:Parameter Name="GioBatDau" Type="Int32" />
            <asp:Parameter Name="PhutBatDau" Type="Int32" />
            <asp:Parameter Name="GioKetThuc" Type="Int32" />
            <asp:Parameter Name="PhutKetThuc" Type="Int32" />
            <asp:Parameter Name="Lydo" Type="String" />
            <asp:SessionParameter Name="IDLic/ield="IDLich" Type="Int32" />
        </InsertParameters>
    </asp:SqlDataSource>--%>
</asp:Content>
