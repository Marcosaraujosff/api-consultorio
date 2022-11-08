using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api_consultorio.Migrations
{
    public partial class adicionandoRelacionamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_especialidade_EspecialidadeId",
                table: "tb_consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_paciente_PacienteId",
                table: "tb_consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_profissional_ProfissionalId",
                table: "tb_consulta");

            migrationBuilder.RenameColumn(
                name: "ProfissionalId",
                table: "tb_consulta",
                newName: "id_profissional");

            migrationBuilder.RenameColumn(
                name: "PacienteId",
                table: "tb_consulta",
                newName: "id_paciente");

            migrationBuilder.RenameColumn(
                name: "EspecialidadeId",
                table: "tb_consulta",
                newName: "id_Especialidade");

            migrationBuilder.RenameIndex(
                name: "IX_tb_consulta_ProfissionalId",
                table: "tb_consulta",
                newName: "IX_tb_consulta_id_profissional");

            migrationBuilder.RenameIndex(
                name: "IX_tb_consulta_PacienteId",
                table: "tb_consulta",
                newName: "IX_tb_consulta_id_paciente");

            migrationBuilder.RenameIndex(
                name: "IX_tb_consulta_EspecialidadeId",
                table: "tb_consulta",
                newName: "IX_tb_consulta_id_Especialidade");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_especialidade_id_Especialidade",
                table: "tb_consulta",
                column: "id_Especialidade",
                principalTable: "tb_especialidade",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_paciente_id_paciente",
                table: "tb_consulta",
                column: "id_paciente",
                principalTable: "tb_paciente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_profissional_id_profissional",
                table: "tb_consulta",
                column: "id_profissional",
                principalTable: "tb_profissional",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_especialidade_id_Especialidade",
                table: "tb_consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_paciente_id_paciente",
                table: "tb_consulta");

            migrationBuilder.DropForeignKey(
                name: "FK_tb_consulta_tb_profissional_id_profissional",
                table: "tb_consulta");

            migrationBuilder.RenameColumn(
                name: "id_profissional",
                table: "tb_consulta",
                newName: "ProfissionalId");

            migrationBuilder.RenameColumn(
                name: "id_paciente",
                table: "tb_consulta",
                newName: "PacienteId");

            migrationBuilder.RenameColumn(
                name: "id_Especialidade",
                table: "tb_consulta",
                newName: "EspecialidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_consulta_id_profissional",
                table: "tb_consulta",
                newName: "IX_tb_consulta_ProfissionalId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_consulta_id_paciente",
                table: "tb_consulta",
                newName: "IX_tb_consulta_PacienteId");

            migrationBuilder.RenameIndex(
                name: "IX_tb_consulta_id_Especialidade",
                table: "tb_consulta",
                newName: "IX_tb_consulta_EspecialidadeId");

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_especialidade_EspecialidadeId",
                table: "tb_consulta",
                column: "EspecialidadeId",
                principalTable: "tb_especialidade",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_paciente_PacienteId",
                table: "tb_consulta",
                column: "PacienteId",
                principalTable: "tb_paciente",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_tb_consulta_tb_profissional_ProfissionalId",
                table: "tb_consulta",
                column: "ProfissionalId",
                principalTable: "tb_profissional",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
