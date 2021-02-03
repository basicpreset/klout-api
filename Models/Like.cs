using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KloutAPI.Models
{
    public class Like
    {
        public Like()
        {

        }

        public Like(string user_id, int post_id)
        {
            this.user_id = user_id;
            this.post_id = post_id;
        }

        [Key]
        public int like_id { get; set; }
        public string user_id { get; set; }
        public int post_id { get; set; }

        [ForeignKey("post_id")]
        public Post post { get; set; }
    }
}
