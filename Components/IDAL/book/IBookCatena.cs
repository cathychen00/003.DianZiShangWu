using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// ͼ��ϵ�нӿ�
    /// </summary>
    public interface IBookCatena
    {
        /// <summary>
        /// ��ȡͼ��ϵ���б�
        /// </summary>
        /// <returns></returns>
        IList<BookCatenaInfo> GetCatenas();

        /// <summary>
        /// ��ȡ�ض�ͼ��ϵ����Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        BookCatenaInfo GetCatenaByID(int catenaID);

        /// <summary>
        /// ���ͼ��ϵ����Ϣ
        /// </summary>
        /// <param name="link"></param>
        void InsertCatena(BookCatenaInfo catena);

        /// <summary>
        /// ����ͼ��ϵ����Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateCatena(BookCatenaInfo catena);

        /// <summary>
        /// ɾ��ͼ��ϵ����Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int DeleteCatena(int catenaID);
    }
}
