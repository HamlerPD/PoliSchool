
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
        

        public StudentModel GetStudent(int studentId)
        {
            StudentModel model = new StudentModel();
            try
            {
                Student? student = schoolDb.Students.Find(studentId);
                if(student is null)
                    throw new StudentDaoExceptions(" El estudiante no se encuentra registrado");
                model.Creationdate = student.Creationdate;
                model.EnrollmentDate = student.EnrollmentDate.Value;
                model.Id = student.Id;
                model.Name = string.Concat(student.FirstName," ",student.LastName);
                 

                
            }
            catch (Exception ex)
            {
                throw new StudentDaoExceptions(ex.Message);
            }
            return model;

            
        }

        public List<Student> GetStudents()
        {
            throw new NotImplementedException();
        }

        public void RemoveStudent(Student student)
        {
            throw new NotImplementedException();
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
