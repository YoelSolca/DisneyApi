using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DisneyApi.Migrations
{
    public partial class DisneyApiEntitiesContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Genero",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Imagen = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genero", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PeliculaSerie",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(maxLength: 50, nullable: false),
                    FechaDeCreacion = table.Column<DateTimeOffset>(nullable: false),
                    Calificacion = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaSerie", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Persona",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imagen = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Edad = table.Column<string>(maxLength: 3, nullable: false),
                    Peso = table.Column<string>(maxLength: 50, nullable: false),
                    Historia = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persona", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "PeliculaSerieGenero",
                schema: "dbo",
                columns: table => new
                {
                    FK_PeliculaSerieID = table.Column<int>(nullable: false),
                    FK_GeneroID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeliculaSerieGenero", x => new { x.FK_PeliculaSerieID, x.FK_GeneroID });
                    table.ForeignKey(
                        name: "FK_PeliculaSerieGenero_Genero_FK_GeneroID",
                        column: x => x.FK_GeneroID,
                        principalSchema: "dbo",
                        principalTable: "Genero",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PeliculaSerieGenero_PeliculaSerie_FK_PeliculaSerieID",
                        column: x => x.FK_PeliculaSerieID,
                        principalSchema: "dbo",
                        principalTable: "PeliculaSerie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonajePeliculaSerie",
                schema: "dbo",
                columns: table => new
                {
                    FK_PersonajeID = table.Column<int>(nullable: false),
                    FK_PeliculaSerieID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonajePeliculaSerie", x => new { x.FK_PersonajeID, x.FK_PeliculaSerieID });
                    table.ForeignKey(
                        name: "FK_PersonajePeliculaSerie_PeliculaSerie_FK_PeliculaSerieID",
                        column: x => x.FK_PeliculaSerieID,
                        principalSchema: "dbo",
                        principalTable: "PeliculaSerie",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonajePeliculaSerie_Persona_FK_PersonajeID",
                        column: x => x.FK_PersonajeID,
                        principalSchema: "dbo",
                        principalTable: "Persona",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PeliculaSerieGenero_FK_GeneroID",
                schema: "dbo",
                table: "PeliculaSerieGenero",
                column: "FK_GeneroID");

            migrationBuilder.CreateIndex(
                name: "IX_PersonajePeliculaSerie_FK_PeliculaSerieID",
                schema: "dbo",
                table: "PersonajePeliculaSerie",
                column: "FK_PeliculaSerieID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PeliculaSerieGenero",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PersonajePeliculaSerie",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Genero",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PeliculaSerie",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Persona",
                schema: "dbo");
        }
    }
}
