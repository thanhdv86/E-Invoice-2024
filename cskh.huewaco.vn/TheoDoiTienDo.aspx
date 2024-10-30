<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="TheoDoiTienDo.aspx.cs" Inherits="cskh.huewaco.vn.TheoDoiTienDo" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            reload();
        });
        function reload() {
            grvTienDo.Refresh();
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
                <img style="border-width: 0px;" src="Source/ReportIcon.gif" class="icon_image"><span class="subNavLink">TIẾN ĐỘ LẮP ĐẶT NƯỚC</span>
            </div>
            <div style="margin-left: 8px; margin-right: 8px; margin-top: 20px">
                <fieldset class="Fieldset_border">
                    <legend align="left">
                        <span class="Fieldset_title_text">Vui lòng nhập thông tin</span>
                    </legend>
                    <div class="box_space" style="padding-top: 10px; padding-bottom: 5px">
                        <table cellpadding="5" cellspacing="0" width="100%">
                            <tr>
                                <td width="15%">Mã đơn đăng ký:</td>
                                <td width="35%" colspan="3">
                                    <dx:ASPxTextBox runat="server" ClientInstanceName="txtMaDonDK" ValidationGroup="VAL" ID="txtMaDonDK" Width="180px" />
                                </td>
                                <td>
                                    <span class="validate_rightCol">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" Display="Dynamic" ControlToValidate="txtMaDonDK" SetFocusOnError="True" ValidationGroup="VAL" Style="color: Red" ErrorMessage="Nhập mã đơn đăng ký" />
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
            
             <div style="margin-left: 8px; margin-right: 8px; margin-top: 20px" runat="server" id="divKH" Visible="False">
                <fieldset class="Fieldset_border">
                    <legend align="left">
                        <span class="Fieldset_title_text">Thông tin đăng ký của khách hàng</span>
                    </legend>
                    <div class="box_space" style="padding-top: 10px; padding-bottom: 5px">
                        <table cellpadding="5" cellspacing="0" width="100%">
                            <tr>
                                <td ><b>Tên khách hàng:</b></td>
                                <td style="text-align: left">
                                    <asp:Label runat="server" ID="lblTenKH"></asp:Label>
                                </td>
                                <td ><b>Địa chỉ:</b></td>
                                <td style="text-align: left">
                                    <asp:Label runat="server" ID="lblDiaChi" ></asp:Label>
                                </td>
                            </tr>
                            
                        </table>
                    </div>
                </fieldset>
            </div>

            <div style="margin-left: 8px; margin-right: 8px; margin-top: 5px"><dx:ASPxGridView ID="grvTienDo" OnCustomColumnDisplayText="grvTienDo_OnCustomColumnDisplayText" OnDataBound="grvTienDo_OnDataBound" ClientInstanceName="grvTienDo" ClientVisible="False"  runat="server" Width="100%" AutoGenerateColumns="False">
                    
                    <Columns>
                        <dx:GridViewDataColumn Caption="Duyệt & Khảo sát" FieldName="duyet_pcks" VisibleIndex="1" Width="80px">
                        </dx:GridViewDataColumn>
                        <dx:GridViewDataColumn Caption="Khảo sát" FieldName="khaosat" VisibleIndex="2" Width="80px"/>
                        <dx:GridViewDataColumn Caption="Dự toán" FieldName="dutoan" VisibleIndex="3" Width="80px"/>
                        <dx:GridViewDataColumn Caption="Duyệt dự toán" FieldName="duyetdutoan" VisibleIndex="4" Width="80px"/>
                        <dx:GridViewDataColumn Caption="Hợp đồng" FieldName="hopdong" VisibleIndex="5" Width="80px"/>
                        <dx:GridViewDataColumn Caption="Chuyển vật tư" FieldName="chuyenvattu" VisibleIndex="6" Width="80px"/>
                        <dx:GridViewDataColumn Caption="Nhập & PCTC" FieldName="nhap_pctc" VisibleIndex="7" Width="80px"/>
                        <dx:GridViewDataColumn Caption="Thi công" FieldName="thicong" VisibleIndex="8" Width="80px"/>
                        <dx:GridViewDataColumn Caption="Quyết toán" FieldName="quyettoan" VisibleIndex="9" Width="80px"/>
                       
                    </Columns>
                    
                    <Styles>
                        <Header BackColor="#0096DF" ForeColor="white" HorizontalAlign="Center" Wrap="True">
                            <font bold="True" size="10"></font>
                        </Header>
                    </Styles>
                   
                       <SettingsText EmptyDataRow="Không có dữ liệu"></SettingsText>
                    <SettingsLoadingPanel Text="Đang tải dữ liệu"></SettingsLoadingPanel>
                    <SettingsBehavior AllowSort="False" ColumnResizeMode="NextColumn" ></SettingsBehavior>
                </dx:ASPxGridView>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
