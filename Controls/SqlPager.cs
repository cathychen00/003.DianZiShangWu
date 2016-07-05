using System;
using System.IO;
using System.Drawing;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Configuration;

namespace Jiaen.Controls
{
    #region 枚举 缓存模式
    public enum PagingMode
    {
        //缓存
        Cached,
        //不缓存
        NonCached
    }
    #endregion

    #region 枚举 导航条样式
    public enum PagerStyle
    {
        Character,
        NextPrev,
        NumericPages
    }
    #endregion

    #region 枚举 排序模式
    public enum SortMode
    {
        ASC,
        DESC
    }
    #endregion

    #region 类 记录统计
    public class VirtualRecordCount
    {
        public int RecordCount;
        public int PageCount;
        //最后一页的记录数
        public int RecordsInLastPage;
    }
    #endregion

    #region 类 页面改变事件参数
    public class PageChangedEventArgs : EventArgs
    {
        public int OldPageIndex;
        public int NewPageIndex;
    }
    #endregion

    #region SqlPager分页控件

    [DefaultProperty("SelectCommand")]
    [DefaultEvent("PageIndexChanged")]
    [ToolboxData("<{0}:SqlPager runat=\"server\" />")]
    public class SqlPager : WebControl, INamingContainer
    {
        #region 私有成员
        // ***********************************************************************
        // 私有成员

        //数据源
        private PagedDataSource _dataSource;
        //数据容器
        private Control _controlToPaginate;
        private string CacheKeyName
        {
            get { return Page.Request.FilePath + "_" + UniqueID + "_Data"; }
        }
        //导航条页面信息显示
        private string CurrentPageText = "当前第<font color={0}>{1}</font>页 共分<font color={0}>{2}</font>页 总计<font color={0}>{3}</font>条 每页<font color={0}>{4}</font>条";
        //导航条无记录显示
        private string NoPageSelectedText = "没有记录！";
        //格式化sql查询语句
        private string QueryPageCommandText = "Select * FROM " +
        "(Select TOP {0} * FROM " +
        "(Select TOP {1} * FROM ({2}) AS t0 orDER BY {3} {4}) AS t1 " +
        "ORDER BY {3} {5}) AS t2 " +
        "ORDER BY {3} {4}";
        //格式化sql记录统计语句
        private string QueryCountCommandText = "Select COUNT(*) FROM ({0}) AS t0";
        // ***********************************************************************
        #endregion

        #region 构造器
        // ***********************************************************************
        // 构造器
        public SqlPager()
            : base()
        {
            _dataSource = null;
            _controlToPaginate = null;

            Font.Name = "verdana";
            Font.Size = FontUnit.Point(9);
            BackColor = Color.Gainsboro;
            ForeColor = Color.Black;
            IndexColor = Color.Black;
            BorderStyle = BorderStyle.Outset;
            BorderWidth = Unit.Parse("1px");
            PagingMode = PagingMode.Cached;
            PagerStyle = PagerStyle.Character;
            CurrentPageIndex = 0;
            SelectCommand = "";
            ConnectionString = "";
            ItemsPerPage = 15;
            TotalPages = -1;
            CacheDuration = 60;
            SortMode = SortMode.DESC;
            ConnectionString = ConfigurationSettings.AppSettings["CONN_STR"];
        }
        // ***********************************************************************
        #endregion

        #region 公共程序接口


        #region 方法 清空缓存
        /// <summary>
        /// 方法 清空缓存
        /// </summary>
        public void ClearCache()
        {
            if (PagingMode == PagingMode.Cached)
                Page.Cache.Remove(CacheKeyName);
        }
        #endregion


        #region 事件 页面索引改变
        // ***********************************************************************
        /// <summary>
        /// 事件 页面索引改变
        /// 当跳转到新页面时发生
        /// </summary>
        public delegate void PageChangedEventHandler(object sender, PageChangedEventArgs e);
        public event PageChangedEventHandler PageIndexChanged;
        protected virtual void OnPageIndexChanged(PageChangedEventArgs e)
        {
            if (PageIndexChanged != null)
                PageIndexChanged(this, e);
        }
        // ***********************************************************************
        #endregion


        #region 属性 缓存过期时间
        // ***********************************************************************
        // 属性 缓存过期时间
        [Description("取得或设置数据在缓存中保存多少秒")]
        public int CacheDuration
        {
            get { return Convert.ToInt32(ViewState["CacheDuration"]); }
            set { ViewState["CacheDuration"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region 属性 缓存模式
        // ***********************************************************************
        // 属性 缓存模式
        [Description("指定数据是否需要在页面上缓存")]
        public PagingMode PagingMode
        {
            get { return (PagingMode)ViewState["PagingMode"]; }
            set { ViewState["PagingMode"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region 属性 导航条样式
        // ***********************************************************************
        // 属性 导航条样式
        [Description("指定导航条样式")]
        public PagerStyle PagerStyle
        {
            get { return (PagerStyle)ViewState["PagerStyle"]; }
            set { ViewState["PagerStyle"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region 属性 索引值颜色
        // ***********************************************************************
        // 属性 索引值颜色
        [Description("指定索引值颜色")]
        public Color IndexColor
        {
            get { return (Color)ViewState["IndexColor"]; }
            set { ViewState["IndexColor"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region 属性 数据容器
        // ***********************************************************************
        // 属性 数据容器
        [Description("取得设置数据容器的名字")]
        public string ControlToPaginate
        {
            get { return Convert.ToString(ViewState["ControlToPaginate"]); }
            set { ViewState["ControlToPaginate"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region 属性 每页记录数
        // ***********************************************************************
        // 属性 每页记录数
        [Description("取得设置每页显示的记录数")]
        public int ItemsPerPage
        {
            get { return Convert.ToInt32(ViewState["ItemsPerPage"]); }
            set { ViewState["ItemsPerPage"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region 属性 当前页索引
        // ***********************************************************************
        // 属性 当前页索引
        [Description("取得设置当前页面索引")]
        public int CurrentPageIndex
        {
            get { return Convert.ToInt32(ViewState["CurrentPageIndex"]); }
            set { ViewState["CurrentPageIndex"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region 属性 连接字符串
        // ***********************************************************************
        // 属性 连接字符串
        [Description("取得设置数据库连接字符串")]
        public string ConnectionString
        {
            get { return Convert.ToString(ViewState["ConnectionString"]); }
            set { ViewState["ConnectionString"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region 属性 查询语句
        // ***********************************************************************
        // 属性 查询语句
        [Description("取得设置数据库查询语句")]
        public string SelectCommand
        {
            get { return Convert.ToString(ViewState["SelectCommand"]); }
            set { ViewState["SelectCommand"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region 属性 排序字段
        // ***********************************************************************
        // 属性 排序字段
        [Description("取得设置排序字段，仅在无缓存的模式下可用")]
        public string SortField
        {
            get { return Convert.ToString(ViewState["SortKeyField"]); }
            set { ViewState["SortKeyField"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region 属性 总页数
        // ***********************************************************************
        // 属性 总页数
        // 取得显示页面的总数
        [Browsable(false)]
        public int PageCount
        {
            get { return TotalPages; }
        }
        // ***********************************************************************
        #endregion

        #region 属性 总页数
        // ***********************************************************************
        // 属性 总页数
        // 取得设置显示页面的总数
        protected int TotalPages
        {
            get { return Convert.ToInt32(ViewState["TotalPages"]); }
            set { ViewState["TotalPages"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region 属性 总记录数
        // ***********************************************************************
        // 属性 总记录数
        // 取得设置总记录数
        protected int TotalRecords
        {
            get { return Convert.ToInt32(ViewState["TotalRecords"]); }
            set { ViewState["TotalRecords"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region 属性 排序模式
        // ***********************************************************************
        // 属性 排序模式
        [Description("取得设置排序模式")]
        public SortMode SortMode
        {
            get { return (SortMode)ViewState["SortMode"]; }
            set { ViewState["SortMode"] = value; }
        }
        // ***********************************************************************
        #endregion


        #region 方法 重载 数据绑定
        // ***********************************************************************
        // 方法 重载数据绑定
        /// <summary>
        /// 取得，填充数据
        /// </summary>
        public override void DataBind()
        {
            // 触发数据绑定事件
            base.DataBind();

            // 控件必须在数据绑定后重新创建
            ChildControlsCreated = false;

            // 确定数据容器存在并且为列表控件(list control)
            if (ControlToPaginate == "")
                return;
            _controlToPaginate = Page.FindControl(ControlToPaginate);
            if (_controlToPaginate == null)
                return;
            if (!(_controlToPaginate is BaseDataList || _controlToPaginate is ListControl))
                return;

            // 确定数据库连接字符串有效且查询命令已指定
            if (ConnectionString == "" || SelectCommand == "")
                return;

            // 取得数据
            if (PagingMode == PagingMode.Cached)
                FetchAllData();
            else
            {
                //if (SortField == "")
                // return;
                FetchPageData();
            }

            // Bind data to the buddy control
            // 绑定数据到数据容器
            BaseDataList baseDataListControl = null;
            ListControl listControl = null;
            if (_controlToPaginate is BaseDataList)
            {
                baseDataListControl = (BaseDataList)_controlToPaginate;
                baseDataListControl.DataSource = _dataSource;
                baseDataListControl.DataBind();
                return;
            }
            if (_controlToPaginate is ListControl)
            {
                listControl = (ListControl)_controlToPaginate;
                listControl.Items.Clear();
                listControl.DataSource = _dataSource;
                listControl.DataBind();
                return;
            }
        }
        // ***********************************************************************
        #endregion

        #region 方法 重载 传递数据
        // ***********************************************************************
        // 方法 重载 传递数据
        // 把数据内容传递到客户端
        protected override void Render(HtmlTextWriter output)
        {
            // If in design-mode ensure that child controls have been created.
            // Child controls are not created at this time in design-mode because
            // there's no pre-render stage. Do so for composite controls like this 
            if (Site != null && Site.DesignMode)
                CreateChildControls();

            base.Render(output);
        }
        // ***********************************************************************
        #endregion

        #region 方法 重载 创建子控件
        // ***********************************************************************
        // 方法 重载 创建子控件
        // Outputs the HTML markup for the control
        protected override void CreateChildControls()
        {
            Controls.Clear();
            ClearChildViewState();

            BuildControlHierarchy();
        }
        // ***********************************************************************
        #endregion


        #endregion

        #region 私有方法

        #region 方法 创建导航条
        // ***********************************************************************
        // 方法 创建导航条
        private void BuildControlHierarchy()
        {
            // 导航条表格，1行2列
            Table t = new Table();
            t.Font.Name = Font.Name;
            t.Font.Size = Font.Size;
            t.BorderStyle = BorderStyle;
            t.BorderWidth = BorderWidth;
            t.BorderColor = BorderColor;
            t.Width = Width;
            t.Height = Height;
            t.BackColor = BackColor;
            t.ForeColor = ForeColor;

            // 表格行
            TableRow row = new TableRow();
            t.Rows.Add(row);

            // 页面索引单元格
            TableCell cellPageDesc = new TableCell();
            cellPageDesc.HorizontalAlign = HorizontalAlign.Right;
            BuildCurrentPage(cellPageDesc);
            row.Cells.Add(cellPageDesc);

            // 导航按钮单元格
            TableCell cellNavBar = new TableCell();

            switch (PagerStyle)
            {
                //字符导航条
                case PagerStyle.Character:
                    BuildCharacterUI(cellNavBar);
                    break;
                case PagerStyle.NextPrev:
                    BuildNextPrevUI(cellNavBar);
                    break;
                case PagerStyle.NumericPages:
                    BuildNumericPagesUI(cellNavBar);
                    break;
                default:
                    break;
            }

            row.Cells.Add(cellNavBar);

            TableCell cellTip = new TableCell();
            cellTip.Text = "跳转到";
            row.Cells.Add(cellTip);

            //跳转到指定页输入框和按钮
            TableCell cellGotoPage = new TableCell();
            BuildGotoPage(cellGotoPage);
            row.Cells.Add(cellGotoPage);

            // 把表格加入到控件树
            Controls.Add(t);
        }
        // ***********************************************************************
        #endregion

        #region 建立字符导航栏
        /// <summary>
        /// 建立字符导航栏
        /// </summary>
        /// <param name="cell"></param>
        private void BuildCharacterUI(TableCell cell)
        {
            bool isValidPage = (CurrentPageIndex >= 0 && CurrentPageIndex <= TotalPages - 1);
            bool canMoveBack = (CurrentPageIndex > 0);
            bool canMoveForward = (CurrentPageIndex < TotalPages - 1);

            //定义首页按钮式样
            LinkButton first = new LinkButton();
            first.ID = "First";
            first.CausesValidation = false;
            first.Click += new EventHandler(first_Click);
            first.ToolTip = "首页";
            first.Text = "首页";
            first.Enabled = isValidPage && canMoveBack;
            cell.Controls.Add(first);

            //加空格
            cell.Controls.Add(new LiteralControl(" "));

            //定义前页按钮式样
            LinkButton prev = new LinkButton();
            prev.ID = "Prev";
            prev.CausesValidation = false;
            prev.Click += new EventHandler(prev_Click);
            prev.ToolTip = "前页";
            prev.Text = "前页";
            prev.Enabled = isValidPage && canMoveBack;
            cell.Controls.Add(prev);

            //加空格
            cell.Controls.Add(new LiteralControl(" "));

            //定义后页按钮式样
            LinkButton next = new LinkButton();
            next.ID = "Next";
            next.CausesValidation = false;
            next.Click += new EventHandler(next_Click);
            next.ToolTip = "后页";
            next.Text = "后页";
            next.Enabled = isValidPage && canMoveForward;
            cell.Controls.Add(next);

            //加空格
            cell.Controls.Add(new LiteralControl(" "));

            //定义尾页按钮式样
            LinkButton last = new LinkButton();
            last.ID = "Last";
            last.CausesValidation = false;
            last.Click += new EventHandler(last_Click);
            last.ToolTip = "尾页";
            last.Text = "尾页";
            last.Enabled = isValidPage && canMoveForward;
            cell.Controls.Add(last);


        }
        // ***********************************************************************
        #endregion

        #region BuildNextPrevUI
        // ***********************************************************************
        // PRIVATE BuildNextPrevUI
        // Generates the HTML markup for the Next/Prev navigation bar
        private void BuildNextPrevUI(TableCell cell)
        {
            bool isValidPage = (CurrentPageIndex >= 0 && CurrentPageIndex <= TotalPages - 1);
            bool canMoveBack = (CurrentPageIndex > 0);
            bool canMoveForward = (CurrentPageIndex < TotalPages - 1);

            // Render the << button
            LinkButton first = new LinkButton();
            first.ID = "First";
            first.Click += new EventHandler(first_Click);
            first.Font.Name = "webdings";
            first.Font.Size = FontUnit.Medium;
            first.ForeColor = ForeColor;
            first.ToolTip = "First page";
            first.Text = "7";
            first.Enabled = isValidPage && canMoveBack;
            cell.Controls.Add(first);

            // Add a separator
            cell.Controls.Add(new LiteralControl(" "));

            // Render the < button
            LinkButton prev = new LinkButton();
            prev.ID = "Prev";
            prev.Click += new EventHandler(prev_Click);
            prev.Font.Name = "webdings";
            prev.Font.Size = FontUnit.Medium;
            prev.ForeColor = ForeColor;
            prev.ToolTip = "Previous page";
            prev.Text = "3";
            prev.Enabled = isValidPage && canMoveBack;
            cell.Controls.Add(prev);

            // Add a separator
            cell.Controls.Add(new LiteralControl(" "));

            // Render the > button
            LinkButton next = new LinkButton();
            next.ID = "Next";
            next.Click += new EventHandler(next_Click);
            next.Font.Name = "webdings";
            next.Font.Size = FontUnit.Medium;
            next.ForeColor = ForeColor;
            next.ToolTip = "Next page";
            next.Text = "4";
            next.Enabled = isValidPage && canMoveForward;
            cell.Controls.Add(next);

            // Add a separator
            cell.Controls.Add(new LiteralControl(" "));

            // Render the >> button
            LinkButton last = new LinkButton();
            last.ID = "Last";
            last.Click += new EventHandler(last_Click);
            last.Font.Name = "webdings";
            last.Font.Size = FontUnit.Medium;
            last.ForeColor = ForeColor;
            last.ToolTip = "Last page";
            last.Text = "8";
            last.Enabled = isValidPage && canMoveForward;
            cell.Controls.Add(last);
        }
        // ***********************************************************************
        #endregion

        #region BuildNumericPagesUI
        // ***********************************************************************
        // PRIVATE BuildNumericPagesUI
        // Generates the HTML markup for the Numeric Pages button bar
        private void BuildNumericPagesUI(TableCell cell)
        {
            // Render a drop-down list 
            DropDownList pageList = new DropDownList();
            pageList.ID = "PageList";
            pageList.AutoPostBack = true;
            pageList.SelectedIndexChanged += new EventHandler(PageList_Click);
            pageList.Font.Name = Font.Name;
            pageList.Font.Size = Font.Size;
            pageList.ForeColor = ForeColor;

            // Embellish the list when there are no pages to list 
            if (TotalPages <= 0 || CurrentPageIndex == -1)
            {
                pageList.Items.Add("No pages");
                pageList.Enabled = false;
                pageList.SelectedIndex = 0;
            }
            else // Populate the list
            {
                for (int i = 1; i <= TotalPages; i++)
                {
                    ListItem item = new ListItem(i.ToString(), (i - 1).ToString());
                    pageList.Items.Add(item);
                }
                pageList.SelectedIndex = CurrentPageIndex;
            }
            cell.Controls.Add(pageList);
        }
        // ***********************************************************************
        #endregion

        #region 方法 建立跳转到指定页面
        // ***********************************************************************
        // 方法 建立跳转到指定页面
        private void BuildGotoPage(TableCell cell)
        {
            // bool isValidPage = (CurrentPageIndex >=0 && CurrentPageIndex <= TotalPages-1);

            //跳转到页面索引输入框
            TextBox txbPage = new TextBox();
            txbPage.ID = "txbPage";
            txbPage.Width = 50;
            txbPage.MaxLength = 5;
            cell.Controls.Add(txbPage);

            //加空格
            cell.Controls.Add(new LiteralControl(" "));

            //跳转到按钮
            Button btnGo = new Button();
            btnGo.ID = "btnGo";
            btnGo.Text = "确定";
            btnGo.BorderStyle = BorderStyle.Ridge;
            btnGo.BorderWidth = 1;
            btnGo.CausesValidation = false;
            btnGo.Click += new EventHandler(btnGo_Click);
            // btnGo.Enabled = isValidPage;
            cell.Controls.Add(btnGo);

        }
        // ***********************************************************************
        #endregion

        #region 方法 当前页索引
        // ***********************************************************************
        // 方法 当前页索引
        // 从0开始
        private void BuildCurrentPage(TableCell cell)
        {
            Label lblIndex = new Label();
            string temp = "";

            // Use a standard template: Page X of Y
            if (CurrentPageIndex < 0 || CurrentPageIndex >= TotalPages)
            {
                temp = NoPageSelectedText;
            }
            else
            {
                temp = String.Format(CurrentPageText, IndexColor.Name, (CurrentPageIndex + 1), TotalPages, TotalRecords, ItemsPerPage);
            }

            lblIndex.Text = temp;
            cell.Controls.Add(lblIndex);

        }
        // ***********************************************************************
        #endregion

        #region 方法 验证当前页面索引是否有效
        // ***********************************************************************
        /// <summary>
        /// 方法 验证索引是否有效
        /// 确定当前页面索引范围:[0,TotalPages) or -1
        /// </summary>
        private void ValidatePageIndex()
        {
            //如果当前页记录删除，跳到前一页
            if (CurrentPageIndex == TotalPages)
            {
                CurrentPageIndex -= 1;
            }
            if (!(CurrentPageIndex >= 0 && CurrentPageIndex < TotalPages))
                CurrentPageIndex = -1;
            return;
        }
        // ***********************************************************************
        #endregion

        #region 方法 获取全部数据
        // ***********************************************************************
        // PRIVATE FetchAllData
        // Runs the query for all data to be paged and caches the resulting data
        private void FetchAllData()
        {
            // Looks for data in the ASP.NET Cache
            DataTable data;
            data = (DataTable)Page.Cache[CacheKeyName];
            if (data == null)
            {
                // Fix SelectCommand with order-by info
                AdjustSelectCommand(true);

                // If data expired or has never been fetched, go to the database
                SqlDataAdapter adapter = new SqlDataAdapter(SelectCommand, ConnectionString);
                data = new DataTable();
                adapter.Fill(data);
                Page.Cache.Insert(CacheKeyName, data, null,
                DateTime.Now.AddSeconds(CacheDuration),
                System.Web.Caching.Cache.NoSlidingExpiration);
            }

            // Configures the paged data source component
            if (_dataSource == null)
                _dataSource = new PagedDataSource();
            _dataSource.DataSource = data.DefaultView; // must be IEnumerable!
            _dataSource.AllowPaging = true;
            _dataSource.PageSize = ItemsPerPage;
            TotalPages = _dataSource.PageCount;
            TotalRecords = _dataSource.Count;

            // Ensures the page index is valid 
            ValidatePageIndex();
            if (CurrentPageIndex == -1)
            {
                _dataSource = null;
                return;
            }

            // Selects the page to view
            _dataSource.CurrentPageIndex = CurrentPageIndex;
        }
        // ***********************************************************************
        #endregion

        #region 方法 获取当前页面数据
        // ***********************************************************************
        /// <summary>
        /// 方法 获取当前页面数据
        /// </summary>
        private void FetchPageData()
        {
            // 必须获得一个有效的页面索引
            // 还需要虚拟页面记录统计来验证页面索引
            AdjustSelectCommand(false);
            VirtualRecordCount countInfo = CalculateVirtualRecordCount();
            TotalPages = countInfo.PageCount;
            TotalRecords = countInfo.RecordCount;

            // 验证页面索引值的有效性（当前页面索引必须有效或为－1）
            ValidatePageIndex();
            if (CurrentPageIndex == -1)
            {
                CurrentPageIndex = 0;
                // return;
            }

            // 准备，运行数据库查询
            SqlCommand cmd = PrepareCommand(countInfo);
            if (cmd == null)
                return;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapter.Fill(data);

            // 配置翻页数据源组件
            if (_dataSource == null)
                _dataSource = new PagedDataSource();
            _dataSource.AllowCustomPaging = true;
            _dataSource.AllowPaging = true;
            _dataSource.CurrentPageIndex = 0;
            _dataSource.PageSize = ItemsPerPage;
            _dataSource.VirtualCount = countInfo.RecordCount;
            _dataSource.DataSource = data.DefaultView;
        }
        // ***********************************************************************
        #endregion

        #region 方法 调整查询语句
        // ***********************************************************************
        /// <summary>
        /// 方法 调整查询语句
        /// 去除查询语句中的ORDER-BY字句，改用SortField代替排序
        /// </summary>
        /// <param name="addCustomSortInfo"></param>
        private void AdjustSelectCommand(bool addCustomSortInfo)
        {
            // 截去查询语句中的 orDER BY 子句
            string temp = SelectCommand.ToLower();
            int pos = temp.IndexOf("order by");
            if (pos > -1)
                SelectCommand = SelectCommand.Substring(0, pos);

            // 如果定义了SortField，则加上排序
            if (SortField != "" && addCustomSortInfo)
                SelectCommand += " orDER BY " + SortField;
        }
        // ***********************************************************************
        #endregion

        #region 方法 计算记录统计
        // ***********************************************************************
        /// <summary>
        /// 方法 计算记录统计
        /// 计算指定查询的记录及页面数
        /// </summary>
        /// <returns>记录统计</returns>
        private VirtualRecordCount CalculateVirtualRecordCount()
        {
            VirtualRecordCount count = new VirtualRecordCount();

            // 计算记录数
            count.RecordCount = GetQueryVirtualCount();
            count.RecordsInLastPage = ItemsPerPage;

            // 计算交互记录信息
            int lastPage = count.RecordCount / ItemsPerPage;
            int remainder = count.RecordCount % ItemsPerPage;
            if (remainder > 0)
                lastPage++;
            count.PageCount = lastPage;

            // 计算最后一页的记录数
            if (remainder > 0)
                count.RecordsInLastPage = remainder;
            return count;
        }
        // ***********************************************************************
        #endregion

        #region 方法 格式化查询语句
        // ***********************************************************************
        /// <summary>
        /// 方法 格式化查询语句
        /// </summary>
        /// <param name="countInfo">记录统计</param>
        /// <returns>command对象</returns>
        private SqlCommand PrepareCommand(VirtualRecordCount countInfo)
        {
            // 如排序字段没有定义
            if (SortField == "")
            {
                // Get metadata for all columns and choose either the primary key
                // or the 
                // 取得所有列的数据，并取任意一列数据为主键
                string text = "SET FMTONLY ON;" + SelectCommand + ";SET FMTONLY OFF;";
                SqlDataAdapter adapter = new SqlDataAdapter(text, ConnectionString);
                DataTable t = new DataTable();
                adapter.MissingSchemaAction = MissingSchemaAction.AddWithKey;
                adapter.Fill(t);
                DataColumn col = null;
                if (t.PrimaryKey.Length > 0)
                    col = t.PrimaryKey[0];
                else
                    col = t.Columns[0];
                SortField = col.ColumnName;
            }

            // 确定要得到多少条数据
            // 最后一页的数据不会多于前页
            int recsToRetrieve = ItemsPerPage;
            if (CurrentPageIndex == countInfo.PageCount - 1)
                recsToRetrieve = countInfo.RecordsInLastPage;

            string cmdText = String.Format(QueryPageCommandText,
            recsToRetrieve, // {0} --> page size
            ItemsPerPage * (CurrentPageIndex + 1), // {1} --> size * index
            SelectCommand, // {2} --> base query
            SortField, // {3} --> key field in the query
            SortMode, // {4} --> 排序模式
            AlterSortMode(SortMode));

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            return cmd;
        }

        // ***********************************************************************
        #endregion

        #region 方法 取得总记录条数
        // ***********************************************************************
        /// <summary>
        /// 方法 取得总记录条数
        /// </summary>
        /// <returns>总记录条数</returns>
        private int GetQueryVirtualCount()
        {
            string cmdText = String.Format(QueryCountCommandText, SelectCommand);
            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(cmdText, conn);

            cmd.Connection.Open();
            int recCount = (int)cmd.ExecuteScalar();
            cmd.Connection.Close();

            return recCount;
        }
        // ***********************************************************************
        #endregion

        #region 方法 跳转到指定页面
        // ***********************************************************************
        /// <summary>
        /// 方法 跳转到指定页面
        /// </summary>
        /// <param name="pageIndex">页面索引</param>
        private void GoToPage(int pageIndex)
        {
            // 准备事件数据
            PageChangedEventArgs e = new PageChangedEventArgs();
            e.OldPageIndex = CurrentPageIndex;
            e.NewPageIndex = pageIndex;

            // 更新当前页面索引
            CurrentPageIndex = pageIndex;

            // 触发页面改变事件
            OnPageIndexChanged(e);

            // 绑定新的数据
            DataBind();
        }
        // ***********************************************************************
        #endregion

        #region 方法 跳转到第一页
        // ***********************************************************************
        /// <summary>
        /// 方法 跳转到第一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void first_Click(object sender, EventArgs e)
        {
            GoToPage(0);
        }
        // ***********************************************************************
        #endregion

        #region 方法 跳转到前一页
        // ***********************************************************************
        /// <summary>
        /// 方法 跳转到前一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prev_Click(object sender, EventArgs e)
        {
            GoToPage(CurrentPageIndex - 1);
        }
        // ***********************************************************************
        #endregion

        #region 方法 跳转到后一页
        // ***********************************************************************
        /// <summary>
        /// 方法 跳转到后一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void next_Click(object sender, EventArgs e)
        {
            GoToPage(CurrentPageIndex + 1);
        }
        // ***********************************************************************
        #endregion

        #region 方法 跳转到最后一页
        // ***********************************************************************
        /// <summary>
        /// 方法 跳转到最后一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void last_Click(object sender, EventArgs e)
        {
            GoToPage(TotalPages - 1);
        }
        // ***********************************************************************
        #endregion

        #region 方法 页面索引选择列表点击
        // ***********************************************************************
        /// <summary>
        /// 方法 页面索引选择列表点击
        /// 通过下拉框选择页面索引
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PageList_Click(object sender, EventArgs e)
        {
            DropDownList pageList = (DropDownList)sender;
            int pageIndex = Convert.ToInt32(pageList.SelectedItem.Value);
            GoToPage(pageIndex);
        }
        // ***********************************************************************
        #endregion

        #region 方法 反转排序模式
        // ***********************************************************************
        /// <summary>
        /// 方法 反转排序模式
        /// </summary>
        /// <param name="mode">排序模式</param>
        /// <returns>相反的排序模式</returns>
        private SortMode AlterSortMode(SortMode mode)
        {
            if (mode == SortMode.DESC)
            {
                mode = SortMode.ASC;
            }
            else
            {
                mode = SortMode.DESC;
            }
            return mode;

        }
        // ***********************************************************************
        #endregion

        #region 方法 跳转到指定页面按钮点击
        // ***********************************************************************
        /// <summary>
        /// 方法 跳转到指定页面按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGo_Click(object sender, EventArgs e)
        {
            // bool isValidPage = (CurrentPageIndex >=0 && CurrentPageIndex < TotalPages);

            TextBox txbpage = (TextBox)FindControl("txbPage");
            if (txbpage.Text.Length > 0)
            {
                int page = Convert.ToInt32(txbpage.Text.Trim());

                bool isValidPage = (page - 1 >= 0 && page - 1 < TotalPages);
                if (isValidPage == true)
                {
                    GoToPage(page - 1);
                }
            }
        }
        // ***********************************************************************
        #endregion


        #endregion
    }
    #endregion
}
