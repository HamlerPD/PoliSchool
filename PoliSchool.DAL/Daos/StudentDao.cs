
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PoliSchool.DAL.Context;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Exceptions;
using PoliSchool.DAL.Interfaces;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Daos
{
    public class StudentDao : IStudentDao
    {
        private readonly SchoolDbContext schoolDb;

        public StudentDao(SchoolDbContext schoolDb)
        {
            this.schoolDb = schoolDb;
        }

        public StudentModel GetStudentById(int studentId)
        {
            StudentModel model = new StudentModel();
            try
            {
                Student? student = schoolDb.Students.Find(studentId);
                if (student is null)
                    throw new StudentDaoExceptions(" El estudiante no se encuentra registrado");
                model.Creationdate = student.Creationdate;
                model.EnrollmentDate = student.EnrollmentDate.Value;
                model.Id = student.Id;
                model.FirstName = student.FirstName;
                model.LastName = student.LastName;





            }
            catch (Exception ex)
            {
                throw new StudentDaoExceptions(ex.Message);
            }
            return model;


        }

        public List<StudentModel> GetStudents()
        {
            List<StudentModel> students = new List<StudentModel>();
            try
            {
                var query = from st in this.schoolDb.Students
                            where st.Deleted == false
                            orderby st.Creationdate descending
                            select new StudentModel()
                            {
                                Creationdate = st.Creationdate,
                                EnrollmentDate = st.EnrollmentDate.Value,
                                Id = st.Id,
                                FirstName = st.FirstName,
                                LastName = st.LastName
                            };


                students = query.ToList();
                        
                          
            }
            catch (Exception)
            {
                
            }
            return students;
        }

        public void RemoveStudent(Student student)
        {
            try
            {
                Student? studentToRemove = this.schoolDb.Students.Find(student.Id);

                if (studentToRemove is null)
                    throw new StudentDaoExceptions("El estudiante no se encuentra registrado.");


                studentToRemove.Deleted = student.Deleted;
                studentToRemove.DeletedDate = student.DeletedDate;
                studentToRemove.UserDeleted = student.UserDeleted;

                this.schoolDb.Students.Update(studentToRemove);
                this.schoolDb.SaveChanges();

            }
            catch (Exception ex)
            {

                throw new StudentDaoExceptions(ex.Message);
            }
        }

        public void SaveStudent(Student student)
        {
            try
            {
                if (student is null)
                    throw new StudentDaoExceptions("la clase debe de ser instaciada.");


                this.schoolDb.Students.Add(student);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new StudentDaoExceptions(ex.Message);
            }


        }

        public void UpdateStudent(Student student)
        {
            try
            {
                Student? studentToUpdate = this.schoolDb.Students.Find(student.Id);

                if (studentToUpdate is null)
                    throw new StudentDaoExceptions("El estudiante no se encuentra registrado.");


                studentToUpdate.Modifydate = student.Modifydate;
                studentToUpdate.UserMod = student.UserMod;
                studentToUpdate.Id = student.Id;
                studentToUpdate.LastName = student.LastName;
                studentToUpdate.FirstName = student.FirstName;
                studentToUpdate.EnrollmentDate = student.EnrollmentDate.Value;


                this.schoolDb.Students.Update(studentToUpdate);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new StudentDaoExceptions(ex.Message);
            }



        }
    }
}
