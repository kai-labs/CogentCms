using CogentCms.Core.Blogs;
using CogentCms.WebAdmin.Models.Blog;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CogentCms.WebAdmin.Controllers
{
    
    public class BlogController : Controller
    {
        private readonly IBlogService blogService;

        public BlogController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        public IActionResult Index()
        {
            var blogPosts = blogService.GetBlogPosts();

            var vm = new BlogIndexView
            {
                BlogPosts = blogPosts
            };

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new BlogCreateForm());
        }

        [HttpPost]
        public IActionResult Create(BlogCreateForm blogCreateForm)
        {
            if (!ModelState.IsValid)
            {
                return View(blogCreateForm);
            }

            var blogPostId = blogService.CreateBlogPost(blogCreateForm.Title, blogCreateForm.Body, blogCreateForm.Slug);

            return Redirect(nameof(Index));
        }
    }    
}
