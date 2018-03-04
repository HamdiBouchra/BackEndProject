using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BackEndProject.Migrations
{
    public partial class m4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DEVIS",
                columns: table => new
                {
                    IDauto = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CA_ESPERE = table.Column<string>(maxLength: 255, nullable: true),
                    Champ14 = table.Column<string>(maxLength: 255, nullable: true),
                    COMMENTAIRE = table.Column<string>(maxLength: 255, nullable: true),
                    COMPTABILISE = table.Column<string>(maxLength: 255, nullable: true),
                    CTRL = table.Column<string>(maxLength: 255, nullable: true),
                    DATE_EMISSION = table.Column<string>(maxLength: 255, nullable: true),
                    DESCRIPTION1 = table.Column<string>(maxLength: 255, nullable: true),
                    DESCRIPTION2 = table.Column<string>(maxLength: 255, nullable: true),
                    DESCRIPTION3 = table.Column<string>(maxLength: 255, nullable: true),
                    DESCRIPTION4 = table.Column<string>(maxLength: 255, nullable: true),
                    DOC = table.Column<string>(maxLength: 255, nullable: true),
                    ECART = table.Column<string>(maxLength: 255, nullable: true),
                    ECH = table.Column<string>(maxLength: 255, nullable: true),
                    FACTOR = table.Column<string>(maxLength: 255, nullable: true),
                    ID = table.Column<string>(maxLength: 255, nullable: true),
                    MONTANT_HT = table.Column<string>(maxLength: 255, nullable: true),
                    MONTANT_TTC = table.Column<string>(maxLength: 255, nullable: true),
                    NOM = table.Column<string>(maxLength: 255, nullable: true),
                    PERSONNE = table.Column<string>(maxLength: 255, nullable: true),
                    PRIXUHT1 = table.Column<string>(maxLength: 255, nullable: true),
                    PRIXUHT2 = table.Column<string>(maxLength: 255, nullable: true),
                    PRIXUHT3 = table.Column<string>(maxLength: 255, nullable: true),
                    PRIXUHT4 = table.Column<string>(maxLength: 255, nullable: true),
                    PROBA = table.Column<string>(maxLength: 255, nullable: true),
                    PRODUCT1 = table.Column<string>(maxLength: 255, nullable: true),
                    PRODUCT2 = table.Column<string>(maxLength: 255, nullable: true),
                    PRODUCT3 = table.Column<string>(maxLength: 255, nullable: true),
                    PRODUCT4 = table.Column<string>(maxLength: 255, nullable: true),
                    QUANTITY1 = table.Column<string>(maxLength: 255, nullable: true),
                    QUANTITY2 = table.Column<string>(maxLength: 255, nullable: true),
                    QUANTITY3 = table.Column<string>(maxLength: 255, nullable: true),
                    QUANTITY4 = table.Column<string>(maxLength: 255, nullable: true),
                    REC = table.Column<string>(maxLength: 255, nullable: true),
                    TVA = table.Column<string>(maxLength: 255, nullable: true),
                    TYPE1 = table.Column<string>(maxLength: 255, nullable: true),
                    TYPE2 = table.Column<string>(maxLength: 255, nullable: true),
                    TYPE3 = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEVIS", x => x.IDauto);
                });

            migrationBuilder.CreateTable(
                name: "Factors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FactorCode = table.Column<string>(maxLength: 50, nullable: false),
                    FactorName = table.Column<string>(maxLength: 255, nullable: true),
                    NumCompte = table.Column<string>(maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Factors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pays",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IsCee = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    IsDomTOm = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    IsoCode = table.Column<string>(maxLength: 3, nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: true),
                    Phonecode = table.Column<string>(maxLength: 50, nullable: true),
                    SSMA_TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pays", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "produitFa",
                columns: table => new
                {
                    IdProduit = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    description = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produitFa", x => x.IdProduit);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fonction",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FactorId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fonction", x => x.Id);
                    table.ForeignKey(
                        name: "Fonction$fk_FactorId2",
                        column: x => x.FactorId,
                        principalTable: "Factors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "COMPTES",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AccHasImpayedInv = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    AccountingId = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    ADRESSE1 = table.Column<string>(maxLength: 255, nullable: true),
                    ADRESSE2 = table.Column<string>(maxLength: 255, nullable: true),
                    ANCIEN_FACTOR1_ID = table.Column<int>(nullable: true),
                    ANCIEN_FACTOR2_ID = table.Column<int>(nullable: true),
                    AUTO_UPDATE = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    AutorisationLicence = table.Column<string>(maxLength: 50, nullable: true),
                    AutorisationMaintenance = table.Column<string>(maxLength: 50, nullable: true),
                    BASE = table.Column<string>(maxLength: 255, nullable: true),
                    BlockTypeTierUpdate = table.Column<bool>(nullable: true),
                    BUId = table.Column<int>(nullable: true),
                    Champ1 = table.Column<string>(maxLength: 255, nullable: true),
                    ClientCount = table.Column<int>(nullable: true),
                    CoTitulaire = table.Column<string>(maxLength: 10, nullable: true),
                    CodeContrat = table.Column<string>(maxLength: 50, nullable: true),
                    CODEPOSTAL = table.Column<string>(maxLength: 10, nullable: true),
                    Commentaire_Interne = table.Column<string>(maxLength: 255, nullable: true),
                    Commentaires = table.Column<string>(maxLength: 250, nullable: true),
                    CONTRACT_END = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    ContractNumber = table.Column<string>(maxLength: 50, nullable: true),
                    CONTRACT_START = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    CONTRAT = table.Column<string>(maxLength: 255, nullable: true),
                    courtierId = table.Column<int>(nullable: true),
                    ctcCourtierId = table.Column<int>(nullable: true),
                    Date1ereHeure = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    DateDernierEmail = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    DateLastActivity = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    Date_Maj_CI = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    Date_Maj_Obs = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    EntiteFactor = table.Column<string>(maxLength: 255, nullable: true),
                    FACTOR = table.Column<string>(maxLength: 255, nullable: true),
                    FactorId = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    GestionContactId = table.Column<int>(nullable: true),
                    Heures1annee = table.Column<double>(nullable: true),
                    IdSuspect = table.Column<int>(nullable: true),
                    IDComptePrincipal = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    InfoContactId = table.Column<int>(nullable: true),
                    InvoiceCount = table.Column<int>(nullable: true),
                    InvoicingId = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    isLocked = table.Column<bool>(nullable: true),
                    LastHeure = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    LAST_UPDATE = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    Link = table.Column<string>(nullable: true),
                    LOGICIEL = table.Column<string>(maxLength: 255, nullable: true),
                    MailAbouti = table.Column<string>(maxLength: 255, nullable: true),
                    MainContactId = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    NOM = table.Column<string>(maxLength: 255, nullable: true),
                    NOM_COURT = table.Column<string>(maxLength: 50, nullable: true),
                    NumTVA = table.Column<string>(maxLength: 50, nullable: true),
                    OtherContactId = table.Column<int>(nullable: true),
                    PaysId = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    PremHeure = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    SIREN = table.Column<string>(maxLength: 14, nullable: true),
                    SSMA_TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: false),
                    Statut = table.Column<string>(maxLength: 255, nullable: true),
                    TauxCourtage = table.Column<int>(nullable: true),
                    TitreDernierEmail = table.Column<string>(maxLength: 255, nullable: true),
                    TitulaireFacturation = table.Column<string>(maxLength: 250, nullable: true),
                    Titulaires = table.Column<string>(maxLength: 255, nullable: true),
                    Turnover = table.Column<double>(nullable: true),
                    TypeContrat = table.Column<string>(maxLength: 255, nullable: true),
                    TypeTiers = table.Column<string>(maxLength: 255, nullable: true),
                    ValidLicence = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    VERSION = table.Column<string>(maxLength: 255, nullable: true),
                    VILLE = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_COMPTES", x => x.ID);
                    table.ForeignKey(
                        name: "COMPTES$PaysCOMPTES",
                        column: x => x.PaysId,
                        principalTable: "Pays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CONTACTS",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    actif = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    ADRESSE1 = table.Column<string>(maxLength: 255, nullable: true),
                    ADRESSE2 = table.Column<string>(maxLength: 255, nullable: true),
                    BUId = table.Column<int>(nullable: true),
                    Champ17 = table.Column<string>(maxLength: 255, nullable: true),
                    Champ21 = table.Column<string>(maxLength: 255, nullable: true),
                    Champ22 = table.Column<string>(maxLength: 255, nullable: true),
                    Champ25 = table.Column<string>(maxLength: 255, nullable: true),
                    Civilite = table.Column<string>(maxLength: 50, nullable: true),
                    CODEPOSTAL = table.Column<string>(maxLength: 255, nullable: true),
                    COMMENTAIRES = table.Column<string>(maxLength: 255, nullable: true),
                    Compagne = table.Column<string>(maxLength: 250, nullable: true),
                    CompteId = table.Column<int>(nullable: true, defaultValueSql: "((0))"),
                    courtierId = table.Column<int>(nullable: true),
                    DateDernierEmail = table.Column<DateTime>(type: "datetime2(0)", nullable: true),
                    EMAIL = table.Column<string>(maxLength: 255, nullable: true),
                    Email2 = table.Column<string>(maxLength: 250, nullable: true),
                    ENTITE = table.Column<string>(maxLength: 255, nullable: true),
                    factorId = table.Column<int>(nullable: true),
                    FONCTION = table.Column<string>(maxLength: 255, nullable: true),
                    FonctionId = table.Column<int>(nullable: true),
                    IncludeInDiff = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    IsMassMailing = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    KEYYO = table.Column<string>(maxLength: 255, nullable: true),
                    LangueId = table.Column<int>(nullable: true),
                    LE = table.Column<string>(maxLength: 255, nullable: true),
                    LIEU = table.Column<string>(maxLength: 255, nullable: true),
                    MailAbouti = table.Column<string>(maxLength: 255, nullable: true),
                    NEXTLE = table.Column<string>(name: "NEXT LE", maxLength: 255, nullable: true),
                    NOM = table.Column<string>(maxLength: 255, nullable: true),
                    PAR = table.Column<string>(maxLength: 255, nullable: true),
                    PaysId = table.Column<int>(nullable: false, defaultValueSql: "((0))"),
                    Phonecode = table.Column<string>(maxLength: 50, nullable: true),
                    Phonecode2 = table.Column<string>(maxLength: 50, nullable: true),
                    Phonecode3 = table.Column<string>(maxLength: 50, nullable: true),
                    PRENOM = table.Column<string>(maxLength: 255, nullable: true),
                    SIREN = table.Column<string>(maxLength: 255, nullable: true),
                    SOURCE = table.Column<string>(maxLength: 255, nullable: true),
                    SSMA_TimeStamp = table.Column<byte[]>(rowVersion: true, nullable: false),
                    TEL = table.Column<string>(maxLength: 255, nullable: true),
                    TEL2 = table.Column<string>(maxLength: 255, nullable: true),
                    TEL3 = table.Column<string>(maxLength: 255, nullable: true),
                    TitreDernierEmail = table.Column<string>(maxLength: 255, nullable: true),
                    Tutoiement = table.Column<bool>(nullable: true),
                    TypeVoeux = table.Column<string>(maxLength: 255, nullable: true),
                    TYPECTC = table.Column<string>(maxLength: 255, nullable: true),
                    UserCode = table.Column<string>(maxLength: 50, nullable: true),
                    VILLE = table.Column<string>(maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CONTACTS", x => x.ID);
                    table.ForeignKey(
                        name: "CONTACTS$PaysCONTACTS",
                        column: x => x.PaysId,
                        principalTable: "Pays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProduitFactor",
                columns: table => new
                {
                    IdFact = table.Column<int>(nullable: false),
                    IdProd = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProduitFactor", x => new { x.IdFact, x.IdProd });
                    table.ForeignKey(
                        name: "FK_ProduitFactor_Factors_IdFact",
                        column: x => x.IdFact,
                        principalTable: "Factors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProduitFactor_produitFa_IdProd",
                        column: x => x.IdProd,
                        principalTable: "produitFa",
                        principalColumn: "IdProduit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CompteContact",
                columns: table => new
                {
                    IdCpt = table.Column<int>(nullable: false),
                    Idcnt = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompteContact", x => new { x.IdCpt, x.Idcnt });
                    table.ForeignKey(
                        name: "FK_CompteContact_COMPTES_IdCpt",
                        column: x => x.IdCpt,
                        principalTable: "COMPTES",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompteContact_CONTACTS_Idcnt",
                        column: x => x.Idcnt,
                        principalTable: "CONTACTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublicUser",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ContaId = table.Column<int>(nullable: true),
                    ContactId = table.Column<int>(nullable: false),
                    EstActive = table.Column<bool>(nullable: true, defaultValueSql: "((0))"),
                    Password = table.Column<string>(nullable: true),
                    RoleId = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublicUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK__PublicUse__Conta__47DBAE45",
                        column: x => x.ContactId,
                        principalTable: "CONTACTS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Role_Id",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompteContact_Idcnt",
                table: "CompteContact",
                column: "Idcnt");

            migrationBuilder.CreateIndex(
                name: "COMPTES$SoftwaresCOMPTES",
                table: "COMPTES",
                column: "AccountingId");

            migrationBuilder.CreateIndex(
                name: "COMPTES$CODEPOSTAL",
                table: "COMPTES",
                column: "CODEPOSTAL");

            migrationBuilder.CreateIndex(
                name: "COMPTES$FactorsCOMPTES",
                table: "COMPTES",
                column: "FactorId");

            migrationBuilder.CreateIndex(
                name: "COMPTES$IdSuspect",
                table: "COMPTES",
                column: "IdSuspect");

            migrationBuilder.CreateIndex(
                name: "COMPTES$IDComptePrincipal",
                table: "COMPTES",
                column: "IDComptePrincipal");

            migrationBuilder.CreateIndex(
                name: "COMPTES$SoftwaresCOMPTES1",
                table: "COMPTES",
                column: "InvoicingId");

            migrationBuilder.CreateIndex(
                name: "COMPTES$MainContactId",
                table: "COMPTES",
                column: "MainContactId");

            migrationBuilder.CreateIndex(
                name: "COMPTES$PaysId",
                table: "COMPTES",
                column: "PaysId");

            migrationBuilder.CreateIndex(
                name: "CONTACTS$CODEPOSTAL",
                table: "CONTACTS",
                column: "CODEPOSTAL");

            migrationBuilder.CreateIndex(
                name: "CONTACTS$CompteId",
                table: "CONTACTS",
                column: "CompteId");

            migrationBuilder.CreateIndex(
                name: "CONTACTS$PaysId",
                table: "CONTACTS",
                column: "PaysId");

            migrationBuilder.CreateIndex(
                name: "DEVIS$N° DOCUMENT",
                table: "DEVIS",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "Factors$FactorCode",
                table: "Factors",
                column: "FactorCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Factors$Id",
                table: "Factors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "Fonction$fk_FactorId2",
                table: "Fonction",
                column: "FactorId");

            migrationBuilder.CreateIndex(
                name: "Pays$pays_id",
                table: "Pays",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "Pays$code_pays",
                table: "Pays",
                column: "IsoCode");

            migrationBuilder.CreateIndex(
                name: "IX_ProduitFactor_IdProd",
                table: "ProduitFactor",
                column: "IdProd");

            migrationBuilder.CreateIndex(
                name: "PublicUser$publicUser_contactId",
                table: "PublicUser",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "PublicUser$publicUser_id",
                table: "PublicUser",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "PublicUser$publicUser_password",
                table: "PublicUser",
                column: "Password");

            migrationBuilder.CreateIndex(
                name: "IX_PublicUser_RoleId",
                table: "PublicUser",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "PublicUser$publicUser_username",
                table: "PublicUser",
                column: "Username");

            migrationBuilder.CreateIndex(
                name: "Role$Role_description",
                table: "Role",
                column: "Description");

            migrationBuilder.CreateIndex(
                name: "Role$Role_id",
                table: "Role",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompteContact");

            migrationBuilder.DropTable(
                name: "DEVIS");

            migrationBuilder.DropTable(
                name: "Fonction");

            migrationBuilder.DropTable(
                name: "ProduitFactor");

            migrationBuilder.DropTable(
                name: "PublicUser");

            migrationBuilder.DropTable(
                name: "COMPTES");

            migrationBuilder.DropTable(
                name: "Factors");

            migrationBuilder.DropTable(
                name: "produitFa");

            migrationBuilder.DropTable(
                name: "CONTACTS");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Pays");
        }
    }
}
