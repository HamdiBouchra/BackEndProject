using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using BackEndProject.FactoryPattern;
using BackEndProject.Models;
using BackEndProject.Metiers;
using Microsoft.Data;

namespace BackEndProject
{
    public class Program
    {
        public static readonly CRMv1Context contextCRM;

        private static  CRMv1Context _context = new CRMv1Context();
        public static void Main(string[] args)
        {
          /*  LoginModel lg = new LoginModel();
            LogInMetier lm = new LogInMetier();
            IEnumerable<Comptes>  liste = lm.getListComptes(lg);
            Console.WriteLine(liste.Count());
            foreach(Comptes c in liste)
            {
                Console.WriteLine("CPT ====> " + c.Nom);
            }*/
            BuildWebHost(args).Run();
        }

        /*http://192.168.1.81:58083*/
        public static IWebHost BuildWebHost(string[] args) =>
              WebHost.CreateDefaultBuilder(args).UseUrls("http://localhost:58083")
                  .UseStartup<Startup>()
                  .Build();
            
    }
}
