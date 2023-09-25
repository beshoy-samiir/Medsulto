using Eva_project.DTOS;
using Eva_project.Models;

namespace Eva_project.BussinessService
{
    public interface ICourseBusinessService
    {
        List<AllCoursesDTO> GetCourses();
        CourseDetailsDTO GetByID(int id);
    }
}
