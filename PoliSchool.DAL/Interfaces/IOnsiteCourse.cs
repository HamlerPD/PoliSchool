

using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Interfaces
{
    public interface IOnsiteCourse
    {
        List<OnsiteCourseModel> GetOnsiteCourse();

        OnsiteCourseModel GetIOnsiteCourseById(int courseId);
    }
}
