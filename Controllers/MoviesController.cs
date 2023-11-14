using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using road_to_asp.Data;
using road_to_asp.Models;
using road_to_asp.ViewModels;

namespace road_to_asp.Controllers
{

    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<CustomersController> _logger;
        public MoviesController(ApplicationDbContext context, ILogger<CustomersController> logger)
        {
            _context = context;
            _logger = logger;
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        [Route("movies/random")]
        public IActionResult Random()
        {
            var movie = _context.Movies.ToList();
            var customers = _context.Customers.ToList();


            var viewModel = new RandomMovieViewModel
            {
                Movie = movie,
                Customers = customers
            };
            //return NotFound();
            //return new EmptyResults();
            //return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });

            // 2 blocks of code below shows how to use viewdata to pass data to views
            //ViewData["Movie"] = movie;
            //return View();
            return View(viewModel);
        }
        public IActionResult New()
        {
            var genres = _context.Genres.ToList();
            var movie = new Movie();
            var viewModel = new MovieFormViewModel
            {
                Movie = movie,
                Genres = genres,

            };
            return View("MoviesForm", viewModel);
        }
        public IActionResult Edit(int id)
        {
            var movie = _context.Movies.Single(m => m.MovieId == id);
            var viewModel = new MovieFormViewModel()
            {
                Movie = movie,
                Genres = _context.Genres.ToList(),
            };
            return View("MoviesForm", viewModel);
        }
        [HttpPost]
        public IActionResult Save(Movie movie)
        {
            if (movie.Name != null)
                movie.Name = movie.Name.ToLower();
            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    foreach (var error in ModelState[key].Errors)
                    {
                        _logger.LogError($"Model error for {key}: {error.ErrorMessage}");
                    }
                }
                var viewModel = new MovieFormViewModel()
                {
                    Movie = movie,
                    Genres = _context.Genres.ToList(),
                };
                return View("MoviesForm", viewModel);
            }
            if (movie.MovieId == 0)
            {
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.MovieId == movie.MovieId);

                movieInDb.Name = movie.Name;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.ReleaseDate = movie.ReleaseDate;
            }
            _context.SaveChanges();

            return RedirectToAction("AllMovies", "Movies");
        }

        public IActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
            {
                pageIndex = 1;
            }
            if (String.IsNullOrWhiteSpace(sortBy))
            {
                sortBy = "Name";
            }
            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        //this is attribute-based routing
        // movies

        [Route("movies/released/{year}/{month}")]
        public IActionResult ByReleaseYear(int year, byte month)
        {
            return Content(year + "/" + month);

        }

        [Route("movies/AllMovies")]
        public IActionResult AllMovies()
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            return View(movies);
        }
        [Route("movies/Details/{id}")]
        public IActionResult Details(int? id)
        {
            var movies = _context.Movies.Include(m => m.Genre).ToList();
            var movie = movies.FirstOrDefault(m => id == m.MovieId);

            return View(movie);

        }


    }
}
