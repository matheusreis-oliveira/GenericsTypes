using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<User>> GetAllUsers() 
        {
            return Ok();
        }
    }
}
