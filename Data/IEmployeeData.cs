using RestApiCrud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCrud.Data
{
    public interface IEmployeeData
    {
        List<Employee> GetEmployees();

        Employee GetSingle(int id);

        Employee AddEmployee(Employee employee);

        bool DeleteEmployee(int id);

        Employee EditEmployee(Employee employee);
    }
}
