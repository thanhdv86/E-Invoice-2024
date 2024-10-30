<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlSupportonline.ascx.cs" Inherits="cskh.huewaco.vn.Control.ctrlSupportonline" %>


<div class="left_panel_top"></div>
<div class="left_panel_main">
    <div class="panel_body">
        <div class="panel_line">
            <div class="panel_title">
                Hỗ trợ trực tuyến 
            </div>
        </div>
        <div class="panel_line" style="font-size: 12px;">
            <table width="100%">
                <%-- <tr>
                    <td>
                        <asp:DataList id="dlCSKH" runat="server">
                            <ItemTemplate>
                                <table cellpadding=2 cellspacing=2>
                                    <tr>
                                        <td>
                                            <asp:Image ID="Image1" ImageUrl="../Images/phone.png" Width="15px" runat="server" style="line-height:25px;font-weight:bold;font-family:@Adobe Fan Heiti Std B;font-size:11px"/>
                                        </td>
                                        <td style="width:120px; color:#7A3B9C;font-weight:bold;font-size:11px;font-family:Tahoma;margin-left:5px">
                                            <asp:Label ID="lbSuachuadien" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.TEN_DL_CSKH")%>'></asp:Label>                                            
                                        </td>
                                        <td style="width:100px; color:#FF0000;font-weight:bold;text-align:right; font-size:11px; font-family:Tahoma">
                                            <asp:Label ID="Label1" runat="server" Text='<%#DataBinder.Eval(Container, "DataItem.DTHOAI_HTKH")%>'/>
                                        </td>
                                    </tr>
                                </table>
                                <div style="border-bottom:1px dotted gray; width:207px"></div>
                            </ItemTemplate>
                        </asp:DataList>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <asp:Image ID="Image1" ImageUrl="../Images/phone.png" Width="15px" runat="server" Style="line-height: 25px; font-weight: bold; font-family: @Adobe Fan Heiti Std B; font-size: 11px" />
                    </td>
                    <td style="width: 120px; color: #7A3B9C; font-weight: bold; font-size: 11px; font-family: Tahoma; margin-left: 5px">
                       Trung tâm CSKH
                    </td>
                    <td style="width: 100px; color: #FF0000; font-weight: bold; text-align: right; font-size: 11px; font-family: Tahoma">
                        <asp:Label ID="lblPhoneCCC" runat="server" Text=""></asp:Label>
                    </td>
                </tr>
             <%--   <tr>
                    <td>
                        <asp:Image ID="Image2" ImageUrl="../Images/phone.png" Width="15px" runat="server" Style="line-height: 25px; font-weight: bold; font-family: @Adobe Fan Heiti Std B; font-size: 11px" />
                    </td>
                    <td style="width: 120px; color: #7A3B9C; font-weight: bold; font-size: 11px; font-family: Tahoma; margin-left: 5px">
                       Nhà MN Tứ Hạ
                    </td>
                    <td style="width: 100px; color: #FF0000; font-weight: bold; text-align: right; font-size: 11px; font-family: Tahoma">
                        054.3833.710
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Image3" ImageUrl="../Images/phone.png" Width="15px" runat="server" Style="line-height: 25px; font-weight: bold; font-family: @Adobe Fan Heiti Std B; font-size: 11px" />
                    </td>
                    <td style="width: 120px; color: #7A3B9C; font-weight: bold; font-size: 11px; font-family: Tahoma; margin-left: 5px">
                       Nhà MN Bạch Mã
                    </td>
                    <td style="width: 100px; color: #FF0000; font-weight: bold; text-align: right; font-size: 11px; font-family: Tahoma">
                        054.3833.710
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Image4" ImageUrl="../Images/phone.png" Width="15px" runat="server" Style="line-height: 25px; font-weight: bold; font-family: @Adobe Fan Heiti Std B; font-size: 11px" />
                    </td>
                    <td style="width: 120px; color: #7A3B9C; font-weight: bold; font-size: 11px; font-family: Tahoma; margin-left: 5px">
                       Nhà MN Chân Mây
                    </td>
                    <td style="width: 100px; color: #FF0000; font-weight: bold; text-align: right; font-size: 11px; font-family: Tahoma">
                       054.3833.710
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Image5" ImageUrl="../Images/phone.png" Width="15px" runat="server" Style="line-height: 25px; font-weight: bold; font-family: @Adobe Fan Heiti Std B; font-size: 11px" />
                    </td>
                    <td style="width: 120px; color: #7A3B9C; font-weight: bold; font-size: 11px; font-family: Tahoma; margin-left: 5px">
                      Nhà MN Hòa Bình Chương
                    </td>
                    <td style="width: 100px; color: #FF0000; font-weight: bold; text-align: right; font-size: 11px; font-family: Tahoma">
                       054.3833.710
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Image6" ImageUrl="../Images/phone.png" Width="15px" runat="server" Style="line-height: 25px; font-weight: bold; font-family: @Adobe Fan Heiti Std B; font-size: 11px" />
                    </td>
                    <td style="width: 120px; color: #7A3B9C; font-weight: bold; font-size: 11px; font-family: Tahoma; margin-left: 5px">
                       Nhà MN Dã Viên
                    </td>
                    <td style="width: 100px; color: #FF0000; font-weight: bold; text-align: right; font-size: 11px; font-family: Tahoma">
                       054.3833.710
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Image7" ImageUrl="../Images/phone.png" Width="15px" runat="server" Style="line-height: 25px; font-weight: bold; font-family: @Adobe Fan Heiti Std B; font-size: 11px" />
                    </td>
                    <td style="width: 120px; color: #7A3B9C; font-weight: bold; font-size: 11px; font-family: Tahoma; margin-left: 5px">
                       Nhà MN Nam Đông
                    </td>
                    <td style="width: 100px; color: #FF0000; font-weight: bold; text-align: right; font-size: 11px; font-family: Tahoma">
                       054.3833.710
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Image8" ImageUrl="../Images/phone.png" Width="15px" runat="server" Style="line-height: 25px; font-weight: bold; font-family: @Adobe Fan Heiti Std B; font-size: 11px" />
                    </td>
                    <td style="width: 120px; color: #7A3B9C; font-weight: bold; font-size: 11px; font-family: Tahoma; margin-left: 5px">
                       Nhà MN Vinh Hiền
                    </td>
                    <td style="width: 100px; color: #FF0000; font-weight: bold; text-align: right; font-size: 11px; font-family: Tahoma">
                       054.3833.710
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Image9" ImageUrl="../Images/phone.png" Width="15px" runat="server" Style="line-height: 25px; font-weight: bold; font-family: @Adobe Fan Heiti Std B; font-size: 11px" />
                    </td>
                    <td style="width: 120px; color: #7A3B9C; font-weight: bold; font-size: 11px; font-family: Tahoma; margin-left: 5px">
                       Nhà MN Bình Thành
                    </td>
                    <td style="width: 100px; color: #FF0000; font-weight: bold; text-align: right; font-size: 11px; font-family: Tahoma">
                       054.3833.710
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Image10" ImageUrl="../Images/phone.png" Width="15px" runat="server" Style="line-height: 25px; font-weight: bold; font-family: @Adobe Fan Heiti Std B; font-size: 11px" />
                    </td>
                    <td style="width: 120px; color: #7A3B9C; font-weight: bold; font-size: 11px; font-family: Tahoma; margin-left: 5px">
                       Nhà MN Bến Ván
                    </td>
                    <td style="width: 100px; color: #FF0000; font-weight: bold; text-align: right; font-size: 11px; font-family: Tahoma">
                       054.3833.710
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Image11" ImageUrl="../Images/phone.png" Width="15px" runat="server" Style="line-height: 25px; font-weight: bold; font-family: @Adobe Fan Heiti Std B; font-size: 11px" />
                    </td>
                    <td style="width: 120px; color: #7A3B9C; font-weight: bold; font-size: 11px; font-family: Tahoma; margin-left: 5px">
                       Chi nhánh cấp nước Phú Dương
                    </td>
                    <td style="width: 100px; color: #FF0000; font-weight: bold; text-align: right; font-size: 11px; font-family: Tahoma">
                       054.3833.710
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Image12" ImageUrl="../Images/phone.png" Width="15px" runat="server" Style="line-height: 25px; font-weight: bold; font-family: @Adobe Fan Heiti Std B; font-size: 11px" />
                    </td>
                    <td style="width: 120px; color: #7A3B9C; font-weight: bold; font-size: 11px; font-family: Tahoma; margin-left: 5px">
                       Chi nhánh cấp nước Hương Điền
                    </td>
                    <td style="width: 100px; color: #FF0000; font-weight: bold; text-align: right; font-size: 11px; font-family: Tahoma">
                       054.3833.710
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Image ID="Image13" ImageUrl="../Images/phone.png" Width="15px" runat="server" Style="line-height: 25px; font-weight: bold; font-family: @Adobe Fan Heiti Std B; font-size: 11px" />
                    </td>
                    <td style="width: 120px; color: #7A3B9C; font-weight: bold; font-size: 11px; font-family: Tahoma; margin-left: 5px">
                       Chi nhánh cấp nước Phú Bài
                    </td>
                    <td style="width: 100px; color: #FF0000; font-weight: bold; text-align: right; font-size: 11px; font-family: Tahoma">
                       054.3833.710
                    </td>
                </tr>--%>
            </table>
        </div>
        <%--<div class="panel_line" style="font-size:12px; padding-left: 50px">           
            <img id="ctl00_panelRight1_Image1" class="panel_icon" src="../images/icon_tel.png" style="border-width:0px;">
            Hotline:
            <span style="color:Red;font-weight:bold;">
                <asp:Label ID="lbHotline" runat="server" Text="Chọn nút"></asp:Label>&nbsp;<a href="cskh.huewaco.vn/A00_ContactUs.aspx">Liên hệ</a> <a>trên Menu để biết trực tiếp số Nước thoại liên lạc Đơn vị</a></span>
        </div>
        <div class="panel_line" style="font-size:12px">
             <img id="ctl00_panelRight1_Image2" class="panel_icon" src="../images/icon_email.png" style="border-width:0px;"><b> Email: </b> <span style="color:Blue;font-weight:bold;"> 
                 <asp:Label ID="lbEmail" runat="server" Text="cskh@cpc.vn"></asp:Label></span>
        </div>
        <div class="panel_line" style="font-size:12px;">
             <img id="ctl00_panelRight1_Image3" class="panel_icon" src="../images/icon_web.png" style="border-width:0px; width:22px;"><b>Website: </b><span style="color:Red;font-weight:bold;"> 
                 <asp:Label ID="lbWebsite" runat="server" Text="cskh.huewaco.vn"></asp:Label> </span>
        </div>--%>
    </div>
</div>
<div class="left_panel_bottom"></div>
