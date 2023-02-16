using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDORouteApi.Migrations
{
    /// <inheritdoc />
    public partial class removemanytomanymodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MobinstancePulls");

            migrationBuilder.CreateTable(
                name: "MobinstancePull",
                columns: table => new
                {
                    MobInstancesId = table.Column<int>(type: "int", nullable: false),
                    PullsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobinstancePull", x => new { x.MobInstancesId, x.PullsId });
                    table.ForeignKey(
                        name: "FK_MobinstancePull_Mobinstances_MobInstancesId",
                        column: x => x.MobInstancesId,
                        principalTable: "Mobinstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MobinstancePull_Pulls_PullsId",
                        column: x => x.PullsId,
                        principalTable: "Pulls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MobinstancePull_PullsId",
                table: "MobinstancePull",
                column: "PullsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MobinstancePull");

            migrationBuilder.CreateTable(
                name: "MobinstancePulls",
                columns: table => new
                {
                    MobinstanceId = table.Column<int>(type: "int", nullable: false),
                    PullId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobinstancePulls", x => new { x.MobinstanceId, x.PullId });
                    table.ForeignKey(
                        name: "FK_MobinstancePulls_Mobinstances_MobinstanceId",
                        column: x => x.MobinstanceId,
                        principalTable: "Mobinstances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MobinstancePulls_Pulls_PullId",
                        column: x => x.PullId,
                        principalTable: "Pulls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MobinstancePulls_PullId",
                table: "MobinstancePulls",
                column: "PullId");
        }
    }
}
