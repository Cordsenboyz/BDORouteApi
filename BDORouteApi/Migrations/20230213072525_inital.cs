using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BDORouteApi.Migrations
{
    /// <inheritdoc />
    public partial class inital : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MobTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Routes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedById = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClassName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Routes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsElite = table.Column<bool>(type: "bit", nullable: false),
                    MobTypeId = table.Column<int>(type: "int", nullable: false),
                    TrashDropRange = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mobs_MobTypes_MobTypeId",
                        column: x => x.MobTypeId,
                        principalTable: "MobTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pulls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RouteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pulls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pulls_Routes_RouteId",
                        column: x => x.RouteId,
                        principalTable: "Routes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mobinstances",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lat = table.Column<double>(type: "float", nullable: false),
                    Lng = table.Column<double>(type: "float", nullable: false),
                    MobId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mobinstances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mobinstances_Mobs_MobId",
                        column: x => x.MobId,
                        principalTable: "Mobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MobinstancePulls",
                columns: table => new
                {
                    PullId = table.Column<int>(type: "int", nullable: false),
                    MobinstanceId = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Mobinstances_MobId",
                table: "Mobinstances",
                column: "MobId");

            migrationBuilder.CreateIndex(
                name: "IX_Mobs_MobTypeId",
                table: "Mobs",
                column: "MobTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Pulls_RouteId",
                table: "Pulls",
                column: "RouteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MobinstancePulls");

            migrationBuilder.DropTable(
                name: "Mobinstances");

            migrationBuilder.DropTable(
                name: "Pulls");

            migrationBuilder.DropTable(
                name: "Mobs");

            migrationBuilder.DropTable(
                name: "Routes");

            migrationBuilder.DropTable(
                name: "MobTypes");
        }
    }
}
