using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using road_to_asp.Data;
using road_to_asp.Dtos;
using road_to_asp.Models;

namespace road_to_asp.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;

        public MoviesController(ApplicationDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpGet]
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Movie> GetMovieById(int id)
        {
            var customer = _context.Movies.SingleOrDefault(c => c.MovieId == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        [HttpPost]

        public ActionResult<Movie> CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Ok(movie);

        }

        [HttpDelete("{id}")]
        public ActionResult<Movie> DeleteMovieById(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.MovieId == id);
            if (movie == null)
            {
                return NotFound();
            }
            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok(new { message = $"Customer {movie.Name} has been deleted!" });
        }

        [HttpDelete]
        public ActionResult DeleteAllMovies()
        {
            var movies = _context.Movies.ToList();
            if (movies.Count == 0)
            {
                return NotFound(new { message = "No movies were found" });
            }

            _context.Movies.RemoveRange(movies);
            _context.SaveChanges();
            return Ok(new { message = "All Movies were deleted" });
        }

        [HttpPut("{id}")]
        public ActionResult<MovieDto> UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            var movieInDb = _context.Movies.SingleOrDefault(c => c.MovieId == id);
            if (movieInDb == null)
            {
                return NotFound(new { message = "No movie was found" });
            }
            _mapper.Map(movieDto, movieInDb);
            /*            movieInDb.ReleaseDate = movieDto.ReleaseDate;
                        movieInDb.NumberInStock = movieDto.NumberInStock;
                        movieInDb.DateAdded = movieDto.DateAdded;
                        movieInDb.Name = movieDto.Name;*/
            _context.SaveChanges();
            return Ok(movieInDb);



        }


    }
}
