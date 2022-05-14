using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CogentCms.WebAdmin.Models.Blog
{
    public class BlogEditForm
    {
        public int BlogPostId { get; set; }

        [Required]
        [MaxLength(500)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        [MaxLength(500)]
        public string Slug { get; set; }        
    }
}
