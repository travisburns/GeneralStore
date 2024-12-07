namespace GeneralStore.Models
{
    public class AdminViewModel
    {
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Item> Items { get; set; } = new List<Item>();
    }
}