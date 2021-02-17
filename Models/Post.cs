using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KloutAPI.Models
{
    public class Post
    {
        public Post()
        {

        }

        [Key]
        public int post_id { get; set; }
        //[Key]
        public string user_id { get; set; }
        public string username { get; set; }
        public string user_img_url { get; set; }
        public string post_content { get; set; }
        public string post_img_url { get; set; }
        public DateTime created_on { get; set; }
        public int likes_count { get; set; }
        public int dislikes_count { get; set; }
        public int comments_count { get; set; }
        public int original_post_id { get; set; }

        
        //public virtual User user { get; set; } = new User();
        //public virtual List<Dislike> dislikes { get; set;  } = new List<Dislike>();
        //public virtual List<Like> likes { get; set;  } = new List<Like>();
    }
}
