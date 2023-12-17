

using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Interfaces
{
    public interface IOnsiteCourseDao
    {
        List<OnsiteCourseModel> GetOnsiteCourse();

        OnsiteCourseModel GetIOnsiteCourseById(int courseId);
    }
}
