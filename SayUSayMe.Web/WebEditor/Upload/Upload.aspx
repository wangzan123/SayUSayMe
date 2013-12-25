<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Upload.aspx.cs" Inherits="WebEditor_Upload_Upload" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Upload.css" type="text/css" rel="Stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="allpage">
        <div class="title">
            <div class="tabTitle"><span>本地上传</span></div>
        </div>
        <!-- fieldset 元素可将表单内的相关元素分组。
        <fieldset> 标签将表单内容的一部分打包，生成一组相关表单的字段。<fieldset> 标签没有必需的或唯一的属性。
        当一组表单元素放到 <fieldset> 标签内时，浏览器会以特殊方式来显示它们，它们可能有特殊的边界、3D 效果，或者甚至可创建一个子表单来处理这些元素。
        <div> 可定义文档中的分区或节（division/section）。 
        <div> 标签可以把文档分割为独立的、不同的部分。它可以用作严格的组织工具，并且不使用任何格式与其关联。 
        如果用 id 或 class 来标记 <div>，那么该标签的作用会变得更加有效。 

        用法 
        <div> 是一个块级元素。这意味着它的内容自动地开始一个新行。实际上，换行是 <div> 固有的唯一格式表现。可以通过 <div> 的 class 或 id 应用额外的样式。 
        不必为每一个 <div> 都加上类或 id，虽然这样做也有一定的好处。 
        可以对同一个 <div> 元素应用 class 或 id 属性，但是更常见的情况是只应用其中一种。这两者的主要差异是，class 用于元素组（类似的元素，或者可以理解为某一类元素），而 id 用于标识单独的唯一的元素。 
        -->
        <div class="content">
            <div>
                <fieldset>
                    <legend><asp:Literal runat="server" ID="Caption"></asp:Literal></legend>
                    <asp:FileUpload ID="ImgUpload" runat="server" Width="80%" ToolTip="浏览文件"/>
                </fieldset>
                <asp:LinkButton ID="btnOK1" runat="server" CssClass="btn out" onmouseover="this.className='btn over'" onmouseout="this.className='btn out'" Width="60px" ToolTip="确定" OnClick="btnOK1_Click">确定</asp:LinkButton>
                <asp:LinkButton ID="btnCancle1" runat="server" CssClass="btn out" onmouseover="this.className='btn over'" onmouseout="this.className='btn out'" Width="60px" ToolTip="取消">取消</asp:LinkButton>
                <fieldset>
                    <legend>提示信息</legend>
                    <ul class="messageList">
                        <asp:Literal runat="server" ID="showMessage"></asp:Literal>
                    </ul>
                </fieldset>
            </div>
        </div>
    </div>
    
    </form>
</body>
</html>
