using IMS.Web.Business.Interfaces;
using IMS.Web.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IMS.Web.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [HttpGet][Route("GetCourses")]
        public IActionResult GetCourses()
        {
            try
            {
                var courses = _courseService.GetCourses();
                if (courses == null)
                {
                    return StatusCode(StatusCodes.Status200OK, "No courses found");
                }
                return StatusCode(StatusCodes.Status200OK, courses);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while getting all courses");
            }
        }
        [HttpGet][Route("GetCourse/{courseID}")]
        public IActionResult GetCourse(int id)
        {
            try
            {
                var course = _courseService.GetCourse(id);
                if (course == null)
                {
                    return StatusCode(StatusCodes.Status200OK, "No course found");
                }
                return StatusCode(StatusCodes.Status200OK, course);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while getting course detail");
            }
        }
        [HttpPost][Route("AddCourse")]
        public IActionResult AddCourse(CourseModel course)
        {
            try
            {
                var newCourse = _courseService.AddCourse(course);
                if(newCourse == null)
                {
                    return StatusCode(StatusCodes.Status200OK, "Course not added");
                }
                return StatusCode(StatusCodes.Status200OK, newCourse);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while adding course");
            }
        }
        [HttpPut][Route("UpdateCourse")]
        public IActionResult UpdateCourse(CourseModel course)
        {
            try
            {
                var updatedCourse = _courseService.UpdateCourse(course);
                if (updatedCourse == null)
                {
                    return StatusCode(StatusCodes.Status200OK, "Course not updated");
                }
                return StatusCode(StatusCodes.Status200OK, updatedCourse);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while updating course");
            }
        }
        [HttpDelete][Route("DeleteCourse/{courseID}")]
        public IActionResult DeleteCourse(int id)
        {
            try
            {
                var isDeleted = _courseService.DeleteCourse(id);
                if (!isDeleted)
                {
                    return StatusCode(StatusCodes.Status200OK, "Course not deleted");
                }
                return StatusCode(StatusCodes.Status200OK, "Course deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while deleting course");
            }
        }
    }
}
