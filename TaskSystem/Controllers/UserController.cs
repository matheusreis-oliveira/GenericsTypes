﻿using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Repository.Interfaces;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<User>
    {
        public UserController(IRepository<User> repository) : base(repository)
        {
        }
    }
}
