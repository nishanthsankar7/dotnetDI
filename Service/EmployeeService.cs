using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebApplication2.Model;

namespace WebApplication2.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IConfiguration _configuration;
        public EmployeeService(IConfiguration configuration) {
            
            tempEmpl.EmployeeId = 1;
            tempEmpl.EmployeeName = "Test";
            tempEmpl.EmployeeAddress = "India";
            list.Add(tempEmpl);
            _configuration = configuration;
        }
        Employee tempEmpl = new Employee();
        List<Employee> list = new List<Employee>();
        
        public Employee AddEmployee(Employee employee)
        {
            list.Add(employee);
            string query = @"insert into dbo.Employee
                             (EmployeeName,EmployeeAddress,EmployeeId)
                       values (@EmployeeName,@EmployeeAddress,@EmployeeId)";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myCommand.Parameters.AddWithValue("@EmployeeName", employee.EmployeeName);
                    myCommand.Parameters.AddWithValue("@EmployeeAddress", employee.EmployeeAddress);
                    myCommand.Parameters.AddWithValue("@EmployeeId", employee.EmployeeId);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }
            return employee;
        }

        public List<Employee> GetEmployee()
        {
            return list;
        }
    }
}
