using System.ComponentModel.DataAnnotations;

namespace AspNetCore.Models
{
    public class Item
    {
        [Key]
        public int Id {get; set; }

        [Required]
        public string Description {get; set; }

        [Required]
        public bool Completed {get; set; }
    }
}