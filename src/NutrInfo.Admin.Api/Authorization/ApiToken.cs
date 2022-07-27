using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Nutrinfo.Admin.Domain.Users;

namespace  NutrInfo.Admin.Api.Authorization
{
    public class ApiToken
    {
        private readonly JwtOptions _jwtOptions;

        public User User { get; set; }

        public ApiToken(IOptions<JwtOptions> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }

        public override string ToString()
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, User.Id.ToString()));

            // foreach (var role in User.Roles)
            // {
            //     claims.Add(new Claim(ClaimTypes.Role, role));
            // }

            var token = new JwtSecurityToken(
                issuer: JwtOptions.Issuer,
                audience: JwtOptions.Audience,
                notBefore: DateTime.UtcNow,
                signingCredentials: new SigningCredentials(
                    key: new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtOptions.Secret)),
                    algorithm: SecurityAlgorithms.HmacSha256
                ),
                claims: claims
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
