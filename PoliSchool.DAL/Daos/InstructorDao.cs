
using PoliSchool.DAL.Context;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Exceptions;
using PoliSchool.DAL.Interfaces;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Daos
{
    public class InstructorDao : IInstructor
    {
        private readonly SchoolDbContext schoolDb;

        public InstructorDao(SchoolDbContext schoolDb)
        {
            this.schoolDb = schoolDb;
        }
        public InstructorModel GetInstructorById(int instructorId)
        {
            InstructorModel model = new InstructorModel();
            try
            {
                Instructor? instructor = schoolDb.Instructors.Find(instructorId);
                if (instructor is null)
                    throw new InstructorDaoExceptions(" El instructor no se encuentra registrado");
                model.Creationdate = instructor.Creationdate;
                model.HireDate = instructor.HireDate.Value;
                model.Id = instructor.Id;
                model.Name = string.Concat(instructor.FirstName, " ", instructor.LastName);
               



            }
            catch (Exception ex)
            {
                throw new InstructorDaoExceptions(ex.Message);
            }
            return model;
        }

        public List<InstructorModel> GetStudents()
        {
            throw new NotImplementedException();
        }

        public void RemoveInstructor(Instructor instructor)
        {
            throw new NotImplementedException();
        }

        public void SaveInstructor(Instructor instructor)
        {
            throw new NotImplementedException();
        }

        public void UpdateInstructor(Instructor instructor)
        {
            throw new NotImplementedException();
        }
    }
}
