using System.ComponentModel.DataAnnotations;

namespace road_to_asp.Models
{
    public class Movie
    {
        public int MovieId { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public Genre Genre { get; set; }
        public DateTime DateAdded { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 20, ErrorMessage = "The stock must be between {1} and {2}")]
        [Display(Name = "Number in Stock")]
        public int NumberInStock { get; set; }

        public int GenreId { get; set; }

    }
}
