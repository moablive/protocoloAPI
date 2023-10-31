using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace atendimentoEmpresaMVC.Migrations
{
    /// <inheritdoc />
    public partial class ajuste5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
