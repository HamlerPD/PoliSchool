﻿

using System.ComponentModel.DataAnnotations.Schema;

namespace PoliSchool.DAL.Entities
{
    [Table("StudentGrade")]
    public partial class StudentGrade : Course
    {
       
        public int EnrollmentId { get; set; }
        public int StudentId { get; set; }
        public decimal? Grade { get; set; }

    }
}
