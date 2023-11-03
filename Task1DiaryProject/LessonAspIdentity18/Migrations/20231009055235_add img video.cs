using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LessonAspIdentity18.Migrations
{
    /// <inheritdoc />
    public partial class addimgvideo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "UserPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Video",
                table: "UserPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "UserPosts");

            migrationBuilder.DropColumn(
                name: "Video",
                table: "UserPosts");
        }
    }
}
