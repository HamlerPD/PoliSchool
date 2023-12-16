
namespace PoliSchool.DAL.Models
{
    public class InstructorModel
    {
        public int Id { get; set; }

        public DateTime? HireDate { get; set; }

        public string? Name { get; set; }

        public DateTime Creationdate { get; set; }

        public String CreationdateDisplay
        {
            get { return this.Creationdate.ToString("dd/mm/yyyy"); }
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
