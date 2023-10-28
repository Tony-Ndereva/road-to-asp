using System.ComponentModel.DataAnnotations;

namespace road_to_asp.Models
{
    public class Genre
    {
        [Required]
        public int GenreId { get; set; }
        public string Name { get; set; }
    }
}
