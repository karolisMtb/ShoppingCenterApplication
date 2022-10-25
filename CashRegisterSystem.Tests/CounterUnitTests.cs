using Microsoft.VisualStudio.TestTools.UnitTesting;
using CashRegisterSystem;
using CashRegisterSystem.Models;
using CashRegisterSystem.Repositories;
using CashRegisterSystem.Services;
using System.Linq;

namespace CounterTests
{
    // TODO: Write more tests
    [TestClass]
    public class CounterUnitTests
    {
        // Integration test
        [TestMethod]
        public void UpdateWarehouseItemQuantity_returnsReducedQuantity()
        {
            // Arrange
            FoodItemRepository foodItemRepository = new FoodItemRepository();
            SalesListRepository salesListRepository = new SalesListRepository();
            CounterService counterService = new CounterService(foodItemRepository, salesListRepository);
            int foodItemId = 57;
            int quantity = 15;
            int expected = 45;

            // Act
            var resultList = counterService.UpdateWarehouse(foodItemId, quantity, foodItemRepository.FoodItemWarehouse);
            int actualQuantity = resultList.First(x => x.Id == foodItemId).Quantity;

            // Assert
            Assert.AreEqual(expected, actualQuantity);
        }

        [TestMethod]
        public void GetRandomItemsCount_ReturnsNotNull()
        {
            // Arrange
            FoodItemRepository foodItemRepository = new FoodItemRepository();
            SalesListRepository salesListRepository = new SalesListRepository();
            CounterService counterService = new CounterService(foodItemRepository, salesListRepository);

            // Act + Assert
            Assert.NotNull(counterService.GetRandomItemsCount());
        }

        [TestMethod]
        public void GetRandomItemsQuantity_ReturnsNotNull()
        {
            // Arrange
            FoodItemRepository foodItemRepository = new FoodItemRepository();
            SalesListRepository salesListRepository = new SalesListRepository();
            CounterService counterService = new CounterService(foodItemRepository, salesListRepository);

            // Act + Assert
            Assert.NotNull(counterService.GetRandomItemsQuantity());
        }

        // TODO: Padaryti kazka dar
        [TestMethod]
        public void GetTotalSales_returnsSalesAmount()
        {
            // Arrange
            SalesListRepository salesListRepository = new SalesListRepository();
            FinancialService financialService = new FinancialService(salesListRepository);
            double expectedResultWithSalesTax = 64.5;

            // Act
            salesListRepository.FoodItemsToSell.Add(new FoodItem() { Id = 35, Quantity = 5, UnitPrice = 2.00, SalePrice = 12.00 });
            double actual = financialService.GetTotalSales();

            // Assert
            Assert.AreEqual(expectedResultWithSalesTax, actual);
        }
    }
}
