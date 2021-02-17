using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace KloutAPI.Models
{
    public class Dislike
    {
        [Key]
        public int dislike_id { get; set; }
        //[ForeignKey("user_id")]
        public string user_id { get; set; }
        //[ForeignKey("post_id")]
        public int post_id { get; set; }
    }
}
