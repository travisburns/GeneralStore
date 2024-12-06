using GeneralStore.Data;
using GeneralStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class AdminController : Controller
{
    private readonly StoreContext _context;

    public AdminController(StoreContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var orders = _context.Orders.Include(o => o.Items).ToList();
        var items = _context.Items.ToList();
        ViewBag.TotalItems = items.Count();
        ViewBag.ActiveOrders = orders.Count(o => o.Status == "Pending");
        ViewBag.LowStock = items.Count(i => i.StockQuantity < 5);
        ViewBag.RecentOrders = orders.OrderByDescending(o => o.OrderDate).Take(5).ToList();
        return View(new AdminViewModel
        {
            Orders = orders,
            Items = items
        });
    }

    public IActionResult AddItem()
    {
        return View();
    }

    [HttpPost]
    public IActionResult AddItem(Item item)
    {
        if (ModelState.IsValid)
        {
            item.DateListed = DateTime.Now;
            item.InStock = item.StockQuantity > 0;
            _context.Items.Add(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(item);
    }

    // GET: Show edit form
    public IActionResult EditItem(int id)
    {
        var item = _context.Items.Find(id);
        if (item == null)
            return NotFound();
        return View(item);
    }

    // POST: Save edits
    [HttpPost]
    public IActionResult EditItem(Item item)
    {
        if (ModelState.IsValid)
        {
            item.InStock = item.StockQuantity > 0;
            _context.Update(item);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(item);
    }
}