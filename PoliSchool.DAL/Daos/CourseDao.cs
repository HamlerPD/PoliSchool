

using PoliSchool.DAL.Context;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Exceptions;
using PoliSchool.DAL.Interfaces;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Daos
{
    public class CourseDao : ICourseDao
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
            catch(Exception)
            {
                
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
                           
                            course = query.ToList();

            }
            catch(Exception)
            {
                
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

                this.schoolDb.Courses.Update(courseToRemove);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CourseDaoExceptions(ex.Message);
            }
        }

        public void SaveCourse(Course course)
        {
            try
            {
                if (course is null)
                    throw new CourseDaoExceptions("El curso debe de ser instaciada.");


                this.schoolDb.Courses.Add(course);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CourseDaoExceptions(ex.Message);
            }
        }

        public void UpdateCourse(Course course)
        {
            try
            {
                Course? courseToUpdate = this.schoolDb.Courses.Find(course.CourseId);

                if (courseToUpdate is null)
                    throw new CourseDaoExceptions("El Curso no se encuentra registrado.");



                courseToUpdate.Title = course.Title;
                courseToUpdate.Modifydate = course.Modifydate;
                courseToUpdate.UserMod = course.UserMod;
                courseToUpdate.CourseId = course.CourseId;
                courseToUpdate.Creationdate = course.Creationdate;


                this.schoolDb.Courses.Update(courseToUpdate);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new StudentDaoExceptions(ex.Message);
            }
        }
    }
}
