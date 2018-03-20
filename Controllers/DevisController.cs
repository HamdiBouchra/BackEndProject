using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BackEndProject.Metiers;
using Microsoft.Extensions.Configuration;
using BackEndProject.Models;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.Primitives;

namespace BackEndProject.Controllers
{
    [Produces("application/json")]
    [Route("[controller]")]
    public class DevisController : Controller
    {
        private readonly CRMv1Context _context;
        private DevisMetier _devisMetier;
        private IConfiguration _config;


        public DevisController(CRMv1Context context, IConfiguration config)
        {
            _context = context;
            _config = config;
            _devisMetier = new DevisMetier(context, config);

        }
       
        public JObject SaveIdentiteInformation(JObject j)
{
    dynamic res = new JObject();

    //try
    //{
    //    using (var transaction = _context.Database.BeginTransaction())
    //    {
    //        PublicUser user = _context.PublicUser.Where(t => t.Id == _tokenHelper.getSidToken(j)).First();
    //        Comptes cpt = _context.CompteContact.Select(t => t.IdCptNavigation).Where(p => p.MainContactId == user.Contact.Id).FirstOrDefault();
    //        DevisInformation devis = new DevisInformation()
    //        {
    //            NbrPoste = int.Parse(j["Devis"]["nombrePoste"].ToObject<string>()),
    //            NbrContrat = int.Parse(j["Devis"]["nombreContrat"].ToObject<string>()),
    //            LogCompta = j["Devis"]["logCompta"].ToObject<string>(),
    //            LogGestion = j["Devis"]["logGestion"].ToObject<string>(),
    //            LettragePartiel = j["Devis"]["lettragePart"].ToObject<int>(),
    //            ClotureFacture = j["Devis"]["clotureFacture"].ToObject<int>(),
    //            PreLettrage = j["Devis"]["preLettrage"].ToObject<int>(),
    //            Volumetrie = j["Devis"]["volumetrie"].ToObject<int>(),
    //            IdCpt = cpt.Id
    //        };
    //        _context.DevisInformation.Add(devis);
    //        _context.SaveChanges();
    //        res.saved = true;
    //        res.time = DateTime.Now;
    //    }
    //}
    //catch (Exception e)
    //{
    //    res.saved = false;
    //    res.time = DateTime.Now;
    //    res.error = e.Message;
    //}
    return res;
}


 
        [Route("SaveDevis")]
        [HttpPost, Authorize(Roles = "Admin")]
        public IActionResult SaveDevis([FromBody] JObject newDevisInformation)
        {
            StringValues token;
            Request.Headers.TryGetValue("Authorization", out token);
            JObject res = this._devisMetier.SaveDevisInformation(newDevisInformation, token.ToString().Substring(7));
            Boolean b = (Boolean)res["saved"];
            if ((Boolean)res["saved"])
            {
                return Ok(res);
            }
            else
            {
                return StatusCode(500, res);
            }
        }


        [Route("SaveDevis")]
        [HttpPost, Authorize(Roles = "Admin")]
        public IActionResult SaveIdentity([FromBody] JObject newDevisInformation)
        {
            JObject res = null;
           
                StringValues token;
                Request.Headers.TryGetValue("Authorization", out token);
                 res = this._devisMetier.SaveIdentiteInformation(newDevisInformation, token.ToString().Substring(7));
                Boolean b = (Boolean)res["saved"];
                if ((Boolean)res["saved"])
                {
                    return Ok(res);
                }
                else
                {
                    return StatusCode(500, res);
                }
           
        }



        [Route("getDevis")]
        [HttpGet, Authorize(Roles = "Admin")]
        public IActionResult GetDevis()
        {
            StringValues token;
            Request.Headers.TryGetValue("Authorization", out token);
            return Ok(this._devisMetier.GetDevis(token.ToString().Substring(7)));
        }

        [Route("deleteDevis")]
        [HttpDelete("{idDevis}"), Authorize(Roles = "Admin")]
        public IActionResult deleteDevis(long idDevis)
        {
            StringValues token;
            Request.Headers.TryGetValue("Authorization", out token);          
            return Ok(_devisMetier.deleteDevis(idDevis, token.ToString().Substring(7)));
        }

    }
    }