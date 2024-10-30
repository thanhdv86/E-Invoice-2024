<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="LichGhiChiSo.aspx.cs" Inherits="cskh.huewaco.vn.LichGhiChiSo" %>

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
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlace" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UDPLICH" runat="server">
        <ContentTemplate>
            <div style="height: 5px"></div>
            <div class="TitPage" style="margin-left: 8px; margin-right: 8px">
                <img style="border-width: 0px;" src="Source/ReportIcon.gif" class="icon_image"><span class="subNavLink">LỊCH GHI CHỈ SỐ ĐỒNG HỒ NƯỚC</span>
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
                                <td width="35%">

                                    <dx:ASPxTextBox runat="server" ClientInstanceName="txtCustomerCode" ID="txtCustomerCode" Width="180px" />
                                </td>
                                <td colspan="1">
                                    <span class="validate_rightCol">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtCustomerCode" SetFocusOnError="True" ValidationGroup="VAL" Style="color: Red" ErrorMessage="Nhập mã khách hàng" />
                                    </span>
                                </td>
                            </tr>
                            <tr>
                                <td>Từ ngày:</td>
                                <td>
                                    <dx:ASPxDateEdit ID="datFrom" runat="server" AutoPostBack="false" EditFormat="Custom" EditFormatString="dd/MM/yyyy" Width="100px" Font-Size="11px" Font-Names="Verdana">
                                        <CalendarProperties ShowClearButton="False" ShowTodayButton="False">
                                            <WeekNumberStyle BackColor="White" Font-Bold="True" ForeColor="#0033CC">
                                                <Border BorderStyle="Solid" />
                                            </WeekNumberStyle>
                                        </CalendarProperties>
                                    </dx:ASPxDateEdit>
                                </td>
                                <td>Đến ngày:</td>
                                <td>
                                    <dx:ASPxDateEdit ID="datTo" runat="server" AutoPostBack="false" EditFormat="Custom" EditFormatString="dd/MM/yyyy" Width="100px" Font-Size="11px" Font-Names="Verdana">
                                        <CalendarProperties ShowClearButton="False" ShowTodayButton="False">
                                            <WeekNumberStyle BackColor="White" Font-Bold="True" ForeColor="#0033CC">
                                                <Border BorderStyle="Solid" />
                                            </WeekNumberStyle>

                                        </CalendarProperties>
                                    </dx:ASPxDateEdit>
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
                <dx:ASPxGridView ID="grvLich" OnDataBound="grvLich_OnDataBound" ClientInstanceName="grvLich" EnableRowsCache="False" KeyFieldName="idkh" runat="server" Width="100%" AutoGenerateColumns="False" OnDataBinding="grvLich_DataBinding">
                    <Columns>
                        <dx:GridViewDataColumn Caption="Số danh bộ" FieldName="sodb" VisibleIndex="0" />
                        <dx:GridViewDataColumn Caption="Tên khách hàng" FieldName="tenkh" VisibleIndex="1" />
                        <dx:GridViewDataColumn Caption="Tháng" FieldName="thang" VisibleIndex="2" />
                        <dx:GridViewDataColumn Caption="Năm" FieldName="nam" VisibleIndex="3" />
                        <dx:GridViewDataColumn Caption="Ngày GCS tháng trước" FieldName="ngaynhap_tt" VisibleIndex="5">
                            <CellStyle HorizontalAlign="Right"></CellStyle>

                        </dx:GridViewDataColumn>
                        <dx:GridViewDataColumn Caption="Ngày GCS" FieldName="ngaynhap" VisibleIndex="4" >
                             <CellStyle HorizontalAlign="Right"></CellStyle>
                        </dx:GridViewDataColumn>
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
