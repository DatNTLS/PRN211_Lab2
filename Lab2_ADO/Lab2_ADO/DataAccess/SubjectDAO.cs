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
    internal class SubjectDAO
    {
        public static List<Subject> GetAllSubjects()
        {
            string sql = "select * from Subjects";
            DataTable dt = DAO.GetDataBySql(sql);
            List<Subject> list = new List<Subject>();
            foreach (DataRow dr in dt.Rows)
                list.Add(new Subject(
                    Convert.ToInt32(dr["SubjectId"]),
                    dr["SubjectCode"].ToString(),
                    dr["SubjectName"].ToString(),
                    Convert.ToInt32(dr["DepartmentId"])));
            return list;
        }
    }
}
