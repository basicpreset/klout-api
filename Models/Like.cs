using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KloutAPI.Models
{
    public class Like
    {
        [Key]
        public int like_id { get; set; }
        public string user_id { get; set; }
        public int post_id { get; set; }
    }
}
