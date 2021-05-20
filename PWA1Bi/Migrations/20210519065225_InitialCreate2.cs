using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Buffet.Migrations
{
    public partial class InitialCreate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Clientes_ClienteId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_ClienteId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "ClienteId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "descricaoEven",
                table: "Eventos");

            migrationBuilder.AddColumn<Guid>(
                name: "clienteContratanteId",
                table: "Eventos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "descricaoEvento",
                table: "Eventos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_clienteContratanteId",
                table: "Eventos",
                column: "clienteContratanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Clientes_clienteContratanteId",
                table: "Eventos",
                column: "clienteContratanteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Clientes_clienteContratanteId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_clienteContratanteId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "clienteContratanteId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "descricaoEvento",
                table: "Eventos");

            migrationBuilder.AddColumn<Guid>(
                name: "ClienteId",
                table: "Eventos",
                type: "char(36)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "descricaoEven",
                table: "Eventos",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_ClienteId",
                table: "Eventos",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Clientes_ClienteId",
                table: "Eventos",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
