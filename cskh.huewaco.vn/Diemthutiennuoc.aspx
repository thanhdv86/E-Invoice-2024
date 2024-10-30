<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" 
CodeBehind="Diemthutiennuoc.aspx.cs" Inherits="cskh.huewaco.vn.Diemthutiennuoc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script async defer type="text/javascript" 
        src="https://maps.googleapis.com/maps/api/js?key=AIzaSyBs9eWOYJ857BbXWtniA5oMnCL9w7cands&callback=LoadMap"></script>
    <script type="text/javascript" src="media/js/jquery.js"></script>
    <link href="media/css/jquery.dataTables.css" rel="stylesheet" />

    <script type="text/javascript" src="media/js/jquery.dataTables.js"></script>
    <script type="text/javascript">
       
        function LoadMap() {
            
            var markers = <%=GetDataMap() %>;
            var mapOptions = {
                center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
                zoom: 8,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            var infoWindow = new google.maps.InfoWindow();
            var latlngbounds = new google.maps.LatLngBounds();
            var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);
           
            for (var i = 0; i < markers.length; i++) {
                var data = markers[i];
                var myLatlng = new google.maps.LatLng(data.lat, data.lng);
                var marker = new google.maps.Marker({
                    position: myLatlng,
                    map: map,
                    title: data.title,
                    icon: data.icon
                });
                (function (marker, data) {
                    google.maps.event.addListener(marker, "click", function (e) {
                        infoWindow.setContent("<div style = 'width:150px;height:70px'>" + data.description + "</div>");
                        infoWindow.open(map, marker);
                    });
                })(marker, data);
                latlngbounds.extend(marker.position);

                //legend.innerHTML += "<div style = 'margin:5px'><img align = 'middle' src = '" + marker.icon + "' />&nbsp;" + marker.title + "</div>";
            }
            var bounds = new google.maps.LatLngBounds();
            map.setCenter(latlngbounds.getCenter());
            map.fitBounds(latlngbounds);
       
        }
    </script>
    
      <script type="text/javascript">
          $(document).ready(function () {
              LoadMap();
              $('#tablecauhoi').DataTable(
              {
                  "language": {
                      "search": "Tìm kiếm",
                      "info": "Có tất cả _MAX_ quầy thu",
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
                      }
                  ]
              });
          });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlace" runat="server">

    <div style="height: 5px">
    </div>
    <div class="TitPage" style="margin-left: 8px; margin-right: 8px">
        <img style="border-width: 0px;" src="Source/ReportIcon.gif" class="icon_image">
        <span class="subNavLink">TRA CỨU ĐIỂM THU TIỀN NƯỚC</span>
    </div>
    <div style="margin-left: 5px; margin-right: 5px">
        <fieldset class="Fieldset_border">
            <legend align="left">
                <span class="Fieldset_title_text">Chọn thông tin</span>
            </legend>
            <div class="box_space" style="padding-top: 10px; padding-bottom: 5px">
                <table cellpadding="5" cellspacing="0" width="100%">
                    <tr>
                        <td width="15%">Khu vực (Chi nhánh):</td>
                        <td width="35%">
                            <asp:DropDownList ID="ddlKV" AutoPostBack="True" OnSelectedIndexChanged="ddlKV_OnSelectedIndexChanged" DataValueField="MAKV" DataTextField="TENKV" TabIndex="2" Width="150px" runat="server" CssClass="text_combo">
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
        </fieldset>
    </div>

    <div style="margin-left: 8px; margin-right: 8px; margin-top: 10px">
        <div id="dvMap" style="width: 100%; height: 500px">
        </div>

        <div id="divListCH" runat="server" style="margin-left: 8px; margin-right: 8px; margin-top: 20px">
            <table id="tablecauhoi" class="table" cellpadding="10">
                <thead>
                    <tr>
                        <td></td>
                        <td><b>Tên quầy thu</b></td>
                        <td><b>Địa chỉ</b></td>
                    </tr>
                </thead>
                <tbody>
                    <%=htmlContent %>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
