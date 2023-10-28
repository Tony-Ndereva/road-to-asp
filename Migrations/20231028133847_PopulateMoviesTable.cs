using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace road_to_asp.Migrations
{
    /// <inheritdoc />
    public partial class PopulateMoviesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            string sql = @"UPDATE Movies SET Genre = 'action', Name = 'The Terminator', ReleaseDate = '06/03/1995' WHERE MovieId = 1;
                           INSERT INTO Movies (MovieId,Name, Genre,ReleaseDate,DateAdded,NumberInStock) VALUES(2,'Titanic','romance','06/03/1996','06/03/2005',51);
                           INSERT INTO Movies (MovieId,Name, Genre,ReleaseDate,DateAdded,NumberInStock) VALUES(3,'Hangover','comedy','06/03/1997','06/03/2006',70);
                           INSERT INTO Movies (MovieId,Name, Genre,ReleaseDate,DateAdded,NumberInStock) VALUES(4,'Die Hard','action','06/03/1998','06/03/2007',125);
INSERT INTO Movies (MovieId,Name, Genre,ReleaseDate,DateAdded,NumberInStock) VALUES(5,'Toy Story','family','06/03/1999','06/03/2008',250)";
            migrationBuilder.Sql(sql);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
