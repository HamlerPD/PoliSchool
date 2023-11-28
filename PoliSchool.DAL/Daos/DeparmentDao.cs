

using PoliSchool.DAL.Context;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Exceptions;
using PoliSchool.DAL.Interfaces;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Daos
{
    public class DeparmentDao : IDeparment
    {

        private readonly SchoolDbContext schoolDb;

        public DeparmentDao(SchoolDbContext schoolDb)
        {
            this.schoolDb = schoolDb;
        }
        public DeparmentModel GetDeparmentById(int deparmentId)
        {
            DeparmentModel model = new DeparmentModel();
            try
            {
                Deparment? deparment = schoolDb.Deparments.Find(deparmentId);
                if (deparment is null)
                    throw new DeparmentDaoExceptions(" El estudiante no se encuentra registrado");
                model.Creationdate = deparment.Creationdate;
                model.StartDate = deparment.StartDate.Value;
                model.DepartmentID = deparment.DepartmentID.Value;
                model.Name = deparment.Name;
                model.Administrator = deparment.Administrator;



            }
            catch (Exception ex)
            {
                throw new DeparmentDaoExceptions(ex.Message);
            }
            return model;
        }

        public List<DeparmentModel> GetDeparments()
        {
            List<DeparmentModel> course = new List<DeparmentModel>();
            try
            {
                var query = from de in this.schoolDb.Deparments
                            where de.Deleted == false
                            select new DeparmentModel()
                            {
                                Creationdate = de.Creationdate,
                                StartDate = de.StartDate.Value,
                                DepartmentID = de.DepartmentID.Value,
                                Name = de.Name,
                                Administrator = de.Administrator,
                            };

            }
            catch (Exception ex)
            {
                throw new CourseDaoExceptions(ex.Message);
            }
            return course;
        }

        public void RemoveDeparment(Deparment deparment)
        {

            DeparmentModel model = new DeparmentModel();
            try
            {
                Deparment? deparmentToRemove = this.schoolDb.Deparments.Find(deparment.DepartmentID);

                if (deparmentToRemove == null)
                    throw new CourseDaoExceptions(" El curso no se encuentra registrado ");
                deparmentToRemove.Deleted = deparment.Deleted;
                deparmentToRemove.DeletedDate = deparment.DeletedDate;
                deparmentToRemove.UserDeleted = deparment.UserDeleted;

                this.schoolDb.Deparments.Update(deparmentToRemove);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new CourseDaoExceptions(ex.Message);
            }
        }

        public void SaveDeparment(Deparment deparment)
        {
            try
            {
                if (deparment is null)
                    throw new DeparmentDaoExceptions("El deparmento debe de ser instaciada.");


                this.schoolDb.Deparments.Add(deparment);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new StudentDaoExceptions(ex.Message);
            }

        }

        public void UpdateDeparment(Deparment deparment)
        {
            try
            {
                Deparment? deparmentToUpdate = this.schoolDb.Deparments.Find(deparment.DepartmentID);

                if (deparmentToUpdate is null)
                    throw new DeparmentDaoExceptions("El deparmento no se encuentra registrado.");


                deparmentToUpdate.Modifydate = deparment.Modifydate;
                deparmentToUpdate.UserMod = deparment.UserMod;
                deparmentToUpdate.DepartmentID = deparment.DepartmentID;
                deparmentToUpdate.Name = deparment.Name;
                deparmentToUpdate.Administrator = deparment.Administrator;
                deparmentToUpdate.Creationdate = deparment.Creationdate;
                deparmentToUpdate.StartDate = deparment.StartDate.Value;


                this.schoolDb.Deparments.Update(deparmentToUpdate);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new StudentDaoExceptions(ex.Message);
            }
        }

    }

}
