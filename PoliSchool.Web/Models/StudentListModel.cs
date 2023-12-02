namespace PoliSchool.Web.Models
{
    public class StudentListModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public String? CreationdateDisplay{ get; set; }

        public String? EnrollmentDateDisplay{ get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
