using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CogentCms.Core.Blogs;
using CogentCms.Core.Sql;
using CogentCms.WebPublic.Models.Home;
using Microsoft.AspNetCore.Mvc;

namespace CogentCms.WebPublic.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlogService blogService;

        public HomeController(IBlogService blogService)
        {            
            this.blogService = blogService;
        }

        public IActionResult Index()
        {
            var vm = new HomeIndexView();
            vm.BlogPosts = blogService.GetRecentBlogPosts();

            return View(vm);
        }
    }
}
