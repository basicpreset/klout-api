using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using KloutAPI.Models;

namespace KloutAPI.Models
{
    public class PostRepository : IPostRepository
    {
        private AppDBContext _context;

        public PostRepository(AppDBContext context)
        {
            _context = context;
        }

        public Post Get(int post_id)
        {
            var post = _context.posts.Find(post_id);
            return post;
        }

        public Post Create(string user_id, Post post)
        {
            _context.posts.Add(post);
            var user = _context.users.Find(user_id);
            //user.posts.Add(post);
            user.post_count++;
            _context.users.Update(user);
            _context.SaveChanges();
            return post;
        }

        public Post Edit(string user_id, int post_id, string post_content)
        {
            var edited_post = _context.posts.Find(post_id);
            edited_post.post_content = post_content;

            _context.posts.Update(edited_post);

            _context.SaveChanges();

            return _context.posts.Find(post_id);
        }

        public void Repost(Post post, string user_id, int original_post_id)
        {
            /*var repost = new Repost
            {
                user_id = user_id,
                post_id = post_id
            };
            _context.reposts.Add(repost);
            _context.SaveChanges();*/
            var new_post = post;
            new_post.original_post_id = original_post_id;
            _context.posts.Add(new_post);
            _context.SaveChanges();
        }

        public void DeleteRepost(string user_id, int post_id)
        {
            var repost = new Repost
            {
                user_id = user_id,
                post_id = post_id
            };
            _context.reposts.RemoveRange(repost);
            _context.SaveChanges();
        }

        public void Delete(string user_id, int post_id)
        {
            var post = _context.posts.Find(post_id);
            var likes = _context.likes.Where(l => l.post_id == post_id);
            foreach (var like in likes)
            {
                _context.likes.Remove(like);
            }
            var dislikes = _context.dislikes.Where(d => d.post_id == post_id);
            foreach (var dislike in dislikes)
            {
                _context.dislikes.Remove(dislike);
            }

            var user = _context.users.Find(user_id);
            user.post_count--;

            _context.users.Update(user);

            _context.posts.Remove(post);
            _context.SaveChanges();
        }

        public int Like(int post_id, string user_id)
        {
            //IMPLEMENT: Counter
            var post = _context.posts.Find(post_id);

            bool alreadyLiked = false;
            
            foreach (var dislike in _context.dislikes.Where(d => d.post_id == post.post_id))
            {
                if (dislike.user_id == user_id)
                {
                    post.dislikes_count--;
                    Dislike rdis = new Dislike
                    {
                        dislike_id = dislike.dislike_id,
                        user_id = user_id,
                        post_id = post.post_id
                    };
                    _context.dislikes.Remove(rdis);
                }
            }
            foreach (var like in _context.likes.Where(l => l.post_id == post_id))
            {
                if(like.user_id == user_id)
                {
                    post.likes_count--;
                    Like rlike = new Like {
                        like_id = like.like_id,
                        user_id = like.user_id,
                        post_id = like.post_id
                    };
                    _context.Remove(rlike);
                    alreadyLiked = true;
                }
            }
            if(!alreadyLiked) {
                var newLike = new Like
                {
                    user_id = user_id,
                    post_id = post_id
                };
                _context.likes.Add(newLike);
                post.likes_count++;
            }
            _context.posts.Update(post);
            _context.SaveChanges();
            return post.likes_count;
        }

        public int Dislike(int post_id, string user_id)
        {
            //IMPLEMENT: Counter
            var post = _context.posts.Find(post_id);

            bool alreadyDisliked = false;
            foreach (var like in _context.likes.Where(d => d.post_id == post.post_id))
            {
                if (like.user_id == user_id)
                {
                    post.likes_count--;
                    Like rlike = new Like
                    {
                        like_id = like.like_id,
                        user_id = user_id,
                        post_id = post.post_id
                    };
                    _context.likes.Remove(rlike);
                }
            }
            foreach (var dislike in _context.dislikes.Where(d => d.post_id == post_id))
            {
                if(dislike.user_id == user_id)
                {
                    post.dislikes_count--;
                    Dislike rdis = new Dislike {
                        dislike_id = dislike.dislike_id,
                        user_id = dislike.user_id,
                        post_id = dislike.post_id
                    };
                    _context.dislikes.Remove(rdis);
                    alreadyDisliked = true;
                }
            }
            if(!alreadyDisliked) {
                var newDislike = new Dislike
                {
                    user_id = user_id,
                    post_id = post_id
                };
                _context.dislikes.Add(newDislike);
                post.dislikes_count++;
            }
            _context.posts.Update(post);
            _context.SaveChanges();
            return post.dislikes_count;
        }

        public IEnumerable<Post> Feed(string user_id)
        {
            List<Follow> rows = _context.follows.ToList();
            var matching = new List<string>();
            foreach (var row in rows)
            {
                if (row.follower_id == user_id)
                {
                    matching.Add(row.following_id);
                }
            }
            var feed = _context.posts.Where(p => matching.Contains(p.user_id)).OrderBy(p => p.created_on);
            return feed;
        }

        public IEnumerable<Post> ThisUserPosts(string user_id)
        {
            var filtered = _context.posts.Where(p => p.user_id == user_id);
            return filtered;
        }
    }
}
