using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using CogentCms.Core.Auth;
using CogentCms.WebAdmin.Models.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;

namespace CogentCms.WebAdmin.Controllers
{
    public class AuthController : Controller
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IAppUserService appUserService;

        public AuthController(IWebHostEnvironment webHostEnvironment, IAppUserService appUserService)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.appUserService = appUserService;
        }

        public async Task<IActionResult> Index(string returnUrl)
        {            
            var tokenString = webHostEnvironment.IsDevelopment()
                ? Environment.GetEnvironmentVariable("Cogent_DevAuthToken")
                : Request.Headers["X-MS-TOKEN-AAD-ACCESS-TOKEN"].ToString();

            var tokenJwt = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);
            var idProvider = tokenJwt.Claims.Single(c => c.Type == "iss").Value;
            var subjectId = tokenJwt.Claims.Single(c => c.Type == "sub").Value;

            if (!appUserService.DoesAppUserExist(idProvider, subjectId))
            {
                return Redirect(nameof(AccessDenied));
            }
            else
            {
                var principal = new CogentPrincipalBuilder().BuildFromJwt(tokenJwt, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();
                await HttpContext.SignInAsync(principal, authProperties);

                return Redirect(returnUrl);
            }
        }

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
