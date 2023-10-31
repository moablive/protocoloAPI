using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace atendimentoEmpresaMVC.Migrations
{
    /// <inheritdoc />
    public partial class ajusteTipoDados : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "PessoaJuridicaID",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PessoaFisicaID",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_PessoasFisicas_PessoaFisicaID",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_PessoasJuridicas_PessoaJuridicaID",
                table: "Enderecos");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaJuridicaID",
                table: "Enderecos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PessoaFisicaID",
                table: "Enderecos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_PessoasFisicas_PessoaFisicaID",
                table: "Enderecos",
                column: "PessoaFisicaID",
                principalTable: "PessoasFisicas",
                principalColumn: "PessoaFisicaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_PessoasJuridicas_PessoaJuridicaID",
                table: "Enderecos",
                column: "PessoaJuridicaID",
                principalTable: "PessoasJuridicas",
                principalColumn: "PessoaJuridicaID");
        }
    }
}
