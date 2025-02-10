using IMS.Web.Models.ViewModel;

namespace IMS.Web.Business.Interfaces
{
    public interface ICourseService
    {
        CourseModel AddCourse(CourseModel course);
        CourseModel UpdateCourse(CourseModel course);
        bool DeleteCourse(int courseID);
        CourseModel GetCourse(int courseID);
        List<CourseModel> GetCourses();
    }
}
