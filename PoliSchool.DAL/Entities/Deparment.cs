using PoliSchool.DAL.Entities.Base;

namespace PoliSchool.DAL.Entities
{
    public partial class Deparment : BaseEntity
    {
        public int? DepartmentID { get; set; }
        public string? Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Administrator { get; set; }


    }
}
