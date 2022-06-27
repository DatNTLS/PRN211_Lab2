using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_ADO.Models
{
    internal class Term
    {
        public int TermId { get; set; }
        public string TermName { get; set; }
        //public DateTime FromDate { get; set; }
        //public DateTime ToDate { get; set; }

        public string Description { get; set; }

        public Term()
        {
        }

        public Term(int termId, string termName, string description)
        {
            TermId = termId;
            TermName = termName;
            Description = description;
        }

    }
}
