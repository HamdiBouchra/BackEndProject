﻿// <auto-generated />
using BackEndProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace BackEndProject.Migrations
{
    [DbContext(typeof(CRMv1Context))]
    [Migration("20180302145939_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEndProject.Models.CompteContact", b =>
                {
                    b.Property<int>("IdCpt");

                    b.Property<int>("Idcnt");

                    b.HasKey("IdCpt", "Idcnt");

                    b.HasIndex("Idcnt");

                    b.ToTable("CompteContact");
                });

            modelBuilder.Entity("BackEndProject.Models.Comptes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<bool?>("AccHasImpayedInv")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("AccountingId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Adresse1")
                        .HasColumnName("ADRESSE1")
                        .HasMaxLength(255);

                    b.Property<string>("Adresse2")
                        .HasColumnName("ADRESSE2")
                        .HasMaxLength(255);

                    b.Property<int?>("AncienFactor1Id")
                        .HasColumnName("ANCIEN_FACTOR1_ID");

                    b.Property<int?>("AncienFactor2Id")
                        .HasColumnName("ANCIEN_FACTOR2_ID");

                    b.Property<bool?>("AutoUpdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("AUTO_UPDATE")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("AutorisationLicence")
                        .HasMaxLength(50);

                    b.Property<string>("AutorisationMaintenance")
                        .HasMaxLength(50);

                    b.Property<string>("Base")
                        .HasColumnName("BASE")
                        .HasMaxLength(255);

                    b.Property<bool?>("BlockTypeTierUpdate");

                    b.Property<int?>("Buid")
                        .HasColumnName("BUId");

                    b.Property<string>("Champ1")
                        .HasMaxLength(255);

                    b.Property<int?>("ClientCount");

                    b.Property<string>("CoTitulaire")
                        .HasMaxLength(10);

                    b.Property<string>("CodeContrat")
                        .HasMaxLength(50);

                    b.Property<string>("Codepostal")
                        .HasColumnName("CODEPOSTAL")
                        .HasMaxLength(10);

                    b.Property<string>("CommentaireInterne")
                        .HasColumnName("Commentaire_Interne")
                        .HasMaxLength(255);

                    b.Property<string>("Commentaires")
                        .HasMaxLength(250);

                    b.Property<DateTime?>("ContractEnd")
                        .HasColumnName("CONTRACT_END")
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("ContractNumber")
                        .HasMaxLength(50);

                    b.Property<DateTime?>("ContractStart")
                        .HasColumnName("CONTRACT_START")
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("Contrat")
                        .HasColumnName("CONTRAT")
                        .HasMaxLength(255);

                    b.Property<int?>("CourtierId")
                        .HasColumnName("courtierId");

                    b.Property<int?>("CtcCourtierId")
                        .HasColumnName("ctcCourtierId");

                    b.Property<DateTime?>("Date1ereHeure")
                        .HasColumnType("datetime2(0)");

                    b.Property<DateTime?>("DateDernierEmail")
                        .HasColumnType("datetime2(0)");

                    b.Property<DateTime?>("DateLastActivity")
                        .HasColumnType("datetime2(0)");

                    b.Property<DateTime?>("DateMajCi")
                        .HasColumnName("Date_Maj_CI")
                        .HasColumnType("datetime2(0)");

                    b.Property<DateTime?>("DateMajObs")
                        .HasColumnName("Date_Maj_Obs")
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("EntiteFactor")
                        .HasMaxLength(255);

                    b.Property<string>("Factor")
                        .HasColumnName("FACTOR")
                        .HasMaxLength(255);

                    b.Property<int?>("FactorId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("GestionContactId");

                    b.Property<double?>("Heures1annee");

                    b.Property<int?>("IdSuspect");

                    b.Property<int>("IdcomptePrincipal")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDComptePrincipal")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("InfoContactId");

                    b.Property<int?>("InvoiceCount");

                    b.Property<int?>("InvoicingId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<bool?>("IsLocked")
                        .HasColumnName("isLocked");

                    b.Property<DateTime?>("LastHeure")
                        .HasColumnType("datetime2(0)");

                    b.Property<DateTime?>("LastUpdate")
                        .HasColumnName("LAST_UPDATE")
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("Link");

                    b.Property<string>("Logiciel")
                        .HasColumnName("LOGICIEL")
                        .HasMaxLength(255);

                    b.Property<string>("MailAbouti")
                        .HasMaxLength(255);

                    b.Property<int?>("MainContactId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Nom")
                        .HasColumnName("NOM")
                        .HasMaxLength(255);

                    b.Property<string>("NomCourt")
                        .HasColumnName("NOM_COURT")
                        .HasMaxLength(50);

                    b.Property<string>("NumTva")
                        .HasColumnName("NumTVA")
                        .HasMaxLength(50);

                    b.Property<int?>("OtherContactId");

                    b.Property<int>("PaysId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<DateTime?>("PremHeure")
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("Siren")
                        .HasColumnName("SIREN")
                        .HasMaxLength(14);

                    b.Property<byte[]>("SsmaTimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("SSMA_TimeStamp");

                    b.Property<string>("Statut")
                        .HasMaxLength(255);

                    b.Property<int?>("TauxCourtage");

                    b.Property<string>("TitreDernierEmail")
                        .HasMaxLength(255);

                    b.Property<string>("TitulaireFacturation")
                        .HasMaxLength(250);

                    b.Property<string>("Titulaires")
                        .HasMaxLength(255);

                    b.Property<double?>("Turnover");

                    b.Property<string>("TypeContrat")
                        .HasMaxLength(255);

                    b.Property<string>("TypeTiers")
                        .HasMaxLength(255);

                    b.Property<bool?>("ValidLicence")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Version")
                        .HasColumnName("VERSION")
                        .HasMaxLength(255);

                    b.Property<string>("Ville")
                        .HasColumnName("VILLE")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("AccountingId")
                        .HasName("COMPTES$SoftwaresCOMPTES");

                    b.HasIndex("Codepostal")
                        .HasName("COMPTES$CODEPOSTAL");

                    b.HasIndex("FactorId")
                        .HasName("COMPTES$FactorsCOMPTES");

                    b.HasIndex("IdSuspect")
                        .HasName("COMPTES$IdSuspect");

                    b.HasIndex("IdcomptePrincipal")
                        .HasName("COMPTES$IDComptePrincipal");

                    b.HasIndex("InvoicingId")
                        .HasName("COMPTES$SoftwaresCOMPTES1");

                    b.HasIndex("MainContactId")
                        .HasName("COMPTES$MainContactId");

                    b.HasIndex("PaysId")
                        .HasName("COMPTES$PaysId");

                    b.ToTable("COMPTES");
                });

            modelBuilder.Entity("BackEndProject.Models.Contacts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID");

                    b.Property<bool?>("Actif")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("actif")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Adresse1")
                        .HasColumnName("ADRESSE1")
                        .HasMaxLength(255);

                    b.Property<string>("Adresse2")
                        .HasColumnName("ADRESSE2")
                        .HasMaxLength(255);

                    b.Property<int?>("Buid")
                        .HasColumnName("BUId");

                    b.Property<string>("Champ17")
                        .HasMaxLength(255);

                    b.Property<string>("Champ21")
                        .HasMaxLength(255);

                    b.Property<string>("Champ22")
                        .HasMaxLength(255);

                    b.Property<string>("Champ25")
                        .HasMaxLength(255);

                    b.Property<string>("Civilite")
                        .HasMaxLength(50);

                    b.Property<string>("Codepostal")
                        .HasColumnName("CODEPOSTAL")
                        .HasMaxLength(255);

                    b.Property<string>("Commentaires")
                        .HasColumnName("COMMENTAIRES")
                        .HasMaxLength(255);

                    b.Property<string>("Compagne")
                        .HasMaxLength(250);

                    b.Property<int?>("CompteId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("CourtierId")
                        .HasColumnName("courtierId");

                    b.Property<DateTime?>("DateDernierEmail")
                        .HasColumnType("datetime2(0)");

                    b.Property<string>("Email")
                        .HasColumnName("EMAIL")
                        .HasMaxLength(255);

                    b.Property<string>("Email2")
                        .HasMaxLength(250);

                    b.Property<string>("Entite")
                        .HasColumnName("ENTITE")
                        .HasMaxLength(255);

                    b.Property<int?>("FactorId")
                        .HasColumnName("factorId");

                    b.Property<string>("Fonction")
                        .HasColumnName("FONCTION")
                        .HasMaxLength(255);

                    b.Property<int?>("FonctionId");

                    b.Property<bool?>("IncludeInDiff")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<bool?>("IsMassMailing")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Keyyo")
                        .HasColumnName("KEYYO")
                        .HasMaxLength(255);

                    b.Property<int?>("LangueId");

                    b.Property<string>("Le")
                        .HasColumnName("LE")
                        .HasMaxLength(255);

                    b.Property<string>("Lieu")
                        .HasColumnName("LIEU")
                        .HasMaxLength(255);

                    b.Property<string>("MailAbouti")
                        .HasMaxLength(255);

                    b.Property<string>("NextLe")
                        .HasColumnName("NEXT LE")
                        .HasMaxLength(255);

                    b.Property<string>("Nom")
                        .HasColumnName("NOM")
                        .HasMaxLength(255);

                    b.Property<string>("Par")
                        .HasColumnName("PAR")
                        .HasMaxLength(255);

                    b.Property<int>("PaysId")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Phonecode")
                        .HasMaxLength(50);

                    b.Property<string>("Phonecode2")
                        .HasMaxLength(50);

                    b.Property<string>("Phonecode3")
                        .HasMaxLength(50);

                    b.Property<string>("Prenom")
                        .HasColumnName("PRENOM")
                        .HasMaxLength(255);

                    b.Property<string>("Siren")
                        .HasColumnName("SIREN")
                        .HasMaxLength(255);

                    b.Property<string>("Source")
                        .HasColumnName("SOURCE")
                        .HasMaxLength(255);

                    b.Property<byte[]>("SsmaTimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("SSMA_TimeStamp");

                    b.Property<string>("Tel")
                        .HasColumnName("TEL")
                        .HasMaxLength(255);

                    b.Property<string>("Tel2")
                        .HasColumnName("TEL2")
                        .HasMaxLength(255);

                    b.Property<string>("Tel3")
                        .HasColumnName("TEL3")
                        .HasMaxLength(255);

                    b.Property<string>("TitreDernierEmail")
                        .HasMaxLength(255);

                    b.Property<bool?>("Tutoiement");

                    b.Property<string>("TypeVoeux")
                        .HasMaxLength(255);

                    b.Property<string>("Typectc")
                        .HasColumnName("TYPECTC")
                        .HasMaxLength(255);

                    b.Property<string>("UserCode")
                        .HasMaxLength(50);

                    b.Property<string>("Ville")
                        .HasColumnName("VILLE")
                        .HasMaxLength(255);

                    b.HasKey("Id");

                    b.HasIndex("Codepostal")
                        .HasName("CONTACTS$CODEPOSTAL");

                    b.HasIndex("CompteId")
                        .HasName("CONTACTS$CompteId");

                    b.HasIndex("PaysId")
                        .HasName("CONTACTS$PaysId");

                    b.ToTable("CONTACTS");
                });

            modelBuilder.Entity("BackEndProject.Models.Devis", b =>
                {
                    b.Property<int>("Idauto")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IDauto");

                    b.Property<string>("CaEspere")
                        .HasColumnName("CA_ESPERE")
                        .HasMaxLength(255);

                    b.Property<string>("Champ14")
                        .HasMaxLength(255);

                    b.Property<string>("Commentaire")
                        .HasColumnName("COMMENTAIRE")
                        .HasMaxLength(255);

                    b.Property<string>("Comptabilise")
                        .HasColumnName("COMPTABILISE")
                        .HasMaxLength(255);

                    b.Property<string>("Ctrl")
                        .HasColumnName("CTRL")
                        .HasMaxLength(255);

                    b.Property<string>("DateEmission")
                        .HasColumnName("DATE_EMISSION")
                        .HasMaxLength(255);

                    b.Property<string>("Description1")
                        .HasColumnName("DESCRIPTION1")
                        .HasMaxLength(255);

                    b.Property<string>("Description2")
                        .HasColumnName("DESCRIPTION2")
                        .HasMaxLength(255);

                    b.Property<string>("Description3")
                        .HasColumnName("DESCRIPTION3")
                        .HasMaxLength(255);

                    b.Property<string>("Description4")
                        .HasColumnName("DESCRIPTION4")
                        .HasMaxLength(255);

                    b.Property<string>("Doc")
                        .HasColumnName("DOC")
                        .HasMaxLength(255);

                    b.Property<string>("Ecart")
                        .HasColumnName("ECART")
                        .HasMaxLength(255);

                    b.Property<string>("Ech")
                        .HasColumnName("ECH")
                        .HasMaxLength(255);

                    b.Property<string>("Factor")
                        .HasColumnName("FACTOR")
                        .HasMaxLength(255);

                    b.Property<string>("Id")
                        .HasColumnName("ID")
                        .HasMaxLength(255);

                    b.Property<string>("MontantHt")
                        .HasColumnName("MONTANT_HT")
                        .HasMaxLength(255);

                    b.Property<string>("MontantTtc")
                        .HasColumnName("MONTANT_TTC")
                        .HasMaxLength(255);

                    b.Property<string>("Nom")
                        .HasColumnName("NOM")
                        .HasMaxLength(255);

                    b.Property<string>("Personne")
                        .HasColumnName("PERSONNE")
                        .HasMaxLength(255);

                    b.Property<string>("Prixuht1")
                        .HasColumnName("PRIXUHT1")
                        .HasMaxLength(255);

                    b.Property<string>("Prixuht2")
                        .HasColumnName("PRIXUHT2")
                        .HasMaxLength(255);

                    b.Property<string>("Prixuht3")
                        .HasColumnName("PRIXUHT3")
                        .HasMaxLength(255);

                    b.Property<string>("Prixuht4")
                        .HasColumnName("PRIXUHT4")
                        .HasMaxLength(255);

                    b.Property<string>("Proba")
                        .HasColumnName("PROBA")
                        .HasMaxLength(255);

                    b.Property<string>("Product1")
                        .HasColumnName("PRODUCT1")
                        .HasMaxLength(255);

                    b.Property<string>("Product2")
                        .HasColumnName("PRODUCT2")
                        .HasMaxLength(255);

                    b.Property<string>("Product3")
                        .HasColumnName("PRODUCT3")
                        .HasMaxLength(255);

                    b.Property<string>("Product4")
                        .HasColumnName("PRODUCT4")
                        .HasMaxLength(255);

                    b.Property<string>("Quantity1")
                        .HasColumnName("QUANTITY1")
                        .HasMaxLength(255);

                    b.Property<string>("Quantity2")
                        .HasColumnName("QUANTITY2")
                        .HasMaxLength(255);

                    b.Property<string>("Quantity3")
                        .HasColumnName("QUANTITY3")
                        .HasMaxLength(255);

                    b.Property<string>("Quantity4")
                        .HasColumnName("QUANTITY4")
                        .HasMaxLength(255);

                    b.Property<string>("Rec")
                        .HasColumnName("REC")
                        .HasMaxLength(255);

                    b.Property<string>("Tva")
                        .HasColumnName("TVA")
                        .HasMaxLength(255);

                    b.Property<string>("Type1")
                        .HasColumnName("TYPE1")
                        .HasMaxLength(255);

                    b.Property<string>("Type2")
                        .HasColumnName("TYPE2")
                        .HasMaxLength(255);

                    b.Property<string>("Type3")
                        .HasColumnName("TYPE3")
                        .HasMaxLength(255);

                    b.HasKey("Idauto");

                    b.HasIndex("Id")
                        .HasName("DEVIS$N° DOCUMENT");

                    b.ToTable("DEVIS");
                });

            modelBuilder.Entity("BackEndProject.Models.Factors", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FactorCode")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("FactorName")
                        .HasMaxLength(255);

                    b.Property<string>("NumCompte")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("FactorCode")
                        .IsUnique()
                        .HasName("Factors$FactorCode");

                    b.HasIndex("Id")
                        .HasName("Factors$Id");

                    b.ToTable("Factors");
                });

            modelBuilder.Entity("BackEndProject.Models.Fonction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("FactorId");

                    b.Property<string>("Title")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("FactorId")
                        .HasName("Fonction$fk_FactorId2");

                    b.ToTable("Fonction");
                });

            modelBuilder.Entity("BackEndProject.Models.Pays", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool?>("IsCee")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<bool?>("IsDomTom")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("IsDomTOm")
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("IsoCode")
                        .HasMaxLength(3);

                    b.Property<string>("Name")
                        .HasMaxLength(50);

                    b.Property<string>("Phonecode")
                        .HasMaxLength(50);

                    b.Property<byte[]>("SsmaTimeStamp")
                        .IsConcurrencyToken()
                        .IsRequired()
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnName("SSMA_TimeStamp");

                    b.HasKey("Id");

                    b.HasIndex("Id")
                        .HasName("Pays$pays_id");

                    b.HasIndex("IsoCode")
                        .HasName("Pays$code_pays");

                    b.ToTable("Pays");
                });

            modelBuilder.Entity("BackEndProject.Models.ProduitFa", b =>
                {
                    b.Property<int>("IdProduit")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description")
                        .HasColumnName("description")
                        .HasMaxLength(50);

                    b.HasKey("IdProduit");

                    b.ToTable("produitFa");
                });

            modelBuilder.Entity("BackEndProject.Models.ProduitFactor", b =>
                {
                    b.Property<int>("IdFact");

                    b.Property<int>("IdProd");

                    b.HasKey("IdFact", "IdProd");

                    b.HasIndex("IdProd");

                    b.ToTable("ProduitFactor");
                });

            modelBuilder.Entity("BackEndProject.Models.PublicUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ContaId");

                    b.Property<int>("ContactId");

                    b.Property<bool?>("EstActive")
                        .ValueGeneratedOnAdd()
                        .HasDefaultValueSql("((0))");

                    b.Property<string>("Password");

                    b.Property<int>("RoleId");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("ContactId")
                        .HasName("PublicUser$publicUser_contactId");

                    b.HasIndex("Id")
                        .HasName("PublicUser$publicUser_id");

                    b.HasIndex("Password")
                        .HasName("PublicUser$publicUser_password");

                    b.HasIndex("RoleId");

                    b.HasIndex("Username")
                        .HasName("PublicUser$publicUser_username");

                    b.ToTable("PublicUser");
                });

            modelBuilder.Entity("BackEndProject.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.HasKey("Id");

                    b.HasIndex("Description")
                        .HasName("Role$Role_description");

                    b.HasIndex("Id")
                        .HasName("Role$Role_id");

                    b.ToTable("Role");
                });

            modelBuilder.Entity("BackEndProject.Models.CompteContact", b =>
                {
                    b.HasOne("BackEndProject.Models.Comptes", "IdCptNavigation")
                        .WithMany("CompteContact")
                        .HasForeignKey("IdCpt")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BackEndProject.Models.Contacts", "IdcntNavigation")
                        .WithMany("CompteContact")
                        .HasForeignKey("Idcnt")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BackEndProject.Models.Comptes", b =>
                {
                    b.HasOne("BackEndProject.Models.Pays", "Pays")
                        .WithMany("Comptes")
                        .HasForeignKey("PaysId")
                        .HasConstraintName("COMPTES$PaysCOMPTES");
                });

            modelBuilder.Entity("BackEndProject.Models.Contacts", b =>
                {
                    b.HasOne("BackEndProject.Models.Pays", "Pays")
                        .WithMany("Contacts")
                        .HasForeignKey("PaysId")
                        .HasConstraintName("CONTACTS$PaysCONTACTS");
                });

            modelBuilder.Entity("BackEndProject.Models.Fonction", b =>
                {
                    b.HasOne("BackEndProject.Models.Factors", "Factor")
                        .WithMany("Fonction")
                        .HasForeignKey("FactorId")
                        .HasConstraintName("Fonction$fk_FactorId2");
                });

            modelBuilder.Entity("BackEndProject.Models.ProduitFactor", b =>
                {
                    b.HasOne("BackEndProject.Models.Factors", "facor")
                        .WithMany("produitFactor")
                        .HasForeignKey("IdFact")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BackEndProject.Models.ProduitFa", "produit")
                        .WithMany("produitFactor")
                        .HasForeignKey("IdProd")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BackEndProject.Models.PublicUser", b =>
                {
                    b.HasOne("BackEndProject.Models.Contacts", "Contact")
                        .WithMany("PublicUser")
                        .HasForeignKey("ContactId")
                        .HasConstraintName("FK__PublicUse__Conta__47DBAE45");

                    b.HasOne("BackEndProject.Models.Role", "Role")
                        .WithMany("PublicUser")
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_Role_Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}