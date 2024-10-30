<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlCounter.ascx.cs" Inherits="cskh.huewaco.vn.Control.ctrlCounter" %>
<p>Tổng số lượt truy cập: <a href="#"><asp:Literal runat=server ID ="lblCounter"></asp:Literal></a></p>
<p>Số khách đang truy cập: <a href="#"><asp:Literal runat=server ID ="lblGuest"></asp:Literal></a></p>
<p>Số tài khoản đang truy cập: <a href="#"><asp:Literal runat=server ID ="lblUserOnline"></asp:Literal></a></p>

<%--<div class="counter">
    <div id="Div1" style = "background: url('images/Delete/SLTC.png') no-repeat top; height: 200px" runat = "server">
        <div style="padding-top: 60px; text-align: center">
            <asp:Label runat=server ID = lblCounter Font-Bold = true Font-Names = Arial Font-Size = "20px" ForeColor = "Blue"/>
        </div>
        <div style="padding-left: 25px; padding-top: 20px; text-align: left">
            Khách online: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <asp:Label runat=server ID = lblGuest Font-Bold=true/>
        </div>
        <div style="padding-left: 25px; padding-top: 10px; text-align: left">
            Thành viên online: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<b>0</b>
        </div>
    </div>
</div>--%>