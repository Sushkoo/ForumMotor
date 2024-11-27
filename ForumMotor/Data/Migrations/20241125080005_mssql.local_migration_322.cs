using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ForumMotor.Data.Migrations
{
    /// <inheritdoc />
    public partial class mssqllocal_migration_322 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Kategoriak",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoriak", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Kategoriak_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Topicok",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topicok", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Topicok_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Topicok_Kategoriak_KategoriaId",
                        column: x => x.KategoriaId,
                        principalTable: "Kategoriak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Bejegyzesek",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    Dislikes = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TopicId = table.Column<int>(type: "int", nullable: false),
                    Reply = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bejegyzesek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bejegyzesek_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bejegyzesek_Topicok_TopicId",
                        column: x => x.TopicId,
                        principalTable: "Topicok",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bejegyzesek_TopicId",
                table: "Bejegyzesek",
                column: "TopicId");

            migrationBuilder.CreateIndex(
                name: "IX_Bejegyzesek_UserId",
                table: "Bejegyzesek",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Kategoriak_UserId",
                table: "Kategoriak",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Topicok_KategoriaId",
                table: "Topicok",
                column: "KategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Topicok_UserId",
                table: "Topicok",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bejegyzesek");

            migrationBuilder.DropTable(
                name: "Topicok");

            migrationBuilder.DropTable(
                name: "Kategoriak");
        }
    }
}
