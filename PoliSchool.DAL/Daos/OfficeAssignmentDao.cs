
using PoliSchool.DAL.Context;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Exceptions;
using PoliSchool.DAL.Interfaces;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Daos
{
    public class OfficeAssignmentDao : IOfficeAssignment
    {
        private readonly SchoolDbContext schoolDb;

        public OfficeAssignmentDao(SchoolDbContext schoolDb)
        {
            this.schoolDb = schoolDb;
        }

        public OfficeAssignmentModel GetOfficeAssignmenById(int instructorId)
        {
            OfficeAssignmentModel model = new OfficeAssignmentModel();
            try
            {
                OfficeAssignment? officeAssignment = schoolDb.OfficeAssignments.Find(instructorId);
                if (officeAssignment is null)
                    throw new OfficeAssignmentDaoExceptions(" La oficina no se encuentra registrada");
                model.InstructorId = officeAssignment.InstructorId;
                model.Location = officeAssignment.Location;
                model.Timestamp = officeAssignment.Timestamp;
                



            }
            catch (Exception ex)
            {
                throw new StudentDaoExceptions(ex.Message);
            }
            return model;
        }

        public List<OfficeAssignmentModel> GetOfficeAssignmens()
        {
            List<OfficeAssignmentModel> officeAssignment = new List<OfficeAssignmentModel>();
            try
            {
          


            }
            catch (Exception ex)
            {
                throw new OfficeAssignmentDaoExceptions(ex.Message);
            }
            return officeAssignment;

        }

        public void RemoveOfficeAssignment(OfficeAssignment officeAssignment)
        {
            OfficeAssignmentModel model = new OfficeAssignmentModel();
            try
            {
                OfficeAssignment? officeAssignmentToRemove = this.schoolDb.OfficeAssignments.Find(officeAssignment.InstructorId);

                if (officeAssignmentToRemove == null)
                    throw new OfficeAssignmentDaoExceptions(" La oficina no se encuentra registrada ");
                
                this.schoolDb.OfficeAssignments.Update(officeAssignmentToRemove);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CourseDaoExceptions(ex.Message);
            }
        }

        public void SaveOfficeAssignment(OfficeAssignment officeAssignment)
        {
            try
            {
                if (officeAssignment is null)
                    throw new OfficeAssignmentDaoExceptions("La oficina debe de ser instaciada.");


                this.schoolDb.OfficeAssignments.Add(officeAssignment);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new OfficeAssignmentDaoExceptions(ex.Message);
            }
        }

        public void UpdateOfficeAssignment(OfficeAssignment officeAssignment)
        {
            try
            {
                OfficeAssignment? OfficeAssigmentToUpdate = this.schoolDb.OfficeAssignments.Find(officeAssignment.InstructorId);

                if (OfficeAssigmentToUpdate is null)
                    throw new OfficeAssignmentDaoExceptions("La oficina no se encuentra registrada.");


                
                OfficeAssigmentToUpdate.InstructorId = officeAssignment.InstructorId;
                OfficeAssigmentToUpdate.Timestamp = officeAssignment.Timestamp;
                OfficeAssigmentToUpdate.Location = officeAssignment.Location;


                this.schoolDb.OfficeAssignments.Update(OfficeAssigmentToUpdate);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new OfficeAssignmentDaoExceptions(ex.Message);
            }
        }

    }
}
