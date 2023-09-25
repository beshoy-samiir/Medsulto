using Eva_project.BussinessService;
using Eva_project.Models;
using Eva_project.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Eva_project.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class CoursesController : ControllerBase
    {
        private readonly ICourseBusinessService courseBusiness;

        public CoursesController(ICourseBusinessService CourseBusiness)
        {
            courseBusiness = CourseBusiness;
        }

        [HttpGet]
        public IActionResult GetAllCourses()
        {
            return Ok(courseBusiness.GetCourses());
        }
        [HttpGet]
        public IActionResult GetCourseByID([FromQuery] int id)
        {
            return Ok(courseBusiness.GetByID(id));
        }
    }
}
