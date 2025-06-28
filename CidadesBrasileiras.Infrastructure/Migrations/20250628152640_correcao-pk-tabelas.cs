using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CidadesBrasileiras.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class correcaopktabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Municipios_Estados_CodigoEstado",
                table: "Municipios");

            migrationBuilder.RenameColumn(
                name: "CodigoEstado",
                table: "Municipios",
                newName: "IdEstado");

            migrationBuilder.RenameColumn(
                name: "CodigoMunicipio",
                table: "Municipios",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Municipios_CodigoEstado",
                table: "Municipios",
                newName: "IX_Municipios_IdEstado");

            migrationBuilder.RenameColumn(
                name: "CodigoEstado",
                table: "Estados",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipios_Estados_IdEstado",
                table: "Municipios",
                column: "IdEstado",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Municipios_Estados_IdEstado",
                table: "Municipios");

            migrationBuilder.RenameColumn(
                name: "IdEstado",
                table: "Municipios",
                newName: "CodigoEstado");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Municipios",
                newName: "CodigoMunicipio");

            migrationBuilder.RenameIndex(
                name: "IX_Municipios_IdEstado",
                table: "Municipios",
                newName: "IX_Municipios_CodigoEstado");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Estados",
                newName: "CodigoEstado");

            migrationBuilder.AddForeignKey(
                name: "FK_Municipios_Estados_CodigoEstado",
                table: "Municipios",
                column: "CodigoEstado",
                principalTable: "Estados",
                principalColumn: "CodigoEstado",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
