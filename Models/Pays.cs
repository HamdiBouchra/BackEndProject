using System;
using System.Collections.Generic;

namespace BackEndProject.Models
{
    public partial class Pays
    {
        public Pays()
        {
            Comptes = new HashSet<Comptes>();
            Contacts = new HashSet<Contacts>();
        }

        public int Id { get; set; }
        public bool? IsCee { get; set; }
        public bool? IsDomTom { get; set; }
        public string IsoCode { get; set; }
        public string Name { get; set; }
        public string Phonecode { get; set; }
        public byte[] SsmaTimeStamp { get; set; }

        public ICollection<Comptes> Comptes { get; set; }
        public ICollection<Contacts> Contacts { get; set; }
    }
}
