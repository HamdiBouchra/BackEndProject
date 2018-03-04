using System;
using System.Collections.Generic;

namespace BackEndProject.Models
{
    public partial class Contacts
    {
        public Contacts()
        {
            CompteContact = new HashSet<CompteContact>();
            PublicUser = new HashSet<PublicUser>();
        }

        public int Id { get; set; }
        public bool? Actif { get; set; }
        public string Adresse1 { get; set; }
        public string Adresse2 { get; set; }
        public int? Buid { get; set; }
        public string Champ17 { get; set; }
        public string Champ21 { get; set; }
        public string Champ22 { get; set; }
        public string Champ25 { get; set; }
        public string Civilite { get; set; }
        public string Codepostal { get; set; }
        public string Commentaires { get; set; }
        public string Compagne { get; set; }
        public int? CompteId { get; set; }
        public int? CourtierId { get; set; }
        public DateTime? DateDernierEmail { get; set; }
        public string Email { get; set; }
        public string Email2 { get; set; }
        public string Entite { get; set; }
        public int? FactorId { get; set; }
        public string Fonction { get; set; }
        public int? FonctionId { get; set; }
        public bool? IncludeInDiff { get; set; }
        public bool? IsMassMailing { get; set; }
        public string Keyyo { get; set; }
        public int? LangueId { get; set; }
        public string Le { get; set; }
        public string Lieu { get; set; }
        public string MailAbouti { get; set; }
        public string NextLe { get; set; }
        public string Nom { get; set; }
        public string Par { get; set; }
        public int PaysId { get; set; }
        public string Phonecode { get; set; }
        public string Phonecode2 { get; set; }
        public string Phonecode3 { get; set; }
        public string Prenom { get; set; }
        public string Siren { get; set; }
        public string Source { get; set; }
        public byte[] SsmaTimeStamp { get; set; }
        public string Tel { get; set; }
        public string Tel2 { get; set; }
        public string Tel3 { get; set; }
        public string TitreDernierEmail { get; set; }
        public bool? Tutoiement { get; set; }
        public string TypeVoeux { get; set; }
        public string Typectc { get; set; }
        public string UserCode { get; set; }
        public string Ville { get; set; }

        public Pays Pays { get; set; }
        public ICollection<CompteContact> CompteContact { get; set; }
        public ICollection<PublicUser> PublicUser { get; set; }
    }
}
