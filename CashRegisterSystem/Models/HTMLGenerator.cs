using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem.Models
{
    public class HTMLGenerator
    {
        private List<ReportItem> _reportItems;
        public HTMLGenerator(List<ReportItem> reportItems)
        {
            _reportItems = reportItems;
        }

        string path = @"C:\Users\Karolis\source\repos\ShoppingCenterApplication\CashRegisterSystem\Files\HTMLTemplate.txt";
        string htmlColumnHeader = "<tr><th>Departmend</th>"
                                + "<th>Description</th>"
                                + "<th>Items sold</th>" 
                                + "<th>Sales each item</th>" 
                                + "<th>Profit each item</th></tr>";

        public void GenerateHTmlReport(int daysOfReport, List<ReportItem> reportItems)
        {            
            List<string> lines = new List<string>();
            try
            {
                string line;
                using(StreamReader HTMLTemplateFile = new StreamReader(path))
                {
                    while((line = HTMLTemplateFile.ReadLine()) != null)
                    {
                        lines.Add(line);
                        if(line == "<table>")
                        {
                            lines.Add(htmlColumnHeader);
                            foreach(ReportItem item in _reportItems)
                            {
                                lines.Add("<tr class='department'><td >" + item.Name + "</td></tr>");
                                lines.Add("<tr>");

                                foreach(FoodItem individualItem in item.DepartmentItems)
                                {
                                    lines.Add("<td></td>"+"<td>" + individualItem.Description + "</td>" +
                                    "<td>" + individualItem.Quantity + "</td>" +
                                    "<td>" + Math.Round(individualItem.Profit*1.29,2) + "</td>" +
                                    "<td>" + Math.Round(individualItem.Profit,2) + "</td>");
                                    lines.Add("</tr>");
                                }
                                   
                            }
                            lines.Add("<tr class='totalHeader'><th>Total items sold</th><th colspan=3 class='totalData1'>" + _reportItems.Sum(x => x.TotalItemsSold) + "</th></tr>");
                            lines.Add("<tr class='totalHeader'><th>Total sales</th><th colspan=4 class='totalData2'>" + Math.Round(_reportItems.Sum(x => x.GeneratedTotalSales),2) + "</th></tr>");
                            lines.Add("<tr class='totalHeader'><th>Total Profit</th><th colspan=4 class='totalData2'>" + Math.Round(_reportItems.Sum(x => x.GeneratedTotalProfit),2) + "</th></tr>");
                        }
                    }
                }
            } catch(Exception e)
            {
                Console.WriteLine($"HTML report could not be created {e.Message}");
            }

            File.WriteAllLines(@"C:\Users\Karolis\source\repos\ShoppingCenterApplication\CashRegisterSystem\Files\HTMLReport.html", lines);            
        }
    }
}
