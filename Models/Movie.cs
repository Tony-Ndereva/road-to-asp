using System.ComponentModel.DataAnnotations;

namespace road_to_asp.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public DateTime DateAdded { get; set; }

        [Display(Name ="Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name ="Number in Stock")]
        public int NumberInStock { get; set; }

        public int GenreId { get; set; }

    }
}
