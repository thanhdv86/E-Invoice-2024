<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" ValidateRequest="false" CodeBehind="HoiDap.aspx.cs" Inherits="cskh.huewaco.vn.HoiDap" %>

<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=3.0.30930.28736, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

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
            width: 800px;
        }
    </style>
    <script type="text/javascript">

        function closePopup() {

            $find("MPE").hide();

        }
    </script>
    <script type="text/javascript" src="media/js/jquery.js"></script>
    <link href="media/css/jquery.dataTables.css" rel="stylesheet" />

    <script type="text/javascript" src="media/js/jquery.dataTables.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#tablecauhoi').DataTable(
            {
                "language": {
                    "search": "Tìm kiếm",
                    "info": "Có tất cả _MAX_ câu hỏi",
                    "paginate": {
                        "first": " Đầu ",
                        "last": " Cuối ",
                        "next": " Sau ",
                        "previous": " Trước "
                    }

                },
                "bFilter": false,
                "bSort": false,
                "bLengthChange": false,
                "aoColumnDefs": [
                {
                    "bSortable": false
                }]
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlace" runat="server">
    <div style="height: 5px">
    </div>
    <div class="TitPage" style="margin-left: 8px; margin-right: 8px">
        <img style="border-width: 0px;" src="Source/ReportIcon.gif" class="icon_image">
        <span class="subNavLink">Chuyên mục hỏi đáp</span>
    </div>

    <div id="divListCH" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <!-- Modal -->
        <asp:UpdatePanel ID="upContent" runat="server">
            <Triggers>
                <asp:PostBackTrigger ControlID="btnSearch" />
            </Triggers>
            <ContentTemplate>
                <div style="margin-left: 8px; margin-right: 8px">
                    <fieldset class="Fieldset_border">
                        <legend align="left">
                            <span class="Fieldset_title_text">Tìm kiếm nhanh</span>
                        </legend>
                        <div class="box_space" style="padding-top: 10px; padding-bottom: 5px">
                            <table cellpadding="5" cellspacing="0">
                                <tr>
                                    <td width="15%">Từ khóa tìm kiếm: 
                                    </td>
                                    <td width="60%">
                                        <asp:TextBox runat="server" ID="txtSearch" Width="100%"></asp:TextBox>
                                    </td>
                                    <td width="15%">
                                        <asp:Button runat="server" CssClass="button cyan validate" OnClick="btnSearch_OnClick" ID="btnSearch" Text="Tìm kiếm"></asp:Button>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%">Hoặc 
                                    </td>
                                    <td width="60%">
                                        <asp:Button runat="server" CssClass="button cyan validate" ID="btnPopUp" Text="Gửi câu hỏi"></asp:Button>
                                    </td>

                                </tr>
                            </table>
                        </div>
                    </fieldset>
                </div>

                <cc1:ModalPopupExtender ID="mp1" runat="server" BehaviorID="MPE" PopupControlID="Panel1"
                    TargetControlID="btnPopUp" BackgroundCssClass="modalBackground">
                </cc1:ModalPopupExtender>
                <asp:Panel ID="Panel1" ClientIDMode="Static" runat="server" CssClass="modalPopup"
                    align="center" Style="display: none">

                    <fieldset class="Fieldset_border">
                        <legend align="left"><span class="Fieldset_title_text">Hỏi đáp</span>
                        </legend>
                        <div class="box_space" style="padding-top: 10px; padding-bottom: 5px">
                            <table>
                                <tr>
                                    <td width="15%">Tiêu đề câu hỏi: 
                                    </td>
                                    <td width="70%">
                                        <asp:TextBox runat="server" ID="txtTieuDe" Width="100%"></asp:TextBox>

                                    </td>
                                    <td width="15%">
                                        <span>
                                            <asp:RequiredFieldValidator ID="rfvTieuDe" runat="server" ControlToValidate="txtTieuDe" SetFocusOnError="True" ValidationGroup="VAL" Style="color: Red" ErrorMessage="Nhập tiêu đề" />
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%">Nội dung: 
                                    </td>
                                    <td width="70%">
                                        <asp:TextBox runat="server" TextMode="MultiLine" Rows="20" ID="txtNoiDung" Width="100%"></asp:TextBox>
                                    </td>
                                    <td width="15%">
                                        <span class="validate_rightCol">
                                            <asp:RequiredFieldValidator ID="rfvNoiDung" runat="server" ControlToValidate="txtNoiDung" SetFocusOnError="True" ValidationGroup="VAL" Style="color: Red" ErrorMessage="Nhập nội dung" />
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%">Thông tin liên hệ (Tên hoặc SĐT): 
                                    </td>
                                    <td width="70%">
                                        <asp:TextBox runat="server" ID="txtLienHe" Width="100%" MaxLength="255"></asp:TextBox>
                                    </td>
                                    <td width="15%">
                                        <span class="validate_rightCol">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLienHe" SetFocusOnError="True" ValidationGroup="VAL" Style="color: Red" ErrorMessage="Nhập thông tin" />
                                        </span>
                                    </td>
                                </tr>
                                <tr>
                                    <td width="15%">SĐT: 
                                    </td>
                                    <td width="70%">
                                        <asp:TextBox runat="server" ID="txtSDT" Width="100%" MaxLength="255"></asp:TextBox>
                                    </td>
                                    <td width="15%">
                                        <span class="validate_rightCol">
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtSDT" SetFocusOnError="True" ValidationGroup="VAL" Style="color: Red" ErrorMessage="Nhập thông tin" />
                                        </span>
                                    </td>
                                </tr>
                                </tr>
                                    <tr>
                                        <td width="15%">Email: 
                                        </td>
                                        <td width="70%">
                                            <asp:TextBox runat="server" ID="txtEmail" Width="100%" MaxLength="255"></asp:TextBox>
                                        </td>
                                        <td width="15%">
                                            <span class="validate_rightCol">
                                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtEmail" SetFocusOnError="True" ValidationGroup="VAL" Style="color: Red" ErrorMessage="Nhập thông tin" />
                                                <asp:RegularExpressionValidator ID="regexEmailValid" runat="server" ValidationExpression="\w+([-+.]\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ErrorMessage="Email không đúng" Display="Dynamic" ForeColor="Red" ValidationGroup="VAL" />
                                            </span>
                                        </td>
                                    </tr>
                                <tr>
                                    <td width="15%"></td>
                                    <td width="70%">
                                        <asp:Button runat="server" CssClass="button cyan validate" ValidationGroup="VAL" OnClick="btnGuiCH_OnClick" ID="btnGuiCH" Text="Gửi câu hỏi"></asp:Button>
                                        <input type="button" class="button cyan validate" id="btnClose" value="Hủy" onclick="closePopup()" />
                                    </td>

                                    <td></td>
                                </tr>
                            </table>
                        </div>
                    </fieldset>
                </asp:Panel>

                <div style="margin-left: 8px; margin-right: 8px">
                    <table id="tablecauhoi" class="table" cellpadding="10">
                        <thead>
                            <tr>
                                <td></td>
                                <td></td>
                            </tr>
                        </thead>
                        <tbody>
                            <%=htmlContent %>
                        </tbody>
                    </table>
                    <%-- <dx:ASPxGridView ID="grdCauHoi" ClientInstanceName="grdCauHoi"  DataSourceID="CauHoiDatasource" runat="server" KeyFieldName="ID" Width="100%" EnableRowsCache="False" AutoGenerateColumns="False" Theme="MetropolisBlue">
                    <Columns>
                        <dx:GridViewDataColumn Caption="Câu hỏi" FieldName="TieuDe" VisibleIndex="1">
                        </dx:GridViewDataColumn>
                    </Columns>
                    <Settings ShowColumnHeaders="True"></Settings>
                    <SettingsBehavior AllowSort="False" ></SettingsBehavior>
                    <SettingsPager PageSize="10">
                        <Summary AllPagesText="Trang: {0} - {1} ({2} câu hỏi)" Text="Trang {0} of {1} ({2} câu hỏi)" />
                    </SettingsPager>
                </dx:ASPxGridView>
                <asp:SqlDataSource ID="CauHoiDatasource" runat="server"
                    ConnectionString="<%$ ConnectionStrings:huewaco %>"
                    SelectCommand="Select TieuDe,NoiDung from tblCauHoi Where (NoiDung like N'%' + RTRIM(@KeySearch) + '%' or TieuDe like N'%' + RTRIM(@KeySearch) + '%') order by NgayTao desc">
                    <SelectParameters>
                        <asp:SessionParameter Name="KeySearch" DefaultValue=" " SessionField="KeySearch" Type="String" />
                    </SelectParameters>
                </asp:SqlDataSource>--%>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>
    </div>

    <div id="divCauHoi" runat="server" style="margin-left: 8px; margin-right: 8px; margin-top: 20px">
        <table>
            <tr style="vertical-align: top;">
                <td style="text-align: center">
                    <img src='images/icon_question.png' /></td>
                <td>
                    <b>Nội dung câu hỏi: </b>
                    <asp:Label runat="server" ID="lblNoiDung" Font-Names="Arial" Font-Size="14px" ForeColor="#000000" />
                </td>
            </tr>
            <tr style="vertical-align: top">
                <td style="text-align: center">
                    <img src='images/icon_traloi.png' /></td>
                <td>
                    <b>Câu trả lời:</b>
                    <asp:Label runat="server" ID="lblTraLoi" Font-Names="Arial" Font-Size="14px" ForeColor="#000000" />
                </td>
            </tr>

        </table>

    </div>

</asp:Content>
