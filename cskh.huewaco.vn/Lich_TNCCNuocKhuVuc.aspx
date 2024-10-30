<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="Lich_TNCCNuocKhuVuc.aspx.cs" Inherits="cskh.huewaco.vn.Lich_TNCCNuocKhuVuc" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript">
        $(function () {
            reload();
        });
        function reload() {
            grdKetQua.Refresh();
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlace" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UDPMain" runat="server" ClientIDMode="Static">
        <ContentTemplate>
            <div style="height: 5px"></div>
            <div class="TitPage" style="margin-left: 8px; margin-right: 8px">
                <img style="border-width: 0px;" src="Source/ReportIcon.gif" class="icon_image"><span class="subNavLink">THÔNG BÁO CẤP NƯỚC THEO KHU VỰC</span>
            </div>
            <div style="margin-left: 8px; margin-right: 8px; margin-top: 20px">
                <fieldset class="Fieldset_border">
                    <legend align="left">
                        <span class="Fieldset_title_text">Vui lòng nhập thông tin</span>
                    </legend>
                    <div class="box_space" style="padding-top: 10px; padding-bottom: 5px">
                        <table cellpadding="5" cellspacing="0" width="100%">
                            <tr>
                                <td width="25%">Khu vực (Chi nhánh):</td>
                                <td width="25%">
                                    <asp:DropDownList runat="server" ID="ddlKhuVuc" OnDataBound="ddlKhuVuc_OnDataBound" AutoPostBack="True" OnSelectedIndexChanged="ddlKhuVuc_OnSelectedIndexChanged" Width="148px" DataTextField="TENKV" DataValueField="MAKV" />
                                </td>
                                <td width="15%">Mã lộ trình:</td>
                                <td width="25%">
                                    <asp:DropDownList runat="server"  ID="ddlLoTrinh" Width="200px" DataTextField="tenduongpho" DataValueField="maduongpho">
                                    </asp:DropDownList>

                                </td>
                            </tr>
                            <tr>
                                <td width="25%">Từ ngày:</td>
                                <td width="25%">
                                    <dx:ASPxDateEdit ID="datFrom" runat="server" AutoPostBack="false" ClientInstanceName="datFrom" EditFormat="Custom" EditFormatString="dd/MM/yyyy" Width="100px" Font-Size="11px" Font-Names="Verdana">
                                        <CalendarProperties ShowClearButton="False" ShowTodayButton="False">
                                            <WeekNumberStyle BackColor="White" Font-Bold="True" ForeColor="#0033CC">
                                                <Border BorderStyle="Solid" />
                                            </WeekNumberStyle>
                                        </CalendarProperties>
                                    </dx:ASPxDateEdit>
                                </td>
                                <td width="15%">Đến ngày:</td>
                                <td width="25%">
                                    <dx:ASPxDateEdit ID="datTo" runat="server" AutoPostBack="false" ClientInstanceName="datTo" EditFormat="Custom" EditFormatString="dd/MM/yyyy" Width="100px" Font-Size="11px" Font-Names="Verdana">
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
                <input type="button" value="Xem" onclick="reload();" class="button cyan validate" />
            </div>
            <%-- <div style="text-align: center">

                <asp:UpdateProgress runat="server" ID="UProcessing" AssociatedUpdatePanelID="UDPMain" DisplayAfter="0" DynamicLayout="True">
                    <ProgressTemplate>
                        <img alt="" width="50px" src="Images/processing.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>--%>

            <div style="margin-left: 8px; margin-right: 8px; margin-top: 5px">
                <dx:ASPxGridView ID="grdKetQua" OnDataBound="grdKetQua_OnDataBound" OnCustomColumnDisplayText="grdKetQua_OnCustomColumnDisplayText" DataSourceID="LichDataSource" ClientInstanceName="grdKetQua" EnableRowsCache="False" runat="server" Width="100%" KeyFieldName="ID" AutoGenerateColumns="False" PreviewFieldName="LyDo">
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
                    <%-- <Templates>
                        <DetailRow>

                            <dx:ASPxGridView ID="grdDetail" ClientInstanceName="grdDetail" DataSourceID="DetailDataSource" runat="server" KeyFieldName="ID" Width="100%" EnableRowsCache="False" AutoGenerateColumns="False" OnBeforePerformDataSelect="grdDetail_OnBeforePerformDataSelect">
                                <Columns>
                                    <dx:GridViewDataColumn Caption="Bắt đầu" FieldName="BatDau" Width="20%" />
                                    <dx:GridViewDataColumn Caption="Kết thúc" FieldName="KetThuc" Width="20%" />
                                    <dx:GridViewDataColumn Caption="Lý do" FieldName="LyDo" Width="60%" />
                                </Columns>
                                <SettingsLoadingPanel Mode="Disabled"></SettingsLoadingPanel>
                                <SettingsText EmptyDataRow="Chưa có lịch cắt nước trong khoảng thời gian trên"></SettingsText>
                                <SettingsBehavior AllowSort="False"></SettingsBehavior>
                                <Styles>
                                    <Header BackColor="#0096DF" ForeColor="white">
                                    </Header>
                                    <AlternatingRow Enabled="true" BackColor="#B7B7B7" />
                                </Styles>
                            </dx:ASPxGridView>
                        </DetailRow>
                    </Templates>--%>
                    <Styles>
                        <Row>
                            <font size="10" bold="True"></font>
                        </Row>
                        <Header BackColor="#0096DF" ForeColor="white">
                            <font bold="True" size="12"></font>
                        </Header>
                        <AlternatingRow Enabled="true" />
                    </Styles>

                    <SettingsLoadingPanel Text="Đang tải dữ liệu"></SettingsLoadingPanel>
                    <SettingsText EmptyDataRow="Chưa có lịch cắt nước trong khoảng thời gian trên"></SettingsText>
                    <SettingsPager PageSize="10"></SettingsPager>
                    <SettingsBehavior AllowSort="False"></SettingsBehavior>
                    <Settings ShowPreview="true" />
                </dx:ASPxGridView>
                <asp:SqlDataSource runat="server" ID="LichDataSource"
                    ConnectionString="<%$ ConnectionStrings:huewaco %>"
                    SelectCommand="Select * from tblLichCatNuoc  WHERE (NgayBatDau BETWEEN @DateFrom and @DateTo) and MaKV like N'%' + @MaKV + '%' and MaLoTrinh like N'%' + @maduongpho+ '%'  order by NgayBatDau desc">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="datFrom" DbType="DateTime" Name="DateFrom" />
                        <asp:ControlParameter ControlID="datTo" DbType="DateTime" Name="DateTo" />
                        <asp:ControlParameter ControlID="ddlKhuVuc" DbType="String" PropertyName="SelectedValue" Name="MaKV" />
                        <asp:ControlParameter ControlID="ddlLoTrinh" DbType="String" PropertyName="SelectedValue" Name="maduongpho" />
                    </SelectParameters>

                </asp:SqlDataSource>
                <%--  <asp:SqlDataSource runat="server" ID="DetailDataSource"
                    ConnectionString="<%$ ConnectionStrings:huewaco %>"
                    SelectCommand="SELECT CONVERT(varchar(10), GioBatDau) + ' : ' + CONVERT(varchar(10), PhutBatDau) AS BatDau, CONVERT(varchar(10), GioKetThuc) + ' : ' + CONVERT(varchar(10), PhutKetThuc) AS KetThuc ,LyDo FROM dbo.tblLichChiTiet WHERE IDLich	= @IDLich">
                    <SelectParameters>
                        <asp:SessionParameter Name="IDLich" SessionField="IDLich" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>--%>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
