using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PortalWeb.WebAPI.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true),
                    Email = table.Column<string>(type: "TEXT", nullable: true),
                    DataNasc = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataIni = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Registro = table.Column<int>(type: "INTEGER", nullable: false),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    Sobrenome = table.Column<string>(type: "TEXT", nullable: true),
                    DataIni = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true),
                    Ativo = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    CursoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataIni = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Disciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(type: "TEXT", nullable: true),
                    CargaHoraria = table.Column<int>(type: "INTEGER", nullable: false),
                    PrerequisitoId = table.Column<int>(type: "INTEGER", nullable: true),
                    ProfessorId = table.Column<int>(type: "INTEGER", nullable: false),
                    CursoId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Cursos_CursoId",
                        column: x => x.CursoId,
                        principalTable: "Cursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Disciplinas_PrerequisitoId",
                        column: x => x.PrerequisitoId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Disciplinas_Professores_ProfessorId",
                        column: x => x.ProfessorId,
                        principalTable: "Professores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AlunosDisciplinas",
                columns: table => new
                {
                    AlunoId = table.Column<int>(type: "INTEGER", nullable: false),
                    DisciplinaId = table.Column<int>(type: "INTEGER", nullable: false),
                    DataIni = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataFim = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Aluno_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Aluno",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Aluno",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Email", "Matricula", "Nome", "Sobrenome" },
                values: new object[] { 1, true, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(92), new DateTime(2021, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "33225555", 1, "Marta", "Kent" });

            migrationBuilder.InsertData(
                table: "Aluno",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Email", "Matricula", "Nome", "Sobrenome" },
                values: new object[] { 2, true, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(3780), new DateTime(2021, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "3354288", 2, "Paula", "Isabela" });

            migrationBuilder.InsertData(
                table: "Aluno",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Email", "Matricula", "Nome", "Sobrenome" },
                values: new object[] { 3, true, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(3809), new DateTime(2021, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "55668899", 3, "Laura", "Antonia" });

            migrationBuilder.InsertData(
                table: "Aluno",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Email", "Matricula", "Nome", "Sobrenome" },
                values: new object[] { 4, true, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(3828), new DateTime(2021, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "6565659", 4, "Luiza", "Maria" });

            migrationBuilder.InsertData(
                table: "Aluno",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Email", "Matricula", "Nome", "Sobrenome" },
                values: new object[] { 5, true, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(3846), new DateTime(2021, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "565685415", 5, "Lucas", "Machado" });

            migrationBuilder.InsertData(
                table: "Aluno",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Email", "Matricula", "Nome", "Sobrenome" },
                values: new object[] { 6, true, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(3873), new DateTime(2021, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "456454545", 6, "Pedro", "Alvares" });

            migrationBuilder.InsertData(
                table: "Aluno",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "DataNasc", "Email", "Matricula", "Nome", "Sobrenome" },
                values: new object[] { 7, true, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(3891), new DateTime(2021, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "9874512", 7, "Paulo", "José" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Tecnologia da Informação" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Sistemas de Informação" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Ciência da Computação" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "Nome", "Registro", "Sobrenome" },
                values: new object[] { 1, true, null, new DateTime(2021, 2, 13, 3, 1, 49, 740, DateTimeKind.Local).AddTicks(219), "Lauro", 1, "Oliveira" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "Nome", "Registro", "Sobrenome" },
                values: new object[] { 2, true, null, new DateTime(2021, 2, 13, 3, 1, 49, 746, DateTimeKind.Local).AddTicks(413), "Roberto", 2, "Soares" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "Nome", "Registro", "Sobrenome" },
                values: new object[] { 3, true, null, new DateTime(2021, 2, 13, 3, 1, 49, 746, DateTimeKind.Local).AddTicks(451), "Ronaldo", 3, "Marconi" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "Nome", "Registro", "Sobrenome" },
                values: new object[] { 4, true, null, new DateTime(2021, 2, 13, 3, 1, 49, 746, DateTimeKind.Local).AddTicks(455), "Rodrigo", 4, "Carvalho" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataFim", "DataIni", "Nome", "Registro", "Sobrenome" },
                values: new object[] { 5, true, null, new DateTime(2021, 2, 13, 3, 1, 49, 746, DateTimeKind.Local).AddTicks(459), "Alexandre", 5, "Montanha" });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 1, 0, 1, "Matemática", null, 1 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 2, 0, 3, "Matemática", null, 1 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 3, 0, 3, "Física", null, 2 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 4, 0, 1, "Português", null, 3 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 5, 0, 1, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 6, 0, 2, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 7, 0, 3, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 8, 0, 1, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 9, 0, 2, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PrerequisitoId", "ProfessorId" },
                values: new object[] { 10, 0, 3, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 2, 1, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(7026) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 4, 5, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(7058) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 2, 5, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(7041) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 1, 5, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(6862) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 7, 4, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(7087) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 6, 4, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(7076) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 5, 4, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(7061) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 4, 4, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(7056) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 1, 4, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(6848) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 7, 3, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(7085) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 5, 5, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(7064) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 6, 3, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(7072) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 7, 2, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(7082) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 6, 2, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(7069) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 3, 2, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(7046) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 2, 2, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(7031) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 1, 2, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(5685) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 7, 1, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(7079) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 6, 1, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(7066) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 4, 1, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(7053) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 3, 1, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(7043) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 3, 3, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(7049) });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataFim", "DataIni" },
                values: new object[] { 7, 5, null, new DateTime(2021, 2, 13, 3, 1, 49, 749, DateTimeKind.Local).AddTicks(7090) });

            migrationBuilder.CreateIndex(
                name: "IX_AlunosCursos_CursoId",
                table: "AlunosCursos",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunosDisciplinas_DisciplinaId",
                table: "AlunosDisciplinas",
                column: "DisciplinaId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_CursoId",
                table: "Disciplinas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_PrerequisitoId",
                table: "Disciplinas",
                column: "PrerequisitoId");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplinas_ProfessorId",
                table: "Disciplinas",
                column: "ProfessorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunosCursos");

            migrationBuilder.DropTable(
                name: "AlunosDisciplinas");

            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
