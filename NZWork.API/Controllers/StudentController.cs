using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace NZWork.API.Controllers
{
    //http://hocalhost:portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        //GET:http://hocalhost:portnumber/api/students
        [HttpGet]
        public IActionResult GetAllStudent()
        {
            string[] studentName = new string[] { "suresh", "malki", "ganga" };
            return Ok(studentName);
        }
    }
}
