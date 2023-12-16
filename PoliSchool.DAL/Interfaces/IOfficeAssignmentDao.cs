using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliSchool.DAL.Interfaces
{
    public interface IOfficeAssignmentDao
    {
        void SaveOfficeAssignment(OfficeAssignment officeAssignment);
        void UpdateOfficeAssignment(OfficeAssignment officeAssignment);
        void RemoveOfficeAssignment(OfficeAssignment officeAssignment);

        List<OfficeAssignmentModel> GetOfficeAssignmens();

        OfficeAssignmentModel GetOfficeAssignmenById(int instructorId);
    }
}
