﻿
using PoliSchool.DAL.Entities.Base;

using System.ComponentModel.DataAnnotations.Schema;

namespace PoliSchool.DAL.Entities
{
    [Table("OnsiteCourse")]
    public partial class OnsiteCourse : BaseEntity
    {
        public int CourseId { get; set; }
        public string? Location { get; set; }
        public string? Days { get; set; }
        public DateTime Time { get; set; }


    }
}
