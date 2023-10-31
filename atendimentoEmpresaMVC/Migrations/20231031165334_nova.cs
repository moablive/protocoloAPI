using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace atendimentoEmpresaMVC.Migrations
{
    /// <inheritdoc />
    public partial class nova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PessoaTipo",
                table: "PessoasJuridicas");

            migrationBuilder.DropColumn(
                name: "PessoaTipo",
                table: "PessoasFisicas");

            migrationBuilder.CreateIndex(
                name: "IX_Protocolos_PessoaFisicaID",
                table: "Protocolos",
                column: "PessoaFisicaID");

            migrationBuilder.CreateIndex(
                name: "IX_Protocolos_PessoaJuridicaID",
                table: "Protocolos",
                column: "PessoaJuridicaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Protocolos_PessoasFisicas_PessoaFisicaID",
                table: "Protocolos",
                column: "PessoaFisicaID",
                principalTable: "PessoasFisicas",
                principalColumn: "PessoaFisicaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Protocolos_PessoasJuridicas_PessoaJuridicaID",
                table: "Protocolos",
                column: "PessoaJuridicaID",
                principalTable: "PessoasJuridicas",
                principalColumn: "PessoaJuridicaID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Protocolos_PessoasFisicas_PessoaFisicaID",
                table: "Protocolos");

            migrationBuilder.DropForeignKey(
                name: "FK_Protocolos_PessoasJuridicas_PessoaJuridicaID",
                table: "Protocolos");

            migrationBuilder.DropIndex(
                name: "IX_Protocolos_PessoaFisicaID",
                table: "Protocolos");

            migrationBuilder.DropIndex(
                name: "IX_Protocolos_PessoaJuridicaID",
                table: "Protocolos");

            migrationBuilder.AddColumn<int>(
                name: "PessoaTipo",
                table: "PessoasJuridicas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PessoaTipo",
                table: "PessoasFisicas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
