using CashRegisterSystem.Models;
using System.Collections.Generic;

namespace CashRegisterSystem.Repositories
{
    public class SalesListRepository
    {
        public List<FoodItem> FoodItemsToSell = new List<FoodItem>();
        public List<FoodItem> Warehouse = new List<FoodItem>();

        public void SetFoodItemsToSell(List<FoodItem> shoppingCart)
        {
            FoodItemsToSell = shoppingCart;
        }

        public void UpdateWarehouse(List<FoodItem> warehouse)
        {
            Warehouse = warehouse;
        }
    }
}
