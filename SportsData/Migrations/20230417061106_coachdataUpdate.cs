using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsData.Migrations
{
    /// <inheritdoc />
    public partial class coachdataUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsHired",
                table: "Coaches",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsHired",
                table: "Coaches");
        }
    }
}
