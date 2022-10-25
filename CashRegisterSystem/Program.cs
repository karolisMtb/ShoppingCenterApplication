using CashRegisterSystem.Controller;
using CashRegisterSystem.Models;
using CashRegisterSystem.Repositories;
using CashRegisterSystem.Services;
using System;
using System.Collections.Generic;

namespace CashRegisterSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FoodItemRepository FoodItemRepository = new FoodItemRepository();
            SalesListRepository SalesListRepository = new SalesListRepository();
            FinancialService FinancialService = new FinancialService(SalesListRepository);
            DepartmentRepository DepartmentRepository = new DepartmentRepository();
            CounterService CounterService = new CounterService(FoodItemRepository, SalesListRepository);
            ReportGenerator ReportGenerator = new ReportGenerator(SalesListRepository, FinancialService, DepartmentRepository);
            CashRegisterController CashRegController = new CashRegisterController(ReportGenerator, SalesListRepository, CounterService, FinancialService);

            int days;
            Console.WriteLine("How many days report of sales should be?");
            if(!int.TryParse(Console.ReadLine(), out days))
            {
                do
                {                
                    Console.WriteLine("Wrong input.");
                    Console.WriteLine("Try again.");
                    int.TryParse(Console.ReadLine(), out days);
                } while (days <= 0); 
            }


            CashRegController.StartCounterService(days);
            var list = CashRegController.GenerateFinalReport();
            
            HTMLGenerator HtmlGenerator = new HTMLGenerator(list);
            HtmlGenerator.GenerateHTmlReport(days, list);
        }
    }
}