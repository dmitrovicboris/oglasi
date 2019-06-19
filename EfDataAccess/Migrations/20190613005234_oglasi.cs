using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EfDataAccess.Migrations
{
    public partial class oglasi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategorije",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Naziv = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategorije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Ime = table.Column<string>(maxLength: 30, nullable: false),
                    Prezime = table.Column<string>(maxLength: 30, nullable: false),
                    Email = table.Column<string>(maxLength: 30, nullable: false),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Marke",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    DateModified = table.Column<DateTime>(nullable: true),
                    MarkaAutomobila = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marke", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Modeli",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Model = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modeli", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipovi",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Type = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipovi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VrsteGoriva",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false, defaultValueSql: "GETDATE()"),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Naziv = table.Column<string>(maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VrsteGoriva", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Automobili",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Naziv = table.Column<string>(type: "text", nullable: true),
                    Opis = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(nullable: false),
                    Godiste = table.Column<DateTime>(nullable: false),
                    Vlasnik = table.Column<bool>(nullable: false),
                    MarkaId = table.Column<int>(nullable: false),
                    KategorijaId = table.Column<int>(nullable: false),
                    TipId = table.Column<int>(nullable: true),
                    GorivoId = table.Column<int>(nullable: false),
                    ModelId = table.Column<int>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Automobili", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Automobili_VrsteGoriva_GorivoId",
                        column: x => x.GorivoId,
                        principalTable: "VrsteGoriva",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Automobili_Kategorije_KategorijaId",
                        column: x => x.KategorijaId,
                        principalTable: "Kategorije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Automobili_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Automobili_Marke_MarkaId",
                        column: x => x.MarkaId,
                        principalTable: "Marke",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Automobili_Modeli_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Modeli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Automobili_Tipovi_TipId",
                        column: x => x.TipId,
                        principalTable: "Tipovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prijave",
                columns: table => new
                {
                    AutomobilId = table.Column<int>(nullable: false),
                    KorisnikId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prijave", x => new { x.AutomobilId, x.KorisnikId });
                    table.ForeignKey(
                        name: "FK_Prijave_Automobili_AutomobilId",
                        column: x => x.AutomobilId,
                        principalTable: "Automobili",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prijave_Korisnici_KorisnikId",
                        column: x => x.KorisnikId,
                        principalTable: "Korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Slike",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: true),
                    Putanja = table.Column<string>(type: "text", nullable: true),
                    AutomobilId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slike", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Slike_Automobili_AutomobilId",
                        column: x => x.AutomobilId,
                        principalTable: "Automobili",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automobili_GorivoId",
                table: "Automobili",
                column: "GorivoId");

            migrationBuilder.CreateIndex(
                name: "IX_Automobili_KategorijaId",
                table: "Automobili",
                column: "KategorijaId");

            migrationBuilder.CreateIndex(
                name: "IX_Automobili_KorisnikId",
                table: "Automobili",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Automobili_MarkaId",
                table: "Automobili",
                column: "MarkaId");

            migrationBuilder.CreateIndex(
                name: "IX_Automobili_ModelId",
                table: "Automobili",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Automobili_TipId",
                table: "Automobili",
                column: "TipId");

            migrationBuilder.CreateIndex(
                name: "IX_Kategorije_Naziv",
                table: "Kategorije",
                column: "Naziv",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_Email",
                table: "Korisnici",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Marke_MarkaAutomobila",
                table: "Marke",
                column: "MarkaAutomobila",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Modeli_Model",
                table: "Modeli",
                column: "Model",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Prijave_KorisnikId",
                table: "Prijave",
                column: "KorisnikId");

            migrationBuilder.CreateIndex(
                name: "IX_Slike_AutomobilId",
                table: "Slike",
                column: "AutomobilId");

            migrationBuilder.CreateIndex(
                name: "IX_Tipovi_Type",
                table: "Tipovi",
                column: "Type",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VrsteGoriva_Naziv",
                table: "VrsteGoriva",
                column: "Naziv",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prijave");

            migrationBuilder.DropTable(
                name: "Slike");

            migrationBuilder.DropTable(
                name: "Automobili");

            migrationBuilder.DropTable(
                name: "VrsteGoriva");

            migrationBuilder.DropTable(
                name: "Kategorije");

            migrationBuilder.DropTable(
                name: "Korisnici");

            migrationBuilder.DropTable(
                name: "Marke");

            migrationBuilder.DropTable(
                name: "Modeli");

            migrationBuilder.DropTable(
                name: "Tipovi");
        }
    }
}
