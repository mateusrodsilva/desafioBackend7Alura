using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace desafioBackend7Alura.Data.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Depoimentos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NomePessoa = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    ConteudoDepoimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Foto = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    CriadoEm = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Depoimentos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Depoimentos_Id",
                table: "Depoimentos",
                column: "Id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Depoimentos");
        }
    }
}
