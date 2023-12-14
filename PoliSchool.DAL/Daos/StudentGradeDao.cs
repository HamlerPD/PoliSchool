
using PoliSchool.DAL.Context;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Exceptions;
using PoliSchool.DAL.Interfaces;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Daos
{
    public class StudentGradeDao : IStudentGradeDao
    {

        private readonly SchoolDbContext schoolDb;

        public StudentGradeDao(SchoolDbContext schoolDb)
        {
            this.schoolDb = schoolDb;
        }
        public StudentGradeModel GetStudentGradeById(int courseId)
        {
            StudentGradeModel model = new StudentGradeModel();
            try
            {
                StudentGrade? studentGrade = schoolDb.StudentGrades.Find(courseId);
                if (studentGrade is null)
                    throw new StudentGradeDaoExceptions(" El grado no se encuentra registrado");
                model.CourseId = studentGrade.CourseId;
                model.EnrollmentId = studentGrade.EnrollmentId;
                model.StudentId = studentGrade.StudentId;
                model.Grade = studentGrade.Grade;
       



            }
            catch (Exception)
            {
                
            }
            return model;
        }

        public List<StudentGradeModel> GetStudentGrades()
        {
            List<StudentGradeModel> studentGrade = new List<StudentGradeModel>();
            try
            {
                var query = from stg in this.schoolDb.StudentGrades
                            where stg.Deleted == false
                            select new StudentGradeModel()
                            {
                                EnrollmentId = stg.EnrollmentId,
                                CourseId = stg.CourseId,
                                StudentId = stg.StudentId,
                                Grade = stg.Grade,
                            };


                studentGrade = query.ToList();


            }
            catch (Exception ex)
            {
                throw new StudentGradeDaoExceptions(ex.Message);
            }
            return studentGrade;
        }

        public void RemoveStudentGrade(StudentGrade studentGrade)
        {
            try
            {
                StudentGrade? studentGradeToRemove = this.schoolDb.StudentGrades.Find(studentGrade.CourseId);

                if (studentGradeToRemove is null)
                    throw new StudentGradeDaoExceptions("El Grado no se encuentra registrado.");


                studentGradeToRemove.Deleted = studentGrade.Deleted;
                studentGradeToRemove.DeletedDate = studentGrade.DeletedDate;
                studentGradeToRemove.UserDeleted = studentGrade.UserDeleted;

                this.schoolDb.StudentGrades.Update(studentGradeToRemove);
                this.schoolDb.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new StudentGradeDaoExceptions(ex.Message);
            }
        }

        public void SaveStudentGrade(StudentGrade studentGrade)
        {
            try
            {
                if (studentGrade is null)
                    throw new StudentGradeDaoExceptions("El grado debe de ser instaciada.");


                this.schoolDb.StudentGrades.Add(studentGrade);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new StudentGradeDaoExceptions(ex.Message);
            }
        }

        public void UpdateStudentGrade(StudentGrade studentGrade)
        {
            try
            {
                StudentGrade? studentGradeToUpdate = this.schoolDb.StudentGrades.Find(studentGrade.CourseId);

                if (studentGradeToUpdate is null)
                    throw new StudentGradeDaoExceptions("El grado no se encuentra registrado.");


                studentGradeToUpdate.Modifydate = studentGrade.Modifydate;
                studentGradeToUpdate.UserMod = studentGrade.UserMod;
                studentGradeToUpdate.CourseId = studentGrade.CourseId;
                studentGradeToUpdate.StudentId = studentGrade.StudentId;
                studentGradeToUpdate.EnrollmentId = studentGrade.EnrollmentId;
                studentGradeToUpdate.Grade = studentGrade.Grade;


                this.schoolDb.StudentGrades.Update(studentGradeToUpdate);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new StudentGradeDaoExceptions(ex.Message);
            }
        }
    }
}
