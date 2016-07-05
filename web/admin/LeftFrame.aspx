<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <title>荒野新闻系统</title>
    <meta content="荒野" name="author" />
    <meta content="荒野新闻系统, Visual Studio 2005" name="description" />
    <meta content="Visual Studio 2005, C# 2.0" name="generator" />
    <meta content="荒野 ASP.NET 2.0 新闻系统" name="keywords" />
    <meta content="text/html; charset=gb2312" http-equiv="content-type" />
    <link href="../Styles/LeftFrame.css" media="all" rel="stylesheet" type="text/css" />

    <script language="javascript" src="../JScript/LeftFrame.js" type="text/javascript"></script>

</head>
<body>
    <table cellspacing="0" cellpadding="0" width="158" align="center">
        <tr>
            <td background="../images/admin_default/admin_title_bg_quit.gif" height="25">
                &nbsp;&nbsp;<a href="admin_login.aspx" target="MainFrame"><strong>重登陆</strong></a>&nbsp;&nbsp;<a
                    href="admin_logout.aspx" target="_top"><strong>退出登陆</strong></a></td>
        </tr>
    </table>
    <br />
    <table cellspacing="0" cellpadding="0" width="158" align="center">
        <tr style="cursor: hand">
            <td background="../images/admin_default/admin_title_bg_show.gif" class="menu_title"
                onmouseover="this.className='menu_title2';" onclick="menuChange(this,bookSys);"
                onmouseout="this.className='menu_title';" height="25">
                <span>图书管理</span></td>
        </tr>
        <tr>
            <td>
                <div class="sec_menu" id="bookSys">
                    <table cellspacing="0" cellpadding="0" width="140" align="center">
                        <tr>
                            <td height="20">
                                <a href="addBookCategory.aspx" target="MainFrame">添加分类</a>&nbsp;|&nbsp;<a href="BookCategory.aspx"
                                    target="MainFrame">管理</a>
                            </td>
                        </tr>
                        <tr>
                            <td height="20">
                                <a href="addBook.aspx" target="MainFrame">添加图书</a>&nbsp;|&nbsp;<a href="bookList.aspx"
                                    target="MainFrame">管理</a>
                            </td>
                        </tr>
                        <tr>
                            <td height="20">
                                <a href="addPublish.aspx" target="MainFrame">添加出版社</a>&nbsp;|&nbsp;<a href="publish.aspx"
                                    target="MainFrame">管理</a>
                            </td>
                        </tr>
                        <tr>
                            <td height="20">
                                <a href="addBookCatena.aspx" target="MainFrame">添加图书系列</a>&nbsp;|&nbsp;<a href="bookCatena.aspx"
                                    target="MainFrame">管理</a>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <br />
          <TABLE class="Left_Item01" cellSpacing=0 cellPadding=0 width="100%" 
border=0>
        <TBODY>
        <TR onclick=showMenu(a2,this)>
          <TD class="Left_Item01_Title" style="CURSOR: hand">商品管理</TD>
          <TD style="CURSOR: hand"><IMG alt=显示/隐藏子菜单 
            src="../images/down.gif"></TD></TR></TBODY></TABLE>
    <table cellspacing="0" cellpadding="0" width="158" align="center">
        <tr style="cursor: hand">
            <td background="../images/admin_default/admin_title_bg_show.gif" class="menu_title"
                onmouseover="this.className='menu_title2';" onclick="menuChange(this,menuNews);"
                onmouseout="this.className='menu_title';" height="25">
                <span>订单管理</span></td>
        </tr>
        <tr>
            <td>
                <div class="sec_menu" id="menuNews">
                    <table cellspacing="0" cellpadding="0" width="140" align="center" border="0">
                        <tr>
                            <td height="20">
                                <a href="orderList.aspx" target="MainFrame">未确认</a>&nbsp;|&nbsp;<a href="orderList.aspx"
                                    target="MainFrame">已确认</a></td>
                        </tr>
                        <tr>
                            <td height="20">
                                <a href="orderList.aspx" target="MainFrame">未付款</a>&nbsp;|&nbsp;<a href="orderList.aspx"
                                    target="MainFrame">已付款</a></td>
                        </tr>
                        <tr>
                            <td style="height: 20px">
                                <a href="orderList.aspx" target="MainFrame">未发货</a>&nbsp;|&nbsp;<a href="orderList.aspx"
                                    target="MainFrame">已发货</a></td>
                        </tr>
                        <tr>
                            <td height="20">
                                <a href="orderList.aspx" target="MainFrame">未归档</a>&nbsp;|&nbsp;<a href="orderList.aspx"
                                    target="MainFrame">已归档</a></td>
                        </tr>
                        <tr>
                            <td style="height: 20px">
                                <a href="orderList.aspx" target="MainFrame">未取消</a>&nbsp;|&nbsp;<a href="orderList.aspx"
                                    target="MainFrame">已取消</a></td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <table cellspacing="0" cellpadding="0" width="158" align="center">
        <tr style="cursor: hand">
            <td background="../images/admin_default/admin_title_bg_show.gif" class="menu_title"
                onmouseover="this.className='menu_title2';" onclick="menuChange(this,menuPoll);"
                onmouseout="this.className='menu_title';" height="25">
                <span>新闻动态/调查/样式</span></td>
        </tr>
        <tr>
            <td>
                <div class="sec_menu" id="menuPoll">
                    <table cellspacing="0" cellpadding="0" width="140" align="center">
                        <tr>
                            <td style="width: 140px; height: 20px">
                                <a href="addDynamic.aspx" target="MainFrame">添加新闻</a>&nbsp;|&nbsp;<a href="Dynamic.aspx"
                                    target="MainFrame">管理新闻</a></td>
                        </tr>
                        <tr>
                            <td height="20" style="width: 140px">
                                <a href="addPoll.aspx" target="MainFrame">添加调查</a>&nbsp;|&nbsp;<a href="polls.aspx"
                                    target="MainFrame">管理调查</a></td>
                        </tr>
                        <tr>
                            <td height="20" style="width: 140px">
                                <a href="addTitleCss.aspx" target="MainFrame">添加标题样式</a>&nbsp;|&nbsp;<a href="titleCss.aspx"
                                    target="MainFrame">标题管理</a></td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <table cellspacing="0" cellpadding="0" width="158" align="center">
        <tr style="cursor: hand">
            <td background="../images/admin_default/admin_title_bg_show.gif" class="menu_title"
                onmouseover="this.className='menu_title2';" onclick="menuChange(this,menuUser);"
                onmouseout="this.className='menu_title';" height="25">
                <span>会员管理</span></td>
        </tr>
        <tr>
            <td>
                <div class="sec_menu" id="menuUser">
                    <table cellspacing="0" cellpadding="0" width="140" align="center">
                        <tr>
                            <td height="20">
                                <a href="../userReg.aspx" target="MainFrame">添加会员</a>&nbsp;|&nbsp;<a href="memberList.aspx"
                                    target="MainFrame">管理</a></td>
                        </tr>
                        <tr>
                            <td height="20">
                                <a href="addGroup.aspx" target="MainFrame">添加会员组</a>&nbsp;|&nbsp;<a href="group.aspx"
                                    target="MainFrame">管理</a></td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <br />
        <table cellspacing="0" cellpadding="0" width="158" align="center">
        <tr style="cursor: hand">
            <td background="../images/admin_default/admin_title_bg_show.gif" class="menu_title"
                onmouseover="this.className='menu_title2';" onclick="menuChange(this,menuUser);"
                onmouseout="this.className='menu_title';" height="25">
                <span>物流系统</span></td>
        </tr>
        <tr>
            <td>
                <div class="sec_menu" id="Div1">
                    <table cellspacing="0" cellpadding="0" width="140" align="center">
                        <tr>
                            <td height="20">
                                <a href="../userReg.aspx" target="MainFrame">支付方式添加</a>&nbsp;|&nbsp;<a href="memberList.aspx"
                                    target="MainFrame">管理</a></td>
                        </tr>
                        <tr>
                            <td height="20">
                                <a href="addGroup.aspx" target="MainFrame">配送方式添加</a>&nbsp;|&nbsp;<a href="group.aspx"
                                    target="MainFrame">管理</a></td>
                        </tr>
                                                <tr>
                            <td height="20">
                                <a href="addGroup.aspx" target="MainFrame">配送地区添加</a>&nbsp;|&nbsp;<a href="group.aspx"
                                    target="MainFrame">管理</a></td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <table cellspacing="0" cellpadding="0" width="158" align="center">
        <tr style="cursor: hand">
            <td background="../images/admin_default/admin_title_bg_show.gif" class="menu_title"
                onmouseover="this.className='menu_title2';" onclick="menuChange(this,menuLink);"
                onmouseout="this.className='menu_title';" height="25">
                <span>友情链接</span></td>
        </tr>
        <tr>
            <td>
                <div class="sec_menu" id="menuLink">
                    <table cellspacing="0" cellpadding="0" width="140" align="center">
                        <tr>
                            <td height="20">
                                <a href="addFriendLink.aspx" target="MainFrame">添加链接</a>&nbsp;|&nbsp;<a href="friendLink.aspx"
                                    target="MainFrame">管理</a>
                            </td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <table cellspacing="0" cellpadding="0" width="158" align="center">
        <tr style="cursor: hand">
            <td background="../images/admin_default/admin_title_bg_show.gif" class="menu_title"
                onmouseover="this.className='menu_title2';" onclick="menuChange(this,menuSys);"
                onmouseout="this.className='menu_title';" height="25">
                <span>系统管理</span></td>
        </tr>
        <tr>
            <td>
                <div class="sec_menu" id="menuSys">
                    <table cellspacing="0" cellpadding="0" width="140" align="center">
                        <tr>
                            <td height="20">
                                <a href="admin_config.aspx" target="MainFrame">系统设置</a>&nbsp;|&nbsp;<a href="admin_maintain.aspx"
                                    target="MainFrame">系统维护</a></td>
                        </tr>
                        <tr>
                            <td height="20">
                                <a href="admin_resetnum.aspx" target="MainFrame">数据统计</a>&nbsp;|&nbsp;<a href="admin_statistic.aspx"
                                    target="MainFrame">站点统计</a></td>
                        </tr>
                        <tr>
                            <td height="20">
                                <a href="admin_upfiles.aspx" target="MainFrame">上传管理</a>&nbsp;|&nbsp;<a href="admin_logs.aspx"
                                    target="MainFrame">系统日志</a></td>
                        </tr>
                        <tr>
                            <td height="20">
                                <a href="admin_message.aspx" target="MainFrame">留言板管理</a></td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <br />
    <table cellspacing="0" cellpadding="0" width="158" align="center">
        <tr style="cursor: hand">
            <td background="../images/admin_default/admin_title_bg_show.gif" class="menu_title"
                onmouseover="this.className='menu_title2';" onclick="menuChange(this,menuCopyright);"
                onmouseout="this.className='menu_title';" height="25">
                <span>版权信息</span>
            </td>
        </tr>
        <tr>
            <td>
                <div class="sec_menu" id="menuCopyright">
                    <table cellspacing="0" cellpadding="0" width="140" align="center" id="Table15">
                        <tr>
                            <td height="20">
                                &nbsp;技术支持：<a href="http://wildknight.vicp.net/" target="_blank">商职</a>院</td>
                        </tr>
                    </table>
                </div>
            </td>
        </tr>
    </table>
    <br />
</body>
</html>

