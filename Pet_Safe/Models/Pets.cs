using System.ComponentModel.DataAnnotations;

namespace Pet_Safe.Models
{
    public class Pets
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        [Required]
        public string? Name { get; set; }
        //public string? Breed { get; set; }

    }
}
