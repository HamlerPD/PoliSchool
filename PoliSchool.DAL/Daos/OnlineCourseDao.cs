

using PoliSchool.DAL.Context;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Exceptions;
using PoliSchool.DAL.Interfaces;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Daos
{
    public class OnlineCourseDao : IOnlineCourseDao
    {
        private readonly SchoolDbContext schoolDb;

        public OnlineCourseDao(SchoolDbContext schoolDb)
        {
            this.schoolDb = schoolDb;
        }
        public OnlineCourseModel GetIOnlineCourseById(int courseId)
        {
            OnlineCourseModel model = new OnlineCourseModel();
            try
            {
                OnlineCourse? onlineCourse = schoolDb.OnlineCourses.Find(courseId);
                if (onlineCourse is null)
                    throw new OnlineCourseDaoExceptions(" El curso no se encuentra registrado");
                model.CourseId = onlineCourse.CourseId;
                model.Url = onlineCourse.Url;
      



            }
            catch (Exception ex)
            {
                throw new OnlineCourseDaoExceptions(ex.Message);
            }
            return model;
        }

        public List<OnlineCourseModel> GetOnlineCourse()
        {
            List<OnlineCourseModel> onlineCourses = new List<OnlineCourseModel>();
            try
            {
                var query = from Onl in this.schoolDb.OnlineCourses
                            where Onl.Deleted == false
                            select new OnlineCourseModel()
                            {
                                CourseId = Onl.CourseId,
                                Url = Onl.Url,

                            };
                onlineCourses = query.ToList();




            }
            catch (Exception)
            {
                
            }
            return onlineCourses;
        }
    }
}
