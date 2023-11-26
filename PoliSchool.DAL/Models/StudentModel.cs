
namespace PoliSchool.DAL.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public DateTime EnrollmentDate { get; set; }

        public DateTime Creationdate { get; set; }

        public String CreationdateDisplay 
        {
            get { return this.Creationdate.ToString("dd/mm/yyyy"); }
        }

        public String EnrollmentDateDisplay
        {
            get { return this.EnrollmentDate.ToString("dd/mm/yyyy"); }
        }
    }
}
