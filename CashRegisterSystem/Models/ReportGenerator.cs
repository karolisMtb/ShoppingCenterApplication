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
                int ReportId = reportId;
                int DepartmentId = departmentId;
                string departmentName = DepartmentRepository.departments.Where(x=>x.Id == departmentId).First().Name;
                int totalItemsSold = SalesListRepository.FoodItemsToSell.Where(x => x.DepartmentId == departmentId).Sum(x => x.Quantity);
                double generatedTotalSales = FinancialService.GetTotalDepartmentSales(departmentId);
                double generatedTotalProfit = FinancialService.GetTotalDepartmentProfit(departmentId);
                List<FoodItem> reportItemsSold = GetDepartmentSoldItems(departmentId);

                reportItems.Add(new ReportItem(ReportId, DepartmentId, departmentName, totalItemsSold, generatedTotalSales, generatedTotalProfit, reportItemsSold));
            }
            return reportItems;
        }

        private List<FoodItem> GetDepartmentSoldItems(int departmentId)
        {
            List<FoodItem> list = new List<FoodItem>();

            foreach(FoodItem foodItem in SalesListRepository.FoodItemsToSell)
            {
                if( foodItem.DepartmentId == departmentId)
                {
                    list.Add(foodItem);
                }
            }
            return list;
        }
    }
}
