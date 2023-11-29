
using PoliSchool.DAL.Entities;
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Interfaces
{
    public interface IStudentGradeDao
    {
        void SaveStudentGrade(StudentGrade studentGrade);
        void UpdateStudentGrade(StudentGrade studentGrade);
        void RemoveStudentGrade(StudentGrade studentGrade);

        List<StudentGradeModel> GetStudentGrades();

        StudentGradeModel GetStudentGradeById(int courseId);
    }
}
