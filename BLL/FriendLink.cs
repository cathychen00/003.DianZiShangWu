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
    public class FriendLink
    {
        private static readonly IFriendLink friendLink = DataAccess.CreateFriendLink();
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns></returns>
        public static IList<FriendLinkInfo> GetLinks(LinkItemType linkType)
        {
            return friendLink.GetLinks(linkType);
        }

        /// <summary>
        /// ��ȡ�ض�����
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static FriendLinkInfo GetLinkByID(int linkID)
        {
            return friendLink.GetLinkByID(linkID);
        }

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="link"></param>
        public static void InsertLink(InsertLinkType linkType, FriendLinkInfo link)
        {
            friendLink.InsertLink(linkType, link);
        }

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int UpdateLink(FriendLinkInfo link)
        {
            return friendLink.UpdateLink(link);
        }

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int UpdateLink(UpdateLinkType linkType,int linkID)
        {
            return friendLink.UpdateLink(linkType, linkID);
        }

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int UpdateLink(UpdateLinkType linkType,int linkOrder, int linkID)
        {
            return friendLink.UpdateLink(linkType,linkOrder, linkID);
        }

        /// <summary>
        /// ɾ���������
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int DeleteLink(int linkID)
        {
            return friendLink.DeleteLink(linkID);
        }
    }
}
