using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace RT.Contacts.DataAccess.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    UUID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Ad = table.Column<string>(type: "text", nullable: false),
                    Soyad = table.Column<string>(type: "text", nullable: false),
                    Firma = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "ContactDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ContactUUID = table.Column<int>(type: "integer", nullable: false),
                    BilgiTipi = table.Column<int>(type: "integer", nullable: false),
                    BilgiIcerigi = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactDetails", x => new { x.ContactUUID, x.Id });
                    table.ForeignKey(
                        name: "FK_ContactDetails_Contacts_ContactUUID",
                        column: x => x.ContactUUID,
                        principalTable: "Contacts",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ContactDetails");

            migrationBuilder.DropTable(
                name: "Contacts");
        }
    }
}
