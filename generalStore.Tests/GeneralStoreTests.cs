using Xunit;
using GeneralStore.Controllers;
using GeneralStore.Models;
using GeneralStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralStore.Tests
{
    public class GeneralStoreTests
    {
        private readonly StoreContext _context;
        private readonly ShopController _shopController;
        private readonly AdminController _adminController;
        private readonly ShippingCalculator _calculator;

        public GeneralStoreTests()
        {
            var options = new DbContextOptionsBuilder<StoreContext>()
                .UseInMemoryDatabase(databaseName: "TestGeneralStore")
                .Options;

            _context = new StoreContext(options);
            _shopController = new ShopController(_context);
            _adminController = new AdminController(_context);
            _calculator = new ShippingCalculator();
        }

        [Fact]
        public void DatabaseDriven_CanSearchItems()
        {
          
            var item = new Item
            {
                Name = "Test Desk",
                Description = "A test item",
                Price = 100m,
                Category = "Furniture"
            };
            _context.Items.Add(item);
            _context.SaveChanges();

         
            var result = _shopController.Index("Furniture", null) as ViewResult;
            var items = result?.Model as List<Item>;

            Assert.NotNull(items);
            Assert.Contains(items, i => i.Category == "Furniture");
        }

        [Fact]
        public void DatabaseDriven_CanAddNewItems()
        {
           
            var newItem = new Item
            {
                Name = "New Item",
                Description = "Test description",
                Price = 50m,
                Category = "Test",
                StockQuantity = 5
            };

            var result = _adminController.AddItem(newItem) as RedirectToActionResult;

            Assert.NotNull(result);
            Assert.Equal("Index", result.ActionName);
            var savedItem = _context.Items.FirstOrDefault(i => i.Name == "New Item");
            Assert.NotNull(savedItem);
        }

        [Fact]
        public void InteractiveFeature_ShippingCalculatorWorks()
        {
       
            decimal cost = _calculator.CalculateShipping(10m, "express");

            // Assert
            Assert.True(cost > 0);
            Assert.Equal(15.00m, cost); // Base rate (5.00) + (10 * 1.00 express rate)
        }

        [Fact]
        public void DomainModel_HasRequiredProperties()
        {
      
            var item = new Item();
            var order = new Order();

            var itemProps = typeof(Item).GetProperties();
            var orderProps = typeof(Order).GetProperties();

            Assert.True(itemProps.Length + orderProps.Length >= 7);
            Assert.True(itemProps.Length + orderProps.Length <= 15);
        }
    }
}