using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components
{
   public enum BookOrderType
    {
       /// <summary>
       /// �����
       /// </summary>
       PassIng=-1,
       /// <summary>
       /// δͨ��
       /// </summary>
       NoPass=0,
       /// <summary>
       /// ��ͨ��
       /// </summary>
       Pass=1,
       /// <summary>
       /// δ����
       /// </summary>
       NoPayMoney = 2,
       /// <summary>
       /// �Ѹ���
       /// </summary>
       PayMoney=3,
       /// <summary>
       /// ������
       /// </summary>
       DealIng=4,
       /// <summary>
       /// �������
       /// </summary>
       Dealed=5
    }
}
