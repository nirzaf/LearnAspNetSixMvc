using System.Collections.Generic;

namespace LearnAspNetCoreMvc.Models.Interface
{
    public interface IDepartment
    {
        //retrive all Deparment
        IEnumerable<Department> GetDepartment();

        //retrive department by Id
        Department GetDepartmentById(int deptId);
    }
}
