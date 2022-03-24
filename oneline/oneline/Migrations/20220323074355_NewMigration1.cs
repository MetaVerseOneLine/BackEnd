using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace oneline.Migrations
{
    public partial class NewMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserPassword = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserContent = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserImg = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Worlds",
                columns: table => new
                {
                    WorldIdx = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WorldName = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorldContent = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorldScene = table.Column<int>(type: "int", nullable: false),
                    WorldCategory = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorldImg = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Worlds", x => x.WorldIdx);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Quests",
                columns: table => new
                {
                    QeustIdx = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    WorldIdx = table.Column<int>(type: "int", nullable: false),
                    QuestContent = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Quests", x => x.QeustIdx);
                    table.ForeignKey(
                        name: "FK_Quests_Worlds_WorldIdx",
                        column: x => x.WorldIdx,
                        principalTable: "Worlds",
                        principalColumn: "WorldIdx",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Scores",
                columns: table => new
                {
                    ScoreIdx = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorldIdx = table.Column<int>(type: "int", nullable: false),
                    MyScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scores", x => x.ScoreIdx);
                    table.ForeignKey(
                        name: "FK_Scores_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Scores_Worlds_WorldIdx",
                        column: x => x.WorldIdx,
                        principalTable: "Worlds",
                        principalColumn: "WorldIdx",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    AchIdx = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(type: "varchar(255)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    WorldIdx = table.Column<int>(type: "int", nullable: false),
                    QuestIdx = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.AchIdx);
                    table.ForeignKey(
                        name: "FK_Achievements_Quests_QuestIdx",
                        column: x => x.QuestIdx,
                        principalTable: "Quests",
                        principalColumn: "QeustIdx",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Achievements_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Achievements_Worlds_WorldIdx",
                        column: x => x.WorldIdx,
                        principalTable: "Worlds",
                        principalColumn: "WorldIdx",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_QuestIdx",
                table: "Achievements",
                column: "QuestIdx");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_UserId",
                table: "Achievements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_WorldIdx",
                table: "Achievements",
                column: "WorldIdx");

            migrationBuilder.CreateIndex(
                name: "IX_Quests_WorldIdx",
                table: "Quests",
                column: "WorldIdx");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_UserId",
                table: "Scores",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Scores_WorldIdx",
                table: "Scores",
                column: "WorldIdx");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "Scores");

            migrationBuilder.DropTable(
                name: "Quests");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Worlds");
        }
    }
}
