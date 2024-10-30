<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="DichVu.aspx.cs" Inherits="cskh.huewaco.vn.DichVu" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>
<%@ Register TagPrefix="uc1" TagName="ctrlsearchcustomer" Src="~/Control/ctrlSearchCustomer.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function OnGridFocusedRowChanged() {
            // Query the server for the "EmployeeID" and "Notes" fields from the focused row 
            // The values will be returned to the OnGetRowValues() function
            grdKetQua.GetRowValues(grdKetQua.GetFocusedRowIndex(), 'idkh', OnGetRowValues);
            grdKetQua.GetRowValues(grdKetQua.GetFocusedRowIndex(), 'tenkh', OnGetRowValuesTen);
        }
        // Value array contains "EmployeeID" and "Notes" field values returned from the server 
        function OnGetRowValues(values) {
            txtContractNumber.SetText(values);

        }

        function OnGetRowValuesTen(values) {

            txtCustomerName.SetText(values);
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlace" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UDPDichvu" runat="server">
        <ContentTemplate>
            <div style="margin: 0 0 0 5px">
                <div style="margin: 0px 10px 0 5px; font-family: Tahoma; font-size: 12px; line-height: 23px; text-align: justify">
                    <div class="TitPage">
                        <img class="icon_image" src="Images/ReportIcon.gif" style="border-width: 0px;" />
                        <span class="subNavLink">
                            <span style="font-size: 14pt; font-weight: bold;">Đăng ký sử dụng dịch vụ</span>
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
                                        <asp:Label ID="Label1" runat="server" Text="Nhập thông tin"></asp:Label></span>
                                </legend>


                                <div class="LineBE">
                                    <div class="LeftCol_right">
                                        <asp:Label ID="Label4" runat="server" Text="Loại dịch vụ"></asp:Label>
                                    </div>
                                    <div class="RightCol">
                                        <asp:RadioButtonList ID="rbLoaiDK" TabIndex="0" Width="300px" runat="server" CssClass="text_combo">
                                            <asp:ListItem Value="EMAIL" Selected="True">Nhận hóa đơn điện tử qua Email</asp:ListItem>                                            
                                            <asp:ListItem Value="HDGIAY" Selected="False">Đăng ký nhận Hóa đơn điện tử chuyển đổi ra giấy</asp:ListItem>
                                            <asp:ListItem Value="SMS" Selected="False">Đăng ký nhận thông báo qua tin nhắn</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <span class="validate_rightCol">
                                        <asp:RequiredFieldValidator ID="rfvLoaiDK" runat="server" ControlToValidate="rbLoaiDK" SetFocusOnError="True" ValidationGroup="VAL" Display="Dynamic" Style="color: Red" ErrorMessage="*" />
                                    </span>
                                </div>

                                <div class="LineBE">
                                    <div class="LeftCol_right">
                                        <asp:Label ID="Label3" runat="server" Text="Mã khách hàng"></asp:Label><span style="color: Red">(*)</span>
                                    </div>
                                    <div class="RightCol">
                                        <dx:ASPxTextBox runat="server" ClientInstanceName="txtContractNumber" ID="txtContractNumber" Width="180px"></dx:ASPxTextBox>
                                        <asp:Label ID="lblError_idkh" Visible="False" runat="server"><span style="color: Red">Mã khách hàng không tồn tại</span></asp:Label> 
                                    </div>
                                    <span class="validate_rightCol">
                                        <asp:RequiredFieldValidator ID="rfvMaKH" runat="server" ErrorMessage="*" Display="Dynamic" SetFocusOnError="True" ControlToValidate="txtContractNumber" ValidationGroup="VAL" ForeColor="Red" /></span>
                                </div>

                                <div class="LineBE">
                                    <div class="LeftCol_right">
                                        <asp:Label ID="lblCustumerName" runat="server" Text="Tên khách hàng "></asp:Label><span style="color: Red">(*)</span>
                                    </div>
                                    <div class="RightCol">
                                        <dx:ASPxTextBox ID="txtCustomerName" ClientInstanceName="txtCustomerName" runat="server" MaxLength="150"></dx:ASPxTextBox>
                                    </div>
                                    <span class="validate_rightCol">
                                        <asp:RequiredFieldValidator ID="rfvTenKH" runat="server" ControlToValidate="txtCustomerName" SetFocusOnError="True" ValidationGroup="VAL" CssClass="registerAccountTDRight" Display="Dynamic" Style="color: Red" ErrorMessage="*" />
                                    </span>
                                </div>




                                <div class="LineBE">
                                    <div class="LeftCol_right">
                                        <span>Email </span><span style="color: Red">(*)</span>
                                    </div>
                                    <div class="RightCol">
                                        <asp:TextBox ID="txtEmail" runat="server" TabIndex="16" Style="width: 200px;"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" ControlToValidate="txtEmail" ErrorMessage="Email không đúng định dạng" SetFocusOnError="True" Display="Dynamic" ForeColor="Red" ValidationGroup="VAL" />
                                    </div>
                                     <span class="validate_rightCol">
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" SetFocusOnError="True" ValidationGroup="VAL" CssClass="registerAccountTDRight" Display="Dynamic" Style="color: Red" ErrorMessage="*" />
                                    </span>
                                </div>
                                <div class="LineBE">
                                    <div class="LeftCol_right">
                                        <span>Số điện thoại </span><span style="color: Red">(*)</span>
                                    </div>
                                    <div class="RightCol">
                                        <asp:TextBox ID="txtSDT" runat="server" TabIndex="16" Style="width: 200px;"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtSDT" ValidationExpression="^([0-9\(\)\/\+ \-]*)$" ErrorMessage="*" Display="Dynamic" ForeColor="Red" ValidationGroup="VAL" />
                                    </div>

                                </div>


                            </fieldset>
                        </div>
                        <div style="text-align: center">

                            <asp:UpdateProgress runat="server" ID="UpdateProgressDK" AssociatedUpdatePanelID="UDPDichvu" DisplayAfter="0" DynamicLayout="True">
                                <ProgressTemplate>
                                    <img alt="" width="50px" src="Images/processing.gif" />
                                </ProgressTemplate>
                            </asp:UpdateProgress>
                        </div>
                        <div class="LineBE">

                            <asp:Button ID="btnDangKy" runat="server" ValidationGroup="VAL" OnClick="btnDangKy_OnClick" CssClass="button cyan validate" Text="Đăng ký" CausesValidation="true" />

                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <uc1:ctrlsearchcustomer runat="server" id="ctrlSearchCustomer" />
    
</asp:Content>
