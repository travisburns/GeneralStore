using System;
using System.ComponentModel.DataAnnotations;

namespace GeneralStore.Models
{

    public class Item
    {
        public int ItemId {get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public decimal Weight { get; set; }

        public string Category { get; set; }
        public bool InStock { get; set; }
        public int StockQuantity { get; set; }

        public DateTime DateListed { get; set; }
    }


}
