using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KloutAPI.Models
{
    public class Follow
    {
        public Follow()
        {

        }

        public Follow(string follower_id, string following_id)
        {
            this.follower_id = follower_id;
            this.following_id = following_id;
        }

        [Key]
        public int id { get; set; }
        public string follower_id { get; set; }
        public string following_id { get; set; }

        //[ForeignKey("follower_id")]
        //public User follower_user { get; set; }

        //[ForeignKey("following_id")]
        //public User following_user { get; set; }
    }
}
