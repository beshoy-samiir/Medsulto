using AutoMapper;
using Eva_project.BaseService;
using Eva_project.DTOS;
using Eva_project.Models;
using Eva_project.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace Eva_project.BussinessService
{
    public class CourseBusinessService : ICourseBusinessService
    {

        private readonly ICourseService courseService;
        private readonly IMapper _mapper;


        public CourseBusinessService(IMapper mapper, ICourseService CourseService)
        {
            courseService = CourseService;
            this._mapper = mapper;
        }

        public List<AllCoursesDTO> GetCourses()
        {
            List<Course> courseList = courseService.GetCourses();
            //List<AllCoursesDTO> coursesDto = new List<AllCoursesDTO>();
            //foreach (Course course in courseList)
            //{
            //    AllCoursesDTO obj = new AllCoursesDTO();
            //    obj.Title = course.Title;
            //    obj.EstimatedTime = course.EstimatedTime;
            //    obj.LevelOfPractice = course.PracticeLevel;
            //    obj.License = course.License;
            //    coursesDto.Add(obj);
            //}
            var records = _mapper.Map<List<AllCoursesDTO>>(courseList);
            return records;
        }
        public CourseDetailsDTO GetByID(int id)
        {
            Course courseDetails =  courseService.GetByID(id);
            //CourseDetailsDTO courseDetailsDto = new CourseDetailsDTO();
            //Course course = new Course();
            //CourseDetailsDTO obj = new CourseDetailsDTO();
            //courseDetailsDto.Title = courseDetails.Title;
            //courseDetailsDto.EstimatedTime = courseDetails.EstimatedTime;
            //courseDetailsDto.LevelOfPractice = courseDetails.PracticeLevel;
            //courseDetailsDto.License = courseDetails.License;
            var records = _mapper.Map<CourseDetailsDTO>(courseDetails);
            return records;
        }
    }
}
