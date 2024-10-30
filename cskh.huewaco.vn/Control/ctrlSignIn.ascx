<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ctrlSignIn.ascx.cs" Inherits="cskh.huewaco.vn.Control.ctrlSignIn" %>


<div id="login">                
    <div class="login_body" style="padding-top: 30px">
        <a href="/Default.aspx"><img src = "/Images/logo-huewaco.png" /> </a>
          
    </div>
</div>

<SCRIPT language="javascript" type="text/javascript">
    function nulltext(id, para) {
        if (id.value == para) {
            id.value = '';
            id.style.color = '#303030';
        }
    }
    function rollback(id, para) {
        if (id.value == '') {
            id.value = para;
            id.style.color = '#828282';
        }
    }

    function enterToTab(e) {
        if (e.srcElement.id != 'btnOK') {
            if (window.event.keyCode == 13) window.event.keyCode = 9
        }
    }
    function setfocus() {
        alert('focus');
        var p = document.getElementById('txtCapt');
        p.focus();
    }
    function checkEnter(e) {
        e = e || event;
        return (e.keyCode || event.which || event.charCode || 0) !== 13;
    }
</SCRIPT>