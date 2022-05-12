using CogentCms.Core.Blogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CogentCms.WebAdmin.Models.Home
{
    public class HomeIndexView
    {
        public IList<BlogPostData> BlogPosts { get; set; } = new List<BlogPostData>();
    }
}
