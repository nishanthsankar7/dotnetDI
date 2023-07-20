using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using WebApplication2.Model;
using WebApplication2.Service;
using System.Data.SqlClient;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IConfiguration _configuration;
        public EmployeeController(IEmployeeService employeeService, IConfiguration configuration)
        {
            _employeeService = employeeService;
            _configuration = configuration;
        }
        
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var employee = _employeeService.GetEmployee();
            return (IEnumerable<Employee>)employee;
        }

        [HttpPost]
        public async Task<int>Post(Employee employee)
        {           
            var abc = _employeeService.AddEmployee(employee);
            return 200;
        }
    }
}
