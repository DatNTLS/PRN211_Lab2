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
    internal class CampusDAO
    {
        public static List<Campus> GetAllCampuses()
        {
            string sql = "select * from Campuses";
            DataTable dt = DAO.GetDataBySql(sql);
            List<Campus> list = new List<Campus>();
            foreach (DataRow dr in dt.Rows)
                list.Add(new Campus(
                    Convert.ToInt32(dr["CampusId"]),
                    dr["CampusCode"].ToString(),
                    dr["CampusName"].ToString(),
                    dr["Description"].ToString()));
            return list;
        }
    }
}
