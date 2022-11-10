using CashRegisterSystem.Repositories;
using CashRegisterSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem.Models
{
    public class ReportGenerator
    {
        SalesListRepository SalesListRepository;
        FinancialService FinancialService;
        DepartmentRepository DepartmentRepository;

        public ReportGenerator(SalesListRepository salesListRepository, FinancialService financialService, DepartmentRepository departmentRepository)
        {
            SalesListRepository = salesListRepository;
            FinancialService = financialService;
            DepartmentRepository = departmentRepository;
        }

        public List<ReportItem> GenerateReport()
        {
            List<int> departmentIds = new List<int>();
            foreach(var department in DepartmentRepository.departments)
            {
                departmentIds.Add(department.Id);
            }

            List<ReportItem> reportItems = new List<ReportItem>();
            int reportId = 0;

            foreach(var departmentId in departmentIds)
            {
                reportId++;
                List<FoodItem> reportItemsSold = GetDepartmentSoldItems(departmentId);

                reportItems.Add(new ReportItem(reportId,
                                               departmentId,
                                               DepartmentRepository.departments.FirstOrDefault(x=>x.Id == departmentId).Name,
                                               SalesListRepository.FoodItemsToSell.Where(x => x.DepartmentId == departmentId).Sum(x => x.Quantity),
                                               FinancialService.GetTotalDepartmentSales(departmentId),
                                               FinancialService.GetTotalDepartmentProfit(departmentId), reportItemsSold));
            }

            return reportItems;
        }

        private List<FoodItem> GetDepartmentSoldItems(int departmentId)
        {
            List<FoodItem> list = new List<FoodItem>();

            foreach(FoodItem foodItem in SalesListRepository.FoodItemsToSell)
            {
                if(foodItem.DepartmentId == departmentId)
                {
                    list.Add(foodItem);
                }
            }
            return list;
        }
    }
}
