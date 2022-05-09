using Dapper;
using LearnAspNetCoreMvc.Models.Interface;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LearnAspNetCoreMvc.Models.Repository
{
    // inharite from iemployee for implementation
    public class EmployeeRepo : IEmployee
    {
        private readonly IConfiguration _configuration;
        private IDbConnection _sqlConnection => new SqlConnection(_configuration.GetConnectionString("DbConnectionString"));
        //create new constructor for inject the configuration - we will get connection string from configuration setting
        //lets check the connections string
        public EmployeeRepo(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public IEnumerable<Employee> GetEmployee()
        {
            string sql = @"Select 
                    e.EmployeeId,
                    e.FirstName,
                    e.LastName,
                    e.Password,
                    e.IsActive,
                    e.DepartmentId,
                    d.DepartmentName
                    from Employee as e
                    inner join Department as d on e.DepartmentId = d.DepartmentId";
            var employee = _sqlConnection.Query<Employee, Department, Employee>(sql, map: (e, d) =>
            {
                e.Department = d;
                return e;
            }, splitOn: "DepartmentId");
            return employee;
        }

        public Employee GetEmpoyeeById(int empId)
        {
            var employee = _sqlConnection.QueryFirstOrDefault<Employee>("Select * from Employee where EmployeeId = @EmployeeId",
                param: new { @EmployeeId = empId });
            return employee;
        }

        //create same implementation for department
    }
}
