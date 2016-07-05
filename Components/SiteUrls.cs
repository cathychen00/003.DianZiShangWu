using System;
using System.Collections;
using System.Collections.Specialized;
using System.Web;
using System.Web.Caching;
using System.Xml;

namespace Jiaen.Components
{
   public class SiteUrls
    {
        #region ��Ա�����͹��캯��

        private HttpContext Context = HttpContext.Current;
        private NameValueCollection paths = null;
        private NameValueCollection reversePaths = null;
        private string siteUrlsXmlFile = "Support/SiteUrls.config";
        private bool enableWaitPage = false;
        // ��дurl�б�
        private ArrayList reWrittenUrls = null;

        // Constructor loads all the site urls from the SiteUrls.config file
        // or returns from the cache
        //
        public SiteUrls()
        {
            string cacheKey = "SiteUrls";
            //			string cacheKeyReverse = "SiteUrls-ReverseLookup";

            // Get the names of the providers
            //
            JiaenConfiguration config = JiaenConfiguration.GetConfig();

            // Get the path to the URLs file
            //
            siteUrlsXmlFile = config.JiaenFilesPath + siteUrlsXmlFile;
            // ��д�ӵ�
            //			HttpContext Context = HttpContext.Current;

            //			if (HttpRuntime.Cache[cacheKey] == null)
            //			if (Context.Cache[cacheKey] == null)
            //			{
            string file = "";

            //				if (forumContext != null)
            //					file = forumContext.Context.Server.MapPath(Globals.ApplicationPath + siteUrlsXmlFile);
            //				else
            file = HttpContext.Current.Server.MapPath(Globals.ApplicationPath + siteUrlsXmlFile);

            paths = new NameValueCollection();
            reversePaths = new NameValueCollection();
            // ��д
            reWrittenUrls = new ArrayList();

            // ���� SiteUrls.xml �ļ�
            //
            XmlDocument doc = new XmlDocument();
            doc.Load(file);

            XmlNode urls = doc.SelectSingleNode("urls");

            foreach (XmlNode n in urls.ChildNodes)
            {
                if (n.NodeType != XmlNodeType.Comment)
                {
                    string name = n.Attributes["name"].Value;
                    string path = ResolveUrl(n.Attributes["path"].Value.Replace("^", "&"));
                    paths.Add(name, path);
                    reversePaths.Add(n.Attributes["path"].Value.Replace("^", "&"), name);


                    //// ��дURL by venjiang
                    //XmlAttribute vanity = n.Attributes["vanity"];
                    //XmlAttribute pattern = n.Attributes["pattern"];

                    ////�洢·��������ģʽ. 
                    //if (vanity != null && pattern != null)
                    //{
                    //    string p = pattern.Value;
                    //    string v = vanity.Value.Replace("^", "&");
                    //    reWrittenUrls.Add(new ReWrittenUrl(name, p, v));
                    //}
                }

            }

            // If the file changes we want to reload it
            CacheDependency dep = new CacheDependency(file);
            CacheDependency dep2 = new CacheDependency(file);

            //				HttpRuntime.Cache.Insert(cacheKey, paths, dep, DateTime.MaxValue, TimeSpan.Zero);
            //				HttpRuntime.Cache.Insert(cacheKeyReverse, reversePaths, dep2, DateTime.MaxValue, TimeSpan.Zero);
            // ��Ϊһ������
            HttpRuntime.Cache.Insert(cacheKey, this, dep, DateTime.MaxValue, TimeSpan.Zero);

            //			}

            //			paths = (NameValueCollection) HttpRuntime.Cache[cacheKey];
            //			reversePaths = (NameValueCollection) HttpRuntime.Cache[cacheKeyReverse];
            //			paths = (NameValueCollection) HttpRuntime.Cache[cacheKey];

        }

        #endregion

       public string Moderate
       {
           get { return paths["moderate"]; }
       }

        #region �ڲ����� Private static helper methods

        private static string ResolveUrl(string path)
        {
            if (Globals.ApplicationPath.Length > 0)
                return Globals.ApplicationPath + path;
            else
                return path;
        }

        public static string RemoveParameters(string url)
        {
            if (url == null)
                return string.Empty;

            int paramStart = url.IndexOf("?");

            if (paramStart > 0)
                return url.Substring(0, paramStart);

            return url;
        }

        private static NameValueCollection ExtractQueryParams(string url)
        {
            int startIndex = url.IndexOf("?");
            NameValueCollection values = new NameValueCollection();

            if (startIndex <= 0)
                return values;

            string[] nameValues = url.Substring(startIndex + 1).Split('&');

            foreach (string s in nameValues)
            {
                string[] pair = s.Split('=');

                string name = pair[0];
                string value = string.Empty;

                if (pair.Length > 1)
                    value = pair[1];

                values.Add(name, value);
            }

            return values;
        }

        public static string FormatUrlWithParameters(string url, string parameters)
        {
            if (url == null)
                return string.Empty;

            if (parameters.Length > 0)
                url = url + "?" + parameters;

            return url;

        }

        #endregion
    }
}
