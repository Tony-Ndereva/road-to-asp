using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace road_to_asp.Migrations
{
    /// <inheritdoc />
    public partial class FixedTypoInBirthDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthdDate",
                table: "Customers",
                newName: "BirthDate");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BirthDate",
                table: "Customers",
                newName: "BirthdDate");
        }
    }
}
