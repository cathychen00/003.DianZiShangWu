using System;
using System.Collections.Generic;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// ���Բ��ӿ�
    /// </summary>
    public interface IGuestBook
    {

        /// <summary>
        /// ��ȡ�û�����
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        IList<GuestBookInfo> GetGuestBook(int userID);


        /// <summary>
        /// ��ȡ�ض�������Ϣ
        /// </summary>
        /// <param name="gbID"></param>
        /// <returns></returns>
        GuestBookInfo GetGuestBookByID(int gbID);

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="g"></param>
        void InsertGuestBook(GuestBookInfo g);

        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        int DeleteGuestBookByID(int gbID);
    }
}
