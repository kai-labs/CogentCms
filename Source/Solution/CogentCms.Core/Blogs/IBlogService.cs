using System;
using System.Collections.Generic;

namespace CogentCms.Core.Blogs
{
    public interface IBlogService
    {
        IList<BlogPostData> GetRecentBlogPosts();
        int CreateBlogPost(string title, string body, string slug);
        IList<BlogPostData> GetBlogPosts();
        BlogPostData GetBlogPost(int blogPostId);
        void PublishBlogPost(int blogPostId, DateTime utcNow);
        void UnpublishBlogPost(int blogPostId);
    }
}