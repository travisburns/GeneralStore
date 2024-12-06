using GeneralStore.Models;
using System.ComponentModel.DataAnnotations;

public class OrderViewModel
{
    public int ItemId { get; set; }
    public Item Item { get; set; }
    [Required]
    public string CustomerName { get; set; }
    [Required]
    [EmailAddress]
    public string CustomerEmail { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Tax { get; set; }
    public decimal Total { get; set; }
}