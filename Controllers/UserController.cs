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

        [HttpGet("{user_id}")]
        public ActionResult<User> Get(string user_id)
        {
            return _repo.Get(user_id);
        }

        // 2. Create
        [HttpPost("create")]
        public ActionResult<User> Create([FromBody] User user)
        {
            var new_user = _repo.Create(user);
            return new_user;
        }

        // 3. Edit
        [HttpPost("{user_id}/edit")]
        public ActionResult<User> Edit([FromBody] User user)
        {
            var edited_user = _repo.Edit(user);
            return edited_user;
        }

        // 4. Delete
        [HttpGet("{user_id}/delete")]
        public ActionResult Delete(string user_id)
        {
            _repo.Delete(user_id);
            return Ok();
        }
        // 5. Follow
        [HttpGet("{user_id}/follow/{following_id}")]
        public ActionResult Follow(string user_id, string following_id)
        {
            _repo.Follow(follower_id: user_id, following_id: following_id);
            return Ok();
        }

        // 6. Unfollow
        [HttpGet("{user_id}/unfollow/{following_id}")]
        public ActionResult Unfollow(string user_id, string following_id)
        {
            _repo.Unfollow(follower_id: user_id, following_id: following_id);
            return Ok();
        }

        // 7. Followers
        [HttpGet("{user_id}/followers")]
        public ActionResult<List<string>> Followers(string user_id)
        {
            var followers = _repo.Followers(user_id: user_id);
            return followers;
        }

        // 8. Following
        [HttpGet("{user_id}/following")]
        public ActionResult<List<string>> Following(string user_id)
        {
            var following = _repo.Following(user_id: user_id);
            return following;
        }

        // 9. Likes
        [HttpGet("{user_id}/likes")]
        public ActionResult<List<int>> Likes(string user_id)
        {
            return _repo.Likes(user_id);
        }

        // 10. Dislikes
        [HttpGet("{user_id}/dislikes")]
        public ActionResult<List<int>> Dislikes(string user_id)
        {
            return _repo.Dislikes(user_id);
        }

        // 11. All users [TEMPORARY SOLUTION FOR SEARCH LIST]
        [HttpGet("search")]
        public ActionResult<List<User>> All()
        {
            return _repo.Search();
        }

        
    }
}
