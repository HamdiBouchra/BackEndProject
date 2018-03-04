using System;
using System.Collections.Generic;

namespace BackEndProject.Models
{
    public partial class ProduitFactor
    {
        public int IdProduit { get; set; }
        public int IdFactor { get; set; }

        public Factors IdFactorNavigation { get; set; }
        public ProduitFa IdProduitNavigation { get; set; }
    }
}
