using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BabyRecords_Server.Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BabyRecords_Server.core.tools
{
    public class Jwt
    {
        private readonly IConfiguration _Configuration;

        public  Jwt(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        public string jwt(string account,int nameid)
        {
            var claims = new List<Claim>
                    {
                     new Claim(JwtRegisteredClaimNames.Email,account),
                     new Claim(JwtRegisteredClaimNames.NameId, nameid.ToString()),
                     new Claim(ClaimTypes.Role,"admin")
                    };
            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["JWT:KEY"]));

            var jwt = new JwtSecurityToken
                (
            issuer: _Configuration["JWT:Issuer"],
            audience: _Configuration["JWT:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256)
                );
            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            return token;
        }
    }
}
