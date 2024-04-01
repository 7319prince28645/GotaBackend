using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApiGotadevida.Migrations
{
    /// <inheritdoc />
    public partial class MiPrimer2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Mensaje",
                table: "PostUsers",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "PostUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "PostUsers");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "PostUsers",
                newName: "Mensaje");
        }
    }
}
