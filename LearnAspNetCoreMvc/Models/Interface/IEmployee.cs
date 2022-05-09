using System.Collections.Generic;

namespace LearnAspNetCoreMvc.Models.Interface
{
    public interface IEmployee
    {
        //retrive all employees
        IEnumerable<Employee> GetEmployee();

        //retrive employee by Id
        Employee GetEmpoyeeById(int empId);
    }
}
