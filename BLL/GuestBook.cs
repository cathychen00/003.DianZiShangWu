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
    public class GuestBook
    {
        private static readonly IGuestBook gbs = DataAccess.CreateGuestBook();

        /// <summary>
        /// ��ȡ�û�����
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static IList<GuestBookInfo> GetGuestBook(int userID)
        {
            return gbs.GetGuestBook(userID);
        }


        /// <summary>
        /// ��ȡ�ض�������Ϣ
        /// </summary>
        /// <param name="gbID"></param>
        /// <returns></returns>
        public static GuestBookInfo GetGuestBookByID(int gbID)
        {
            return gbs.GetGuestBookByID(gbID);
        }

        /// <summary>
        /// �������
        /// </summary>
        /// <param name="g"></param>
        public static void InsertGuestBook(GuestBookInfo g)
        {
            gbs.InsertGuestBook(g);
        }

        /// <summary>
        /// ɾ��������Ϣ
        /// </summary>
        /// <param name="g"></param>
        /// <returns></returns>
        public static int DeleteGuestBookByID(int gbID)
        {
            return gbs.DeleteGuestBookByID(gbID);
        }
    }
}
