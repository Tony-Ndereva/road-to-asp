using Microsoft.AspNetCore.Mvc;
using road_to_asp.Models;

namespace road_to_asp.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Random()
        {
            var movie = new Movie();
            //return NotFound();
            //return new EmptyResults();
            return RedirectToAction("Index", "Home", new { page = 1, sortBy = "name" });
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
