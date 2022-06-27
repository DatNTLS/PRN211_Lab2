using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_ADO.Models
{
    internal class Course
    {
        public int CourseId { get; set; }
        public string CourseCode { get; set; }
        public string CourseDescription { get; set; }
        public int SubjectId { get; set; }
        public int InstructorId { get; set; }
        public int TermId { get; set; }

        public int CampusId { get; set; }

        //public Subject Subject { get; set; }

        //public Instructor Instructor { get; set; }

        //public Term Term { get; set; }

        //public Campus Campus { get; set; }

        public string SubjectName { get; set; }

        public string InstructorName { get; set; }

        public string TermName { get; set; }

        public string CampusName { get; set; }

        public Course()
        {
        }

        //public Course(int courseId, string courseCode, string courseDescription, int subjectId, int instructorId, int termId, int campusId, Subject subject, Instructor instructor, Term term, Campus campus)
        //{
        //    CourseId = courseId;
        //    CourseCode = courseCode;
        //    CourseDescription = courseDescription;
        //    SubjectId = subjectId;
        //    InstructorId = instructorId;
        //    TermId = termId;
        //    CampusId = campusId;
        //    Subject = subject;
        //    Instructor = instructor;
        //    Term = term;
        //    Campus = campus;
        //}

        public Course(int courseId, string courseCode, string courseDescription, int subjectId, int instructorId, int termId, int campusId, string subjectName, string instructorName, string termName, string campusName)
        {
            CourseId = courseId;
            CourseCode = courseCode;
            CourseDescription = courseDescription;
            SubjectId = subjectId;
            InstructorId = instructorId;
            TermId = termId;
            CampusId = campusId;
            SubjectName = subjectName;
            InstructorName = instructorName;
            TermName = termName;
            CampusName = campusName;
        }
    }
}
