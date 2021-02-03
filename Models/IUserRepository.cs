using System;
using System.Collections.Generic;

namespace KloutAPI.Models
{
    public interface IUserRepository
    {
        User Get(string user_id);

        void Create(User user);
        void Edit(User user);
        void Delete(string user_id);

        void Follow(string follower_id, string following_id);
        void Unfollow(string follower_id, string following_id);

        List<string> Followers(string user_id);
        List<string> Following(string user_id);
    }
}
