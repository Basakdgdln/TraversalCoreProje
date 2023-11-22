using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class guide_reservation_relation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GuideID",
                table: "Reservations",
                type: "int",
                nullable: true,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_GuideID",
                table: "Reservations",
                column: "GuideID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Guides_GuideID",
                table: "Reservations",
                column: "GuideID",
                principalTable: "Guides",
                principalColumn: "GuideID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Guides_GuideID",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_GuideID",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "GuideID",
                table: "Reservations");
        }
    }
}
