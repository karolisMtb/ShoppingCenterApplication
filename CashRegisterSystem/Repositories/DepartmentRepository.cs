using CashRegisterSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CashRegisterSystem.Repositories
{
    public class DepartmentRepository
    {
        public List<Department> departments = new List<Department>()
        {
            new Department(){ Id = 1, Name = "Milk"},
            new Department(){ Id = 2, Name = "Fruits"},
            new Department(){ Id = 3, Name = "Drinks"},
            new Department(){ Id = 4, Name = "Bread"},
            new Department(){ Id = 5, Name = "Vegetable"},
            //new Department(){ Id = 6, Name = "Empties"}
        };
    }
}
