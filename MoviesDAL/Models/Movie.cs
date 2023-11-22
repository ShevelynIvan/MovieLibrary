using System.ComponentModel.DataAnnotations;

namespace MoviesDAL.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        
        [Required]
        public bool IsAdult { get; set; }

        public override string ToString()
        {
            string isAdult = IsAdult == true ? "yes":"no";

            return $"Film: {Name}; Is adult: {isAdult}";
        }
    }
}
