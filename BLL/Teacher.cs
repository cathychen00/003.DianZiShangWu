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
        /// 获取教师列表
        /// </summary>
        /// <returns></returns>
        public static IList<TeacherInfo> GetTeacher(int type)
        {
            return teachers.GetTeacher(type);
        }

        /// <summary>
        /// 获取特定教师信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static TeacherInfo GetTeacherByID(int teacherID)
        {
            return teachers.GetTeacherByID(teacherID);
        }

        /// <summary>
        /// 添加教师信息
        /// </summary>
        /// <param name="link"></param>
        public static void InsertTeacher(TeacherInfo teacher)
        {
            teachers.InsertTeacher(teacher);
        }

        /// <summary>
        /// 更新教师信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int UpdateTeacher(TeacherInfo teacher)
        {
            return teachers.UpdateTeacher(teacher);
        }


        /// <summary>
        /// 删除教师信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static int DeleteTeacher(TeacherInfo teacher)
        {
            return teachers.DeleteTeacher(teacher);
        }
    }
}
