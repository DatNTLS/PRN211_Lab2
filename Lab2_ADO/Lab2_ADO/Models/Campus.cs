using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_ADO.Models
{
    internal class Campus
    {
        public int CampusId { get; set; }
        public string CampusCode { get; set; }
        public string CampusName { get; set; }

        public string Description { get; set; }

        public Campus()
        {
        }

        public Campus(int campusId, string campusCode, string campusName, string description)
        {
            CampusId = campusId;
            CampusCode = campusCode;
            CampusName = campusName;
            Description = description;
        }

    }
}
