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
            return _context.users.Find(Id);
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

        public void Follow(string follower_id, string following_id)
        {
            Follow follow = new Follow
            {
                follower_id = follower_id,
                following_id = following_id
            };
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
    }
}
