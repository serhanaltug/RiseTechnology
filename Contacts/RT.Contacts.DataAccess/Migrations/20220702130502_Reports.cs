using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RT.Contacts.DataAccess.Migrations
{
    public partial class Reports : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactDetails",
                table: "ContactDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactDetails",
                table: "ContactDetails",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    UUID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Konum = table.Column<string>(type: "text", nullable: false),
                    KayitliKisiSayisi = table.Column<int>(type: "integer", nullable: true),
                    KayitliTelefonNumarasiSayisi = table.Column<int>(type: "integer", nullable: true),
                    RaporTarihi = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RaporDurumu = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.UUID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ContactDetails_ContactUUID",
                table: "ContactDetails",
                column: "ContactUUID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ContactDetails",
                table: "ContactDetails");

            migrationBuilder.DropIndex(
                name: "IX_ContactDetails_ContactUUID",
                table: "ContactDetails");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ContactDetails",
                table: "ContactDetails",
                columns: new[] { "ContactUUID", "Id" });
        }
    }
}
