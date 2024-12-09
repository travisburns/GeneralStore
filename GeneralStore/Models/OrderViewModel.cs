using GeneralStore.Models;
using System.ComponentModel.DataAnnotations;

public class OrderViewModel
{
    public int ItemId { get; set; }

    public Item Item { get; set; } = new Item(); // Default to a new Item instance

    [Required]
    public string CustomerName { get; set; } = string.Empty; // Default value

    [Required]
    [EmailAddress]
    public string CustomerEmail { get; set; } = string.Empty; // Default value

    public decimal Subtotal { get; set; }
    public decimal Tax { get; set; }
    public decimal Total { get; set; }
}