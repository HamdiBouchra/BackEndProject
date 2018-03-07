using BackEndProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Metiers
{
  
    public class InstallationMetier
    {
        private IConfiguration _config;
        private readonly CRMv1Context _context;

        public InstallationMetier(IConfiguration config)
        {
            _context = new CRMv1Context();
            _config = config;
        }

        public IEnumerable<Factors> getAllFactors()
        {
            var listFactors = _context.Factors.Include(p => p.ProduitFactor).ThenInclude(p => p.IdProduitNavigation).ToList();
                return listFactors;
        }


  


    }
}
