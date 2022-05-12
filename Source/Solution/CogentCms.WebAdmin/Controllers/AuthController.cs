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

        public AuthController(IWebHostEnvironment webHostEnvironment)
        {
            this.webHostEnvironment = webHostEnvironment;
        }

        private ClaimsPrincipal CreateClaimsPrincipal(string tokenString)
        {
            var tokenJwt = new JwtSecurityTokenHandler().ReadJwtToken(tokenString);
            return new CogentPrincipalBuilder().BuildFromJwt(tokenJwt, CookieAuthenticationDefaults.AuthenticationScheme);            
        }

        public async Task<IActionResult> Index(string returnUrl)
        {            
            var tokenString = webHostEnvironment.IsDevelopment()
                ? Environment.GetEnvironmentVariable("Cogent_DevAuthToken")
                : Request.Headers["X-MS-TOKEN-AAD-ACCESS-TOKEN"].ToString();

            var principal = CreateClaimsPrincipal(tokenString);
            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(principal, authProperties);

            return Redirect(returnUrl);
        }
    }
}
