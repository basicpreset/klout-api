using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KloutAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace KloutAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PostController : ControllerBase
    {
        private IPostRepository _repository;

        public PostController(IPostRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("{post_id}")]
        public ActionResult<Post> Get(int post_id)
        {
            return _repository.Get(post_id);
        }

        [HttpPost("following")]
        public IEnumerable<Post> GetFeed([FromBody] int[] following)
        {
            //int json = Sys
            return _repository.GetFeed(following);
        }
    }
}
