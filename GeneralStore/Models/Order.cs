using System;
using System.ComponentModel.DataAnnotations;

namespace GeneralStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now; // Default to current time

        public string Status { get; set; } = string.Empty; // Default value

        public List<Item> Items { get; set; } = new List<Item>(); // Initialize as an empty list

        public string CustomerName { get; set; } = string.Empty; // Default value

        public string CustomerEmail { get; set; } = string.Empty; // Default value
    }
}