
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
                model.Name = string.Concat(student.FirstName, " ", student.LastName);



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
                            select new StudentModel()
                            {
                                Creationdate = st.Creationdate,
                                EnrollmentDate = st.EnrollmentDate.Value,
                                Id = st.Id,
                                Name = string.Concat(st.FirstName, " ", st.LastName)
                            };


                          students = query.ToList();
                        
                          
            }
            catch (Exception ex)
            {
                throw new StudentDaoExceptions(ex.Message);
            }
            return students;
        }

        public void RemoveStudent(Student student)
        {
            try
            {
                Student? studentToRemoved = this.schoolDb.Students.Find(student.Id);
                if (studentToRemoved is null)
                    throw new StudentDaoExceptions(" El estudiante no se encuentra registrado");
                studentToRemoved.Deleted = student.Deleted;

                this.schoolDb.Students.Update(studentToRemoved);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new StudentDaoExceptions(ex.Message);
            }
        }

        public void SaveStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public void UpdateStudent(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
