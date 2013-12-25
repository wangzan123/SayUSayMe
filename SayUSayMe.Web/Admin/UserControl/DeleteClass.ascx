<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DeleteClass.ascx.cs" Inherits="Admin_UserControl_DeleteClass" %>
<asp:ScriptManager runat="server" ID="ScriptManager1">
    <Services>
        <asp:ServiceReference Path="~/WebService.asmx" />
    </Services>
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div>请选择板块：<asp:DropDownList runat="server" Width="160px" ID="droCatalogName" OnSelectedIndexChanged="DroCatalogChange" AutoPostBack="true"></asp:DropDownList></div>
        <hr style="color:Red; height:1px;" />
        <div>
          <asp:DataList ID="showClassState" runat="server" Width="100%">
         <HeaderTemplate>
            <div class="articleBlockTitle">
                <span id="UserID">小板块名称</span>
                <span id="UserNowState">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
                小板块状态</span>
                
            </div>
        </HeaderTemplate>
        <ItemTemplate>
            <div class="UserItem">
                <div class="UserID">
                     <span class="title"><%# Eval("ClassName")%></span>
                </div>
                <div class="UserState">
                    <div style="text-align:center;margin:0px auto;">
                         <span class="title"><%#ChangeToString(Eval("ClassState").ToString())%></span>
                         <span>   <a href="javascript:" onclick="ChangeClassState(<%# Eval("ClassID").ToString() %>,<%#Eval("ClassState").ToString()%>)" id="changeStateBtn"><%#StateOperation(Eval("classState").ToString())%></a></span>
                    </div>
                </div>
         </ItemTemplate>
        <HeaderStyle BackColor="#aaccff" BorderColor="#eeee44" />
    
    </asp:DataList>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<div style="clear:both;"></div>
<div class="pageFoot">
   <div class="pageNumber"><asp:Literal runat="server" ID="pageNumber"></asp:Literal></div> 
</div>
<script type="text/javascript">
    function ChangeClassState(cid,cstate){
       if(confirm("确定操作吗？")){
                WebService.updateClassState(cid,cstate,onSuccess);
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