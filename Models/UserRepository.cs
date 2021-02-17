using System;
using System.Collections.Generic;
using System.Linq;

namespace KloutAPI.Models
{
    public class UserRepository : IUserRepository
    {
        private AppDBContext _context;

        public UserRepository(AppDBContext dbContext)
        {
            _context = dbContext;
        }

        public User Get(string Id)
        {
            var user = _context.users.Find(Id);
            user.posts = Posts(Id);
            user.dislikes = Dislikes(Id);
            user.likes = Likes(Id);
            return user;
        }

        public User Create(User user)
        {
            _context.users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public User Edit(User user)
        {
            var this_user = _context.users.Find(user.user_id);
            this_user = user;
            _context.users.Update(this_user);
            _context.SaveChanges();
            return this_user;
        }

        public void Delete(string user_id)
        {
            var user = _context.users.Find(user_id);
            _context.users.Remove(user);
            _context.SaveChanges();
        }

        public List<Post> Posts(string user_id)
        {
            var posts = _context.posts.Where(p => p.user_id == user_id).ToList();
            return posts;
        }

        public void Follow(string follower_id, string following_id)
        {
            Follow follow = new Follow
            {
                follower_id = follower_id,
                following_id = following_id
            };
            _context.follows.Add(follow);
            var follower = _context.users.Find(follower_id);
            follower.following_count++;
            var followed = _context.users.Find(following_id);
            followed.follower_count++;
            _context.users.Update(follower);
            _context.users.Update(followed);
            _context.SaveChanges();
        }

        public void Unfollow(string follower_id, string following_id)
        {
            var fol = _context.follows.First(p => p.follower_id == follower_id && p.following_id == following_id);
            _context.follows.Remove(fol);
            var unfollower = _context.users.Find(follower_id);
            unfollower.following_count--;
            var unfollowed = _context.users.Find(following_id);
            unfollowed.follower_count--;
            _context.users.Update(unfollower);
            _context.users.Update(unfollowed);
            _context.SaveChanges();
        }

        public List<string> Followers(string user_id)
        {
            var matchingRows = _context.follows.Where(p => p.following_id == user_id).ToList();
            var followers = new List<string>();
            foreach (var row in matchingRows)
            {
                followers.Add(row.follower_id);
            }
            return followers;
        }

        public List<string> Following(string user_id)
        {
            var matchingRows = _context.follows.Where(f => f.follower_id == user_id).ToList();
            var following = new List<string>();
            foreach (var row in matchingRows)
            {
                following.Add(row.following_id);
            }
            return following;
        }

        public List<User> Search()
        {
            //var users = _context.users.Where(u => u.username.Contains(query)).ToList();
            return _context.users.ToList();
        }

        public List<int> Likes(string user_id)
        {
            var likes = _context.likes.Where(l => l.user_id == user_id).ToList();
            List<int> likeIds = new List<int>();
            foreach(var like in likes)
            {
                likeIds.Add(like.post_id);
            }
            return likeIds;
        }

        public List<int> Dislikes(string user_id)
        {
            var dislikes = _context.dislikes.Where(d => d.user_id == user_id).ToList();
            List<int> dislikeIds = new List<int>();
            foreach(var dislike in dislikes)
            {
                dislikeIds.Add(dislike.post_id);
            }
            return dislikeIds;
        }
    }
}
