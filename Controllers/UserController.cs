using System;
using System.Collections.Generic;
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

        // 1. Get user
        [HttpGet("{user_id}")]
        public ActionResult<User> Get(string user_id)
        {
            return _repo.Get(user_id);
        }

        // 2. 
        [HttpPost("{user_id}/follow/{following_id}")]
        public ActionResult Follow(string user_id, string following_id)
        {
            _repo.Follow(follower_id: user_id, following_id: following_id);
            return Ok();
        }

        [HttpPost("{user_id}/unfollow/{following_id}")]
        public ActionResult Unfollow(string user_id, string following_id)
        {
            _repo.Unfollow(follower_id: user_id, following_id: following_id);
            return Ok();
        }

        [HttpGet("{user_id}/followers")]
        public ActionResult<List<string>> Followers(string user_id)
        {
            var followers = _repo.GetFollowers(user_id: user_id);
            return followers;
        }

        [HttpGet("{user_id}/following")]
        public ActionResult<List<string>> Following(string user_id)
        {
            var following = _repo.GetFollowing(user_id: user_id);
            return following;
        }
    }
}
