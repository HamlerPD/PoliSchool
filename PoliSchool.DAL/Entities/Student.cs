
using PoliSchool.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace PoliSchool.DAL.Entities
{
    public partial class Student : Person
    {
        [Key]
        public int Id { get; set; }

        public DateTime? EnrollmentDate { get; set; }
    }
}
