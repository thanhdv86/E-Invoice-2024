<%@ Page Title="" Language="C#" MasterPageFile="~/CSKH.Master" AutoEventWireup="true" CodeBehind="LichSuThanhToan.aspx.cs" Inherits="cskh.huewaco.vn.LichSuThanhToan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlace" runat="server">
    <div class="TitPage">
        <asp:Image ID="imgIcon" runat="server" CssClass="icon_image" ImageUrl="Images/ReportIcon.gif" />
        <span class="subNavLink">
            <asp:Label ID="Label11" runat="server" Text="Lịch sử thanh toán / Sử dụng Nước" Font-Size="12pt"
                Font-Bold="True"></asp:Label>
        </span>
    </div>

    <div id="mak" style="margin: 20px 0 20px 0;">
        <center>
            <a style="text-decoration: none; font-weight: bold; margin: 4px 0 0 7px; background-color: #0096DF; padding: 5px; color: Yellow" href="C03_LichSuThanhToan.aspx">THEO MÃ KHÁCH HÀNG</a>
            <a style="margin: 4px 0 0 7px">| </a>
            <a style="text-decoration: none; font-weight: bold; margin: 4px 7px 0 7px; color: #0096DF" href="C03_LichSuThanhToan_Ten.aspx">THEO TÊN KHÁCH HÀNG</a>
        </center>
    </div>

    <hr />

    <div id="Tde" style="margin: 20px 0 0 0;">
        <center>
            <i>
                <asp:Label ID="Label4" runat="server" ForeColor="#006699">* Mã khách hàng: là dãy 13 ký tự được in ở Giấy báo tiền Nước hoặc Hóa đơn tiền Nước</asp:Label></i>
        </center>
    </div>

    <table border="0" style="margin: 20px 0 20px 230px">
        <tr align="left">
            <td>Mã khách hàng</td>
            <td>
                <asp:TextBox runat="server" ID="TxtMKH" Width="120px" MaxLength="13"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="cmdIn" runat="server" Text="Xem" Width="90px" Height="30px" OnClick="cmdIn_Click1" /></td>
        </tr>
    </table>
    <div id="Thongbao" style="margin: 15px 0 10px 0;">
        <center><b>
            <asp:Label ID="Label1" runat="server" ForeColor="#cc3300"></asp:Label></b></center>
    </div>
    <div id="Ctiet" style="border-top: 0px solid red">
        <div id="Thongtin" class="fl" style="margin: 0 0 10px 0; display: inline; width: 740px; font-size: 11px; border-top: 0px solid #CFCFCF" runat="server"></div>
    </div>

    <div id="NO" style="border: 0px solid red; width: 737px; padding: 3px">
        <div style="font-weight: bold; color: #cc3300; margin: 0 0 10px 0">
            <center>
                <asp:Label ID="NoKH" runat="server"></asp:Label></center>
        </div>
        <asp:DataGrid ID="G_no" runat="server" Width="100%" AllowPaging="True" AutoGenerateColumns="False" AllowSorting="True" HeaderStyle-Height="30px" PageSize="50">
            <ItemStyle Font-Size="11px" Font-Names="Verdana" HorizontalAlign="Center" Height="23px"></ItemStyle>
            <HeaderStyle Font-Size="11px" BackColor="GhostWhite" Font-Bold="True" HorizontalAlign="Center" VerticalAlign="Middle"></HeaderStyle>

            <Columns>

                <asp:TemplateColumn HeaderText="Tháng/năm">
                    <HeaderStyle Width="18%"></HeaderStyle>
                    <ItemTemplate>
                        <asp:Label ID="Label1thang" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.THANG") %>'></asp:Label>
                        <asp:Label ID="Label7" runat="server" Text='/'></asp:Label>
                        <asp:Label ID="Label1nam" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.NAM") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Kỳ thứ">
                    <HeaderStyle Width="10%"></HeaderStyle>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.KY") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Số hóa đơn">
                    <HeaderStyle Width="10%"></HeaderStyle>
                    <ItemTemplate>
                        <asp:Label ID="Label2hd" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.SO_HDON") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Loại hóa đơn">
                    <HeaderStyle Width="17%"></HeaderStyle>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.LOAI_HDON") %>'>
                        </asp:Label>
                    </ItemTemplate>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Tổng tiền hóa đơn" ItemStyle-HorizontalAlign="Right">
                    <HeaderStyle Width="22%"></HeaderStyle>
                    <ItemTemplate>
                        <b>
                            <asp:Label ID="Label6hd" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TIEN_PSINH", "{0:# ### ### ##0}") %>'>
                            </asp:Label></b>
                    </ItemTemplate>

                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateColumn>

                <asp:TemplateColumn HeaderText="Tổng tiền nợ" ItemStyle-HorizontalAlign="Right">
                    <HeaderStyle Width="23%"></HeaderStyle>
                    <ItemTemplate>
                        <b>
                            <asp:Label ID="Label6" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.TIEN_NO", "{0:# ### ### ##0}") %>'>
                            </asp:Label></b>
                    </ItemTemplate>

                    <ItemStyle HorizontalAlign="Right"></ItemStyle>
                </asp:TemplateColumn>

            </Columns>
            <PagerStyle HorizontalAlign="Right" Position="Bottom" Visible="false" Mode="NumericPages" BackColor="FloralWhite" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="True"></PagerStyle>
        </asp:DataGrid>

        <div style="margin: 20px 0 10px 0">
            <b>
                <asp:Label ID="Labno" runat="server" ForeColor="#0066CC"></asp:Label></b>
        </div>
    </div>
</asp:Content>