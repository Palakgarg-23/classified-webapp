using EmployeeMicroservice.Infrastructure;
using EmployeeMicroservice.Models;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeMicroservice.Repository
{
    public class EmployeeRepo : IEmployee
    {
        private static List<Employee> Employees;
        public EmployeeRepo()
        {
            Employees = new List<Employee>()
            {
                new Employee{EmployeeId=2159447, EmployeeName="Surya Theja", Password="12345"},
                new Employee{EmployeeId=2142912, EmployeeName="Palak Garg", Password="12345"},
                new Employee{EmployeeId=2144009, EmployeeName="Mohammad Baban", Password="12345"},
                new Employee{EmployeeId=2141156, EmployeeName="Snigdha", Password="12345"},
                new Employee{EmployeeId=2159071, EmployeeName="Aishwarya", Password="12345"},
                new Employee{EmployeeId=2142922, EmployeeName="Aniket Kumar", Password="12345"},

            };
        }
        public Employee Getprofile(int employeeId)
        {
            Employee Employee = Employees.FirstOrDefault(c => c.EmployeeId == employeeId);
            return Employee;
        }
    }
}
