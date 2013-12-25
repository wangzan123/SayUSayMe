<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DeleteCatalog.ascx.cs" Inherits="Admin_UserControl_DeleteCatalog" %>

<asp:ScriptManager ID="ScriptManager1" runat="server">
    <Services>
        <asp:ServiceReference Path="~/WebService.asmx" />
    </Services>
</asp:ScriptManager>
<div id="userStateBlock">
    <asp:DataList ID="showUserState" runat="server" Width="100%">
         <HeaderTemplate>
            <div class="articleBlockTitle">
                <span id="UserID">大板块名称</span>
                <span id="UserNowState">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                大板块状态</span>
                
            </div>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="UserItem">
                <div class="UserID">
                     <span class="title"><%# Eval("CName")%></span>
                </div>
                <div class="UserState">
                    <div style="text-align:center;margin:0px auto;">
                         <span class="title"><%#ChangeToString(Eval("CState").ToString())%></span>
                         <span>   <a href="javascript:" onclick="ChangeUserState(<%# Eval("Cid").ToString() %>,<%#Eval("CState").ToString()%>)" id="changeStateBtn"><%#StateOperation(Eval("CState").ToString())%></a></span>
                    </div>
                </div>
         </ItemTemplate>
        <HeaderStyle BackColor="#aaccff" BorderColor="#eeee44" />
    
    </asp:DataList>
</div>
<div style="clear:both;"></div>
<div class="pageFoot">
   <div class="pageNumber"><asp:Literal runat="server" ID="pageNumber"></asp:Literal></div> 
</div>
<script type="text/javascript">
    function ChangeUserState(cid,cstate){
       if(confirm("确定操作码？")){
                     WebService.updateCatalogState(cid,cstate,onSuccess);
               }
     return false;
           
    }
    function onSuccess(result){
        if(result=="success"){
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