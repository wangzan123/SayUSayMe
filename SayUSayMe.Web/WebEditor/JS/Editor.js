

/// <summary>弹出菜单</summary>
/// <param name="owner" type="Object">归属对象</param>
///弹出菜单方法类
function populateMenu(owner)
{
    //菜单归属父类
    var _parent=getObj("_menuPoput");
    var _owner=owner;
    var _count=0;
    var _left=getPosLeft(_owner);
    //初始化对象
    this.id="";
    this.width=200;
    //列表值（显示的内容）
    this.items=[];
    //列表项包含的值，用于程序读取，充当函数参数
    this.parms=[];

    //列表显示不同的样式值
    this.value=[];
    this.template="";

    
    this.createMenu=function()
    {
        // <summary>创建菜单</summary>
        //把items里面的数据添加到menu
         _count=this.items.length;
         
         if(_count<1)return false;
         var code="<ul  id='"+this.id+"' class='menu transparent' style=\"left:"+_left+"px;\">";
         
         var codeTem;
         for(var index=0;index<_count;index++)
         {                               
            codeTem=this.template.replace(/\{\$title\}/g,this.items[index]);
            if(this.parms.length==this.items.length)    //当长度相等的话，就证明该弹出窗口有该选项需要匹配
                codeTem=codeTem.replace(/\{\$parm\}/g,this.parms[index]);
            if(this.value.length==this.items.length)
                codeTem=codeTem.replace(/\{\$value\}/g,this.value[index]); 
            code+=codeTem;   
         }
         code+="</ul>";
         
         _parent.innerHTML+=code;
    }
}


//用面向对象的思想
//Web编辑器JavaScript类
function WebEditor(containerID)
{
    //定义编辑器的名字对象，方便使用
    this.name="webEditor";
    //初始化所有的属性
    this._containderID=containerID; //框架ID，用于显示内容
    //字体样式弹出菜单列表值
    this._fontfamily="仿宋_GB2312;黑体;楷体_GB2312;宋体;新宋体;Tahoma;Arial;Impact;Verdana";
    //字体大小弹出菜单列表
    this._fontsize="2/七号/10;3/六号/12;4/五号/14;5/四号/17;6/三号/21;7/二号/26;8/一号/36";
                  //在编辑器的内容字体大小/显示文字/显示文字样式大小值
    this._editor=null;//保存frame编辑区的引用
    this._popups="";  //保存所有弹出窗口对象的ID
    this._waitInterval;
    //表情图片数，可以随时改
    this._faceCount=70;
    this._sender=null;  //缓存当前对象,用于延时处理的情况下
    this._width=Request("w");
    this._height=Request("h");
   

    this.check=function(maxLength)
    {

//    var obj=window.frames["Editor"].document;
        var obj=document.getElementById("Editor").contentWindow.document;
        alert("当前字数为:"+obj.body.innerText.length+"\n最大输入字数为:"+maxLength);
    
    }
    this.initial=function()
    {
        /// <summary>初始化，开启可编辑模式。</summary>
        if(this._editor==null)
        {
            var object=getObj(this._containderID);
            
//            object.style.height=this._height==null?object.style.height:this._height;
//            object.style.width=this._width==null?object.style.width:this._width;
//            
//            alert(object.style.height);
//            alert(object.style.width);
            //获取iframe的对象。然后 iframe对象.contentWindow.document......
            //contentWindow.之后的跟正常页面一样使用。也可以getElementById...等等。。    
//            var containdner_parent=document.getElementById("editorDiv");
//            containder_parent.style.height=this._height==null?object.style.height:this._height;
//            containder_parent.style.width=this._width==null?object.style.width:this._width;
            //另外：可以使用 
            //window.frames["frameName"].document语法直接获取frame里的document对象. 
            //this._editor=window.frames[this._containderID].document;
            this._editor=object.contentWindow.document;
            this._editor.write();
            this._editor.designMode="On";
            this._editor.contentEditable=true;
            
        }
        if(this._editor!=null)   //当存在编辑器
        {
            /*激活编辑器的方法有两种。第一种方法是将整个文档设置为设计模式。
              第二种方法可以在浏览模式中使用，来使各个元素可在运行时编辑。如果想让整个文档可在浏览时进行编辑，
              则可以在文档正文上设置   contentEditable   属性。 */    
            //将文档设置为设计模式     
            /*要将整个文档设置为设计模式，可以对文档对象本身设置   designMode   属性。
             当文档处于设计模式时，将不运行脚本。这样，似乎在文档内设置一个按钮来打开或关闭设计模式是个好注意，但这样做没有作用。
             当用户打开它后，它将保持在设计模式状态。当他们下次单击此按钮时，它将被选定而不是被单击，他们再次单击它，
             将能够编辑它的值。这就是为什么如果要使用设计模式最好对框架或   IFrame   中的文档设置   designMode   属性的原因。*/
             
           /*designMode   属性的值始终以首字母大写格式存储，即时它最初是以全部小写设置的。
           请在测试它的值时一定记住这点。designMode   属性的默认值是“Inherit“*/
            this._editor.designMode="On";
            this._editor.contentEditable=true;
        }
    }
    //隐藏所有的弹出窗口
    this.HideAllMenu=function()
    {
        
        var arrPopupObj = this._popups.split(";");
        for( index = 0; index<arrPopupObj.length; index++)
        {
            hiddenObj(arrPopupObj[index]);
        }
    }
    //点击设置字体大小时调用弹出窗口
    this.onClick_FontFamily=function(sender)
    {
        this.HideAllMenu(); //隐藏所有已经弹出的窗口  
        var menu_id="_menu_family";
        
        var obj=getObj(menu_id);
        if(obj)
        {
            showObj(menu_id);
        }
        else
        {
            //把菜单归属对象传进populate函数,构建对象
            var menu=new populateMenu(sender);
            
            menu.id=menu_id;
            menu.items=this._fontfamily.split(";");
            //菜单列表模板
            //字体必须是系统支持的字体
            //document.execCommand('FontName',false,'标楷体');      //true或false都可以
                           
            menu.template="<li><a href='javascript:' style='font-family:{$title};font-size:15px' onclick=\""+this.name+".format('fontname','{$title}');hiddenObj('"+menu.id+"');"+this.name+"._editor.focus();return false;\">{$title}</a></li>";
            menu.createMenu();
            this._popups+=menu.id+";";
        }
        
    }
    this.onClick_FontSize=function(sender)
    {
        /// <summary>设置字号</summary>
        /// <param name="sender" type="Object"></param>
        //隐藏所有的弹出窗口
        this.HideAllMenu();
        var menu_id="_menu_size";
        
        var obj=getObj(menu_id);
        if(obj)
        {
            showObj(obj);
        }
        else
        { 
            var menu=new populateMenu(sender);
            menu.id=menu_id;
            //将一个字符串分割为子字符串，然后将结果作为字符串数组返回。
            var arrTem=this._fontsize.split(";");
            var arrItem=[];
            for(var i=0;i<arrTem.length;i++)
            {
                arrItem=arrTem[i].split("/");
                menu.items[i]=arrItem[1];
                menu.parms[i]=arrItem[0];
                menu.value[i]=arrItem[2];
                
            }               
            menu.template="<li><a href='javascript:' style='font-size:{$value}px;' onclick=\""+this.name+".format('fontsize','{$parm}');hiddenObj('"+menu_id+"');"+this.name+"._editor.focus();return false;\">{$title}</a></li>";
            menu.createMenu();
            this._popups+=menu_id+";";
        }
    }
    this._createColorPalette=function(sender,event_onClick)
    {
        /// <summary>创建一个拾色板</summary>
        /// <param name="sender" type="Object"></param>
        /// <param name="event_onClick" type="String">Click事件代码</param>
        var id_palette = "_palette_"+sender.id;
        var id_code = "_color_viewer_"+sender.id;
        var id_view = "_color_code_"+sender.id;
        
        //等于传进来的click函数
        //this.name+".format('"+option+"',this.title);hiddenObj('{$palette}');"+this.name+"._editor.focus();return false;"
        event_onClick = event_onClick.replace(/\{\$palette\}/g,id_palette);
        
        var code = "<div id='"+id_palette+"' class='palette' style='left:"+getPosLeft(sender)+"px'>";
        //预览颜色的textbox
        code += "<div style='clear:both'><input id='"+id_view+"' unselectable='on' style='width: 50px; background: #ece9d8' readOnly name='T1' size='20'/>"
        //显示颜色代码，十六进制数
        code += "<input id='"+id_code+"' style='WIDTH: 80px' unselectable='on' readOnly name='T2' size='20'/>"
        code += "<button style='width: 50px;text-align:center; margin-left:6px; margin-bottom:2px; border:solid 1px #E9E7E3; line-height:18px; height:20px; background:#BFBFBF; color:White;cursor:pointer' title='清除' unselectable='on' onclick=\""+event_onClick+"\" onmouseover=\"color_clear(this,'"+id_view+"','"+id_code+"')\" >清除</button></div>"
        code += "<table border='1' cellpadding='0' cellspacing='0' style='border-collapse: collapse'><tr>";
        
        var m=0;
        //生成调色板过程的变量
        var rMin=0,rMax=127;
        for(k=0;k<2;k++)
        {
            for(b = 0; b<= 255; b += 51 )
            {
                for(r = rMin; r<=rMax; r += 51)
                {
                    for(g = 0; g<=255; g += 51)
                    {
                        var HexColor;
                        HexColor = color_RgbToHex(r,g,b);
                        code += "<td style='background:"+HexColor+"' unselectable='on' onclick=\""+event_onClick+"\" onmouseover=\"colorView(this,'"+id_view+"','"+id_code+"')\" title=\""+HexColor.toUpperCase()+"\"></td>";
                        m++;
                        if(m == 18)
                        {
                            code += "</tr><tr>";
                            m = 0;
                            break;
                        }
                    }//-------end g
                  }//-------end r
            }//-------end b
            rMin = 153;
            rMax = 255;
        }//-------end k
        code+="</tr></table>";
        getObj("_menuPoput").innerHTML+=code;
        this._popups+=id_palette+";";
    }
    this.onClick_Color=function(sender,option)
    {
         /// <summary>字体颜色</summary>
         /// <param name="sender" type="Object"></param>
         sender.id="temp_"+getPosLeft(sender);
         option=option==null?"forecolor":"backcolor";
         
         this.HideAllMenu();
         var obj=getObj("_palette_"+sender.id);
         if(obj)
         {
            showObj(obj);
         }
         else
         {
            
            this._createColorPalette(sender,this.name+".format('"+option+"',this.title);hiddenObj('{$palette}');"+this.name+"._editor.focus();return false;");
         }
         
    }

    this.createFaceListView=function(sender,event_onClick)
    {
        /// <summary>创建一个表情面板</summary>
        /// <param name="sender" type="Object"></param>
        /// <param name="event_onClick" type="String">click事件代码</param>  
        
        var id_face="_face_"+sender.id;
        
        event_onClick=event_onClick.replace(/\{\$face\}/g,id_face);
        var code="<div id='"+id_face+"' class='face transparent' style=\"left:"+getPosLeft(sender)+"px\"><ul>";
        
        var fileName="";
        
        for(var i=1;i<=this._faceCount;i++)
        {
            fileName=1000+i+".gif";
            fileName=right(fileName,6);
                   //"<li><img src='face/" + filename+ "' alt='点击插入表情' onclick=\""+event_onClick+"\" /></li>"
            code+="<li><a href='' onclick='return false;'><img src='WebEditor/css/pic/face/"+fileName+"' alt=\"点击插入表情\" onclick=\""+event_onClick+"\" /></a></li>";
        }
        code+="</ul></div>";
        getObj("_menuPoput").innerHTML += code;
        this._popups += id_face+";";
    }
    this.onClick_Face=function(sender)
    {
        /// <summary>表情</summary>
        /// <param name="sender" type="Object"></param>
        sender.id="temp_"+getPosLeft(sender);
        this.HideAllMenu();
        var obj=getObj("_face_"+sender.id);
        if(obj)
        {
            showObj(obj);
        }
        else
        {
            // this._createFaceListView(sender, this.name+".format('InsertImage',this.src);hiddenObj('{$face}');"+this.name+"._editor.focus();return false;");
            this.createFaceListView(sender,this.name+".format('InsertImage',this.src);hiddenObj('{$face}');"+this.name+"._editor.focus();return false;");
        }
    }
    this.createUpload=function(sender,typeID)
    {
        if(typeID==null||typeID=="")
            typeID=1;
        var id="_upload_"+sender.id;
        
        var js_ok="window.parent."+this.name+".insertObj('"+id+"',"+typeID+",'{$filename}')";
        var js_cancle="window.parent.hiddenObj('"+id+"')";
        //显示位置
        var position=getPosLeft(sender);
        if(position+400>this._editor.body.clientWidth)
        {
            //400为弹出页面的宽度
            //position为计算应该弹出页面的位置
            //当弹出页面被输入框遮住，就把页面左移
            position=position-(position+400-this._editor.body.clientWidth);
        }
        var code="<div id='"+id+"' class='upload transparent' style='left:"+position+"px; z-index:300; position:absolute;'>"
            code+="<iframe onmouseover=\"clearTimeout("+this.name+"._waitInterval);\" frameborder='0' style=\"width:100%;height:100%;\" scrolling=no src=\"WebEditor/Upload/Upload.aspx?type="+typeID+"&ok="+js_ok+"&cancle="+js_cancle+" \"></iframe>";
            code+="</div>";
            
        getObj("_menuPoput").innerHTML += code;
        this._popups+=id+";";
    }
    //当插入成功或取消的调用函数
    this.insertObj=function(sender_id,type,filename)
    {
        var code;
        hiddenObj(sender_id);
        
        if(filename!=null&&filename!="")
        {
            switch(type)
            {
                case 1:      
                    code="<img src='"+filename+"' />";       
                    //eval("window.parent."+this.name+".format('InsertImage','"+filename+"')");
                    break;
            }
        }
        this._editor.body.innerHTML+=code;
        this._editor.body.focus();
    }
    this.onClick_Upload=function(sender,type)
    {
        sender.id="temp_"+getPosLeft(sender);
        this.HideAllMenu();
        var obj= getObj("_upload_"+sender.id)
        if(obj)
        {
            showObj(obj);
        }
        else
        {
            this.createUpload(sender,type);
        }
    }
    this.onMouseOver=function(sender,event)
    {
        //clearTimeout() 方法可取消由 setTimeout() 方法设置的 timeout。
        clearTimeout(this._waitInterval);
        //缓存当前对象，用于延时处理
        this._sender=sender;
        //鼠标停留了一定的时间久触发onclick时间，弹出窗口
       
        var event=event==null?this.name+".HideAllMenu();":event.replace(/this/g,this.name+"._sender");

        if(sender!=null)
        {
            sender.onmouseout=this.onMouseOut;
        }
        this._waitInterval=window.setTimeout(event,300);        
    }
    this.onMouseOut = function()
    {
       // alert(this._waitInterval);
        clearTimeout(this._waitInterval);      
    }
    this.format=function(command,option)
    {
        /// <summary>格式化字符</summary>
        /// <param name="command" type="String">命令</param>
        /// <param name="option" type="String">选项</param>
        this._editor.body.focus();
        if(option=="removeFormat")
        {
            this._editor.execCommand(option);
        }
        else if(option==null)
        {
            this._editor.execCommand(command);
        }
        else
        {
            //command,和option是字符串形式
            this._editor.execCommand(command,false,option);
        }
    }
    
}
function getPosLeft(obj)
{
    var value = obj.offsetLeft; 
    while(obj = obj.offsetParent) 
    { 
        if(obj.id=="editorControl")break;
        value += obj.offsetLeft; 
    } 
    return value;

}
function getObj(objID)
{
    if(typeof(objID)=="object") return objID;
    //浏览器兼容
    if(document.getElementById){
		return eval('document.getElementById("' + objID + '")');
	}else if(document.layers){
		return eval("document.layers['" + objID +"']");
	}else{
		return eval('document.all.' + objID);
	}
   
}

function right(value,len)
{
    /// <summary>右截取字符串</summary>
    /// <param name="value" type="String">源字符串</param>
    /// <param name="len" type="Integer">截取长度</param>
    if (value.length-len>=0 && value.length>=0 && value.length-len<=value.length)
    {
        return value.substring(value.length-len,value.length)
    }
    else
    {
        return value;
    }
}
function color_RgbToHex(r,g,b)
{
    /// <summary>将RGB十进制转为十六进制</summary>
    /// <param name="r" type="Integer">红</param>
    /// <param name="g" type="Integer">绿</param>
    /// <param name="b" type="Integer">蓝</param>
    /// <returns type="HexColor">返回:十六进制颜色代码</returns>
    
    /**********************************************
    语法Right ( string, n )
　　参数string：string类型，指定要提取子串的字符串n：
　　long类型，指定子串长度返回值String。函数执行成功时返回string字符串右边n个字符，
　　发生错误时返回空字符串（""）。如果任何参数的值为NULL，Right()函数返回NULL。
　　如果n的值大于string字符串的长度，那么Right()函数返回整个string字符串，
　　但并不增加其它字符。 
　　
　　 27、RIGHT函数 
　　函数名称：RIGHT 
　　主要功能：从一个文本字符串的最后一个字符开始，截取指定数目的字符。 
　　使用格式：RIGHT(text,num_chars) 
　　参数说明：text代表要截字符的字符串；num_chars代表给定的截取数目。　　 
　　应用举例：假定A65单元格中保存了“我喜欢天极网”的字符串，我们在C65单元格中输入公式：=RIGHT(A65,3)，确认后即显示出“天极网”的字符。 
　　特别提醒：Num_chars参数必须大于或等于0，如果忽略，则默认其为1；如果num_chars参数大于文本长度，则函数返回整个文本。
　　**********************************************/
　　r = right("00"+r.toString(16) ,2);
    g = right("00"+g.toString(16) ,2);
    b = right("00"+b.toString(16) ,2);
    return ('#'+(r+g+b));
　　
}
//颜色预览
function colorView(sender,viewer,viewer_code)
{
    /// <summary>颜色清空</summary>
    /// <param name="sender" type="Object"></param>
    /// <param name="viewer" type="Integer">颜色预览控件</param>
    /// <param name="viewer_code" type="Integer">颜色代码控件</param>
    
    getObj(viewer).style.background=sender.style.background;
    getObj(viewer_code).value=sender.title;
}
function colorClear(sender,viewer,viewer_code)
{
    getObj(viewer).style.background="";
    getObj(viewer_code).value="";
}

//显示对象
function showObj(objID)
{
    var object=getObj(objID)
    if(object)
    {
        object.style.display="";
    }
}

//隐藏对象
function hiddenObj(objID)
{
    var object=getObj(objID);
    if(object)
    {
        object.style.display="none";//alert("done");
    }
    
}

function Request(varName,url)
{
     /// <summary>从当前url中接收参数</summary>
    /// <param name="varName" type="String">参数名</param>
    /// <param name="url" type="String">网址(为空时,自动取当前页的网址)</param>
    if(!url)url=document.location.href;
    url=url.toUpperCase();
    if(url.indexOf("?")!=-1)
    {
        var url=url.substring(url.indexOf("?")+1)
        varName=varName.toUpperCase();
        var arrPara=url.split("&");
        var count=arrPara.length;
        for(var i=0;i<count;i++)
        {
            arrParaValue=arrPara[i].split("=");
            if(arrParaValue[0]==varName)return arrParaValue[1];
        }
    }
}

//初始化一个编辑器，传进iframe框架ID
function initial(frmName)
{
    /// <summary>创建并初始化一个新的webEditor实例</summary>
    /// <returns type="Object">iframe框架ID</returns>
    webEditor=new WebEditor(frmName);
    webEditor.initial();
}