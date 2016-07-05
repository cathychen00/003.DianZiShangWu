using System;
using System.Collections.Generic;
namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// 友情链接操作接口
    /// </summary>
    public interface IFriendLink
    {

        /// <summary>
        /// 获取友情链接
        /// </summary>
        /// <returns></returns>
        IList<FriendLinkInfo> GetLinks(LinkItemType linkType);

        /// <summary>
        /// 获取特定链接
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        FriendLinkInfo GetLinkByID(int linkID);

        /// <summary>
        /// 添加友情链接
        /// </summary>
        /// <param name="link"></param>
        void InsertLink(InsertLinkType linkType, FriendLinkInfo link);

        /// <summary>
        /// 更新友情链接
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateLink(FriendLinkInfo link);

        /// <summary>
        /// 根据更新类别更新友情链接
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateLink(UpdateLinkType linkType,int linkID);

        /// <summary>
        /// 更新友情链接排序
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateLink(UpdateLinkType linkType,int linkOrder, int linkID);

        /// <summary>
        /// 删除友情链接
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int DeleteLink(int linkID);
    }
}
