<%@ Page Language="C#" MasterPageFile="~/CSKH.Master"  AutoEventWireup="true" CodeBehind="ThanhToanTrucTuyen.aspx.cs" Inherits="cskh.huewaco.vn.ThanhToanTrucTuyen" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript" src="/Scripts/jssor.js"></script>
    <script type="text/javascript" src="/Scripts/jssor.slider.js"></script>
    <script type="text/javascript">
        jQuery(document).ready(function ($) {
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
    <div style="height: 5px">
    </div>
    <div class="TitPage" style="margin-left: 8px; margin-right: 8px">
        <img style="border-width: 0px;" src="Source/ReportIcon.gif" class="icon_image">
        <span class="subNavLink">THANH TOÁN TRỰC TUYẾN</span>
        <div style="position: absolute; text-align: right; right: 205px; top: 330px;">
        </div>
    </div>
    <div style="margin: 0 0 0 5px">
        <div style="margin: 0px 5px 0 10px; font-family: Tahoma; font-size: 12px; line-height: 23px; text-align: justify">

            <table class="MsoNormalTable" border="0" cellspacing="0" cellpadding="0" width="673" style="color: rgb(86, 86, 86); font-family: Arial; font-size: 12px; width: 505pt; border-collapse: collapse; background: white;">
                <tbody>
                    <tr style="height: 5pt;">
                        <td style="padding: 0cm; height: 16.5pt; background: transparent;"></td>
                        <td style="padding: 0cm; height: 16.5pt; background: transparent;">
                            <p class="MsoNormal" style="line-height: 1.3em; margin: 0px 0px 0.0001pt;"><b><span style="font-size: 10pt; font-family: Tahoma, sans-serif; color: rgb(50, 50, 50);">
                                Để thanh toán trực tuyến tiền nước của HueWACO, quý khách vui lòng nhấn vào logo của đơn vị để lựa chọn phương thức thanh toán:
                                <o:p></o:p></span></b></p></td>
                    </tr>

                    <tr style="height: 16.5pt;">
                        <td style="padding: 0cm; height: 16.5pt; background: transparent;"></td>
                        <td style="padding: 0cm; height: 16.5pt; background: transparent;">
                        <a href="https://payment.momo.vn/pay/utilities/partner/MOMOD9BH20180521">
                            <img src="Images/LogoDoiTac/momo-logo-text.PNG" alt="Momo" width="100%"/> 
                        </a>
                    </tr>

                    <tr style="height: 16.5pt;">
                        <td style="padding: 0cm; height: 16.5pt; background: transparent;"></td>
                        <td style="padding: 0cm; height: 16.5pt; background: transparent;">
                             <p class="MsoNormal" style="line-height: 1.3em; margin: 0px 0px 0.0001pt;"><span style="font-size: 10pt; font-family: Tahoma, sans-serif; color: rgb(50, 50, 50);">
                                <b><u>Đặc biệt:</u></b> Nhận ngay 100,000đ để thanh toán hóa đơn HueWACO cho khách hàng lần đầu thanh toán qua kênh MoMo. Chi tiết: 
                                <a href=" https://drive.google.com/file/d/1KCrf7cbhSOGUt03Cnem92FZXrWyVSXaQ/view?usp=sharing" target="_blank">Click vào đây</a>
                                <o:p></o:p></span></p>
                            <p class="MsoNormal" style="line-height: 1.3em; margin: 0px 0px 0.0001pt;"><span style="font-size: 10pt; font-family: Tahoma, sans-serif; color: rgb(50, 50, 50);">
                                <b><u>Lưu ý:</u></b> Dịch vụ này chỉ áp dùng cho nghững khách hàng đã có tài khoản ví Momo. 
                                Đối với những khách hàng chưa đăng kí tài khoản ví Momo, vui lòng 
                                <a href="https://momo.vn/welcome/" target="_blank">Click vào đây</a> để được hướng dẫn thêm.
                                Để biết cách thức thanh toán, khách hàng <a href="../Document/huewaco_momo_huong_dan_thanh_toan_2018.pdf" target="_blank">Click vào đây</a> để được hướng dẫn.
                                <o:p></o:p></span></p>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div u="navigator" class="jssorb03" style="bottom: 4px; right: 6px;">
                <div u="prototype">
                    <div u="numbertemplate"></div>
                </div>
            </div>

            </div>
        </div>
</asp:Content>