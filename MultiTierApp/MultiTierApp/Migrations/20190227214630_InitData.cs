using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class InitData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AddressType",
                columns: table => new
                {
                    AddressTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(maxLength: 1, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressType", x => x.AddressTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Iso = table.Column<string>(maxLength: 2, nullable: false),
                    Name = table.Column<string>(maxLength: 80, nullable: false),
                    Iso3 = table.Column<string>(maxLength: 3, nullable: true),
                    NumCode = table.Column<string>(nullable: true),
                    PhoneCode = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "varchar(5)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ZIP = table.Column<string>(type: "varchar(20)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => new { x.CustomerId, x.Name });
                    table.ForeignKey(
                        name: "FK_Customers_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Adresses",
                columns: table => new
                {
                    CustomerId = table.Column<string>(type: "varchar(5)", nullable: false),
                    AddressTypeId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    ZIP = table.Column<string>(type: "varchar(20)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    CountryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adresses", x => new { x.CustomerId, x.AddressTypeId });
                    table.ForeignKey(
                        name: "FK_Adresses_AddressType_AddressTypeId",
                        column: x => x.AddressTypeId,
                        principalTable: "AddressType",
                        principalColumn: "AddressTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adresses_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Adresses_Customers_CustomerId_Name",
                        columns: x => new { x.CustomerId, x.Name },
                        principalTable: "Customers",
                        principalColumns: new[] { "CustomerId", "Name" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AddressType",
                columns: new[] { "AddressTypeId", "Code", "Description" },
                values: new object[,]
                {
                    { 1, "I", "invoice address" },
                    { 2, "D", "delivery address" },
                    { 3, "S", "service address" }
                });

            migrationBuilder.InsertData(
                table: "Country",
                columns: new[] { "CountryId", "Iso", "Iso3", "Name", "NumCode", "PhoneCode" },
                values: new object[,]
                {
                    { 20, "BY", null, "Belarus", null, null },
                    { 80, "DE", null, "Germany", null, null },
                    { 171, "PL", null, "Poland", null, null }
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "CustomerId", "Name", "City", "CountryId", "Street", "ZIP" },
                values: new object[,]
                {
                    { "2", "Alex", "Grodno", 20, "Swieta", "35605" },
                    { "1", "Alex", "Wroclaw", 171, "Gaja", "24605" },
                    { "1", "Ola", "Wroclaw", 171, "Jasna", "67605" },
                    { "3", "Ola", "Katovice", 171, "Czysta", "24777" }
                });

            migrationBuilder.InsertData(
                table: "Adresses",
                columns: new[] { "CustomerId", "AddressTypeId", "City", "CountryId", "Name", "Street", "ZIP" },
                values: new object[,]
                {
                    { "2", 2, "Wroclaw", 171, "Alex", "Szara", "24601" },
                    { "1", 1, "Wroclaw", 171, "Alex", "Zielona", "24605" },
                    { "1", 2, "Wroclaw", 171, "Alex", "Czerwona", "24601" },
                    { "3", 3, "Wroclaw", 171, "Ola", "Pomaranczowa", "24605" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_AddressTypeId",
                table: "Adresses",
                column: "AddressTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_CountryId",
                table: "Adresses",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_Adresses_CustomerId_Name",
                table: "Adresses",
                columns: new[] { "CustomerId", "Name" });

            migrationBuilder.CreateIndex(
                name: "IX_Country_Iso",
                table: "Country",
                column: "Iso",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CountryId",
                table: "Customers",
                column: "CountryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adresses");

            migrationBuilder.DropTable(
                name: "AddressType");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Country");
        }
    }
}
