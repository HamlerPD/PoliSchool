

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
        public DeparmentModel GetDeparmentById(int DeparmentId)
        {
            DeparmentModel model = new DeparmentModel();
            try
            {
               Deparment deparments = schoolDb.Deparments.Find(DeparmentId);

                if (deparments == null)

                    throw new DeparmentDaoExceptions(" El Deparmenton no se encuentra registrado ");
                model.DepartmentID = deparments.DepartmentID;
                model.Name = deparments.Name;
                model.StartDate = deparments.StartDate.Value;
                model.Creationdate = deparments.Creationdate;
               
           
            }
            catch (Exception)
            {
               
            }
            return model;
        }

        public List<DeparmentModel> GetDeparments()
        {
            List<DeparmentModel> deparments = new List<DeparmentModel>();
            try
            {
                var query = from de in this.schoolDb.Deparments
                            select new DeparmentModel()
                            {
                                DepartmentID = de.DepartmentID,
                                Name = de.Name,
                                Budget = de.Budget,
                                StartDate = de.StartDate.Value,
                                Administrator = de.Administrator,
                                Creationdate = de.Creationdate,


                            };

                deparments = query.ToList();

            }
            catch (Exception)
            {
                
            }
            return deparments;
        }

        public void RemoveDeparment(Deparment deparment)
        {

            DeparmentModel model = new DeparmentModel();
            try
            {
                Deparment? deparmentToRemove = this.schoolDb.Deparments.Find(deparment.DepartmentID);

                if (deparmentToRemove == null)
                    throw new DeparmentDaoExceptions(" El curso no se encuentra registrado ");
                deparmentToRemove.Deleted = deparment.Deleted;
                deparmentToRemove.DeletedDate = deparment.DeletedDate;
                deparmentToRemove.UserDeleted = deparment.UserDeleted;

                this.schoolDb.Deparments.Update(deparmentToRemove);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DeparmentDaoExceptions(ex.Message);
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
                throw new DeparmentDaoExceptions(ex.Message);
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

                throw new DeparmentDaoExceptions(ex.Message);
            }
        }

    }

}
