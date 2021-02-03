using System;
using System.ComponentModel.DataAnnotations;

namespace KloutAPI.Models
{
    public class Repost
    {
        [Key]
        public int repost_id { get; set; }
        public string user_id { get; set; }
        public int post_id { get; set; }
    }
}
