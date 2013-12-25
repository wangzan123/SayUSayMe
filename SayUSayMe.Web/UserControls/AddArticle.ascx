﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AddArticle.ascx.cs"  Inherits="UserControls_AddArticle" %>
<script src="WebEditor/JS/Editor.js"  type="text/javascript"></script>
<script type="text/javascript">

//必须在前面声明的函数
//假如用户输入内容没有保存关闭窗口则提示  
document.body.onbeforeunload=function()
{
    if(event.clientY<0&&event.clientX>760||event.altKey)
    {
        if(window.frames['Editor'].document.body.innerHTML.length!=0)
        {
            window.event.returnValue='你所编辑的文章还没保存,关闭此页会使内容丢失,你确认关闭吗？';
            return false;
        }
    }
}

</script>
<asp:TextBox runat="server" ID="articleID" Visible="false"></asp:TextBox>
<div style="clear:both;"></div>
<table cellpadding="0" cellspacing="0"  style="width:100%; height:100%;"  class="webEditorTable" id="tableEditor">
     <tr id="trClass">
        <td class="message"><span>主题分类:</span></td>
        <td>
        <asp:UpdatePanel runat="server" ID="updatepanel1">
            <ContentTemplate>
                    <asp:DropDownList ID="droArticleClass" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ArticleClassChange"></asp:DropDownList>
                    <asp:DropDownList ID="droClassSort" runat="server" Width="160px"></asp:DropDownList>
            </ContentTemplate>
        </asp:UpdatePanel>
        </td>
    </tr>
    <tr id="trTitle">
        <td class="message"><span>标题:</span></td>
        <td><asp:TextBox runat="server" ID="ArticleTitle" Width="280px" MaxLength="150"></asp:TextBox></td>
    </tr>
    <tr>
        <td colspan="2" width="100%">
        <div style="background: #dfeef5;width:100%;position:relative;" id="editorControl" unselectable="on">
            <div class="toolbar">
                <a href="javascript:" onclick="webEditor.onClick_FontFamily(this);" onmouseover="webEditor.onMouseOver(this,'webEditor.onClick_FontFamily(this)')" class="family" title="字体"></a>
                <a href="javascript:" onclick="webEditor.onClick_FontSize(this);" onmouseover="webEditor.onMouseOver(this,'webEditor.onClick_FontSize(this)')" class="fontsize" title="字号"></a>
                <a href="javascript:" onclick="webEditor.onClick_Color(this);" onmouseover="webEditor.onMouseOver(this,'webEditor.onClick_Color(this)')" class="color" title="字体颜色"></a>
                <a href="javascript:" onclick="webEditor.onClick_Color(this,'backcolor');" onmouseover="webEditor.onMouseOver(this,'webEditor.onClick_Color(this,1)')" class="backcolor" title="背景颜色"></a>
                <b></b>
                <a href="javascript:" onclick="webEditor.format('Bold');"  class="FontBold" title="字体加粗"></a>
                <a href="javascript:" onclick="webEditor.format('Italic');"   class="FontItalic" title="斜体"></a>
                <a href="javascript:" onclick="webEditor.format('Underline');"  class="FontUnderline" title="下划线"></a>
                <a href="javascript:" onclick="webEditor.format('','removeFormat');" class="RemoveFormat" title="清除样式"></a>
                <b></b>
                <a href="javascript:" onclick="webEditor.format('JustifyLeft');" class="left" title="左对齐"></a>
                <a href="javascript:" onclick="webEditor.format('JustifyCenter');" class="center" title="居中"></a>
                <a href="javascript:" onclick="webEditor.format('JustifyRight');" class="right" title="右对齐"></a>
                <b></b>
                
                <a href="javascript:" onclick="webEditor.onClick_Face(this);" onmouseover="webEditor.onMouseOver(this,'webEditor.onClick_Face(this)');" class="face" title="插入表情"></a>
                <a href="javascript:" onclick="webEditor.onClick_Upload(this,1);" onmouseover="webEditor.onMouseOver(this,'webEditor.onClick_Upload(this,1)');" class="image" title="插入图片"></a>
                <b></b>
            </div>
        <div id="_menuPoput"></div>
         <textarea id="EditorValue" style=" display:none;" runat="server"></textarea>
         <div id="editorDiv" class="editor" onmouseover="webEditor.onMouseOver();" onmouseout="webEditor.onMouseOut();">
            <iframe id="Editor"  name="Editor" scrolling="auto" height="200"  style="width:100%;  padding: 0px auto; margin: 0px auto;"
               frameborder="1" onBlur="document.getElementById('<%=EditorValue.ClientID%>').value=window.frames[this.id].document.body.innerHTML;" onload="window.frames[this.id].document.body.innerHTML=document.getElementById('<%=EditorValue.ClientID%>').value"></iframe>
         </div>                                  
       </div> 
       <div style="height:15px;"></div>
        <div style="height:30px; text-align:center;width:100%;">
            <a href="javascript:" onclick="webEditor.check(5000)">字数检查</a>
            <a href="javascript:" onclick="addFile()" id="addFileText">添加附件</a>
            <div id="webEditorOperator" >
                <a href="javascript:" onclick="ChangeHeight(document.getElementById('Editor'),'+');"><img src= "image/add_1.gif" style="border:0px;"/>加大</a>
                <a href="javascript:" onclick="ChangeHeight(document.getElementById('Editor'),'-');"><img src= "image/plus_1.gif" style="border:0px;" />减小</a>
            </div>
        </div>
        </td>
    </tr>
    <tr style="height:50px; display:none;" id='FileUploadPlace'>
        <%--<td class="message" id="showFileText" style="display:none;"><span>&nbsp;&nbsp;文章的附件：</span></td>--%>
        <td class="message" id="articleFileText"><span>附件最大为:(1M)<br />(目前只支持添加5个附件)<br />&nbsp;有效文件类型:.rar|.flash|等</span><br /><span>(附件描述最多支持10个汉字)</span></td>
        <td class="message" id="TD">
        
          <button style="WIDTH: 288; height:auto; right:1px; top:1px; float:right;" onclick="javascript:addFiles(TD);" type="button">继续添加</button>    
        </td>
   
    </tr>
    <tr>
        
        <td colspan="2" align="center"><asp:Button ID="BtnGetContent" Text="提交" runat="server" OnClick="GetUserLeaveData" OnClientClick="return HasContent()"/></td>
    </tr>
</table>
<input type="hidden" id="flagSumbit" value="0"/>

<div id="showWorking" style=" display:none; height:30px; width:150px; position:absolute; border:0px; background-color:#009900; color:White; ">
    <div style="font-weight:bolder; margin:8px 0px 0px 15px;" id="workedText">正在提交数据...</div>
</div>
<%--<input type="button"  onclick="HasDesciption(); HasFiles()" value="附件测试按钮"/>--%>
<asp:Literal runat="server" ID="script"></asp:Literal>

<asp:HiddenField  runat="server" ID="TxtDescription" Visible="true"/>
<script type="text/javascript">
//初始化在线编辑器
initial('Editor');
//控制回退建
//window.history.forward(1);
var fileCount=0;
//全局变量，判断操作类型（留言和发表文章）
//var type="";
//判断是否有附件
var addFileOperate=0;
var ok=false;
 //----------------------------------函数操作--------------------------------

//判断附件描述是否为空
function HasDesciption(){


        
        //存储附件描述信息
        var Descriptions=document.getElementById('<%=TxtDescription.ClientID %>');
        //获取所有描述控件的值的集合
        var filenames=document.getElementsByName("filename");
       
        for(var j=0;j<filenames.length;j++){ 
            var temp=filenames[j].value.trim();
            if(temp==""){
                alert("附加描述为空.请返回！");
                return  false;
            }
            else{
                if(j==0)
                Descriptions.value=temp;
            
                else
                Descriptions.value+=','+temp;
            }
            
        }
        return true;
       

}
//判断附件是否为空
function HasFiles(){
   
    var files=document.getElementsByName("files");
    for(var i=0;i<files.length;i++){
        var file=files[i].value.trim();
        if(file==""){
             alert("附件为空！请返回");
             return false;
        }
    }
    return true;
}
 function checkContent(){
 
           // alert(type);
            //验证文章字数是否合法
            if(window.frames['Editor'].document.body.innerText.length>5000){
                alert('字数超出允许范围,最大输入字数为5000');
                return false;
            }
            
            //先判断是否是发表文章，如果是留言，不用写标题和选择分类
            //发表文章
            if(type=="AddArticle"){
                //验证是否选择了分类 
                var select=document.getElementById('<%=droArticleClass.ClientID%>');//ClientID：获取由 ASP.NET 生成的服务器控件标识符
                for(var i=0;i<select.length;i++){
                    if(select.options[i].selected)
                        if(select.options[i].value==-1){
                            alert("请选择分类");
                            return false;
                        }      
                }
            
                //验证是否写了标题
                if(document.getElementById('<%=ArticleTitle.ClientID %>').value==""){
                    alert("请为您的文章写一个标题");
                    return false;
                }
                else if(document.getElementById('<%=ArticleTitle.ClientID %>').value.length>30){
                    alert("标题内容过长");
                    return false;
                }  
                
            }
            //验证文章输入是否合法
            var object=window.frames['Editor'].document.body;
            if(object.innerHTML.length!=0&&object.innerText==0){
                alert("不能只发表图片,没有文字内容");
                return false;
            }
            else if(object.innerHTML.length==0&&object.innerText==0){
                alert('输入内容不能为空');
                return false;
            }
            
           
            //验证添加附件的描述文本是否合法
            var hasfiles=HasFiles();
            var hasDescription=HasDesciption();
            if(!hasfiles||!hasDescription){
                return false;
            }
            //以上验证成功后就提示后台正在操作
            var obj=document.getElementById('showWorking');
            var height=window.document.documentElement.clientHeight;
            var width=document.documentElement.clientWidth;
            obj.style.bottom=height/2-100;
            obj.style.left=width/3;
            obj.style.display='';    
            return true;

      
    }  
 

//检查输入内容是否合法
function HasContent(){  
    var ss='<%=Session["userName"]%>';
    var userstate='<%=Session["state"]%>';
    if(!ss){
        alert("请登录后回复！");
        return false;
    }
    else if(userstate==0){
        alert("禁言中，无法发帖！");
        return false;
    } 
    return checkContent();

   // return ok ;
}//结束HasContent()函数


//改变输入框的高度函数
function ChangeHeight(object,operate){
    if(operate=='+'){
        if(object.height<300){
          object.height=object.height-200+300;
        }
    }
      
    else if(operate=='-'){
        if(object.height>100){
        object.height-=100;
        }
    }
 
        
}

//添加附件按钮
function addFile(){   
    //表示用户已经添加附件
    var FileUploadPlace=document.getElementById("FileUploadPlace");
    if(FileUploadPlace.style.display==""){
    
        document.getElementById("addFileText").innerHTML="添加附件";
        document.getElementById("FileUploadPlace").style.display='none';
        //----------------------移除所有动态生成的附件
        var articleFiles=document.getElementsByName("filename");
        for(var i=articleFiles.length-1;i>=0;i--){
                var eachfiles=articleFiles[i];
                var divFile=eachfiles.parentNode;
                divFile.parentNode.removeChild(divFile);
                fileCount--;
        }
       //----------------------------
    
    
    }
    else{
        document.getElementById("addFileText").innerHTML="不添加附件";
        document.getElementById("FileUploadPlace").style.display='';
        if(fileCount==0){//第一次时自动生成第一个附件
        addFiles(TD);
        }
    }
}

 //----------添加附件函数
  function addFiles(oContainer){
        if(fileCount<=4){         
             var sLineHTML="<div>&nbsp; &nbsp; <b>附件描述：</b><input type='text' name='filename'/>&nbsp; &nbsp; <b>附件：</b><input type='file' name='files' style='width:228'><input type='button' onclick='javascript:delFileInput(this)' value='删除'></div>";
              oContainer.insertAdjacentHTML('beforeEnd',sLineHTML);
              fileCount++;
        }
        else{
            alert("已经达到最大附件量");
            return ;
        }

        
 }
 
 //-------删除附件函数
function delFileInput(oInputButton) {
    var divToDel=oInputButton.parentNode;
    divToDel.parentNode.removeChild(divToDel);
    fileCount--;
}

</script>
<asp:Literal runat="server" ID="Literal1"></asp:Literal>
