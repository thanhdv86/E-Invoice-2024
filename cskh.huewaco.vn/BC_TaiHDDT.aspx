<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="BC_TaiHDDT.aspx.cs" Inherits="cskh.huewaco.vn.BC_TaiHDDT" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">

         function reload() {
             grvHDDT.Refresh();
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlace" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div>
        <table>
            <tr height="2px">
                <td></td>
            </tr>
        </table>
    </div>
    <div class="TitPage" style="margin-left: 8px; margin-right: 8px">
        <img style="border-width: 0px;" src="Images/reg-icon.jpg" class="icon_image">
        <span class="subNavLink">THỐNG KÊ LƯỢNG DOWNLOAD HÓA ĐƠN</span>
    </div>
    <div style="margin-left: 5px; margin-right: 5px">
        <fieldset class="Fieldset_border">
            <legend align="left"><span class="Fieldset_title_text">Lọc thông tin</span>
            </legend>
            <div class="box_space" style="padding-top: 10px; padding-bottom: 5px">
                <span style="font-weight: normal;">Kỳ</span>&nbsp;&nbsp;
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:DropDownList ID="ddlKy" runat="server">
                                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp; <span style="font-weight: normal;">Năm</span>&nbsp;&nbsp;
                                <asp:DropDownList ID="ddlNam" runat="server" Width="55px">
                                </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;&nbsp;
                               <%--<input type="button" class="button cyan validate" value="Xem" onclick="reload();" />--%>
                <asp:Button ID="btnTim" runat="server" CssClass="btn-u validate" OnClick="btnTim_OnClick" Text="Xem" />
            </div>
        </fieldset>
    </div>
    <div>
       
        <dx:ASPxGridView ID="grvHDDT" ClientInstanceName="grvHDDT" Width="90%" runat="server" KeyFieldName="IDKH" EnableRowsCache="False" AutoGenerateColumns="False" Theme="MetropolisBlue" OnDataBinding="grvHDDT_DataBinding">           
            <Columns>
                <dx:GridViewDataColumn Caption="Số HĐ" Width="15px" FieldName="SOHOADON" VisibleIndex="1" />
                <dx:GridViewDataColumn Caption="Tên khách hàng" FieldName="TENKH" VisibleIndex="2" >
                    <Settings AutoFilterCondition="Contains"></Settings>                   
                </dx:GridViewDataColumn>
                <dx:GridViewDataColumn Caption="Kỳ" Width="5px" FieldName="KY" VisibleIndex="3" />
                <dx:GridViewDataColumn Caption="Năm" Width="10px" FieldName="NAM" VisibleIndex="4" />
                <dx:GridViewDataColumn Caption="M3"  Width="15px" FieldName="M3TINHTIEN" VisibleIndex="5" />
                <dx:GridViewDataColumn Caption="Tổng tiền"  Width="30px" FieldName="TONGTIEN" VisibleIndex="6" />
                <dx:GridViewDataCheckColumn Caption="Hóa đơn" Width="15px"  FieldName="ISDOWNLOAD" VisibleIndex="7" >
                <PropertiesCheckEdit DisplayTextChecked="Đã tải" DisplayTextUnchecked="Chưa tải">
                </PropertiesCheckEdit>
            </dx:GridViewDataCheckColumn>
            </Columns><Settings ShowFilterRow="True" />
            <SettingsPager PageSize="20"></SettingsPager>
        </dx:ASPxGridView>

<%--        <asp:SqlDataSource ID="HDDTDataSource" runat="server"
            ConnectionString="<%$ ConnectionStrings:huewaco %>"
            SelectCommand="SELECT SOHOADON,KY,NAM,TENKH,M3TINHTIEN,TONGTIEN,ISDOWNLOAD FROM dbo.HD_HOADON where Ky= @Ky and Nam = @Nam order by sohoadon"
            ProviderName="System.Data.SqlClient">
            <SelectParameters>
                <asp:ControlParameter Name="Ky" Type="Int32" ControlID="ddlKy" />
                <asp:ControlParameter Name="Nam" Type="Int32" ControlID="ddlNam" />
            </SelectParameters>

        </asp:SqlDataSource>--%>
       
    </div>

</asp:Content>
