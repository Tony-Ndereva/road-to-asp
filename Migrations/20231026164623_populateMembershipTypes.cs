using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace road_to_asp.Migrations
{
    /// <inheritdoc />
    public partial class populateMembershipTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"GO INSERT INTO MembershipTypes (MembershipTypeId, SignUpFee,DurationInMonths,DiscountRate) VALUES(1,0,0,0)
GO INSERT INTO MembershipTypes (MembershipTypeId, SignUpFee,DurationInMonths,DiscountRate) VALUES(2,30,1,10)
GO INSERT INTO MembershipTypes (MembershipTypeId, SignUpFee,DurationInMonths,DiscountRate) VALUES(3,90,3,15)
GGO INSERT INTO MembershipTypes (MembershipTypeId, SignUpFee,DurationInMonths,DiscountRate) VALUES(4,300,12,20) GO";

            migrationBuilder.Sql(sql);
        
        
        }


        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
