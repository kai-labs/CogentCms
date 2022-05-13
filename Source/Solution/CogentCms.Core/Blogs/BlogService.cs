using CogentCms.Core.Auth;
using CogentCms.Core.Sql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogentCms.Core.Blogs
{
    public class BlogService : IBlogService
    {
        private readonly SqlConnectionFactory sqlConnectionFactory;
        private readonly ICogentUser user;

        public BlogService(SqlConnectionFactory sqlConnectionFactory, ICogentUser user)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
            this.user = user;
        }

        private BlogPostData MapBlogPostData(SqlDataReader rdr)
        {
            return new BlogPostData
            {
                BlogPostId = (int)rdr["BlogPostId"],
                Title = (string)rdr["Title"],
                Body = (string)rdr["Body"],
                Slug = (string)rdr["Slug"],
                PublishDate = (rdr["PublishDate"] == DBNull.Value) ? (DateTime?)null : (DateTime?)rdr["PublishDate"]
            };
        }

        public int CreateBlogPost(string title, string body, string slug)
        {
            using (var conn = sqlConnectionFactory.Open())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "insert into BlogPost (Title, Body, Slug, AuthorAppUserId) values (@Title, @Body, @Slug, @AuthorAppUserId); select scope_identity();";
                cmd.Parameters.AddWithValue("Title", title);
                cmd.Parameters.AddWithValue("Body", body);
                cmd.Parameters.AddWithValue("Slug", slug);
                cmd.Parameters.AddWithValue("AuthorAppUserId", user.AppUserId);

                var blogPostId = Convert.ToInt32(cmd.ExecuteScalar());

                return blogPostId;
            }
        }

        public IList<BlogPostData> GetBlogPosts()
        {
            using (var conn = sqlConnectionFactory.Open())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select BlogPostId, Title, Body, Slug, PublishDate from BlogPost order by BlogPostId";

                var blogPosts = new List<BlogPostData>();

                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        blogPosts.Add(MapBlogPostData(rdr));
                    }
                }

                return blogPosts;
            }
        }

        public IList<BlogPostData> GetRecentBlogPosts()
        {
            using (var conn = sqlConnectionFactory.Open())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select top 10 BlogPostId, Title, Body, Slug, PublishDate from BlogPost where PublishDate is not null order by PublishDate desc";

                var blogPosts = new List<BlogPostData>();

                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        blogPosts.Add(MapBlogPostData(rdr));
                    }
                }

                return blogPosts;
            }
        }

        public BlogPostData GetBlogPost(int blogPostId)
        {
            using (var conn = sqlConnectionFactory.Open())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select BlogPostId, Title, Body, Slug, PublishDate from BlogPost where BlogPostId = @BlogPostId";
                cmd.Parameters.AddWithValue("BlogPostId", blogPostId);

                var blogPosts = new List<BlogPostData>();

                using (var rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        blogPosts.Add(MapBlogPostData(rdr));
                    }
                }

                return blogPosts.FirstOrDefault();
            }
        }

        public void PublishBlogPost(int blogPostId, DateTime publishDate)
        {
            using (var conn = sqlConnectionFactory.Open())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "update BlogPost set PublishDate = @PublishDate where BlogPostId = @BlogPostId";
                cmd.Parameters.AddWithValue("BlogPostId", blogPostId);
                cmd.Parameters.AddWithValue("PublishDate", publishDate);

                cmd.ExecuteNonQuery();
            }
        }

        public void UnpublishBlogPost(int blogPostId)
        {
            using (var conn = sqlConnectionFactory.Open())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "update BlogPost set PublishDate = null where BlogPostId = @BlogPostId";
                cmd.Parameters.AddWithValue("BlogPostId", blogPostId);                

                cmd.ExecuteNonQuery();
            }
        }
    }
}
