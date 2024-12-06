using GeneralStore.Data;
using Microsoft.AspNetCore.Mvc;

public class ShopController : Controller
{
    private readonly StoreContext _context;

    public ShopController(StoreContext context)
    {
        _context = context;
    }

    public IActionResult Index(string category, string search)  
    {
        var items = _context.Items.AsQueryable();

        if (!string.IsNullOrEmpty(category))
        {
            items = items.Where(i => i.Category == category);
        }

        if (!string.IsNullOrEmpty(search)) 
        {
            items = items.Where(i => i.Name.Contains(search) ||
                                    i.Description.Contains(search));  
        }

        return View(items.ToList());
    }

    public IActionResult Details(int id)
    {
        var item = _context.Items.FirstOrDefault(i => i.ItemId == id);
        if (item == null)
        {
            return NotFound();
        }
        return View(item);
    }
}