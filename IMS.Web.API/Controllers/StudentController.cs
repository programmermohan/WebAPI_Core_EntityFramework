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
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet][Route("GetStudents")]
        public IActionResult GetStudents()
        {
            try
            {
                var students = _studentService.GetStudents();
                if (students == null)
                {
                    return StatusCode(StatusCodes.Status200OK, "No students found");
                }
                return StatusCode(StatusCodes.Status200OK, students);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while getting all students");
            }
        }

        [HttpGet][Route("GetStudent/{studentID}")]
        public IActionResult GetStudent(int id)
        {
            try
            {
                var student = _studentService.GetStudent(id);
                if (student == null)
                {
                    return StatusCode(StatusCodes.Status200OK, "No student found");
                }
                return StatusCode(StatusCodes.Status200OK, student);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while getting student detail");
            }
        }
        [HttpPost][Route("AddStudent")]
        public IActionResult AddStudent(StudentModel student)
        {
            try
            {
                var newStudent = _studentService.AddStudent(student);
                if (newStudent == null)
                {
                    return StatusCode(StatusCodes.Status200OK, "Student not added");
                }
                return StatusCode(StatusCodes.Status200OK, newStudent);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while adding student");
            }
        }
        [HttpDelete][Route("DeleteStudent/{studentID}")]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                var isDeleted = _studentService.DeleteStudent(id);
                if (!isDeleted)
                {
                    return StatusCode(StatusCodes.Status200OK, "Student not deleted");
                }
                return StatusCode(StatusCodes.Status200OK, "Student deleted");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while deleting student");
            }
        }
        [HttpPut][Route("UpdateStudent")]
        public IActionResult UpdateStudent(StudentModel student)
        {
            try
            {
                var updatedStudent = _studentService.UpdateStudent(student);
                if (updatedStudent == null)
                {
                    return StatusCode(StatusCodes.Status200OK, "Student not updated");
                }
                return StatusCode(StatusCodes.Status200OK, updatedStudent);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while updating student");
            }
        }

        [HttpGet][Route("GetAllStudentsDetail")]
        public IActionResult GetAllStudentsDetail()
        {
            try
            {
                var students = _studentService.GetAllStudentsDetail();
                if (students == null)
                {
                    return StatusCode(StatusCodes.Status200OK, "No students found");
                }
                return StatusCode(StatusCodes.Status200OK, students);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occured while getting all students detail");
            }
        }
    }
}
