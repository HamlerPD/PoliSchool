

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
            throw new NotImplementedException();
        }

        public void RemoveDeparment(Deparment deparment)
        {
            throw new NotImplementedException();
        }

        public void SaveDeparment(Deparment deparment)
        {
            throw new NotImplementedException();
        }

        public void UpdateDeparment(Deparment deparment)
        {
            throw new NotImplementedException();
        }

    }

}
