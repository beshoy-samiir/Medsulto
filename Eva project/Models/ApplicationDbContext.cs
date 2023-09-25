using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Eva_project.Models
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
        {

        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Speciality> Speciality { get; set; }
        public DbSet<CourseSpeciality> CourseSpecialities { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasData(
                new Course() { Id = 1, PatientName = "Beshoy", EstimatedTime = "2", PracticeLevel = "1", License = "abc", InstructorId = 1, Title = "abc" },
                new Course() { Id = 2, PatientName = "Youstina", EstimatedTime = "2", PracticeLevel = "1", License = "abc", InstructorId = 1, Title = "abc"  },
                new Course() { Id = 3, PatientName = "Emad", EstimatedTime = "2", PracticeLevel = "1", License = "abc", InstructorId = 1, Title = "abc" });

            base.OnModelCreating(modelBuilder);
        }
    }
}
