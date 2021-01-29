using System;
using System.Collections.Generic;

namespace KloutAPI.Models
{
    public interface IPostRepository
    {
        //Get a random post
        Post Get(int Id);

        //Get all posts from following list *-> later implement time constraint
        IEnumerable<Post> GetFeed(int[] following);
        IEnumerable<Post> GetUserPosts(int Id);

        //Post functions
        void Edit(Post post);
        void Like(int Id);
        void Dislike(int Id);
        void Remove(int Id);
    }
}
