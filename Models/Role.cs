using System;
using System.Collections.Generic;

namespace BackEndProject.Models
{
    public partial class Role
    {
        public Role()
        {
            PublicUser = new HashSet<PublicUser>();
        }

        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<PublicUser> PublicUser { get; set; }
    }
}
