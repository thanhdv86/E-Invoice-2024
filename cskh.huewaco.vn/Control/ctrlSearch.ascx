<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlSearch.ascx.cs" Inherits="cskh.huewaco.vn.Control.ctrlSearch" %>



<div style="margin-left:5px; margin-right:5px">
    <fieldset class="Fieldset_border">
        <legend align="left">
            <span class="Fieldset_title_text"><% =getString("strDieuKien")%></span>                
        </legend>
        <div class="box_space" style="padding-top:10px; padding-bottom:5px">
            <table cellpadding=2 cellspacing=0>
                <tr>
                    <td>Tiêu chí tìm kiếm:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:DropDownList runat = "server" ID = "drlTieuchi" Font-Names = "Verdana" Font-Size = "11px" Height = "21px" Font-Italic = True>
                            <asp:ListItem Value = "MaKH" Text = "Mã Khách hàng" />
                            <asp:ListItem Value = "TenKH" Text = "Tên Khách hàng" />
                            <asp:ListItem Value = "Abv" Text = "Tên thu gọn" />
                        </asp:DropDownList>
                        <input type = "hidden" runat="server" id = "hddSample" /> 
                    </td>
                    <td>
                        <asp:TextBox runat="server" ID="txtValue" Width="250px" Font-Names = "Arial" Font-Size="12px" Font-Italic ="true" ForeColor="Gray"/>
                        <asp:Button runat="server" ID="btnSearch" CssClass="button cyan validate" Text = "Tìm kiếm" ValidationGroup="ValueSearch" onclick="btnSearch_Click"/>            
                    </td>
                </tr>
                <tr>
                    <td>Đơn vị cung cấp Nước:</td>
                    <td>
                        <asp:DropDownList runat="server" ID = "drlDonvi" Font-Names = "Arial" Font-Size = "12px" ForeColor="Gray" Width="255px">
                            <asp:ListItem Value= "" Text = "" />
                            <asp:ListItem Value= "PC01" Text = "Công ty Nước lực Quảng Bình" />
                            <asp:ListItem Value= "PC02" Text = "Công ty Nước lực Quảng Trị" />
                            <asp:ListItem Value= "PC03" Text = "Công ty Nước lực TT. Huế" />
                            <asp:ListItem Value= "PP" Text = "Công ty Nước lực Đà Nẵng" />
                            <asp:ListItem Value= "PC05" Text = "Công ty Nước lực Quảng Nam" />
                            <asp:ListItem Value= "PC06" Text = "Công ty Nước lực Quảng Ngãi" />
                            <asp:ListItem Value= "PC07" Text = "Công ty Nước lực Bình Định" />
                            <asp:ListItem Value= "PC08" Text = "Công ty Nước lực Phú Yên" />
                            <asp:ListItem Value= "PQ" Text = "Công ty Nước lực Khách Hòa" />
                            <asp:ListItem Value= "PC10" Text = "Công ty Nước lực Gia Lai" />
                            <asp:ListItem Value= "PC11" Text = "Công ty Nước lực Kon Tum" />
                            <asp:ListItem Value= "PC12" Text = "Công ty Nước lực Đăk Lăk" />
                            <asp:ListItem Value= "PC13" Text = "Công ty Nước lực Đăk Nông" />
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
    </fieldset>
</div>

<div runat=server id=divResult visible=false style="margin-left:5px; margin-right:5px; margin-top:30px">
    <fieldset>
        <legend align="left">
            <span class="Fieldset_title_text">Kết quả tìm kiếm</span>
        </legend>
        <div class="box_space" style="padding-top:10px; padding-bottom:5px; padding-left:5px; padding-right:5px">
            <asp:ScriptManager ID="ScriptManager1" runat="server"/>   
            <asp:UpdatePanel ID="UpdatePanel_Search" runat="server">
                <ContentTemplate>
                    <asp:DataGrid runat="server" ID="dgResult" DataKeyField="MA_KHANG" AutoGenerateColumns="false" Width="100%">
                        <HeaderStyle HorizontalAlign ="Center" Font-Bold = "true" Height = "20px" BackColor = "#71ABD6" ForeColor="#FFFFFF" BorderColor = "Gray"/>
                        <ItemStyle ForeColor = "#444467" Height= "20px" Font-Names= "Verdana" Font-Size = "11px"/>
                        <Columns>    
                            <asp:TemplateColumn HeaderStyle-BorderColor = "Gray" ItemStyle-Width = "30px" ItemStyle-HorizontalAlign = Center>
				                <ItemTemplate>
                                    <asp:RadioButton ID="rb" runat="server" AutoPostBack="true" OnCheckedChanged="rb_CheckedChanged" />
				                </ItemTemplate>
			                </asp:TemplateColumn>
                            <asp:TemplateColumn HeaderText="STT" HeaderStyle-BorderColor = "Gray">
                                <ItemTemplate><%# Container.ItemIndex + 1 %></ItemTemplate>
                            </asp:TemplateColumn>             
                            <asp:BoundColumn DataField = "TEN_KHANG" HeaderText = "Tên khách hàng" HeaderStyle-BorderColor = "Gray"/>
                            <asp:BoundColumn DataField = "DCHI_HDON" HeaderText = "Địa chỉ khách hàng" HeaderStyle-BorderColor = "Gray"/>
                            <asp:BoundColumn DataField = "MA_DVIQLY" HeaderText = "Đơn vị cung cấp Nước" HeaderStyle-BorderColor = "Gray"/>
                        </Columns>
                    </asp:DataGrid>
                </ContentTemplate>
            </asp:UpdatePanel>
            
        </div>
    </fieldset>
</div>


<div style="padding-left:8px; padding-top: 10px">
    <asp:Button runat="server" ID="Button1" CssClass="button cyan validate" Text = "Chọn" ValidationGroup="ValueSearch"/> 
</div>  

<%--<div class="counter" style="padding-left: 20px">
   <table cellpadding=0 cellspacing=5>
        <tr>
            <td>Đơn vị:</td>
            <td>
                <asp:DropDownList runat="server" ID = "drlDonvi" Font-Names = "Arial" Font-Size = "12px">
                    <asp:ListItem Value= "PC01" Text = "Công ty Nước lực Quảng Bình" />
                    <asp:ListItem Value= "PC02" Text = "Công ty Nước lực Quảng Trị" />
                    <asp:ListItem Value= "PC03" Text = "Công ty Nước lực TT. Huế" />
                    <asp:ListItem Value= "PP" Text = "Công ty Nước lực Đà Nẵng" />
                    <asp:ListItem Value= "PC05" Text = "Công ty Nước lực Quảng Nam" />
                    <asp:ListItem Value= "PC06" Text = "Công ty Nước lực Quảng Ngãi" />
                    <asp:ListItem Value= "PC07" Text = "Công ty Nước lực Bình Định" />
                    <asp:ListItem Value= "PC08" Text = "Công ty Nước lực Phú Yên" />
                    <asp:ListItem Value= "PQ" Text = "Công ty Nước lực Khách Hòa" />
                    <asp:ListItem Value= "PC10" Text = "Công ty Nước lực Gia Lai" />
                    <asp:ListItem Value= "PC11" Text = "Công ty Nước lực Kon Tum" />
                    <asp:ListItem Value= "PC12" Text = "Công ty Nước lực Đăk Lăk" />
                    <asp:ListItem Value= "PC13" Text = "Công ty Nước lực Đăk Nông" />
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Giá trị:</td>
            <td>
                <asp:TextBox runat = "server" ID = "txtValue" Text = "Nhập mã hoặc tên khách hàng..." Width = "200px"/>
            </td>
        </tr>
   </table>
</div>--%>