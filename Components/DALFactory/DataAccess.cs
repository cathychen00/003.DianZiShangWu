using System.Reflection;
using System.Configuration;
using Jiaen.Components.IDAL;
namespace Jiaen.Components
{

    /// <summary>
    /// ���󹤳�
    /// </summary>
    public sealed class DataAccess
    {
        // ���ҳ���
        private static readonly string path = ConfigurationManager.AppSettings["WebDAL"];

        private DataAccess() { }

        /// <summary>
        /// ����FriendLinkʵ��
        /// </summary>
        /// <returns></returns>
        public static IFriendLink CreateFriendLink()
        {
            string className = path + ".FriendLink";
            return (IFriendLink)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// ����TitleCssʵ��
        /// </summary>
        /// <returns></returns>
        public static ITitleCss CreateTitleCss()
        {
            string className = path + ".TitleCss";
            return (ITitleCss)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// ����Publishʵ��
        /// </summary>
        /// <returns></returns>
        public static IPublish CreatePublish()
        {
            string className = path + ".Publish";
            return (IPublish)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// ����BookCatenaʵ��
        /// </summary>
        /// <returns></returns>
        public static IBookCatena CreateBookCatena()
        {
            string className = path + ".BookCatena";
            return (IBookCatena)Assembly.Load(path).CreateInstance(className);
        }


        /// <summary>
        /// ����Usersʵ��
        /// </summary>
        /// <returns></returns>
        public static IAddress CreateAddress()
        {
            string className = path + ".Address";
            return (IAddress)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// ����Categoryʵ��
        /// </summary>
        /// <returns></returns>
        public static ICategory CreateCategory()
        {
            string className = path + ".Category";
            return (ICategory)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// ����FavBookʵ��
        /// </summary>
        /// <returns></returns>
        public static IFavBook CreateFavBook()
        {
            string className = path + ".FavBook";
            return (IFavBook)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// ����GuestBookʵ��
        /// </summary>
        /// <returns></returns>
        public static IGuestBook CreateGuestBook()
        {
            string className = path + ".GuestBook";
            return (IGuestBook)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// ����Reviewʵ��
        /// </summary>
        /// <returns></returns>
        public static IReview CreateReview()
        {
            string className = path + ".Review";
            return (IReview)Assembly.Load(path).CreateInstance(className);
        }

                /// <summary>
        /// ����SiteDynamicʵ��
        /// </summary>
        /// <returns></returns>
        public static ISiteDynamic CreateSiteDynamic()
        {
            string className = path + ".SiteDynamic";
            return (ISiteDynamic)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// ����SiteDynamicʵ��
        /// </summary>
        /// <returns></returns>
        public static IBook CreateBook()
        {
            string className = path + ".Book";
            return (IBook)Assembly.Load(path).CreateInstance(className);
        }


        /// <summary>
        /// ����Pollʵ��
        /// </summary>
        /// <returns></returns>
        public static IPoll CreatePoll()
        {
            string className = path + ".Poll";
            return (IPoll)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// ����ShoppingCartʵ��
        /// </summary>
        /// <returns></returns>
        public static IShoppingCart CreateShoppingCart()
        {
            string className = path + ".ShoppingCart";
            return (IShoppingCart)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// ����Ordersʵ��
        /// </summary>
        /// <returns></returns>
        public static IOrders CreateOrders()
        {
            string className = path + ".Orders";
            return (IOrders)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// ����Sendʵ��
        /// </summary>
        /// <returns></returns>
        public static ISend CreateSend()
        {
            string className = path + ".Send";
            return (ISend)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// ����SendAreaʵ��
        /// </summary>
        /// <returns></returns>
        public static ISendArea CreateSendArea()
        {
            string className = path + ".SendArea";
            return (ISendArea)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// ����ImageBookʵ��
        /// </summary>
        /// <returns></returns>
        public static IImageBook CreateImageBook()
        {
            string className = path + ".ImageBook";
            return (IImageBook)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// ����SiteSettingʵ��
        /// </summary>
        /// <returns></returns>
        public static ISiteSetting CreateSiteSetting()
        {
            string className = path + ".SiteSetting";
            return (ISiteSetting)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// ����HelpClassʵ��
        /// </summary>
        /// <returns></returns>
        public static IHelpClass CreateHelpClass()
        {
            string className = path + ".HelpClass";
            return (IHelpClass)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// ����Helpʵ��
        /// </summary>
        /// <returns></returns>
        public static IHelp CreateHelp()
        {
            string className = path + ".Help";
            return (IHelp)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// ����Paymentʵ��
        /// </summary>
        /// <returns></returns>
        public static IPayment CreatePayment()
        {
            string className = path + ".Payment";
            return (IPayment)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// ����Paymentʵ��
        /// </summary>
        /// <returns></returns>
        public static IEmailFormat CreateEmailFormat()
        {
            string className = path + ".EmailFormat";
            return (IEmailFormat)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// ����DownClassʵ��
        /// </summary>
        /// <returns></returns>
        public static IDownClass CreateDownClass()
        {
            string className = path + ".DownClass";
            return (IDownClass)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// ����DownLoadʵ��
        /// </summary>
        /// <returns></returns>
        public static IDownLoad CreateDownLoad()
        {
            string className = path + ".DownLoad";
            return (IDownLoad)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// ����Teacherʵ��
        /// </summary>
        /// <returns></returns>
        public static ITeacher CreateTeacher()
        {
            string className = path + ".Teacher";
            return (ITeacher)Assembly.Load(path).CreateInstance(className);
        }
    }
}
