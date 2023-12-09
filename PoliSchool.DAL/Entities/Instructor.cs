
using PoliSchool.DAL.Entities.Base;


namespace PoliSchool.DAL.Entities
{
    public partial class Instructor : Person
    {
     
        public int Id { get; set; }

        public DateTime? HireDate { get; set; }


    }
}
