using System.Collections.Generic;
using WebApplication2.Model;

namespace WebApplication2.Service
{
    public interface IEmployeeService
    {
        public Employee AddEmployee(Employee employee);
        public List<Employee> GetEmployee();
        
    }
}
