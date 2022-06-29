using RestApiCrud.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestApiCrud.Data
{
    public class MarkEmployee : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>()
        {
            new Employee()
            {
                Id = 1,
                code = Guid.NewGuid(),
                Name = "can acn"
            },
            new Employee()
            {
                Id = 2,
                code = Guid.NewGuid(),
                Name = "can2"
            },
            new Employee()
            {
                Id = 3,
                code = Guid.NewGuid(),
                Name = "can33 33"
            },
        };

        public Employee AddEmployee(Employee employee)
        {
            employee.code = Guid.NewGuid();
            employee.Id = 10;
            employees.Add(employee);
            return employee;
        }

        public bool DeleteEmployee(int id)
        {
            var deletedEmployee = employees.Find(p => p.Id == id);
            if(deletedEmployee != null)
            {
                employees.Remove(deletedEmployee);
                return true;
            }
            else
            {
                return false;
            }
        }

        public Employee EditEmployee(Employee employee)
        {
            var existedEmployee = employees.Find(p => p.Id == employee.Id);
            //var existedEmployee1 = employees.GetSingle(employee.Id);
            if(existedEmployee != null)
            {
                existedEmployee.Id = employee.Id;
                existedEmployee.Name = employee.Name;
                existedEmployee.code = Guid.NewGuid();
                return existedEmployee;
            }
            return null;
        }

        public Employee GetSingle(int id)
        {
            var emlooyeReturn = employees.SingleOrDefault(p => p.Id == id);
            return emlooyeReturn;
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }

    }
}
