using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExcelImportApi.Migrations
{
    /// <inheritdoc />
    public partial class Update_column_name : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Product",
                newName: "Salary");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Salary",
                table: "Product",
                newName: "Price");
        }
    }
}
