<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="false" CodeBehind="Lich_HDDT.aspx.cs" Inherits="cskh.huewaco.vn.Lich_HDDT" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <style type="text/css">
        .modalBackground {
            background-color: Black;
            filter: alpha(opacity=90);
            opacity: 0.8;
        }

        .modalPopup {
            background-color: #FFFFFF;
            border-width: 3px;
            border-style: solid;
            border-color: black;
            padding-top: 10px;
            padding-left: 10px;
            width: 700px;
            height: 550px;
        }
    </style>
    <script type="text/javascript">

        function pageLoad() {
            var mpe = $find("MPE");
            var background = mpe._backgroundElement;
            background.onclick = function () {$find("MPE").hide(); }
        }

        function PrintPanel() {
            var panel = document.getElementById("divHDDTImage");
            var printWindow = window.open('', '', 'height=640,width=800');
            printWindow.document.write('<html><head>');
            printWindow.document.write('</head><body>');
            printWindow.document.write(panel.innerHTML);
            printWindow.document.write('</body></html>');
            printWindow.document.close();
            setTimeout(function () {
                printWindow.print();
            }, 500);
            return false;
        }

    </script>
</asp:Content>
<asp:Content ID="ctnMainPlace" ContentPlaceHolderID="ContentPlace" runat="Server">   
    <div style="margin: 0 0 0 5px">
        <div style="margin: 0px 10px 0 5px; font-family: Tahoma; font-size: 12px; line-height: 23px; text-align: justify">
            <asp:ScriptManager ID="ScriptManager1" ScriptMode="Debug" runat="server">
            </asp:ScriptManager>
            <!-- Modal -->
            <asp:UpdatePanel ID="UpdatePanel_Search" runat="server">
                <Triggers>
<%--                    <asp:PostBackTrigger ControlID="btnSearch" />
                    <asp:PostBackTrigger ControlID="lkbXemHD"/>
                    <asp:PostBackTrigger ControlID="lkbThongBao"/>
                    <asp:PostBackTrigger ControlID="lkbTaiHD"/>--%>
                </Triggers>
                <ContentTemplate>
                    <asp:LinkButton ID="btnShow" runat="server" ClientIDMode="Static"></asp:LinkButton>
                    <!-- ModalPopupExtender -->
                    <cc1:ModalPopupExtender ID="mp1" runat="server" BehaviorID="MPE" PopupControlID="Panel1"
                        TargetControlID="btnShow"  BackgroundCssClass="modalBackground">
                    </cc1:ModalPopupExtender>
                    <asp:Panel ID="Panel1" ClientIDMode="Static" runat="server" CssClass="modalPopup"
                        align="center" Style="display: none">
                        <div id="divHDDTImage">
                            <asp:Image ID="HDDTImage" ViewStateMode="Disabled" Width="100%" Height="100%" runat="server" />
                        </div>
                        <asp:Button ID="btnPrint" runat="server" CssClass="button cyan validate" Text="In" OnClientClick="return PrintPanel();" />
                       <input type="button" ID="btnClose" Class="button cyan validate" value="Đóng" onclick="$find('MPE').hide();" />
                    </asp:Panel>
                    <div class="TitPage" style="margin-left: 8px; margin-right: 8px">
                        <img style="border-width: 0px;" src="Source/ReportIcon.gif" class="icon_image">
                        <span class="subNavLink">HÓA ĐƠN ĐIỆN TỬ</span>
                    </div>
                    <div style="margin-left: 5px; margin-right: 5px">
                        <fieldset class="Fieldset_border">
                            <legend align="left"><span class="Fieldset_title_text">Thông tin khách hàng</span>
                            </legend>
                            <div class="box_space" style="padding-top: 10px; padding-bottom: 5px; width: 630px;">
                                <table>
                                    <tr>
                                        <td align="left">Mã khách hàng:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblMaKH" class="right_col" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>Tên khách hàng:</td>
                                        <td>
                                            <asp:Label ID="lblTenKH" class="right_col" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">Địa chỉ khách hàng:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblDiaChi" class="right_col" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">Mã danh bộ</td>
                                        <td>
                                            <asp:Label ID="lblMaDB" class="right_col" runat="server" Text=""></asp:Label>
                                        </td>
                                        <td>Mã lộ trình:
                                        </td>
                                        <td>
                                            <asp:Label ID="lblMaLo" class="right_col" runat="server" Text=""></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </fieldset>
                    </div>
                    <div style="margin-left: 5px; margin-right: 5px">
                        <fieldset class="Fieldset_border">
                            <legend align="left"><span class="Fieldset_title_text">Thông tin hóa đơn</span>
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
                                <asp:Button runat="server" ID="btnSearch" CssClass="button cyan validate" Text="Tìm kiếm" OnClick="btnSearch_OnClick" />
                            </div> 
                            
<%--                            <div style="text-align: center">
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel_Search" DisplayAfter="1">
                                    <ProgressTemplate>
                                        <img alt="" width="50px" src="Images/processing.gif" />
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>--%>
                            <span><br/><u>Chú ý</u>: Để tra cứu Hóa đơn trước năm 2019. Bấm </span><a href="http://huewaco.net.vn:8089/Lich_HDDT.aspx"><span>Vào đây</span></a><br/>

                            <div class="box_space" id="divKetQua" runat="server" visible="False" style="padding-top: 10px; padding-bottom: 5px; padding-left: 5px; padding-right: 5px; width: 680px;">
                                <table rules="all" style="width: 100%; border-collapse: collapse;" border="1" cellspacing="0">
                                    <tbody>                                        
                                        <tr class="gvtableth">
                                            <td class="auto-style1">IDKH</td>
                                            <td class="auto-style1">Số HĐ</td>
                                            <td class="auto-style1">M3 tiêu thụ</td>
                                            <td class="auto-style1">Số tiền</td>
                                            <td class="auto-style1">Tiền thuế</td>
                                            <td class="auto-style1">Thuế TNMT</td>
                                            <td class="auto-style1">Tổng tiền</td>
                                            <td class="auto-style1">Thông báo</td>
                                            <td class="auto-style1">Hóa đơn</td>
                                            <td class="auto-style1">Tải về</td>
                                        </tr>
                                        <%=htmlContent %>
                                        </tbody>
                                </table>
                            </div>
                            <asp:Label ID="lbNotic" runat="server" Text="Không có hóa đơn" ForeColor="Red" Visible="false"></asp:Label>
                        </fieldset>
                    </div>
                    <div style="margin-left: 5px; margin-right: 5px">
                        <fieldset id="fsdetail" class="Fieldset_border" runat="server">
                            <legend align="left"><span class="Fieldset_title_text">Hóa đơn chi tiết</span> </legend>
                            <div class="box_space" style="padding-top: 10px; padding-bottom: 5px">
                                <table>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label11" runat="server" Text="Mã khách hàng:"></asp:Label>
                                        </td>
                                        <td>
                                            <span style="margin-left: 30px">
                                                <asp:Label ID="Label12" runat="server" Text=""></asp:Label></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label13" runat="server" Text="Tên khách hàng:"></asp:Label>
                                        </td>
                                        <td>
                                            <span style="margin-left: 30px">
                                                <asp:Label ID="Label14" runat="server" Text=""></asp:Label></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label15" runat="server" Text="Địa chỉ khách hàng:"></asp:Label>
                                        </td>
                                        <td>
                                            <span style="margin-left: 30px">
                                                <asp:Label ID="Label16" runat="server" Text=""></asp:Label></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label17" runat="server" Text="Sổ ghi chữ:"></asp:Label>
                                        </td>
                                        <td>
                                            <span style="margin-left: 30px">
                                                <asp:Label ID="Label18" runat="server" Text=""></asp:Label></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label19" runat="server" Text="Số hóa đơn:"></asp:Label>
                                        </td>
                                        <td>
                                            <span style="margin-left: 30px">
                                                <asp:Label ID="Label20" runat="server" Text=""></asp:Label></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Label ID="Label21" runat="server" Text="Loại hóa đơn:"></asp:Label>
                                        </td>
                                        <td>
                                            <span style="margin-left: 30px">
                                                <asp:Label ID="Label22" runat="server" Text=""></asp:Label></span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="left">
                                            <asp:Label ID="Label23" runat="server" Text="Loại phát sinh-điều chỉnh:"></asp:Label>
                                        </td>
                                        <td>
                                            <span style="margin-left: 30px">
                                                <asp:Label ID="Label24" runat="server" Text=""></asp:Label></span>
                                        </td>
                                    </tr>
                                </table>
                                <div class="box_space" style="padding-top: 10px; padding-bottom: 5px; padding-left: 5px; padding-right: 5px">
                                    
                                </div>
                            </div>
                        </fieldset>
                    </div>
                    <div style="margin-left: 5px; margin-right: 5px">
                        <fieldset class="Fieldset_border">
                            <legend align="left"><span class="Fieldset_title_text" style="color: Red">Hướng dẫn
                                sử dụng</span> </legend>
                            <div class="box_space" style="padding-top: 10px; padding-bottom: 5px">
                                <center>
                                    <input type="button" value="Hướng dẫn in hóa đơn" style="width: 250px; font-weight: bold; color: #000066;"
                                        onclick="document.getElementById('divDownload').style.display = 'none'; if (document.getElementById('divPrint').style.display != '') { document.getElementById('divPrint').style.display = ''; } else { document.getElementById('divPrint').style.display = 'none'; }" />
                                    <input type="button" value="Hướng dẫn tải hóa đơn" style="width: 250px; font-weight: bold; color: #000066;"
                                        onclick="document.getElementById('divPrint').style.display = 'none'; if (document.getElementById('divDownload').style.display != '') { document.getElementById('divDownload').style.display = ''; } else { document.getElementById('divDownload').style.display = 'none'; }" />
                                </center>
                            </div>
                            <div style="display: none;" id="divPrint">
                                 <asp:Label runat="server" ID="lblContentInHoaDon" Font-Names="Arial" Font-Size="12px" />
                            </div>
                            <div class="LineBE">
                                <div style="display: none;" id="divDownload">
                                      <asp:Label runat="server" ID="lblContentTaiHoaDon" Font-Names="Arial" Font-Size="12px" />
                                    Hy vọng hướng dẫn trên đây sẽ giúp quý khách hàng sử dụng nước thuận lợi hơn trong
                                    quá trình sử dụng hóa đơn điện tử
                                </div>
                            </b>
                        </fieldset>
                    </div>
                    </div> </fieldset> </div>
                 
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>
