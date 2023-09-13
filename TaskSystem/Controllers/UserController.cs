using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repository.Interfaces;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAll()
        {
            List<User> users = await _userRepository.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(Guid id)
        {
            User users = await _userRepository.GetById(id);
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] User userModel)
        {
            User user = await _userRepository.Create(userModel);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> Update([FromBody] User userModel, Guid id)
        {
            User user = await _userRepository.Update(userModel, id);
            return Ok(user);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<User>> Delete(Guid id)
        {
            User user = await _userRepository.Delete(id);
            return Ok();
        }
    }
}
