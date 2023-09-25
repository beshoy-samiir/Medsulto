using Eva_project.Repository;
using Eva_project.Models;
namespace Eva_project.BaseService
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> courseRepo;

        public CourseService(IRepository<Course> CourseRepo)
        {
            courseRepo = CourseRepo;
        }

        public List<Course> GetCourses()
        {
            return courseRepo.GetAll();
        }
        public Course GetByID(int id)
        {
            return courseRepo.Get(id);
        }
    }
}
