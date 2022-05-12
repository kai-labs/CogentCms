using CogentCms.Core.Sql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CogentCms.Core.Blogs
{
    public class BlogService : IBlogService
    {
        private readonly SqlConnectionFactory sqlConnectionFactory;

        public BlogService(SqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
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
                        blogPosts.Add(new BlogPostData
                        {
                            BlogPostId = (int)rdr["BlogPostId"],
                            Title = (string)rdr["Title"],
                            Body = (string)rdr["Body"],
                            Slug = (string)rdr["Slug"],
                            PublishDate = (rdr["PublishDate"] == DBNull.Value) ? (DateTime?)null : (DateTime?)rdr["PublishDate"]
                        });
                    }
                }

                return blogPosts;
            }
        }
    }
}
