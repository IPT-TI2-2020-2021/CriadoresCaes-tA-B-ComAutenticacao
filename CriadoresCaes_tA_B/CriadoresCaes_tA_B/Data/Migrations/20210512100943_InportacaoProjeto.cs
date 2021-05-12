using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CriadoresCaes_tA_B.Data.Migrations
{
    public partial class InportacaoProjeto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Criadores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    NomeComercial = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    Morada = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    CodPostal = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Telemovel = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Criadores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Racas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Designacao = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Racas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Caes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataNasc = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LOP = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RacaFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Caes_Racas_RacaFK",
                        column: x => x.RacaFK,
                        principalTable: "Racas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CriadoresCaes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataCompra = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CaoFK = table.Column<int>(type: "int", nullable: false),
                    CriadorFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CriadoresCaes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CriadoresCaes_Caes_CaoFK",
                        column: x => x.CaoFK,
                        principalTable: "Caes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CriadoresCaes_Criadores_CriadorFK",
                        column: x => x.CriadorFK,
                        principalTable: "Criadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Fotografias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fotografia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataFoto = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Local = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CaoFK = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fotografias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fotografias_Caes_CaoFK",
                        column: x => x.CaoFK,
                        principalTable: "Caes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Criadores",
                columns: new[] { "Id", "CodPostal", "Email", "Morada", "Nome", "NomeComercial", "Telemovel" },
                values: new object[,]
                {
                    { 1, "2305 - 515 PAIALVO", "Marisa.Freitas@iol.pt", "Largo do Pelourinho", "Marisa Vieira", "da Quinta do Conde", "967197885" },
                    { 9, "2300 - 390 TOMAR", "Mariline.Ribeiro@iol.pt", "Rua Corredora do Mestre (Palhavã de Cima)", "Mariline Santos", "da Quinta do Bacelo", "964106478" },
                    { 8, "2300 - 551 TOMAR", "Paula.Vieira@clix.pt", "Praça Infante Dom Henrique", "Paula Soares", "da Tapada de Cima", "961937768" },
                    { 7, "7630 - 782 ZAMBUJEIRA DO MAR", "Alexandre.Dias@hotmail.com", "Rua João Pedro Costa", "Alexandre Vieira", "do Quintal de Cima", "961493756" },
                    { 10, "2300 - 635 TOMAR", "Roberto.Vieira@sapo.pt", "Largo do Flecheiro", "Roberto Pinto", "da Flecha do Indio", "964685937" },
                    { 5, "2305 - 127 ASSEICEIRA TMR", "Mariline.Martins@sapo.pt", "Zona Industrial", "Mariline Marques", "da Casa do Sobreiral", "967212144" },
                    { 4, "2300 - 324 TOMAR", "Paula.Lopes@iol.pt", "Bairro Pimenta", "Paula Silva", "do Canto do Pimenta", "967517256" },
                    { 2, "2300 - 551 TOMAR", "Fátima.Machado@gmail.com", "Praça Infante Dom Henrique", "Fátima Ribeiro", "da Quinta do Lordy", "963737476" },
                    { 6, "2475 - 013 BENEDITA", "Marcos.Rocha@sapo.pt", "Rua de Bacelos", "Marcos Rocha", "da Casa do Sol", "962125638" }
                });

            migrationBuilder.InsertData(
                table: "Racas",
                columns: new[] { "Id", "Designacao" },
                values: new object[,]
                {
                    { 7, "Golden Retriever" },
                    { 1, "Retriever do Labrador" },
                    { 2, "Serra da Estrela" },
                    { 3, "Pastor Alemão" },
                    { 4, "Dogue Alemão" },
                    { 5, "S. Bernardo" },
                    { 6, "Rafeiro do Alentejo" },
                    { 8, "Border Collie" }
                });

            migrationBuilder.InsertData(
                table: "Caes",
                columns: new[] { "Id", "DataNasc", "LOP", "Nome", "RacaFK", "Sexo" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 4, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "LOP446793", "Aguia da Quinta do Conde", 1, "F" },
                    { 2, new DateTime(2019, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "LOP446795", "Aileen da Quinta do Lordy", 1, "F" },
                    { 5, new DateTime(2012, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "LOP446807", "Alabaster da Casa do Sobreiral", 2, "F" },
                    { 7, new DateTime(2010, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "LOP446811", "Gardenia da Tapada de Cima", 3, "F" },
                    { 10, new DateTime(2017, 3, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "LOP446814", "Garfunkle da Quinta do Lordy", 4, "F" },
                    { 3, new DateTime(2011, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "LOP446801", "Aladim do Canto do Bairro Pimenta", 5, "F" },
                    { 4, new DateTime(2008, 6, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "LOP446804", "Albert do Canto do Bairro Pimenta", 5, "F" },
                    { 6, new DateTime(2010, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "LOP446809", "Gannett do Quintal de Cima", 6, "F" },
                    { 8, new DateTime(2013, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "LOP446799", "Forte da Flecha do Indio", 7, "F" },
                    { 9, new DateTime(2011, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "LOP446812", "Garbo da Flecha do Indio", 7, "M" },
                    { 11, new DateTime(2018, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "LOP446816", "Garnet do Quintal de Cima", 8, "M" }
                });

            migrationBuilder.InsertData(
                table: "CriadoresCaes",
                columns: new[] { "Id", "CaoFK", "CriadorFK", "DataCompra" },
                values: new object[,]
                {
                    { 1, 1, 1, new DateTime(2019, 6, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 9, 10, new DateTime(2011, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, 2, new DateTime(2019, 12, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 5, 6, new DateTime(2012, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 8, 9, new DateTime(2013, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 7, 8, new DateTime(2011, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 6, 7, new DateTime(2010, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 10, 5, new DateTime(2017, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 11, 8, new DateTime(2018, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, 4, new DateTime(2011, 5, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 4, 5, new DateTime(2008, 8, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "Fotografias",
                columns: new[] { "Id", "CaoFK", "DataFoto", "Fotografia", "Local" },
                values: new object[,]
                {
                    { 13, 9, new DateTime(2020, 2, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Golden-Retriever-1.jpg", "" },
                    { 12, 8, new DateTime(2017, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "golden-retriever.jpg", "ninhada" },
                    { 11, 8, new DateTime(2018, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "golden-retriever_2.jpg", "" },
                    { 8, 6, new DateTime(2020, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rafeiro_do_Alentejo.jpg", "Quinta" },
                    { 5, 4, new DateTime(2019, 3, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "s.bernardo_2.jpg", "casa" },
                    { 14, 10, new DateTime(2021, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Dogue_Alemao.jpg", "Casa da tia Ana" },
                    { 10, 7, new DateTime(2020, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "pastor_alemao.jpg", "" },
                    { 9, 7, new DateTime(2011, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "pastor_alemao_2.jpg", "" },
                    { 7, 5, new DateTime(2012, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "serra_da_estrela_2.jpg", "" },
                    { 6, 5, new DateTime(2013, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "serra_da_estrela.jpg", "" },
                    { 3, 2, new DateTime(2019, 11, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Retriever_do_labrador_3.jpg", "" },
                    { 2, 1, new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Retriever_do_labrador_2.jpg", "" },
                    { 1, 1, new DateTime(2019, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Retriever_do_labrador.jpg", "" },
                    { 4, 3, new DateTime(2021, 1, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "s.bernardo.jpg", "" },
                    { 15, 11, new DateTime(2021, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "border_collie.jpg", "quintal" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Caes_RacaFK",
                table: "Caes",
                column: "RacaFK");

            migrationBuilder.CreateIndex(
                name: "IX_CriadoresCaes_CaoFK",
                table: "CriadoresCaes",
                column: "CaoFK");

            migrationBuilder.CreateIndex(
                name: "IX_CriadoresCaes_CriadorFK",
                table: "CriadoresCaes",
                column: "CriadorFK");

            migrationBuilder.CreateIndex(
                name: "IX_Fotografias_CaoFK",
                table: "Fotografias",
                column: "CaoFK");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CriadoresCaes");

            migrationBuilder.DropTable(
                name: "Fotografias");

            migrationBuilder.DropTable(
                name: "Criadores");

            migrationBuilder.DropTable(
                name: "Caes");

            migrationBuilder.DropTable(
                name: "Racas");
        }
    }
}
