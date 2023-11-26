

using PoliSchool.DAL.Context;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Exceptions;
using PoliSchool.DAL.Interfaces;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Daos
{
    internal class CourseDao : ICourseDao
    {

        private readonly SchoolDbContext schoolDb;

        public CourseDao (SchoolDbContext schoolDb)
        {
            this.schoolDb = schoolDb;
        }

        public CourseModel GetCourseById(int courseId)
        {
            CourseModel model = new CourseModel();
            try
            {
                Course? course = schoolDb.Courses.Find(courseId);

                if (course == null)
                
                    throw new CourseDaoExceptions(" El curso no se encuentra registrado ");
                model.Creationdate = course.Creationdate;
                model.CourseId = course.CourseId;
                model.Title = course.Title;
            }
            catch(Exception ex)
            {
                throw new CourseDaoExceptions(ex.Message);
            }
            return model;
        }

        public List<CourseModel> GetCourses()
        {
            throw new NotImplementedException();
        }

        public void RemoveCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public void SaveCourse(Course course)
        {
            throw new NotImplementedException();
        }

        public void UpdateCourse(Course course)
        {
            throw new NotImplementedException();
        }
    }
}
