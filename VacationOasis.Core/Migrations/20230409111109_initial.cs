using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VacationOasis.Core.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotel",
                columns: table => new
                {
                    HotelImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HotelImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelImagePrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    HotelImageCategory = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelImageLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPopular = table.Column<bool>(type: "bit", nullable: false),
                    HotelImageStyle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelImageStyle1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HotelDetailBedRoomNum = table.Column<int>(type: "int", nullable: false),
                    HotelDetailLivingRoomNum = table.Column<int>(type: "int", nullable: false),
                    HotelDetailbathRoomNum = table.Column<int>(type: "int", nullable: false),
                    HotelDetailDinninRoomNum = table.Column<int>(type: "int", nullable: false),
                    HotelDetailMPS = table.Column<int>(type: "int", nullable: false),
                    HotelDetailUnitReady = table.Column<int>(type: "int", nullable: false),
                    HotelDetailRefrigiratorNum = table.Column<int>(type: "int", nullable: false),
                    HotelDetailTelevisionNum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotel", x => x.HotelImageId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    updated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotel");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
