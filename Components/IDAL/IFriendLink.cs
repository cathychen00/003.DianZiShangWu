using System;
using System.Collections.Generic;
namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// �������Ӳ����ӿ�
    /// </summary>
    public interface IFriendLink
    {

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns></returns>
        IList<FriendLinkInfo> GetLinks(LinkItemType linkType);

        /// <summary>
        /// ��ȡ�ض�����
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        FriendLinkInfo GetLinkByID(int linkID);

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="link"></param>
        void InsertLink(InsertLinkType linkType, FriendLinkInfo link);

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateLink(FriendLinkInfo link);

        /// <summary>
        /// ���ݸ�����������������
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateLink(UpdateLinkType linkType,int linkID);

        /// <summary>
        /// ����������������
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateLink(UpdateLinkType linkType,int linkOrder, int linkID);

        /// <summary>
        /// ɾ����������
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int DeleteLink(int linkID);
    }
}
