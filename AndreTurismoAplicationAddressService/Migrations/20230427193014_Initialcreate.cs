using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AndreTurismoAplicationAddressService.Migrations
{
    public partial class Initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CityModel",
                columns: table => new
                {
                    Id_City = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DtRegister_City = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityModel", x => x.Id_City);
                });

            migrationBuilder.CreateTable(
                name: "AddressModel",
                columns: table => new
                {
                    Id_Address = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Complement = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Id_City_AddressId_City = table.Column<int>(type: "int", nullable: false),
                    DtRegister_Address = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AddressModel", x => x.Id_Address);
                    table.ForeignKey(
                        name: "FK_AddressModel_CityModel_Id_City_AddressId_City",
                        column: x => x.Id_City_AddressId_City,
                        principalTable: "CityModel",
                        principalColumn: "Id_City",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AddressModel_Id_City_AddressId_City",
                table: "AddressModel",
                column: "Id_City_AddressId_City");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AddressModel");

            migrationBuilder.DropTable(
                name: "CityModel");
        }
    }
}
