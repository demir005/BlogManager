using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BlogManager.Models
{
    public class BlogPost
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Title { get; set; }

        [Required]
        [MaxLength(350)]
        public string Summary { get; set; }

        [Required]
        [MaxLength(3500)]
        public string Content { get; set; }

        [Required]
        public DateTime DateAndTime { get; set; }
    }
}
