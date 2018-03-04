using System;
using System.Collections.Generic;

namespace BackEndProject.Models
{
    public partial class Comptes
    {
        public Comptes()
        {
            CompteContact = new HashSet<CompteContact>();
        }

        public int Id { get; set; }
        public bool? AccHasImpayedInv { get; set; }
        public int? AccountingId { get; set; }
        public string Adresse1 { get; set; }
        public string Adresse2 { get; set; }
        public int? AncienFactor1Id { get; set; }
        public int? AncienFactor2Id { get; set; }
        public bool? AutoUpdate { get; set; }
        public string AutorisationLicence { get; set; }
        public string AutorisationMaintenance { get; set; }
        public string Base { get; set; }
        public bool? BlockTypeTierUpdate { get; set; }
        public int? Buid { get; set; }
        public string Champ1 { get; set; }
        public int? ClientCount { get; set; }
        public string CoTitulaire { get; set; }
        public string CodeContrat { get; set; }
        public string Codepostal { get; set; }
        public string CommentaireInterne { get; set; }
        public string Commentaires { get; set; }
        public DateTime? ContractEnd { get; set; }
        public string ContractNumber { get; set; }
        public DateTime? ContractStart { get; set; }
        public string Contrat { get; set; }
        public int? CourtierId { get; set; }
        public int? CtcCourtierId { get; set; }
        public DateTime? Date1ereHeure { get; set; }
        public DateTime? DateDernierEmail { get; set; }
        public DateTime? DateLastActivity { get; set; }
        public DateTime? DateMajCi { get; set; }
        public DateTime? DateMajObs { get; set; }
        public string EntiteFactor { get; set; }
        public string Factor { get; set; }
        public int? FactorId { get; set; }
        public int? GestionContactId { get; set; }
        public double? Heures1annee { get; set; }
        public int? IdSuspect { get; set; }
        public int IdcomptePrincipal { get; set; }
        public int? InfoContactId { get; set; }
        public int? InvoiceCount { get; set; }
        public int? InvoicingId { get; set; }
        public bool? IsLocked { get; set; }
        public DateTime? LastHeure { get; set; }
        public DateTime? LastUpdate { get; set; }
        public string Link { get; set; }
        public string Logiciel { get; set; }
        public string MailAbouti { get; set; }
        public int? MainContactId { get; set; }
        public string Nom { get; set; }
        public string NomCourt { get; set; }
        public string NumTva { get; set; }
        public int? OtherContactId { get; set; }
        public int PaysId { get; set; }
        public DateTime? PremHeure { get; set; }
        public string Siren { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
        public string Statut { get; set; }
        public int? TauxCourtage { get; set; }
        public string TitreDernierEmail { get; set; }
        public string TitulaireFacturation { get; set; }
        public string Titulaires { get; set; }
        public double? Turnover { get; set; }
        public string TypeContrat { get; set; }
        public string TypeTiers { get; set; }
        public bool? ValidLicence { get; set; }
        public string Version { get; set; }
        public string Ville { get; set; }

        public Pays Pays { get; set; }
        public ICollection<CompteContact> CompteContact { get; set; }
    }
}
