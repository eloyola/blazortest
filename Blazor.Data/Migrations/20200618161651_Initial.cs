using Microsoft.EntityFrameworkCore.Migrations;

namespace Blazor.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Frequency",
                columns: table => new
                {
                    FrequencyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frequency", x => x.FrequencyId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Ray",
                columns: table => new
                {
                    RayId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(nullable: true),
                    FrequencyId = table.Column<int>(nullable: false),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ray", x => x.RayId);
                    table.ForeignKey(
                        name: "FK_Ray_Frequency_FrequencyId",
                        column: x => x.FrequencyId,
                        principalTable: "Frequency",
                        principalColumn: "FrequencyId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ray_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prism",
                columns: table => new
                {
                    PrismId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    RayId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prism", x => x.PrismId);
                    table.ForeignKey(
                        name: "FK_Prism_Ray_RayId",
                        column: x => x.RayId,
                        principalTable: "Ray",
                        principalColumn: "RayId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prism_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Prism_RayId",
                table: "Prism",
                column: "RayId");

            migrationBuilder.CreateIndex(
                name: "IX_Prism_UserId",
                table: "Prism",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Ray_FrequencyId",
                table: "Ray",
                column: "FrequencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Ray_UserId",
                table: "Ray",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Prism");

            migrationBuilder.DropTable(
                name: "Ray");

            migrationBuilder.DropTable(
                name: "Frequency");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
