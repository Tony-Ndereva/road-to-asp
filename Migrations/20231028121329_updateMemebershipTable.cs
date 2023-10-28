using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace road_to_asp.Migrations
{
    /// <inheritdoc />
    public partial class updateMemebershipTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql =  @"UPDATE  MembershipTypes SET Name = 'free' WHERE MembershipTypeId = 1 ;
                             UPDATE  MembershipTypes SET Name = 'silver' WHERE MembershipTypeId = 2;
                             UPDATE  MembershipTypes SET Name = 'gold' WHERE MembershipTypeId = 3; ";
            migrationBuilder.Sql(sql);
        }
        

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
