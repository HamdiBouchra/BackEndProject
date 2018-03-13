using System;
using System.Collections.Generic;

namespace BackEndProject.Models
{
    public partial class ProduitFa
    {
        public ProduitFa()
        {
            ProduitFactor = new HashSet<ProduitFactor>();
        }

        public int IdProduit { get; set; }
        public string Description { get; set; }
        public int? TypeId { get; set; }

        public TypesContrat Type { get; set; }
        public ICollection<ProduitFactor> ProduitFactor { get; set; }
    }
}
