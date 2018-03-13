using BackEndProject.Helpers;
using BackEndProject.Models;
using BackEndProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BackEndProject.FactoryPattern
{
    public class InscriptionMetier : Controller
    {
        public Comptes compte { get; private set; }
        private TokenHelper _tokenHelper;

        private readonly CRMv1Context _context;
        private IConfiguration _config;
        private MailService _mailService;

        public InscriptionMetier(CRMv1Context context, IConfiguration config)
        {
            _context = context;
            _config = config;
            _tokenHelper = new TokenHelper(config);
            _mailService = new MailService(config);
        }

        public InscriptionMetier()
        {
        }


        /**
         * Si l'utilisateur n'est pas actif : activer 
         * Sinon rien faire
         */
        public Boolean ActivateUser(string token)
        {
            PublicUser user = _tokenHelper.ValidateVerificationToken(token);
            user = _context.PublicUser.First(x => x.Id == user.Id);

            if (user != null)
            {
                if (user.EstActive == false)
                {
                    user.EstActive = true;
                    try
                    {
                        _context.SaveChanges();
                        return true;
                    }
                    catch
                    {
                    }
                }
            }
            return false;
        }

        /*
         * Tester si un SIREN est valide 
         **/
        public static bool isSirenValid(string siren)
        {
            if (siren == null)
                return false;

            if ((!Regex.Match(siren, "[0-9]{9}").Success))
            {
                return false;
            }

            if (siren == "".PadLeft(9, '0'))
            {
                return false;
            }
            char[] numbers = siren.ToCharArray();
            int sum = 0;
            for (int i = 1; i <= numbers.Length; i++)
            {
                int nb = Convert.ToInt16("" + numbers[i - 1]);
                if (i % 2 == 0)
                {
                    //par
                    nb = nb * 2;
                    if (nb >= 10)
                    {
                        nb = 1 + (nb % 10);
                    }
                }
                else
                {
                }
                sum += nb;
            }
            return (sum % 10 == 0);
        }

        /*
         * Recupérer les informations du client à partir de son SIREN
         * */
        private async Task<JObject> getInfosFromAPISIRENAsync(string siren)
        {
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
            };
            var client = new System.Net.Http.HttpClient(
                new HttpClientHandler
                {
                    AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
                }
            );
            var response = await client.GetAsync(new Uri("https://data.opendatasoft.com/api/records/1.0/search/?dataset=sirene%40public&q=" + siren));
            var body = await response.Content.ReadAsStringAsync();
            return JObject.Parse(body);
        }


        /*
         * Récupérer les informations à partir du numéro de TVA
         */
        private async Task<JObject> getInfosFromAPITVAAsync(string tva)
        {
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
            };
            var client = new System.Net.Http.HttpClient(
                new HttpClientHandler
                {
                    AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
                }
            );

            //return Ok(JObject.Parse(body));
            var response = await client.GetAsync(new Uri("https://euvat.ga/api/info/" + tva));
            var body = await response.Content.ReadAsStringAsync();
            return JObject.Parse(body);
        }

        /*
         * Vérifier si le num de TVA est valide
         */
        public Boolean IsTvaValide(string tva)
        {
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
            };
            var client = new System.Net.Http.HttpClient(
                new HttpClientHandler
                {
                    AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
                }
            );
            var response = client.GetAsync(new Uri("https://euvat.ga/api/validate/" + tva)).Result;
            var resu = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            Boolean valid = resu["valid"].ToObject<Boolean>();
            if (valid)
                return true;
            return false;
        }

        /*
         * Récupérer le code postale à partir de l'adresse
         */

        public string getCodePostaleFromAdresse(string adresse)
        {
            Console.WriteLine("ADRESSE ============>" + adresse);
            String[] substrings1 = adresse.Split('\n');
            foreach (String s in substrings1)
                Console.WriteLine("SUBSTRING 1 ====> " + s);
            String Part2 = substrings1[1];
            String[] substrings2 = Part2.Split(' ');
            return substrings2[0];
        }


        /*
         * Récupérer la ville à partir de l'adresse
         */

        public string getCityFromAdresse(string adresse)
        {
            String[] substrings1 = adresse.Split('\n');
            String Part2 = substrings1[1];
            String[] substrings2 = Part2.Split(' ');
            return substrings2[1];
        }



        /*
         * Récupérer le pays à travers son code
         */
        public string getCountryFromCode(string codeCountry)
        {
            var request = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
            };
            var client = new System.Net.Http.HttpClient(
                new HttpClientHandler
                {
                    AutomaticDecompression = System.Net.DecompressionMethods.GZip | System.Net.DecompressionMethods.Deflate
                }
            );
            var response = client.GetAsync(new Uri("https://euvat.ga/api/country/" + codeCountry)).Result;
            var resu = JObject.Parse(response.Content.ReadAsStringAsync().Result);
            string country = resu["name"]["common"].ToObject<string>();
            return country;
        }

        /*
         * Méthode d'inscription du client
         * Création d'un compte,contact,publicUser
         */
        public Object Inscrire(JObject j)
        {
            string Identif = j["compte"]["Identifiant"].ToObject<string>();
            Comptes cptAjout = null;
            Contacts ctcAjout = null;
            CompteContact cptCntct = null;
            PublicUser user = null;
            //On va tester selon la réponse de l'identifiant( SIREN ou bien TVA)
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    if (Identif.Equals("Siren"))
                    {
                        string siren = j["compte"]["Siren"].ToObject<string>();
                        if (isSirenValid(siren))
                        {
                            var infosFromAPI = getInfosFromAPISIRENAsync(siren).Result;
                            var PaysId = this.getIdPaysByName(infosFromAPI["records"][0]["fields"]["l7_normalisee"].ToObject<string>());
                            ctcAjout = new Contacts()
                            {
                                Nom = j["contact"]["Nom"].ToObject<string>(),
                                Prenom = j["contact"]["Prenom"].ToObject<string>(),
                                Email = j["contact"]["Email"].ToObject<string>(),
                                Tel = j["contact"]["Tel"].ToObject<string>(),
                                PaysId = PaysId,
                                Typectc = "PROSPECT" // ça va refleter le type du client 
                            };
                            _context.Contacts.Add(ctcAjout);
                            _context.SaveChanges();

                            cptAjout = new Comptes()
                            {
                                Siren = siren,
                                Codepostal = infosFromAPI["records"][0]["fields"]["codpos"].ToObject<string>(),
                                Nom = infosFromAPI["records"][0]["fields"]["nomen_long"].ToObject<string>(),
                                NomCourt = infosFromAPI["records"][0]["fields"]["sigle"].ToObject<string>(),
                                Ville = infosFromAPI["records"][0]["fields"]["nom_dept"].ToObject<string>(),
                                Adresse1 = infosFromAPI["records"][0]["fields"]["l4_normalisee"].ToObject<string>(),
                                PaysId = PaysId,
                                MainContactId = ctcAjout.Id,
                            };

                           
                        }
                    }

                    else if (Identif.Equals("Tva"))
                    {
                        Console.WriteLine("===============> TVAAA");
                       string tva = j["compte"]["NumTva"].ToObject<string>();
                        if (IsTvaValide(tva))
                        {
                            Console.WriteLine("===============> valid");
                            var infosFromAPI = getInfosFromAPITVAAsync(tva).Result;
                            var adresse = infosFromAPI["traderAddress"].ToObject<string>();
                            var PaysIdentif = this.getIdPaysByName(this.getCountryFromCode(infosFromAPI["countryCode"].ToObject<string>()));
                            ctcAjout = new Contacts()
                            {
                                Nom = j["contact"]["Nom"].ToObject<string>(),
                                Prenom = j["contact"]["Prenom"].ToObject<string>(),
                                Email = j["contact"]["Email"].ToObject<string>(),
                                Tel = j["contact"]["Tel"].ToObject<string>(),
                                PaysId = PaysIdentif,
                                Typectc = "PROSPECT" // ça va refleter le type du client 
                            };
                            _context.Contacts.Add(ctcAjout);
                            _context.SaveChanges();

                            cptAjout = new Comptes()
                            {             
                                NumTva = tva,
                                Codepostal = getCodePostaleFromAdresse(adresse.ToString()),
                                Nom = infosFromAPI["traderName"].ToObject<string>(),
                                MainContactId = ctcAjout.Id,
                                PaysId = PaysIdentif,
                                Ville = getCityFromAdresse(adresse.ToString())
                            };
                        }
                      }
                        cptCntct = new CompteContact()
                        {
                            Idcnt = ctcAjout.Id,
                            IdCpt = cptAjout.Id
                        };

                        ctcAjout.CompteContact.Add(cptCntct);
                        cptAjout.CompteContact.Add(cptCntct);

                        user = new PublicUser()
                        {
                            Username = ctcAjout.Email,
                            ContactId = ctcAjout.Id,
                            Password = j["password"].ToObject<string>(),
                            RoleId = 1
                        };
                        _context.Comptes.Add(cptAjout);
                        _context.PublicUser.Add(user);
                        _context.CompteContact.Add(cptCntct);
                        _context.SaveChanges();
                        transaction.Commit();

                        var validationToken = _tokenHelper.BuildMailVerificationToken(user); //Token à envoyer dans un mail de verification avec le mailservice
                        var ourLink = "<a href='"+_config["Jwt:Issuer"] + "Inscription/verify?token=" + validationToken+"' > Clicker ici pour confirmer votre compte </a>";
                        MailModel mailModel = new MailModel()
                        {
                            fromAdr = "bouchra.hamdi95@gmail.com",
                            toAdr = user.Username,
                            fromName = "AWBS TARGET",
                            toName = ctcAjout.Nom,
                            content = ourLink,
                            subject = "Test"
                        };
                        _mailService.SendVerificationMail(mailModel);
                    }
                return new { cmpt = cptAjout, cntct = ctcAjout };
            }            
            catch(DbUpdateException)
            {
              
            }
            return null;
        }


        public Object updateCompte(Comptes c)
        {
            try
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    _context.Comptes.Update(c);
                     transaction.Commit();
                }
            }
            catch(DbUpdateException)
            {

            }

                    return null;
        }

        public IActionResult CreerDossierClient()
        {

            return null;
        }
        
   
        /*
         * Recupérer le pays à partir du SIREN
         * */
        private int getIdPaysByName(string nomPays)
        {
            var p = _context.Pays 
                .First(pp =>pp.Name == nomPays);
            return p.Id;
        }



        public string getActivity(string siren)
        {
            var infosFromAPI = getInfosFromAPISIRENAsync(siren).Result;
            return infosFromAPI["records"][0]["fields"]["activite"].ToObject<string>();
        }

    }
}
    

