using System;
using System.Collections.Generic;
using System.Linq;

namespace KloutAPI.Models
{
    public class PostRepository : IPostRepository
    {
        private AppDBContext _context;

        public PostRepository(AppDBContext context)
        {
            _context = context;
        }


        public Post Get(int Id)
        {
            return _context.posts.Find(Id);
        }

        public IEnumerable<Post> GetFeed(int[] following)
        {
            var filtered = _context.posts.Where(p => following.Contains(p.user_id)).OrderBy(p => p.created_on);
            return filtered;
        }

        public IEnumerable<Post> GetUserPosts(int Id)
        {
            var filtered = _context.posts.Where(p => p.post_id == Id);
            return filtered;
        }

        public void Like(int Id)
        {
            var post = _context.posts.Find(Id);
            post.likes_count++;
            _context.SaveChanges();
        }

        public void Dislike(int Id)
        {
            var post = _context.posts.Find(Id);
            post.dislikes_count++;
            _context.SaveChanges();
        }

        public void Remove(int Id)
        {
            var post = _context.posts.Find(Id);
            _context.posts.Remove(post);
            _context.SaveChanges();
        }

        public void Edit(Post post)
        {
            var editedPost = _context.posts.Find(post.post_id);
            editedPost.post_content = post.post_content;
            _context.SaveChanges();
        }
    }
}
