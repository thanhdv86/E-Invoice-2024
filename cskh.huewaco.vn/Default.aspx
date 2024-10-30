<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/CSKH.master" AutoEventWireup="false" CodeBehind="Default.aspx.cs" Inherits="cskh.huewaco.vn.Default" %>

<%@ Register Assembly="DevExpress.XtraCharts.v14.2.Web, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.XtraCharts.Web" TagPrefix="dxchartsui" %>
<%@ Register TagPrefix="dxcharts" Namespace="DevExpress.XtraCharts" Assembly="DevExpress.XtraCharts.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/Scripts/jssor.js"></script>
    <script type="text/javascript" src="/Scripts/jssor.slider.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
            var options = {
                $AutoPlay: true,                                    //[Optional] Whether to auto play, to enable slideshow, this option must be set to true, default value is false
                $AutoPlaySteps: 4,                                  //[Optional] Steps to go for each navigation request (this options applys only when slideshow disabled), the default value is 1
                $AutoPlayInterval: 4000,                            //[Optional] Interval (in milliseconds) to go for next slide since the previous stopped if the slider is auto playing, default value is 3000
                $PauseOnHover: 1,                               //[Optional] Whether to pause when mouse over if a slider is auto playing, 0 no pause, 1 pause for desktop, 2 pause for touch device, 3 pause for desktop and touch device, 4 freeze for desktop, 8 freeze for touch device, 12 freeze for desktop and touch device, default value is 1

                $ArrowKeyNavigation: true,   			            //[Optional] Allows keyboard (arrow key) navigation or not, default value is false
                $SlideDuration: 160,                                //[Optional] Specifies default duration (swipe) for slide in milliseconds, default value is 500
                $MinDragOffsetToSlide: 20,                          //[Optional] Minimum drag offset to trigger slide , default value is 20
                $SlideWidth: 200,                                   //[Optional] Width of every slide in pixels, default value is width of 'slides' container
                //$SlideHeight: 150,                                //[Optional] Height of every slide in pixels, default value is height of 'slides' container
                $SlideSpacing: 3, 					                //[Optional] Space between each slide in pixels, default value is 0
                $DisplayPieces: 4,                                  //[Optional] Number of pieces to display (the slideshow would be disabled if the value is set to greater than 1), the default value is 1
                $ParkingPosition: 0,                              //[Optional] The offset position to park slide (this options applys only when slideshow disabled), default value is 0.
                $UISearchMode: 1,                                   //[Optional] The way (0 parellel, 1 recursive, default value is 1) to search UI components (slides container, loading screen, navigator container, arrow navigator container, thumbnail navigator container etc).
                $PlayOrientation: 1,                                //[Optional] Orientation to play slide (for auto play, navigation), 1 horizental, 2 vertical, 5 horizental reverse, 6 vertical reverse, default value is 1
                $DragOrientation: 1,                                //[Optional] Orientation to drag slide, 0 no drag, 1 horizental, 2 vertical, 3 either, default value is 1 (Note that the $DragOrientation should be the same as $PlayOrientation when $DisplayPieces is greater than 1, or parking position is not 0)

                $BulletNavigatorOptions: {                                //[Optional] Options to specify and enable navigator or not
                    $Class: $JssorBulletNavigator$,                       //[Required] Class to create navigator instance
                    $ChanceToShow: 2,                               //[Required] 0 Never, 1 Mouse Over, 2 Always
                    $AutoCenter: 0,                                 //[Optional] Auto center navigator in parent container, 0 None, 1 Horizontal, 2 Vertical, 3 Both, default value is 0
                    $Steps: 1,                                      //[Optional] Steps to go for each navigation request, default value is 1
                    $Lanes: 1,                                      //[Optional] Specify lanes to arrange items, default value is 1
                    $SpacingX: 0,                                   //[Optional] Horizontal space between each item in pixel, default value is 0
                    $SpacingY: 0,                                   //[Optional] Vertical space between each item in pixel, default value is 0
                    $Orientation: 1                                 //[Optional] The orientation of the navigator, 1 horizontal, 2 vertical, default value is 1
                },

                $ArrowNavigatorOptions: {
                    $Class: $JssorArrowNavigator$,              //[Requried] Class to create arrow navigator instance
                    $ChanceToShow: 1,                               //[Required] 0 Never, 1 Mouse Over, 2 Always
                    $AutoCenter: 2,                                 //[Optional] Auto center navigator in parent container, 0 None, 1 Horizontal, 2 Vertical, 3 Both, default value is 0
                    $Steps: 4                                       //[Optional] Steps to go for each navigation request, default value is 1
                }
            };
            var jssor_slider1 = new $JssorSlider$("slider1_container", options);

            //responsive code begin
            //you can remove responsive code if you don't want the slider scales while window resizes
            function ScaleSlider() {
                var bodyWidth = document.body.clientWidth;
                if (bodyWidth)
                    jssor_slider1.$ScaleWidth(Math.min(bodyWidth, 720));
                else
                    window.setTimeout(ScaleSlider, 30);
            }
            ScaleSlider();

            $(window).bind("load", ScaleSlider);
            $(window).bind("resize", ScaleSlider);
            $(window).bind("orientationchange", ScaleSlider);
            //responsive code end
        });
    </script>
    <style type="text/css">
        /* jssor slider arrow navigator skin 03 css */
        /*
            .jssora03l                  (normal)
            .jssora03r                  (normal)
            .jssora03l:hover            (normal mouseover)
            .jssora03r:hover            (normal mouseover)
            .jssora03l.jssora03ldn      (mousedown)
            .jssora03r.jssora03rdn      (mousedown)
            */
        .jssora03l, .jssora03r {
            display: block;
            position: absolute;
            /* size of arrow element */
            width: 55px;
            height: 55px;
            cursor: pointer;
            background: url(Images/a03.png) no-repeat;
            overflow: hidden;
        }

        .jssora03l {
            background-position: -3px -33px;
        }

        .jssora03r {
            background-position: -63px -33px;
        }

        .jssora03l:hover {
            background-position: -123px -33px;
        }

        .jssora03r:hover {
            background-position: -183px -33px;
        }

        .jssora03l.jssora03ldn {
            background-position: -243px -33px;
        }

        .jssora03r.jssora03rdn {
            background-position: -303px -33px;
        }
    </style>
    <style type="text/css">
        /* jssor slider bullet navigator skin 03 css */
        /*
            .jssorb03 div           (normal)
            .jssorb03 div:hover     (normal mouseover)
            .jssorb03 .av           (active)
            .jssorb03 .av:hover     (active mouseover)
            .jssorb03 .dn           (mousedown)
            */
        .jssorb03 {
            position: absolute;
        }

            .jssorb03 div, .jssorb03 div:hover, .jssorb03 .av {
                position: absolute;
                /* size of bullet elment */
                width: 21px;
                height: 21px;
                text-align: center;
                line-height: 21px;
                color: black;
                font-size: 12px;
                background: url(Images/b03.png) no-repeat;
                overflow: hidden;
                cursor: pointer;
            }

            .jssorb03 div {
                background-position: -5px -4px;
            }

                .jssorb03 div:hover, .jssorb03 .av:hover {
                    background-position: -35px -4px;
                }

            .jssorb03 .av {
                background-position: -65px -4px;
            }

            .jssorb03 .dn, .jssorb03 .dn:hover {
                background-position: -95px -4px;
            }
    </style>
</asp:Content>
<asp:Content ID="ctnMainPlace" ContentPlaceHolderID="ContentPlace" runat="Server">



    <div style="margin: 0 0 0 5px">
        <div style="margin: 0px 10px 0 10px; font-family: Tahoma; font-size: 12px; line-height: 23px; text-align: justify">
            <br>

            <br>
        </div>
    </div>

    <div style="margin: 0 0 0 5px">
        <div style="margin: 0px 10px 0 10px; font-family: Tahoma; font-size: 12px; line-height: 23px; text-align: justify">

            <table class="MsoNormalTable" border="0" cellspacing="0" cellpadding="0" width="673" style="color: rgb(86, 86, 86); font-family: Arial; font-size: 12px; width: 505pt; border-collapse: collapse; background: white;">
                <tbody>
                    <tr style="height: 16.5pt;">
                        <td style="padding: 0cm; background: transparent;" class="auto-style2">
                            <p class="MsoNormal" style="line-height: 1.3em; margin: 0px 0px 0.0001pt;"><span style="font-size: 10pt; font-family: Tahoma, sans-serif;">&nbsp;<o:p></o:p></span></p>
                        </td>
                        <td style="padding: 0cm; background: transparent;" class="auto-style3">
                            <asp:Label ID="lblCompany" runat="server" Text="CÔNG TY ABC" ForeColor="#000099" Font-Bold="True" Font-Names="Tahoma" Font-Size="Medium"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 16.5pt;">
                        <td style="padding: 0cm; background: transparent;" class="auto-style1"></td>
                        <td style="padding: 0cm; background: transparent;" class="auto-style1">
                            <asp:Label ID="lblAddress" runat="server" Text="Địa chỉ:" ForeColor="#1B3FAD" Font-Bold="True" Font-Names="Tahoma" Font-Size="10pt"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 16.5pt;">

                        <td style="padding: 0cm; height: 16.5pt; background: transparent;"></td>
                        <td style="padding: 0cm; height: 16.5pt; background: transparent;">
                            <asp:Label ID="lblPhone" runat="server" Text="Số điện thoại:" ForeColor="#1B3FAD" Font-Bold="True" Font-Names="Tahoma" Font-Size="10pt"></asp:Label>
                        </td>
                    </tr>
                    <tr style="height: 16.5pt;">

                        <td style="padding: 0cm; height: 16.5pt; background: transparent;">
                            <p class="MsoNormal" style="line-height: 1.3em; margin: 0px 0px 0.0001pt;"><span style="font-size: 10pt; font-family: Tahoma, sans-serif;">&nbsp;<o:p></o:p></span></p>
                        </td>
                        <td style="padding: 0cm; height: 16.5pt; background: transparent;">
                            <asp:Label ID="lblEmail" runat="server" Text="Email:" ForeColor="#1B3FAD" Font-Bold="True" Font-Names="Tahoma" Font-Size="10pt"></asp:Label>
                        </td>
                    </tr>
                </tbody>
            </table>
            <br />
            <div style="text-align: left; margin: 0px; font-family: Tahoma; font-size: 13px; font-weight: bold">
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr height="30px">
                        <td height="30px" colspan="3">
                            <table height="100%" cellpadding="0" cellspacing="0" width="620px">
                                <tr style="font-weight: bold; font-size: 12px; color: #FFFFFF; font-family: Arial">
                                    <td width="70%" bordercolor="#FFFFFF" style="border-bottom-style: solid; border-bottom-width: 1px; padding-left: 5px; padding-right: 0px" background="Images/cellpic1.gif">
                                        <span style="color: #DD7B36">
                                            <asp:Label runat="server" ID="Label8" Font-Size="12px" Text="LỊCH SỬ DÙNG NƯỚC 4 THÁNG GẦN NHẤT" /></span>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    <td align="right" width="30%" bordercolor="#FFFFFF" style="border-bottom-style: solid; border-bottom-width: 1px; padding-left: 4px; padding-right: 4px" background="Images/cellpic2.jpg"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="margin-top: 5px; margin-bottom: 5px">

                <dxchartsui:WebChartControl ID="charTieuThu" runat="server" CrosshairEnabled="True" ToolTipEnabled="False" Height="400px" Width="600px">

                    <diagramserializable>
            <dxcharts:XYDiagram>
                <AxisX VisibleInPanesSerializable="-1">
                   
                </AxisX>
                <AxisY Title-Text="Đơn vị tính: đồng" Title-Visibility="True" VisibleInPanesSerializable="-1" Interlaced="True" visibility="True">
                    <label textpattern="{V:#,#}">
                    </label>
                </AxisY>
                
            </dxcharts:XYDiagram>
        </diagramserializable>

                    <seriesserializable>
                        <dxcharts:Series LabelsVisibility="True" Name="2015">
                            <labelserializable>
                                <dxcharts:SideBySideBarSeriesLabel Position="Top" TextPattern="{V:#,#}">
                                </dxcharts:SideBySideBarSeriesLabel>
                            </labelserializable>
                        </dxcharts:Series>
                        <dxcharts:Series LabelsVisibility="True" Name="2014">
                            <labelserializable>
                                <dxcharts:SideBySideBarSeriesLabel Position="Top" TextPattern="{V:#,#}">
                                </dxcharts:SideBySideBarSeriesLabel>
                            </labelserializable>
                        </dxcharts:Series>
                    </seriesserializable>

                    <titles>
            <dxcharts:ChartTitle Text="Lịch sử dùng nước 4 tháng gần nhất"></dxcharts:ChartTitle>
        </titles>

                </dxchartsui:WebChartControl>
                <asp:Label runat="server" Text="Chưa có thông tin" ID="lblChart" Visible="False"></asp:Label>
                <%=HtmlLogin %><br>
            </div>


            <div style="text-align: left; margin: 0px; font-family: Tahoma; font-size: 13px; font-weight: bold">
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr height="30px">
                        <td height="30px" colspan="3">
                            <table height="100%" cellpadding="0" cellspacing="0" width="620px">
                                <tr style="font-weight: bold; font-size: 12px; color: #FFFFFF; font-family: Arial">
                                    <td width="70%" bordercolor="#FFFFFF" style="border-bottom-style: solid; border-bottom-width: 1px; padding-left: 5px; padding-right: 0px" background="Images/cellpic1.gif">
                                        <span style="color: #DD7B36">
                                            <asp:Label runat="server" ID="Label3" Font-Size="12px" Text="THÔNG TIN THANH TOÁN TIỀN NƯỚC NHÀ BẠN" /></span>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    <td align="right" width="30%" bordercolor="#FFFFFF" style="border-bottom-style: solid; border-bottom-width: 1px; padding-left: 4px; padding-right: 4px" background="Images/cellpic2.jpg"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="margin-top: 5px; margin-bottom: 5px">

                <asp:Label runat="server" ID="lblCongNo"></asp:Label>
                <%=HtmlLogin %><br />

            </div>

            <div style="text-align: left; margin: 0px; font-family: Tahoma; font-size: 13px; font-weight: bold">
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr height="30px">
                        <td height="30px" colspan="3">
                            <table height="100%" cellpadding="0" cellspacing="0" width="620px">
                                <tr style="font-weight: bold; font-size: 12px; color: #FFFFFF; font-family: Arial">
                                    <td width="70%" bordercolor="#FFFFFF" style="border-bottom-style: solid; border-bottom-width: 1px; padding-left: 5px; padding-right: 0px" background="Images/cellpic1.gif">
                                        <span style="color: #DD7B36">
                                            <asp:Label runat="server" ID="Label4" Font-Size="12px" Text="LỊCH GHI CHỈ SỐ NHÀ BẠN" /></span>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    <td align="right" width="30%" bordercolor="#FFFFFF" style="border-bottom-style: solid; border-bottom-width: 1px; padding-left: 4px; padding-right: 4px" background="Images/cellpic2.jpg"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="margin-top: 5px; margin-bottom: 5px">

                <asp:Label runat="server" ID="lblGCS"></asp:Label>
                <%=HtmlLogin %><br>
            </div>

            <div style="text-align: left; margin: 0px; font-family: Tahoma; font-size: 13px; font-weight: bold">
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr height="30px">
                        <td height="30px" colspan="3">
                            <table height="100%" cellpadding="0" cellspacing="0" width="620px">
                                <tr style="font-weight: bold; font-size: 12px; color: #FFFFFF; font-family: Arial">
                                    <td width="70%" bordercolor="#FFFFFF" style="border-bottom-style: solid; border-bottom-width: 1px; padding-left: 5px; padding-right: 0px" background="Images/cellpic1.gif">
                                        <span style="color: #DD7B36">
                                            <asp:Label runat="server" ID="Label2" Font-Size="12px" Text="THÔNG BÁO CẤP NƯỚC NHÀ BẠN" /></span>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    <td align="right" width="30%" bordercolor="#FFFFFF" style="border-bottom-style: solid; border-bottom-width: 1px; padding-left: 4px; padding-right: 4px" background="Images/cellpic2.jpg"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div style="margin-top: 5px; margin-bottom: 5px">

                <dx:ASPxGridView ID="grvLich" OnDataBound="grvLich_OnDataBound" DataSourceID="LichDataSource" OnCustomColumnDisplayText="grvLich_OnCustomColumnDisplayText" ClientInstanceName="grvLich" EnableRowsCache="False" runat="server" Width="100%" KeyFieldName="ID" AutoGenerateColumns="False">
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
                    <SettingsDetail ShowDetailRow="True"></SettingsDetail>
                    <SettingsLoadingPanel Text="Đang tải dữ liệu"></SettingsLoadingPanel>
                    <SettingsText EmptyDataRow="Chưa có lịch cắt nước trong tuần tới"></SettingsText>
                    <SettingsDetail ShowDetailRow="True"></SettingsDetail>
                    <SettingsPager PageSize="10"></SettingsPager>
                    <SettingsBehavior AllowSort="False"></SettingsBehavior>
                </dx:ASPxGridView>
                <asp:SqlDataSource runat="server" ID="LichDataSource"
                    ConnectionString="<%$ ConnectionStrings:huewaco %>"
                    SelectCommand="SELECT * FROM dbo.tblLichCatNuoc lich WHERE lich.MaKV  = @MAKV and (NgayBatDau BETWEEN GETDATE() and GETDATE() + 7)  order by NgayBatDau desc">
                    <SelectParameters>
                        <asp:Parameter Name="MAKV" Type="String" />
                    </SelectParameters>

                </asp:SqlDataSource>
                <asp:SqlDataSource runat="server" ID="DetailDataSource"
                    ConnectionString="<%$ ConnectionStrings:huewaco %>"
                    SelectCommand="SELECT CONVERT(varchar(10), GioBatDau) + ' : ' + CONVERT(varchar(10), PhutBatDau) AS BatDau, CONVERT(varchar(10), GioKetThuc) + ' : ' + CONVERT(varchar(10), PhutKetThuc) AS KetThuc ,LyDo FROM dbo.tblLichChiTiet WHERE IDLich	= @IDLich">
                    <SelectParameters>
                        <asp:SessionParameter Name="IDLich" SessionField="IDLich" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>

                <%=HtmlLogin %><br>
            </div>



            <div style="text-align: left; margin: 0px; font-family: Tahoma; font-size: 13px; font-weight: bold">
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr height="30px">
                        <td height="30px" colspan="3">
                            <table height="100%" cellpadding="0" cellspacing="0" width="620px">
                                <tr style="font-weight: bold; font-size: 12px; color: #FFFFFF; font-family: Arial">
                                    <td width="70%" bordercolor="#FFFFFF" style="border-bottom-style: solid; border-bottom-width: 1px; padding-left: 5px; padding-right: 0px" background="Images/cellpic1.gif">
                                        <span style="color: #DD7B36">
                                            <asp:Label runat="server" ID="Label7" Font-Size="12px" Text="CHỈ DẪN CHO NGƯỜI DÙNG NƯỚC" /></span>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    <td align="right" width="30%" bordercolor="#FFFFFF" style="border-bottom-style: solid; border-bottom-width: 1px; padding-left: 4px; padding-right: 4px" background="Images/cellpic2.jpg"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>

                <table style="height: 200px">
                    <tr style="vertical-align: top">
                        <td style="width: 300px">
                            <asp:Label ForeColor="#FF1B3FAD" OnDataBinding="lblTinView_OnDataBinding" ID="lblTinTD" runat="server"></asp:Label>
                            <br />
                            <asp:Label ID="lblTinTT" Font-Bold="False" runat="server"></asp:Label>
                        </td>
                        <td style="width: 300px">
                            <dx:ASPxGridView ID="grvTinTuc" ClientInstanceName="grvCauHoi" EnableRowsCache="False" DataSourceID="TinTucDataSource"
                                runat="server" KeyFieldName="ID" Width="100%" AutoGenerateColumns="False" Theme="MetropolisBlue">
                                <Settings ShowColumnHeaders="False" GridLines="None"></Settings>

                                <Templates>
                                    <DataRow>
                                        <ul style="margin: 0px 0px 5px 0px">
                                            <li style="color: rgb(27, 63, 173);"><a href='TinTuc/<%#Eval("ID")%>/<%# MakeTitle(Eval("TieuDe").ToString())%>' style="text-decoration: none; cursor: pointer"><%#Eval("TieuDe") %></a></li>
                                        </ul>
                                    </DataRow>
                                </Templates>

                                <Border BorderStyle="None"></Border>
                                <SettingsPager PageSize="5">
                                    <PrevPageButton Visible="False"></PrevPageButton>
                                    <NextPageButton Visible="False"></NextPageButton>
                                    <Summary Visible="False"></Summary>
                                </SettingsPager>
                                <Settings VerticalScrollableHeight="200"></Settings>
                            </dx:ASPxGridView>

                            <asp:SqlDataSource ID="TinTucDataSource" runat="server"
                                ConnectionString="<%$ ConnectionStrings:huewaco %>"
                                SelectCommand="Select top(20) * from tblTinTuc order by NgayTao desc"
                                ProviderName="System.Data.SqlClient"></asp:SqlDataSource>
                        </td>
                    </tr>
                </table>
            </div>


            <div style="text-align: left; margin: 0px; font-family: Tahoma; font-size: 13px; font-weight: bold">
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr height="30px">
                        <td height="30px" colspan="3">
                            <table height="100%" cellpadding="0" cellspacing="0" width="620px">
                                <tr style="font-weight: bold; font-size: 12px; color: #FFFFFF; font-family: Arial">
                                    <td width="70%" bordercolor="#FFFFFF" style="border-bottom-style: solid; border-bottom-width: 1px; padding-left: 5px; padding-right: 0px" background="Images/cellpic1.gif">
                                        <span style="color: #DD7B36">
                                            <asp:Label runat="server" ID="Label1" Font-Size="12px" Text="CHỈ DẪN CHO NGƯỜI DÙNG NƯỚC " /></span>
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                                    <td align="right" width="30%" bordercolor="#FFFFFF" style="border-bottom-style: solid; border-bottom-width: 1px; padding-left: 4px; padding-right: 4px" background="Images/cellpic2.jpg"></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </div>
            <div id="slider1_container" style="position: relative; top: 0px; left: 0px; width: 700px; height: 230px; overflow: hidden;">
                <!-- Slides Container -->
                <div u="slides" style="cursor: move; position: absolute; left: 0px; top: 0px; width: 850px; height: 160px; overflow: hidden;">
                    <div>
                        <img u="image" src="Images/MinhHoa/1.jpg" />
                    </div>
                    <div>
                        <img u="image" src="Images/MinhHoa/2.jpg" />
                    </div>
                    <div>
                        <img u="image" src="Images/MinhHoa/3.jpg" />
                    </div>
                    <div>
                        <img u="image" src="Images/MinhHoa/4.jpg" />
                    </div>
                    <div>
                        <img u="image" src="Images/MinhHoa/5.jpg" />
                    </div>
                    <div>
                        <img u="image" src="Images/MinhHoa/6.jpg" />
                    </div>
                    <div>
                        <img u="image" src="Images/MinhHoa/7.jpg" />
                    </div>
                    <div>
                        <img u="image" src="Images/MinhHoa/8.jpg" />
                    </div>
                    <div>
                        <img u="image" src="Images/MinhHoa/9.jpg" />
                    </div>
                    <div>
                        <img u="image" src="Images/MinhHoa/10.jpg" />
                    </div>
                    <div>
                        <img u="image" src="Images/MinhHoa/11.jpg" />
                    </div>
                    <div>
                        <img u="image" src="Images/MinhHoa/12.jpg" />
                    </div>
                    <div>
                        <img u="image" src="Images/MinhHoa/13.jpg" />
                    </div>
                    <div>
                        <img u="image" src="Images/MinhHoa/14.jpg" />
                    </div>
                    <div>
                        <img u="image" src="Images/MinhHoa/15.jpg" />
                    </div>
                </div>

                <div u="navigator" class="jssorb03" style="bottom: 4px; right: 6px;">
                    <!-- bullet navigator item prototype -->
                    <div u="prototype">
                        <div u="numbertemplate"></div>
                    </div>
                </div>

            </div>
        </div>
    </div>
</asp:Content>
