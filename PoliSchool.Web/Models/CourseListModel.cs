namespace PoliSchool.Web.Models
{
    public class CourseListModel
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

        public DateTime Creationdate { get; set; }

        public String? CreationdateDisplay { get; set; }
        public string? DepartmentName { get; set; }

        public string? Name { get; set; }


    }
}
