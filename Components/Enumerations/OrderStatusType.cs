using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
    /// <summary>
    /// ����״̬
    /// </summary>
    public enum OrderStatusType
    {
        /// <summary>
        /// �Ƿ����
        /// </summary>
        Pass=0,
        /// <summary>
        /// �Ƿ񸶿�
        /// </summary>
        Pay=1,
        /// <summary>
        /// �Ƿ񷢻�
        /// </summary>
        Send=2,
        /// <summary>
        /// �Ƿ�鵵
        /// </summary>
        Finished=3,
        /// <summary>
        /// �Ƿ�ȡ��
        /// </summary>
        Cancel=4
    }
}
