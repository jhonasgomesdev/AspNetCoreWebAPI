﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartSchoolWebAPI.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Alunos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Matricula = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataDeNascimento = table.Column<DateTime>(nullable: false),
                    DataDeMatricula = table.Column<DateTime>(nullable: false),
                    DataDeEncerramento = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cursos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Professores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Registro = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Sobrenome = table.Column<string>(nullable: true),
                    Telefone = table.Column<string>(nullable: true),
                    DataDeRegistro = table.Column<DateTime>(nullable: false),
                    DataDeEncerramento = table.Column<DateTime>(nullable: true),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AlunosCursos",
                columns: table => new
                {
                    AlunoId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false),
                    DataDeInicio = table.Column<DateTime>(nullable: false),
                    DataDeFim = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosCursos", x => new { x.AlunoId, x.CursoId });
                    table.ForeignKey(
                        name: "FK_AlunosCursos_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
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
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nome = table.Column<string>(nullable: true),
                    CargaHoraria = table.Column<int>(nullable: false),
                    PreRequisitoId = table.Column<int>(nullable: true),
                    ProfessorId = table.Column<int>(nullable: false),
                    CursoId = table.Column<int>(nullable: false)
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
                        name: "FK_Disciplinas_Disciplinas_PreRequisitoId",
                        column: x => x.PreRequisitoId,
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
                    AlunoId = table.Column<int>(nullable: false),
                    DisciplinaId = table.Column<int>(nullable: false),
                    DataDeInicio = table.Column<DateTime>(nullable: false),
                    DataDeFim = table.Column<DateTime>(nullable: true),
                    Nota = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunosDisciplinas", x => new { x.AlunoId, x.DisciplinaId });
                    table.ForeignKey(
                        name: "FK_AlunosDisciplinas_Alunos_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Alunos",
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
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataDeEncerramento", "DataDeMatricula", "DataDeNascimento", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 1, true, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(6565), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "Marta", "Kent", "33225555" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataDeEncerramento", "DataDeMatricula", "DataDeNascimento", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 2, true, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(7346), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "Paula", "Isabela", "3354288" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataDeEncerramento", "DataDeMatricula", "DataDeNascimento", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 3, true, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(7382), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "Laura", "Antonia", "55668899" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataDeEncerramento", "DataDeMatricula", "DataDeNascimento", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 4, true, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(7386), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, "Luiza", "Maria", "6565659" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataDeEncerramento", "DataDeMatricula", "DataDeNascimento", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 5, true, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(7389), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, "Lucas", "Machado", "565685415" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataDeEncerramento", "DataDeMatricula", "DataDeNascimento", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 6, true, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(7394), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, "Pedro", "Alvares", "456454545" });

            migrationBuilder.InsertData(
                table: "Alunos",
                columns: new[] { "Id", "Ativo", "DataDeEncerramento", "DataDeMatricula", "DataDeNascimento", "Matricula", "Nome", "Sobrenome", "Telefone" },
                values: new object[] { 7, true, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(7396), new DateTime(2005, 5, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, "Paulo", "José", "9874512" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 1, "Tecnologia da Informação" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 2, "Sistemas de Informaçãoo" });

            migrationBuilder.InsertData(
                table: "Cursos",
                columns: new[] { "Id", "Nome" },
                values: new object[] { 3, "Ciência da Computação" });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataDeEncerramento", "DataDeRegistro", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 1, true, null, new DateTime(2025, 4, 23, 13, 52, 8, 176, DateTimeKind.Local).AddTicks(4133), "Lauro", 1, "Oliveira", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataDeEncerramento", "DataDeRegistro", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 2, true, null, new DateTime(2025, 4, 23, 13, 52, 8, 176, DateTimeKind.Local).AddTicks(9547), "Roberto", 2, "Soares", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataDeEncerramento", "DataDeRegistro", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 3, true, null, new DateTime(2025, 4, 23, 13, 52, 8, 176, DateTimeKind.Local).AddTicks(9579), "Ronaldo", 3, "Marconi", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataDeEncerramento", "DataDeRegistro", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 4, true, null, new DateTime(2025, 4, 23, 13, 52, 8, 176, DateTimeKind.Local).AddTicks(9581), "Rodrigo", 4, "Carvalho", null });

            migrationBuilder.InsertData(
                table: "Professores",
                columns: new[] { "Id", "Ativo", "DataDeEncerramento", "DataDeRegistro", "Nome", "Registro", "Sobrenome", "Telefone" },
                values: new object[] { 5, true, null, new DateTime(2025, 4, 23, 13, 52, 8, 176, DateTimeKind.Local).AddTicks(9582), "Alexandre", 5, "Montanha", null });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 1, 0, 1, "Matemática", null, 1 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 2, 0, 3, "Matemática", null, 1 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 3, 0, 3, "Física", null, 2 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 4, 0, 1, "Português", null, 3 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 5, 0, 1, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 6, 0, 2, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 7, 0, 3, "Inglês", null, 4 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 8, 0, 1, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 9, 0, 2, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "Disciplinas",
                columns: new[] { "Id", "CargaHoraria", "CursoId", "Nome", "PreRequisitoId", "ProfessorId" },
                values: new object[] { 10, 0, 3, "Programação", null, 5 });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 2, 1, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8463), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 4, 5, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8471), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 2, 5, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8465), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 1, 5, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8462), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 7, 4, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8479), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 6, 4, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8476), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 5, 4, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8472), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 4, 4, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8470), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 1, 4, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8443), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 7, 3, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8479), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 5, 5, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8472), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 6, 3, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8475), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 7, 2, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8478), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 6, 2, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8474), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 3, 2, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8467), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 2, 2, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8463), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 1, 2, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8225), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 7, 1, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8477), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 6, 1, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8473), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 4, 1, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8469), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 3, 1, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8466), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 3, 3, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8468), null });

            migrationBuilder.InsertData(
                table: "AlunosDisciplinas",
                columns: new[] { "AlunoId", "DisciplinaId", "DataDeFim", "DataDeInicio", "Nota" },
                values: new object[] { 7, 5, null, new DateTime(2025, 4, 23, 13, 52, 8, 178, DateTimeKind.Local).AddTicks(8480), null });

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
                name: "IX_Disciplinas_PreRequisitoId",
                table: "Disciplinas",
                column: "PreRequisitoId");

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
                name: "Alunos");

            migrationBuilder.DropTable(
                name: "Disciplinas");

            migrationBuilder.DropTable(
                name: "Cursos");

            migrationBuilder.DropTable(
                name: "Professores");
        }
    }
}
