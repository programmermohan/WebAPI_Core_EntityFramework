using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IMS.Web.Business.ModelEntities
{
    public class Course
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }
        public decimal CourseFees { get; set; }
        public IList<Student> Students { get; set; }
        public IList<StudentCourse> StudentCourses { get; set; }
    }
}
