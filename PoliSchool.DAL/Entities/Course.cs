
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PoliSchool.DAL.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoliSchool.DAL.Entities
{
    [Table("Course")]
    public partial class Course : BaseEntity
    {
        [Key]
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }
    }
}
