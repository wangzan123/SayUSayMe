<%@ Page Title="" Language="C#" MasterPageFile="~/NewsManage/Style/MasterPage.master" AutoEventWireup="true" CodeFile="MainNews.aspx.cs" Inherits="NewsManage_news_datagrid_MainNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../../Style/templatemo_style.css" rel="stylesheet" type="text/css" />
    <script language="javascript" type="text/javascript">
        function clearText(field) {
            if (field.defaultValue == field.value) field.value = '';
            else if (field.value == '') field.value = field.defaultValue;
        }
    </script>
    
    <style type="text/css">
body{background:#E9E6E6;}
#tagsList {position:relative; width:250px; height:250px; margin: 0px auto 0;  }
#tagsList a {position:absolute; top:0px; left:0px; font-family: Microsoft YaHei; color:#24313d; font-weight:bold; text-decoration:none; padding: 3px 6px; }
#tagsList a:hover { color:#00008b; letter-spacing:2px;}
</style>
<script type="text/javascript" src="../../Style/js/tags.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <form id="form1" runat="server">
    <div class="fp_services_box">
            <div class="fps_title">国际新闻</div>
            <p>国际微新闻(Foreign micro-news)</p>
            &nbsp;</div>
        
        <div class="fp_services_box">
            <div class="fps_title">国内新闻</div>
            <p>国内新闻(Domestic micro-news)</p>
            &nbsp;</div>
        
        <div class="fp_services_box l_box">
            <div class="fps_title"><a href="#">趣味</a>新闻</div>
            <p>趣味新闻(Fun Micro News)</p>
            &nbsp;</div>
    
    </div> <!-- end of templatemo fp services -->
    
        <div id="templatemo_main">
    
            <div class="col_w620 float_r">
                <h2>本站新闻简介</h2> 
            
                &nbsp;<p>
                          为了丰富IT朋友们的生活和技术需要。本站选取了一些经典新微新闻，为了让我们可以在较短的时间内可以了解到更多的内容；本站所有的新闻都不超过150字。
                          虽然简短但是精湛，我们选取了国内外的最新新闻，努力让大家可以更全面地找到自己喜欢的~~</br>
                    我们时刻欢迎您的宝贵意见！邮箱：392989505@qq.com
                      </p>
          	
          	<div class="cleaner h10"></div>
            
            <div class="cleaner"></div>
            
            <a class="more" href="#">More</a>
            
      </div>
        
        <div class="col_w300 float_l">
        	<h2> 新闻头条</h2>
            
            <div class="fp_news_box">
                
                <div id="tagsList">
                    <%--移动开发,asp.net,java，php，c++，c#，javascript，.net，汇编，算法设计，数据结构，云计算，jsp，操作系统，硬件，IIS，IOS，网站维护，HTML5--%> 
                    <a href="http://localhost:27265/SayUSayMe.Web/NewsManage/news/datagrid/ShowNews.aspx?sortName=移动开发" title="移动开发">移动开发</a>
                    <a href="http://localhost:27265/SayUSayMe.Web/NewsManage/news/datagrid/ShowNews.aspx?sortName=asp.net" title="asp.net">asp.net</a>
                    <a href="http://localhost:27265/SayUSayMe.Web/NewsManage/news/datagrid/ShowNews.aspx?sortName=asp.net" title="java">java</a>
                    <a href="http://localhost:27265/SayUSayMe.Web/NewsManage/news/datagrid/ShowNews.aspx?sortName=java" title="php">php</a>
                    <a href="http://localhost:27265/SayUSayMe.Web/NewsManage/news/datagrid/ShowNews.aspx?sortName=php" title="php">php</a>
                    <a href="http://localhost:27265/SayUSayMe.Web/NewsManage/news/datagrid/ShowNews.aspx?sortName=c++" title="c++">c++</a>
                    <a href="http://localhost:27265/SayUSayMe.Web/NewsManage/news/datagrid/ShowNews.aspx?sortName=c#" title="c#">c#</a>
                    <a href="http://localhost:27265/SayUSayMe.Web/NewsManage/news/datagrid/ShowNews.aspx?sortName=javascript" title="javascript">javascript</a>
                    <a href="http://localhost:27265/SayUSayMe.Web/NewsManage/news/datagrid/ShowNews.aspx?sortName=.net" title=".net">.net</a>
                    <a href="http://localhost:27265/SayUSayMe.Web/NewsManage/news/datagrid/ShowNews.aspx?sortName=汇编" title="汇编">汇编</a>
                    <a href="http://localhost:27265/SayUSayMe.Web/NewsManage/news/datagrid/ShowNews.aspx?sortName=算法设计" title="算法设计">算法设计</a>
                    <a href="http://localhost:27265/SayUSayMe.Web/NewsManage/news/datagrid/ShowNews.aspx?sortName=数据结构" title="数据结构">数据结构</a>
                    <a href="http://localhost:27265/SayUSayMe.Web/NewsManage/news/datagrid/ShowNews.aspx?sortName=云计算" title="云计算">云计算</a>
                    <a href="http://localhost:27265/SayUSayMe.Web/NewsManage/news/datagrid/ShowNews.aspx?sortName=jsp" title="jsp">jsp</a>
                    <a href="http://localhost:27265/SayUSayMe.Web/NewsManage/news/datagrid/ShowNews.aspx?sortName=操作系统" title="操作系统">操作系统</a>
                    <a href="http://localhost:27265/SayUSayMe.Web/NewsManage/news/datagrid/ShowNews.aspx?sortName=硬件" title="硬件">硬件</a>
                    <a href="http://localhost:27265/SayUSayMe.Web/NewsManage/news/datagrid/ShowNews.aspx?sortName=IIS" title="IIS">IIS</a>
                    <a href="http://localhost:27265/SayUSayMe.Web/NewsManage/news/datagrid/ShowNews.aspx?sortName=IOS" title="IOS">IOS</a>
                    <a href="http://localhost:27265/SayUSayMe.Web/NewsManage/news/datagrid/ShowNews.aspx?sortName=网站维护" title="网站维护">网站维护</a>
                    <a href="http://localhost:27265/SayUSayMe.Web/NewsManage/news/datagrid/ShowNews.aspx?sortName=HTML5" title="HTML5">HTML5</a>
                </div>

            </div>
        
        <div class="cleaner"></div>
    </div> <!-- end of main -->
	<div id="templatemo_main_bottom"></div>
	<div class="cleaner"></div>
</div> <!-- end of templatemo wrapper -->
</div> <!-- end of templatemo body wrapper -->

<div id="templatemo_footer_wrapper">

	<div id="templatemo_footer">
    	Copyright © 2048 <a href="#">SayUSayMe技术论坛</a> - 
        from <a href="http://www.SayUSayMe.com" target="_parent" title="网站">SayUSayMe技术论坛</a>
        <div class="cleaner"></div>
	</div>
    
</div>
    </form>
</asp:Content>

