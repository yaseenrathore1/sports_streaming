using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sportrs_Streaming_platform.Migrations
{
    /// <inheritdoc />
    public partial class AddKeepLoginColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "KeepLogin",
                table: "Admin",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KeepLogin",
                table: "Admin");
        }
    }
}
