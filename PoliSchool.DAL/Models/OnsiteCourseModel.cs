﻿
namespace PoliSchool.DAL.Models
{
    public class OnsiteCourseModel
    {
        public int CourseId { get; set; }
        public string? Location { get; set; }
        public string? Days { get; set; }
        public DateTime Time { get; set; }
    }
}
