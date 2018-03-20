using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEndProject.Models;
using BackEndProject.Metiers;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;

namespace BackEndProject.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class DocumentationController : Controller
    {
        private readonly CRMv1Context _context;
        private DocumentationMetier _documentationMetier { get; }
        private IConfiguration _config;

        public DocumentationController(CRMv1Context context, IConfiguration config)
        {
            _context = context;
            _config = config;
            _documentationMetier = new DocumentationMetier(_context, config);
        }

        [Route("doc")]
        [HttpGet]
        public IActionResult getFactorsDocument()
        {
            var resultat = this._documentationMetier.getFactorsDoc();
               Boolean f = (Boolean)resultat.found;
               if(f)
                   return Ok(resultat);
               else
                   return StatusCode(500, resultat);
        }
    }
}