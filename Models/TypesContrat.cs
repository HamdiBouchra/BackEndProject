using System;
using System.Collections.Generic;

namespace BackEndProject.Models
{
    public partial class TypesContrat
    {
        public TypesContrat()
        {
            ProduitFa = new HashSet<ProduitFa>();
        }

        public int Id { get; set; }
        public string Sigle { get; set; }
        public string Description { get; set; }
        public int? MinNbrPosteInstalle { get; set; }
        public int? UniteSuppNbrPoste { get; set; }
        public int? MinNbrContat { get; set; }
        public int? UniteSuppContrat { get; set; }
        public double? PrixBase { get; set; }
        public double? MdrtrtAacceptation { get; set; }
        public double? MdrtrtSacceptation { get; set; }
        public double? Lpimpact { get; set; }
        public int? LimiteHausse { get; set; }
        public int? LimiteBasse { get; set; }
        public int? Vnh { get; set; }
        public int? Vnb { get; set; }
        public double? Vspf { get; set; }
        public double? Vipf { get; set; }
        public double? LettragePart { get; set; }

        public ICollection<ProduitFa> ProduitFa { get; set; }
    }
}
