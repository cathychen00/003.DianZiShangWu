using System;
using System.Data;
using System.Web;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using Jiaen.Components.IDAL;
using Jiaen.Components;
using Jiaen.Components.Utility;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace Jiaen.SQLServerDAL
{
    /// <summary>
    /// �������Ӳ���
    /// </summary>
    public class FriendLink : IFriendLink
    {
        #region  ��ȡ��������
        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <param name="productid"></param>
        /// <returns></returns>
        [DataObjectMethod(DataObjectMethodType.Select, true)]
        public IList<FriendLinkInfo> GetLinks(LinkItemType linkType)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<FriendLinkInfo> friendlinks = new List<FriendLinkInfo>();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@linkType", SqlDbType.Int, 4);
            objParams[0].Value = (int)linkType;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Link_GetLinks", objParams); ;

            objParams[0].Value = (int)linkType;

            while (reader.Read())
            {
                FriendLinkInfo item = new FriendLinkInfo();
                item.LinkID = reader.GetInt32(reader.GetOrdinal("linkID"));
                item.LinkName = reader.GetString(reader.GetOrdinal("linkName"));
                item.LinkURL = reader.GetString(reader.GetOrdinal("linkURL"));
                item.LinkLogo = reader.GetString(reader.GetOrdinal("linkLogo"));
                item.LinkOrder = reader.GetInt32(reader.GetOrdinal("linkOrder"));
                item.IsMain = reader.GetBoolean(reader.GetOrdinal("linkMain"));
                item.IsArrow = reader.GetBoolean(reader.GetOrdinal("linkArrow"));
                friendlinks.Add(item);
            }
            reader.Close();
            return friendlinks;
        }

        #endregion

        #region ��ȡ�ض�����
        /// <summary>
        /// ��ȡ�ض�����
        /// </summary>
        /// <returns></returns>
        public FriendLinkInfo GetLinkByID(int linkID)
        {

            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@LinkID", SqlDbType.Int, 4);
            objParams[0].Value = linkID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_Link_GetLinkByID", objParams);
            FriendLinkInfo item = new FriendLinkInfo();
            while (reader.Read())
            {
                item.LinkID = reader.GetInt32(reader.GetOrdinal("linkID"));
                item.LinkName = reader.GetString(reader.GetOrdinal("linkName"));
                item.LinkURL = reader.GetString(reader.GetOrdinal("linkURL"));
                item.LinkLogo = reader.GetString(reader.GetOrdinal("linkLogo"));
                item.LinkOrder = reader.GetInt32(reader.GetOrdinal("linkOrder"));
                item.IsMain = reader.GetBoolean(reader.GetOrdinal("linkMain"));
                item.IsArrow = reader.GetBoolean(reader.GetOrdinal("linkArrow"));
            }
            reader.Close();
            return item;
        }

        #endregion

        #region �����������
        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="r"></param>
        public void InsertLink(InsertLinkType linkType, FriendLinkInfo f)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[6];
            objParams[0] = new SqlParameter("@LinkName", f.LinkName);
            objParams[1] = new SqlParameter("@LinkURL", f.LinkURL);
            objParams[2] = new SqlParameter("@LinkLogo", StringHelper.convertStr(f.LinkLogo));
            objParams[3] = new SqlParameter("@linkMain", f.IsMain);
            objParams[4] = new SqlParameter("@LinkAddDate", DateTime.Now);
            objParams[5] = new SqlParameter("@linkArrow", (int)linkType); ;
            objSqlHelper.ExecuteNonQuery("je_Link_InsertLink", objParams);
        }

        #endregion

        #region ������������

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int UpdateLink(FriendLinkInfo f)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[5];
            objParams[0] = new SqlParameter("@LinkName", f.LinkName);
            objParams[1] = new SqlParameter("@LinkURL", f.LinkURL);
            objParams[2] = new SqlParameter("@LinkLogo", StringHelper.convertStr(f.LinkLogo));
            objParams[3] = new SqlParameter("@linkMain", f.IsMain);
            objParams[4] = new SqlParameter("@LinkID", f.LinkID);
            return objSqlHelper.ExecuteNonQuery("je_Link_UpdateLink", objParams);
        }

        #endregion

         /// <summary>
        /// ������������
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int UpdateLink(UpdateLinkType linkType,int linkID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@linkType", (int)linkType);
            objParams[1] = new SqlParameter("@LinkID", linkID);
            return objSqlHelper.ExecuteNonQuery("je_Link_UpdateLinkByID", objParams);
        }

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int UpdateLink(UpdateLinkType linkType,int LinkOrder, int linkID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[2];
            objParams[0] = new SqlParameter("@LinkID", linkID);
            objParams[1] = new SqlParameter("@linkOrder", LinkOrder);
            return objSqlHelper.ExecuteNonQuery("je_Link_UpdateLinkOrder", objParams);
        }

        #region ɾ����������
        /// <summary>
        /// ɾ���������
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public int DeleteLink(int linkID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@LinkID", linkID);
            return objSqlHelper.ExecuteNonQuery("je_Link_DeleteLink", objParams);
        }
        #endregion
    }
}