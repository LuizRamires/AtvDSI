using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoTS.Server.Migrations
{
    public partial class FirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Desenvolvedoraes",
                columns: table => new
                {
                    IdDesenvolvedora = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Endereco = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Desenvolvedoraes", x => x.IdDesenvolvedora);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    TagId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.TagId);
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    IdDesenvolvedora = table.Column<int>(nullable: false),
                    DesenvolvedoraIdDesenvolvedora = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Desenvolvedoraes_DesenvolvedoraIdDesenvolvedora",
                        column: x => x.DesenvolvedoraIdDesenvolvedora,
                        principalTable: "Desenvolvedoraes",
                        principalColumn: "IdDesenvolvedora",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetalheGames",
                columns: table => new
                {
                    IdGame = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    TempoDeUso = table.Column<string>(nullable: true),
                    EstadodeConservacao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetalheGames", x => x.IdGame);
                    table.ForeignKey(
                        name: "FK_DetalheGames_Games_IdGame",
                        column: x => x.IdGame,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TagGames",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    TagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagGames", x => new { x.TagId, x.Id });
                    table.ForeignKey(
                        name: "FK_TagGames_Games_Id",
                        column: x => x.Id,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagGames_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "TagId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_DesenvolvedoraIdDesenvolvedora",
                table: "Games",
                column: "DesenvolvedoraIdDesenvolvedora");

            migrationBuilder.CreateIndex(
                name: "IX_TagGames_Id",
                table: "TagGames",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetalheGames");

            migrationBuilder.DropTable(
                name: "TagGames");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Desenvolvedoraes");
        }
    }
}
