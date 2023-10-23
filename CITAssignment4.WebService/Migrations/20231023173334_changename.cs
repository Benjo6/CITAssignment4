using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CITAssignment4.WebService.Migrations
{
    /// <inheritdoc />
    public partial class changename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "customername",
                table: "Category",
                newName: "CATEGORYNAME");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CATEGORYNAME",
                table: "Category",
                newName: "customername");
        }
    }
}
