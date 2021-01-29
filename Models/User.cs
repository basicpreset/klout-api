using System;
using System.ComponentModel.DataAnnotations;

namespace KloutAPI.Models
{
    public class User
    {
        [Key]
        public int user_id { get; set; }
        public string username { get; set; }
        public string full_name { get; set; }
        public string userbio { get; set; }
        public string phone_number { get; set; }
        public string email { get; set; }
        public DateTime reg_date { get; set; }
        public int post_count { get; set; }
        public int follower_count { get; set; }
        public int following_count { get; set; }
    }
}
