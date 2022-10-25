using CashRegisterSystem.Models;
using CashRegisterSystem.Repositories;
using CashRegisterSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem.Controller
{
    // TODO: Change Name
    public class CashRegisterController
    {
        ReportGenerator ReportGenerator;
        SalesListRepository SalesListRepository;
        CounterService CounterService;
        FinancialService FinancialService;

        public CashRegisterController(ReportGenerator reportGenerator, SalesListRepository salesListRepository,  CounterService counterService, FinancialService financialService)
        {
            ReportGenerator = reportGenerator;
            SalesListRepository = salesListRepository;
            CounterService = counterService;
            FinancialService = financialService;
        }

        public void StartCounterService(int daysOfReport)
        {
            CounterService.SelectFoodItemsToSell(daysOfReport);
        }

        public List<ReportItem> GenerateFinalReport()
        {
            return ReportGenerator.GenerateReport();
        }
    }
}
