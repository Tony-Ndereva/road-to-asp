using Microsoft.AspNetCore.Mvc;
using road_to_asp.Models;

namespace road_to_asp.Controllers
{
    public class MoviesController : Controller
    {
        public IActionResult Random()
        {
            var movie = new Movie();
            return View(movie);
        }
    }
}
