<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserControlIndex.aspx.cs" Inherits="UserControlIndex" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
<style type="text/css">
    *{margin:0px; padding:0px;}
body{ margin:5px;}
/*用户内容*/
#userContent{ margin:0px; width:100%;font-size:13px; font-weight:bolder;} 
/*左边*/
#left{width:220px; float:left;position:relative;}
/*用户头像*/
#left #headPhoto{ height:180px; width:100%; border-right:1px solid #cccccc; border:1px solid #cccccc; text-align:center;}
#left .UserDetailsTitle{height: 30px;width: 95%;background-repeat: repeat-x;background-position: left top;padding: 8px 0px 0px 10px;background-color: #000000;color: #FF0000;}
/*用户详细信息*/
#left #userDetails{height:162px; width:100%; border:1px solid #cccccc;margin-bottom:12px;}
/*用户浏览历史*/
#left #history{height:180px; width:100%; border:1px solid #cccccc; margin-bottom:10px;}  

/*右边*/
#right{float:right; width:710px;}
                                 
#right #newMessagesTitle{height:29px;
width:98%;
background-color: #000000;color: #FF0000;
                                      background-repeat:repeat-x; background-position:left top; padding:8px 0px 0px 10px;
    }    
#right #newMessages{width:100%;height:auto; }

#details,#historyData,#imgOperate{ font-weight:normal;}

#details{ line-height:20px;}

.gridViewRow{padding:10px; font-weight:normal;}
.gridViewRow a{ text-decoration:none; color:Blue; white-space:nowrap;}
.gridViewRow a:hover{ text-decoration:underline; color:Red;}
.gridViewRow a:visited{ color:#eeaa00;}
.gridViewItem{ padding:5px 0px 5px 2px; margin:0px auto;}
</style>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
        <Services>
            <asp:ServiceReference Path="~/WebService.asmx" />
        </Services>
    </asp:ScriptManager>
        <div id="userContent">
            <div id="left">
                <div id="headPhoto">
                    <div id="headPhotoTitle" class="UserDetailsTitle">您的头像</div>
                    <img src='<%# GetUserDetails("image") %>' onError="this.src='image/defualtHeadPhoto.gif'" height="120px" width="160px"/>
                    <div id="imgOperate"><a href="#"> 更换图像</a></div>
                </div>
                <div id="userDetails">
                    <div id="userDetailsTitle" class="UserDetailsTitle">您的信息</div>
                    <div id="details"><%# GetUserDetails("details") %></div>
                </div>
                <div id="history">
      <!--            <div id="historyTitle" class="UserDetailsTitle">您浏览的历史</div>-->  
                    <div id="historyData"></div>
                </div>
            </div>
            <div id="right">
                <div id="newMessagesTitle">您有<b style="color:Red;"><%#GetHowManyMessage()%></b>条新回复</div><p />
                <div id="newMessages">
                    <asp:GridView runat="server" ID="messages" AutoGenerateColumns="false" 
                        Width="100%" Height="100%" RowStyle-CssClass="gridViewRow" 
                        CellPadding="15" AllowPaging="True" 
                        onpageindexchanging="messages_PageIndexChanging" >
                        <RowStyle BorderColor="Aqua" BorderStyle="None" />
                        <Columns>
                            <asp:TemplateField HeaderText="被评论的文章" >
                                <ItemTemplate><img src="image/folder.gif" /><a href="ArticleContent.aspx?articleid=<%#Eval("articleID")%>" target="_blank" onclick=" Worked(<%#Eval("commentID") %>)"><%# Eval("articleSubject") %></a></ItemTemplate>
                                <ItemStyle CssClass="gridViewItem"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="评论内容" >
                                <ItemTemplate><a href="ArticleContent.aspx?articleid=<%#Eval("articleID") %>#<%#Eval("commentID") %>" target="_blank" onclick=" Worked(<%#Eval("commentID") %>)"><%#Eval("shortContent")%></a></ItemTemplate>
                                <ItemStyle CssClass="gridViewItem"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="评论人">
                                <ItemTemplate><a href="UserHomePage.aspx?userID=<%#Eval("userID") %>" target="_blank"><%# Eval("userShowName")%></a></ItemTemplate>
                                <ItemStyle CssClass="gridViewItem"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="评论时间" >
                                <ItemTemplate> <%# Eval("addDate","{0:D}") %></ItemTemplate>
                                <ItemStyle CssClass="gridViewItem"></ItemStyle>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="已看"  >
                                <ItemTemplate>
                                    <label id="workState"><%#Convert.ToBoolean(Eval("worked"))?'是':'否'%></label>
                                    <asp:Label ID="workedState" runat="server"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle CssClass="gridViewItem">
                                </ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </form>
    
<script type="text/javascript">

function Worked(commentID){

    
    //调用web服务更新后台数据库
    WebService.Worked(commentID,onSuccessWorked);
    function onSuccessWorked(result){
        if(result==1){};
//           document.getElementById('workState').innerHTML="是";
    }
}
</script>
</body>
</html>
