using System.ComponentModel.DataAnnotations;

namespace GuitarManager.Models
{
    public class Guitar
    {
        public int id { get; set; }
        [Required]
        public string Manufacturer { get; set; }
        [Required]
        public string ModelName { get; set; }
        [Required]
        public string YearMade { get; set; }
        public string Price { get; set; }
        public string? ImagePath { get; set; }
    }
}
