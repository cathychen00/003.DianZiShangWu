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
    public class FavBook
    {
        private static readonly IFavBook favBooks = DataAccess.CreateFavBook();

        /// <summary>
        /// ��ȡ�ղ�ͼ��
        /// </summary>
        /// <returns></returns>
        public static IList<FavBookInfo> GetFavBooks()
        {
            return favBooks.GetFavBooks();
        }

        /// <summary>
        /// ����ղ�ͼ��
        /// </summary>
        /// <param name="link"></param>
        public static void InsertFavBook(int bookID)
        {
            favBooks.InsertFavBook(bookID);
        }

        /// <summary>
        /// ɾ���ղ�ͼ��
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int DeleteFavBook(int favID)
        {
            return favBooks.DeleteFavBook(favID);
        }

        public static int DeleteFavBookByID(int bookID)
        {
            return favBooks.DeleteFavBookByID(bookID);
        }
    }
}
