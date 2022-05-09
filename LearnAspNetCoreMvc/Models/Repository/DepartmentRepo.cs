using Dapper;
using LearnAspNetCoreMvc.Models.Interface;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LearnAspNetCoreMvc.Models.Repository
{
    public class DepartmentRepo : IDepartment
    {
        private readonly IConfiguration _configuration;
        private IDbConnection _sqlConnection => new SqlConnection(_configuration.GetConnectionString("DbConnectionString"));
        public DepartmentRepo(IConfiguration configuration)
        {
            this._configuration = configuration;
        }
        public IEnumerable<Department> GetDepartment()
        {
            var deparment = _sqlConnection.Query<Department>("Select * from Department");
            return deparment;
        }

        public Department GetDepartmentById(int deptId)
        {
            var department = _sqlConnection.QueryFirstOrDefault<Department>("Select * from Department where DepartmentId = @DepartmentId",
                param: new { @DepartmentId = deptId });
            return department;
        }
    }
}
