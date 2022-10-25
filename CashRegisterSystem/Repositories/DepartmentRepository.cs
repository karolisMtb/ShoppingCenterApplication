using CashRegisterSystem.Models;
using System.Collections.Generic;

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
        };
    }
}
