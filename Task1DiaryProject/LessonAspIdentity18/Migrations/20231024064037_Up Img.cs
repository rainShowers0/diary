using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LessonAspIdentity18.Migrations
{
    /// <inheritdoc />
    public partial class UpImg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Image",
                table: "UserPosts",
                newName: "ImgPath");

            migrationBuilder.AddColumn<string>(
                name: "ImgName",
                table: "UserPosts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImgName",
                table: "UserPosts");

            migrationBuilder.RenameColumn(
                name: "ImgPath",
                table: "UserPosts",
                newName: "Image");
        }
    }
}
