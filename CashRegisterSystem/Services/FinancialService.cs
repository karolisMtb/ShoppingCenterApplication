using CashRegisterSystem.Models;
using CashRegisterSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem.Services
{
    public class FinancialService
    {
        public SalesListRepository _salesListRepository;

        public FinancialService(SalesListRepository salesListRepository)
        {
            _salesListRepository = salesListRepository;
        }

        public double GetTotalProfit()
        {
            double totalProfit = Math.Round(_salesListRepository.FoodItemsToSell.Sum(x => x.Profit), 2);
            return totalProfit;
        }

        public double GetTotalSales()
        {
            double totalSalesSum = Math.Round(GetTotalProfit() * 1.29,2);
            return totalSalesSum;
        }


        public double GetTotalDepartmentSales(int departmentId)
        {
            var itemsSold = _salesListRepository.FoodItemsToSell;
            double sum = 0;
            foreach(var item in itemsSold)
            {
                if(item.DepartmentId == departmentId)
                {
                    sum += Math.Round(item.Profit,2);
                }
            }
            return sum;
        }

        public double GetTotalDepartmentProfit(int departmentId)
        {
            double profit = Math.Round(GetTotalDepartmentSales(departmentId) * 0.81,2);
            return profit;
        }
    }
}
