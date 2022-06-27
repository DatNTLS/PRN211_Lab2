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
    internal class TermDAO
    {
        public static List<Term> GetAllTerms()
        {
            string sql = "select TermId, TermName, Description  from Terms";
            DataTable dt = DAO.GetDataBySql(sql);
            List<Term> list = new List<Term>();
            foreach (DataRow dr in dt.Rows)
                list.Add(new Term(
                    Convert.ToInt32(dr["TermId"]),
                    dr["TermName"].ToString(),
                    dr["Description"].ToString()));
            return list;
        }
    }
}
