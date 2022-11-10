using CashRegisterSystem.Models;
using CashRegisterSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CashRegisterSystem.Services
{
    // counterService iskvieciamas kiekviena diena. Jis iskvieciant uzpildo listus ka parduoti kiekvienam departamentui
    public class CounterService
    {
        private FoodItemRepository _foodItemRepository;
        private SalesListRepository _salesListRepository;

        public CounterService(FoodItemRepository foodItemRepository, SalesListRepository salesListRepository)
        {
            _foodItemRepository = foodItemRepository;
            _salesListRepository = salesListRepository;
        }

        // TODO: update the name of the service
        public void SelectFoodItemsToSell(int daysOfReport)
        {
            List<FoodItem> shoppingCart = new List<FoodItem>();
            List<FoodItem> Warehouse = _foodItemRepository.FoodItemWarehouse;

            for (int j = 0; j < daysOfReport; j++)
            {
                for (int i = 0; i < GetRandomItemsCount(); i++)
                {
                    FoodItem newItem = GetRandomItemFromShop();

                    FoodItem newCartItem = new FoodItem()
                    {
                        Id = newItem.Id,
                        Description = newItem.Description,
                        Quantity = GetRandomItemsQuantity(),
                        DepartmentId = newItem.DepartmentId,
                        UnitPrice = newItem.UnitPrice,
                        SalePrice = newItem.SalePrice
                    };

                    // kas tas
                    if(shoppingCart.Exists(x => x.Id == newItem.Id))
                    {
                        UpdateItemQuantityToSell(newCartItem.Id, newCartItem.Quantity, shoppingCart);
                        continue;
                    }

                    AddNewItemToSell(newCartItem, shoppingCart);
                    UpdateWarehouse(newCartItem.Id, newCartItem.Quantity, Warehouse);
                }
            }
            _salesListRepository.SetFoodItemsToSell(shoppingCart);
            _salesListRepository.UpdateWarehouse(Warehouse);
        }

        public List<FoodItem> UpdateWarehouse(int foodItemId, int quantity, List<FoodItem> Warehouse)
         {
            foreach (FoodItem foodItem in Warehouse)
            {
                if (foodItem.Id == foodItemId)
                {
                    foodItem.Quantity -= quantity;
                    if (foodItem.Quantity <= 0) // doesn't work, because of reference type
                    {
                        Console.WriteLine($"Baigiasi {foodItem.Description}, ir kiekie kuris liko yra {foodItem.Quantity}");
                        // call delivery method to stock up warehouse
                    }
                }
            }
            return Warehouse;
        }

        private List<FoodItem> UpdateItemQuantityToSell(int foodItemId, int quantity, List<FoodItem> shoppingCart)
        {
            shoppingCart.Where(x => x.Id == foodItemId).FirstOrDefault().Quantity += quantity;

            return shoppingCart;
        }

        private List<FoodItem> AddNewItemToSell(FoodItem foodItem, List<FoodItem> shoppingCart)
        {
            shoppingCart.Add(foodItem);
            
            return shoppingCart;
        }

        public int GetRandomItemsQuantity()
        {
            Random random = new Random();
            int quantity = random.Next(5, 20);
            return quantity;
        }

        public int GetRandomItemsCount()
        {
            Random random = new Random();
            int itemsCount = random.Next(10, 30);
            return itemsCount;
        }

        public FoodItem GetRandomItemFromShop()
        {
            Random random = new Random();
            int index = random.Next(0, _foodItemRepository.FoodItemWarehouse.Count); random.Next(0, _foodItemRepository.FoodItemWarehouse.Count);
            FoodItem randomItem = _foodItemRepository.FoodItemWarehouse[index];
            return randomItem;
        }
    }
}
