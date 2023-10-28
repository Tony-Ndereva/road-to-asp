using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace road_to_asp.Migrations
{
    /// <inheritdoc />
    public partial class PopulateGenres : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"INSERT INTO Genres (Name) VALUES('action');
                            INSERT INTO Genres (Name) VALUES('romance');
                            INSERT INTO Genres (Name) VALUES('comedy');
                            INSERT INTO Genres (Name) VALUES('family');";
            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
