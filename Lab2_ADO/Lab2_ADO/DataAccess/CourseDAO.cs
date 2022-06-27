using Lab2_ADO.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_ADO.DataAccess
{
    internal class CourseDAO
    {
        //public static List<Course> GetAllCourses()
        //{
        //    string sql = "select c.*, s.*, i.*, t.TermId, t.TermName, t.Description, cs.* from COURSES c left join SUBJECTS s " +
        //        "on c.SubjectId = s.SubjectId left join INSTRUCTORS i on c.InstructorId = i.InstructorId left join TERMS t " +
        //        "on c.TermId = t.TermId left join CAMPUSES cs on c.CampusID = cs.CampusId";
        //    DataTable dt = DAO.GetDataBySql(sql);
        //    List<Course> list = new List<Course>();
        //    foreach (DataRow dr in dt.Rows)
        //        list.Add(new Course(
        //            Convert.ToInt32(dr["CourseId"]),
        //            dr["CourseCode"].ToString(),
        //            dr["CourseDescription"].ToString(),
        //            Convert.ToInt32(dr["SubjectId"]),
        //            Convert.ToInt32(dr["InstructorId"]),
        //            Convert.ToInt32(dr["TermId"]),
        //            Convert.ToInt32(dr["CampusId"]),
        //            new Subject(Convert.ToInt32(dr["SubjectId"]), dr["SubjectCode"].ToString(), dr["SubjectName"].ToString(), Convert.ToInt32(dr["DepartmentId"])),
        //            new Instructor(Convert.ToInt32(dr["InstructorId"]), dr["InstructorFirstName"].ToString(), dr["InstructorMidName"].ToString() ,dr["InstructorLastName"].ToString(), Convert.ToInt32(dr["DepartmentId"])),
        //            new Term(Convert.ToInt32(dr["TermId"]), dr["TermName"].ToString(), dr["Description"].ToString()),
        //            new Campus(Convert.ToInt32(dr["CampusId"]), dr["CampusCode"].ToString(), dr["CampusName"].ToString(), dr["Description"].ToString())));
        //    return list;
        //}

        public static List<Course> GetAllCourses()
        {
            string sql = "select c.CourseId, c.CourseCode, c.CourseDescription, c.SubjectId, c.InstructorId,c.TermId, c.CampusID," +
                "s.SubjectName, i.InstructorLastName, t.TermName, cs.CampusName from COURSES c left join SUBJECTS s " +
                "on c.SubjectId = s.SubjectId left join INSTRUCTORS i on c.InstructorId = i.InstructorId left join TERMS t " +
                "on c.TermId = t.TermId left join CAMPUSES cs on c.CampusID = cs.CampusId";
            DataTable dt = DAO.GetDataBySql(sql);
            List<Course> list = new List<Course>();
            foreach (DataRow dr in dt.Rows)
                list.Add(new Course(
                    Convert.ToInt32(dr["CourseId"]),
                    dr["CourseCode"].ToString(),
                    dr["CourseDescription"].ToString(),
                    Convert.ToInt32(dr["SubjectId"]),
                    Convert.ToInt32(dr["InstructorId"]),
                    Convert.ToInt32(dr["TermId"]),
                    Convert.ToInt32(dr["CampusId"]),
                    dr["SubjectName"].ToString(),
                    dr["InstructorLastName"].ToString(),
                    dr["TermName"].ToString(),
                    dr["CampusName"].ToString()));
            return list;
        }

        public static List<Course> SearchBySubjects(int SubjectId)
        {
            string sql = "select c.CourseId, c.CourseCode, c.CourseDescription, c.SubjectId, c.InstructorId,c.TermId, c.CampusID," +
                "s.SubjectName, i.InstructorLastName, t.TermName, cs.CampusName from COURSES c left join SUBJECTS s " +
                "on c.SubjectId = s.SubjectId left join INSTRUCTORS i on c.InstructorId = i.InstructorId left join TERMS t " +
                "on c.TermId = t.TermId left join CAMPUSES cs on c.CampusID = cs.CampusId where c.SubjectId = @subject";
            SqlParameter parameter1 = new SqlParameter("@subject", DbType.Int32);
            parameter1.Value = SubjectId;
            DataTable dt = DAO.GetDataBySql(sql, parameter1);
            List<Course> list = new List<Course>();
            foreach (DataRow dr in dt.Rows)
                list.Add(new Course(
                    Convert.ToInt32(dr["CourseId"]),
                    dr["CourseCode"].ToString(),
                    dr["CourseDescription"].ToString(),
                    Convert.ToInt32(dr["SubjectId"]),
                    Convert.ToInt32(dr["InstructorId"]),
                    Convert.ToInt32(dr["TermId"]),
                    Convert.ToInt32(dr["CampusId"]),
                    dr["SubjectName"].ToString(),
                    dr["InstructorLastName"].ToString(),
                    dr["TermName"].ToString(),
                    dr["CampusName"].ToString()));
            return list;
        }

        public static List<Course> SearchByInstructors(int InstructorId)
        {
            string sql = "select c.CourseId, c.CourseCode, c.CourseDescription, c.SubjectId, c.InstructorId,c.TermId, c.CampusID," +
                "s.SubjectName, i.InstructorLastName, t.TermName, cs.CampusName from COURSES c left join SUBJECTS s " +
                "on c.SubjectId = s.SubjectId left join INSTRUCTORS i on c.InstructorId = i.InstructorId left join TERMS t " +
                "on c.TermId = t.TermId left join CAMPUSES cs on c.CampusID = cs.CampusId where c.InstructorId = @instructor";
            SqlParameter parameter1 = new SqlParameter("@instructor", DbType.Int32);
            parameter1.Value = InstructorId;
            DataTable dt = DAO.GetDataBySql(sql, parameter1);
            List<Course> list = new List<Course>();
            foreach (DataRow dr in dt.Rows)
                list.Add(new Course(
                    Convert.ToInt32(dr["CourseId"]),
                    dr["CourseCode"].ToString(),
                    dr["CourseDescription"].ToString(),
                    Convert.ToInt32(dr["SubjectId"]),
                    Convert.ToInt32(dr["InstructorId"]),
                    Convert.ToInt32(dr["TermId"]),
                    Convert.ToInt32(dr["CampusId"]),
                    dr["SubjectName"].ToString(),
                    dr["InstructorLastName"].ToString(),
                    dr["TermName"].ToString(),
                    dr["CampusName"].ToString()));
            return list;

        }



        public static Course GetCourseById(int CourseId)
        {
            string sql = "select c.CourseId, c.CourseCode, c.CourseDescription, c.SubjectId, c.InstructorId,c.TermId, c.CampusID,"
                + "s.SubjectName, i.InstructorLastName, t.TermName, cs.CampusName from COURSES c left join SUBJECTS s"
                + " on c.SubjectId = s.SubjectId left join INSTRUCTORS i on c.InstructorId = i.InstructorId left join TERMS t"
                + " on c.TermId = t.TermId left join CAMPUSES cs on c.CampusID = cs.CampusId where c.CourseId = @id";
            SqlParameter parameter1 = new SqlParameter("@id", DbType.Int32);
            parameter1.Value = CourseId;
            DataTable dt = DAO.GetDataBySql(sql, parameter1);
            if (dt.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                DataRow dr = dt.Rows[0];
                Course course = new Course(
                    Convert.ToInt32(dr["CourseId"]),
                    dr["CourseCode"].ToString(),
                    dr["CourseDescription"].ToString(),
                    Convert.ToInt32(dr["SubjectId"]),
                    Convert.ToInt32(dr["InstructorId"]),
                    Convert.ToInt32(dr["TermId"]),
                    Convert.ToInt32(dr["CampusId"]),
                    dr["SubjectName"].ToString(),
                    dr["InstructorLastName"].ToString(),
                    dr["TermName"].ToString(),
                    dr["CampusName"].ToString());
                return course;
            }

        }

        public static int AddCourse(string CourseCode, string Description, int SubjectId, int InstructorId, int TermId, int CampusId)
        {
            string sql = "insert into Courses values(@CourseCode, @CourseDescription, " +
                "@SubjectId, @InstructorId, @TermId, @CampusId)";
            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = new SqlParameter("@CourseCode", SqlDbType.NVarChar);
            parameters[0].Value = CourseCode;
            parameters[1] = new SqlParameter("@CourseDescription", SqlDbType.NVarChar);
            parameters[1].Value = Description;
            parameters[2] = new SqlParameter("@SubjectId", SqlDbType.Int);
            parameters[2].Value = SubjectId;
            parameters[3] = new SqlParameter("@InstructorId", SqlDbType.Int);
            parameters[3].Value = InstructorId;
            parameters[4] = new SqlParameter("@TermId", SqlDbType.Int);
            parameters[4].Value = TermId;
            parameters[5] = new SqlParameter("@CampusId", SqlDbType.Int);
            parameters[5].Value = CampusId;
            return DAO.ExecuteSql(sql, parameters);
        }

        public static int DeleteCourse(int CourseId)
        {
            string sql = "delete from Courses where CourseId = @id";
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@id", SqlDbType.Int);
            parameters[0].Value = CourseId;
            return DAO.ExecuteSql(sql, parameters);
        }

        public static int UpdateCourse(int CourseId, string CourseCode, string Description, int SubjectId, int InstructorId, int TermId, int CampusId)
        {
            string sql = "update Courses set CourseCode = @code , CourseDescription = @description " +
                ", SubjectId = @subject, InstructorId = @instructor, TermId = @term," +
                " CampusId = @campus where CourseId = @id";
            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = new SqlParameter("@code", SqlDbType.NVarChar);
            parameters[0].Value = CourseCode;
            parameters[1] = new SqlParameter("@description", SqlDbType.NVarChar);
            parameters[1].Value = Description;
            parameters[2] = new SqlParameter("@subject", SqlDbType.Int);
            parameters[2].Value = SubjectId;
            parameters[3] = new SqlParameter("@instructor", SqlDbType.Int);
            parameters[3].Value = InstructorId;
            parameters[4] = new SqlParameter("@term", SqlDbType.Int);
            parameters[4].Value = TermId;
            parameters[5] = new SqlParameter("@campus", SqlDbType.Int);
            parameters[5].Value = CampusId;
            parameters[6] = new SqlParameter("@id", SqlDbType.Int);
            parameters[6].Value = CourseId;
            return DAO.ExecuteSql(sql, parameters);
        }


    }
}
