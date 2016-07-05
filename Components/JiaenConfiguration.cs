using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Web.Caching;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Xml;

namespace Jiaen.Components
{
   public class JiaenConfiguration
    {
        #region ��Ա�ֶ�
       public static readonly string CacheKey = "JiaenConfiguration";
        private Hashtable providers = new Hashtable();
        private Hashtable extensions = new Hashtable();
        private static readonly Cache cache = HttpRuntime.Cache;
        private string defaultProvider;
        private string defaultLanguage;
        private string forumFilesPath;
        private bool disableBackgroundThreads = false;
        private bool disableIndexing = false;
        private bool disableEmail = false;
        private string passwordEncodingFormat = "unicode";
        private int threadIntervalEmail = 15;
        private int threadIntervalStats = 15;
        //private SystemType systemType = SystemType.Self;
        private short smtpServerConnectionLimit = -1;
        private bool enableLatestVersionCheck = true;
        private string uploadFilesPath = "/Upload/";
        private XmlDocument XmlDoc = null;
        #endregion

       	#region ������
       public JiaenConfiguration(XmlDocument doc)
		{
			XmlDoc = doc;
			LoadValuesFromConfigurationXml();
		}
		#endregion

       #region ��ȡXML�ڵ�
       public XmlNode GetConfigSection(string nodePath)
       {
           return XmlDoc.SelectSingleNode(nodePath);
       }

       #endregion

       #region ��ȡ������Ϣʵ��
       public static JiaenConfiguration GetConfig()
       {
           JiaenConfiguration config = cache.Get(CacheKey) as JiaenConfiguration;
           if (config == null)
           {
               string path;
               if (HttpContext.Current != null)
                   path = HttpContext.Current.Server.MapPath("~/Jiaen.config");
               else
                   path = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "Jiaen.config";

               XmlDocument doc = new XmlDocument();
               doc.Load(path);
               config = new JiaenConfiguration(doc);
               cache.Insert(CacheKey, config, new CacheDependency(path), DateTime.MaxValue, TimeSpan.Zero, CacheItemPriority.AboveNormal, null);

               //cache.ReSetFactor(config.CacheFactor);
           }
           return config;

       }
       #endregion

       #region ���������ļ�����
       internal void LoadValuesFromConfigurationXml()
       {
           XmlNode node = GetConfigSection("Jiaen/Core");
           XmlAttributeCollection attributeCollection = node.Attributes;

           // Ĭ�������ṩ��
           XmlAttribute att = attributeCollection["defaultProvider"];
           if (att != null)
               defaultProvider = att.Value;
           // Ĭ������
           att = attributeCollection["defaultLanguage"];
           if (att != null)
               defaultLanguage = att.Value;
           else
               defaultLanguage = "zh-CN";
           // ��̳·��
           att = attributeCollection["forumFilesPath"];
           if (att != null)
               forumFilesPath = att.Value;
           else
               forumFilesPath = "/";
           // ���ú�̨�߳�
           att = attributeCollection["disableThreading"];
           if (att != null)
               disableBackgroundThreads = bool.Parse(att.Value);
           else
               disableBackgroundThreads = false;
           // ��ֹ����
           att = attributeCollection["disableIndexing"];
           if (att != null)
               disableIndexing = bool.Parse(att.Value);
           else
               disableIndexing = false;
           // ��ֹ�ʼ�
           att = attributeCollection["disableEmail"];
           if (att != null)
               disableEmail = bool.Parse(att.Value);
           else
               disableEmail = false;
           // ������ܸ�ʽ
           att = attributeCollection["passwordEncodingFormat"];
           if (att != null)
               passwordEncodingFormat = att.Value;
           else
               passwordEncodingFormat = "unicode";
           // ����ͳ��״̬
           att = attributeCollection["threadIntervalStats"];
           if (att != null)
               threadIntervalStats = int.Parse(att.Value);
           else
               threadIntervalStats = 15;
           // �ʼ����з��ͼ��
           att = attributeCollection["threadIntervalEmail"];
           if (att != null)
               threadIntervalEmail = int.Parse(att.Value);
           else
               threadIntervalEmail = 15;
           // SMTP����������
           att = attributeCollection["smtpServerConnectionLimit"];
           if (att != null)
               smtpServerConnectionLimit = short.Parse(att.Value);
           else
               smtpServerConnectionLimit = -1;
           // �汾���
           att = attributeCollection["enableLatestVersionCheck"];
           if (att != null)
               enableLatestVersionCheck = bool.Parse(att.Value);
           // �ϴ��ļ�·��
           att = attributeCollection["uploadFilesPath"];
           if (att != null)
               uploadFilesPath = att.Value;

           // ��ȡ�ӽڵ�
           foreach (XmlNode child in node.ChildNodes)
           {
               if (child.Name == "providers")
                   GetProviders(child, providers);

               if (child.Name == "extensionModules")
                   GetProviders(child, extensions);

           }
       }

       #endregion

       #region ��ȡ�����ļ��ڵ�Provider
       internal void GetProviders(XmlNode node, Hashtable table)
       {
           foreach (XmlNode provider in node.ChildNodes)
           {
               switch (provider.Name)
               {
                   case "add":
                       table.Add(provider.Attributes["name"].Value, new Provider(provider.Attributes));
                       break;

                   case "remove":
                       table.Remove(provider.Attributes["name"].Value);
                       break;

                   case "clear":
                       table.Clear();
                       break;

               }

           }

       }
       #endregion

       #region ��������
       // Properties
       //
       public string DefaultLanguage
       {
           get { return defaultLanguage; }
       }

       public string JiaenFilesPath
       {
           get { return forumFilesPath; }
       }

       public string DefaultProvider
       {
           get { return defaultProvider; }
       }

       public Hashtable Providers
       {
           get { return providers; }
       }

       public Hashtable Extensions
       {
           get { return extensions; }
       }

       public bool IsBackgroundThreadingDisabled
       {
           get { return disableBackgroundThreads; }
       }

       public bool IsIndexingDisabled
       {
           get { return disableIndexing; }
       }

       public string PasswordEncodingFormat
       {
           get { return passwordEncodingFormat; }
       }

       public string UploadFilesPath
       {
           get { return uploadFilesPath; }
       }

       public bool IsEmailDisabled
       {
           get { return disableEmail; }
       }

       public int ThreadIntervalEmail
       {
           get { return threadIntervalEmail; }
       }

       public int ThreadIntervalStats
       {
           get { return threadIntervalStats; }
       }

       public short SmtpServerConnectionLimit
       {
           get { return smtpServerConnectionLimit; }
       }

       public bool EnableLatestVersionCheck
       {
           get { return enableLatestVersionCheck; }
       }
       #endregion

       /// <summary>
       /// �����ṩ��ʵ����
       /// </summary>
       public class Provider
       {
           #region ��Ա�ֶ�
           private string name;
           private string providerType;
           private ExtensionType extensionType;
           private NameValueCollection providerAttributes = new NameValueCollection();
           #endregion

           #region ������
           public Provider(XmlAttributeCollection attributes)
           {
               // Set the name of the provider
               //
               name = attributes["name"].Value;

               // Set the extension type
               //
               try
               {
                   extensionType = (ExtensionType)Enum.Parse(typeof(ExtensionType), attributes["extensionType"].Value, true);
               }
               catch
               {
                   // Occassionally get an exception on parsing the extensiontype, so set it to Unknown
                   extensionType = ExtensionType.Unknown;
               }

               providerType = attributes["type"].Value;

               // Store all the attributes in the attributes bucket
               //
               foreach (XmlAttribute attribute in attributes)
               {
                   if ((attribute.Name != "name") && (attribute.Name != "type"))
                       providerAttributes.Add(attribute.Name, attribute.Value);

               }

           }
           #endregion

           #region ��������
           public string Name
           {
               get { return name; }
           }

           public string Type
           {
               get { return providerType; }
           }

           public ExtensionType ExtensionType
           {
               get { return extensionType; }
           }


           public NameValueCollection Attributes
           {
               get { return providerAttributes; }
           }

           #endregion
       }
    }
}
