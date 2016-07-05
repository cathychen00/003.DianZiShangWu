using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// ͼ���ղؼнӿ�
    /// </summary>
    public interface IFavBook
    {
        /// <summary>
        /// ��ȡ�ղ�ͼ��
        /// </summary>
        /// <returns></returns>
        IList<FavBookInfo> GetFavBooks();

        /// <summary>
        /// ����ղ�ͼ��
        /// </summary>
        /// <param name="link"></param>
        void InsertFavBook(int bookID);

        /// <summary>
        /// ɾ���ղ�ͼ��
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int DeleteFavBook(int favID);

        int DeleteFavBookByID(int bookID);
    }
}
