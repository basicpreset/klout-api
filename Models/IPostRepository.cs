using System;
using System.Collections.Generic;

namespace KloutAPI.Models
{
    public interface IPostRepository
    {
        IEnumerable<Post> ThisUserPosts(string user_id);

        //Post functions
        Post Get(int post_id);
        Post Create(string user_id, Post post);
        Post Edit(string user_id, int post_id, string post_content);
        void Repost(Post post, string user_id, int original_post_id);
        void DeleteRepost(string user_id, int post_id);
        void Delete(string user_id, int post_id);
        void Like(int post_id, string user_id);
        void Dislike(int post_id, string user_id);
        IEnumerable<Post> Feed(string user_id);
    }
}
