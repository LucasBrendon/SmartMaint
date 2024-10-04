using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace SmartMaint.Persistencia.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    End_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    End_Cep = table.Column<string>(type: "varchar(10)", nullable: false),
                    End_Logradouro = table.Column<string>(type: "varchar(100)", nullable: false),
                    End_Bairro = table.Column<string>(type: "varchar(100)", nullable: false),
                    End_Localidade = table.Column<string>(type: "varchar(100)", nullable: false),
                    End_Uf = table.Column<string>(type: "varchar(2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.End_Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresa",
                columns: table => new
                {
                    Emp_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Emp_Nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    Emp_Cnpj = table.Column<string>(type: "varchar(14)", nullable: true),
                    Emp_Cpf = table.Column<string>(type: "varchar(11)", nullable: true),
                    Emp_Telefone = table.Column<string>(type: "varchar(20)", nullable: true),
                    Emp_Celular = table.Column<string>(type: "varchar(20)", nullable: true),
                    Emp_Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Emp_Ativa = table.Column<bool>(type: "boolean", nullable: false),
                    Emp_DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Emp_DataAtualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Emp_NumeroEndereco = table.Column<string>(type: "varchar(20)", nullable: false),
                    Emp_ComplementoEndereco = table.Column<string>(type: "varchar(255)", nullable: true),
                    Emp_Endereco_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresa", x => x.Emp_Id);
                    table.ForeignKey(
                        name: "FK_Empresa_Endereco_Emp_Endereco_Id",
                        column: x => x.Emp_Endereco_Id,
                        principalTable: "Endereco",
                        principalColumn: "End_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Perfil",
                columns: table => new
                {
                    Perf_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Perf_Nome = table.Column<string>(type: "varchar(50)", nullable: false),
                    Perf_TipoPerfil = table.Column<int>(type: "integer", nullable: false),
                    Perf_Acoes = table.Column<int[]>(type: "integer[]", nullable: false),
                    Perf_Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    Usr_DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Usr_DataAtualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Perf_Empresa_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perfil", x => x.Perf_Id);
                    table.ForeignKey(
                        name: "FK_Perfil_Empresa_Perf_Empresa_Id",
                        column: x => x.Perf_Empresa_Id,
                        principalTable: "Empresa",
                        principalColumn: "Emp_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Usr_Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Usr_Nome = table.Column<string>(type: "varchar(255)", nullable: false),
                    Usr_Email = table.Column<string>(type: "varchar(255)", nullable: false),
                    Usr_Senha = table.Column<string>(type: "varchar(32)", nullable: false),
                    Usr_Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    Usr_DataCadastro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Usr_DataAtualizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Usr_Perfil_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Usr_Id);
                    table.ForeignKey(
                        name: "FK_Usuario_Perfil_Usr_Perfil_Id",
                        column: x => x.Usr_Perfil_Id,
                        principalTable: "Perfil",
                        principalColumn: "Perf_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuario_Empresa",
                columns: table => new
                {
                    Empresa_Id = table.Column<long>(type: "bigint", nullable: false),
                    Usuario_Id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario_Empresa", x => new { x.Empresa_Id, x.Usuario_Id });
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa_Empresa_Empresa_Id",
                        column: x => x.Empresa_Id,
                        principalTable: "Empresa",
                        principalColumn: "Emp_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Usuario_Empresa_Usuario_Usuario_Id",
                        column: x => x.Usuario_Id,
                        principalTable: "Usuario",
                        principalColumn: "Usr_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Empresa_Emp_Endereco_Id",
                table: "Empresa",
                column: "Emp_Endereco_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Perfil_Perf_Empresa_Id",
                table: "Perfil",
                column: "Perf_Empresa_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Usr_Perfil_Id",
                table: "Usuario",
                column: "Usr_Perfil_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Empresa_Usuario_Id",
                table: "Usuario_Empresa",
                column: "Usuario_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario_Empresa");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Perfil");

            migrationBuilder.DropTable(
                name: "Empresa");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
