using Microsoft.AspNetCore.Mvc;
using road_to_asp.Data;
using road_to_asp.Models;
using road_to_asp.Services;
using road_to_asp.ViewModels;

namespace road_to_asp.Controllers
{

    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;
        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
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
        public IActionResult Edit(int id)
        {
            return Content("id=" + id);
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

    }
}
