using Lab2_ADO.DataAccess;
using Lab2_ADO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_ADO.Logics
{
    internal class CourseManager
    {
        public static List<Course> GetAllCoursesFromDB()
        {
            return CourseDAO.GetAllCourses();
        }

        public static List<Course> SearchBySubjectsDB(int SubjectId)
        {
            return CourseDAO.SearchBySubjects(SubjectId);
        }

        public static List<Course> SearchByInstructorsDB(int InstructorId)
        {
            return CourseDAO.SearchByInstructors(InstructorId);
        }

        public static Course GetCourseByIdDB(int CourseId)
        {
            return CourseDAO.GetCourseById(CourseId);
        }

        public static int AddCourseDB(string CourseCode, string Description, int SubjectId, int InstructorId, int TermId, int CampusId)
        {
            return CourseDAO.AddCourse(CourseCode, Description, SubjectId, InstructorId, TermId, CampusId);
        }

        public static int DeleteCourseDB(int CourseId)
        {
            return CourseDAO.DeleteCourse(CourseId);
        }

        public static int UpdateCourseDB(int CourseId, string CourseCode, string Description, int SubjectId, int InstructorId, int TermId, int CampusId)
        {
            return CourseDAO.UpdateCourse(CourseId, CourseCode, Description, SubjectId, InstructorId, TermId, CampusId);
        }


    }
}
