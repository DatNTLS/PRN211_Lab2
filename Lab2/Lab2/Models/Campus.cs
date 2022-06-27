using System;
using System.Collections.Generic;

#nullable disable

namespace Lab2.Models
{
    public partial class Campus
    {
        public Campus()
        {
            Courses = new HashSet<Course>();
        }

        public int CampusId { get; set; }
        public string CampusCode { get; set; }
        public string CampusName { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Course> Courses { get; set; }
    }
}
