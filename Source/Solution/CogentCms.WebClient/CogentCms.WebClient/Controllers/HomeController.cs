using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CogentCms.WebPublic.Models.Home;
using Microsoft.AspNetCore.Mvc;

namespace CogentCms.WebPublic.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new HomeIndexView());
        }
    }
}
