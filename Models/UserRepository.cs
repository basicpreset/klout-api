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

        public void EditUser(User user)
        {
            var this_user = _context.users.Find(user.user_id);
            this_user.full_name = user.full_name;
            this_user.email = user.email;
            this_user.username = user.username;
        }

        public User Get(string Id)
        {
            return _context.users.Find(Id);
        }

        public void Follow(string follower_id, string following_id)
        {
            Follow follow = new Follow();
            follow.follower_id = follower_id;
            follow.following_id = following_id;
            _context.follows.Add(follow);
            _context.SaveChanges();
        }

        public void Unfollow(string follower_id, string following_id)
        {
            Follow follow = new Follow();
            follow.follower_id = follower_id;
            follow.following_id = following_id;
            _context.follows.Remove(follow);
            _context.SaveChanges();
        }

        public List<string> GetFollowers(string user_id)
        {
            var matchingRows = _context.follows.Where(p => p.following_id == user_id).ToList();
            var followers = new List<string>();
            foreach (var row in matchingRows)
            {
                followers.Add(row.follower_id);
            }
            return followers;
        }

        public List<string> GetFollowing(string user_id)
        {
            var matchingRows = _context.follows.Where(f => f.follower_id == user_id).ToList();
            var following = new List<string>();
            foreach (var row in matchingRows)
            {
                following.Add(row.following_id);
            }
            return following;
        }
    }
}
