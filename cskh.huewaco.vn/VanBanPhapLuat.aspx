<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="VanBanPhapLuat.aspx.cs" Inherits="cskh.huewaco.vn.VanBanPhapLuat" %>

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
                    "info": "Có tất cả _MAX_ văn bản",
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
        <span class="subNavLink">CÁC VĂN BẢN THƯỜNG GẶP</span>
    </div>
    <div id="divListCH" runat="server" style="margin-left: 8px; margin-right: 8px; margin-top: 20px">
        <table id="tablecauhoi" class="hover" cellpadding="10">
            <thead>
                <tr>
                    <td></td>
                    <td></td>
                    <td></td>
                </tr>
            </thead>
            <tbody>
                <%=htmlContent %>
            </tbody>
        </table>
    </div>
   
</asp:Content>
