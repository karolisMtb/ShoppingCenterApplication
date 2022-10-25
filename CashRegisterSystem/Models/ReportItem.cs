using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem.Models
{
    public class ReportItem
    {
        public int ReportId { get; set; }
        public int DepartmentId { get; }
        public string Name { get; set; }
        public int TotalItemsSold { get; }
        public double GeneratedTotalSales { get; }
        public double GeneratedTotalProfit { get; }
        public List<FoodItem> DepartmentItems { get; }

        public ReportItem(int reportId, int departmentId, string name, int totalItemsSold, double generatedToTalSales, double generatedTotalProfit, List<FoodItem> departmentItems)
        {
            ReportId = reportId;
            DepartmentId = departmentId;
            Name = name;
            TotalItemsSold = totalItemsSold;
            GeneratedTotalSales = generatedToTalSales;
            GeneratedTotalProfit = generatedTotalProfit;
            DepartmentItems = departmentItems;
        }
    }
}
