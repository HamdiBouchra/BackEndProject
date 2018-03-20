using BackEndProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Metiers
{
    public class DocumentationMetier
    {
        private readonly CRMv1Context _context;
        private IConfiguration _config;


        public DocumentationMetier(CRMv1Context context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        /*
         * Récupérer les documents des factors 
         */
        public dynamic getFactorsDoc()
        {
            try
            {
                var docFact = _context.Factors.Include(d => d.Document);
                return new { factDoc = docFact, found = true};
            }
            catch(Exception e)
            {
                return new { found = false };
            }
        }

    }
}
