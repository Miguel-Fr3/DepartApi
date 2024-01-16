using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DepartApi.Migrations
{
    /// <inheritdoc />
    public partial class Case : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Departamentos_DepartamentoId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_DepartamentoId",
                table: "Funcionarios");

            migrationBuilder.AddColumn<int>(
                name: "DepartamentosId",
                table: "Funcionarios",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "DepartamentosId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "DepartamentosId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "DepartamentosId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "DepartamentosId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Funcionarios",
                keyColumn: "Id",
                keyValue: 5,
                column: "DepartamentosId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_DepartamentosId",
                table: "Funcionarios",
                column: "DepartamentosId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Departamentos_DepartamentosId",
                table: "Funcionarios",
                column: "DepartamentosId",
                principalTable: "Departamentos",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Departamentos_DepartamentosId",
                table: "Funcionarios");

            migrationBuilder.DropIndex(
                name: "IX_Funcionarios_DepartamentosId",
                table: "Funcionarios");

            migrationBuilder.DropColumn(
                name: "DepartamentosId",
                table: "Funcionarios");

            migrationBuilder.CreateIndex(
                name: "IX_Funcionarios_DepartamentoId",
                table: "Funcionarios",
                column: "DepartamentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Departamentos_DepartamentoId",
                table: "Funcionarios",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
