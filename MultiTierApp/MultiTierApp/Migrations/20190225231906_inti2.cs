using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiTierApp.Migrations
{
    public partial class inti2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Countries_CountryId",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Customers_CustomerId_Name",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Countries_CountryId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Countries",
                table: "Countries");

            migrationBuilder.RenameTable(
                name: "Countries",
                newName: "Country");

            migrationBuilder.RenameIndex(
                name: "IX_Countries_Iso",
                table: "Country",
                newName: "IX_Country_Iso");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Country",
                table: "Country",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Country_CountryId",
                table: "Adresses",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Customers_CustomerId_Name",
                table: "Adresses",
                columns: new[] { "CustomerId", "Name" },
                principalTable: "Customers",
                principalColumns: new[] { "CustomerId", "Name" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Country_CountryId",
                table: "Customers",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Country_CountryId",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Adresses_Customers_CustomerId_Name",
                table: "Adresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Country_CountryId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Country",
                table: "Country");

            migrationBuilder.RenameTable(
                name: "Country",
                newName: "Countries");

            migrationBuilder.RenameIndex(
                name: "IX_Country_Iso",
                table: "Countries",
                newName: "IX_Countries_Iso");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Countries",
                table: "Countries",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Countries_CountryId",
                table: "Adresses",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Adresses_Customers_CustomerId_Name",
                table: "Adresses",
                columns: new[] { "CustomerId", "Name" },
                principalTable: "Customers",
                principalColumns: new[] { "CustomerId", "Name" },
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Countries_CountryId",
                table: "Customers",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "CountryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
