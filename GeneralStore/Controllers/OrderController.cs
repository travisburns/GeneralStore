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

            if (item == null)
            {
                ModelState.AddModelError(string.Empty, "Item not found.");
                return View(order);
            }

            if (item.StockQuantity <= 0)
            {
                ModelState.AddModelError(string.Empty, "Item is out of stock.");
                return View(order);
            }

            // Use the already tracked item directly
            order.Items = new List<Item> { item };

            order.OrderDate = DateTime.Now;
            order.Status = "Pending";

            // Adjust stock
            item.StockQuantity -= 1;
            item.InStock = item.StockQuantity > 0;

            try
            {
                // Explicitly save the order to avoid tracking conflicts
                _context.Orders.Add(order);
                _context.SaveChanges();

                Console.WriteLine($"Order ID saved: {order.OrderId}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving order: {ex.Message}");
                ModelState.AddModelError(string.Empty, "Failed to save order.");
                return View(order);
            }

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