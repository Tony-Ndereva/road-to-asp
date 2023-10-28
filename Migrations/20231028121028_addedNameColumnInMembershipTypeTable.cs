using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace road_to_asp.Migrations
{
    /// <inheritdoc />
    public partial class addedNameColumnInMembershipTypeTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "MembershipTypes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "MembershipTypes");
        }
    }
}
