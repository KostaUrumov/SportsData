using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsData.Migrations
{
    /// <inheritdoc />
    public partial class coachHired : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsHired",
                table: "Coaches",
                newName: "isHired");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "isHired",
                table: "Coaches",
                newName: "IsHired");
        }
    }
}
