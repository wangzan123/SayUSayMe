<%@ Page Language="C#" AutoEventWireup="true" CodeFile="dillApply.aspx.cs" Inherits="Admin_dillApply" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Css/page.css" rel="Stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="ScriptManager1">
        <Services>
            <asp:ServiceReference Path="~/WebService.asmx" />
        </Services>
    </asp:ScriptManager>
    <div>
        <div id="applyContent">
            <asp:LinkButton runat="server" OnClick="ViewSuccessData" Text="查询批准的申请" ID="success" ></asp:LinkButton>
            <asp:LinkButton runat="server" OnClick="ViewFailData" Text="查询拒绝的申请" ID="failed"></asp:LinkButton>
            <asp:LinkButton runat="server" OnClick="ViewWaitData" Text="查询等待的申请" ID="waitfor"></asp:LinkButton>
            <asp:DataList runat="server" ID="ShowApply" Width="100%">
                <HeaderTemplate>
                    <span class="title1">申请类型</span><span class="title2">申请时间</span><span class="title3">操作</span>
                </HeaderTemplate>
                <HeaderStyle CssClass="title" />
                <ItemTemplate>
                    <div class="dataItem">
                        <span class="dataTitle"><%#Eval("applyTitle") %></span><span id="tips" style="position:absolute; left:80px; color:Red;"></span>
                        <span class="dataTime"><%#Eval("addDate") %></span>
                        
                        <span class="operateButton">
                            <span></span>
                            [<a href="javascript:" onclick="DisplayData('applyText<%#Eval("applyID") %>',this)">查看申请内容</a>]
                            [<a href="javascript:" onclick="ViewUserDetails('<%#Eval("userID") %>','userData<%#Eval("applyID") %>',this)">查看申请人资料</a>]
                            [<a href="javascript:" onclick="ApplyDeal(this,'<%#Eval("applyID") %>','accept')">同意申请</a>]
                            [<%#GetOperator(Container.DataItem) %>]
                        </span>
                        <div style="display:none;" class="applyText" id="applyText<%#Eval("applyID") %>"><%#HttpUtility.HtmlDecode(Eval("applyText").ToString()) %></div>
                        <div style="display:none" id="userData<%#Eval("applyID") %>" class="userData"></div>
                        <div style="display:none;" id="failedTextPlace<%#Eval("applyID")%>">
                            <textarea id="failedText<%#Eval("applyID") %>" cols="50" rows="3"><%#Eval("applyFailedText") %></textarea>
                        </div>
                    </div>
                </ItemTemplate>
                <ItemStyle CssClass="" />
                <HeaderStyle BackColor="#aaccff" BorderColor="#eeee44" />
            </asp:DataList>
        </div>
    </div>
    <asp:Literal runat="server" ID="script"></asp:Literal>
    </form>
<script type="text/javascript">
//改变字体颜色
function ChangeColor(obj)
{
    
}
//查看申请内容
function DisplayData(applyTextID,operatorText)
{
    var obj=document.getElementById(applyTextID);
    if(obj.style.display=='')
    {
        obj.style.display='none';
        operatorText.innerHTML='查看申请内容';
    }
    else
    {
        obj.style.display='';
        operatorText.innerHTML='收起申请内容';
    }
    
}
//查看拒绝原因
function DisplayRefuseData(placeID,operatorText)
{
    var obj=document.getElementById(placeID);
    if(obj.style.display=='')
    {
        obj.style.display='none';
        operatorText.innerHTML='查看拒绝原因';
    }
    else
    {
        obj.style.display='';
        operatorText.innerHTML='收起拒绝原因';
    }
}
//查看作者信息
function ViewUserDetails(userID,userDataPlace,operatorText)
{
    var place=document.getElementById(userDataPlace);
    if(place.innerHTML=="")
    {
        WebService.GetApplyUserDetails(userID,onSuccess,onFailed);
        function onSuccess(result)
        {
            place.innerHTML=result;
            place.style.display='';
        }
        function onFailed(result)
        {
            alert(result.get_message());
        }
    }
    else if(place.style.display=='')
    {
        operatorText.innerHTML="查看申请人资料";
        place.style.display="none";
    }
    else
    {
        operatorText.innerHTML="收起申请人资料";
        place.style.display="";
    }
    
}
//处理申请
function ApplyDeal(child,applyID,applyType)
{   

    var span1=child.parentNode.firstChild;
    if(confirm("确定执行该处理？"))
    {
        var placeID="failedTextPlace"+applyID;
        var textBoxID="failedText"+applyID;
        var failedText=document.getElementById(textBoxID);
        var failedTextPlace=document.getElementById(placeID);
        if(applyType=='refuse')
        {
            if(failedTextPlace.style.display=='')
            {
                if(failedText.value=="")
                {
                    alert("请说明拒绝申请原因");
                    return false;
                }
            }
            else if(failedTextPlace.style.display=='none')
            {
                failedTextPlace.style.display='';
                return ;
            }
        }
        
        WebService.UpdateApply(applyID,failedText.value,applyType,onDealSuccess,onFailed);
        function onDealSuccess(result)
        {
            
            var obj=document.getElementById("tips");
            if(applyType=='accept')
                span1.innerHTML="(已接受)";
            else
                span1.innerHTML="(已拒绝)";
             //alert(result);
            if(result==1)
            {  
                alert("处理成功");
                failedTextPlace.style.display="none";
                failedText.value="";
                window.location="<%# Request.Url %>";
            }
            else
                alert("处理失败");
        }
        function onFailed(result)
        {
            alert(result.get_message());
        }
    }
}
</script>
</body>
</html>
