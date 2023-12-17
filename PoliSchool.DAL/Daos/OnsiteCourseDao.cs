
using PoliSchool.DAL.Context;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Exceptions;
using PoliSchool.DAL.Interfaces;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Daos
{
    public class OnsiteCourseDao : IOnsiteCourseDao
    {
        private readonly SchoolDbContext schoolDb;

        public OnsiteCourseDao(SchoolDbContext schoolDb)
        {
            this.schoolDb = schoolDb;
        }
        public OnsiteCourseModel GetIOnsiteCourseById(int courseId)
        {
            OnsiteCourseModel model = new OnsiteCourseModel();
            try
            {
                OnsiteCourse? onsiteCourse = schoolDb.OnsiteCourses.Find(courseId);
                if (onsiteCourse is null)
                    throw new OnsiteCourseExceptions(" El curso no se encuentra registrado");
                model.CourseId = onsiteCourse.CourseId;
                model.Location = onsiteCourse.Location;
                model.Days = onsiteCourse.Days;
                model.Time = onsiteCourse.Time;
               




            }
            catch (Exception ex)
            {
                throw new OnsiteCourseExceptions(ex.Message);
            }
            return model;
        }

        public List<OnsiteCourseModel> GetOnsiteCourse()
        {
            List<OnsiteCourseModel> onsiteCourses = new List<OnsiteCourseModel>();
            try
            {
                var query = from Ons in this.schoolDb.OnsiteCourses
                           
                            select new OnsiteCourseModel()
                            {
                                CourseId = Ons.CourseId,
                                Location = Ons.Location,
                                Days = Ons.Days,
                                Time = Ons.Time,
                            };


                onsiteCourses = query.ToList();


            }
            catch (Exception)
            {

            }
            return onsiteCourses;
        }
    }
}
