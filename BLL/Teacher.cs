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
    public class Teacher
    {

        private static readonly ITeacher teachers = DataAccess.CreateTeacher();

        /// <summary>
        /// ��ȡ��ʦ�б�
        /// </summary>
        /// <returns></returns>
        public static IList<TeacherInfo> GetTeacher(int type)
        {
            return teachers.GetTeacher(type);
        }

        /// <summary>
        /// ��ȡ�ض���ʦ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static TeacherInfo GetTeacherByID(int teacherID)
        {
            return teachers.GetTeacherByID(teacherID);
        }

        /// <summary>
        /// ��ӽ�ʦ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        public static void InsertTeacher(TeacherInfo teacher)
        {
            teachers.InsertTeacher(teacher);
        }

        /// <summary>
        /// ���½�ʦ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int UpdateTeacher(TeacherInfo teacher)
        {
            return teachers.UpdateTeacher(teacher);
        }


        /// <summary>
        /// ɾ����ʦ��Ϣ
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int DeleteTeacher(TeacherInfo teacher)
        {
            return teachers.DeleteTeacher(teacher);
        }
    }
}
