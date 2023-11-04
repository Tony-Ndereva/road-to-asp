using road_to_asp.Models;

namespace road_to_asp.ViewModels
{
    public class MovieFormViewModel
    {
        public Movie Movie { get; set; }
        public IEnumerable<Genre>Genres { get; set; }
        
    }
}
