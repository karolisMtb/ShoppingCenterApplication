using CashRegisterSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IronXL;

namespace CashRegisterSystem.Repositories
{
    public class FoodItemRepository
    {

        // read file from excel

        //private void OrderDeliveryToStock(FoodItem foodItem)
        //{
        //    // stock up the warehouse
        //    // update warehouse
        //    foreach (FoodItem item in FoodItemWarehouse)
        //    {
        //        if(item.Id == foodItem.Id)
        //        {
        //            item.Quantity = 50;
        //        }
        //        continue;
        //    }
        //}

        public List<FoodItem> FoodItemWarehouse = new List<FoodItem>()
        {
            new FoodItem(){ Id = 11, Description = "Low fat milk 2.5%", Quantity = 150, SalePrice = 2.98, UnitPrice = 1.72, DepartmentId = 1},
            new FoodItem(){ Id = 12, Description = "Cheddar cheese", Quantity = 30, SalePrice = 2.05, UnitPrice = 0.89, DepartmentId = 1},
            new FoodItem(){ Id = 13, Description = "Butter", Quantity = 175, SalePrice = 1.85, UnitPrice = 0.65, DepartmentId = 1},
            new FoodItem(){ Id = 14, Description = "Buttermilk", Quantity = 70, SalePrice = 1.30, UnitPrice = 0.35, DepartmentId = 1},
            new FoodItem(){ Id = 15, Description = "Cream Cheese", Quantity = 35, SalePrice = 1.59, UnitPrice = 0.47, DepartmentId = 1},
            new FoodItem(){ Id = 16, Description = "Cherry yogurt", Quantity = 100, SalePrice = 0.99, UnitPrice = 0.20, DepartmentId = 1},
            new FoodItem(){ Id = 17, Description = "Condensed Milk", Quantity = 60, SalePrice = 3.16, UnitPrice = 1.75, DepartmentId = 1},
            new FoodItem(){ Id = 18, Description = "Custard milk", Quantity = 50, SalePrice = 2.45, UnitPrice = 1.55, DepartmentId = 1},
            new FoodItem(){ Id = 19, Description = "Sour Cream", Quantity = 150, SalePrice = 1.15, UnitPrice = 0.55, DepartmentId = 1},
            new FoodItem(){ Id = 111, Description = "Gorgonzolla cheese", Quantity = 25, SalePrice = 4.80, UnitPrice = 2.15, DepartmentId = 1},
            new FoodItem(){ Id = 112, Description = "Parmesan cheese", Quantity = 25, SalePrice = 4.65, UnitPrice = 1.95, DepartmentId = 1},
            new FoodItem(){ Id = 113, Description = "Bio eggs", Quantity = 175, SalePrice = 4.55, UnitPrice = 2.44, DepartmentId = 1},
            new FoodItem(){ Id = 114, Description = "Feta cheese", Quantity = 40, SalePrice = 1.98, UnitPrice = 1.02, DepartmentId = 1},
            new FoodItem(){ Id = 21, Description = "Banana", Quantity = 100, SalePrice = 1.59, UnitPrice = 0.70, DepartmentId = 2},
            new FoodItem(){ Id = 22, Description = "Lemon", Quantity = 40, SalePrice = 2.69, UnitPrice = 1.15, DepartmentId = 2},
            new FoodItem(){ Id = 23, Description = "Apples", Quantity = 200, SalePrice = 2.10, UnitPrice = 1.20, DepartmentId = 2},
            new FoodItem(){ Id = 24, Description = "Avocado", Quantity = 50, SalePrice = 1.99, UnitPrice = 1.00, DepartmentId = 2},
            new FoodItem(){ Id = 25, Description = "Grapes", Quantity = 55, SalePrice = 3.49, UnitPrice = 2.30, DepartmentId = 2},
            new FoodItem(){ Id = 26, Description = "Pears", Quantity = 60, SalePrice = 1.49, UnitPrice = 0.70, DepartmentId = 2},
            new FoodItem(){ Id = 31, Description = "Sparkling water", Quantity = 150, SalePrice = 0.70, UnitPrice = 0.30, DepartmentId = 3},
            new FoodItem(){ Id = 32, Description = "Still water", Quantity = 150, SalePrice = 0.75, UnitPrice = 0.25, DepartmentId = 3},
            new FoodItem(){ Id = 33, Description = "Bear", Quantity = 100, SalePrice = 1.49, UnitPrice = 0.70, DepartmentId = 3},
            new FoodItem(){ Id = 34, Description = "Cider", Quantity = 30, SalePrice = 2.50, UnitPrice = 1.99, DepartmentId = 3},
            new FoodItem(){ Id = 35, Description = "Red wine", Quantity = 50, SalePrice = 11.50, UnitPrice = 2.75, DepartmentId = 3},
            new FoodItem(){ Id = 36, Description = "White wine", Quantity = 50, SalePrice = 11.75, UnitPrice = 2.95, DepartmentId = 3},
            new FoodItem(){ Id = 37, Description = "Cola", Quantity = 70, SalePrice = 1.29, UnitPrice = 0.15, DepartmentId = 3},
            new FoodItem(){ Id = 38, Description = "Energy drink", Quantity = 60, SalePrice = 1.49, UnitPrice = 0.20, DepartmentId = 3},
            new FoodItem(){ Id = 41, Description = "Bread", Quantity = 60, SalePrice = 3.55, UnitPrice = 2.10, DepartmentId = 4},
            new FoodItem(){ Id = 42, Description = "Flatbread", Quantity = 75, SalePrice = 2.15, UnitPrice = 1.00, DepartmentId = 4},
            new FoodItem(){ Id = 43, Description = "Pie", Quantity = 50, SalePrice = 1.70, UnitPrice = 0.50, DepartmentId = 4},
            new FoodItem(){ Id = 44, Description = "Bagel", Quantity = 50, SalePrice = 1.55, UnitPrice = 0.39, DepartmentId = 4},
            new FoodItem(){ Id = 45, Description = "Muffin", Quantity = 100, SalePrice = 2.60, UnitPrice = 0.95, DepartmentId = 4},
            new FoodItem(){ Id = 46, Description = "Brownie", Quantity = 80, SalePrice = 2.90, UnitPrice = 0.87, DepartmentId = 4},
            new FoodItem(){ Id = 47, Description = "Chocolate", Quantity = 60, SalePrice = 3.10, UnitPrice = 1.12, DepartmentId = 4},
            new FoodItem(){ Id = 51, Description = "Cucumber", Quantity = 75, SalePrice = 2.35, UnitPrice = 0.55, DepartmentId = 5},
            new FoodItem(){ Id = 52, Description = "Tomatoes", Quantity = 70, SalePrice = 1.89, UnitPrice = 0.62, DepartmentId = 5},
            new FoodItem(){ Id = 53, Description = "Carrots", Quantity = 80, SalePrice = 1.75, UnitPrice = 0.43, DepartmentId = 5},
            new FoodItem(){ Id = 54, Description = "Cabage", Quantity = 40, SalePrice = 0.89, UnitPrice = 0.15, DepartmentId = 5},
            new FoodItem(){ Id = 55, Description = "Onions", Quantity = 50, SalePrice = 0.99, UnitPrice = 0.34, DepartmentId = 5},
            new FoodItem(){ Id = 56, Description = "Potatoe", Quantity = 65, SalePrice = 1.45, UnitPrice = 0.73, DepartmentId = 5},
            new FoodItem(){ Id = 57, Description = "Broccoli", Quantity = 60, SalePrice = 2.45, UnitPrice = 1.00, DepartmentId = 5}

        };
        
    }


}
