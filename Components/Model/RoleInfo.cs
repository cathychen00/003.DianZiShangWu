using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// 角色实体类
    /// </summary>
    public class RoleInfo
    {
        private int intRoleID;
        private string strRoleName;
        private string strRoleDec;
        private bool _editEnable;
        private int intUserID;

        /// <summary>
        /// 角色编号
        /// </summary>
        public int RoleID
        {
            get { return intRoleID; }
            set { intRoleID = value; }
        }


        /// <summary>
        /// 角色名字
        /// </summary>
        public string RoleName
        {
            get { return strRoleName; }
            set { strRoleName = value; }
        }

        /// <summary>
        /// 角色介绍
        /// </summary>
        public string RoleDec
        {
            get { return strRoleDec; }
            set { strRoleDec = value; }
        }

        /// <summary>
        /// 是否可编辑
        /// </summary>
        public bool EditEnable
        {
            get { return _editEnable; }
            set { _editEnable = value; }
        }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int UserID
        {
            get { return intUserID; }
            set { intUserID = value; }
        }
    }
}
