

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
                model.Credits = course.Credits;
            }
            catch(Exception ex)
            {
                throw new CourseDaoExceptions(ex.Message);
            }
            return model;
        }

        public List<CourseModel> GetCourses()
        {
            List<CourseModel> course = new List<CourseModel>();
            try
            {
                var query = from co in this.schoolDb.Courses
                            where co.Deleted == false
                            orderby co.Creationdate descending
                            select new CourseModel()
                            {
                                Creationdate= co.Creationdate,
                                CourseId = co.CourseId,
                                Title = co.Title,
                                Credits = co.Credits,
                            };

            }
            catch(Exception ex)
            {
                throw new CourseDaoExceptions(ex.Message);
            }
            return course;
        } 

        public void RemoveCourse(Course course)
        {
            CourseModel model = new CourseModel();
            try
            {
                Course? courseToRemove = this.schoolDb.Courses.Find(course.CourseId);

                if (courseToRemove == null)
                    throw new CourseDaoExceptions(" El curso no se encuentra registrado ");
                courseToRemove.Deleted = course.Deleted;
                courseToRemove.DeletedDate = course.DeletedDate;
                courseToRemove.UserDeleted = course.UserDeleted;
            }
            catch (Exception ex)
            {
                throw new CourseDaoExceptions(ex.Message);
            }
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
