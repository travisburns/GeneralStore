using System.Collections.Generic;

namespace GeneralStore.Models
{
    public class AdminViewModel
    {
        public List<Order> Orders { get; set; }
        public List<Item> Items { get; set; }
    }
}