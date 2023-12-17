

using PoliSchool.DAL.Daos;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Interfaces
{
    public interface IDeparment

    {
        void SaveDeparment(Deparments deparment);
        void UpdateDeparment(Deparments deparment);
        void RemoveDeparment(Deparments deparment);

        List<DeparmentModel> GetDeparments();

        DeparmentModel GetDeparmentById(int deparmentId);


    }
}
