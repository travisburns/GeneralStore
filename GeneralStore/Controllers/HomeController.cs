using GeneralStore.Data;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    private readonly StoreContext _context;

    public HomeController(StoreContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var featuredItems = _context.Items.Take(6).ToList();  // Just grab 6 items, wanted to add further complexity to this for more categories but ran out of 'effective' time.
        return View(featuredItems);
    }
}