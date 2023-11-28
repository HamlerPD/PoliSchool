using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PoliSchool.DAL.Interfaces
{
    public interface IInstructor
    {
        void SaveInstructor(Instructor instructor);
        void UpdateInstructor(Instructor instructor);
        void RemoveInstructor(Instructor instructor);

        List<InstructorModel> GetInstructors();

        InstructorModel GetInstructorById(int instructorId);
    }
}
