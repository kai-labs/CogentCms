using System.Collections.Generic;

namespace CogentCms.Core.Blogs
{
    public interface IBlogService
    {
        IList<BlogPostData> GetRecentBlogPosts();
        int CreateBlogPost(string title, string body, string slug);
        IList<BlogPostData> GetBlogPosts();
    }
}