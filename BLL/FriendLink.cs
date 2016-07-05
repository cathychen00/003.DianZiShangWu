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
        /// 获取友情链接
        /// </summary>
        /// <returns></returns>
        public static IList<FriendLinkInfo> GetLinks(LinkItemType linkType)
        {
            return friendLink.GetLinks(linkType);
        }

        /// <summary>
        /// 获取特定链接
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static FriendLinkInfo GetLinkByID(int linkID)
        {
            return friendLink.GetLinkByID(linkID);
        }

        /// <summary>
        /// 添加友情链接
        /// </summary>
        /// <param name="link"></param>
        public static void InsertLink(InsertLinkType linkType, FriendLinkInfo link)
        {
            friendLink.InsertLink(linkType, link);
        }

        /// <summary>
        /// 更新友情链接
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int UpdateLink(FriendLinkInfo link)
        {
            return friendLink.UpdateLink(link);
        }

        /// <summary>
        /// 更新友情链接
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int UpdateLink(UpdateLinkType linkType,int linkID)
        {
            return friendLink.UpdateLink(linkType, linkID);
        }

        /// <summary>
        /// 更新友情链接
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int UpdateLink(UpdateLinkType linkType,int linkOrder, int linkID)
        {
            return friendLink.UpdateLink(linkType,linkOrder, linkID);
        }

        /// <summary>
        /// 删除分类标题
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int DeleteLink(int linkID)
        {
            return friendLink.DeleteLink(linkID);
        }
    }
}
