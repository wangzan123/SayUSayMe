<%@ Control Language="C#" AutoEventWireup="true" CodeFile="showUserState.ascx.cs" Inherits="Admin_UserControl_showUserState" %>
<asp:ScriptManager ID="ScriptManager1" runat="server">
    <Services>
        <asp:ServiceReference Path="~/WebService.asmx" />
    </Services>
</asp:ScriptManager>
<div id="userStateBlock">
    <asp:DataList ID="showUserState" runat="server" Width="100%">
         <HeaderTemplate>
            <div class="articleBlockTitle">
                <span id="UserID">用户ID:</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                 &nbsp;&nbsp;&nbsp;&nbsp;
                <span id="UserNowState">用户状态</span>  &nbsp;&nbsp;&nbsp;&nbsp;    <span>状态操作</span>
                
            </div>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="UserItem">
                <div class="UserID">
                     <span class="title"><%# Eval("uname")%></span>
                </div>
                <div class="UserState">
                    <div style="text-align:center;margin:0px auto;">
                         <span class="title"><%#ChangeToString(Eval("ustate").ToString())%></span>
                         <span>   <a href="javascript:" onclick="ChangeUserState(<%# Eval("uid").ToString() %>,<%#Eval("ustate").ToString()%>)" id="changeStateBtn"><%#StateOperation(Eval("ustate").ToString())%></a></span>
                    </div>
                </div>
        <%--        <div class="operateButton">
                 
                </div>--%>
      
        </ItemTemplate>
        <HeaderStyle BackColor="#aaccff" BorderColor="#eeee44" />
    
    </asp:DataList>
</div>
<div style="clear:both;"></div>
<div class="pageFoot">
   <div class="pageNumber"><asp:Literal runat="server" ID="pageNumber"></asp:Literal></div> 
</div>
<script type="text/javascript">
    function ChangeUserState(userid,userstate){
               if(confirm("确定操作码？")){
//                alert(userid);
                if(userstate=="1")
                    WebService.UpdateUserStateByAdmin(userid,"forbiden",onSuccess);
                else if(userstate=="0")
                      WebService.UpdateUserStateByAdmin(userid,"normal",onSuccess);
                
               }
     return false;
           
    }
    function onSuccess(result){
        if(result==1){
            alert("更改成功！");
             window.location="<%# Request.Url %>";
            return ;
        }
        else {
             alert("更改失败！");
             
              window.location="<%# Request.Url %>";
            return ;
        }
    }
</script>