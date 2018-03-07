using BackEndProject.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BackEndProject.Helpers
{
    public class TokenHelper
    {
        private IConfiguration _config;
        private CRMv1Context _context;
        public TokenHelper(IConfiguration config)
        {
            _config = config;
            _context = new CRMv1Context();
        }
        /**
         *Changer le password dans l'appSettings */         
        public string BuildToken(PublicUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Role, user.Role.Description)
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Audience"],
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(300),
                signingCredentials: creds);
            return (new JwtSecurityTokenHandler()).WriteToken(token);
        }

        /*
         * Associer un token (pour l'émail) à un publicUser 
         */
        public string BuildMailVerificationToken(PublicUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:KeyForMail"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Sid, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Username),
            };
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: creds);
            return (new JwtSecurityTokenHandler()).WriteToken(token);
        }

        public PublicUser ValidateToken(string token)
        {
            PublicUser result = null;
            TokenValidationParameters validation = new TokenValidationParameters()
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = _config["Jwt:Issuer"],
                ValidAudience = _config["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:KeyForMail"]))
            };
            SecurityToken returnedToken = null;

            var handler = new JwtSecurityTokenHandler();
            ClaimsPrincipal jsonToken = null;
            try
            {
                jsonToken = handler.ValidateToken(token, validation, out returnedToken);
                int temp = -1;
                int.TryParse(jsonToken.Claims.ElementAt(0).Value,out temp);
                result = new PublicUser()
                {
                    Id = temp,
                    Username = jsonToken.Claims.ElementAt(1).Value
                };
            }
            catch { }
            return result;
        }


    }
}
