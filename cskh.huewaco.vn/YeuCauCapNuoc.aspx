<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="YeuCauCapNuoc.aspx.cs" Inherits="cskh.huewaco.vn.YeuCauCapNuoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlace" runat="server">
    <div style="margin: 0 0 0 5px">
        <div style="margin: 0px 10px 0 5px; font-family: Tahoma; font-size: 12px; line-height: 23px; text-align: justify">
            <div class="TitPage">
                <img class="icon_image" src="Images/ReportIcon.gif" style="border-width: 0px;" />
                <span class="subNavLink">
                    <span style="font-size: 14pt; font-weight: bold;">Yêu cầu lắp đặt, thay nâng, dò tìm nước chảy</span>
                </span>
            </div>

            <div style="padding-bottom: 10px;">
                <div class="LineBE">
                    <div>
                        &nbsp; 
                    </div>
                    <div>
                        <fieldset style="text-align: left;">
                            Những mục có dấu
                                <label style="color: Red;">
                                    *
                                </label>
                            là bắt buộc phải nhập
                        </fieldset>
                    </div>
                </div>
                <div class="LineBE">
                    <fieldset style="text-align: left;">
                        <legend>
                            <span>
                                <asp:Label ID="Label1" runat="server" Text="Thủ tục"></asp:Label></span>
                        </legend>

                        <asp:ScriptManager ID="ScriptManager1" runat="server">
                        </asp:ScriptManager>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <div class="LineBE">
                                    <div class="LeftCol_right">
                                        <asp:Label ID="Label4" runat="server" Text="Loại hình yêu cầu"></asp:Label>
                                    </div>
                                    <div class="RightCol">
                                        <asp:RadioButtonList ID="rbLoaiDK" TabIndex="0" Width="300px" runat="server" CssClass="text_combo">
                                            <asp:ListItem Value="YCCM">Yêu cầu lắp đặt nước mới</asp:ListItem>
                                            <asp:ListItem Value="YCNH">Yêu cầu lắp đặt nước ngắn hạn</asp:ListItem>
                                            <asp:ListItem Value="YCSC">Yêu cầu thay nâng, dời, dò tìm nước chảy</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <span class="validate_rightCol">
                                        <asp:RequiredFieldValidator ID="rfvLoaiDK" runat="server" ControlToValidate="rbLoaiDK" SetFocusOnError="True" ValidationGroup="VAL" CssClass="ReqNewEUseTDRight" Display="Dynamic" Style="color: Red" ErrorMessage="*" />
                                    </span>
                                </div>
                                <div class="LineBE">
                                    <div class="LeftCol_right">
                                        <asp:Label ID="Label2" runat="server" Text="Chi nhánh (Khu vực)"></asp:Label>
                                    </div>
                                    <div class="RightCol">
                                        <asp:DropDownList ID="ddlKhuVuc" DataValueField="MAKV" DataTextField="TENKV" TabIndex="2" Width="300px" runat="server" CssClass="text_combo">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="lineCol">
                                    <div class="col1">
                                        <div class="LineBE">
                                            <div class="LeftCol_right">
                                                <asp:Label ID="Label3" runat="server" Text="Quận(huyện)"></asp:Label><span style="color: Red">(*)</span>
                                            </div>
                                            <div class="RightCol">
                                                <asp:DropDownList ID="ddlQuan" AutoPostBack="True" DataValueField="MAQUAN" DataTextField="TENQUAN" TabIndex="2" Width="150px" runat="server" CssClass="text_combo">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col2">
                                        <div class="LineBE">
                                            <div class="LeftCol_right">
                                                <asp:Label ID="Label5" runat="server" Text="Phường(xã)"></asp:Label><span style="color: Red">(*)</span>
                                            </div>
                                            <div class="RightCol">
                                                <asp:DropDownList ID="ddlPhuong" DataValueField="MAPHUONG" DataTextField="TENPHUONG" TabIndex="2" Width="150px" runat="server" CssClass="text_combo">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="LineBE">
                                    <div class="LeftCol_right">
                                        <asp:Label ID="lblCustumerName" runat="server" Text="Tên khách hàng "></asp:Label><span style="color: Red">(*)</span>
                                    </div>
                                    <div class="RightCol">
                                        <asp:DropDownList runat="server" ID="drlKhachHang">
                                            <asp:ListItem Text="Ông"></asp:ListItem>
                                            <asp:ListItem Text="Bà"></asp:ListItem>
                                            <asp:ListItem Text="Cơ quan"></asp:ListItem>
                                        </asp:DropDownList>
                                        <asp:TextBox ID="txtTenKH" runat="server" Width="420px" TabIndex="3" MinLength="3" MaxLength="150"></asp:TextBox>
                                    </div>
                                    <span class="validate_rightCol">
                                        <asp:RequiredFieldValidator ID="rfvTenKH" runat="server" ControlToValidate="txtTenKH" SetFocusOnError="True" ValidationGroup="VAL" CssClass="registerAccountTDRight" Display="Dynamic" Style="color: Red" ErrorMessage="*" />
                                    </span>
                                </div>

                                <div class="lineCol">
                                    <div class="col1">
                                        <div class="LineBE">
                                            <div class="LeftCol_right">
                                                <asp:Label ID="Label9" runat="server" Text="Số nhà "></asp:Label><span style="color: Red">(*)</span>
                                            </div>
                                            <div class="RightCol">
                                                <asp:TextBox ID="txtSoNha" runat="server" Width="150px" TabIndex="11" MaxLength="100"></asp:TextBox>
                                                <%--  <asp:Label ID="Label10" ForeColor="Red" runat="server" Text="*"></asp:Label>--%>
                                            </div>
                                            <span class="validate_rightCol">
                                                <asp:RequiredFieldValidator ID="rfvsoNha" runat="server" ControlToValidate="txtSoNha" SetFocusOnError="True" ValidationGroup="VAL" CssClass="ReqNewEUseTDRight" Display="Dynamic" Style="color: Red" ErrorMessage="*" />
                                            </span>
                                        </div>
                                    </div>
                                    <div class="col2">
                                        <div class="LineBE">
                                            <div class="LeftCol_right">
                                                <asp:Label ID="Label11" runat="server" Text="Đường phố "></asp:Label><span style="color: Red">(*)</span>
                                            </div>
                                            <div class="RightCol">
                                                <asp:TextBox ID="txtDuongPho" runat="server" Width="145px" TabIndex="12" MaxLength="100"></asp:TextBox>
                                                <%--<asp:Label ID="Label12" ForeColor="Red" runat="server" Text="*"></asp:Label>--%>
                                            </div>
                                            <asp:RequiredFieldValidator ID="rfvDgPHo" runat="server" ControlToValidate="txtDuongPho" SetFocusOnError="True" ValidationGroup="VAL" CssClass="registerAccountTDRight" ErrorMessage="*" Display="Dynamic" ForeColor="Red" />
                                        </div>
                                    </div>
                                </div>


                                <div class="LineBE">
                                    <div class="LeftCol_right">
                                        <span id="ctl00_ContentPlaceHolder1_ctl00_Label20">Email </span>
                                    </div>
                                    <div class="RightCol">
                                        <asp:TextBox ID="txtEmail" runat="server" TabIndex="16" Style="width: 200px;"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="VAL" />
                                    </div>
                                </div>
                                <div class="LineBE">
                                    <div class="LeftCol_right">
                                        <span id="Span1">Số điện thoại </span><span style="color: Red">(*)</span>
                                    </div>
                                    <div class="RightCol">
                                        <asp:TextBox ID="txtSDT" runat="server" MaxLength="11" TabIndex="16" Style="width: 200px;"></asp:TextBox>
                                        <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSDT" ValidationExpression="^([0-9\(\)\/\+ \-]*)$" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="VAL" />--%>
                                        <asp:RegularExpressionValidator ID="revSDT" runat="server" ControlToValidate="txtSDT" ValidationExpression="^([0-9]{7}|[0-9]{10}|[0-9]{11})$" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="VAL" />
                                        <asp:RequiredFieldValidator ID="rfvSDT" runat="server" ControlToValidate="txtSDT" SetFocusOnError="True" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="VAL"/>
                                    </div>
                                </div>
                                <div class="LineBE">
                                    <div class="LeftCol_right">
                                        <span id="ctl00_ContentPlaceHolder1_ctl00_Label21">Nội dung yêu cầu </span>
                                    </div>
                                    <div class="RightCol">
                                        <asp:TextBox ID="txtNoiDung" TextMode="MultiLine" Rows="10" runat="server" type="text" TabIndex="17" Width="500px"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvNoiDung" runat="server" ControlToValidate="txtNoiDung" SetFocusOnError="True" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="VAL"/>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </fieldset>
                </div>
                <div class="LineBE">
                    Khách hàng có thể tải mẫu đơn dưới đây để điền thông tin:
                    <ul style="padding-left: 20px">
                        <li>Mẫu đơn lắp đặt nước <a href="VanBan/MauDon/maulapdat.doc" target="_blank">
                            <img src="Images/icon_download.png" height="20px"></a></li>
                        <%--   <li>Mẫu đơn lắp đặt nước ngắn hạn <a href="VanBan/MauDon/maulapdatdaihan.doc" target="_blank"><img src="Images/icon_download.png" height="20px"></a></li>
                        <li>Mẫu đơn thay nâng, dời, dò tìm nước chảy <a href="VanBan/MauDon/mausuachua.doc" target="_blank"><img src="Images/icon_download.png" height="20px"></a></li>--%>
                    </ul>
                </div>
                <div class="LineBE">

                    <asp:Button ID="btnDangKy" runat="server" ValidationGroup="VAL" OnClick="btnDangKy_OnClick" CssClass="button cyan validate" Text="Đăng ký" CausesValidation="true" />

                </div>
            </div>
        </div>
    </div>
</asp:Content>
