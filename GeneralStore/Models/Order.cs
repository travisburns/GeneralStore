using System;
using System.ComponentModel.DataAnnotations;

namespace GeneralStore.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

   
        public List<Item> Items { get; set; }

        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }
    }
}