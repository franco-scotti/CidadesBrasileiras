using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CidadesBrasileiras.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addmunicipiosestado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estados",
                columns: table => new
                {
                    CodigoEstado = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estados", x => x.CodigoEstado);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    CodigoMunicipio = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Capital = table.Column<bool>(type: "boolean", nullable: false),
                    Populacao = table.Column<int>(type: "integer", nullable: false),
                    CodigoEstado = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.CodigoMunicipio);
                    table.ForeignKey(
                        name: "FK_Municipios_Estados_CodigoEstado",
                        column: x => x.CodigoEstado,
                        principalTable: "Estados",
                        principalColumn: "CodigoEstado",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_CodigoEstado",
                table: "Municipios",
                column: "CodigoEstado");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Estados");
        }
    }
}
