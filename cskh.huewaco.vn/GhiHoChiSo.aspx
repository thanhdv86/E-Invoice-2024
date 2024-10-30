<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="GhiHoChiSo.aspx.cs" Inherits="cskh.huewaco.vn.GhiHoChiSo" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(function () {
            reload();
        });
        function reload() {
            grvLich.Refresh();
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
                <img style="border-width: 0px;" src="Source/ReportIcon.gif" class="icon_image"><span class="subNavLink">DANH SÁCH CHƯA GHI CHỈ SỐ</span>
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
                                    <asp:DropDownList runat="server" ID="ddlKhuVuc" DataSourceID="KhuVucDataSource" AutoPostBack="False" Width="148px" DataTextField="TenKhuVuc" DataValueField="MaKV" />
                                    <asp:SqlDataSource ID="KhuVucDataSource" runat="server"
                                        ConnectionString="<%$ ConnectionStrings:huewaco %>"
                                        SelectCommand="Select * from tblKhuVuc"></asp:SqlDataSource>
                                </td>
                                <td width="25%"></td>
                                <td width="25%">
                                   
                                </td>
                            </tr>
                            <tr>
                                <td width="25%">Quận (Huyện):</td>
                                <td width="25%">
                                   <asp:DropDownList ID="ddlQuan" DataSourceID="QuanDataSource" AutoPostBack="True" DataValueField="MaQuan" DataTextField="TenDonVi" TabIndex="2" Width="150px" runat="server" CssClass="text_combo">
                                                </asp:DropDownList>
                                </td>
                                <td width="25%">Phường (Xã)</td>
                                <td width="25%">
                                    <asp:DropDownList ID="ddlPhuong" DataSourceID="PhuongDataSource" DataValueField="MaPhuong" DataTextField="TenDonVi" TabIndex="2" Width="150px" runat="server" CssClass="text_combo">
                                                </asp:DropDownList>
                                </td>
                            </tr>
                        </table>
                    </div>
                </fieldset>
            </div>
             <asp:SqlDataSource ID="SqlDataSource1" runat="server"
            ConnectionString="<%$ ConnectionStrings:huewaco %>"
            SelectCommand="Select * from tblKhuVuc"></asp:SqlDataSource>
        <asp:SqlDataSource ID="QuanDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:huewaco %>"
            SelectCommand="SELECT * FROM dbo.tblDonViDiaChinh WHERE MaQuan is NOT NULL AND MaPhuong is NULL"></asp:SqlDataSource>
        <asp:SqlDataSource ID="PhuongDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:huewaco %>"
            SelectCommand="SELECT * FROM dbo.tblDonViDiaChinh WHERE MaPhuong is NOT NULL AND MaQuan is NOT NULL and MaQuan = @MaQuan">
            <SelectParameters>
                <asp:ControlParameter ControlID="ddlQuan" PropertyName="SelectedValue"
                    Type="String" Name="MaQuan" />
            </SelectParameters>
        </asp:SqlDataSource>
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
                <dx:ASPxGridView ID="grvLich" OnDataBound="grvLich_OnDataBound" ClientInstanceName="grvLich"  EnableRowsCache="False" runat="server" Width="100%" AutoGenerateColumns="False" OnDataBinding="grvLich_DataBinding">
                    
                    <Columns>
                        <dx:GridViewDataColumn Caption="Số danh bộ" FieldName="sodb" VisibleIndex="1" />
                        <dx:GridViewDataColumn Caption="Tên khách hàng" FieldName="tenkh" VisibleIndex="2" />
                        <dx:GridViewDataColumn Caption="Địa chỉ" FieldName="diachi" VisibleIndex="3" />
                        <dx:GridViewDataTextColumn Caption="Tình trạng" VisibleIndex="4" >
                            <CellStyle HorizontalAlign="Center"></CellStyle>
                            <DataItemTemplate>
                                <asp:Label runat="server"  Text="Chưa ghi chỉ số"></asp:Label>
                              
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
            <div style="margin-left: 8px; margin-right: 8px; margin-top: 5px">
                <asp:Label runat="server" Text="(Vui lòng gọi cho trung tâm chăm sóc khách hàng theo số 0234.3890890 để được tư vấn thêm)" Font-Italic="True"></asp:Label>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
   
</asp:Content>

