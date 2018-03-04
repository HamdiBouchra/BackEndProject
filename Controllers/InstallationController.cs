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
        [HttpGet]
        public IEnumerable<Factors> GetFactorsName()
          {
              return _installationMetier.getAllFactors();
          }

        [Route("testProduit")]
        [HttpGet("{idFactor}")]
        public IEnumerable<ProduitFa> getProductsFactor(int idFactor)
        {
            Console.WriteLine("****************");
            // var list = _context.ProduitFactor.Select(t => t.ProduitFactor.Where(c => c.IdFactor == idFactor));
            // var listt = _context.ProduitFactor.Select(c => c.IdFactorNavigation.Id);
            //Factors f = _context.ProduitFactor.Select(c => c.IdFactorNavigation).Where(cc => cc.Id== idFactor).FirstOrDefault();
            var list = _context.ProduitFactor.Select(t => t.IdProduitNavigation).Where(cc => cc.ProduitFactor.Select(c => c.IdFactorNavigation.Id).FirstOrDefault() == idFactor);
           /* foreach(ProduitFa f in lis1t)
            {
                Console.WriteLine("PPPPPP => " + f.Description);
            }*/

            return list;
        }


    }
}
