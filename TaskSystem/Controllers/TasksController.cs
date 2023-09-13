using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repository.Interfaces;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : BaseController<Tasks>
    {
        public TasksController(IRepository<Tasks> repository) : base(repository)
        {
        }
    }
}
