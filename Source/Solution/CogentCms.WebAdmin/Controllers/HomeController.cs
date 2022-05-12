using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CogentCms.Core.Blogs;
using CogentCms.Core.Sql;
using CogentCms.WebAdmin.Models.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CogentCms.WebAdmin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public HomeController()
        {            
        }

        public IActionResult Index()
        {
            return View(new HomeIndexView());
        }
    }
}
