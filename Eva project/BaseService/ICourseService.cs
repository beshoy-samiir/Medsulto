using Eva_project.Models;

namespace Eva_project.BaseService
{
    public interface ICourseService
    {
        List<Course> GetCourses();
        Course GetByID(int id);
    }
}
