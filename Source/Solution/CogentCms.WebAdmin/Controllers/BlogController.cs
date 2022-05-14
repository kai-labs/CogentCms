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

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var blogPost = blogService.GetBlogPost(id);

            var blogEditForm = new BlogEditForm
            {
                BlogPostId = blogPost.BlogPostId,
                Title = blogPost.Title,
                Body = blogPost.Body,
                Slug = blogPost.Slug
            };

            return View(blogEditForm);
        }

        [HttpPost]
        public IActionResult Edit(BlogEditForm blogEditForm)
        {
            if (!ModelState.IsValid)
            {
                return View(blogEditForm);
            }

            blogService.UpdateBlogPost(blogEditForm.BlogPostId, blogEditForm.Title, blogEditForm.Body, blogEditForm.Slug);

            return RedirectToAction(nameof(Detail), new { id = blogEditForm.BlogPostId });
        }

        public IActionResult Detail(int id)
        {
            var blogPost = blogService.GetBlogPost(id);
            var vm = new BlogDetailView { BlogPost = blogPost };

            return View(vm);
        }

        [HttpPost]
        public IActionResult Publish(int blogPostId)
        {
            blogService.PublishBlogPost(blogPostId, DateTime.UtcNow);

            return RedirectToAction(nameof(Detail), new { id = blogPostId });
        }

        [HttpPost]
        public IActionResult Unpublish(int blogPostId)
        {
            blogService.UnpublishBlogPost(blogPostId);

            return RedirectToAction(nameof(Detail), new { id = blogPostId });
        }
    }    
}
