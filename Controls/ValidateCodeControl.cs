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
        #region �������

        #region �ؼ�����
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
        /// ��֤��Session������
        /// </summary>
        private string strValidateCodeSessionName = "ValidateCodeSession";

        private string _strValidateCodeUserInput = string.Empty;

        #endregion

        #region ��������
        /// <summary>
        /// ��ȡ��������֤�������ı����CSS��ʽ
        /// </summary>
        /// <value>����֤�������ı����CSS��ʽ</value>
        [Description("��ȡ��������֤�������ı����CSS��ʽ"), Category("���"), DefaultValue("")]
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
        /// ��ȡ��������֤���CSS��ʽ
        /// </summary>
        [Description("��ȡ��������֤���CSS��ʽ"), Category("���"), DefaultValue("")]
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
        /// ��ȡ������ˢ�����ӵ�CSS��ʽ.
        /// </summary>
        [Description("��ȡ������ˢ�����ӵ�CSS��ʽ"), Category("���"), DefaultValue("")]
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
        /// ��ȡ�������Ƿ����ִ�Сд��
        /// </summary>
        [Description("��ȡ�������Ƿ����ִ�Сд��"), Category("��Ϊ"), DefaultValue(true)]
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
        /// ��ȡ��������֤��ͼƬ��ַ
        /// </summary>
        /// <value>The image page URL.</value>
        [Description("��ȡ��������֤��ͼƬ��ַ"), Category("��Ϊ"), DefaultValue("./TW_Client/ValidateCode/TW.ValidateCode.aspx")]
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
        /// ��ȡ������ˢ����֤�����������
        /// </summary>
        /// <value>The refresh link text.</value>
        [Description("��ȡ������ˢ����֤�����������"), Category("��Ϊ"), DefaultValue("ˢ����֤��")]
        public string RefreshLinkText
        {
            get
            {
                object objValidateCodeRefreshText = ViewState["ValidateCodeRefreshText"];
                return objValidateCodeRefreshText == null ? "ˢ����֤��" : objValidateCodeRefreshText.ToString();
            }
            set
            {
                ViewState["ValidateCodeRefreshText"] = value;
            }
        }

        /// <summary>
        /// ��ȡ��������֤��Session��������ƣ������������Ĭ��ΪValidateCodeSession��
        /// ע�⣺�����ValidateCodeImage���ValidateCodeSessionName����һ�£��������ִ���
        /// </summary>
        /// <value>The name of the validate code session.</value>
        [Description("��ȡ��������֤��Session��������ƣ������������Ĭ��ΪValidateCodeSession��ע�⣺�����ValidateCodeImage���ValidateCodeSessionName����һ�£��������ִ���"), DefaultValue("ValidateCodeSession")]
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
        /// ��ȡ�û��������֤��
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

        #region ��д������
        /// <summary>
        /// ��ȡ��� Web �������ؼ����Ӧ�� <see cref="T:System.Web.UI.HtmlTextWriterTag"></see> ֵ����������Ҫ�ɿؼ�������Աʹ�á�
        /// </summary>
        /// <value></value>
        /// <returns><see cref="T:System.Web.UI.HtmlTextWriterTag"></see> ö��ֵ֮һ��</returns>
        protected override HtmlTextWriterTag TagKey
        {
            get
            {
                return HtmlTextWriterTag.Table;
            }
        }
        #endregion

        #region ���캯��
        public ValidateCodeControl()
            : base()
        {
        }
        #endregion

        #region ��д�ķ���
        /// <summary>
        /// ���� <see cref="E:System.Web.UI.Control.PreRender"></see> �¼���
        /// </summary>
        /// <param name="e">�����¼����ݵ� <see cref="T:System.EventArgs"></see> ����</param>
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
        /// �� ASP.NET ҳ���ܵ��ã���֪ͨʹ�û��ںϳɵ�ʵ�ֵķ������ؼ��������ǰ������κ��ӿؼ����Ա�Ϊ�ط��������׼����
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
        /// ���ؼ����ָ�ָ���� HTML ��д����
        /// </summary>
        /// <param name="writer">���տؼ����ݵ� <see cref="T:System.Web.UI.HtmlTextWriter"></see> ����</param>
        protected override void Render(HtmlTextWriter writer)
        {
            EnsureChildControls();
            base.Render(writer);
        }
        #endregion

        #region ˽�з������������ؼ�
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
            inputCell.Dispose();//�ͷ���Դ

            TableCell imageCell = new TableCell();
            imageCell.Controls.Add(imgValidateCodeImage);
            row.Cells.Add(imageCell);
            imageCell.Dispose();//�ͷ���Դ

            TableCell linkCell = new TableCell();
            linkCell.Controls.Add(linkRefreshValidateCode);
            row.Cells.Add(linkCell);
            linkCell.Dispose();//�ͷ���Դ

            Controls.Add(row);
            row.Dispose();//�ͷ���Դ
        }
        #endregion

        #region ��������
        /// <summary>
        /// �Ƚ��û������Ƿ���ȷ
        /// </summary>
        /// <returns>
        /// 	�����ȷ <c>true</c> ; ����, <c>false</c>.
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
        /// �Ƚ��û������Ƿ���ȷ
        /// </summary>
        /// <param name="bIgnoreCase">�������Ϊ <c>true</c> [������Сд].</param>
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

        #region IDisposable ��Ա

        /// <summary>
        /// ʹ�������ؼ������ڴ��ڴ����ͷ�֮ǰִ���������������
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


        #region IPostBackDataHandler ��Ա

        /// <summary>
        /// ����ĳ����ʵ��ʱ����Ϊ ASP.NET �������ؼ�����ط����ݡ�
        /// </summary>
        /// <param name="postDataKey">�ؼ�����Ҫ��ʶ����</param>
        /// <param name="postCollection">���д�������ֵ�ļ��ϡ�</param>
        /// <returns>����������ؼ���״̬���ڻط����������ģ���Ϊ true������Ϊ false��</returns>
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
        /// ������ʵ��ʱ�������ź�Ҫ��������ؼ�����֪ͨ ASP.NET Ӧ�ó���ÿؼ���״̬�Ѹ��ġ�
        /// </summary>
        void IPostBackDataHandler.RaisePostDataChangedEvent()
        {
        }
        #endregion
    }
}
