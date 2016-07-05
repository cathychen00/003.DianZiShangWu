using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Collections.Specialized;

namespace TW.Web.UI
{
    public class ValidateCodeControl : WebControl, IDisposable, IPostBackDataHandler
    {
        #region 定义变量

        #region 控件变量
        private TextBox txbValidateCodeInput;
        private Image imgValidateCodeImage;
        private HyperLink linkRefreshValidateCode;
        #endregion

        #region JS
        private const string VALIDATE_CODE_REFRESH_SCRIPT =
@"<script language='javascript'>
function refreshValidateCodeImage(ValidateCodeImageControl, NewUrl)
{
    //window.alert('a');
    ValidateCodeImageControl.src = NewUrl + '?code=' + randomNum(10);
}
function randomNum(n){ 
    var rnd=''; 
    for(var i=0;i<n;i++)
         rnd+=Math.floor(Math.random()*10);
    return rnd;
}
</script>";

        private const string VALIDATE_CODE_REFRESH_SCRIPT_ID = "1382a047-3f1d-4d12-8e19-6f698c81d7cd";
        private const string VALIDATE_CODE_REFRESH_HOOK = "refreshValidateCodeImage({0}, {1});";
        #endregion

        /// <summary>
        /// 验证码Session的名称
        /// </summary>
        private string strValidateCodeSessionName = "ValidateCodeSession";

        private string _strValidateCodeUserInput = string.Empty;

        #endregion

        #region 公共属性
        /// <summary>
        /// 读取或设置验证码输入文本框的CSS样式
        /// </summary>
        /// <value>置验证码输入文本框的CSS样式</value>
        [Description("读取或设置验证码输入文本框的CSS样式"), Category("外观"), DefaultValue("")]
        public string TextBoxCSSClass
        {
            get
            {
                object objValidateCodeInputTextBoxCSSClass = ViewState["ValidateCodeInputTextBoxCSSClass"];
                return objValidateCodeInputTextBoxCSSClass == null ? "" : objValidateCodeInputTextBoxCSSClass.ToString();
            }
            set
            {
                ViewState["ValidateCodeInputTextBoxCSSClass"] = value;
            }
        }

        /// <summary>
        /// 读取或设置验证码的CSS样式
        /// </summary>
        [Description("读取或设置验证码的CSS样式"), Category("外观"), DefaultValue("")]
        public string ImageCSSClass
        {
            get
            {
                object objValidateCodeImageCSSClass = ViewState["ValidateCodeImageCSSClass"];
                return objValidateCodeImageCSSClass == null ? "" : objValidateCodeImageCSSClass.ToString();
            }
            set
            {
                ViewState["ValidateCodeImageCSSClass"] = value;
            }
        }

        /// <summary>
        /// 读取或设置刷新链接的CSS样式.
        /// </summary>
        [Description("读取或设置刷新链接的CSS样式"), Category("外观"), DefaultValue("")]
        public string RefreshLinkCSSClass
        {
            get
            {
                object objValidateCodeRefreshCSSClass = ViewState["ValidateCodeRefreshCSSClass"];
                return objValidateCodeRefreshCSSClass == null ? "" : objValidateCodeRefreshCSSClass.ToString();
            }
            set
            {

                ViewState["ValidateCodeRefreshCSSClass"] = value;
            }
        }

        /// <summary>
        /// 读取或设置是否不区分大小写。
        /// </summary>
        [Description("读取或设置是否不区分大小写。"), Category("行为"), DefaultValue(true)]
        public bool IgnoreCase
        {
            get
            {
                object objIgnoreCase = ViewState["IgnoreCase"];
                return objIgnoreCase == null ? true : (bool)objIgnoreCase;
            }
            set
            {
                ViewState["IgnoreCase"] = value;
            }
        }


        /// <summary>
        /// 读取或设置验证码图片地址
        /// </summary>
        /// <value>The image page URL.</value>
        [Description("读取或设置验证码图片地址"), Category("行为"), DefaultValue("./TW_Client/ValidateCode/TW.ValidateCode.aspx")]
        public string ImagePageUrl
        {
            get
            {
                object objValidateCodeImagePageUrl = ViewState["ValidateCodeImagePageUrl"];
                return objValidateCodeImagePageUrl == null ? "./TW_Client/ValidateCode/TW.ValidateCode.aspx" : objValidateCodeImagePageUrl.ToString();
            }
            set
            {
                ViewState["ValidateCodeImagePageUrl"] = value;
            }
        }

        /// <summary>
        /// 读取或设置刷新验证码的链接文字
        /// </summary>
        /// <value>The refresh link text.</value>
        [Description("读取或设置刷新验证码的链接文字"), Category("行为"), DefaultValue("刷新验证码")]
        public string RefreshLinkText
        {
            get
            {
                object objValidateCodeRefreshText = ViewState["ValidateCodeRefreshText"];
                return objValidateCodeRefreshText == null ? "刷新验证码" : objValidateCodeRefreshText.ToString();
            }
            set
            {
                ViewState["ValidateCodeRefreshText"] = value;
            }
        }

        /// <summary>
        /// 读取或设置验证码Session保存的名称，如果不设置则默认为ValidateCodeSession。
        /// 注意：必须和ValidateCodeImage里的ValidateCodeSessionName保持一致，否则会出现错误。
        /// </summary>
        /// <value>The name of the validate code session.</value>
        [Description("读取或设置验证码Session保存的名称，如果不设置则默认为ValidateCodeSession。注意：必须和ValidateCodeImage里的ValidateCodeSessionName保持一致，否则会出现错误。"), DefaultValue("ValidateCodeSession")]
        public string ValidateCodeSessionName
        {
            get
            {
                return strValidateCodeSessionName;
            }
            set
            {
                strValidateCodeSessionName = value;
            }
        }

        /// <summary>
        /// 获取用户输入的验证码
        /// </summary>
        /// <value>The validate code user input.</value>
        [Browsable(false)]
        public string ValidateCodeUserInput
        {
            get
            {
                return _strValidateCodeUserInput;
            }
        }
        #endregion

        #region 重写的属性
        /// <summary>
        /// 获取与此 Web 服务器控件相对应的 <see cref="T:System.Web.UI.HtmlTextWriterTag"></see> 值。此属性主要由控件开发人员使用。
        /// </summary>
        /// <value></value>
        /// <returns><see cref="T:System.Web.UI.HtmlTextWriterTag"></see> 枚举值之一。</returns>
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Table;
            }
        }
        #endregion

        #region 构造函数
        public ValidateCodeControl()
            : base()
        {
        }
        #endregion

        #region 重写的方法
        /// <summary>
        /// 引发 <see cref="E:System.Web.UI.Control.PreRender"></see> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.EventArgs"></see> 对象。</param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            Page.RegisterRequiresPostBack(this);
            Page.ClientScript.GetPostBackClientHyperlink(this, "");
            if (!Page.ClientScript.IsClientScriptBlockRegistered(VALIDATE_CODE_REFRESH_SCRIPT_ID))
            {
                Page.ClientScript.RegisterClientScriptBlock(Type.GetType("System.String"), VALIDATE_CODE_REFRESH_SCRIPT_ID, VALIDATE_CODE_REFRESH_SCRIPT);
            }
        }

        /// <summary>
        /// 由 ASP.NET 页面框架调用，以通知使用基于合成的实现的服务器控件创建它们包含的任何子控件，以便为回发或呈现做准备。
        /// </summary>
        protected override void CreateChildControls()
        {
            Controls.Clear();
            ClearChildViewState();
            CreateControlHierarchy();
            PrepareControlHierarchy();
            TrackViewState();
            ChildControlsCreated = true;
        }

        /// <summary>
        /// 将控件呈现给指定的 HTML 编写器。
        /// </summary>
        /// <param name="writer">接收控件内容的 <see cref="T:System.Web.UI.HtmlTextWriter"></see> 对象。</param>
        protected override void Render(HtmlTextWriter writer)
        {
            EnsureChildControls();
            base.Render(writer);
        }
        #endregion

        #region 私有方法——产生控件
        /// <summary>
        /// Creates the control hierarchy.
        /// </summary>
        protected virtual void CreateControlHierarchy()
        {
            txbValidateCodeInput = new TextBox();
            imgValidateCodeImage = new Image();
            linkRefreshValidateCode = new HyperLink();

            this.txbValidateCodeInput.ID = this.ClientID + "_validateInputControl";
            this.imgValidateCodeImage.ID = this.ClientID + "_validateImageControl";
            this.linkRefreshValidateCode.ID = this.ClientID + "_validateRefreshControl";

            this.txbValidateCodeInput.CssClass = TextBoxCSSClass;
            this.imgValidateCodeImage.CssClass = ImageCSSClass;
            this.linkRefreshValidateCode.CssClass = RefreshLinkCSSClass;

            this.imgValidateCodeImage.ImageUrl = ImagePageUrl;
            this.linkRefreshValidateCode.Text = RefreshLinkText;
            this.linkRefreshValidateCode.Attributes.Add("onclick", string.Format(VALIDATE_CODE_REFRESH_HOOK, this.ClientID + "_validateImageControl", "'" + ImagePageUrl + "'"));

            ChildControlsCreated = true;
        }

        /// <summary>
        /// Prepares the control hierarchy.
        /// </summary>
        protected virtual void PrepareControlHierarchy()
        {
            TableRow row = new TableRow();

            TableCell inputCell = new TableCell();
            inputCell.Controls.Add(txbValidateCodeInput);
            row.Cells.Add(inputCell);
            inputCell.Dispose();//释放资源

            TableCell imageCell = new TableCell();
            imageCell.Controls.Add(imgValidateCodeImage);
            row.Cells.Add(imageCell);
            imageCell.Dispose();//释放资源

            TableCell linkCell = new TableCell();
            linkCell.Controls.Add(linkRefreshValidateCode);
            row.Cells.Add(linkCell);
            linkCell.Dispose();//释放资源

            Controls.Add(row);
            row.Dispose();//释放资源
        }
        #endregion

        #region 公共方法
        /// <summary>
        /// 比较用户输入是否正确
        /// </summary>
        /// <returns>
        /// 	如果正确 <c>true</c> ; 否则, <c>false</c>.
        /// </returns>
        public bool IsMatch()
        {
            if (HttpContext.Current.Session[ValidateCodeSessionName] == null)
            {
                return false;
            }
            if (!IgnoreCase)
            {
                return _strValidateCodeUserInput == HttpContext.Current.Session[ValidateCodeSessionName].ToString();
            }
            else
            {
                return _strValidateCodeUserInput.ToLower() == HttpContext.Current.Session[ValidateCodeSessionName].ToString().ToLower();
            }
        }

        /// <summary>
        /// 比较用户输入是否正确
        /// </summary>
        /// <param name="bIgnoreCase">如果设置为 <c>true</c> [跳过大小写].</param>
        /// <returns>
        /// 	<c>true</c> if the specified b ignore case is match; otherwise, <c>false</c>.
        /// </returns>
        public bool IsMatch(bool bIgnoreCase)
        {
            if (HttpContext.Current.Session[ValidateCodeSessionName] == null)
            {
                return false;
            }
            if (!bIgnoreCase)
            {
                return _strValidateCodeUserInput == HttpContext.Current.Session[ValidateCodeSessionName].ToString();
            }
            else
            {
                return _strValidateCodeUserInput.ToLower() == HttpContext.Current.Session[ValidateCodeSessionName].ToString().ToLower();
            }
        }
        #endregion

        #region IDisposable 成员

        /// <summary>
        /// 使服务器控件得以在从内存中释放之前执行最后的清理操作。
        /// </summary>
        void IDisposable.Dispose()
        {
            txbValidateCodeInput.Dispose();
            imgValidateCodeImage.Dispose();
            linkRefreshValidateCode.Dispose();
            GC.Collect();
        }

        #endregion

        ~ValidateCodeControl()
        {
            Dispose();
        }


        #region IPostBackDataHandler 成员

        /// <summary>
        /// 当由某个类实现时，它为 ASP.NET 服务器控件处理回发数据。
        /// </summary>
        /// <param name="postDataKey">控件的主要标识符。</param>
        /// <param name="postCollection">所有传入名称值的集合。</param>
        /// <returns>如果服务器控件的状态由于回发而发生更改，则为 true；否则为 false。</returns>
        bool IPostBackDataHandler.LoadPostData(string postDataKey, NameValueCollection postCollection)
        {
            string userInputCode = (string)postCollection[this.ClientID + "_validateInputControl"];

            if (!string.IsNullOrEmpty(userInputCode))
            {
                _strValidateCodeUserInput = userInputCode;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 当由类实现时，它用信号要求服务器控件对象通知 ASP.NET 应用程序该控件的状态已更改。
        /// </summary>
        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
        }
        #endregion
    }
}
