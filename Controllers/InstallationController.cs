using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEndProject.Models;
using Microsoft.Extensions.Configuration;
using BackEndProject.Metiers;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace BackEndProject.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class InstallationController : Controller
    {
        private InstallationMetier _installationMetier;
        private CRMv1Context _context;

        public InstallationController(IConfiguration config)
        {
            _installationMetier = new InstallationMetier(config);
            _context = new CRMv1Context();
        }

        //GET: api/Installation
        [Route("getFactors")]
        [HttpGet, Authorize]
        public IActionResult GetFactorsName()
          {
            Console.WriteLine("#################################################");
              return Ok(_installationMetier.getAllFactors());
          }


        [Route("getSoftwares")]
        [HttpGet, Authorize]
        public IActionResult GetSoftwaresName()
        {
            Console.WriteLine("#################################################");
            return Ok(_installationMetier.getAllSoftwares());
        }

        [Route("getTypeContrat")]
        [HttpGet, Authorize(Roles = "Admin")]
        public IActionResult getTypeContrat(int idProduit)
        {
            Console.WriteLine("#################################################");
            return Ok(_installationMetier.getContratType(idProduit).Id);
        }

        [Route("calculDevis")]
        [HttpGet, Authorize(Roles = "Admin")]
        public IActionResult calculerDevis(int idProduit,int IdDevis)
        {
            Console.WriteLine("#################################################");
            return Ok(_installationMetier.calculDevis(idProduit, IdDevis));
        }

    }
}
