using IMS.Web.Business.ModelEntities;
using IMS.Web.Models.ViewModel;

namespace IMS.Web.Business.Interfaces
{
    public interface IStudentService
    {
        StudentModel AddStudent(StudentModel student);
        StudentModel UpdateStudent(StudentModel student);
        bool DeleteStudent(int studentID);
        StudentModel GetStudent(int studentID);
        List<StudentModel> GetStudents();
        List<StudentModel> GetAllStudentsDetail();
    }
}
