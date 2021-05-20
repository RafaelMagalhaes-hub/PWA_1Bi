using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Buffet.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SituacaoId",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "dataEvento",
                table: "Eventos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "descricaoEven",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "localDoEventoId",
                table: "Eventos",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cidade = table.Column<string>(nullable: true),
                    Uf = table.Column<string>(nullable: true),
                    Cep = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    Logradouro = table.Column<string>(nullable: true),
                    Numero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SituacaoConvidado",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    opcaoGeral = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacaoConvidado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SituacaoEvento",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    escolhaSituacaoGeral = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SituacaoEvento", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Locais",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    EnderecoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locais", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Locais_Endereco_EnderecoId",
                        column: x => x.EnderecoId,
                        principalTable: "Endereco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ConvidadoEntity",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    nascimentoConvidado = table.Column<DateTime>(nullable: false),
                    Observacoes = table.Column<string>(nullable: true),
                    Insercao = table.Column<DateTime>(nullable: false),
                    Modificacao = table.Column<DateTime>(nullable: false),
                    situacaoConvidadoId = table.Column<Guid>(nullable: true),
                    EventoEntityId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConvidadoEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConvidadoEntity_Eventos_EventoEntityId",
                        column: x => x.EventoEntityId,
                        principalTable: "Eventos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ConvidadoEntity_SituacaoConvidado_situacaoConvidadoId",
                        column: x => x.situacaoConvidadoId,
                        principalTable: "SituacaoConvidado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_SituacaoId",
                table: "Eventos",
                column: "SituacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_localDoEventoId",
                table: "Eventos",
                column: "localDoEventoId");

            migrationBuilder.CreateIndex(
                name: "IX_ConvidadoEntity_EventoEntityId",
                table: "ConvidadoEntity",
                column: "EventoEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ConvidadoEntity_situacaoConvidadoId",
                table: "ConvidadoEntity",
                column: "situacaoConvidadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Locais_EnderecoId",
                table: "Locais",
                column: "EnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_SituacaoEvento_SituacaoId",
                table: "Eventos",
                column: "SituacaoId",
                principalTable: "SituacaoEvento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Locais_localDoEventoId",
                table: "Eventos",
                column: "localDoEventoId",
                principalTable: "Locais",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_SituacaoEvento_SituacaoId",
                table: "Eventos");

            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Locais_localDoEventoId",
                table: "Eventos");

            migrationBuilder.DropTable(
                name: "ConvidadoEntity");

            migrationBuilder.DropTable(
                name: "Locais");

            migrationBuilder.DropTable(
                name: "SituacaoEvento");

            migrationBuilder.DropTable(
                name: "SituacaoConvidado");

            migrationBuilder.DropTable(
                name: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_SituacaoId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_localDoEventoId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "SituacaoId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "dataEvento",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "descricaoEven",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "localDoEventoId",
                table: "Eventos");
        }
    }
}
