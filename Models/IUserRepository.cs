using System;
using System.Collections.Generic;

namespace KloutAPI.Models
{
    public interface IUserRepository
    {
        User Get(string Id);
        void EditUser(User user);

        void Follow(string follower_id, string following_id);
        void Unfollow(string follower_id, string following_id);

        List<string> GetFollowers(string user_id);
        List<string> GetFollowing(string user_id);
    }
}
