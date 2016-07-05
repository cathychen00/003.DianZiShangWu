using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// ��ɫʵ����
    /// </summary>
    public class RoleInfo
    {
        private int intRoleID;
        private string strRoleName;
        private string strRoleDec;
        private bool _editEnable;
        private int intUserID;

        /// <summary>
        /// ��ɫ���
        /// </summary>
        public int RoleID
        {
            get { return intRoleID; }
            set { intRoleID = value; }
        }


        /// <summary>
        /// ��ɫ����
        /// </summary>
        public string RoleName
        {
            get { return strRoleName; }
            set { strRoleName = value; }
        }

        /// <summary>
        /// ��ɫ����
        /// </summary>
        public string RoleDec
        {
            get { return strRoleDec; }
            set { strRoleDec = value; }
        }

        /// <summary>
        /// �Ƿ�ɱ༭
        /// </summary>
        public bool EditEnable
        {
            get { return _editEnable; }
            set { _editEnable = value; }
        }

        /// <summary>
        /// �û����
        /// </summary>
        public int UserID
        {
            get { return intUserID; }
            set { intUserID = value; }
        }
    }
}
