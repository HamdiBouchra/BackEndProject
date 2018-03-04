using System;
using System.Collections.Generic;

namespace BackEndProject.Models
{
    public partial class Fonction
    {
        public int Id { get; set; }
        public int? FactorId { get; set; }
        public string Title { get; set; }

        public Factors Factor { get; set; }
    }
}
