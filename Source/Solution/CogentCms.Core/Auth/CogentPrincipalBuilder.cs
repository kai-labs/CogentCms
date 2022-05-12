using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CogentCms.Core.Auth
{
    public class CogentPrincipalBuilder
    {
        private string ReadClaimValue(JwtSecurityToken jwtSecurityToken, string claimType)
        {
            return jwtSecurityToken.Claims.Single(c => c.Type == claimType).Value;
        }

        public ClaimsPrincipal BuildFromJwt(JwtSecurityToken jwtSecurityToken, string authenticationType)
        {
            var claimsIdentity = new ClaimsIdentity(
                new List<Claim>
                {
                    new Claim("sub", ReadClaimValue(jwtSecurityToken, "sub")),
                    new Claim("name", ReadClaimValue(jwtSecurityToken, "name"))
                },
                authenticationType);

            return new ClaimsPrincipal(claimsIdentity);
        }
    }
}
