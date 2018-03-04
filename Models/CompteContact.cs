using System;
using System.Collections.Generic;

namespace BackEndProject.Models
{
    public partial class CompteContact
    {
        public int IdCpt { get; set; }
        public int Idcnt { get; set; }

        public Comptes IdCptNavigation { get; set; }
        public Contacts IdcntNavigation { get; set; }
    }
}
