
using PoliSchool.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoliSchool.DAL.Entities
{
    [Table("OfficeAssignment")]
    public partial class OfficeAssignment : BaseEntity
    {
        
        public int InstructorId { get; set; }
        public string? Location { get; set; }
        public byte[]? Timestamp { get; set; }


    }
}
