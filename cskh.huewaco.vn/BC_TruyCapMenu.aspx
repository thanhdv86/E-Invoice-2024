<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="BC_TruyCapMenu.aspx.cs" Inherits="cskh.huewaco.vn.BC_TruyCapMenu" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">

        function reload() {
            grvTruyCap.Refresh();
            grvDeTail.Refresh();
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
                <img style="border-width: 0px;" src="Source/ReportIcon.gif" class="icon_image"><span class="subNavLink">LƯỢNG TRUY CẬP CÁC CHỨC NĂNG</span>
            </div>
            <div style="margin-left: 8px; margin-right: 8px; margin-top: 20px">
                <fieldset class="Fieldset_border">
                    <legend align="left">
                        <span class="Fieldset_title_text">Lọc dữ liệu</span>
                    </legend>
                    <div class="box_space" style="padding-top: 10px; padding-bottom: 5px">
                        <table cellpadding="5" cellspacing="0" width="100%">
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
                <input type="button" class="button cyan validate" value="Xem" onclick="reload();" />
            </div>
            <div style="text-align: center">

                <asp:UpdateProgress runat="server" ID="UpdateProgressDK" AssociatedUpdatePanelID="UDPLICH" DisplayAfter="0" DynamicLayout="True">
                    <ProgressTemplate>
                        <img alt="" width="50px" src="Images/processing.gif" />
                    </ProgressTemplate>
                </asp:UpdateProgress>
            </div>
            <div style="margin-left: 8px; margin-right: 8px; margin-top: 5px">
                <dx:ASPxGridView ID="grvTruyCap" OnDataBound="grvTruyCap_OnDataBound" DataSourceID="ParrentMenuDataSource" ClientInstanceName="grvTruyCap" EnableRowsCache="False" runat="server" Width="100%" KeyFieldName="intMenuID" AutoGenerateColumns="False">
                    <Columns>
                        <dx:GridViewDataColumn Caption="Tên Menu" FieldName="strMenuName" VisibleIndex="1" />
                    </Columns>
                    <Templates>
                        <DetailRow>
                            <dx:ASPxGridView ID="grvDeTail" DataSourceID="SubMenuDataSource" ClientInstanceName="grvDeTail" EnableRowsCache="False" runat="server" Width="100%" KeyFieldName="intMenuID" AutoGenerateColumns="False" OnBeforePerformDataSelect="grvDeTail_OnBeforePerformDataSelect">
                                <Columns>
                                    <dx:GridViewDataColumn FieldName="strMenuName" VisibleIndex="1" Width="70%"/>
                                    <dx:GridViewDataColumn  FieldName="SL" VisibleIndex="2"  Width="30%"/>
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
                                <Settings ShowColumnHeaders="False"></Settings>
                                <SettingsPager PageSize="100"></SettingsPager>
                                <SettingsBehavior AllowSort="False"></SettingsBehavior>
                            </dx:ASPxGridView>
                        </DetailRow>
                    </Templates>
                    <Styles>
                        <Row>
                            <font size="10" bold="True"></font>
                        </Row>
                        <Header BackColor="#0096DF" ForeColor="white">
                            <font bold="True" size="12"></font>
                        </Header>
                    </Styles>

                    <SettingsLoadingPanel Text="Đang tải dữ liệu"></SettingsLoadingPanel>
                    <SettingsText EmptyDataRow="Không có dữ liệu"></SettingsText>
                    <SettingsDetail ShowDetailRow="True"></SettingsDetail>
                    <SettingsPager PageSize="100"></SettingsPager>
                    <SettingsBehavior AllowSort="False"></SettingsBehavior>
                </dx:ASPxGridView>
                <asp:SqlDataSource runat="server" ID="ParrentMenuDataSource"
                    ConnectionString="<%$ ConnectionStrings:huewaco %>"
                    SelectCommand="SELECT tblMenus.intMenuID,intMenuOrder,tblMenus.strMenuName,tblMenus.strMenuLink FROM dbo.tblMenus where
	 bolIsAdminSession = 'false' and intParentID = 0 ORDER BY intMenuOrder">
                    <SelectParameters>
                        <asp:ControlParameter ControlID="datFrom" DbType="DateTime" Name="TuNgay" />
                        <asp:ControlParameter ControlID="datTo" DbType="DateTime" Name="DenNgay" />
                    </SelectParameters>

                </asp:SqlDataSource>
                
                <asp:SqlDataSource runat="server" ID="SubMenuDataSource"
                    ConnectionString="<%$ ConnectionStrings:huewaco %>"
                    SelectCommand="SELECT tblMenus.intMenuID,intMenuOrder,tblMenus.strMenuName,tblMenus.strMenuLink,COUNT(PageName) AS SL FROM dbo.tblMenus 
	LEFT JOIN  dbo.tblTruyCap tc ON  tblMenus.strMenuLink = ('../'+ tc.PageName) WHERE (tc.NgayTruyCap BETWEEN @TuNgay AND @DenNgay) AND bolIsAdminSession = 'false' and intParentID != 0
                    And intParentID = @ParentID
	GROUP BY tblMenus.intMenuID,intMenuOrder,tblMenus.strMenuName,tblMenus.strMenuLink ORDER BY intMenuOrder">
                    <SelectParameters>
                         <asp:ControlParameter ControlID="datFrom" DbType="DateTime" Name="TuNgay" />
                        <asp:ControlParameter ControlID="datTo" DbType="DateTime" Name="DenNgay" />
                       <asp:SessionParameter Name="ParentID" SessionField="ParentID" Type="Int32" />
                    </SelectParameters>

                </asp:SqlDataSource>

            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
