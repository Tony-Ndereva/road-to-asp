namespace road_to_asp.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Movie()
        {
            this.Name = "Shrek!";
            this.Id = 3;
        }
    }
}
