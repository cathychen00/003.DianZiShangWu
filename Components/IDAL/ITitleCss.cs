using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
    /// <summary>
    /// ������ʽ�ӿ�
    /// </summary>
   public interface ITitleCss
    {
        /// <summary>
        /// ��ȡ������ʽ�б�
        /// </summary>
        /// <returns></returns>
       IList<TitleCssInfo> GetTitleCss();

        /// <summary>
        /// ��ȡ�ض�������ʽ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       TitleCssInfo GetTitleCssByID(int titleCssID);

        /// <summary>
        /// ��ӱ�����ʽ��Ϣ
        /// </summary>
        /// <param name="link"></param>
       void InsertTitleCss(TitleCssInfo titleCss);

        /// <summary>
        /// ���±�����ʽ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int UpdateTitleCss(TitleCssInfo titleCss);

        /// <summary>
        /// ɾ��������ʽ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
       int DeleteTitleCss(int titleCssID);
    }
}
