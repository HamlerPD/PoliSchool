

using PoliSchool.DAL.Daos;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Interfaces
{
    public interface IDeparment

    {
        void SaveDeparment(Deparment deparment);
        void UpdateDeparment(Deparment deparment);
        void RemoveDeparment(Deparment deparment);

        List<DeparmentModel> GetDeparments();

        DeparmentModel GetDeparmentById(int deparmentId);


    }
}
