using BackEndProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Metiers
{
  
    public class InstallationMetier
    {
        private IConfiguration _config;
        private readonly CRMv1Context _context;

        public InstallationMetier(IConfiguration config)
        {
            _context = new CRMv1Context();
            _config = config;
        }


        public IEnumerable<Factors> getAllFactors()
        {
            var listFactors = _context.Factors.Include(p => p.ProduitFactor).ThenInclude(p => p.IdProduitNavigation).ToList();
                return listFactors;
        }

        public IEnumerable<Softwares> getAllSoftwares()
        {
            var listSoftwares = _context.Softwares.ToList();
            return listSoftwares;
        }

        public TypesContrat getContratType(int Idproduit)
        {
            int typeId = (int) _context.ProduitFa.Where(p => p.IdProduit == Idproduit).Select(t => t.TypeId).FirstOrDefault();
            Console.WriteLine("TC TYPE ID ====> " + typeId);
            TypesContrat type = _context.TypesContrat.Where(t => t.Id == typeId).FirstOrDefault();
            Console.WriteLine("TC TYPE Desc ====> " + type.Sigle);
            return type;
        }


        public double calculDevis(int produitId, int IdDevis)
        {
            DevisInformation devis = null;
            double resuDevis = 0.0;
            double mdrCalcul = 0.0;
            double LettP = 0.0;
            DevisInformation devisInfos = _context.DevisInformation.Include(c => c.IdCptNavigation).Where(d => d.Id == IdDevis).FirstOrDefault();
            Console.WriteLine("DEVIS INFOS =====> " + devisInfos.LogCompta);
            devis = new DevisInformation()
            {
                NbrPoste = devisInfos.NbrPoste,
                NbrContrat = devisInfos.NbrContrat,
                LogCompta = devisInfos.LogCompta,
                LogGestion = devisInfos.LogGestion,
                LettragePartiel = devisInfos.LettragePartiel,
                ClotureFacture = devisInfos.ClotureFacture,
                PreLettrage = devisInfos.PreLettrage,
                Volumetrie = devisInfos.Volumetrie,
                IdCpt = devisInfos.IdCpt,
                MdrPrcntTrtAaccept = devisInfos.MdrPrcntTrtAaccept,
                MdrPrcntChq = devisInfos.MdrPrcntChq,
                MdrPrcntTrtSaccept = devisInfos.MdrPrcntTrtSaccept,
                MdrPrcntVirts = devisInfos.MdrPrcntVirts,
                MdrPrcntAutres = devisInfos.MdrPrcntAutres
            };
            if (devis.NbrPoste > 0 && devis.NbrContrat > 0 && !devis.LogCompta.Equals("") && !devis.LogGestion.Equals("") && ((devis.LettragePartiel == 1) ||
               (devis.LettragePartiel == 0)) && ((devis.PreLettrage == 1) || (devis.PreLettrage == 0)) && (devis.Volumetrie > 0))
            {
                double impactPrix = 0.0;
                TypesContrat tc = this.getContratType(produitId);
                Console.WriteLine("TC TYPE ====> " + tc.Sigle);
                resuDevis = (double)tc.PrixBase;
                if (devis.NbrPoste >= tc.MinNbrPosteInstalle)
                    resuDevis += ((double)devis.NbrPoste - (double)tc.MinNbrPosteInstalle) * (double)tc.UniteSuppNbrPoste;
                if (devis.NbrContrat >= tc.MinNbrContat)
                    resuDevis += ((double)devis.NbrContrat - (double)tc.MinNbrPosteInstalle) * (double)tc.UniteSuppContrat;
                if (devis.Volumetrie >= tc.LimiteHausse)
                    impactPrix += ((double)tc.LimiteHausse - (double)tc.Vnh) * (double)tc.Vspf;
                else
                {
                    if (devis.Volumetrie >= tc.Vnh)
                        impactPrix += (double)tc.Vspf * ((double)devis.Volumetrie - (double)tc.Vnh);
                    else
                    {
                        if (devis.Volumetrie >= tc.Vnb)
                            impactPrix += 0.0;
                        else
                        {
                            if (devis.Volumetrie >= tc.LimiteBasse)
                                impactPrix += ((double)tc.Vnb - (double)devis.Volumetrie) * (double)tc.Vipf * (-1);
                            else
                                impactPrix += ((double)tc.Vnb - (double)tc.LimiteBasse) * (double)tc.Vipf * (-1);
                        }
                    }
                }
                resuDevis += impactPrix;
                if ((impactPrix + tc.PrixBase) > 0)
                {
                    if ((devis.MdrPrcntTrtAaccept + devis.MdrPrcntTrtSaccept) > 0)
                    {
                        if (tc.Sigle != "CLA")
                            mdrCalcul += (double)tc.MdrtrtSacceptation * (double)devis.MdrPrcntTrtSaccept + (double)tc.MdrtrtAacceptation * (double)devis.MdrPrcntTrtAaccept;
                        else
                            mdrCalcul += (double)tc.MdrtrtSacceptation;
                    }
                }
                if (devis.LettragePartiel == 1)
                    LettP = (double)tc.LettragePart;
                resuDevis += (double)(impactPrix + tc.PrixBase) * (mdrCalcul + LettP);
                Console.WriteLine("Achat licence == " + resuDevis);
            }
            return resuDevis;
        }
    }
}
