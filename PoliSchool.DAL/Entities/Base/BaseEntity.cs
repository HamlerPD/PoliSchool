using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliSchool.DAL.Entities.Base
{
    public abstract class BaseEntity
    {
        public DateTime Creationdate { get; set; }
        public DateTime? Modifydate { get; set; }
        public int CreationUser { get; set; }
        public int? UserMod { get; set; }
        public int? UserDeleted { get; set; }
        public DateTime? DeletedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
