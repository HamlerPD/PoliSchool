

namespace PoliSchool.DAL.Models
{
    public class CourseModel
    {
        public int CourseId { get; set; }
        public string? Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentId { get; set; }

        public DateTime Creationdate { get; set; }

        public String CreationdateDisplay
        {
            get { return this.Creationdate.ToString("dd/mm/yyyy"); }
        }
    }
}
