using AutoMapper;
using Eva_project.DTOS;
using Eva_project.Models;

namespace Eva_project.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig() 
        {
            CreateMap<Course, AllCoursesDTO>().ReverseMap();
            CreateMap<Course, CourseDetailsDTO>().ReverseMap();
        }
    }
}
