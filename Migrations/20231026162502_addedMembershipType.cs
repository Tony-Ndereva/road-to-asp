using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace road_to_asp.Migrations
{
    /// <inheritdoc />
    public partial class addedMembershipType : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MembershipType_MembershipTypeId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MembershipType",
                table: "MembershipType");

            migrationBuilder.RenameTable(
                name: "MembershipType",
                newName: "MembershipTypes");

            migrationBuilder.RenameColumn(
                name: "MemberShipTypeId",
                table: "MembershipTypes",
                newName: "MembershipTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembershipTypes",
                table: "MembershipTypes",
                column: "MembershipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MembershipTypes_MembershipTypeId",
                table: "Customers",
                column: "MembershipTypeId",
                principalTable: "MembershipTypes",
                principalColumn: "MembershipTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_MembershipTypes_MembershipTypeId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MembershipTypes",
                table: "MembershipTypes");

            migrationBuilder.RenameTable(
                name: "MembershipTypes",
                newName: "MembershipType");

            migrationBuilder.RenameColumn(
                name: "MembershipTypeId",
                table: "MembershipType",
                newName: "MemberShipTypeId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MembershipType",
                table: "MembershipType",
                column: "MemberShipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_MembershipType_MembershipTypeId",
                table: "Customers",
                column: "MembershipTypeId",
                principalTable: "MembershipType",
                principalColumn: "MemberShipTypeId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
