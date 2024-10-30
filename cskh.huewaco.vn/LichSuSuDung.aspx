<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="LichSuSuDung.aspx.cs" Inherits="cskh.huewaco.vn.LichSuSuDung" %>

<%@ Import Namespace="System.Globalization" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register Src="~/Control/ctrlSearchCustomer.ascx" TagPrefix="uc1" TagName="ctrlSearchCustomer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function OnGridFocusedRowChanged() {
            // Query the server for the "EmployeeID" and "Notes" fields from the focused row 
            // The values will be returned to the OnGetRowValues() function
            if (grdKetQua.GetFocusedRowIndex() > -1) {
                grdKetQua.GetRowValues(grdKetQua.GetFocusedRowIndex(), 'idkh', OnGetRowValues);
            }
        }
        // Value array contains "EmployeeID" and "Notes" field values returned from the server 
        function OnGetRowValues(values) {

            txtCustomerCode.SetText(values);

        }
    </script>

    <script type="text/javascript">
        $(function () {
            reload();
        });
        function reload() {
            grvLich.Refresh();
            grdDetail.Refresh();
        }
    </script>
</asp:Content>
<asp:Content ID="ctnMainPlace" ContentPlaceHolderID="ContentPlace" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UDPLICH" runat="server">

        <ContentTemplate>
            <div style="height: 5px"></div>
            <div class="TitPage" style="margin-left: 8px; margin-right: 8px">
                <img style="border-width: 0px;" src="Source/ReportIcon.gif" class="icon_image"><span class="subNavLink">LỊCH SỬ SỬ DỤNG NƯỚC</span>
            </div>
            <div style="margin-left: 8px; margin-right: 8px; margin-top: 20px">
                <fieldset class="Fieldset_border">
                    <legend align="left">
                        <span class="Fieldset_title_text">Vui lòng nhập thông tin</span>
                    </legend>
                    <div class="box_space" style="padding-top: 10px; padding-bottom: 5px">
                        <table cellpadding="5" cellspacing="0" width="100%">
                            <tr>
                                <td width="15%">Mã khách hàng:</td>
                                <td width="35%" colspan="3">
                                    <dx:ASPxTextBox runat="server" ClientInstanceName="txtCustomerCode" ValidationGroup="VAL" ID="txtCustomerCode" Width="180px" />
                                </td>
                                <td>
                                    <span class="validate_rightCol">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtCustomerCode" SetFocusOnError="True" ValidationGroup="VAL" Style="color: Red" ErrorMessage="Nhập mã khách hàng" />
                                    </span>
                                </td>
                            </tr>
                        </table>
                    </div>
                </fieldset>
            </div>
            <div style="margin-left: 8px; margin-right: 8px; margin-top: 5px">
                <asp:Button runat="server" CssClass="button cyan validate" Text="Xem lịch" ID="btnXem" ValidationGroup="VAL" OnClick="btnXem_OnClick" />
            </div>
            <div style="text-align: center">

                <asp:UpdateProgress runat="server" ID="UpdateProgressDK" AssociatedUpdatePanelID="UDPLICH" DisplayAfter="0" DynamicLayout="True">
                    <ProgressTemplate>
                        <img alt="" width="50px" src="Images/processing.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
            <div style="margin-left: 8px; margin-right: 8px; margin-top: 5px">
                <dx:ASPxGridView ID="grvLich" OnDataBound="grvLich_OnDataBound" ClientInstanceName="grvLich" EnableRowsCache="False" runat="server" Width="100%" AutoGenerateColumns="False" OnDataBinding="grvLich_DataBinding">
                    
                    <Columns>
                        <dx:GridViewDataColumn Caption="Tháng" FieldName="thang" VisibleIndex="1" />
                        <dx:GridViewDataColumn Caption="Năm" FieldName="nam" VisibleIndex="2" />
                        <dx:GridViewDataColumn Caption="M3 tiêu thụ" FieldName="kltieuthu" VisibleIndex="3" />
                        <dx:GridViewDataColumn Caption="Tổng tiền" FieldName="tongtien" VisibleIndex="4">
                            <DataItemTemplate>
                                <dx:ASPxLabel ID="lblAmount" runat="server" Text='<%#double.Parse(Eval("tongtien").ToString()).ToString("0,0", CultureInfo.CreateSpecificCulture("el-GR")) %>' />
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>
                        <dx:GridViewDataTextColumn Caption="TT Thanh toán" VisibleIndex="5" >
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                            <DataItemTemplate>
                                <asp:Label runat="server" Visible='<%#(bool)Eval("hetNo") %>' Text="Hết nợ"></asp:Label>
                                <asp:Label runat="server" Visible='<%#!(bool)Eval("hetNo") %>' Text="Còn nợ"></asp:Label>
                            </DataItemTemplate>
                        </dx:GridViewDataTextColumn>
                    </Columns>
                    <Styles>
                        <Header BackColor="#0096DF" ForeColor="white" HorizontalAlign="Center">
                            <font bold="True" size="10"></font>
                        </Header>
                    </Styles>
                    <SettingsPager PageSize="12"></SettingsPager>
                       <SettingsText EmptyDataRow="Không có dữ liệu"></SettingsText>
                    <SettingsLoadingPanel Text="Đang tải dữ liệu"></SettingsLoadingPanel>
                    <SettingsBehavior AllowSort="True"></SettingsBehavior>
                </dx:ASPxGridView>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
    <uc1:ctrlSearchCustomer runat="server" id="ctrlSearchCustomer" />
</asp:Content>
