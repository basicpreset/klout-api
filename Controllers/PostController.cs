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

        // 1. Get post
        [HttpGet("{post_id}")]
        public ActionResult<Post> Get(int post_id)
        {
            return _repository.Get(post_id);
        }

        // 2. Create post
        [HttpPost("{user_id}/create")]
        public ActionResult<Post> Create(string user_id, [FromBody] Post post)
        {
            var new_post = _repository.Create(user_id, post);
            return new_post;
        }

        // 3. Edit post
        [HttpPost("{user_id}/edit/{post_id}")]
        public ActionResult<Post> Edit(string user_id, int post_id, [FromBody] string post_content)
        {
            var edited_post = _repository.Edit(user_id, post_id, post_content);
            return edited_post;
        }

        // 4. Repost post
        [HttpPost("{user_id}/repost/{original_post_id}")]
        public ActionResult Repost([FromBody] Post post, string user_id, int original_post_id)
        {
            _repository.Repost(post, user_id, original_post_id);
            return Ok();
        }

        // 5. Delete
        [HttpGet("{user_id}/delete/{post_id}")]
        public ActionResult Delete(string user_id, int post_id)
        {
            _repository.Delete(user_id, post_id);
            return Ok();
        }

        // 6. Like
        [HttpGet("{user_id}/like/{post_id}")]
        public ActionResult<int> Like(string user_id, int post_id)
        {
            var like_count = _repository.Like(post_id, user_id);
            return like_count;
        }

        // 7. Dislike
        [HttpGet("{user_id}/dislike/{post_id}/")]
        public ActionResult<int> Dislike(string user_id, int post_id)
        {

            var dislike_count = _repository.Dislike(post_id, user_id);
            return dislike_count;
        }

        // 8. Feed
        [HttpGet("{user_id}/feed")]
        public IEnumerable<Post> Feed(string user_id)
        {
            return _repository.Feed(user_id);
        }

        // 9. ThisUserPosts
        [HttpGet("{user_id}/all")]
        public IEnumerable<Post> ThisUserPosts(string user_id)
        {
            return _repository.ThisUserPosts(user_id);
        }
    }
}
