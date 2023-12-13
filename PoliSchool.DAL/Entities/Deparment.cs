using PoliSchool.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace PoliSchool.DAL.Entities
{
    public partial class Deparment : BaseEntity
    {
        [Key]
        public int? DepartmentID { get; set; }
        public string? Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Administrator { get; set; }


    }
}
