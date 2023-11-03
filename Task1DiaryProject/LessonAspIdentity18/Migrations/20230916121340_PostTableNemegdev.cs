using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LessonAspIdentity18.Migrations
{
    /// <inheritdoc />
    public partial class PostTableNemegdev : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserPosts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PostBody = table.Column<string>(type: "nvarchar(2000)", maxLength: 2000, nullable: false),
                    CDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPosts", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserPosts");
        }
    }
}
