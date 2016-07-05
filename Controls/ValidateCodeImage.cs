using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
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
    public class ValidateCodeImage : WebControl, IDisposable
    {
        #region 本控件用到的枚举
        /// <summary>
        /// 生成验证码的方式
        /// </summary>
        public enum ValidateCodeLengthType
        {
            /// <summary>
            /// 固定长度的
            /// </summary>
            Static,
            /// <summary>
            /// 可变长度的
            /// </summary>
            Random
        }

        public enum ValidateCodeBorderColorType
        {
            Static,
            Random
        }

        public enum ValidateCodeDisturb
        {
            None = 0,
            A = 10,
            B = 20,
            C = 30,
            D = 40,
            E = 50,
            F = 60,
            G = 80,
            H = 100,
            Custom
        }

        public enum ValidateCodeFontColorType
        {
            Static,
            Random,
            RandomAll
        }
        #endregion

        #region 定义变量

        #region 静态变量
        private const string strValidateCodeBound = "a|b|c|d|e|f|g|h|i|j|k|l|m|n|o|p|q|r|s|t|u|v|w|x|y|z|A|B|C|D|E|F|G|H|I|J|K|L|M|N|O|P|Q|R|S|T|U|V|W|X|Y|Z|0|1|2|3|4|5|6|7|8|9";
        static string[] Fonts = new string[] {  "Helvetica", 
                                                "Geneva", 
                                                "sans-serif", 
                                                "Verdana",
                                                "Times New Roman",
                                                "Courier New"
                                             };

        #endregion

        /// <summary>
        /// 验证码Session的名称
        /// </summary>
        private string strValidateCodeSessionName = "ValidateCodeSession";
        #endregion

        #region 公共属性
        /// <summary>
        /// 读取或设置验证码的生成字符范围
        /// </summary>
        /// <value>The validate code bound string.</value>
        [Category("行为"), Description("读取或设置验证码的生成字符范围。"), DefaultValue(strValidateCodeBound)]
        public string ValidateCodeBoundString
        {
            get
            {
                object objValidateCodeBound = ViewState["ValidateCodeBound"];
                return objValidateCodeBound == null ? strValidateCodeBound : objValidateCodeBound.ToString();
            }
            set
            {
                ViewState["ValidateCodeBound"] = value;
            }
        }

        /// <summary>
        /// 只读：根据ValidateCodeBoundString获取验证码生成范围的数组
        /// </summary>
        /// <value>The validate code bound.</value>
        [Browsable(false), Description("只读：根据ValidateCodeBoundString获取验证码生成范围的数组")]
        public string[] ValidateCodeBound
        {
            get
            {
                if (ViewState["ValidateCodeBoundCharArray"] == null)
                {
                    ViewState["ValidateCodeBoundCharArray"] = ValidateCodeBoundString.Split(new char[] { '|' });
                }
                return (string[])ViewState["ValidateCodeBoundCharArray"];
            }
        }

        /// <summary>
        /// 读取或设置验证码长度是可变长度的还是固定长度的。
        /// 
        /// 如果是固定长度的则长度为ValidateCodeMaxLength所设置的值"
        /// </summary>
        /// <value>The validate code length mode.</value>
        [
        Category("行为"),
        Description(@"读取或设置验证码长度是可变长度的还是固定长度的。
        如果是固定长度的则长度为ValidateCodeMaxLength所设置的值"),

        DefaultValue(TW.Web.UI.ValidateCodeImage.ValidateCodeLengthType.Static)
        ]
        public ValidateCodeLengthType ValidateCodeLengthMode
        {
            get
            {
                object objValidateCodeLengthMode = ViewState["ValidateCodeLengthMode"];
                return objValidateCodeLengthMode == null ? ValidateCodeLengthType.Static : (ValidateCodeLengthType)objValidateCodeLengthMode;
            }
            set
            {
                ViewState["ValidateCodeLengthMode"] = value;
            }
        }

        /// <summary>
        /// 读取或设置验证码的最大长度。
        /// </summary>
        /// <value>The length of the validate code max.</value>
        [Category("行为"), Description("读取或设置验证码的最大长度。"), DefaultValue(4)]
        public byte ValidateCodeMaxLength
        {
            get
            {
                object objLength = ViewState["ValidateCodeMaxLength"];
                return objLength == null ? (byte)4 : (byte)objLength;
            }
            set
            {
                if (value <= ValidateCodeMinLength)//如果最大长度的设置值小于或等于最小值
                {
                    ViewState["ValidateCodeMaxLength"] = ValidateCodeMinLength;
                }
                else if (value == 0)
                {
                    ViewState["ValidateCodeMaxLength"] = 4;
                }
                else
                {
                    ViewState["ValidateCodeMaxLength"] = value;
                }
            }
        }

        /// <summary>
        /// 读取或设置验证码的最小长度。
        /// </summary>
        /// <value>The length of the validate code min.</value>
        [Category("行为"), Description("读取或设置验证码的最小长度。"), DefaultValue(4)]
        public byte ValidateCodeMinLength
        {
            get
            {
                object objLength = ViewState["ValidateCodeMinLength"];
                return objLength == null ? (byte)4 : (byte)objLength;
            }
            set
            {
                if (value >= ValidateCodeMaxLength)//如果最大长度的设置值小于或等于最小值
                {
                    ViewState["ValidateCodeMinLength"] = ValidateCodeMaxLength;
                }
                else if (value == 0)
                {
                    ViewState["ValidateCodeMinLength"] = 4;
                }
                else
                {
                    ViewState["ValidateCodeMinLength"] = value;
                }
            }
        }

        /// <summary>
        /// 读取或设置验证码的文字大小，单位为“像素”
        /// </summary>
        /// <value>The size of the validate code font.</value>
        [Category("外观"), Description("读取或设置验证码的文字大小，单位为“像素”"), DefaultValue(12)]
        public byte ValidateCodeFontSize
        {
            get
            {
                object objValidateCodeFontSize = ViewState["ValidateCodeFontSize"];
                return objValidateCodeFontSize == null ? (byte)12 : (byte)objValidateCodeFontSize;
            }
            set
            {
                ViewState["ValidateCodeFontSize"] = value;
            }
        }

        /// <summary>
        /// 设置图片宽度的系数
        /// </summary>
        /// <value>The valiate code width modulus.</value>
        [Category("外观"), Description("设置图片宽度的系数"), DefaultValue(1)]
        public float ValiateCodeWidthModulus
        {
            get
            {
                object objValidateCodeWidthModulus = ViewState["ValidateCodeWidthModulus"];
                return objValidateCodeWidthModulus == null ? 1f : (float)objValidateCodeWidthModulus;
            }
            set
            {
                float tmpF = value;
                if (tmpF < 0f)
                {
                    tmpF = 1f;
                }
                else if (tmpF > 2f)
                {
                    tmpF = 2f;
                }
                else
                {
                    tmpF = 1;
                }
                ViewState["ValidateCodeWidthModulus"] = tmpF;
            }
        }

        /// <summary>
        /// 设置验证码文字的颜色类型
        /// </summary>
        /// <value>The validate code font color mode.</value>
        [Category("外观"), Description("设置验证码文字的颜色类型"), DefaultValue(TW.Web.UI.ValidateCodeImage.ValidateCodeFontColorType.Static)]
        public ValidateCodeFontColorType ValidateCodeFontColorMode
        {
            get
            {
                object objFontColorMode = ViewState["ValidateCodeFontColorMode"];
                return objFontColorMode == null ? ValidateCodeFontColorType.Static : (ValidateCodeFontColorType)objFontColorMode;
            }
            set
            {
                ViewState["ValidateCodeFontColorMode"] = value;
            }
        }

        /// <summary>
        /// 设置验证码文字的颜色
        /// </summary>
        /// <value>The color of the validate code font.</value>
        [Category("外观"), Description("设置验证码文字的颜色"), DefaultValue("")]
        public Color ValidateCodeFontColor
        {
            get
            {
                object objFontColor = ViewState["ValidateCodeFontColor"];
                return objFontColor == null ? Color.Black : (Color)objFontColor;
            }
            set
            {
                ViewState["ValidateCodeFontColor"] = value;
            }
        }

        /// <summary>
        /// 读取或设置验证码的背景颜色
        /// </summary>
        /// <value>The color of the validate code back.</value>
        [Category("外观"), Description("读取或设置验证码的背景颜色")]
        public Color ValidateCodeBackColor
        {
            get
            {
                object objBackColor = ViewState["ValidateCodeBackColor"];
                return objBackColor == null ? Color.FromArgb(0xff, 0xff, 0xcc) : (Color)objBackColor;
            }
            set
            {
                ViewState["ValidateCodeBackColor"] = value;
            }
        }

        /// <summary>
        /// 读取或设置验证码的边框颜色
        /// </summary>
        /// <value>The color of the validate code border.</value>
        [Category("外观"), Description("读取或设置验证码的边框颜色")]
        public Color ValidateCodeBorderColor
        {
            get
            {
                object objBorderColor = ViewState["ValidateCodeBorderColor"];
                return objBorderColor == null ? Color.Black : (Color)objBorderColor;
            }
            set
            {
                ViewState["ValidateCodeBorderColor"] = value;
            }
        }

        /// <summary>
        /// 读取或设置验证码的边框颜色类型
        /// </summary>
        [Category("外观"), Description("读取或设置验证码的边框颜色类型"), DefaultValue(TW.Web.UI.ValidateCodeImage.ValidateCodeBorderColorType.Static)]
        public ValidateCodeBorderColorType ValidateCodeBorderColorMode
        {
            get
            {
                object objBorderColorType = ViewState["ValidateBorderColorMode"];
                return objBorderColorType == null ? ValidateCodeBorderColorType.Static : (ValidateCodeBorderColorType)objBorderColorType;
            }
            set
            {
                ViewState["ValidateBorderColorMode"] = value;
            }
        }

        /// <summary>
        /// 读取或设置验证码的边框宽度
        /// </summary>
        /// <value>The width of the validate code border.</value>
        [Category("外观"), Description("读取或设置验证码的边框宽度"), DefaultValue(1)]
        public int ValidateCodeBorderWidth
        {
            get
            {
                object objBorderWidth = ViewState["ValidateCodeBorderWidth"];
                return objBorderWidth == null ? 1 : (int)objBorderWidth;
            }
            set
            {
                ViewState["ValidateCodeBorderWidth"] = value;
            }
        }

        /// <summary>
        /// 读取或设置干扰线的密度。级别越高则越密度越大，越不容易被软件识别，但同时占用的系统资源也越多
        /// </summary>
        /// <value>The validate code disturb level.</value>
        [Category("外观"), Description("读取或设置干扰线的密度。级别越高则越密度越大，越不容易被软件识别，但同时占用的系统资源也越多。"), DefaultValue(TW.Web.UI.ValidateCodeImage.ValidateCodeDisturb.A)]
        public ValidateCodeDisturb ValidateCodeDisturbLevel
        {
            get
            {
                object objDistrubLevel = ViewState["ValidateCodeDisturbLevel"];
                return objDistrubLevel == null ? ValidateCodeDisturb.A : (ValidateCodeDisturb)objDistrubLevel;
            }
            set
            {
                ViewState["ValidateCodeDisturbLevel"] = value;
            }
        }

        /// <summary>
        /// 读取或设置干扰线的条数。
        /// 
        /// 只有在ValidateCodeDistrubLevel设置为Custom时才有效
        /// </summary>
        /// <value>The validate code disturb num.</value>
        [Description("读取或设置干扰线的条数，如果为负数则取绝对值。只有在ValidateCodeDistrubLevel设置为Custom时才有效"), DefaultValue(0), Category("外观")]
        public short ValidateCodeDisturbNum
        {
            get
            {
                object objDistrubNum = ViewState["ValidateCodeDistrubNum"];
                return objDistrubNum == null ? (short)0 : (short)objDistrubNum;
            }
            set
            {
                ViewState["ValidateCodeDistrubNum"] = value;
            }
        }

        /// <summary>
        /// 干扰线的最大长度。
        /// </summary>
        /// 
        [Description("读取或设置干扰线的最大长度"), DefaultValue(10), Category("外观")]
        public byte ValidateCodeDistrubLength
        {
            get
            {
                object ValidateCodeDistrubLength = ViewState["ValidateCodeDistrubLength"];
                return ValidateCodeDistrubLength == null ? (byte)10 : (byte)ValidateCodeDistrubLength;
            }
            set
            {
                ViewState["ValidateCodeDistrubLength"] = value;
            }
        }

        /// <summary>
        /// 读取或设置验证码Session保存的名称，如果不设置则默认为ValidateCodeSession
        /// </summary>
        /// <value>The name of the validate code session.</value>
        [Description("读取或设置验证码Session保存的名称，如果不设置则默认为ValidateCodeSession"), DefaultValue("ValidateCodeSession")]
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
        #endregion

        #region 重写的方法
        /// <summary>
        /// 引发 <see cref="E:System.Web.UI.Control.PreRender"></see> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.EventArgs"></see> 对象。</param>
        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
            PaintValidateCode();
        }
        /// <summary>
        /// 引发 <see cref="E:System.Web.UI.Control.Init"></see> 事件。
        /// </summary>
        /// <param name="e">包含事件数据的 <see cref="T:System.EventArgs"></see> 对象。</param>
        protected override void OnInit(EventArgs e)
        {
            this.SetNotCache();
            base.OnInit(e);
        }
        #endregion

        #region 私有方法
        /// <summary>
        /// 取得要生成的验证码的长度。
        /// </summary>
        /// <returns></returns>
        private byte GetValidateCodeLength()
        {
            //如果是定长的
            if (ValidateCodeLengthMode == ValidateCodeLengthType.Static)
            {
                return ValidateCodeMaxLength;
            }
            else
            {
                Random ran = new Random();
                return (byte)ran.Next(ValidateCodeMinLength, ValidateCodeMaxLength + 1);
            }
        }

        /// <summary>
        /// 产生验证码。
        /// </summary>
        /// <returns></returns>
        private string GetValidateCode()
        {
            Random ran = new Random();
            int iBoundLength = ValidateCodeBound.Length;
            int iMaxLength = GetValidateCodeLength();
            string strCode = "";
            for (int i = 0; i < iMaxLength; i++)
            {
                strCode += ValidateCodeBound[ran.Next(iBoundLength)];
            }

            //记录Session
            if (HttpContext.Current.Session[strValidateCodeSessionName] == null)
            {
                HttpContext.Current.Session.Add(strValidateCodeSessionName, strCode);
            }
            else
            {
                HttpContext.Current.Session[strValidateCodeSessionName] = strCode;
            }

            return strCode;
        }

        /// <summary>
        /// 获取验证码的字体
        /// </summary>
        /// <returns></returns>
        private Font GetFont()
        {
            Random ran = new Random();
            //FontFamily[] fonts = FontFamily.Families;
            System.Drawing.Font font = new Font(Fonts[ran.Next(Fonts.Length)], ValidateCodeFontSize, GetFontStyle(), GraphicsUnit.Pixel);
            //fonts = null;
            ran = null;
            return font;
        }

        /// <summary>
        /// 获取验证码的字体外观。
        /// </summary>
        /// <returns></returns>
        private FontStyle GetFontStyle()
        {
            switch (new Random().Next(0, 3))
            {
                case 0:
                    return FontStyle.Bold;
                case 1:
                    return FontStyle.Italic;
                case 2:
                    return FontStyle.Bold | FontStyle.Italic;
                default:
                    return FontStyle.Regular;
            }
        }

        /// <summary>
        /// 获取随机颜色
        /// </summary>
        /// <returns></returns>
        private Color GetRandomColor()
        {
            Random ran = new Random();
            return Color.FromArgb(ran.Next(255), ran.Next(255), ran.Next(255));
        }

        /// <summary>
        /// 获取随机的点
        /// </summary>
        /// <param name="minValue"></param>
        /// <param name="maxValue"></param>
        /// <returns></returns>
        private Point GetRandomPoint(int width, int height)
        {
            Random ran = new Random();
            int x = ran.Next(0, width);
            int y = ran.Next(0, height);
            return new Point(x, y);
        }

        /// <summary>
        /// 获取画刷
        /// </summary>
        /// <returns></returns>
        private Brush GetBrush()
        {
            Random ran = new Random();
            SolidBrush brush = new SolidBrush(Color.FromArgb(ran.Next(255), ran.Next(255), ran.Next(255)));
            return brush;
        }

        /// <summary>
        /// 获取绘制边框的画笔
        /// </summary>
        /// <returns></returns>
        private Pen GetBorderPen()
        {
            if (ValidateCodeBorderColorMode == ValidateCodeBorderColorType.Random)
            {
                return new Pen(GetRandomColor(), ValidateCodeBorderWidth);
            }
            else
            {
                return new Pen(ValidateCodeBorderColor, ValidateCodeBorderWidth);
            }
        }

        /// <summary>
        /// 获取验证码的图片宽度
        /// </summary>
        /// <returns></returns>
        private int GetValidateCodeWidth()
        {
            return (int)((GetValidateCode().Length * ValidateCodeFontSize) * ValiateCodeWidthModulus);
        }

        /// <summary>
        /// 获取验证码的图片高度
        /// </summary>
        /// <returns></returns>
        private int GetValidateCodeHeight()
        {
            return ValidateCodeFontSize * 2;
        }

        /// <summary>
        /// 绘制验证码
        /// </summary>
        private void PaintValidateCode()
        {
            int iWidth = GetValidateCodeWidth();
            int iHeight = GetValidateCodeHeight();

            Bitmap objBitmap = new Bitmap(iWidth, iHeight);
            Graphics objG = Graphics.FromImage(objBitmap);
            try
            {

                //绘制背景
                objG.Clear(ValidateCodeBackColor);

                //绘制噪音线
                PaintDisturb(objG, iWidth, iHeight);

                //绘制验证码

                this.PaintCode(objG);

                //绘制边框
                objG.DrawRectangle(GetBorderPen(), new Rectangle(0, 0, iWidth - ValidateCodeBorderWidth, iHeight - ValidateCodeBorderWidth));


                //输出验证码图片
                using (MemoryStream imageStream = new MemoryStream())
                {
                    objBitmap.Save(imageStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    HttpContext.Current.Response.BinaryWrite(imageStream.ToArray());
                }
            }
            catch
            {
            }
            finally
            {
                objBitmap.Dispose();
                objG.Dispose();
            }

        }

        /// <summary>
        /// 绘制验证码
        /// </summary>
        /// <param name="g">The g.</param>
        public void PaintCode(Graphics g)
        {
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            string strValidateCode = GetValidateCode();

            switch (this.ValidateCodeFontColorMode)
            {
                case ValidateCodeFontColorType.RandomAll:
                    //逐字符绘制
                    Random ran = new Random();
                    for (int i = 0; i < strValidateCode.Length; i++)
                    {
                        using (Brush brush = new SolidBrush(Color.FromArgb(ran.Next(0, 255), ran.Next(0, 255), ran.Next(0, 255))))
                        {
                            g.DrawString(strValidateCode.Substring(i, 1), GetFont(), brush, GetCodeRect(i), sf);
                        }
                    }
                    ran = null;
                    break;
                case ValidateCodeFontColorType.Random:
                    g.DrawString(strValidateCode, GetFont(), GetBrush(), new Rectangle(0, 0, this.GetValidateCodeWidth(), this.GetValidateCodeHeight()), sf);
                    break;
                default:
                    using (Brush brush = new SolidBrush(Color.Black))
                    {
                        g.DrawString(strValidateCode, GetFont(), brush, new Rectangle(0, 0, this.GetValidateCodeWidth(), this.GetValidateCodeHeight()), sf);
                    }
                    break;
            }

            sf.Dispose();
        }

        /// <summary>
        /// 获取单个字符的绘制区域
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Rectangle GetCodeRect(int index)
        {
            // 计算一个字符应该分配有多宽的绘制区域（等分为CodeLength份）
            int subWidth = this.GetValidateCodeWidth() / GetValidateCodeLength();
            // 计算该字符左边的位置
            int subLeftPosition = subWidth * index;

            return new Rectangle(subLeftPosition, 0, subWidth, this.GetValidateCodeHeight());
        }

        /// <summary>
        /// 绘制干扰线
        /// </summary>
        /// <param name="g">要绘制的Graphics.</param>
        /// <param name="width">宽度.</param>
        /// <param name="height">高度</param>
        private void PaintDisturb(Graphics g, int width, int height)
        {
            //objG.DrawLine(new Pen(Color.FromArgb(0xff, 0x00, 0x00), 1), 0, 0, 10, 10);
            Random ran = new Random();

            int disturbDensity = 0;
            if (ValidateCodeDisturbLevel != ValidateCodeDisturb.Custom)
                disturbDensity = (int)ValidateCodeDisturbLevel;
            else
                disturbDensity = ValidateCodeDisturbNum;

            for (int i = 0; i < disturbDensity; i++)
            {
                Point p1 = new Point(ran.Next(0, width), ran.Next(0, height));
                Point p2 = new Point(p1.X + ran.Next(-ValidateCodeDistrubLength, ValidateCodeDistrubLength), p1.Y + ran.Next(-ValidateCodeDistrubLength, ValidateCodeDistrubLength));
                using (Pen pen = new Pen(Color.FromArgb(ran.Next(0, 255), ran.Next(0, 255), ran.Next(0, 255))))
                {
                    g.DrawLine(pen, p1, p2);
                }
            }
        }

        /// <summary>
        /// 设置包含该控件的页面不缓存
        /// </summary>
        private void SetNotCache()
        {
            HttpContext.Current.Response.Buffer = true;
            HttpContext.Current.Response.ExpiresAbsolute = System.DateTime.Now.AddSeconds(-1);
            HttpContext.Current.Response.Expires = 0;
            HttpContext.Current.Response.CacheControl = "no-cache";
            HttpContext.Current.Response.AppendHeader("Pragma", "No-Cache");
        }
        #endregion

        #region IDisposable 成员

        /// <summary>
        /// 使服务器控件得以在从内存中释放之前执行最后的清理操作。
        /// </summary>
        void IDisposable.Dispose()
        {
            GC.Collect();
            base.Dispose();
        }

        #endregion

        /// <summary>
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// <see cref="ValidateCodeImage"/> is reclaimed by garbage collection.
        /// </summary>
        ~ValidateCodeImage()
        {
            this.Dispose();
        }
    }
}
