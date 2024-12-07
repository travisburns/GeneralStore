using System;
using System.ComponentModel.DataAnnotations;

namespace GeneralStore.Models
{

    public class Item
    {
        public int ItemId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty; // Default value

        [Required]
        public string Description { get; set; } = string.Empty; // Default value

        [Required]
        public decimal Price { get; set; } = 0m; // Default value

        [Required]
        public decimal Weight { get; set; } = 0m; // Default value

        public string Category { get; set; } = string.Empty; // Default value

        public bool InStock { get; set; } = true; // Assume in stock by default

        public int StockQuantity { get; set; } = 0; // Default to zero

        public DateTime DateListed { get; set; } = DateTime.Now; // Default to current time
    }


}
