using System.Collections.Generic;

namespace CogentCms.Core.Blogs
{
    public interface IBlogService
    {
        IList<BlogPostData> GetRecentBlogPosts();
    }
}