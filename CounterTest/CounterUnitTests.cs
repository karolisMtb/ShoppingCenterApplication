using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CounterTests
{
    using CashRegisterSystem;
    using CashRegisterSystem.Models;
    using CashRegisterSystem.Repositories;
    using CashRegisterSystem.Services;
    using System.Linq;

    [TestClass]
    public class CounterUnitTests
    {
        [TestMethod]
        public void UpdateWarehouseItemQuantity_returnsReducedQuantity()
        {

            // Arrange
            FoodItemRepository foodItemRepository = new FoodItemRepository();
            SalesListRepository salesListRepository = new SalesListRepository();
            CounterService counterService = new CounterService(foodItemRepository, salesListRepository);
            int foodItemId = 57;
            int quantity = 15;


            // Act

            int expected = 45;
            var resultList = counterService.UpdateWarehouse(foodItemId, quantity, foodItemRepository.FoodItemWarehouse);
            int actualQuantity = resultList.Where(x => x.Id == foodItemId).First().Quantity;
            // Assert

            Assert.AreEqual(expected, actualQuantity);
        }

        [TestMethod]

        public void GetTotalSales_returnsSalesAmount()
        {
            // Arrange

            SalesListRepository salesListRepository = new SalesListRepository();
            FinancialService financialService = new FinancialService(salesListRepository);

            // Act

            salesListRepository.FoodItemsToSell.Add(new FoodItem() { Id = 35, Quantity = 5, UnitPrice = 2.00, SalePrice = 12.00 });
            // (quantity * salePrice - quantity * unitPrice) * 1.29
            double expected = 64.5;
            double actual = financialService.GetTotalSales();

            // Assert

            Assert.AreEqual(expected, actual);
        }
    }
}
