<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Flash.ascx.cs" Inherits="UC_Flash" %>
<script type="text/javascript" src="../js/dartRichMedia.js"></script>

<div id="divFlash" style="display:block;">
<script type="text/javascript">
var swf_width=240;
var swf_height=240;
var files='<asp:Literal runat="server" ID="ltFiles"></asp:Literal>';
var links='<asp:Literal runat="server" ID="ltLinks"></asp:Literal>';
var texts='<asp:Literal runat="server" ID="ltTexts"></asp:Literal>';
document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="'+ swf_width +'" height="'+ swf_height +'">');
document.write('<param name="movie" value="image/flashnews1.swf"><param name="quality" value="high">');
document.write('<param name="menu" value="false"><param name=wmode value="opaque">');
document.write('<param name="FlashVars" value="bcastr_file='+files+'&bcastr_link='+links+'&bcastr_title='+texts+'">');
document.write('<embed src="image/flashnews1.swf" wmode="opaque" FlashVars="bcastr_file='+files+'&bcastr_link='+links+'&bcastr_title='+texts+'& menu="false" quality="high" width="'+ swf_width +'" height="'+ swf_height +'" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />');
document.write('</object>'); 
</script>
</div>
<asp:Literal runat="server" ID="script"></asp:Literal>

<!--JS实现flash效果代码实例


<a target=_self href="javascript:goUrl()"> 
                    <span class="f14b">
                    <script type="text/javascript">
imgUrl1="http://www.webjx.com/img/200406301.jpg";
imgtext1="网页教学网制作素材"
imgLink1=escape("http://www.webjx.com/htmldata/sort/8.html");
imgUrl2="http://www.webjx.com/img/200406302.jpg";
imgtext2="网页教学网网页制作专区"
imgLink2=escape("http://www.webjx.com/htmldata/sort/3.html");
imgUrl3="http://www.webjx.com/img/200406303.jpg";
imgtext3="网页教学网网页特效专区"
imgLink3=escape("http://www.webjx.com/htmldata/sort/5.html");
imgUrl4="http://www.webjx.com/img/200406304.jpg";
imgtext4="网页教学网视频教程"
imgLink4=escape("http://www.webjx.com/htmldata/sort/15.html");
imgUrl5="http://www.webjx.com/img/200406305.jpg";
imgtext5="网页教学网网页制作书籍"
imgLink5=escape("http://www.webjx.com/htmldata/sort/7.html");

 var focus_width=280
 var focus_height=158
 var text_height=18
 var swf_height = focus_height+text_height
 
 var pics=imgUrl1+"|"+imgUrl2+"|"+imgUrl3+"|"+imgUrl4+"|"+imgUrl5
 var links=imgLink1+"|"+imgLink2+"|"+imgLink3+"|"+imgLink4+"|"+imgLink5
 var texts=imgtext1+"|"+imgtext2+"|"+imgtext3+"|"+imgtext4+"|"+imgtext5
 
 document.write('<object classid="clsid:d27cdb6e-ae6d-11cf-96b8-444553540000" codebase="http://fpdownload.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,0,0" width="'+ focus_width +'" height="'+ swf_height +'">');
 document.write('<param name="allowScriptAccess" value="sameDomain"><param name="movie" value="http://www.webjx.com/js/focus.swf"><param name="quality" value="high"><param name="bgcolor" value="#F0F0F0">');
 document.write('<param name="menu" value="false"><param name=wmode value="opaque">');
 document.write('<param name="FlashVars" value="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'">');
 document.write('<embed src="pixviewer.swf" wmode="opaque" FlashVars="pics='+pics+'&links='+links+'&texts='+texts+'&borderwidth='+focus_width+'&borderheight='+focus_height+'&textheight='+text_height+'" menu="false" bgcolor="#F0F0F0" quality="high" width="'+ focus_width +'" height="'+ focus_height +'" allowScriptAccess="sameDomain" type="application/x-shockwave-flash" pluginspage="http://www.macromedia.com/go/getflashplayer" />');  document.write('</object>');
 

 </script>
                    </span></a><span id=focustext class=f14b> </span>


-->