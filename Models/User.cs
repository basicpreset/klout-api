using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KloutAPI.Models
{
    public class User
    {
        [Key]
        public string user_id { get; set; }
        public string username { get; set; }
        public string full_name { get; set; }
        public string userbio { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public DateTime reg_date { get; set; }
        public int post_count { get; set; }
        public int follower_count { get; set; }
        public int following_count { get; set; }
        public string profile_img_url { get; set; }
        public string profile_cover_url { get; set; }

        //[InverseProperty("User")]
        //public virtual List<Post> posts { get; set; } = new List<Post>();
    }
}
