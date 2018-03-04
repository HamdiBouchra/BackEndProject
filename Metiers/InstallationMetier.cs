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
            var listFactors = _context.Factors.ToList();
                return listFactors;
        }


        public IEnumerable<ProduitFa> getProductsFactor(int idFactor)
        {
            //var listProduct = _context.ProduitFactor.Select(item => item.IdFactor == idFactor).Include(item => item.IdProduitNavigation).Distinct().ToList();
            var list = _context.ProduitFa.Include(f => f.ProduitFactor).ThenInclude(f => f.IdFactor == idFactor).ToList();
                return list;
        }


    }
}
