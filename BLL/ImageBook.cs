using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Jiaen.Components;
using Jiaen.Components.IDAL;
using Jiaen.SQLServerDAL;

namespace Jiaen.BLL
{
    [DataObjectAttribute]
    public class ImageBook
    {
        private static readonly IImageBook imageBooks = DataAccess.CreateImageBook();

        /// <summary>
        /// ��ȡͼƬ��Ϣ
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static IList<ImageBookInfo> GetImageBook(ImageBookType type)
        {
            return imageBooks.GetImageBook(type);
        }


        /// <summary>
        /// ��ȡ�ض�ͼƬ��Ϣ
        /// </summary>
        /// <param name="gbID"></param>
        /// <returns></returns>
        public static ImageBookInfo GetImageBookByID(int imageID)
        {
            return imageBooks.GetImageBookByID(imageID);
        }

        /// <summary>
        /// ���ͼƬ��Ϣ
        /// </summary>
        /// <param name="g"></param>
        public static void InsertImageBook(ImageBookInfo image)
        {
            imageBooks.InsertImageBook(image);
        }

        /// <summary>
        /// ����ͼƬ��Ϣ
        /// </summary>
        /// <param name="g"></param>
        public static int UpdateImageBook(ImageBookInfo image)
        {
            return imageBooks.UpdateImageBook(image);
        }

        /// <summary>
        /// ����ͼƬ��Ϣ
        /// </summary>
        /// <param name="g"></param>
        public static int UpdateImageBook(UpdateImageType type, int order, int imageID)
        {
            return imageBooks.UpdateImageBook(type, order, imageID);
        }

        /// <summary>
        /// ɾ��ͼƬ��Ϣ
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static int DeleteImageBookByID(int imageID)
        {
            return imageBooks.DeleteImageBookByID(imageID);
        }
    }
}
