using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CogentCms.WebAdmin.Models.Auth;
using Microsoft.AspNetCore.Mvc;

namespace CogentCms.WebAdmin.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View(new AuthIndexView());
        }
    }
}
