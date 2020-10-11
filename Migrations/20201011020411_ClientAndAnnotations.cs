using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RazorPages.Migrations
{
    public partial class ClientAndAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Services_ServicesID",
                table: "Contacts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contact");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_ServicesID",
                table: "Contact",
                newName: "IX_Contact_ServicesID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(name: "First Name", nullable: false),
                    LastName = table.Column<string>(name: "Last Name", nullable: false),
                    Address = table.Column<string>(nullable: true),
                    City = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Zipcode = table.Column<string>(nullable: true),
                    Country = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    ConfirmPassword = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ClientService",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientID = table.Column<int>(nullable: false),
                    ServicesID = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientService", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ClientService_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Client",
                columns: new[] { "ID", "Address", "City", "ConfirmPassword", "Country", "Email", "First Name", "Last Name", "Password", "Phone", "Zipcode", "State", "Username" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "flo@schmoe.net", "Flo", "Schmoe", "FloSchmoe1234*", null, null, null, "Flo" },
                    { 2, null, null, null, null, "jojo@schmoe.net", "Jo", "Schmoe", "JoJoSchmoe1234?", null, null, null, "JoJo" },
                    { 3, null, null, null, null, "truly@schmoe.net", "Truly", "Schmoe", "Truly9876**", null, null, null, "Truly" }
                });

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ID",
                keyValue: 6,
                column: "Classification",
                value: "Cut");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ID",
                keyValue: 7,
                column: "Classification",
                value: "Color");

            migrationBuilder.InsertData(
                table: "ClientService",
                columns: new[] { "ID", "ClientID", "Date", "ServicesID" },
                values: new object[] { 1, 1, new DateTime(2020, 10, 10, 22, 4, 10, 845, DateTimeKind.Local).AddTicks(6004), 1 });

            migrationBuilder.InsertData(
                table: "ClientService",
                columns: new[] { "ID", "ClientID", "Date", "ServicesID" },
                values: new object[] { 3, 1, new DateTime(2020, 10, 10, 22, 4, 10, 850, DateTimeKind.Local).AddTicks(2430), 5 });

            migrationBuilder.InsertData(
                table: "ClientService",
                columns: new[] { "ID", "ClientID", "Date", "ServicesID" },
                values: new object[] { 2, 2, new DateTime(2020, 10, 10, 22, 4, 10, 850, DateTimeKind.Local).AddTicks(2354), 7 });

            migrationBuilder.CreateIndex(
                name: "IX_ClientService_ClientID",
                table: "ClientService",
                column: "ClientID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Services_ServicesID",
                table: "Contact",
                column: "ServicesID",
                principalTable: "Services",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Services_ServicesID",
                table: "Contact");

            migrationBuilder.DropTable(
                name: "ClientService");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Contacts");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_ServicesID",
                table: "Contacts",
                newName: "IX_Contacts_ServicesID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ID",
                keyValue: 6,
                column: "Classification",
                value: "Salon");

            migrationBuilder.UpdateData(
                table: "Services",
                keyColumn: "ID",
                keyValue: 7,
                column: "Classification",
                value: "Foil Color");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Services_ServicesID",
                table: "Contacts",
                column: "ServicesID",
                principalTable: "Services",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
