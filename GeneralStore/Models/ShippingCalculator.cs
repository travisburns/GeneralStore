public class ShippingCalculator
{
    public decimal CalculateShipping(decimal weight, string shippingType)
    {
        decimal baseRate = 5.00m;
        decimal ratePerPound;

        switch (shippingType.ToLower())
        {
            case "standard":
                ratePerPound = 0.50m;
                break;
            case "express":
                ratePerPound = 1.00m;
                break;
            case "overnight":
                ratePerPound = 2.00m;
                break;
            default:
                ratePerPound = 0.50m;
                break;
        }

        return Math.Round(baseRate + (weight * ratePerPound), 2);
    }
}