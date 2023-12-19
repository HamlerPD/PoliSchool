

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
               Deparments? deparments = schoolDb.Deparments.Find(DeparmentId);

                if (deparments == null)

                    throw new DeparmentDaoExceptions(" El Deparmenton no se encuentra registrado ");
                model.DepartmentID = deparments.DepartmentID;
                model.Name = deparments.Name;
                model.StartDate = deparments.StartDate.Value;



            }
            catch (Exception ex)
            {
                throw new StudentDaoExceptions(ex.Message);
            }
            return model;
        }

        public List<DeparmentModel> GetDeparments()
        {
            List<DeparmentModel> deparments = new List<DeparmentModel>();
            try
            {
                var query = from de in this.schoolDb.Deparments
                            where de.Deleted == false
                            orderby de.StartDate descending
                            select new DeparmentModel()
                            {
                                DepartmentID = de.DepartmentID,
                                Name = de.Name,
                                Budget = de.Budget,
                                StartDate = de.StartDate.Value,
                                Administrator = de.Administrator,
                                


                            };

                deparments = query.ToList();

            }
            catch (Exception)
            {
                
            }
            return deparments;
        }

        public void RemoveDeparment(Deparments deparment)
        {

            DeparmentModel model = new DeparmentModel();
            try
            {
                Deparments? deparmentToRemove = this.schoolDb.Deparments.Find(deparment.DepartmentID);

                if (deparmentToRemove == null)
                    throw new DeparmentDaoExceptions(" El curso no se encuentra registrado ");
               

                this.schoolDb.Deparments.Update(deparmentToRemove);
                this.schoolDb.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DeparmentDaoExceptions(ex.Message);
            }
        }

        public void SaveDeparment(Deparments deparment)
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

        public void UpdateDeparment(Deparments deparment)
        {
            try
            {
                Deparments? deparmentToUpdate = this.schoolDb.Deparments.Find(deparment.DepartmentID);

                if (deparmentToUpdate is null)
                    throw new DeparmentDaoExceptions("El deparmento no se encuentra registrado.");


               
                deparmentToUpdate.DepartmentID = deparment.DepartmentID;
                deparmentToUpdate.Name = deparment.Name;
                deparmentToUpdate.Administrator = deparment.Administrator;
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
