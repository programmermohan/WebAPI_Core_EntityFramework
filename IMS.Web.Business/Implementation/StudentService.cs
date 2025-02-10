using IMS.Web.Business.Common;
using IMS.Web.Business.Interfaces;
using IMS.Web.Business.ModelEntities;
using IMS.Web.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Web.Business.Implementation
{
    public class StudentService : IStudentService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public StudentService(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }
        public StudentModel AddStudent(StudentModel student)
        {
            var studentEntity = new Student()
            {
                StudentName = student.StudentName,
                DateOfBirth = student.DateOfBirth,
                Email = student.Email,
                Address = student.Address,
                StudentCourses = new List<StudentCourse>(),
            };
            _applicationDbContext.Students.Add(studentEntity);
            _applicationDbContext.SaveChanges();
            student.StudentID = studentEntity.StudentID;

            //var existingCourses = _applicationDbContext.Courses.Where(a=> student.Courses.Select(c=> c.CourseId).Contains(a.CourseID)).ToList();

            var courses = student.Courses.Select(a=> a.CourseId).ToList();
            foreach (var item in courses)
            {
                var studentCourse = new StudentCourse()
                {
                    StudentID = studentEntity.StudentID,
                    CourseID = item
                };
                _applicationDbContext.StudentCourses.Add(studentCourse);
            }

            return student;
        }

        public bool DeleteStudent(int studentID)
        {
            var student = _applicationDbContext.Students.FirstOrDefault(x => x.StudentID == studentID);
            if (student != null)
            {
                _applicationDbContext.Students.Remove(student);
                _applicationDbContext.SaveChanges();
                return true;
            }
            return false;
        }
        public StudentModel GetStudent(int studentID)
        {
            var student = _applicationDbContext.Students.Where(a => a.StudentID == studentID).Select(x => new StudentModel()
            {
                StudentID = x.StudentID,
                StudentName = x.StudentName,
                DateOfBirth = x.DateOfBirth,
                Email = x.Email,
                Address = x.Address
            }).FirstOrDefault();
            return student;
        }

        public List<StudentModel> GetStudents()
        {
            var students = _applicationDbContext.Students.Select(x => new StudentModel()
            {
                StudentID = x.StudentID,
                StudentName = x.StudentName,
                DateOfBirth = x.DateOfBirth,
                Email = x.Email,
                Address = x.Address
            }).ToList();
            return students;
        }

        public StudentModel UpdateStudent(StudentModel student)
        {
            var studentEntity = _applicationDbContext.Students.FirstOrDefault(x => x.StudentID == student.StudentID);
            if (studentEntity != null)
            {
                studentEntity.StudentName = student.StudentName;
                studentEntity.DateOfBirth = student.DateOfBirth;
                studentEntity.Email = student.Email;
                studentEntity.Address = student.Address;

                foreach (var item in studentEntity.Courses)
                {
                    studentEntity.Courses.Remove(item);
                }
                var updatedCourses = student.Courses.Select(x => new Course()
                {
                    CourseID = x.CourseId,
                    CourseName = x.CourseName,
                    Description = x.Description,
                    CourseFees = x.CourseFee
                }).ToList();

                foreach (var item in updatedCourses)
                {
                    studentEntity.Courses.Add(item);
                }

                _applicationDbContext.SaveChanges();
            }
            return student;
        }
        public List<StudentModel> GetAllStudentsDetail()
        {
            var students = _applicationDbContext.Students.Select(x => new StudentModel()
            {
                StudentID = x.StudentID,
                StudentName = x.StudentName,
                DateOfBirth = x.DateOfBirth,
                Email = x.Email,
                Address = x.Address,
                Courses = x.Courses.Select(y => new CourseModel()
                {
                    CourseId = y.CourseID,
                    CourseName = y.CourseName,
                    Description = y.Description,
                    CourseFee = y.CourseFees
                }).ToList()
            }).ToList();

            return students;
        }
    }
}
