using System;
using System.Collections.Generic;
using System.Text;

namespace Jiaen.Components.IDAL
{
   public interface ITeacher
    {
        /// <summary>
        /// 获取教师信息列表
        /// </summary>
        /// <returns></returns>
        IList<TeacherInfo> GetTeacher(int type);

        /// <summary>
        /// 获取特定教师信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        TeacherInfo GetTeacherByID(int teacherID);

        /// <summary>
        /// 添加教师信息
        /// </summary>
        /// <param name="link"></param>
        void InsertTeacher(TeacherInfo teacher);

        /// <summary>
        /// 更新教师信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int UpdateTeacher(TeacherInfo teacher);


        /// <summary>
        /// 删除教师信息
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        int DeleteTeacher(TeacherInfo teacher);
    }
}
