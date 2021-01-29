using System;
using KloutAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KloutAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private IUserRepository _repo;

        public UserController(IUserRepository userRepository)
        {
            _repo = userRepository;
        }

        [HttpGet("{user_id}")]
        //[Route("{id}")]
        public ActionResult<User> Get(int user_id)
        {
            return _repo.Get(user_id);
        }
    }
}
