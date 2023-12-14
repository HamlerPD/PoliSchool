using PoliSchool.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoliSchool.DAL.Entities
{

    [Table("Deparment")]
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
