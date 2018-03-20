using System;
using System.Collections.Generic;

namespace BackEndProject.Models
{
    public partial class Document
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public int? IdFactor { get; set; }
        public string Nom { get; set; }

        public Factors IdFactorNavigation { get; set; }
    }
}
