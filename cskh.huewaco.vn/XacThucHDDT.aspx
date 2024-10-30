<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="XacThucHDDT.aspx.cs" Inherits="cskh.huewaco.vn.XacThucHDDT" %>

<%@ Register TagPrefix="dx" Namespace="DevExpress.Web" Assembly="DevExpress.Web.v14.2, Version=14.2.3.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script type="text/javascript" src="media/js/jquery.js"></script>
    <link href="media/css/jquery.dataTables.css" rel="stylesheet" />

    <script type="text/javascript" src="media/js/jquery.dataTables.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $('#tblFiles').DataTable(
            {
                "language": {
                    "sEmptyTable": "Chưa có file được tải lên"

                },
                "paging":   false,
                "ordering": false,
                "info":     false,
                "bFilter": false,
                "bSort": false,
                "bLengthChange": false
            });

            if ($('#tblFiles').dataTable().fnGetData().length > 0)
                $('#btnXacThuc').removeAttr('disabled');
        });
    </script>
    <script type="text/javascript">
        function onFileUploadComplete(s, e) {
            if (e.callbackData) {

                if (e.callbackData != "false") {
                    $('#tblFiles').DataTable().row.add([e.callbackData, '']).draw();

                    if ($('#tblFiles').dataTable().fnGetData().length > 0)
                         $('#btnXacThuc').removeAttr('disabled');
                } else {
                    alert("File đã tồn tại trong danh sách");
                }
               

            }
        }

        function PerformCallbackControl(s, e) {
           
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlace" runat="server">

    <div style="height: 5px">
    </div>
    <div class="TitPage" style="margin-left: 8px; margin-right: 8px">
        <img style="border-width: 0px;" src="Source/ReportIcon.gif" class="icon_image">
        <span class="subNavLink">HÓA ĐƠN ĐIỆN TỬ</span>
    </div>
    <div style="margin-left: 8px; margin-right: 8px; margin-top: 20px">

        <fieldset class="Fieldset_border">
            <legend align="left"><span class="Fieldset_title_text">Vui lòng nhập thông tin</span>
            </legend>
            <div class="box_space" style="padding-top: 10px; padding-bottom: 5px">
                <table cellpadding="5" cellspacing="0">
                    <tr>
                        <td width="30%">Chọn file cần xác thực: 
                        </td>
                        <td width="30%">
                            
                            <dx:ASPxUploadControl ID="UploadControl" ClientInstanceName="UploadControl" runat="server" UploadMode="Advanced" ShowUploadButton="True" ShowProgressPanel="True" OnFileUploadComplete="UploadControl_FileUploadComplete"  >
                                <ValidationSettings MaxFileSize="4194304" AllowedFileExtensions=".xml" ErrorStyle-CssClass="validationMessage">
                                    <ErrorStyle CssClass="validationMessage"></ErrorStyle>
                                </ValidationSettings>

                                <ClientSideEvents FileUploadComplete="onFileUploadComplete" />
                                
                                <BrowseButton Text="Chọn file hóa đơn XML" />
                                <RemoveButton Text="Xóa"> </RemoveButton> 
                                <UploadButton Text="Thêm vào danh sách"></UploadButton>
                                <AdvancedModeSettings  EnableMultiSelect="True" EnableFileList="True"></AdvancedModeSettings>
                            </dx:ASPxUploadControl>
                            
                            <dx:ASPxCallback runat="server" ID="callback" ClientInstanceName="callback" OnCallback="OnCallback"></dx:ASPxCallback>
                        </td>
                    </tr>


                </table>
                <br />
                <hr />
                <b>Danh sách file sẽ xác thực</b>
                <div>
                    <table id="tblFiles" class="table" width="100%" >
                        <thead style="background-color: #0096DF; color: white; font-weight: bold">
                            <tr>
                                <td style="width: 100px">Tên file</td>
                                <td style="width: 200px">Kết quả</td>
                            </tr>

                        </thead>
                        <tbody>
                            <%=HtmlFile %>
                        </tbody>
                    </table>
                </div>

            </div>
            <div class="box_space" style="padding-left: 100px">
                 <b>Nhập mã xác thực</b>
                <dx:ASPxCaptcha runat="server" ID="Captcha">
                    <ValidationSettings SetFocusOnError="true" ErrorDisplayMode="Text" ErrorText="Mã xác thực không đúng"/>
                    <RefreshButton Text="Hiện mã khác"></RefreshButton>
                    <TextBox LabelText="Nhập mã bên cạnh:" />
                </dx:ASPxCaptcha>

            </div>
            <div>

                <asp:Button runat="server" OnClick="btnXacThuc_OnClick" ClientIDMode="Static" Enabled="False" Text="Xác thực" ID="btnXacThuc" />
            </div>
        </fieldset>
    </div>

</asp:Content>
