
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

        public List<InstructorModel> GetInstructors()
        {
            List<InstructorModel> instructors = new List<InstructorModel>();
            try
            {
                var query = from ins in this.schoolDb.Instructors
                            where ins.Deleted == false
                            select new InstructorModel()
                            {
                                Creationdate = ins.Creationdate,
                                HireDate = ins.HireDate,
                                Id= ins.Id,
                                Name = string.Concat(ins.FirstName, " ", ins.LastName)

                            };
                instructors = query.ToList();

            }
            catch (Exception)
            {
               
            }
            return instructors;
        }

        public void RemoveInstructor(Instructor instructor)
        {
            InstructorModel model = new InstructorModel();
            try
            {
                Instructor? instructorToRemove = this.schoolDb.Instructors.Find(instructor.Id);

                if (instructorToRemove is null)
                    throw new InstructorDaoExceptions(" El instructor no se encuentra registrado ");
                instructorToRemove.Deleted = instructor.Deleted;
                instructorToRemove.DeletedDate = instructor.DeletedDate;
                instructorToRemove.UserDeleted = instructor.UserDeleted;

                this.schoolDb.Instructors.Update(instructorToRemove);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CourseDaoExceptions(ex.Message);
            }
        }

        public void SaveInstructor(Instructor instructor)
        {
            try
            {
                if (instructor is null)
                    throw new InstructorDaoExceptions("El instructor debe de ser instaciada.");


                this.schoolDb.Instructors.Add(instructor);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new StudentDaoExceptions(ex.Message);
            }
        }

        public void UpdateInstructor(Instructor instructor)
        {
            try
            {
                Instructor? instructorToUpdate = this.schoolDb.Instructors.Find(instructor.Id);

                if (instructorToUpdate is null)
                    throw new InstructorDaoExceptions("El deparmento no se encuentra registrado.");


                instructorToUpdate.Modifydate = instructor.Modifydate;
                instructorToUpdate.UserMod = instructor.UserMod;
                instructorToUpdate.Id = instructor.Id;
                instructorToUpdate.FirstName = instructor.FirstName;
                instructorToUpdate.LastName = instructor.LastName;
                instructorToUpdate.Creationdate = instructor.Creationdate;
                instructorToUpdate.HireDate = instructor.HireDate.Value;


                this.schoolDb.Instructors.Update(instructorToUpdate);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new StudentDaoExceptions(ex.Message);
            }
        }
    }
}
