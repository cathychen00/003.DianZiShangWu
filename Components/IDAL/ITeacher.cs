using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
   public interface ITeacher
    {
        /// <summary>
        /// ��ȡ��ʦ��Ϣ�б�
        /// </summary>
        /// <returns></returns>
        IList<TeacherInfo> GetTeacher(int type);

        /// <summary>
        /// ��ȡ�ض���ʦ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        TeacherInfo GetTeacherByID(int teacherID);

        /// <summary>
        /// ��ӽ�ʦ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        void InsertTeacher(TeacherInfo teacher);

        /// <summary>
        /// ���½�ʦ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateTeacher(TeacherInfo teacher);


        /// <summary>
        /// ɾ����ʦ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int DeleteTeacher(TeacherInfo teacher);
    }
}
