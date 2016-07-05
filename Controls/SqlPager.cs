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
    #region ö�� ����ģʽ
    public enum PagingMode
    {
        //����
        Cached,
        //������
        NonCached
    }
    #endregion

    #region ö�� ��������ʽ
    public enum PagerStyle
    {
        Character,
        NextPrev,
        NumericPages
    }
    #endregion

    #region ö�� ����ģʽ
    public enum SortMode
    {
        ASC,
        DESC
    }
    #endregion

    #region �� ��¼ͳ��
    public class VirtualRecordCount
    {
        public int RecordCount;
        public int PageCount;
        //���һҳ�ļ�¼��
        public int RecordsInLastPage;
    }
    #endregion

    #region �� ҳ��ı��¼�����
    public class PageChangedEventArgs : EventArgs
    {
        public int OldPageIndex;
        public int NewPageIndex;
    }
    #endregion

    #region SqlPager��ҳ�ؼ�

    [DefaultProperty("SelectCommand")]
    [DefaultEvent("PageIndexChanged")]
    [ToolboxData("<{0}:SqlPager runat=\"server\" />")]
    public class SqlPager : WebControl, INamingContainer
    {
        #region ˽�г�Ա
        // ***********************************************************************
        // ˽�г�Ա

        //����Դ
        private PagedDataSource _dataSource;
        //��������
        private Control _controlToPaginate;
        private string CacheKeyName
        {
            get { return Page.Request.FilePath + "_" + UniqueID + "_Data"; }
        }
        //������ҳ����Ϣ��ʾ
        private string CurrentPageText = "��ǰ��<font color={0}>{1}</font>ҳ ����<font color={0}>{2}</font>ҳ �ܼ�<font color={0}>{3}</font>�� ÿҳ<font color={0}>{4}</font>��";
        //�������޼�¼��ʾ
        private string NoPageSelectedText = "û�м�¼��";
        //��ʽ��sql��ѯ���
        private string QueryPageCommandText = "Select * FROM " +
        "(Select TOP {0} * FROM " +
        "(Select TOP {1} * FROM ({2}) AS t0 orDER BY {3} {4}) AS t1 " +
        "ORDER BY {3} {5}) AS t2 " +
        "ORDER BY {3} {4}";
        //��ʽ��sql��¼ͳ�����
        private string QueryCountCommandText = "Select COUNT(*) FROM ({0}) AS t0";
        // ***********************************************************************
        #endregion

        #region ������
        // ***********************************************************************
        // ������
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

        #region ��������ӿ�


        #region ���� ��ջ���
        /// <summary>
        /// ���� ��ջ���
        /// </summary>
        public void ClearCache()
        {
            if (PagingMode == PagingMode.Cached)
                Page.Cache.Remove(CacheKeyName);
        }
        #endregion


        #region �¼� ҳ�������ı�
        // ***********************************************************************
        /// <summary>
        /// �¼� ҳ�������ı�
        /// ����ת����ҳ��ʱ����
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


        #region ���� �������ʱ��
        // ***********************************************************************
        // ���� �������ʱ��
        [Description("ȡ�û����������ڻ����б��������")]
        public int CacheDuration
        {
            get { return Convert.ToInt32(ViewState["CacheDuration"]); }
            set { ViewState["CacheDuration"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region ���� ����ģʽ
        // ***********************************************************************
        // ���� ����ģʽ
        [Description("ָ�������Ƿ���Ҫ��ҳ���ϻ���")]
        public PagingMode PagingMode
        {
            get { return (PagingMode)ViewState["PagingMode"]; }
            set { ViewState["PagingMode"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region ���� ��������ʽ
        // ***********************************************************************
        // ���� ��������ʽ
        [Description("ָ����������ʽ")]
        public PagerStyle PagerStyle
        {
            get { return (PagerStyle)ViewState["PagerStyle"]; }
            set { ViewState["PagerStyle"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region ���� ����ֵ��ɫ
        // ***********************************************************************
        // ���� ����ֵ��ɫ
        [Description("ָ������ֵ��ɫ")]
        public Color IndexColor
        {
            get { return (Color)ViewState["IndexColor"]; }
            set { ViewState["IndexColor"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region ���� ��������
        // ***********************************************************************
        // ���� ��������
        [Description("ȡ��������������������")]
        public string ControlToPaginate
        {
            get { return Convert.ToString(ViewState["ControlToPaginate"]); }
            set { ViewState["ControlToPaginate"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region ���� ÿҳ��¼��
        // ***********************************************************************
        // ���� ÿҳ��¼��
        [Description("ȡ������ÿҳ��ʾ�ļ�¼��")]
        public int ItemsPerPage
        {
            get { return Convert.ToInt32(ViewState["ItemsPerPage"]); }
            set { ViewState["ItemsPerPage"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region ���� ��ǰҳ����
        // ***********************************************************************
        // ���� ��ǰҳ����
        [Description("ȡ�����õ�ǰҳ������")]
        public int CurrentPageIndex
        {
            get { return Convert.ToInt32(ViewState["CurrentPageIndex"]); }
            set { ViewState["CurrentPageIndex"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region ���� �����ַ���
        // ***********************************************************************
        // ���� �����ַ���
        [Description("ȡ���������ݿ������ַ���")]
        public string ConnectionString
        {
            get { return Convert.ToString(ViewState["ConnectionString"]); }
            set { ViewState["ConnectionString"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region ���� ��ѯ���
        // ***********************************************************************
        // ���� ��ѯ���
        [Description("ȡ���������ݿ��ѯ���")]
        public string SelectCommand
        {
            get { return Convert.ToString(ViewState["SelectCommand"]); }
            set { ViewState["SelectCommand"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region ���� �����ֶ�
        // ***********************************************************************
        // ���� �����ֶ�
        [Description("ȡ�����������ֶΣ������޻����ģʽ�¿���")]
        public string SortField
        {
            get { return Convert.ToString(ViewState["SortKeyField"]); }
            set { ViewState["SortKeyField"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region ���� ��ҳ��
        // ***********************************************************************
        // ���� ��ҳ��
        // ȡ����ʾҳ�������
        [Browsable(false)]
        public int PageCount
        {
            get { return TotalPages; }
        }
        // ***********************************************************************
        #endregion

        #region ���� ��ҳ��
        // ***********************************************************************
        // ���� ��ҳ��
        // ȡ��������ʾҳ�������
        protected int TotalPages
        {
            get { return Convert.ToInt32(ViewState["TotalPages"]); }
            set { ViewState["TotalPages"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region ���� �ܼ�¼��
        // ***********************************************************************
        // ���� �ܼ�¼��
        // ȡ�������ܼ�¼��
        protected int TotalRecords
        {
            get { return Convert.ToInt32(ViewState["TotalRecords"]); }
            set { ViewState["TotalRecords"] = value; }
        }
        // ***********************************************************************
        #endregion

        #region ���� ����ģʽ
        // ***********************************************************************
        // ���� ����ģʽ
        [Description("ȡ����������ģʽ")]
        public SortMode SortMode
        {
            get { return (SortMode)ViewState["SortMode"]; }
            set { ViewState["SortMode"] = value; }
        }
        // ***********************************************************************
        #endregion


        #region ���� ���� ���ݰ�
        // ***********************************************************************
        // ���� �������ݰ�
        /// <summary>
        /// ȡ�ã��������
        /// </summary>
        public override void DataBind()
        {
            // �������ݰ��¼�
            base.DataBind();

            // �ؼ����������ݰ󶨺����´���
            ChildControlsCreated = false;

            // ȷ�������������ڲ���Ϊ�б�ؼ�(list control)
            if (ControlToPaginate == "")
                return;
            _controlToPaginate = Page.FindControl(ControlToPaginate);
            if (_controlToPaginate == null)
                return;
            if (!(_controlToPaginate is BaseDataList || _controlToPaginate is ListControl))
                return;

            // ȷ�����ݿ������ַ�����Ч�Ҳ�ѯ������ָ��
            if (ConnectionString == "" || SelectCommand == "")
                return;

            // ȡ������
            if (PagingMode == PagingMode.Cached)
                FetchAllData();
            else
            {
                //if (SortField == "")
                // return;
                FetchPageData();
            }

            // Bind data to the buddy control
            // �����ݵ���������
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

        #region ���� ���� ��������
        // ***********************************************************************
        // ���� ���� ��������
        // ���������ݴ��ݵ��ͻ���
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

        #region ���� ���� �����ӿؼ�
        // ***********************************************************************
        // ���� ���� �����ӿؼ�
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

        #region ˽�з���

        #region ���� ����������
        // ***********************************************************************
        // ���� ����������
        private void BuildControlHierarchy()
        {
            // ���������1��2��
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

            // �����
            TableRow row = new TableRow();
            t.Rows.Add(row);

            // ҳ��������Ԫ��
            TableCell cellPageDesc = new TableCell();
            cellPageDesc.HorizontalAlign = HorizontalAlign.Right;
            BuildCurrentPage(cellPageDesc);
            row.Cells.Add(cellPageDesc);

            // ������ť��Ԫ��
            TableCell cellNavBar = new TableCell();

            switch (PagerStyle)
            {
                //�ַ�������
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
            cellTip.Text = "��ת��";
            row.Cells.Add(cellTip);

            //��ת��ָ��ҳ�����Ͱ�ť
            TableCell cellGotoPage = new TableCell();
            BuildGotoPage(cellGotoPage);
            row.Cells.Add(cellGotoPage);

            // �ѱ����뵽�ؼ���
            Controls.Add(t);
        }
        // ***********************************************************************
        #endregion

        #region �����ַ�������
        /// <summary>
        /// �����ַ�������
        /// </summary>
        /// <param name="cell"></param>
        private void BuildCharacterUI(TableCell cell)
        {
            bool isValidPage = (CurrentPageIndex >= 0 && CurrentPageIndex <= TotalPages - 1);
            bool canMoveBack = (CurrentPageIndex > 0);
            bool canMoveForward = (CurrentPageIndex < TotalPages - 1);

            //������ҳ��ťʽ��
            LinkButton first = new LinkButton();
            first.ID = "First";
            first.CausesValidation = false;
            first.Click += new EventHandler(first_Click);
            first.ToolTip = "��ҳ";
            first.Text = "��ҳ";
            first.Enabled = isValidPage && canMoveBack;
            cell.Controls.Add(first);

            //�ӿո�
            cell.Controls.Add(new LiteralControl(" "));

            //����ǰҳ��ťʽ��
            LinkButton prev = new LinkButton();
            prev.ID = "Prev";
            prev.CausesValidation = false;
            prev.Click += new EventHandler(prev_Click);
            prev.ToolTip = "ǰҳ";
            prev.Text = "ǰҳ";
            prev.Enabled = isValidPage && canMoveBack;
            cell.Controls.Add(prev);

            //�ӿո�
            cell.Controls.Add(new LiteralControl(" "));

            //�����ҳ��ťʽ��
            LinkButton next = new LinkButton();
            next.ID = "Next";
            next.CausesValidation = false;
            next.Click += new EventHandler(next_Click);
            next.ToolTip = "��ҳ";
            next.Text = "��ҳ";
            next.Enabled = isValidPage && canMoveForward;
            cell.Controls.Add(next);

            //�ӿո�
            cell.Controls.Add(new LiteralControl(" "));

            //����βҳ��ťʽ��
            LinkButton last = new LinkButton();
            last.ID = "Last";
            last.CausesValidation = false;
            last.Click += new EventHandler(last_Click);
            last.ToolTip = "βҳ";
            last.Text = "βҳ";
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

        #region ���� ������ת��ָ��ҳ��
        // ***********************************************************************
        // ���� ������ת��ָ��ҳ��
        private void BuildGotoPage(TableCell cell)
        {
            // bool isValidPage = (CurrentPageIndex >=0 && CurrentPageIndex <= TotalPages-1);

            //��ת��ҳ�����������
            TextBox txbPage = new TextBox();
            txbPage.ID = "txbPage";
            txbPage.Width = 50;
            txbPage.MaxLength = 5;
            cell.Controls.Add(txbPage);

            //�ӿո�
            cell.Controls.Add(new LiteralControl(" "));

            //��ת����ť
            Button btnGo = new Button();
            btnGo.ID = "btnGo";
            btnGo.Text = "ȷ��";
            btnGo.BorderStyle = BorderStyle.Ridge;
            btnGo.BorderWidth = 1;
            btnGo.CausesValidation = false;
            btnGo.Click += new EventHandler(btnGo_Click);
            // btnGo.Enabled = isValidPage;
            cell.Controls.Add(btnGo);

        }
        // ***********************************************************************
        #endregion

        #region ���� ��ǰҳ����
        // ***********************************************************************
        // ���� ��ǰҳ����
        // ��0��ʼ
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

        #region ���� ��֤��ǰҳ�������Ƿ���Ч
        // ***********************************************************************
        /// <summary>
        /// ���� ��֤�����Ƿ���Ч
        /// ȷ����ǰҳ��������Χ:[0,TotalPages) or -1
        /// </summary>
        private void ValidatePageIndex()
        {
            //�����ǰҳ��¼ɾ��������ǰһҳ
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

        #region ���� ��ȡȫ������
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

        #region ���� ��ȡ��ǰҳ������
        // ***********************************************************************
        /// <summary>
        /// ���� ��ȡ��ǰҳ������
        /// </summary>
        private void FetchPageData()
        {
            // ������һ����Ч��ҳ������
            // ����Ҫ����ҳ���¼ͳ������֤ҳ������
            AdjustSelectCommand(false);
            VirtualRecordCount countInfo = CalculateVirtualRecordCount();
            TotalPages = countInfo.PageCount;
            TotalRecords = countInfo.RecordCount;

            // ��֤ҳ������ֵ����Ч�ԣ���ǰҳ������������Ч��Ϊ��1��
            ValidatePageIndex();
            if (CurrentPageIndex == -1)
            {
                CurrentPageIndex = 0;
                // return;
            }

            // ׼�����������ݿ��ѯ
            SqlCommand cmd = PrepareCommand(countInfo);
            if (cmd == null)
                return;
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable data = new DataTable();
            adapter.Fill(data);

            // ���÷�ҳ����Դ���
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

        #region ���� ������ѯ���
        // ***********************************************************************
        /// <summary>
        /// ���� ������ѯ���
        /// ȥ����ѯ����е�ORDER-BY�־䣬����SortField��������
        /// </summary>
        /// <param name="addCustomSortInfo"></param>
        private void AdjustSelectCommand(bool addCustomSortInfo)
        {
            // ��ȥ��ѯ����е� orDER BY �Ӿ�
            string temp = SelectCommand.ToLower();
            int pos = temp.IndexOf("order by");
            if (pos > -1)
                SelectCommand = SelectCommand.Substring(0, pos);

            // ���������SortField�����������
            if (SortField != "" && addCustomSortInfo)
                SelectCommand += " orDER BY " + SortField;
        }
        // ***********************************************************************
        #endregion

        #region ���� �����¼ͳ��
        // ***********************************************************************
        /// <summary>
        /// ���� �����¼ͳ��
        /// ����ָ����ѯ�ļ�¼��ҳ����
        /// </summary>
        /// <returns>��¼ͳ��</returns>
        private VirtualRecordCount CalculateVirtualRecordCount()
        {
            VirtualRecordCount count = new VirtualRecordCount();

            // �����¼��
            count.RecordCount = GetQueryVirtualCount();
            count.RecordsInLastPage = ItemsPerPage;

            // ���㽻����¼��Ϣ
            int lastPage = count.RecordCount / ItemsPerPage;
            int remainder = count.RecordCount % ItemsPerPage;
            if (remainder > 0)
                lastPage++;
            count.PageCount = lastPage;

            // �������һҳ�ļ�¼��
            if (remainder > 0)
                count.RecordsInLastPage = remainder;
            return count;
        }
        // ***********************************************************************
        #endregion

        #region ���� ��ʽ����ѯ���
        // ***********************************************************************
        /// <summary>
        /// ���� ��ʽ����ѯ���
        /// </summary>
        /// <param name="countInfo">��¼ͳ��</param>
        /// <returns>command����</returns>
        private SqlCommand PrepareCommand(VirtualRecordCount countInfo)
        {
            // �������ֶ�û�ж���
            if (SortField == "")
            {
                // Get metadata for all columns and choose either the primary key
                // or the 
                // ȡ�������е����ݣ���ȡ����һ������Ϊ����
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

            // ȷ��Ҫ�õ�����������
            // ���һҳ�����ݲ������ǰҳ
            int recsToRetrieve = ItemsPerPage;
            if (CurrentPageIndex == countInfo.PageCount - 1)
                recsToRetrieve = countInfo.RecordsInLastPage;

            string cmdText = String.Format(QueryPageCommandText,
            recsToRetrieve, // {0} --> page size
            ItemsPerPage * (CurrentPageIndex + 1), // {1} --> size * index
            SelectCommand, // {2} --> base query
            SortField, // {3} --> key field in the query
            SortMode, // {4} --> ����ģʽ
            AlterSortMode(SortMode));

            SqlConnection conn = new SqlConnection(ConnectionString);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            return cmd;
        }

        // ***********************************************************************
        #endregion

        #region ���� ȡ���ܼ�¼����
        // ***********************************************************************
        /// <summary>
        /// ���� ȡ���ܼ�¼����
        /// </summary>
        /// <returns>�ܼ�¼����</returns>
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

        #region ���� ��ת��ָ��ҳ��
        // ***********************************************************************
        /// <summary>
        /// ���� ��ת��ָ��ҳ��
        /// </summary>
        /// <param name="pageIndex">ҳ������</param>
        private void GoToPage(int pageIndex)
        {
            // ׼���¼�����
            PageChangedEventArgs e = new PageChangedEventArgs();
            e.OldPageIndex = CurrentPageIndex;
            e.NewPageIndex = pageIndex;

            // ���µ�ǰҳ������
            CurrentPageIndex = pageIndex;

            // ����ҳ��ı��¼�
            OnPageIndexChanged(e);

            // ���µ�����
            DataBind();
        }
        // ***********************************************************************
        #endregion

        #region ���� ��ת����һҳ
        // ***********************************************************************
        /// <summary>
        /// ���� ��ת����һҳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void first_Click(object sender, EventArgs e)
        {
            GoToPage(0);
        }
        // ***********************************************************************
        #endregion

        #region ���� ��ת��ǰһҳ
        // ***********************************************************************
        /// <summary>
        /// ���� ��ת��ǰһҳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void prev_Click(object sender, EventArgs e)
        {
            GoToPage(CurrentPageIndex - 1);
        }
        // ***********************************************************************
        #endregion

        #region ���� ��ת����һҳ
        // ***********************************************************************
        /// <summary>
        /// ���� ��ת����һҳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void next_Click(object sender, EventArgs e)
        {
            GoToPage(CurrentPageIndex + 1);
        }
        // ***********************************************************************
        #endregion

        #region ���� ��ת�����һҳ
        // ***********************************************************************
        /// <summary>
        /// ���� ��ת�����һҳ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void last_Click(object sender, EventArgs e)
        {
            GoToPage(TotalPages - 1);
        }
        // ***********************************************************************
        #endregion

        #region ���� ҳ������ѡ���б���
        // ***********************************************************************
        /// <summary>
        /// ���� ҳ������ѡ���б���
        /// ͨ��������ѡ��ҳ������
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

        #region ���� ��ת����ģʽ
        // ***********************************************************************
        /// <summary>
        /// ���� ��ת����ģʽ
        /// </summary>
        /// <param name="mode">����ģʽ</param>
        /// <returns>�෴������ģʽ</returns>
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

        #region ���� ��ת��ָ��ҳ�水ť���
        // ***********************************************************************
        /// <summary>
        /// ���� ��ת��ָ��ҳ�水ť���
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
