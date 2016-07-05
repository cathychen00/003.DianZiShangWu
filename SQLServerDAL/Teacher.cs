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
    public class Teacher : ITeacher
    {
        #region ITeacher ≥…‘±

        public IList<TeacherInfo> GetTeacher(int type)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            List<TeacherInfo> teachers = new List<TeacherInfo>();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@type", SqlDbType.Int, 4);
            objParams[0].Value = type;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_TE_GetTeacher", objParams);
            while (reader.Read())
            {
                TeacherInfo item = GetTeacherByID(reader.GetInt32(reader.GetOrdinal("ID")));
                teachers.Add(item);
            }
            return teachers;
        }

        public TeacherInfo GetTeacherByID(int teacherID)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@ID", SqlDbType.Int, 4);
            objParams[0].Value = teacherID;
            SqlDataReader reader = objSqlHelper.ExecuteReader("je_TE_GetTeacherByID", objParams);
            TeacherInfo item = new TeacherInfo();
            while (reader.Read())
            {
                item.TeacherID = reader.GetInt32(reader.GetOrdinal("ID"));
                item.Name = reader.GetString(reader.GetOrdinal("Name"));
                item.Image = reader.GetString(reader.GetOrdinal("Image"));
                item.IsMain = reader.GetBoolean(reader.GetOrdinal("IsMain"));
                item.AddDate = reader.GetDateTime(reader.GetOrdinal("AddDate"));
                item.SmallDec = reader.GetString(reader.GetOrdinal("SmallDec"));
                item.Dec = reader.GetString(reader.GetOrdinal("Dec"));
            }
            reader.Close();
            return item;
        }

        public void InsertTeacher(TeacherInfo teacher)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[5];
            objParams[0] = new SqlParameter("@Name", teacher.Name);
            objParams[1] = new SqlParameter("@Image", teacher.Image);
            objParams[2] = new SqlParameter("@SmallDec", teacher.SmallDec);
            objParams[3] = new SqlParameter("@Dec", teacher.Dec);
            objParams[4] = new SqlParameter("@IsMain", teacher.IsMain);
            objSqlHelper.ExecuteNonQuery("je_TE_InsertTeacher", objParams);
        }

        public int UpdateTeacher(TeacherInfo teacher)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[6];
            objParams[0] = new SqlParameter("@Name", teacher.Name);
            objParams[1] = new SqlParameter("@Image", teacher.Image);
            objParams[2] = new SqlParameter("@SmallDec", teacher.SmallDec);
            objParams[3] = new SqlParameter("@Dec", teacher.Dec);
            objParams[4] = new SqlParameter("@IsMain", teacher.IsMain);
            objParams[5] = new SqlParameter("@ID", teacher.TeacherID);
            return objSqlHelper.ExecuteNonQuery("je_TE_UpdateTeacher", objParams);
        }

        public int DeleteTeacher(TeacherInfo teacher)
        {
            SqlHelper objSqlHelper = new SqlHelper();
            SqlParameter[] objParams = new SqlParameter[1];
            objParams[0] = new SqlParameter("@ID", teacher.TeacherID);
            return objSqlHelper.ExecuteNonQuery("je_TE_DeleteTeacher", objParams);
        }

        #endregion
    }
}
