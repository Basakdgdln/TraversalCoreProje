using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TravelStories",
                columns: table => new
                {
                    StoriesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details1 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Details2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Image2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Quotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Writer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GuideID = table.Column<int>(type: "int", nullable: true),
                    DestinationID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TravelStories", x => x.StoriesID);
                    table.ForeignKey(
                        name: "FK_TravelStories_Destinations_DestinationID",
                        column: x => x.DestinationID,
                        principalTable: "Destinations",
                        principalColumn: "DestinationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TravelStories_Guides_GuideID",
                        column: x => x.GuideID,
                        principalTable: "Guides",
                        principalColumn: "GuideID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TravelStories_DestinationID",
                table: "TravelStories",
                column: "DestinationID");

            migrationBuilder.CreateIndex(
                name: "IX_TravelStories_GuideID",
                table: "TravelStories",
                column: "GuideID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TravelStories");
        }
    }
}
