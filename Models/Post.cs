using System;
using System.ComponentModel.DataAnnotations;

namespace KloutAPI.Models
{
    public class Post
    {
        [Key]
        public int post_id { get; set; }
        public int user_id { get; set; }
        public string username { get; set; }
        public string user_img_url { get; set; }
        public string post_content { get; set; }
        public string image_url { get; set; }
        public DateTime created_on { get; set; }
        public int likes_count { get; set; }
        public int dislikes_count { get; set; }
        public int comments_count { get; set; }
        public int original_post_id { get; set; }
    }
}
