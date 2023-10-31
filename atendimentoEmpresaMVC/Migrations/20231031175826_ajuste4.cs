using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace atendimentoEmpresaMVC.Migrations
{
    /// <inheritdoc />
    public partial class ajuste4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_PessoasFisicas_PessoaFisicaID",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_PessoasJuridicas_PessoaJuridicaID",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_PessoaFisicaID",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_PessoaJuridicaID",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "PessoaFisicaID",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "PessoaJuridicaID",
                table: "Enderecos");

            migrationBuilder.AddColumn<int>(
                name: "EnderecoID",
                table: "PessoasJuridicas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnderecoID",
                table: "PessoasFisicas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Enderecos",
                type: "varchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnderecoID",
                table: "PessoasJuridicas");

            migrationBuilder.DropColumn(
                name: "EnderecoID",
                table: "PessoasFisicas");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Enderecos");

            migrationBuilder.AddColumn<int>(
                name: "PessoaFisicaID",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PessoaJuridicaID",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_PessoaFisicaID",
                table: "Enderecos",
                column: "PessoaFisicaID");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_PessoaJuridicaID",
                table: "Enderecos",
                column: "PessoaJuridicaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_PessoasFisicas_PessoaFisicaID",
                table: "Enderecos",
                column: "PessoaFisicaID",
                principalTable: "PessoasFisicas",
                principalColumn: "PessoaFisicaID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_PessoasJuridicas_PessoaJuridicaID",
                table: "Enderecos",
                column: "PessoaJuridicaID",
                principalTable: "PessoasJuridicas",
                principalColumn: "PessoaJuridicaID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
