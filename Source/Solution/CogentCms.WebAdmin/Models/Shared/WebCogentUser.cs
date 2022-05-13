﻿using CogentCms.Core.Auth;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CogentCms.WebAdmin.Models.Shared
{
    public class WebCogentUser : ICogentUser
    {
        public WebCogentUser(IHttpContextAccessor httpContextAccessor)
        {
            var principal = httpContextAccessor.HttpContext.User;
            AppUserId = Convert.ToInt32(principal.Claims.Single(c => c.Type == "AppUserId").Value);
            Username = principal.Claims.Single(c => c.Type == "sub").Value;
            FullName = principal.Claims.Single(c => c.Type == "name").Value;
        }

        public int AppUserId { get; set; }
        public string Username { get; set; }
        public string FullName { get; set; }
    }
}
