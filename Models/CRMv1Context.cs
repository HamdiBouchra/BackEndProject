using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BackEndProject.Models
{
    public partial class CRMv1Context : DbContext
    {
        public virtual DbSet<CompteContact> CompteContact { get; set; }
        public virtual DbSet<Comptes> Comptes { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Devis> Devis { get; set; }
        public virtual DbSet<DevisInformation> DevisInformation { get; set; }
        public virtual DbSet<Factors> Factors { get; set; }
        public virtual DbSet<Fonction> Fonction { get; set; }
        public virtual DbSet<Pays> Pays { get; set; }
        public virtual DbSet<ProduitFa> ProduitFa { get; set; }
        public virtual DbSet<ProduitFactor> ProduitFactor { get; set; }
        public virtual DbSet<PublicUser> PublicUser { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Softwares> Softwares { get; set; }
        public virtual DbSet<TypesContrat> TypesContrat { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-8A5F1J9\SQL;Database=CRMv1;Trusted_Connection=True;");
            }
        }

        public CRMv1Context(DbContextOptions<CRMv1Context> options)
    : base(options)
        { }

        public CRMv1Context()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CompteContact>(entity =>
            {
                entity.HasKey(e => new { e.IdCpt, e.Idcnt });

                entity.HasIndex(e => e.Idcnt);

                entity.HasOne(d => d.IdCptNavigation)
                    .WithMany(p => p.CompteContact)
                    .HasForeignKey(d => d.IdCpt);

                entity.HasOne(d => d.IdcntNavigation)
                    .WithMany(p => p.CompteContact)
                    .HasForeignKey(d => d.Idcnt);
            });

            modelBuilder.Entity<Comptes>(entity =>
            {
                entity.ToTable("COMPTES");

                entity.HasIndex(e => e.AccountingId)
                    .HasName("COMPTES$SoftwaresCOMPTES");

                entity.HasIndex(e => e.Codepostal)
                    .HasName("COMPTES$CODEPOSTAL");

                entity.HasIndex(e => e.FactorId)
                    .HasName("COMPTES$FactorsCOMPTES");

                entity.HasIndex(e => e.IdSuspect)
                    .HasName("COMPTES$IdSuspect");

                entity.HasIndex(e => e.IdcomptePrincipal)
                    .HasName("COMPTES$IDComptePrincipal");

                entity.HasIndex(e => e.InvoicingId)
                    .HasName("COMPTES$SoftwaresCOMPTES1");

                entity.HasIndex(e => e.MainContactId)
                    .HasName("COMPTES$MainContactId");

                entity.HasIndex(e => e.PaysId)
                    .HasName("COMPTES$PaysId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AccHasImpayedInv).HasDefaultValueSql("((0))");

                entity.Property(e => e.AccountingId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Adresse1)
                    .HasColumnName("ADRESSE1")
                    .HasMaxLength(255);

                entity.Property(e => e.Adresse2)
                    .HasColumnName("ADRESSE2")
                    .HasMaxLength(255);

                entity.Property(e => e.AncienFactor1Id).HasColumnName("ANCIEN_FACTOR1_ID");

                entity.Property(e => e.AncienFactor2Id).HasColumnName("ANCIEN_FACTOR2_ID");

                entity.Property(e => e.AutoUpdate)
                    .HasColumnName("AUTO_UPDATE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.AutorisationLicence).HasMaxLength(50);

                entity.Property(e => e.AutorisationMaintenance).HasMaxLength(50);

                entity.Property(e => e.Base)
                    .HasColumnName("BASE")
                    .HasMaxLength(255);

                entity.Property(e => e.Buid).HasColumnName("BUId");

                entity.Property(e => e.Champ1).HasMaxLength(255);

                entity.Property(e => e.CoTitulaire).HasMaxLength(10);

                entity.Property(e => e.CodeContrat).HasMaxLength(50);

                entity.Property(e => e.Codepostal)
                    .HasColumnName("CODEPOSTAL")
                    .HasMaxLength(10);

                entity.Property(e => e.CommentaireInterne)
                    .HasColumnName("Commentaire_Interne")
                    .HasMaxLength(255);

                entity.Property(e => e.Commentaires).HasMaxLength(250);

                entity.Property(e => e.ContractEnd)
                    .HasColumnName("CONTRACT_END")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.ContractNumber).HasMaxLength(50);

                entity.Property(e => e.ContractStart)
                    .HasColumnName("CONTRACT_START")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Contrat)
                    .HasColumnName("CONTRAT")
                    .HasMaxLength(255);

                entity.Property(e => e.CourtierId).HasColumnName("courtierId");

                entity.Property(e => e.CtcCourtierId).HasColumnName("ctcCourtierId");

                entity.Property(e => e.Date1ereHeure).HasColumnType("datetime2(0)");

                entity.Property(e => e.DateDernierEmail).HasColumnType("datetime2(0)");

                entity.Property(e => e.DateLastActivity).HasColumnType("datetime2(0)");

                entity.Property(e => e.DateMajCi)
                    .HasColumnName("Date_Maj_CI")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.DateMajObs)
                    .HasColumnName("Date_Maj_Obs")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.EntiteFactor).HasMaxLength(255);

                entity.Property(e => e.Factor)
                    .HasColumnName("FACTOR")
                    .HasMaxLength(255);

                entity.Property(e => e.FactorId).HasDefaultValueSql("((0))");

                entity.Property(e => e.IdcomptePrincipal)
                    .HasColumnName("IDComptePrincipal")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.InvoicingId).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsLocked).HasColumnName("isLocked");

                entity.Property(e => e.LastHeure).HasColumnType("datetime2(0)");

                entity.Property(e => e.LastUpdate)
                    .HasColumnName("LAST_UPDATE")
                    .HasColumnType("datetime2(0)");

                entity.Property(e => e.Logiciel)
                    .HasColumnName("LOGICIEL")
                    .HasMaxLength(255);

                entity.Property(e => e.MailAbouti).HasMaxLength(255);

                entity.Property(e => e.MainContactId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Nom)
                    .HasColumnName("NOM")
                    .HasMaxLength(255);

                entity.Property(e => e.NomCourt)
                    .HasColumnName("NOM_COURT")
                    .HasMaxLength(50);

                entity.Property(e => e.NumTva)
                    .HasColumnName("NumTVA")
                    .HasMaxLength(50);

                entity.Property(e => e.PaysId).HasDefaultValueSql("((0))");

                entity.Property(e => e.PremHeure).HasColumnType("datetime2(0)");

                entity.Property(e => e.Siren)
                    .HasColumnName("SIREN")
                    .HasMaxLength(14);

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion();

                entity.Property(e => e.Statut).HasMaxLength(255);

                entity.Property(e => e.TitreDernierEmail).HasMaxLength(255);

                entity.Property(e => e.TitulaireFacturation).HasMaxLength(250);

                entity.Property(e => e.Titulaires).HasMaxLength(255);

                entity.Property(e => e.TypeContrat).HasMaxLength(255);

                entity.Property(e => e.TypeTiers).HasMaxLength(255);

                entity.Property(e => e.ValidLicence).HasDefaultValueSql("((0))");

                entity.Property(e => e.Version)
                    .HasColumnName("VERSION")
                    .HasMaxLength(255);

                entity.Property(e => e.Ville)
                    .HasColumnName("VILLE")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Pays)
                    .WithMany(p => p.Comptes)
                    .HasForeignKey(d => d.PaysId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("COMPTES$PaysCOMPTES");
            });

            modelBuilder.Entity<Contacts>(entity =>
            {
                entity.ToTable("CONTACTS");

                entity.HasIndex(e => e.Codepostal)
                    .HasName("CONTACTS$CODEPOSTAL");

                entity.HasIndex(e => e.CompteId)
                    .HasName("CONTACTS$CompteId");

                entity.HasIndex(e => e.PaysId)
                    .HasName("CONTACTS$PaysId");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Actif)
                    .HasColumnName("actif")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Adresse1)
                    .HasColumnName("ADRESSE1")
                    .HasMaxLength(255);

                entity.Property(e => e.Adresse2)
                    .HasColumnName("ADRESSE2")
                    .HasMaxLength(255);

                entity.Property(e => e.Buid).HasColumnName("BUId");

                entity.Property(e => e.Champ17).HasMaxLength(255);

                entity.Property(e => e.Champ21).HasMaxLength(255);

                entity.Property(e => e.Champ22).HasMaxLength(255);

                entity.Property(e => e.Champ25).HasMaxLength(255);

                entity.Property(e => e.Civilite).HasMaxLength(50);

                entity.Property(e => e.Codepostal)
                    .HasColumnName("CODEPOSTAL")
                    .HasMaxLength(255);

                entity.Property(e => e.Commentaires)
                    .HasColumnName("COMMENTAIRES")
                    .HasMaxLength(255);

                entity.Property(e => e.Compagne).HasMaxLength(250);

                entity.Property(e => e.CompteId).HasDefaultValueSql("((0))");

                entity.Property(e => e.CourtierId).HasColumnName("courtierId");

                entity.Property(e => e.DateDernierEmail).HasColumnType("datetime2(0)");

                entity.Property(e => e.Email)
                    .HasColumnName("EMAIL")
                    .HasMaxLength(255);

                entity.Property(e => e.Email2).HasMaxLength(250);

                entity.Property(e => e.Entite)
                    .HasColumnName("ENTITE")
                    .HasMaxLength(255);

                entity.Property(e => e.FactorId).HasColumnName("factorId");

                entity.Property(e => e.Fonction)
                    .HasColumnName("FONCTION")
                    .HasMaxLength(255);

                entity.Property(e => e.IncludeInDiff).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsMassMailing).HasDefaultValueSql("((0))");

                entity.Property(e => e.Keyyo)
                    .HasColumnName("KEYYO")
                    .HasMaxLength(255);

                entity.Property(e => e.Le)
                    .HasColumnName("LE")
                    .HasMaxLength(255);

                entity.Property(e => e.Lieu)
                    .HasColumnName("LIEU")
                    .HasMaxLength(255);

                entity.Property(e => e.MailAbouti).HasMaxLength(255);

                entity.Property(e => e.NextLe)
                    .HasColumnName("NEXT LE")
                    .HasMaxLength(255);

                entity.Property(e => e.Nom)
                    .HasColumnName("NOM")
                    .HasMaxLength(255);

                entity.Property(e => e.Par)
                    .HasColumnName("PAR")
                    .HasMaxLength(255);

                entity.Property(e => e.PaysId).HasDefaultValueSql("((0))");

                entity.Property(e => e.Phonecode).HasMaxLength(50);

                entity.Property(e => e.Phonecode2).HasMaxLength(50);

                entity.Property(e => e.Phonecode3).HasMaxLength(50);

                entity.Property(e => e.Prenom)
                    .HasColumnName("PRENOM")
                    .HasMaxLength(255);

                entity.Property(e => e.Siren)
                    .HasColumnName("SIREN")
                    .HasMaxLength(255);

                entity.Property(e => e.Source)
                    .HasColumnName("SOURCE")
                    .HasMaxLength(255);

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion();

                entity.Property(e => e.Tel)
                    .HasColumnName("TEL")
                    .HasMaxLength(255);

                entity.Property(e => e.Tel2)
                    .HasColumnName("TEL2")
                    .HasMaxLength(255);

                entity.Property(e => e.Tel3)
                    .HasColumnName("TEL3")
                    .HasMaxLength(255);

                entity.Property(e => e.TitreDernierEmail).HasMaxLength(255);

                entity.Property(e => e.TypeVoeux).HasMaxLength(255);

                entity.Property(e => e.Typectc)
                    .HasColumnName("TYPECTC")
                    .HasMaxLength(255);

                entity.Property(e => e.UserCode).HasMaxLength(50);

                entity.Property(e => e.Ville)
                    .HasColumnName("VILLE")
                    .HasMaxLength(255);

                entity.HasOne(d => d.Pays)
                    .WithMany(p => p.Contacts)
                    .HasForeignKey(d => d.PaysId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("CONTACTS$PaysCONTACTS");
            });

            modelBuilder.Entity<Devis>(entity =>
            {
                entity.HasKey(e => e.Idauto);

                entity.ToTable("DEVIS");

                entity.HasIndex(e => e.Id)
                    .HasName("DEVIS$N° DOCUMENT");

                entity.Property(e => e.Idauto).HasColumnName("IDauto");

                entity.Property(e => e.CaEspere)
                    .HasColumnName("CA_ESPERE")
                    .HasMaxLength(255);

                entity.Property(e => e.Champ14).HasMaxLength(255);

                entity.Property(e => e.Commentaire)
                    .HasColumnName("COMMENTAIRE")
                    .HasMaxLength(255);

                entity.Property(e => e.Comptabilise)
                    .HasColumnName("COMPTABILISE")
                    .HasMaxLength(255);

                entity.Property(e => e.Ctrl)
                    .HasColumnName("CTRL")
                    .HasMaxLength(255);

                entity.Property(e => e.DateEmission)
                    .HasColumnName("DATE_EMISSION")
                    .HasMaxLength(255);

                entity.Property(e => e.Description1)
                    .HasColumnName("DESCRIPTION1")
                    .HasMaxLength(255);

                entity.Property(e => e.Description2)
                    .HasColumnName("DESCRIPTION2")
                    .HasMaxLength(255);

                entity.Property(e => e.Description3)
                    .HasColumnName("DESCRIPTION3")
                    .HasMaxLength(255);

                entity.Property(e => e.Description4)
                    .HasColumnName("DESCRIPTION4")
                    .HasMaxLength(255);

                entity.Property(e => e.Doc)
                    .HasColumnName("DOC")
                    .HasMaxLength(255);

                entity.Property(e => e.Ecart)
                    .HasColumnName("ECART")
                    .HasMaxLength(255);

                entity.Property(e => e.Ech)
                    .HasColumnName("ECH")
                    .HasMaxLength(255);

                entity.Property(e => e.Factor)
                    .HasColumnName("FACTOR")
                    .HasMaxLength(255);

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .HasMaxLength(255);

                entity.Property(e => e.MontantHt)
                    .HasColumnName("MONTANT_HT")
                    .HasMaxLength(255);

                entity.Property(e => e.MontantTtc)
                    .HasColumnName("MONTANT_TTC")
                    .HasMaxLength(255);

                entity.Property(e => e.Nom)
                    .HasColumnName("NOM")
                    .HasMaxLength(255);

                entity.Property(e => e.Personne)
                    .HasColumnName("PERSONNE")
                    .HasMaxLength(255);

                entity.Property(e => e.Prixuht1)
                    .HasColumnName("PRIXUHT1")
                    .HasMaxLength(255);

                entity.Property(e => e.Prixuht2)
                    .HasColumnName("PRIXUHT2")
                    .HasMaxLength(255);

                entity.Property(e => e.Prixuht3)
                    .HasColumnName("PRIXUHT3")
                    .HasMaxLength(255);

                entity.Property(e => e.Prixuht4)
                    .HasColumnName("PRIXUHT4")
                    .HasMaxLength(255);

                entity.Property(e => e.Proba)
                    .HasColumnName("PROBA")
                    .HasMaxLength(255);

                entity.Property(e => e.Product1)
                    .HasColumnName("PRODUCT1")
                    .HasMaxLength(255);

                entity.Property(e => e.Product2)
                    .HasColumnName("PRODUCT2")
                    .HasMaxLength(255);

                entity.Property(e => e.Product3)
                    .HasColumnName("PRODUCT3")
                    .HasMaxLength(255);

                entity.Property(e => e.Product4)
                    .HasColumnName("PRODUCT4")
                    .HasMaxLength(255);

                entity.Property(e => e.Quantity1)
                    .HasColumnName("QUANTITY1")
                    .HasMaxLength(255);

                entity.Property(e => e.Quantity2)
                    .HasColumnName("QUANTITY2")
                    .HasMaxLength(255);

                entity.Property(e => e.Quantity3)
                    .HasColumnName("QUANTITY3")
                    .HasMaxLength(255);

                entity.Property(e => e.Quantity4)
                    .HasColumnName("QUANTITY4")
                    .HasMaxLength(255);

                entity.Property(e => e.Rec)
                    .HasColumnName("REC")
                    .HasMaxLength(255);

                entity.Property(e => e.Tva)
                    .HasColumnName("TVA")
                    .HasMaxLength(255);

                entity.Property(e => e.Type1)
                    .HasColumnName("TYPE1")
                    .HasMaxLength(255);

                entity.Property(e => e.Type2)
                    .HasColumnName("TYPE2")
                    .HasMaxLength(255);

                entity.Property(e => e.Type3)
                    .HasColumnName("TYPE3")
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<DevisInformation>(entity =>
            {
                entity.Property(e => e.ClotureFacture).HasColumnName("clotureFacture");

                entity.Property(e => e.IdCpt).HasColumnName("idCpt");

                entity.Property(e => e.LettragePartiel).HasColumnName("lettragePartiel");

                entity.Property(e => e.LogCompta)
                    .HasColumnName("logCompta")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.LogGestion)
                    .HasColumnName("logGestion")
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.MdrPrcntAutres).HasColumnName("mdrPrcntAutres");

                entity.Property(e => e.MdrPrcntChq).HasColumnName("mdrPrcntCHQ");

                entity.Property(e => e.MdrPrcntTrtAaccept).HasColumnName("mdrPrcntTrtAaccept");

                entity.Property(e => e.MdrPrcntTrtSaccept).HasColumnName("mdrPrcntTrtSaccept");

                entity.Property(e => e.MdrPrcntVirts).HasColumnName("mdrPrcntVIRTS");

                entity.Property(e => e.NbrContrat).HasColumnName("nbrContrat");

                entity.Property(e => e.NbrPoste).HasColumnName("nbrPoste");

                entity.Property(e => e.PreLettrage).HasColumnName("preLettrage");

                entity.Property(e => e.Volumetrie).HasColumnName("volumetrie");

                entity.HasOne(d => d.IdCptNavigation)
                    .WithMany(p => p.DevisInformation)
                    .HasForeignKey(d => d.IdCpt)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("IdComptes");
            });

            modelBuilder.Entity<Factors>(entity =>
            {
                entity.HasIndex(e => e.FactorCode)
                    .HasName("Factors$FactorCode")
                    .IsUnique();

                entity.HasIndex(e => e.Id)
                    .HasName("Factors$Id");

                entity.Property(e => e.FactorCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FactorName).HasMaxLength(255);

                entity.Property(e => e.NumCompte).HasMaxLength(30);
            });

            modelBuilder.Entity<Fonction>(entity =>
            {
                entity.HasIndex(e => e.FactorId)
                    .HasName("Fonction$fk_FactorId2");

                entity.Property(e => e.Title).HasMaxLength(50);

                entity.HasOne(d => d.Factor)
                    .WithMany(p => p.Fonction)
                    .HasForeignKey(d => d.FactorId)
                    .HasConstraintName("Fonction$fk_FactorId2");
            });

            modelBuilder.Entity<Pays>(entity =>
            {
                entity.HasIndex(e => e.Id)
                    .HasName("Pays$pays_id");

                entity.HasIndex(e => e.IsoCode)
                    .HasName("Pays$code_pays");

                entity.Property(e => e.IsCee).HasDefaultValueSql("((0))");

                entity.Property(e => e.IsDomTom)
                    .HasColumnName("IsDomTOm")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.IsoCode).HasMaxLength(3);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phonecode).HasMaxLength(50);

                entity.Property(e => e.SsmaTimeStamp)
                    .IsRequired()
                    .HasColumnName("SSMA_TimeStamp")
                    .IsRowVersion();
            });

            modelBuilder.Entity<ProduitFa>(entity =>
            {
                entity.HasKey(e => e.IdProduit);

                entity.ToTable("produitFa");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(150);

                entity.Property(e => e.TypeId).HasColumnName("typeId");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.ProduitFa)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("FK_produitFa_TypesContrat");
            });

            modelBuilder.Entity<ProduitFactor>(entity =>
            {
                entity.HasKey(e => new { e.IdProduit, e.IdFactor });

                entity.Property(e => e.IdFactor).HasColumnName("idFactor");

                entity.HasOne(d => d.IdFactorNavigation)
                    .WithMany(p => p.ProduitFactor)
                    .HasForeignKey(d => d.IdFactor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idFact");

                entity.HasOne(d => d.IdProduitNavigation)
                    .WithMany(p => p.ProduitFactor)
                    .HasForeignKey(d => d.IdProduit)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idProd");
            });

            modelBuilder.Entity<PublicUser>(entity =>
            {
                entity.HasIndex(e => e.ContactId)
                    .HasName("PublicUser$publicUser_contactId");

                entity.HasIndex(e => e.Id)
                    .HasName("PublicUser$publicUser_id");

                entity.HasIndex(e => e.Password)
                    .HasName("PublicUser$publicUser_password");

                entity.HasIndex(e => e.RoleId);

                entity.HasIndex(e => e.Username)
                    .HasName("PublicUser$publicUser_username");

                entity.Property(e => e.EstActive).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Contact)
                    .WithMany(p => p.PublicUser)
                    .HasForeignKey(d => d.ContactId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PublicUse__Conta__47DBAE45");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PublicUser)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Role_Id");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasIndex(e => e.Description)
                    .HasName("Role$Role_description");

                entity.HasIndex(e => e.Id)
                    .HasName("Role$Role_id");
            });

            modelBuilder.Entity<Softwares>(entity =>
            {
                entity.Property(e => e.CompteId)
                    .HasColumnName("CompteID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.DbType).HasMaxLength(100);

                entity.Property(e => e.Edition).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Version).HasMaxLength(20);
            });

            modelBuilder.Entity<TypesContrat>(entity =>
            {
                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LettragePart).HasColumnName("lettragePart");

                entity.Property(e => e.Lpimpact).HasColumnName("LPimpact");

                entity.Property(e => e.MdrtrtAacceptation).HasColumnName("MDRtrtAacceptation");

                entity.Property(e => e.MdrtrtSacceptation).HasColumnName("MDRtrtSacceptation");

                entity.Property(e => e.MinNbrContat).HasColumnName("minNbrContat");

                entity.Property(e => e.MinNbrPosteInstalle).HasColumnName("minNbrPosteInstalle");

                entity.Property(e => e.PrixBase).HasColumnName("prixBase");

                entity.Property(e => e.Sigle)
                    .HasColumnName("sigle")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UniteSuppContrat).HasColumnName("uniteSuppContrat");

                entity.Property(e => e.UniteSuppNbrPoste).HasColumnName("uniteSuppNbrPoste");

                entity.Property(e => e.Vipf).HasColumnName("VIPF");

                entity.Property(e => e.Vnb).HasColumnName("VNB");

                entity.Property(e => e.Vnh).HasColumnName("VNH");

                entity.Property(e => e.Vspf).HasColumnName("VSPF");
            });
        }
    }
}
