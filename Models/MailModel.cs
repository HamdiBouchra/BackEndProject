using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class MailModel
    {
       
            public string toName { get; set; }
            public string toAdr { get; set; }
            public string fromName { get; set; }
            public string fromAdr { get; set; }
            public string subject { get; set; }
            public string content { get; set; }
    
    }
}
