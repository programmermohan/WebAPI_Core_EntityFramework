using IMS.Web.Business.ModelEntities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS.Web.Business.Common
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id = 1,
                RoleName = "Admin",
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "Sachin",
                Password = "Sachin@123",
                RoleId = 1
            });

            modelBuilder.Entity<StudentCourse>()
            .HasKey(sc => new { sc.StudentID, sc.CourseID }); // Composite Primary Key

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)
                .WithMany(s => s.StudentCourses) // Fix for CS0266 and CS1662
                .HasForeignKey(sc => sc.StudentID);

            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)
                .WithMany(c => c.StudentCourses)
                .HasForeignKey(sc => sc.CourseID);
        }
    }
}
