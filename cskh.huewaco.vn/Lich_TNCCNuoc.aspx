<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="Lich_TNCCNuoc.aspx.cs" Inherits="cskh.huewaco.vn.Lich_TNCCNuoc" %>

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
                <img style="border-width: 0px;" src="Source/ReportIcon.gif" class="icon_image"><span class="subNavLink">THÔNG BÁO CẤP NƯỚC</span>
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
                                    <dx:ASPxTextBox runat="server" ClientInstanceName="txtCustomerCode" ID="txtCustomerCode" Width="180px" />
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
                <asp:Button runat="server" CssClass="button cyan validate" Text="Xem lịch" ID="btnXem" OnClick="btnXem_OnClick" />
            </div>
            <div style="text-align: center">

                <asp:UpdateProgress runat="server" ID="UpdateProgressDK" AssociatedUpdatePanelID="UDPLICH" DisplayAfter="0" DynamicLayout="True">
                    <ProgressTemplate>
                        <img alt="" width="50px" src="Images/processing.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
            <div style="margin-left: 8px; margin-right: 8px; margin-top: 5px">
                <dx:ASPxGridView ID="grvLich" OnDataBound="grvLich_OnDataBound" OnCustomColumnDisplayText="grvLich_OnCustomColumnDisplayText" DataSourceID="LichDataSource" ClientInstanceName="grvLich" EnableRowsCache="False" runat="server" Width="100%" KeyFieldName="ID" AutoGenerateColumns="False">
                    <Templates>
                        <PreviewRow>
                            Lý do:   
                            <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text='<%# Eval("LyDo") %>'></dx:ASPxLabel>
                        </PreviewRow>
                    </Templates>
                    <Columns>
                        <dx:GridViewDataColumn Caption="Mã lộ trình" Width="150px" FieldName="MaLoTrinh" VisibleIndex="1" />
                        <dx:GridViewDataColumn Caption="Bắt đầu" VisibleIndex="2">
                            <DataItemTemplate>
                                <%# Eval("GioBatDau") %> h : <%# Eval("PhutBatDau") %> phút : ngày <%# Convert.ToDateTime(Eval("NgayBatDau")).ToString("dd/MM/yyyy") %>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>
                        <dx:GridViewDataColumn Caption="Kết thúc" VisibleIndex="3">
                            <DataItemTemplate>
                                <%# Eval("GioKetThuc") %> h : <%# Eval("PhutKetThuc") %> phút : ngày <%# Convert.ToDateTime(Eval("NgayKetThuc")).ToString("dd/MM/yyyy") %>
                            </DataItemTemplate>
                        </dx:GridViewDataColumn>
                    </Columns>
                    <Styles>
                        <Row>
                            <font size="10" bold="True"></font>
                        </Row>
                        <Header BackColor="#0096DF" ForeColor="white">
                            <font bold="True" size="12"></font>
                        </Header>
                    </Styles>

                    <SettingsLoadingPanel Text="Đang tải dữ liệu"></SettingsLoadingPanel>
                    <SettingsText EmptyDataRow="Chưa có lịch cắt nước trong khoảng thời gian trên"></SettingsText>
                    <SettingsDetail ShowDetailRow="True"></SettingsDetail>
                    <SettingsPager PageSize="10"></SettingsPager>
                    <SettingsBehavior AllowSort="False"></SettingsBehavior>
                    <Settings ShowPreview="true" />
                </dx:ASPxGridView>
                <asp:SqlDataSource runat="server" ID="LichDataSource"
                    ConnectionString="<%$ ConnectionStrings:huewaco %>"
                    SelectCommand="SELECT * FROM dbo.tblLichCatNuoc lich WHERE lich.MaKV  = @MAKV and (NgayBatDau BETWEEN @DateFrom and @DateTo)  order by NgayBatDau desc">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="datFrom" DbType="DateTime" Name="DateFrom" />
                        <asp:ControlParameter ControlID="datTo" DbType="DateTime" Name="DateTo" />
                        <asp:SessionParameter SessionField="MAKV" Name="MAKV" DbType="String" />
                    </SelectParameters>

                </asp:SqlDataSource>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
    <uc1:ctrlSearchCustomer runat="server" id="ctrlSearchCustomer" />
</asp:Content>
