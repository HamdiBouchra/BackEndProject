using System;
using System.Collections.Generic;

namespace BackEndProject.Models
{
    public partial class Softwares
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Edition { get; set; }
        public string Version { get; set; }
        public string DbType { get; set; }
        public int? CompteId { get; set; }
    }
}
