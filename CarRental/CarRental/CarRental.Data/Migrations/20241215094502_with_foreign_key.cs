using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Data.Migrations
{
    public partial class with_foreign_key : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    License_plate = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<int>(type: "int", nullable: false),
                    Company = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Year_production = table.Column<int>(type: "int", nullable: false),
                    Fuel_consumption_per_km = table.Column<int>(type: "int", nullable: false),
                    Test_validity = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Kategory = table.Column<int>(type: "int", nullable: false),
                    IsAvailable = table.Column<bool>(type: "bit", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Color = table.Column<int>(type: "int", nullable: false),
                    Raiting = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CollectionPoint",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumCollectionPoint = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Max_num_of_cars = table.Column<int>(type: "int", nullable: false),
                    Num_of_cars_occupancy = table.Column<int>(type: "int", nullable: false),
                    Accessible_to_disabled = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CollectionPoint", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tz = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip_code = table.Column<int>(type: "int", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invitation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumInvitation = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", maxLength: 9, nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    CollectionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CollectionPointId = table.Column<int>(type: "int", nullable: false),
                    DateOfOrder = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Method_payment = table.Column<int>(type: "int", nullable: false),
                    TotalPayment = table.Column<decimal>(type: "decimal(18,3)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Invitation_Car_CarId",
                        column: x => x.CarId,
                        principalTable: "Car",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invitation_CollectionPoint_CollectionPointId",
                        column: x => x.CollectionPointId,
                        principalTable: "CollectionPoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Invitation_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Invitation_CarId",
                table: "Invitation",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitation_CollectionPointId",
                table: "Invitation",
                column: "CollectionPointId");

            migrationBuilder.CreateIndex(
                name: "IX_Invitation_UserId",
                table: "Invitation",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invitation");

            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "CollectionPoint");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
