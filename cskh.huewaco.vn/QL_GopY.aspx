<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="QL_GopY.aspx.cs" Inherits="cskh.huewaco.vn.QL_GopY" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="ctnMainPlace" ContentPlaceHolderID="ContentPlace" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server">
        <ContentTemplate>
            <div style="height: 5px"></div>
            <div class="TitPage" style="margin-left: 8px; margin-right: 8px">
                <img style="border-width: 0px;" src="Images/reg-icon.jpg" class="icon_image">
                <span class="subNavLink"></span>
            </div>
           <dx:ASPxGridView ID="grdYeuCau" ClientInstanceName="grid" DataSourceID="GopYDatasource" runat="server" KeyFieldName="ID" Width="100%" EnableRowsCache="False" AutoGenerateColumns="False" Theme="MetropolisBlue" EnableTheming="True">
                    <Columns>
                        <dx:GridViewCommandColumn ShowEditButton="True" VisibleIndex="0"/>                        
                        <dx:GridViewDataColumn Caption="Tên khách hàng" FieldName="HOTEN" VisibleIndex="1" />
                        <dx:GridViewDataColumn Caption="Địa chỉ" FieldName="DIACHI" VisibleIndex="2" />
                        <dx:GridViewDataColumn Caption="SĐT" FieldName="SDT" VisibleIndex="3" />
                        <dx:GridViewDataColumn Caption="Email" FieldName="EMAIL" VisibleIndex="4" />
                        <dx:GridViewDataColumn Caption="Ngày gửi" FieldName="NGAY_GUI" VisibleIndex="5"/>
                        <dx:GridViewDataColumn Caption="Xử lý" FieldName="XuLy" VisibleIndex="6"/>
                    </Columns>
                    <Templates>
                        <DetailRow>
                            <div>
                                <b>Nội dung góp ý:</b> <%#Eval("NOI_DUNG") %>
                            </div>

                        </DetailRow>
                    </Templates>
                    <Settings ShowFilterRow="True" />

                    <SettingsDetail ShowDetailRow="true" />
                    <SettingsText CommandEdit="Sửa" CommandCancel="Bỏ qua" CommandUpdate="Lưu" ></SettingsText>                    
                </dx:ASPxGridView>

                <asp:SqlDataSource ID="GopYDatasource" runat="server"
                    ConnectionString="<%$ ConnectionStrings:huewaco %>"
                    SelectCommand="Select * from tblGOPY order by NGAY_GUI desc" 
                    UpdateCommand="Update tblGOPY set XuLy = @XuLy where ID=@ID">                    
                    <UpdateParameters>
                        <asp:Parameter Name="XuLy" />
                        <asp:Parameter Name="ID" />
                    </UpdateParameters>
            </asp:SqlDataSource>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

