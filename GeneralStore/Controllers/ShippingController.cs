using Microsoft.AspNetCore.Mvc;

public class ShippingController : Controller
{
    private readonly ShippingCalculator _calculator;

    public ShippingController(ShippingCalculator calculator)
    {
        _calculator = calculator;
    }

    public IActionResult Calculate()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Calculate(decimal weight, string shippingType)
    {
        decimal cost = _calculator.CalculateShipping(weight, shippingType);
        ViewBag.Cost = cost;
        return View();
    }
}