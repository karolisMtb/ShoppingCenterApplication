using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem.Models
{
    public class FoodItem
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public double UnitPrice { get; set; }
        public double SalePrice { get; set; }
        public int Quantity { get; set; }
        public int DepartmentId { get; set; }
        public double Profit
        {
            get
            {
                return (SalePrice * Quantity) - (UnitPrice * Quantity);
            }
        }
    }
}
