

using PoliSchool.DAL.Daos;
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Interfaces
{
    public interface IDeparment

    {
        void SaveDeparment(Deparment deparment);
        void UpdateStudent(Deparment deparment);
        void RemoveStudent(Deparment deparment);

        List<Student> GetDeparments();

        StudentModel GetDeparment(int deparmentId);


    }
}
