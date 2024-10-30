<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="HDSD.aspx.cs" Inherits="cskh.huewaco.vn.HDSD" %>
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
                    "info": "Có tất cả _MAX_ hướng dẫn",
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
        <img style="border-width: 0px;" src="/Source/ReportIcon.gif" class="icon_image">
        <span class="subNavLink">HƯỚNG DẪN SỬ DỤNG</span>
        <div style="position: absolute; text-align: right; right: 205px; top: 330px;">
            <%--<a href = "A01_ThongTinGiaDienCu.aspx">Giá Nước cũ</a> áp dụng trước ngày 16/03/2015--%>
        </div>
    </div>
     <div id="divDanhSach" runat="server" style="margin-left: 8px; margin-right: 8px; margin-top: 20px">
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
    <div id="divChiTiet" Visible="False" runat="server" style="margin-left: 8px; margin-right: 8px; margin-top: 20px">
        <asp:Label runat="server" ID="lblContent" Font-Names="Arial" Font-Size="12px" />
    </div>
</asp:Content>
