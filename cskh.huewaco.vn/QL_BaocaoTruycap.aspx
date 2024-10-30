<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="QL_BaocaoTruycap.aspx.cs" Inherits="cskh.huewaco.vn.QL_BaocaoTruycap" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="ctnMainPlace" ContentPlaceHolderID="ContentPlace" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Scripts>
            <asp:ScriptReference Path="~/Scripts/Grid.js" />
        </Scripts>
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel_Search" runat="server">
        <ContentTemplate>
            <div style="height: 5px"></div>    
            <div class="TitPage" style="margin-left:8px; margin-right:8px">
                <img style="border-width:0px;" src="Source/ReportIcon.gif" class="icon_image"><span class="subNavLink">BÁO CÁO SỐ LƯỢNG KHÁCH HÀNG TRUY CẬP WEBSITE CSKH</span>
            </div>
            <div style="margin-left:8px; margin-right:8px; margin-top: 20px">
                <fieldset class="Fieldset_border">
                    <legend align="left">
                        <span class="Fieldset_title_text"><% =getString("strVuilongNhapthongtin")%></span>
                    </legend>
                    <div class="box_space" style="padding-top:10px; padding-bottom:5px">
                        <table cellpadding=5 cellspacing=0 width=100%>
                            <tr>
                                <td width="15%">Đơn vị:</td>
                                <td width="35%">
                                    <asp:DropDownList runat="server" ID="drlDonvi" CssClass="font33" Width=220px Height=20px AutoPostBack="false"/>
                                </td>
                                <td width="50%" colspan=2></td>                                
                            </tr>   
                            <tr>
                                <td>Từ ngày:</td>
                                <td>
                                    <dx:ASPxDateEdit ID="datFrom" runat="server" AutoPostBack="false" EditFormat="Custom" EditFormatString="dd/MM/yyyy" Width="100px" Font-Size= "11px" Font-Names = "Verdana">
                                       <CalendarProperties ShowClearButton="False" ShowTodayButton="False">
                                           <WeekNumberStyle BackColor="White" Font-Bold="True" ForeColor="#0033CC">
                                               <Border BorderStyle="Solid" />
                                           </WeekNumberStyle>
                                       </CalendarProperties>
                                    </dx:ASPxDateEdit>    
                                </td>
                                <td>Đến ngày:</td>
                                <td>
                                    <dx:ASPxDateEdit ID="datTo" runat="server" AutoPostBack="false" EditFormat="Custom" EditFormatString="dd/MM/yyyy" Width="100px" Font-Size= "11px" Font-Names = "Verdana">
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
            <div style="margin-left:8px; margin-right:8px; margin-top: 5px">
                <asp:Button runat="server" ID="btnSearch" CssClass="button cyan validate" Text = "Xem" onclick="btnSearch_Click" />        
                <asp:Button runat="server" ID="btnBack" CssClass="button cyan validate" Text = "Trở về" onclick="btnBack_Click" />
            </div>
            <div runat="server" id="divResult" visible="false" style="margin-left:8px; margin-right:8px; margin-top: 10px">
                <asp:DataGrid runat="server" ID="dgSchedule" AutoGenerateColumns="false" ShowFooter = "true" Width="100%" CellPadding = "3" ondatabinding="dgSchedule_DataBinding" onitemcreated="dgSchedule_ItemCreated">
                    <HeaderStyle CssClass ="gvtableth" Height="25px"/>
                    <FooterStyle ForeColor = "Red" Height = "30px" HorizontalAlign = "Center"/>
                    <ItemStyle CssClass ="gvtabletd" Height="22px" Font-Size = "11px" Font-Names = "Tahoma" ForeColor = "#000066"/>
                    <AlternatingItemStyle Height="22px" Font-Size = "11px" Font-Names = "Tahoma" ForeColor = "#000066"/>
                    <Columns>                        
                        <asp:BoundColumn DataField = "TEN_DVICTREN" ItemStyle-Width = "100px" ItemStyle-HorizontalAlign ="Left" HeaderStyle-BorderColor = "Gray" HeaderText = "Đơn vị" FooterText = "Không tìm thấy dữ liệu" FooterStyle-BorderColor = "Gray"/>
                        <asp:BoundColumn DataField = "TEN_DVIQLY" ItemStyle-Width = "100px" ItemStyle-HorizontalAlign ="Left" HeaderStyle-BorderColor = "Gray" HeaderText = "Nước lực" FooterStyle-BorderColor = "Gray"/>
                        <asp:BoundColumn DataField = "LUOT_TRUYCAP" HeaderStyle-BorderColor = "Gray" ItemStyle-Width = "100px" HeaderText = "Số lượt khách hàng truy cập" ItemStyle-HorizontalAlign ="Right" DataFormatString = "{0: ### ### ### ###}"/>
                    </Columns>
                </asp:DataGrid>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>     
</asp:Content>
