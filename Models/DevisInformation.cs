using System;
using System.Collections.Generic;

namespace BackEndProject.Models
{
    public partial class DevisInformation
    {
        public int Id { get; set; }
        public int? NbrPoste { get; set; }
        public int? NbrContrat { get; set; }
        public int? LettragePartiel { get; set; }
        public string LogCompta { get; set; }
        public string LogGestion { get; set; }
        public int? Volumetrie { get; set; }
        public int? PreLettrage { get; set; }
        public int? ClotureFacture { get; set; }
        public int? IdCpt { get; set; }
        public double MdrPrcntVirts { get; set; }
        public double MdrPrcntChq { get; set; }
        public double MdrPrcntTrtAaccept { get; set; }
        public double MdrPrcntTrtSaccept { get; set; }
        public double MdrPrcntAutres { get; set; }
        public string Siren { get; set; }
        public string NomSociete { get; set; }
        public string Pays { get; set; }
        public string Activite { get; set; }
        public int? Ch { get; set; }
        public string Factor { get; set; }
        public string Produit { get; set; }

        public Comptes IdCptNavigation { get; set; }
    }
}
