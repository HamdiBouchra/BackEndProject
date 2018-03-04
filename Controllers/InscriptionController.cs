using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackEndProject.FactoryPattern;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Authorization;
using BackEndProject.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using BackEndProject.Services;
using System.Net.Http;

namespace BackEndProject.Controllers
{
   [Produces("application/json")]
    [Route("[controller]")]
    public class InscriptionController : Controller
    {
        private readonly CRMv1Context _context;
        private InscriptionMetier _inscrptionMetier { get; }
        private IConfiguration _config;
        
        public InscriptionController(CRMv1Context context, IConfiguration config)
        {
            _context = context;
            _config = config;
            _inscrptionMetier = new InscriptionMetier(_context,config);
        }

        /**
         * Verifier si le mail est activer ou pas si true le activer sinon rien faire
        //**/
        [Route("verify")]
        [HttpGet("{token}"), AllowAnonymous]
        public IActionResult Verify(string token)
        {
            IActionResult response = Unauthorized();
            if(_inscrptionMetier.ActivateUser(token) == true)
                response = Ok();
            return response;
        }

    
        /*
         * Vérifier si le num de TVA est valide
         */
        [Route("tva/validate")]
        [HttpGet("{tva}"), AllowAnonymous]
        public async Task<IActionResult> validateTVAAsync(string tva)
        {
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
            };
            var client = new System.Net.Http.HttpClient(
                new HttpClientHandler
                {
                    AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
                }
            );
            var response = await client.GetAsync(new Uri("https://euvat.ga/api/validate/" + tva));
            var body = await response.Content.ReadAsStringAsync();
            return Ok(JObject.Parse(body));
        }
        // POST: api/Comptes
        [Route("New")]
         [HttpPost,AllowAnonymous]
        public IActionResult New([FromBody] JObject newUser)
        {
            var res = this._inscrptionMetier.Inscrire(newUser);
            return Ok(res);

        }

    }
}