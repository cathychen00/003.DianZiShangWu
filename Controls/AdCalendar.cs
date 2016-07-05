using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Image = System.Web.UI.WebControls.Image;

namespace Jiaen.Controls
{
    [
    DefaultEvent("DateChanged"),
    DefaultProperty("SelectedDate"),
    ValidationProperty("SelectedDateText"),
    ToolboxData("<{0}:AdCalendar runat=server></{0}:AdCalendar>")
    ]
    public class AdCalendar : WebControl, INamingContainer
    {
        #region 定义变量
        private static readonly object EventDateChanged = new object();
        private static string ClientFilesUrlPrefix = "ClientFiles\\";
        private TableStyle _calendarStyle;
        private Style _titleStyle;
        private Style _dayHeaderStyle;
        private Style _dayStyle;
        private Style _otherMonthDayStyle;
        private Style _todayDayStyle;
        private Style _selectedDayStyle;
        private TextBox _dateTextBox;
        private Image _errorImage;
        private RegularExpressionValidator _dateValidator;
        private bool _renderClientScript;
        private bool _renderPopupScript;
        #endregion

        #region 重写Controls属性
        public override ControlCollection Controls
        {
            get
            {
                EnsureChildControls();
                return base.Controls;
            }
        }
        #endregion

        #region 定义属性
        [
        Category("Behavior"),
        DefaultValue(false),
        Description("指示当用户更改内容时是否自动产生向服务器的回发.")
        ]
        public bool AutoPostBack
        {
            get
            {
                EnsureChildControls();
                return _dateTextBox.AutoPostBack;
            }
            set
            {
                EnsureChildControls();
                _dateTextBox.AutoPostBack = value;
            }
        }

        [
        Category("Appearance"),
        DefaultValue(0),
        Description("定义文本框可输入的字符长度.")
        ]
        public virtual int Columns
        {
            get
            {
                EnsureChildControls();
                return _dateTextBox.Columns;
            }
            set
            {
                EnsureChildControls();
                _dateTextBox.Columns = value;
            }
        }

        [
        Category("Behavior"),
        DefaultValue(true),
        Description("获取或设置一个值，该值指示是否启用客户端验证.")
        ]
        public bool EnableClientScript
        {
            get
            {
                object b = ViewState["EnableClientScript"];
                return (b == null) ? true : (bool)b;
            }
            set
            {
                ViewState["EnableClientScript"] = value;
            }
        }

        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)
        ]
        public virtual bool IsDateSelected
        {
            get
            {
                object d = ViewState["SelectedDate"];
                return (d != null);
            }
        }

        [
        Category("Behavior"),
        DefaultValue(false),
        Description("设置文本框是否为只读.")
        ]
        public virtual bool ReadOnly
        {
            get
            {
                EnsureChildControls();
                return _dateTextBox.ReadOnly;
            }
            set
            {
                EnsureChildControls();
                _dateTextBox.ReadOnly = value;
            }
        }

        [
        Bindable(true),
        Category("Default"),
        Description("设定文本框中的自定义日期.")
        ]
        public virtual DateTime SelectedDate
        {
            get
            {
                object d = ViewState["SelectedDate"];
                return (d == null) ? DateTime.Today : (DateTime)d;
            }
            set
            {
                ViewState["SelectedDate"] = value;

                EnsureChildControls();
                _dateTextBox.Text = SelectedDateText;
            }
        }

        [
        Browsable(false),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden),
        EditorBrowsable(EditorBrowsableState.Never)
        ]
        public string SelectedDateText
        {
            get
            {
                if (IsDateSelected)
                {
                    return String.Format(CultureInfo.InvariantCulture, "{0:d}", new object[] { SelectedDate });
                }
                return String.Empty;
            }
        }

        [
        Category("Appearance"),
        DefaultValue(""),
        Description("验证错误提示信息.")
        ]
        public virtual string ValidationMessage
        {
            get
            {
                string s = (string)ViewState["ValidationMessage"];
                return (s == null) ? String.Empty : s;
            }
            set
            {
                ViewState["ValidationMessage"] = value;
            }
        }

        [
        Category("Style"),
        Description("定义日历样式."),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        NotifyParentProperty(true),
        PersistenceMode(PersistenceMode.InnerProperty)
        ]
        public virtual TableStyle CalendarStyle
        {
            get
            {
                if (_calendarStyle == null)
                {
                    _calendarStyle = new TableStyle();
                    if (IsTrackingViewState)
                    {
                        ((IStateManager)_calendarStyle).TrackViewState();
                    }
                }
                return _calendarStyle;
            }
        }

        [
        Category("Style"),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        Description("定义上部表示星期的样式."),
        NotifyParentProperty(true),
        PersistenceMode(PersistenceMode.InnerProperty)
        ]
        public virtual Style DayHeaderStyle
        {
            get
            {
                if (_dayHeaderStyle == null)
                {
                    _dayHeaderStyle = new Style();
                    if (IsTrackingViewState)
                    {
                        ((IStateManager)_dayHeaderStyle).TrackViewState();
                    }
                }
                return _dayHeaderStyle;
            }
        }

        [
        Category("Style"),
        Description("定义日历中日期的样式."),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        NotifyParentProperty(true),
        PersistenceMode(PersistenceMode.InnerProperty)
        ]
        public virtual Style DayStyle
        {
            get
            {
                if (_dayStyle == null)
                {
                    _dayStyle = new Style();
                    if (IsTrackingViewState)
                    {
                        ((IStateManager)_dayStyle).TrackViewState();
                    }
                }
                return _dayStyle;
            }
        }

        [
        Category("Style"),
        Description("定义当月以外显示的日期的样式."),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        NotifyParentProperty(true),
        PersistenceMode(PersistenceMode.InnerProperty)
        ]
        public virtual Style OtherMonthDayStyle
        {
            get
            {
                if (_otherMonthDayStyle == null)
                {
                    _otherMonthDayStyle = new Style();
                    if (IsTrackingViewState)
                    {
                        ((IStateManager)_otherMonthDayStyle).TrackViewState();
                    }
                }
                return _otherMonthDayStyle;
            }
        }

        [
        Category("Style"),
        Description("设置当前选中日期的样式."),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        NotifyParentProperty(true),
        PersistenceMode(PersistenceMode.InnerProperty)
        ]
        public virtual Style SelectedDayStyle
        {
            get
            {
                if (_selectedDayStyle == null)
                {
                    _selectedDayStyle = new Style();
                    if (IsTrackingViewState)
                    {
                        ((IStateManager)_selectedDayStyle).TrackViewState();
                    }
                }
                return _selectedDayStyle;
            }
        }

        [
        Category("Style"),
        Description("设置日历头部样式."),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        NotifyParentProperty(true),
        PersistenceMode(PersistenceMode.InnerProperty)
        ]
        public virtual Style TitleStyle
        {
            get
            {
                if (_titleStyle == null)
                {
                    _titleStyle = new Style();
                    if (IsTrackingViewState)
                    {
                        ((IStateManager)_titleStyle).TrackViewState();
                    }
                }
                return _titleStyle;
            }
        }

        [
        Category("Style"),
        Description("定义当前日期的样式."),
        DesignerSerializationVisibility(DesignerSerializationVisibility.Content),
        NotifyParentProperty(true),
        PersistenceMode(PersistenceMode.InnerProperty)
        ]
        public virtual Style TodayDayStyle
        {
            get
            {
                if (_todayDayStyle == null)
                {
                    _todayDayStyle = new Style();
                    if (IsTrackingViewState)
                    {
                        ((IStateManager)_todayDayStyle).TrackViewState();
                    }
                }
                return _todayDayStyle;
            }
        }

        [
        Category("Appearance"),
        Description("客户端文件的相对路径."),
        DefaultValue("ClientFiles\\")
        ]
        public string ClientFilesUrl
        {
            get
            {
                return ClientFilesUrlPrefix;
            }
            set
            {
                ClientFilesUrlPrefix = value;
            }
        }
        #endregion

        #region 定义事件
        [
        Category("Change"),
        Description("为DateChanged定义事件属性.")
        ]
        public event EventHandler DateChanged
        {
            add
            {
                Events.AddHandler(EventDateChanged, value);
            }
            remove
            {
                Events.RemoveHandler(EventDateChanged, value);
            }
        }

        private void dateTextBox_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string text = _dateTextBox.Text.Trim();
                DateTime date = DateTime.Parse(text, CultureInfo.InvariantCulture);

                if ((IsDateSelected == false) || !(date.Equals(SelectedDate)))
                {
                    SelectedDate = date;
                    OnDateChanged(EventArgs.Empty);
                }
            }
            catch
            {
                ViewState.Remove("SelectedDate");
            }
        }

        protected virtual void OnDateChanged(EventArgs e)
        {
            EventHandler handler = (EventHandler)Events[EventDateChanged];
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion

        #region 定义呈现
        protected override void AddAttributesToRender(HtmlTextWriter writer)
        {
            writer.AddAttribute(HtmlTextWriterAttribute.Id, ClientID);

            if (_renderClientScript)
            {
                if (_renderPopupScript)
                {
                    writer.AddAttribute("dp_htcURL", GetClientFileUrl("Calendar.htc"), false);
                }
                if (AutoPostBack)
                {
                    writer.AddAttribute("dp_autoPostBack", "true", false);
                }
                if (_calendarStyle != null)
                {
                    Unit u = _calendarStyle.Width;
                    if (!u.IsEmpty)
                    {
                        writer.AddAttribute("dp_width", u.ToString(CultureInfo.InvariantCulture));
                    }
                    u = _calendarStyle.Height;
                    if (!u.IsEmpty)
                    {
                        writer.AddAttribute("dp_height", u.ToString(CultureInfo.InvariantCulture));
                    }
                    string s = GetCssFromStyle(_calendarStyle);
                    if (s.Length != 0)
                    {
                        writer.AddAttribute("dp_calendarStyle", s, false);
                    }
                }
                if (_titleStyle != null)
                {
                    string s = GetCssFromStyle(_titleStyle);
                    if (s.Length != 0)
                    {
                        writer.AddAttribute("dp_titleStyle", s, false);
                    }
                }
                if (_dayHeaderStyle != null)
                {
                    string s = GetCssFromStyle(_dayHeaderStyle);
                    if (s.Length != 0)
                    {
                        writer.AddAttribute("dp_dayHeaderStyle", s, false);
                    }
                }
                if (_dayStyle != null)
                {
                    string s = GetCssFromStyle(_dayStyle);
                    if (s.Length != 0)
                    {
                        writer.AddAttribute("dp_dayStyle", s, false);
                    }
                }
                if (_otherMonthDayStyle != null)
                {
                    string s = GetCssFromStyle(_otherMonthDayStyle);
                    if (s.Length != 0)
                    {
                        writer.AddAttribute("dp_otherMonthDayStyle", s, false);
                    }
                }
                if (_todayDayStyle != null)
                {
                    string s = GetCssFromStyle(_todayDayStyle);
                    if (s.Length != 0)
                    {
                        writer.AddAttribute("dp_todayDayStyle", s, false);
                    }
                }
                if (_selectedDayStyle != null)
                {
                    string s = GetCssFromStyle(_selectedDayStyle);
                    if (s.Length != 0)
                    {
                        writer.AddAttribute("dp_selectedDayStyle", s, false);
                    }
                }
            }
        }

        protected override void CreateChildControls()
        {
            _dateTextBox = new TextBox();
            _errorImage = new Image();
            _dateValidator = new RegularExpressionValidator();

            _dateTextBox.ID = "dateTextBox";
            _dateTextBox.MaxLength = 10;
            _dateTextBox.TextChanged += new EventHandler(this.dateTextBox_TextChanged);

            _errorImage.EnableViewState = false;
            _errorImage.ImageUrl = GetClientFileUrl("Error.gif");
            _errorImage.ImageAlign = ImageAlign.AbsMiddle;
            _errorImage.Width = new Unit(16);
            _errorImage.Height = new Unit(16);

            _dateValidator.EnableViewState = false;
            _dateValidator.ControlToValidate = "dateTextBox";
            _dateValidator.ValidationExpression = "^\\s*(\\d{1,2})([-./])(\\d{1,2})\\2((\\d{4})|(\\d{2}))\\s*$";
            _dateValidator.Display = ValidatorDisplay.Dynamic;
            _dateValidator.Controls.Add(_errorImage);

            Controls.Add(_dateTextBox);
            Controls.Add(_dateValidator);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

            DetermineClientScriptLevel();
            if (_renderClientScript)
            {
                Page.RegisterClientScriptBlock(typeof(AdCalendar).FullName, GetClientScriptInclude("DatePicker.js"));
            }
            _dateValidator.EnableClientScript = EnableClientScript;
        }

        protected override void Render(HtmlTextWriter writer)
        {
            if (Page != null)
            {
                Page.VerifyRenderingInServerForm(this);
            }
            base.Render(writer);
        }

        protected override void RenderContents(HtmlTextWriter writer)
        {
            writer.Write("<STYLE type=text/css>");
            writer.Write(".DateEditStyle {BORDER-RIGHT: #404040 1px solid; BORDER-TOP: #f0f0f0 1px solid; FONT-SIZE: 1pt; BORDER-LEFT: #f0f0f0 1px solid; BORDER-BOTTOM: #404040 1px solid; BACKGROUND-COLOR: buttonface}");
            writer.Write("</STYLE>");
            writer.Write("<TABLE height=20 cellSpacing=0 cellPadding=0>");
            writer.Write("<TR><TD>");

            if (ControlStyleCreated)
            {
                _dateTextBox.ApplyStyle(ControlStyle);
            }
            _dateTextBox.CopyBaseAttributes(this);
            _dateTextBox.RenderControl(writer);

            writer.Write("</TD>");
            writer.Write("<TD width=15 height=20>");
            writer.Write("<TABLE height=20 cellSpacing=0 cellPadding=0 width=15 border=0>");
            writer.Write("<TR><TD onclick='UpArrowClick(" + _dateTextBox.ClientID + ")'" + " class=DateEditStyle vAlign=center align=middle>");
            writer.Write("<TABLE style='FONT-SIZE: 1px; CURSOR: default; LINE-HEIGHT: 0; FONT-FAMILY: arial' cellSpacing=0 cellPadding=0>");
            writer.Write("<TR><TD>&nbsp;</TD><TD>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD>&nbsp;</TD><TD>&nbsp;</TD></TR>");
            writer.Write("<TR><TD>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD>&nbsp;</TD></TR>");
            writer.Write("<TR><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD></TR>");
            writer.Write("</TABLE>");
            writer.Write("</TD></TR>");
            writer.Write("<TR><TD onclick='DownArrowClick(" + _dateTextBox.ClientID + ")'" + " class=DateEditStyle vAlign=center align=middle>");
            writer.Write("<TABLE style='FONT-SIZE: 1px; CURSOR: default; LINE-HEIGHT: 0; FONT-FAMILY: arial' cellSpacing=0 cellPadding=0>");
            writer.Write("<TR><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD></TR>");
            writer.Write("<TR><TD>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD>&nbsp;</TD></TR>");
            writer.Write("<TR><TD>&nbsp;</TD><TD>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD>&nbsp;</TD><TD>&nbsp;</TD></TR>");
            writer.Write("</TABLE>");
            writer.Write("</TD></TR>");
            writer.Write("</TABLE>");
            writer.Write("</TD>");
            writer.AddAttribute("class", "DateEditStyle");
            writer.AddAttribute("vAlign", "center");
            writer.AddAttribute("align", "middle");
            writer.AddAttribute("width", "12");
            string clickEvent = "dp_showDatePickerPopup(this, document.all['" + _dateTextBox.ClientID + "'], document.all['" + ClientID + "'])";
            writer.AddAttribute("onclick", clickEvent);
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            writer.Write("<TABLE style='FONT-SIZE: 1px; CURSOR: default; LINE-HEIGHT: 0; FONT-FAMILY: arial' cellSpacing=0 cellPadding=0>");
            writer.Write("<TR><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD></TR>");
            writer.Write("<TR><TD>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD>&nbsp;</TD></TR>");
            writer.Write("<TR><TD>&nbsp;</TD><TD>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD>&nbsp;</TD><TD>&nbsp;</TD></TR>");
            writer.Write("<TR><TD>&nbsp;</TD><TD>&nbsp;</TD><TD>&nbsp;</TD><TD bgColor=buttontext>&nbsp;</TD><TD>&nbsp;</TD><TD>&nbsp;</TD><TD>&nbsp;</TD></TR>");
            writer.Write("</TABLE>");
            writer.RenderEndTag();
            writer.Write("<TD>");

            bool designMode = (Site != null) && Site.DesignMode;

            bool showPicker = _renderClientScript;
            if (showPicker == false)
            {
                if (EnableClientScript && designMode)
                {
                    showPicker = true;
                }
            }
            if (showPicker)
            {
                string pickerAction;
                if (_renderPopupScript)
                {
                    pickerAction = "dp_showDatePickerPopup(this, document.all['" + _dateTextBox.ClientID + "'], document.all['" + ClientID + "'])";
                }
                else
                {
                    pickerAction = "dp_showDatePickerFrame(this, document.all['" + _dateTextBox.ClientID + "'], document.all['" + ClientID + "'], document.all['" + ClientID + "_frame'], document)";
                }
                if (_renderPopupScript == false)
                {
                    writer.AddAttribute(HtmlTextWriterAttribute.Id, ClientID + "_frame");
                    writer.AddAttribute(HtmlTextWriterAttribute.Src, GetClientFileUrl("CalendarFrame.htm"));
                    writer.AddAttribute("marginheight", "0", false);
                    writer.AddAttribute("marginwidth", "0", false);
                    writer.AddAttribute("noresize", "noresize", false);
                    writer.AddAttribute("frameborder", "0", false);
                    writer.AddAttribute("scrolling", "no", false);
                    writer.AddStyleAttribute("position", "absolute");
                    writer.AddStyleAttribute("z-index", "100");
                    writer.AddStyleAttribute("display", "none");
                    writer.RenderBeginTag(HtmlTextWriterTag.Iframe);
                    writer.RenderEndTag();
                }
            }

            if (_dateValidator.Visible)
            {
                _dateValidator.ErrorMessage = ValidationMessage;
                _dateValidator.ToolTip = ValidationMessage;
                _dateValidator.RenderControl(writer);
            }
            writer.Write("</TD>");
            writer.Write("</TR></TABLE>");
        }

        #region 辅助方法
        private void DetermineClientScriptLevel()
        {
            _renderClientScript = false;
            _renderPopupScript = false;

            if ((Page != null) && (Page.Request != null))
            {
                if (EnableClientScript)
                {
                    HttpBrowserCapabilities browserCaps = Page.Request.Browser;
                    bool hasEcmaScript = (browserCaps.EcmaScriptVersion.CompareTo(new Version(1, 2)) >= 0);
                    bool hasDOM = (browserCaps.MSDomVersion.Major >= 4);
                    bool hasBehaviors = (browserCaps.MajorVersion > 5) ||
                        ((browserCaps.MajorVersion == 5) && (browserCaps.MinorVersion >= .5));

                    _renderClientScript = hasEcmaScript && hasDOM;
                    _renderPopupScript = _renderClientScript && hasBehaviors;
                }
            }
        }

        private string GetClientFileUrl(string fileName)
        {
            return (ClientFilesUrl + fileName);
        }

        private string GetClientScriptInclude(string scriptFile)
        {
            return "<script language=\"JavaScript\" src=\"" + GetClientFileUrl(scriptFile) + "\"></script>";
        }

        private string GetCssFromStyle(Style style)
        {
            StringBuilder sb = new StringBuilder(256);
            Color c;

            c = style.ForeColor;
            if (!c.IsEmpty)
            {
                sb.Append("color:");
                sb.Append(ColorTranslator.ToHtml(c));
                sb.Append(";");
            }
            c = style.BackColor;
            if (!c.IsEmpty)
            {
                sb.Append("background-color:");
                sb.Append(ColorTranslator.ToHtml(c));
                sb.Append(";");
            }

            FontInfo fi = style.Font;
            string s;

            s = fi.Name;
            if (s.Length != 0)
            {
                sb.Append("font-family:'");
                sb.Append(s);
                sb.Append("';");
            }
            if (fi.Bold)
            {
                sb.Append("font-weight:bold;");
            }
            if (fi.Italic)
            {
                sb.Append("font-style:italic;");
            }

            s = String.Empty;
            if (fi.Underline)
                s += "underline";
            if (fi.Strikeout)
                s += " line-through";
            if (fi.Overline)
                s += " overline";
            if (s.Length != 0)
            {
                sb.Append("text-decoration:");
                sb.Append(s);
                sb.Append(';');
            }

            FontUnit fu = fi.Size;
            if (fu.IsEmpty == false)
            {
                sb.Append("font-size:");
                sb.Append(fu.ToString(CultureInfo.InvariantCulture));
                sb.Append(';');
            }

            s = String.Empty;
            Unit u = style.BorderWidth;
            BorderStyle bs = style.BorderStyle;
            if (u.IsEmpty == false)
            {
                s = u.ToString(CultureInfo.InvariantCulture);
                if (bs == BorderStyle.NotSet)
                {
                    s += " solid";
                }
            }
            c = style.BorderColor;
            if (!c.IsEmpty)
            {
                s += " " + ColorTranslator.ToHtml(c);
            }
            if (bs != BorderStyle.NotSet)
            {
                s += " " + Enum.Format(typeof(BorderStyle), bs, "G");
            }
            if (s.Length != 0)
            {
                sb.Append("border:");
                sb.Append(s);
                sb.Append(';');
            }

            return sb.ToString();
        }

        #endregion
        #endregion

        #region 定义复杂样式属性的视图状态管理
        protected override void LoadViewState(object savedState)
        {
            object baseState = null;
            object[] myState = null;

            if (savedState != null)
            {
                myState = (object[])savedState;
                if (myState.Length != 8)
                {
                    throw new ArgumentException("Invalid view state");
                }

                baseState = myState[0];
            }

            base.LoadViewState(baseState);

            if (myState == null)
            {
                return;
            }

            if (myState[1] != null)
                ((IStateManager)CalendarStyle).LoadViewState(myState[1]);
            if (myState[2] != null)
                ((IStateManager)TitleStyle).LoadViewState(myState[1]);
            if (myState[3] != null)
                ((IStateManager)DayHeaderStyle).LoadViewState(myState[1]);
            if (myState[4] != null)
                ((IStateManager)DayStyle).LoadViewState(myState[1]);
            if (myState[5] != null)
                ((IStateManager)OtherMonthDayStyle).LoadViewState(myState[1]);
            if (myState[6] != null)
                ((IStateManager)TodayDayStyle).LoadViewState(myState[1]);
            if (myState[7] != null)
                ((IStateManager)SelectedDayStyle).LoadViewState(myState[1]);
        }

        protected override object SaveViewState()
        {
            object[] myState = new object[8];

            myState[0] = base.SaveViewState();
            myState[1] = (_calendarStyle != null) ? ((IStateManager)_calendarStyle).SaveViewState() : null;
            myState[2] = (_titleStyle != null) ? ((IStateManager)_titleStyle).SaveViewState() : null;
            myState[3] = (_dayHeaderStyle != null) ? ((IStateManager)_dayHeaderStyle).SaveViewState() : null;
            myState[4] = (_dayStyle != null) ? ((IStateManager)_dayStyle).SaveViewState() : null;
            myState[5] = (_otherMonthDayStyle != null) ? ((IStateManager)_otherMonthDayStyle).SaveViewState() : null;
            myState[6] = (_todayDayStyle != null) ? ((IStateManager)_todayDayStyle).SaveViewState() : null;
            myState[7] = (_selectedDayStyle != null) ? ((IStateManager)_selectedDayStyle).SaveViewState() : null;

            for (int i = 0; i < 8; i++)
            {
                if (myState[i] != null)
                {
                    return myState;
                }
            }
            return null;
        }

        protected override void TrackViewState()
        {
            base.TrackViewState();

            if (_calendarStyle != null)
                ((IStateManager)_calendarStyle).TrackViewState();
            if (_titleStyle != null)
                ((IStateManager)_titleStyle).TrackViewState();
            if (_dayHeaderStyle != null)
                ((IStateManager)_dayHeaderStyle).TrackViewState();
            if (_dayStyle != null)
                ((IStateManager)_dayStyle).TrackViewState();
            if (_otherMonthDayStyle != null)
                ((IStateManager)_otherMonthDayStyle).TrackViewState();
            if (_todayDayStyle != null)
                ((IStateManager)_todayDayStyle).TrackViewState();
            if (_selectedDayStyle != null)
                ((IStateManager)_selectedDayStyle).TrackViewState();
        }
        #endregion

        protected override void AddParsedSubObject(object o)
        {
            throw new Exception("Cannot add child objects declaratively.");
        }
    }
}
