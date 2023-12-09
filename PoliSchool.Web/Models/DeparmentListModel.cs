namespace PoliSchool.Web.Models
{
    public class DeparmentListModel
    {
        public int DepartmentID { get; set; }
        public string? Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime Creationdate { get; set; }

        public int? Administrator { get; set; }

        public String CreationdateDisplay
        {
            get { return this.Creationdate.ToString("dd/mm/yyyy"); }
        }
    }
}
