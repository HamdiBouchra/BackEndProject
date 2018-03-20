using System;
using System.Collections.Generic;

namespace BackEndProject.Models
{
    public partial class Factors
    {
        public Factors()
        {
            Document = new HashSet<Document>();
            Fonction = new HashSet<Fonction>();
            ProduitFactor = new HashSet<ProduitFactor>();
        }

        public int Id { get; set; }
        public string FactorCode { get; set; }
        public string FactorName { get; set; }
        public string NumCompte { get; set; }

        public ICollection<Document> Document { get; set; }
        public ICollection<Fonction> Fonction { get; set; }
        public ICollection<ProduitFactor> ProduitFactor { get; set; }
    }
}
