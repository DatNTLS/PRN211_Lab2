using Lab2_ADO.DataAccess;
using Lab2_ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_ADO.Logics
{
    internal class InstructorManager
    {
        public static List<Instructor> GetAllInstructorsFromDB()
        {
            return InstructorDAO.GetAllInstructors();
        }
    }
}
