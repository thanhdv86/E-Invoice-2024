<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlLeftmenu.ascx.cs" Inherits="cskh.huewaco.vn.Control.ctrlLeftmenu" %>


    
<div class="left_menu_top"></div>

<div class="left_menu_main">
    <div style="width: 228px;" class="panelbar RadPanelbar_CMIS">                                         
        <asp:Repeater runat="server" ID="rptMenu">
            <HeaderTemplate>
                <UL class="rootGroup">
            </HeaderTemplate>
            <ItemTemplate>
                <li class="item">                
                    <asp:HyperLink runat="server" ID="hplLinkItem" CssClass="link expandable">
                        <asp:Label ID="Label1" runat="server" Text='<% #DataBinder.Eval(Container.DataItem, "strMenuName")%>' CssClass="text" />
                    </asp:HyperLink><asp:Repeater runat="server" ID="rptSubMenu" DataSource='<%# GetSubMenuByParentID((int)DataBinder.Eval(Container.DataItem, "intMenuID"))%>'>
                        <HeaderTemplate>
                            <div style="display: block;" class="slide">
                                <ul style="display: block;" class="group level1">
                        </HeaderTemplate>
                        <ItemTemplate>
                                <li>
                                    <asp:HyperLink runat="server" ID="hplLinkItem" CssClass="link" NavigateUrl = '<% #DataBinder.Eval(Container.DataItem, "strMenuLink")%>'>                                        
                                        <asp:Label ID="Label2" runat="server" Text='<% #DataBinder.Eval(Container.DataItem, "strSubMenuName")%>' CssClass="text" />
                                    </asp:HyperLink></li></ItemTemplate><FooterTemplate>
                                </ul>
                            </div>
                        </FooterTemplate>
                    </asp:Repeater>
                </li>
            </ItemTemplate>
            <FooterTemplate>
                </UL>
            </FooterTemplate>
        </asp:Repeater>        
        
      
    </div>
</div>

<div class="left_menu_bottom"></div>