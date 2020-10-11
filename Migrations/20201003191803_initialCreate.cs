using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPages.Migrations
{
    public partial class initialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Classification = table.Column<string>(nullable: true),
                    Fee = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    ServicesID = table.Column<int>(nullable: false),
                    ContactEmail = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Contacts_Services_ServicesID",
                        column: x => x.ServicesID,
                        principalTable: "Services",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "ID", "Classification", "Fee", "Name" },
                values: new object[,]
                {
                    { 1, "Full", 450.0, "Full-Day Treatment Package" },
                    { 2, "Half", 300.0, "Half-Day Treatment Package" },
                    { 3, "Two", 225.0, "Two-Hour Treatment Package" },
                    { 4, "One", 100.0, "One-Hour Treatment Package" },
                    { 5, "Other", 200.0, "Custom Treatment Package" },
                    { 6, "Salon", 45.0, "Haircut or Trim" },
                    { 7, "Salon", 100.0, "Full Foil Color" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ID", "ContactEmail", "Name", "ServicesID" },
                values: new object[] { 1, "wilma@flint.net", "Wilma Flintstone", 1 });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ID", "ContactEmail", "Name", "ServicesID" },
                values: new object[] { 3, "betts@rubb.com", "Betty Rubble", 5 });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "ID", "ContactEmail", "Name", "ServicesID" },
                values: new object[] { 2, "Barn@rubb.com", "Barney Rubble", 7 });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_ServicesID",
                table: "Contacts",
                column: "ServicesID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "Services");
        }
    }
}
