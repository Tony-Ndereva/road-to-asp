using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace road_to_asp.Migrations
{
    /// <inheritdoc />
    public partial class AddBirthDateToCustomers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "BirthdDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BirthdDate",
                table: "Customers");
        }
    }
}
