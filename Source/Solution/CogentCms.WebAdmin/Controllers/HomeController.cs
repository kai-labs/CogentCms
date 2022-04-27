using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CogentCms.WebAdmin.Models.Home;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CogentCms.WebAdmin.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new HomeIndexView());
        }
    }
}
