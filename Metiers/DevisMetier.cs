using BackEndProject.Helpers;
using BackEndProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BackEndProject.Metiers
{

    public class DevisMetier
    {
        private readonly CRMv1Context _context;
        private IConfiguration _config;
        private TokenHelper _tokenHelper;



        public DevisMetier(CRMv1Context context, IConfiguration config)
        {
            _context = context;
            _config = config;
            _tokenHelper = new TokenHelper(config);
        }

        public DevisMetier()
        {
        }
        public JObject SaveDevisInformation(JObject j, string token)
        {
            dynamic res = new JObject();
            DevisInformation devis = null;
            //   try
            //    {
            int id = j["Devis"]["Id"].ToObject<int>();
            //Il s'agit bien d'une modification d'un devis
            var requ = j["Devis"];
            if (id != -1)
            {
                devis = _context.DevisInformation.First(d => d.Id == id);

                if (requ["nombrePoste"] != null) devis.NbrPoste = requ["nombrePoste"].ToObject<int>();
                if (requ["nombreContrat"] != null) devis.NbrContrat = requ["nombreContrat"].ToObject<int>();
                if (requ["logCompta"] != null) devis.LogCompta = requ["logCompta"].ToObject<Softwares>().Name;
                if (requ["LogGestion"] != null) devis.LogGestion = requ["LogGestion"].ToObject<Softwares>().Name;
                if (requ["lettragePart"] != null) devis.LettragePartiel = requ["lettragePart"].ToObject<int>();
                if (requ["clotureFacture"] != null) devis.ClotureFacture = requ["clotureFacture"].ToObject<int>();
                if (requ["preLettrage"] != null) devis.PreLettrage = requ["preLettrage"].ToObject<int>();
                if (requ["volumetrie"] != null) devis.Volumetrie = requ["volumetrie"].ToObject<int>();
                if (requ["mdrVRTS"] != null) devis.MdrPrcntVirts = requ["mdrVRTS"].ToObject<int>();
                if (requ["mdrLCM"] != null) devis.MdrPrcntTrtSaccept = requ["mdrLCM"].ToObject<int>();
                if (requ["mdrBOR"] != null) devis.MdrPrcntTrtAaccept = requ["mdrBOR"].ToObject<int>();
                if (requ["mdrCHQ"] != null) devis.MdrPrcntChq = requ["mdrCHQ"].ToObject<int>();
                if (requ["mdrAutre"] != null) devis.MdrPrcntAutres = requ["mdrAutre"].ToObject<int>();

                _context.SaveChanges();
                res.saved = true;

            }
            //Il s'agit d'une nouvelle insertion d'un devis
            else
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    int idPublicUser = _tokenHelper.getSidToken(token);
                    PublicUser user = _context.PublicUser.Include(u => u.Contact).Where(t => t.Id == idPublicUser).First();
                    // Console.WriteLine("PUBLIC USER ====> " + user.Username);
                    Comptes cpt = _context.CompteContact.Select(t => t.IdCptNavigation).Where(p => p.MainContactId == user.Contact.Id).FirstOrDefault();
                    Console.WriteLine("COMPTE ID ====> " + cpt.Id);

                    devis = new DevisInformation();
                    if (requ["nombrePoste"] != null) devis.NbrPoste = requ["nombrePoste"].ToObject<int>();
                    if (requ["nombreContrat"] != null) devis.NbrContrat = requ["nombreContrat"].ToObject<int>();
                    if (requ["logCompta"] != null) devis.LogCompta = requ["logCompta"].ToObject<Softwares>().Name;
                    if (requ["LogGestion"] != null) devis.LogGestion = requ["LogGestion"].ToObject<Softwares>().Name;
                    if (requ["lettragePart"] != null) devis.LettragePartiel = requ["lettragePart"].ToObject<int>();
                    if (requ["clotureFacture"] != null) devis.ClotureFacture = requ["clotureFacture"].ToObject<int>();
                    if (requ["preLettrage"] != null) devis.PreLettrage = requ["preLettrage"].ToObject<int>();
                    if (requ["volumetrie"] != null) devis.Volumetrie = requ["volumetrie"].ToObject<int>();
                    if (requ["mdrVRTS"] != null) devis.MdrPrcntVirts = requ["mdrVRTS"].ToObject<int>();
                    if (requ["mdrLCM"] != null) devis.MdrPrcntTrtSaccept = requ["mdrLCM"].ToObject<int>();
                    if (requ["mdrBOR"] != null) devis.MdrPrcntTrtAaccept = requ["mdrBOR"].ToObject<int>();
                    if (requ["mdrCHQ"] != null) devis.MdrPrcntChq = requ["mdrCHQ"].ToObject<int>();
                    if (requ["mdrAutre"] != null) devis.MdrPrcntAutres = requ["mdrAutre"].ToObject<int>();
                    devis.IdCpt = cpt.Id;

                    _context.DevisInformation.Add(devis);
                    _context.SaveChanges();
                    transaction.Commit();
                    res.newId = devis.Id;
                    res.saved = true;
                }
            }
            //  }
            /*    catch (Exception e)
                {
                    res.saved = false;
                    res.error = e.Message;
                    throw;
                }
                finally
                {
                    res.time = DateTime.Now.ToString("HH:mm:ss - dd/MM/yyyy");
                }*/
            return res;
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

        public IEnumerable<DevisInformation> GetDevis(string token)
        {
            int idCompte = this._tokenHelper.getCompteIdToken(token); // get compte id from token claims
            Console.WriteLine("ID COMPOR ===> " + idCompte);
            return this._context.DevisInformation.Where(d => d.IdCpt == idCompte).ToList();
        }

        public void GetIdentite(int idCompte)
        {

        }

        
        public Boolean deleteDevis(long idDevis,string token)
        {
            int idCompte = this._tokenHelper.getCompteIdToken(token); // get compte id from token claims
            DevisInformation devis = _context.DevisInformation.FirstOrDefault(d => d.Id == idDevis);
            if (devis == null) return true;
            if (devis.IdCpt == idCompte)
            {
                try
                {
                    _context.DevisInformation.Remove(devis);
                    this._context.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }



        //JObject j , 




    }
}
