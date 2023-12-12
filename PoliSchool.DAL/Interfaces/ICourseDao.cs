using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Interfaces
{
    public interface ICourseDao
    {
        void RemoveCourse(Course course);

        List<CourseModel> GetCourses();

        CourseModel GetCourseById(int courseId);

        void SaveCourse(Course course);

    }
}
