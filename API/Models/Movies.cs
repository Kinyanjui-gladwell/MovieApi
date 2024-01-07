using System.ComponentModel.DataAnnotations;

namespace MovieAPI.Models
{
    public class Movies
    {
        [Key]
        public Guid Guid = new Guid();

        [Required]
        public int id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public Genre Genre { get; set; }

        
    }
    public enum Genre
    {
        Romantic,
        Comedy,
        Action,
        Mystery,
        Horror
    }
}
