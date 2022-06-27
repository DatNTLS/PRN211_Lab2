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
    internal class InstructorDAO
    {
        public static List<Instructor> GetAllInstructors()
        {
            string sql = "select * from Instructors";
            DataTable dt = DAO.GetDataBySql(sql);
            List<Instructor> list = new List<Instructor>();
            foreach (DataRow dr in dt.Rows)
                list.Add(new Instructor(
                    Convert.ToInt32(dr["InstructorId"]),
                    dr["InstructorFirstName"].ToString(),
                    dr["InstructorMidName"].ToString(),
                    dr["InstructorLastName"].ToString(),
                    Convert.ToInt32(dr["DepartmentId"])));
            return list;
        }
    }
}
