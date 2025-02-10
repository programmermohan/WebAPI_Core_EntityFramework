using IMS.Web.Business.Common;
using IMS.Web.Business.Interfaces;
using IMS.Web.Business.ModelEntities;
using IMS.Web.Models.ViewModel;

namespace IMS.Web.Business.Implementation
{
    public class CourseService : ICourseService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public CourseService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public CourseModel AddCourse(CourseModel course)
        {
            var courseEntity = new Course()
            {
                CourseName = course.CourseName,
                Description = course.Description,
                CourseFees = course.CourseFee
            };
            _applicationDbContext.Courses.Add(courseEntity);
            _applicationDbContext.SaveChanges();
            course.CourseId = courseEntity.CourseID;
            return course;
        }

        public bool DeleteCourse(int courseID)
        {
            var course = _applicationDbContext.Courses.FirstOrDefault(x => x.CourseID == courseID);
            if(course != null)
            {
                _applicationDbContext.Courses.Remove(course);
                _applicationDbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public CourseModel GetCourse(int courseID)
        {
            var course = _applicationDbContext.Courses.Where(a => a.CourseID == courseID).Select(x => new CourseModel()
            {
                CourseId = x.CourseID,
                CourseName = x.CourseName,
                Description = x.Description,
                CourseFee = x.CourseFees
            }).FirstOrDefault();
            return course;
        }

        public List<CourseModel> GetCourses()
        {
            var courses = _applicationDbContext.Courses.Select(x => new CourseModel()
            {
                CourseId = x.CourseID,
                CourseName = x.CourseName,
                Description = x.Description,
                CourseFee = x.CourseFees
            }).ToList();
            return courses;
        }

        public CourseModel UpdateCourse(CourseModel course)
        {
            var courseEntity = _applicationDbContext.Courses.FirstOrDefault(x => x.CourseID == course.CourseId);
            if (courseEntity != null)
            {
                courseEntity.CourseName = course.CourseName;
                courseEntity.Description = course.Description;
                courseEntity.CourseFees = course.CourseFee;
                _applicationDbContext.SaveChanges();
            }
            return course;
        }
    }
}
