using road_to_asp.Models;

namespace road_to_asp.Services
{
    public class MovieList
    {
        private List<Movie> _movies;
        public MovieList()
        {
            this._movies = new List<Movie>
            {
             new Movie {Name = "Shrek!",Id = 1 },
             new Movie {Name = "Snowfall", Id = 2}
            };
        }

        public List<Movie> GetMovies()
        {
            return _movies;
        }
    }
}
