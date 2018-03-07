using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackEndProject.Metiers;
using BackEndProject.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using BackEndProject.Models;

namespace BackEndProject.Controllers
{
   [Route("[controller]")]
    public class LogInController : Controller
    {
        private LogInMetier _logInMetier;
        private TokenHelper _tokenHelper;
        private CRMv1Context _context;
        public LogInController(IConfiguration config)
        {
            _logInMetier = new LogInMetier(config);
            _tokenHelper = new TokenHelper(config);
            _context = new CRMv1Context();
        }

        [HttpPost, AllowAnonymous]
        public IActionResult Authenticate([FromBody]LoginModel login)
        {
            IActionResult response = Unauthorized();
            PublicUser user = _logInMetier.Authenticate(login);

            if (user != null)
            {
                var tokenString = _tokenHelper.BuildToken(user);
                var cpt = _context.CompteContact.Select(t => t.IdCptNavigation).Where(p => p.MainContactId == user.Contact.Id).FirstOrDefault();
                response = Ok(new { token = tokenString, Utilisateur = user,compte = cpt });
            }
            return response;
        }
    }
}