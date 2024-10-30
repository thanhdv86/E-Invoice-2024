<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="CauHoi.aspx.cs" Inherits="cskh.huewaco.vn.CauHoi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        <span class="subNavLink">CÁC CÂU HỎI THƯỜNG GẶP</span>
    </div>
    <div id="divListCH" runat="server" style="margin-left: 8px; margin-right: 8px; margin-top: 20px">
        <table id="tablecauhoi" class="hover" cellspacing="0">
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
