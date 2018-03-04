using System;
using System.Collections.Generic;

namespace BackEndProject.Models
{
    public partial class PublicUser
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Username { get; set; }
        public bool? EstActive { get; set; }
        public int? ContaId { get; set; }

        public Contacts Contact { get; set; }
        public Role Role { get; set; }
    }
}
