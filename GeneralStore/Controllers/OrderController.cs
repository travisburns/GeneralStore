using GeneralStore.Data;
using GeneralStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly StoreContext _context;

        public OrderController(StoreContext context)
        {
            _context = context;
        }

        public IActionResult Create(int itemId)
        {
            var item = _context.Items.Find(itemId);
            if (item == null)
                return NotFound();
            ViewBag.ItemId = itemId;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Order order, int itemId)
        {
            var item = _context.Items.Find(itemId);
            order.Items = new List<Item> { item };
            order.OrderDate = DateTime.Now;
            order.Status = "Pending";

            item.StockQuantity -= 1;
            item.InStock = item.StockQuantity > 0;

            _context.Orders.Add(order);
            _context.SaveChanges();
            return RedirectToAction("Confirmation", new { id = order.OrderId });
        }

        public IActionResult Confirmation(int id)
        {
            var order = _context.Orders.Include(o => o.Items).FirstOrDefault(o => o.OrderId == id);
            if (order == null)
                return NotFound();
            return View(order);
        }
    }
}