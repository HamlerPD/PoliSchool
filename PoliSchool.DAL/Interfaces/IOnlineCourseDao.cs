
using PoliSchool.DAL.Models;

namespace PoliSchool.DAL.Interfaces
{
    public interface IOnlineCourseDao
    {

        List<OnlineCourseModel> GetOnlineCourse();

        OnlineCourseModel GetIOnlineCourseById(int courseId);
    }
}
