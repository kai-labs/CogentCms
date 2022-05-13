using CogentCms.Core.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CogentCms.WebAdmin.Models.Blog
{
    public class BlogIndexView
    {
        public IList<BlogPostData> BlogPosts { get; set; }
    }
}
