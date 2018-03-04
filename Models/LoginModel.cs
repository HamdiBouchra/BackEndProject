using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Models
{
    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public LoginModel(string name,string pwd)
        {
            Username = name;
            Password = pwd;
        }

        public LoginModel()
        {
        }
    }
}
