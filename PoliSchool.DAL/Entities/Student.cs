
using PoliSchool.DAL.Entities.Base;

namespace PoliSchool.DAL.Entities
{
    public partial class Student : Person
    {
        public int Id { get; set; }

        public DateTime? EnrollmentDate { get; set; }
        public DateTime Creationdate { get; internal set; }
    }
}
