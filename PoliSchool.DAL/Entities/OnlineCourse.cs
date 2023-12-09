﻿
using PoliSchool.DAL.Entities.Base;

using System.ComponentModel.DataAnnotations.Schema;

namespace PoliSchool.DAL.Entities
{
    [Table("OnlineCourse")]
    public partial class OnlineCourse : BaseEntity
    {
  
        public int CourseId { get; set; }
        public string? Url { get; set; }


    }
}
